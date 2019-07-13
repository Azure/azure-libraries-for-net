// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine.
    /// </summary>
    internal partial class VirtualMachineMsiHelper : RoleAssignmentHelper
    {
        private ISet<string> creatableIdentityKeys;
        private IDictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue> userAssignedIdentities;
        private VirtualMachineImpl virtualMachine;

        /// <summary>
        /// Creates VirtualMachineMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        internal VirtualMachineMsiHelper(IGraphRbacManager rbacManager, VirtualMachineImpl virtualMachine) 
            : base(rbacManager, new VmIdProvider(virtualMachine))
        {
            this.virtualMachine = virtualMachine;
            this.creatableIdentityKeys = new HashSet<string>();
            this.userAssignedIdentities = new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>();
        }

        internal void Clear()
        {
            this.userAssignedIdentities.Clear();
        }

        internal void HandleExternalIdentities()
        {
            if (this.userAssignedIdentities.Any())
            {
                this.virtualMachine.Inner.Identity.UserAssignedIdentities = this.userAssignedIdentities;
            }
        }

        internal void HandleExternalIdentities(VirtualMachineUpdate vmUpdate)
        {
            if (this.HandleRemoveAllExternalIdentitiesCase(vmUpdate))
            {
                return;
            }
            else
            {
                // At this point one of the following condition is met:
                //
                // 1. User don't want touch the 'VM.Identity.UserAssignedIdentities' property
                //      [this.userAssignedIdentities.Empty() == true]
                // 2. User want to add some identities to 'VM.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.virtualMachine.Inner().Identity() != null]
                // 3. User want to remove some (not all) identities in 'VM.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.virtualMachine.Inner().Identity() != null]
                //      Note: The scenario where this.virtualMachine.Inner().Identity() is null in #3 is already handled in
                //      handleRemoveAllExternalIdentitiesCase method
                // 4. User want to add and remove (all or subset) some identities in 'VM.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.virtualMachine.Inner().Identity() != null]
                //
                var currentIdentity = this.virtualMachine.Inner.Identity;
                vmUpdate.Identity = currentIdentity;

                if (this.userAssignedIdentities.Any())
                {
                    // At this point its guaranteed that 'currentIdentity' is not null so vmUpdate.Identity() is.
                    vmUpdate.Identity.UserAssignedIdentities = this.userAssignedIdentities;
                }
                else
                {
                    // User don't want to touch 'VM.Identity.UserAssignedIdentities' property
                    if (currentIdentity != null)
                    {
                        // and currently there is identity exists or user want to manipulate some other properties of
                        // identity, set identities to null so that it won't send over wire.
                        currentIdentity.UserAssignedIdentities = null;
                    }
                }
            }
        }
        
        internal void ProcessCreatedExternalIdentities()
        {
            foreach (var key in this.creatableIdentityKeys)
            {
                var identity = (IIdentity)this.virtualMachine.CreatorTaskGroup.CreatedResource(key);
                this.userAssignedIdentities[identity.Id] = new VirtualMachineIdentityUserAssignedIdentitiesValue();
            }
            this.creatableIdentityKeys.Clear();
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the virtual machine.
        /// </summary>
        /// <param name="identity">An identity to associate.</param>
        /// <return>VirtualMachineMsiHandler.</return>
        internal VirtualMachineMsiHelper WithExistingExternalManagedServiceIdentity(IIdentity identity)
        {
            this.InitVMIdentity(Fluent.Models.ResourceIdentityType.UserAssigned);
            this.userAssignedIdentities[identity.Id] = new VirtualMachineIdentityUserAssignedIdentitiesValue();
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be enabled in the virtual machine.
        /// If MSI extension is not already installed then it will be installed with access token
        /// port as 50342.
        /// </summary>
        /// <return>VirtualMachineMsiHandler.</return>
        internal VirtualMachineMsiHelper WithLocalManagedServiceIdentity()
        {
            this.InitVMIdentity(Fluent.Models.ResourceIdentityType.SystemAssigned);
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">Yet-to-be-created identity to be associated with the virtual machine.</param>
        /// <return>VirtualMachineMsiHandler.</return>
        internal VirtualMachineMsiHelper WithNewExternalManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity)
        {
            if (!this.creatableIdentityKeys.Contains(creatableIdentity.Key))
            {
                this.InitVMIdentity(Fluent.Models.ResourceIdentityType.UserAssigned);
                this.creatableIdentityKeys.Add(creatableIdentity.Key);
                ((creatableIdentity as IResourceCreator<IHasId>).CreatorTaskGroup).Merge(this.virtualMachine.CreatorTaskGroup);
            }
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be removed from the list of External Managed Service Identity
        /// associated with the virtual machine machine.
        /// </summary>
        /// <param name="identityId">Resource id of the identity.</param>
        /// <return>VirtualMachineMsiHandler.</return>
        internal VirtualMachineMsiHelper WithoutExternalManagedServiceIdentity(string identityId)
        {
            this.userAssignedIdentities[identityId] = null;
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be disabled in the virtual machine.
        /// </summary>
        /// <return>VirtualMachineMsiHandler.</return>
        internal VirtualMachineMsiHelper WithoutLocalManagedServiceIdentity()
        {
            if (this.virtualMachine.Inner.Identity == null || 
                this.virtualMachine.Inner.Identity.Type == null || 
                this.virtualMachine.Inner.Identity.Type.Value.Equals(Models.ResourceIdentityType.None) || 
                this.virtualMachine.Inner.Identity.Type.Value.Equals(Models.ResourceIdentityType.UserAssigned))
            {
                return this;
            }
            else if (this.virtualMachine.Inner.Identity.Type.Value.Equals(Models.ResourceIdentityType.SystemAssigned))
            {
                this.virtualMachine.Inner.Identity.Type = Models.ResourceIdentityType.None;
            }
            else if (this.virtualMachine.Inner.Identity.Type.Value.Equals(Models.ResourceIdentityType.SystemAssignedUserAssigned))
            {
                this.virtualMachine.Inner.Identity.Type = Models.ResourceIdentityType.UserAssigned;
            }
            return this;
        }

        /// <summary>
        /// Method that handle the case where user request indicates all it want to do is remove all identities associated
        /// with the virtual machine.
        /// </summary>
        /// <param name="vmUpdate">The vm update payload model.</param>
        /// <return>True if user indented to remove all the identities.</return>
        private bool HandleRemoveAllExternalIdentitiesCase(VirtualMachineUpdate vmUpdate)
        {
            if (this.userAssignedIdentities.Any())
            {
                int rmCount = 0;
                foreach(var v in this.userAssignedIdentities.Values)
                {
                    if (v == null)
                    {
                        rmCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                var containsRemoveOnly = rmCount > 0 && rmCount == this.userAssignedIdentities.Count;
                // Check if user request contains only request for removal of identities.
                if (containsRemoveOnly)
                {
                    var currentIds = new HashSet<string>();
                    var currentIdentity = this.virtualMachine.Inner.Identity;
                    if (currentIdentity != null && currentIdentity.UserAssignedIdentities != null)
                    {
                        foreach(var id in currentIdentity.UserAssignedIdentities.Keys)
                        {
                            currentIds.Add(id.ToLower());
                        }
                    }

                    var removeIds = new HashSet<string>();

                    foreach (var entrySet in this.userAssignedIdentities)
                    {
                        if (entrySet.Value == null)
                        {
                            removeIds.Add(entrySet.Key.ToLower());
                        }
                    }
                    // If so check user want to remove all the identities
                    var removeAllCurrentIds = currentIds.Count == removeIds.Count && !removeIds.Any(id => !currentIds.Contains(id)); // Java part looks like this -> && currentIds.ContainsAll(removeIds);
                    if (removeAllCurrentIds)
                    {
                        // If so adjust  the identity type [Setting type to SYSTEM_ASSIGNED orNONE will remove all the identities]
                        if (currentIdentity == null || currentIdentity.Type == null)
                        {
                            vmUpdate.Identity = new VirtualMachineIdentity { Type = Models.ResourceIdentityType.None };
                        }
                        else if (currentIdentity.Type.Equals(Models.ResourceIdentityType.SystemAssignedUserAssigned))
                        {
                            vmUpdate.Identity = currentIdentity;
                            vmUpdate.Identity.Type = Models.ResourceIdentityType.SystemAssigned;
                        }
                        else if (currentIdentity.Type.Equals(Models.ResourceIdentityType.UserAssigned))
                        {
                            vmUpdate.Identity = currentIdentity;
                            vmUpdate.Identity.Type = Models.ResourceIdentityType.None;
                        }
                        // and set identities property in the payload model to null so that it won't be sent
                        vmUpdate.Identity.UserAssignedIdentities = null;
                        return true;
                    }
                    else
                    {
                        // Check user is asking to remove identities though there is no identities currently associated
                        if (currentIds.Count == 0 && 
                            removeIds.Count != 0 && 
                            currentIdentity == null)
                        {
                            // If so we are in a invalid state but we want to send user input to service and let service
                            // handle it (ignore or error).
                            vmUpdate.Identity = new VirtualMachineIdentity { Type = Models.ResourceIdentityType.None };
                            vmUpdate.Identity.UserAssignedIdentities = null;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Initialize VM's identity property.
        /// </summary>
        /// <param name="identityType">The identity type to set.</param>
        private void InitVMIdentity(Fluent.Models.ResourceIdentityType identityType)
        {
            if (!identityType.Equals(Models.ResourceIdentityType.UserAssigned) && 
                !identityType.Equals(Models.ResourceIdentityType.SystemAssigned))
            {
                throw new ArgumentException("Invalid argument: " + identityType);
            }

            var virtualMachineInner = this.virtualMachine.Inner;
            if (virtualMachineInner.Identity == null)
            {
                virtualMachineInner.Identity = new VirtualMachineIdentity();
            }

            if (virtualMachineInner.Identity.Type == null || 
                virtualMachineInner.Identity.Type.Equals(Models.ResourceIdentityType.None) || 
                virtualMachineInner.Identity.Type.Equals(identityType))
            {
                virtualMachineInner.Identity.Type = identityType;
            }
            else
            {
                virtualMachineInner.Identity.Type = Models.ResourceIdentityType.SystemAssignedUserAssigned;
            }
        }

        /// <summary>
        /// Gets the MSI identity type.
        /// </summary>
        /// <param name="inner">the virtual machine inner</param>
        /// <returns>the MSI identity type</returns>
        internal static Models.ResourceIdentityType? ManagedServiceIdentityType(VirtualMachineInner inner)
        {
            if (inner.Identity != null)
            {
                return inner.Identity.Type;
            }
            return null;
        }
    }


    internal class VmIdProvider : IIdProvider
    {
        private readonly VirtualMachineImpl vm;

        internal VmIdProvider(VirtualMachineImpl vm)
        {
            this.vm = vm;
        }

        public string PrincipalId
        {
            get
            {
                if (this.vm.Inner != null && this.vm.Inner.Identity != null)
                {
                    return this.vm.Inner.Identity.PrincipalId;
                }
                else
                {
                    return null;
                }
            }
        }

        public string ResourceId
        {
            get
            {
                if (this.vm.Inner != null)
                {
                    return this.vm.Inner.Id;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}