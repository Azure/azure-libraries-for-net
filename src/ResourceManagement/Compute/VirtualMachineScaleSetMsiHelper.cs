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

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine scale set.
    /// </summary>
    public partial class VirtualMachineScaleSetMsiHelper : RoleAssignmentHelper
    {
        private readonly int DEFAULT_TOKEN_PORT = 50342;
        private readonly string MSI_EXTENSION_PUBLISHER_NAME = "Microsoft.ManagedIdentity";
        private int? tokenPort;
        private bool installExtensionIfNotInstalled;
        private ISet<string> userAssignedIdentityCreatableKeys;
        private ISet<string> userAssignedIdentityIdsToAssociate;
        private ISet<string> userAssignedIdentityIdsToRemove;

        /// <summary>
        /// Creates VirtualMachineScaleSetMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        /// <param name="idProvider">Provider that exposes MSI service principal id and resource id.</param>
        internal VirtualMachineScaleSetMsiHelper(IGraphRbacManager rbacManager, IIdProvider idProvider) : base(rbacManager, idProvider)
        {
            this.userAssignedIdentityCreatableKeys = new HashSet<string>();
            this.userAssignedIdentityIdsToAssociate = new HashSet<string>();
            this.userAssignedIdentityIdsToRemove = new HashSet<string>();
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
                return ResourceIdentityTypeEnumExtension.ParseResourceIdentityType(inner.Identity.Type);
            }
            return null;
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="scaleSetInner">The virtual machine scale set to enable System Assigned MSI.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        internal VirtualMachineScaleSetMsiHelper WithSystemAssignedManagedServiceIdentity(VirtualMachineScaleSetInner scaleSetInner)
        {
            return WithSystemAssignedManagedServiceIdentity(null, scaleSetInner);
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="port">The port in the virtual machine scale set instance to get the access token from.</param>
        /// <param name="vmssInner">The virtual machine scale set to enable System Assigned MSI.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        internal VirtualMachineScaleSetMsiHelper WithSystemAssignedManagedServiceIdentity(int? port, VirtualMachineScaleSetInner vmssInner)
        {
            this.installExtensionIfNotInstalled = true;
            this.tokenPort = port;
            InitVMIdentity(vmssInner, ResourceIdentityType.SystemAssigned);
            return this;
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the VMSS.
        /// </summary>
        /// <param name="vmssInner">The VMSS to set the identity.</param>
        /// <param name="vmTaskGroup">the task group of the virtual machine</param>
        /// <param name="creatableIdentity">the creatable user assigned identity</param>
        /// <returns>VirtualMachineScaleSetMsiHelper.</returns>
        internal VirtualMachineScaleSetMsiHelper WithNewUserAssignedManagedServiceIdentity(VirtualMachineScaleSetInner vmssInner, CreatorTaskGroup<IHasId> vmTaskGroup, ICreatable<IIdentity> creatableIdentity)
        {
            if (!this.userAssignedIdentityCreatableKeys.Contains(creatableIdentity.Key))
            {
                this.installExtensionIfNotInstalled = true;
                InitVMIdentity(vmssInner, ResourceIdentityType.UserAssigned);
                this.userAssignedIdentityCreatableKeys.Add(creatableIdentity.Key);
                ((creatableIdentity as IResourceCreator<IHasId>).CreatorTaskGroup).Merge(vmTaskGroup);
            }
            return this;
        }

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the VMSS.
        /// </summary>
        /// <param name="identity">an existing user assigned identity</param>
        /// <returns>VirtualMachineScaleSetMsiHelper.</returns>
        internal VirtualMachineScaleSetMsiHelper WithExistingUserAssignedManagedServiceIdentity(VirtualMachineScaleSetInner vmssInner, IIdentity identity)
        {
            if (!this.userAssignedIdentityIdsToAssociate.Contains(identity.Id))
            {
                this.installExtensionIfNotInstalled = true;
                InitVMIdentity(vmssInner, ResourceIdentityType.UserAssigned);
                this.userAssignedIdentityIdsToAssociate.Add(identity.Id);
            }
            return this;
        }

        /// <summary>
        /// Specifies that an user assigned identity associated with the VMSS should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        internal VirtualMachineScaleSetMsiHelper WithoutUserAssignedManagedServiceIdentity(string identityId)
        {
            if (!this.userAssignedIdentityIdsToRemove.Contains(identityId))
            {
                this.userAssignedIdentityIdsToRemove.Add(identityId);
            }
            return this;
        }

        /// <summary>
        /// Set user assigned identity ids to the given VMSS inner model
        /// </summary>
        /// <param name="vmssInner">the VMSS inner model</param>
        /// <param name="vmTaskGroup">the VMSS task group</param>
        internal void HandleUserAssignedIdentities(VirtualMachineScaleSetInner vmssInner, CreatorTaskGroup<IHasId> vmTaskGroup)
        {
            try
            {
                if (vmssInner.Identity == null || vmssInner.Identity.Type == null)
                {
                    return;
                }
                ResourceIdentityType? parsedIdentityType = ResourceIdentityTypeEnumExtension.ParseResourceIdentityType(vmssInner.Identity.Type);
                if (parsedIdentityType.Equals(ResourceIdentityType.None)
                    || parsedIdentityType.Equals(ResourceIdentityType.SystemAssigned))
                {
                    return;
                }
                foreach (var key in this.userAssignedIdentityCreatableKeys)
                {
                    var identity = (IIdentity)vmTaskGroup.CreatedResource(key);
                    if (!this.userAssignedIdentityIdsToAssociate.Contains(identity.Id))
                    {
                        this.userAssignedIdentityIdsToAssociate.Add(identity.Id);
                    }
                }
                if (vmssInner.Identity.IdentityIds == null)
                {
                    vmssInner.Identity.IdentityIds = new List<string>();
                }
                foreach (var identityId in this.userAssignedIdentityIdsToAssociate)
                {
                    if (!vmssInner.Identity.IdentityIds.Contains(identityId))
                    {
                        vmssInner.Identity.IdentityIds.Add(identityId);
                    }
                }
                foreach (var identityId in this.userAssignedIdentityIdsToRemove)
                {
                    if (vmssInner.Identity.IdentityIds.Contains(identityId))
                    {
                        vmssInner.Identity.IdentityIds.Remove(identityId);
                    }
                }
            }
            finally
            {
                this.userAssignedIdentityCreatableKeys.Clear();
                this.userAssignedIdentityIdsToAssociate.Clear();
                this.userAssignedIdentityIdsToRemove.Clear();
            }

        }

        /// <summary>
        /// Add or update the Managed Service Identity extension for the given virtual machine scale set.
        /// </summary>
        /// <param name="scaleSetImpl">The scale set.</param>
        internal void AddOrUpdateMSIExtension(VirtualMachineScaleSetImpl scaleSetImpl)
        {
            if (!this.installExtensionIfNotInstalled)
            {
                return;
            }

            // To add or update MSI extension, we relay on methods exposed from interfaces instead of from
            // impl so that any breaking change in the contract cause a compile time error here. So do not
            // change the below 'updateExtension' or 'defineNewExtension' to use impls.
            //
            String msiExtensionType = scaleSetImpl.OSTypeIntern() == OperatingSystemTypes.Linux ? "ManagedIdentityExtensionForLinux" : "ManagedIdentityExtensionForWindows";
            IVirtualMachineScaleSetExtension msiExtension = GetMSIExtension(scaleSetImpl.Extensions(), msiExtensionType);
            if (msiExtension != null)
            {
                Object currentTokenPortObj = msiExtension.PublicSettings["port"];
                int? currentTokenPort = ComputeUtils.ObjectToInteger(currentTokenPortObj);
                int? newPort;
                if (this.tokenPort != null)
                {
                    // user specified a port
                    newPort = this.tokenPort;
                }
                else if (currentTokenPort != null)
                {
                    // user didn't specify a port and currently there is a port
                    newPort = currentTokenPort;
                }
                else
                {
                    // user didn't specify a port and currently there is no port
                    newPort = DEFAULT_TOKEN_PORT;
                }
                VirtualMachineScaleSet.Update.IUpdate appliableVMSS = scaleSetImpl;
                appliableVMSS.UpdateExtension(msiExtension.Name)
                    .WithPublicSetting("port", newPort)
                    .Parent();
            }
            else
            {
                int? port;
                if (this.tokenPort != null)
                {
                    port = this.tokenPort;
                }
                else
                {
                    port = DEFAULT_TOKEN_PORT;
                }
                if (scaleSetImpl.Inner.Id == null) // InCreateMode
                {
                    VirtualMachineScaleSet.Definition.IWithCreate creatableVMSS = scaleSetImpl;
                    creatableVMSS.DefineNewExtension(msiExtensionType)
                        .WithPublisher(MSI_EXTENSION_PUBLISHER_NAME)
                        .WithType(msiExtensionType)
                        .WithVersion("1.0")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("port", port)
                        .Attach();
                }
                else
                {
                    VirtualMachineScaleSet.Update.IUpdate appliableVMSS = scaleSetImpl;
                    appliableVMSS.DefineNewExtension(msiExtensionType)
                        .WithPublisher(MSI_EXTENSION_PUBLISHER_NAME)
                        .WithType(msiExtensionType)
                        .WithVersion("1.0")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("port", port)
                        .Attach();
                }
            }

            this.installExtensionIfNotInstalled = false;
            this.tokenPort = null;
        }

        /// <summary>
        /// Gets the Managed Service Identity extension from the given extensions.
        /// </summary>
        /// <param name="extensions">The extensions.</param>
        /// <param name="typeName">The extension type.</param>
        /// <return>The MSI extension if exists, null otherwise.</return>
        private IVirtualMachineScaleSetExtension GetMSIExtension(IReadOnlyDictionary<string, IVirtualMachineScaleSetExtension> extensions, string typeName)
        {
            return extensions.Values.FirstOrDefault(extension =>
                extension.PublisherName.Equals(MSI_EXTENSION_PUBLISHER_NAME, System.StringComparison.OrdinalIgnoreCase) && extension.TypeName.Equals(typeName, System.StringComparison.OrdinalIgnoreCase));
        }

        private static void InitVMIdentity(VirtualMachineScaleSetInner vmssInner, ResourceIdentityType identityType)
        {
            if (!identityType.Equals(ResourceIdentityType.UserAssigned)
                    && !identityType.Equals(ResourceIdentityType.SystemAssigned))
            {
                throw new ArgumentException("Invalid argument: " + identityType);
            }
            if (vmssInner.Identity == null)
            {
                vmssInner.Identity = new VirtualMachineScaleSetIdentity();
            }

            ResourceIdentityType? parsedIdentityType = ResourceIdentityTypeEnumExtension.ParseResourceIdentityType(vmssInner.Identity.Type);
            if (parsedIdentityType == null
                    || parsedIdentityType.Equals(ResourceIdentityType.None)
                    || parsedIdentityType.Equals(identityType))
            {
                vmssInner.Identity.Type = ResourceIdentityTypeEnumExtension.ToSerializedValue(identityType);
            }
            else
            {
                vmssInner.Identity.Type = ResourceIdentityTypeEnumExtension.ToSerializedValue(ResourceIdentityType.SystemAssignedUserAssigned);
            }
            if (vmssInner.Identity.IdentityIds == null)
            {
                if (identityType.Equals(ResourceIdentityType.UserAssigned)
                        || identityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned))
                {
                    vmssInner.Identity.IdentityIds = new List<string>();
                }
            }
        }
    }
}