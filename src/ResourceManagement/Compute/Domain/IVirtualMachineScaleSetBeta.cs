// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the resource ids of User Assigned Managed Service Identities associated with the virtual machine scale set.
        /// </summary>
        ISet<string> UserAssignedManagedServiceIdentityIds { get; }

        /// <summary>
        /// Gets the type of Managed Service Identity used for the virtual machine scale set.
        /// </summary>
        Models.ResourceIdentityType? ManagedServiceIdentityType { get; }

        /// <summary>
        /// Gets the priority of virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachinePriorityTypes VirtualMachinePriority { get; }

        /// <summary>
        /// Gets the eviction policy of the virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachineEvictionPolicyTypes VirtualMachineEvictionPolicy { get; }

        /// <summary>
        /// Gets true if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        bool IsBootDiagnosticsEnabled { get; }

        /// <summary>
        /// Gets the storage blob endpoint uri if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        string BootDiagnosticsStorageUri { get; }

        /// <summary>
        /// Gets the storage account type of the OS managed disk. A null value will be returned if the
        /// virtual machine scale set is based on un-managed disk.
        /// </summary>
        Models.StorageAccountTypes ManagedOSDiskStorageAccountType { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Check whether Managed Service Identity is enabled for the virtual machine scale set.
        /// </summary>
        bool IsManagedServiceIdentityEnabled { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets the availability zones assigned to virtual machine scale set.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones { get; }
    }
}