// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine.
    /// </summary>
    public partial class VirtualMachineMsiHelper : RoleAssignmentHelper
    {
        private readonly int DEFAULT_TOKEN_PORT = 50342;
        private readonly string MSI_EXTENSION_PUBLISHER_NAME = "Microsoft.ManagedIdentity";

        private readonly IGraphRbacManager rbacManager;
        private int? tokenPort;
        private bool installExtensionIfNotInstalled;

        /// <summary>
        /// Creates VirtualMachineMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        /// <param name="idProvider">Provider that exposes MSI service principal id and resource id.</param>
        internal VirtualMachineMsiHelper(IGraphRbacManager rbacManager, IIdProvider idProvider) : base(rbacManager, idProvider)
        {
            this.rbacManager = rbacManager;
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="virtualMachineInner">The virtual machine to set the identity.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        internal VirtualMachineMsiHelper WithSystemAssignedManagedServiceIdentity(VirtualMachineInner virtualMachineInner)
        {
            return WithSystemAssignedManagedServiceIdentity(null, virtualMachineInner);
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="port">The port in the virtual machine to get the access token from.</param>
        /// <param name="virtualMachineInner">The virtual machine to set the identity.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        internal VirtualMachineMsiHelper WithSystemAssignedManagedServiceIdentity(int? port, VirtualMachineInner virtualMachineInner)
        {
            this.installExtensionIfNotInstalled = true;
            this.tokenPort = port;
            if (virtualMachineInner.Identity == null)
            {
                virtualMachineInner.Identity = new VirtualMachineIdentity();
            }
            if (virtualMachineInner.Identity.Type == null)
            {
                virtualMachineInner.Identity.Type = ResourceIdentityType.SystemAssigned;
            }
            return this;
        }

        /// <summary>
        /// Install or update the MSI extension in the virtual machine and creates a RBAC role assignment for the System Assigned Service Principal.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine for which the MSI needs to be enabled.</param>
        /// <return>True if the extension is installed</return>
        internal async Task<Boolean> SetMSIExtensionIfRequiredAndHandleSystemAssignedMSIRoleAssignmentsAsync(IVirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (virtualMachine.Inner == null)
            {
                throw new ArgumentException("Method requires fluent model to be fully populated");
            }

            try
            {
                bool isExtensionInstalledOrUpdated = false;
                // Install or Update the MSI extension
                //
                if (this.installExtensionIfNotInstalled)
                {
                    OperatingSystemTypes osType = virtualMachine.OSType;
                    string extensionTypeName = osType == OperatingSystemTypes.Linux ? "ManagedIdentityExtensionForLinux" : "ManagedIdentityExtensionForWindows";
                    var extension = await GetMSIExtensionAsync(virtualMachine, extensionTypeName);
                    if (extension != null)
                    {
                        isExtensionInstalledOrUpdated = await UpdateMSIExtensionAsync(virtualMachine, extension, extensionTypeName, cancellationToken);
                    }
                    else
                    {
                        isExtensionInstalledOrUpdated = await InstallMSIExtensionAsync(virtualMachine, extensionTypeName);
                    }
                }

                // Create, Delete System Assigned MSI Role assignments
                //
                if (IsSystemAssignedMSIEnabled(virtualMachine))
                {
                    await CommitsRoleAssignmentsPendingActionAsync(cancellationToken);
                }

                return isExtensionInstalledOrUpdated;
            }
            finally
            {
                this.installExtensionIfNotInstalled = false;
                this.tokenPort = null;
            }
        }

        /// <summary>
        /// Checks system assigned identity is enabled for the virtual machine.
        /// </summary>
        /// <param name="virtualMachine">the virtual machine</param>
        /// <returns>true if system assigned MSI is enabled, false otherwise</returns>
        private static bool IsSystemAssignedMSIEnabled(IVirtualMachine virtualMachine)
        {
            VirtualMachineInner VMInner = virtualMachine.Inner;
            if (VMInner.Identity == null)
            {
                return false;
            }
            else if (VMInner.Identity.Type == null || VMInner.Identity.Type.Equals(ResourceIdentityType.None))
            {
                return false;
            }
            else
            {
                return VMInner.Identity.Type.Equals(ResourceIdentityType.SystemAssigned) || VMInner.Identity.Type.Equals(ResourceIdentityType.SystemAssignedUserAssigned);
            }
        }

        /// <summary>
        /// Checks the virtual machine already has the Managed Service Identity extension installed if so return it.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>An observable that emits MSI extension if exists.</return>
        private async Task<IVirtualMachineExtension> GetMSIExtensionAsync(IVirtualMachine virtualMachine, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var installedExtensions = await virtualMachine.ListExtensionsAsync(cancellationToken);
            return installedExtensions.FirstOrDefault(extension => extension.PublisherName.Equals(MSI_EXTENSION_PUBLISHER_NAME, System.StringComparison.OrdinalIgnoreCase)
                    && extension.TypeName.Equals(typeName, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Install Managed Service Identity extension in the virtual machine.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>An observable that emits true indicating MSI extension installed.</return>
        private async Task<bool> InstallMSIExtensionAsync(IVirtualMachine virtualMachine, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            int tokenPortToUse = tokenPort != null ? tokenPort.Value : DEFAULT_TOKEN_PORT;
            var publicSettings = new Dictionary<string, object>
            {
                { "port", tokenPortToUse }
            };
            VirtualMachineExtensionInner extensionParameter = new VirtualMachineExtensionInner()
            {
                Publisher = MSI_EXTENSION_PUBLISHER_NAME,
                VirtualMachineExtensionType = typeName,
                TypeHandlerVersion = "1.0",
                AutoUpgradeMinorVersion = true,
                Location = virtualMachine.RegionName,
                Settings = publicSettings,
                ProtectedSettings = null
            };
            await virtualMachine.Manager.Inner.VirtualMachineExtensions.CreateOrUpdateAsync(virtualMachine.ResourceGroupName, virtualMachine.Name, typeName, extensionParameter, cancellationToken);
            return true;
        }

        /// <summary>
        /// Update the Managed Service Identity extension installed in the virtual machine.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="extension">The Managed Service Identity extension.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>Task that produces true if extension is updated, false otherwise</return>
        private async Task<bool> UpdateMSIExtensionAsync(IVirtualMachine virtualMachine, IVirtualMachineExtension extension, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            int? currentTokenPort = ComputeUtils.ObjectToInteger(extension.PublicSettings["port"]);
            int? tokenPortToUse;
            if (this.tokenPort != null)
            {
                // User specified a port
                tokenPortToUse = this.tokenPort;
            }
            else if (currentTokenPort == null)
            {
                // User didn't specify a port and port is not already set
                tokenPortToUse = this.DEFAULT_TOKEN_PORT;
            }
            else
            {
                // User didn't specify a port and port is already set in the extension
                // No need to do a PUT on extension
                //
                return false;
            }
            var publicSettings = new Dictionary<string, object>
            {
                { "port", tokenPortToUse }
            };
            extension.Inner.Settings = publicSettings;
            await virtualMachine.Manager.Inner.VirtualMachineExtensions.CreateOrUpdateAsync(virtualMachine.ResourceGroupName, virtualMachine.Name, typeName, extension.Inner, cancellationToken);
            return true;
        }
    }
}