// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine scale set.
    /// </summary>
    public partial class VirtualMachineScaleSetMsiHelper  : RoleAssignmentHelper
    {
        private readonly int DEFAULT_TOKEN_PORT = 50342;
        private readonly string MSI_EXTENSION_PUBLISHER_NAME = "Microsoft.ManagedIdentity";
        private int? tokenPort;
        private bool installExtensionIfNotInstalled;

        /// <summary>
        /// Creates VirtualMachineScaleSetMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        /// <param name="idProvider">Provider that exposes MSI service principal id and resource id.</param>
        internal VirtualMachineScaleSetMsiHelper(IGraphRbacManager rbacManager, IIdProvider idProvider) : base(rbacManager, idProvider)
        {
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
        /// <param name="scaleSetInner">The virtual machine scale set to enable System Assigned MSI.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        internal VirtualMachineScaleSetMsiHelper WithSystemAssignedManagedServiceIdentity(int? port, VirtualMachineScaleSetInner scaleSetInner)
        {
            this.installExtensionIfNotInstalled = true;
            this.tokenPort = port;
            if (scaleSetInner.Identity == null) {
                scaleSetInner.Identity = new VirtualMachineScaleSetIdentity();
            }
            if (scaleSetInner.Identity.Type == null) {
                scaleSetInner.Identity.Type = ResourceIdentityType.SystemAssigned;
            }
            return this;
        }

        /// <summary>
        /// Clear internal properties.
        /// </summary>
        private void Clear()
        {
            this.installExtensionIfNotInstalled = false;
            this.tokenPort = null;

        }

        /// <summary>
        /// Add or update the Managed Service Identity extension for the given virtual machine scale set.
        /// </summary>
        /// <param name="scaleSetImpl">The scale set.</param>
        internal void AddOrUpdateMSIExtension(VirtualMachineScaleSetImpl scaleSetImpl)
        {
            if (!this.installExtensionIfNotInstalled) {
                return;
            }

            // To add or update MSI extension, we relay on methods exposed from interfaces instead of from
            // impl so that any breaking change in the contract cause a compile time error here. So do not
            // change the below 'updateExtension' or 'defineNewExtension' to use impls.
            //
            String msiExtensionType = scaleSetImpl.OSTypeIntern() == OperatingSystemTypes.Linux? "ManagedIdentityExtensionForLinux" : "ManagedIdentityExtensionForWindows";
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
    }
}