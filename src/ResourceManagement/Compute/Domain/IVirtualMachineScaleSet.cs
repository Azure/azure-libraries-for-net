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
    public interface IVirtualMachineScaleSet :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager, Models.VirtualMachineScaleSetInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>,
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta
    {

        /// <summary>
        /// Gets the list of application gateway backend pool associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ApplicationGatewayBackendAddressPoolsIds { get; }

        /// <summary>
        /// Gets the list of application security groups associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ApplicationSecurityGroupIds { get; }


        /// <summary> 
        /// When Overprovision is enabled, extensions are launched only on the
        /// requested number of VMs which are finally kept. This property will hence
        /// ensure that the extensions do not run on the extra overprovisioned VMs.
        /// </summary>
        bool? DoNotRunExtensionsOnOverprovisionedVMs { get; }

        /// <summary>
        /// Get specifies information about the proximity placement group that the virtual machine scale set should be assigned to.
        /// </summary>
        IProximityPlacementGroup ProximityPlacementGroup { get; }

        /// <summary>
        /// Get specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale
        /// Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with
        /// UltraSSD_LRS storage account type.
        /// </summary>
        AdditionalCapabilities AdditionalCapabilities { get; }


        /// <summary>
        /// Gets the number of virtual machine instances in the scale set.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Gets the name prefix of the virtual machines in the scale set.
        /// </summary>
        string ComputerNamePrefix { get; }

        /// <summary>
        /// Gets the extensions attached to the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions { get; }

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine scale set's disks (os, data).
        /// </summary>
        bool IsManagedDiskEnabled { get; }

        /// <summary>
        /// Gets the network profile.
        /// </summary>
        Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get; }

        /// <summary>
        /// Gets the operating system disk caching type.
        /// </summary>
        Models.CachingTypes OSDiskCachingType { get; }

        /// <summary>
        /// Gets the name of the OS disk of virtual machines in the scale set.
        /// </summary>
        string OSDiskName { get; }

        /// <summary>
        /// Gets the operating system of the virtual machines in the scale set.
        /// </summary>
        Models.OperatingSystemTypes OSType { get; }

        /// <summary>
        /// Gets true if over provision is enabled for the virtual machines, false otherwise.
        /// </summary>
        bool OverProvisionEnabled { get; }

        /// <return>
        /// Gets the list of IDs of the public IP addresses associated with the primary Internet-facing load balancer
        /// of the scale set.
        /// </return>
        /// <summary>
        /// Gets IOException the IO exception.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> PrimaryPublicIPAddressIds { get; }

        /// <summary>
        /// Gets the SKU of the virtual machines in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Sku { get; }

        /// <summary>
        /// Gets the storage profile.
        /// </summary>
        Models.VirtualMachineScaleSetStorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets the upgrade mode.
        /// </summary>
        /// [Obsolete("Use UpgradeMode instead.")]
        Models.UpgradeMode UpgradeModel { get; }

        /// <summary>
        /// Gets the upgrade mode.
        /// </summary>
        Models.UpgradeMode UpgradeMode { get; }

        /// <summary>
        /// Gets the URL to storage containers that store the VHDs of the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> VhdContainers { get; }

        /// <summary>
        /// Gets entry point to manage virtual machine instances in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs VirtualMachines { get; }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        void Deallocate();

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="instanceId">The virtual machine scale set vm instance ID.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface GetNetworkInterfaceByInstanceId(string instanceId, string name);

        /// <return>
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternalLoadBalancer();

        /// <return>
        /// The Internet-facing load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer GetPrimaryInternetFacingLoadBalancer();

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
        /// A primary internal load balancer associated with the primary network interfaces of the scale set
        /// virtual machine will be also belong to this network
        /// </p>.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetPrimaryNetwork();

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> ListAvailableSkus();

        /// <return>The network interfaces associated with all virtual machine instances in a scale set.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfaces();

        /// <summary>
        /// Lists the network interface associated with a specific virtual machine instance in the scale set.
        /// </summary>
        /// <param name="virtualMachineInstanceId">The instance ID.</param>
        /// <return>The network interfaces.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfacesByInstanceId(string virtualMachineInstanceId);

        /// <return>
        /// The internal load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends();

        /// <return>
        /// The inbound NAT pools of the internal load balancer associated with the primary network interface
        /// of the virtual machines in the scale set, if any.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools();

        /// <return>
        /// The Internet-facing load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends();

        /// <return>
        /// The Internet-facing load balancer's inbound NAT pool associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools();

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Reimage();

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        void Restart();

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}