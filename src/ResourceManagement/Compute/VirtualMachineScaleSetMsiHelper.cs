// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine scale set.
    /// </summary>
    public partial class VirtualMachineScaleSetMsiHelper : RoleAssignmentHelper
    {
        private ISet<string> creatableIdentityKeys;
        private VirtualMachineScaleSetImpl scaleSet;
        private Dictionary<string, Models.VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue> userAssignedIdentities;

        /// <summary>
        /// Creates VirtualMachineScaleSetMsiHandler.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        internal VirtualMachineScaleSetMsiHelper(IGraphRbacManager rbacManager, VirtualMachineScaleSetImpl scaleSet)
            : base(rbacManager, new VmssIdProvider(scaleSet))
        {
            this.scaleSet = scaleSet;
            this.creatableIdentityKeys = new HashSet<string>();
            this.userAssignedIdentities = new Dictionary<string, VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue>();

        }

        /// <summary>
        /// Clear VirtualMachineScaleSetMsiHandler post-run specific internal state.
        /// </summary>
        internal void Clear()
        {
            this.userAssignedIdentities.Clear();
        }

        internal void HandleExternalIdentities()
        {
            if (this.userAssignedIdentities.Any())
            {
                this.scaleSet.Inner.Identity.UserAssignedIdentities = this.userAssignedIdentities;
            }
        }

        internal void HandleExternalIdentities(VirtualMachineScaleSetUpdate vmssUpdate)
        {
            if (this.HandleRemoveAllExternalIdentitiesCase(vmssUpdate))
            {
                return;
            }
            else
            {
                // At this point one of the following condition is met:
                //
                // 1. User don't want touch the 'VMSS.Identity.UserAssignedIdentities' property
                //      [this.userAssignedIdentities.Empty() == true]
                // 2. User want to add some identities to 'VMSS.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.scaleSet.Inner().Identity() != null]
                // 3. User want to remove some (not all) identities in 'VMSS.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.scaleSet.Inner().Identity() != null]
                //      Note: The scenario where this.scaleSet.Inner().Identity() is null in #3 is already handled in
                //      handleRemoveAllExternalIdentitiesCase method
                // 4. User want to add and remove (all or subset) some identities in 'VMSS.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.scaleSet.Inner().Identity() != null]
                //
                var currentIdentity = this.scaleSet.Inner.Identity;
                vmssUpdate.Identity = currentIdentity;
                if (this.userAssignedIdentities.Any())
                {
                    // At this point its guaranteed that 'currentIdentity' is not null so vmUpdate.Identity() is.
                    vmssUpdate.Identity.UserAssignedIdentities = this.userAssignedIdentities;
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

        /// <summary>
        /// Update the VMSS payload model using the created External Managed Service Identities.
        /// </summary>
        internal void ProcessCreatedExternalIdentities()
        {
            foreach (var key in this.creatableIdentityKeys)
            {
                var identity = (IIdentity)this.scaleSet.CreatorTaskGroup.CreatedResource(key);
                this.userAssignedIdentities[identity.Id] = new VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue();
            }
            this.creatableIdentityKeys.Clear();
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the virtual machine scale set.
        /// </summary>
        /// <param name="identity">An identity to associate.</param>
        /// <return>VirtualMachineScaleSetMsiHandler.</return>
        internal VirtualMachineScaleSetMsiHelper WithExistingExternalManagedServiceIdentity(IIdentity identity)
        {
            this.InitVMSSIdentity(ResourceIdentityType.UserAssigned);
            this.userAssignedIdentities[identity.Id] = new VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue();
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be enabled in the virtual machine scale set.
        /// If MSI extension is not already installed then it will be installed with access token port as 50342.
        /// </summary>
        /// <return>VirtualMachineScaleSetMsiHandler.</return>
        internal VirtualMachineScaleSetMsiHelper WithLocalManagedServiceIdentity()
        {
            this.InitVMSSIdentity(ResourceIdentityType.SystemAssigned);
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the virtual machine scale set.
        /// </summary>
        /// <param name="creatableIdentity">
        /// Yet-to-be-created identity to be associated with the virtual machine
        /// scale set.
        /// </param>
        /// <return>VirtualMachineScaleSetMsiHandler.</return>
        internal VirtualMachineScaleSetMsiHelper WithNewExternalManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            this.InitVMSSIdentity(ResourceIdentityType.UserAssigned);
            if (!this.creatableIdentityKeys.Contains(creatableIdentity.Key))
            {
                this.InitVMSSIdentity(Fluent.Models.ResourceIdentityType.UserAssigned);
                this.creatableIdentityKeys.Add(creatableIdentity.Key);
                ((creatableIdentity as IResourceCreator<IHasId>).CreatorTaskGroup).Merge(this.scaleSet.CreatorTaskGroup);
            }
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be removed from the list of External Managed Service Identity
        /// associated with the virtual machine machine scale set.
        /// </summary>
        /// <param name="identityId">Resource id of the identity.</param>
        /// <return>VirtualMachineScaleSetMsiHandler.</return>
        internal VirtualMachineScaleSetMsiHelper WithoutExternalManagedServiceIdentity(string identityId)
        {
            this.userAssignedIdentities[identityId] = null;
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be disabled in the virtual machine scale set.
        /// </summary>
        /// <return>VirtualMachineScaleSetMsiHandler.</return>
        internal VirtualMachineScaleSetMsiHelper WithoutLocalManagedServiceIdentity()
        {
            if (this.scaleSet.Inner.Identity == null || 
                this.scaleSet.Inner.Identity.Type == null || 
                this.scaleSet.Inner.Identity.Type.Equals(ResourceIdentityType.None) || 
                this.scaleSet.Inner.Identity.Type.Equals(ResourceIdentityType.UserAssigned))
            {
                return this;
            }
            else if (this.scaleSet.Inner.Identity.Type.Equals(ResourceIdentityType.SystemAssigned))
            {
                this.scaleSet.Inner.Identity.Type = ResourceIdentityType.None;
            }
            else if (this.scaleSet.Inner.Identity.Type.Equals(ResourceIdentityType.SystemAssignedUserAssigned))
            {
                this.scaleSet.Inner.Identity.Type = ResourceIdentityType.UserAssigned;
            }
            return this;
        }

        /// <summary>
        /// Method that handle the case where user request indicates all it want to do is remove all identities associated
        /// with the virtual machine.
        /// </summary>
        /// <param name="vmssUpdate">The vm update payload model.</param>
        /// <return>True if user indented to remove all the identities.</return>
        private bool HandleRemoveAllExternalIdentitiesCase(VirtualMachineScaleSetUpdate vmssUpdate)
        {
            if (this.userAssignedIdentities.Any())
            {
                int rmCount = 0;
                foreach(var  v in this.userAssignedIdentities.Values)
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
                bool containsRemoveOnly = rmCount > 0 && rmCount == this.userAssignedIdentities.Count;
                // Check if user request contains only request for removal of identities.
                if (containsRemoveOnly)
                {
                    var currentIds = new HashSet<string>();
                    var currentIdentity = this.scaleSet.Inner.Identity;
                    if (currentIdentity != null && currentIdentity.UserAssignedIdentities != null)
                    {
                        foreach (var id in currentIdentity.UserAssignedIdentities.Keys)
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
                    bool removeAllCurrentIds = currentIds.Count == removeIds.Count && !removeIds.Any(id => !currentIds.Contains(id));  // Java part looks like this -> && currentIds.ContainsAll(removeIds);
                    if (removeAllCurrentIds)
                    {
                        // If so adjust  the identity type [Setting type to SYSTEM_ASSIGNED orNONE will remove all the identities]
                        if (currentIdentity == null || currentIdentity.Type == null)
                        {
                            vmssUpdate.Identity = new VirtualMachineScaleSetIdentity { Type = ResourceIdentityType.None };
                        }
                        else if (currentIdentity.Type.Equals(ResourceIdentityType.SystemAssignedUserAssigned))
                        {
                            vmssUpdate.Identity = currentIdentity;
                            vmssUpdate.Identity.Type = ResourceIdentityType.SystemAssigned;
                        }
                        else if (currentIdentity.Type.Equals(ResourceIdentityType.UserAssigned))
                        {
                            vmssUpdate.Identity = currentIdentity;
                            vmssUpdate.Identity.Type = ResourceIdentityType.None;
                        }
                        // and set identities property in the payload model to null so that it won't be sent
                        vmssUpdate.Identity.UserAssignedIdentities = null;
                        return true;
                    }
                    else
                    {
                        // Check user is asking to remove identities though there is no identities currently associated
                        if (currentIds.Count == 0 && removeIds.Count != 0 && currentIdentity == null)
                        {
                            // If so we are in a invalid state but we want to send user input to service and let service
                            // handle it (ignore or error).
                            vmssUpdate.Identity = new VirtualMachineScaleSetIdentity { Type = ResourceIdentityType.None };
                            vmssUpdate.Identity.UserAssignedIdentities = null;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Initialize VMSS's identity property.
        /// </summary>
        /// <param name="identityType">The identity type to set.</param>
        private void InitVMSSIdentity(ResourceIdentityType identityType)
        {
            if (!identityType.Equals(ResourceIdentityType.UserAssigned) && 
                !identityType.Equals(ResourceIdentityType.SystemAssigned))
            {
                throw new ArgumentException("Invalid argument: " + identityType);
            }

            var scaleSetInner = this.scaleSet.Inner;

            if (scaleSetInner.Identity == null)
            {
                scaleSetInner.Identity = new VirtualMachineScaleSetIdentity();
            }
            if (scaleSetInner.Identity.Type == null || 
                scaleSetInner.Identity.Type.Equals(ResourceIdentityType.None) || 
                scaleSetInner.Identity.Type.Equals(identityType))
            {
                scaleSetInner.Identity.Type = identityType;
            }
            else
            {
                scaleSetInner.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
            }
        }

        /// <summary>
        /// Gets the MSI identity type.
        /// </summary>
        /// <param name="inner">the virtual machine scale set inner</param>
        /// <returns>the MSI identity type</returns>
        internal static ResourceIdentityType? ManagedServiceIdentityType(VirtualMachineScaleSetInner inner)
        {
            if (inner.Identity != null)
            {
                //ResourceIdentityTypeEnumExtension.ToSerializedValue(ResourceIdentityType.SystemAssigned);
                return inner.Identity.Type;
            }
            return null;
        }
    }


    internal class VmssIdProvider : IIdProvider
    {
        private readonly VirtualMachineScaleSetImpl vmss;

        internal VmssIdProvider(VirtualMachineScaleSetImpl vmss)
        {
            this.vmss = vmss;
        }

        public string PrincipalId
        {
            get
            {
                if (this.vmss.Inner != null && this.vmss.Inner.Identity != null)
                {
                    return this.vmss.Inner.Identity.PrincipalId;
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
                if (this.vmss.Inner != null)
                {
                    return this.vmss.Inner.Id;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}