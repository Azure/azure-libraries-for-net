// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets the availability zones assigned to virtual machine scale set.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones { get; }

        /// <summary>
        /// Gets the storage blob endpoint uri if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        string BootDiagnosticsStorageUri { get; }

        /// <summary>
        /// Gets true if accelerated networking is enabled for the virtual machine scale set.
        /// </summary>
        bool IsAcceleratedNetworkingEnabled { get; }

        /// <summary>
        /// Gets true if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        bool IsBootDiagnosticsEnabled { get; }

        /// <summary>
        /// Gets true if ip forwarding is enabled for the virtual machine scale set.
        /// </summary>
        bool IsIpForwardingEnabled { get; }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the virtual machine scale set.
        /// </summary>
        bool IsManagedServiceIdentityEnabled { get; }

        /// <summary>
        /// Gets true if single placement group is enabled for the virtual machine scale set.
        /// </summary>
        bool IsSinglePlacementGroupEnabled { get; }

        /// <summary>
        /// Gets the storage account type of the OS managed disk. A null value will be returned if the
        /// virtual machine scale set is based on un-managed disk.
        /// </summary>
        Models.StorageAccountTypes ManagedOSDiskStorageAccountType { get; }

        /// <summary>
        /// Gets the type of Managed Service Identity used for the virtual machine scale set.
        /// </summary>
        Models.ResourceIdentityType? ManagedServiceIdentityType { get; }

        /// <summary>
        /// Gets the network security group ARM id.
        /// </summary>
        string NetworkSecurityGroupId { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets the resource ids of User Assigned Managed Service Identities associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.ISet<string> UserAssignedManagedServiceIdentityIds { get; }

        /// <summary>
        /// Gets the eviction policy of the virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachineEvictionPolicyTypes VirtualMachineEvictionPolicy { get; }

        /// <summary>
        /// Gets the priority of virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachinePriorityTypes VirtualMachinePriority { get; }

        /// <summary>
        /// Gets the billing related details of the low priority virtual machines in the scale set.
        /// </summary>
        BillingProfile BillingProfile { get; }

        /// <summary>
        /// Gets the public ip configuration of virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachineScaleSetPublicIPAddressConfiguration VirtualMachinePublicIpConfig { get; }

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Result of execution.</return>
        Models.RunCommandResultInner RunCommandInVMInstance(string vmId, RunCommandInput inputCommand);

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunCommandVMInstanceAsync(string vmId, RunCommandInput inputCommand, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run PowerShell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of PowerShell script execution.</return>
        Models.RunCommandResultInner RunPowerShellScriptInVMInstance(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run PowerShell in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunPowerShellScriptInVMInstanceAsync(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of shell script execution.</return>
        Models.RunCommandResultInner RunShellScriptInVMInstance(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunShellScriptInVMInstanceAsync(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}