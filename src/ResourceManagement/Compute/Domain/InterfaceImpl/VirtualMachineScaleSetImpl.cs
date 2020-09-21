// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VirtualMachineScaleSetImpl
    {
        /// <summary>
        /// Gets the list of application gateway backend pool associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ApplicationGatewayBackendAddressPoolsIds
        {
            get
            {
                return this.ApplicationGatewayBackendAddressPoolsIds();
            }
        }

        /// <summary>
        /// Gets the list of application security groups associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ApplicationSecurityGroupIds
        {
            get
            {
                return this.ApplicationSecurityGroupIds();
            }
        }

        /// <summary> 
        /// When Overprovision is enabled, extensions are launched only on the
        /// requested number of VMs which are finally kept. This property will hence
        /// ensure that the extensions do not run on the extra overprovisioned VMs.
        /// </summary>
        bool? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.DoNotRunExtensionsOnOverprovisionedVMs
        {
            get
            {
                return this.DoNotRunExtensionsOnOverprovisionedVMs();
            }
        }

        /// <summary>
        /// Get specifies information about the proximity placement group that the virtual machine scale set should be assigned to.
        /// </summary>
        IProximityPlacementGroup Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ProximityPlacementGroup
        {
            get
            {
                return this.ProximityPlacementGroup();
            }
        }


        /// <summary>
        /// Get specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale
        /// Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with
        /// UltraSSD_LRS storage account type.
        /// </summary>
        AdditionalCapabilities Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.AdditionalCapabilities
        {
            get
            {
                return this.AdditionalCapabilities();
            }
        }

        /// <summary>
        /// Gets the availability zones assigned to virtual machine scale set.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.AvailabilityZones
        {
            get
            {
                return this.AvailabilityZones();
            }
        }

        /// <summary>
        /// Gets the billing profile.
        /// </summary>
        BillingProfile IVirtualMachineScaleSetBeta.BillingProfile
        {
            get
            {
                return this.BillingProfile();
            }
        }

        /// <summary>
        /// Gets the storage blob endpoint uri if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.BootDiagnosticsStorageUri
        {
            get
            {
                return this.BootDiagnosticsStorageUri();
            }
        }

        /// <summary>
        /// Gets the number of virtual machine instances in the scale set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Capacity
        {
            get
            {
                return this.Capacity();
            }
        }

        /// <summary>
        /// Gets the name prefix of the virtual machines in the scale set.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ComputerNamePrefix
        {
            get
            {
                return this.ComputerNamePrefix();
            }
        }

        /// <summary>
        /// Gets the extensions attached to the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Extensions
        {
            get
            {
                return this.Extensions();
            }
        }

        /// <summary>
        /// Gets true if accelerated networking is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsAcceleratedNetworkingEnabled
        {
            get
            {
                return this.IsAcceleratedNetworkingEnabled();
            }
        }

        /// <summary>
        /// Gets true if boot diagnostics is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsBootDiagnosticsEnabled
        {
            get
            {
                return this.IsBootDiagnosticsEnabled();
            }
        }

        /// <summary>
        /// Gets true if ip forwarding is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsIpForwardingEnabled
        {
            get
            {
                return this.IsIpForwardingEnabled();
            }
        }

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine scale set's disks (os, data).
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.IsManagedDiskEnabled
        {
            get
            {
                return this.IsManagedDiskEnabled();
            }
        }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsManagedServiceIdentityEnabled
        {
            get
            {
                return this.IsManagedServiceIdentityEnabled();
            }
        }

        /// <summary>
        /// Gets true if single placement group is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsSinglePlacementGroupEnabled
        {
            get
            {
                return this.IsSinglePlacementGroupEnabled();
            }
        }

        /// <summary>
        /// Gets the storage account type of the OS managed disk. A null value will be returned if the
        /// virtual machine scale set is based on un-managed disk.
        /// </summary>
        Models.StorageAccountTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.ManagedOSDiskStorageAccountType
        {
            get
            {
                return this.ManagedOSDiskStorageAccountType();
            }
        }

        /// <summary>
        /// Gets the type of Managed Service Identity used for the virtual machine scale set.
        /// </summary>
        Models.ResourceIdentityType? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.ManagedServiceIdentityType
        {
            get
            {
                return this.ManagedServiceIdentityType();
            }
        }

        /// <summary>
        /// Gets the network profile.
        /// </summary>
        Models.VirtualMachineScaleSetNetworkProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.NetworkProfile
        {
            get
            {
                return this.NetworkProfile();
            }
        }

        /// <summary>
        /// Gets the network security group ARM id.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        /// <summary>
        /// Gets the operating system disk caching type.
        /// </summary>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OSDiskCachingType
        {
            get
            {
                return this.OSDiskCachingType();
            }
        }

        /// <summary>
        /// Gets the name of the OS disk of virtual machines in the scale set.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OSDiskName
        {
            get
            {
                return this.OSDiskName();
            }
        }

        /// <summary>
        /// Gets the operating system of the virtual machines in the scale set.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets true if over provision is enabled for the virtual machines, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.OverProvisionEnabled
        {
            get
            {
                return this.OverProvisionEnabled();
            }
        }

        /// <return>
        /// Gets the list of IDs of the public IP addresses associated with the primary Internet-facing load balancer
        /// of the scale set.
        /// </return>
        /// <summary>
        /// Gets IOException the IO exception.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PrimaryPublicIPAddressIds
        {
            get
            {
                return this.PrimaryPublicIPAddressIds();
            }
        }

        /// <summary>
        /// Gets the SKU of the virtual machines in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetSkuTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the storage profile.
        /// </summary>
        Models.VirtualMachineScaleSetStorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.StorageProfile
        {
            get
            {
                return this.StorageProfile();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.SystemAssignedManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityPrincipalId();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID
        /// assigned to the virtual machine scale set.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.SystemAssignedManagedServiceIdentityTenantId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// Gets the upgrade model.
        /// </summary>
        Models.UpgradeMode Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.UpgradeModel
        {
            get
            {
                return this.UpgradeMode();
            }
        }
        
        Models.UpgradeMode Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.UpgradeMode
        {
            get
            {
                return this.UpgradeMode();
            }
        }

        /// <summary>
        /// Gets the resource ids of User Assigned Managed Service Identities associated with the virtual machine scale set.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.UserAssignedManagedServiceIdentityIds
        {
            get
            {
                return this.UserAssignedManagedServiceIdentityIds();
            }
        }

        /// <summary>
        /// Gets the URL to storage containers that store the VHDs of the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.VhdContainers
        {
            get
            {
                return this.VhdContainers();
            }
        }

        /// <summary>
        /// Gets the eviction policy of the virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachineEvictionPolicyTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.VirtualMachineEvictionPolicy
        {
            get
            {
                return this.VirtualMachineEvictionPolicy();
            }
        }

        /// <summary>
        /// Gets the priority of virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachinePriorityTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.VirtualMachinePriority
        {
            get
            {
                return this.VirtualMachinePriority();
            }
        }

        /// <summary>
        /// Gets the public ip configuration of virtual machines in the scale set.
        /// </summary>
        Models.VirtualMachineScaleSetPublicIPAddressConfiguration Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.VirtualMachinePublicIpConfig
        {
            get
            {
                return this.VirtualMachinePublicIpConfig();
            }
        }

        /// <summary>
        /// Gets entry point to manage virtual machine instances in the scale set.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMs Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.VirtualMachines
        {
            get
            {
                return this.VirtualMachines();
            }
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Deallocate()
        {

            this.Deallocate();
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.DeallocateAsync(CancellationToken cancellationToken)
        {

            await this.DeallocateAsync(cancellationToken);
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        VirtualMachineScaleSetExtension.Definition.IBlank<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSet.Definition.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name);
        }

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for an extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSet.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name);
        }

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="instanceId">The virtual machine scale set vm instance ID.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetNetworkInterfaceByInstanceId(string instanceId, string name)
        {
            return this.GetNetworkInterfaceByInstanceId(instanceId, name);
        }

        /// <return>
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryInternalLoadBalancer()
        {
            return this.GetPrimaryInternalLoadBalancer();
        }

        /// <return>
        /// The Internet-facing load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer()
        {
            return this.GetPrimaryInternetFacingLoadBalancer();
        }

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
        /// A primary internal load balancer associated with the primary network interfaces of the scale set
        /// virtual machine will be also belong to this network
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryNetwork()
        {
            return this.GetPrimaryNetwork();
        }

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListAvailableSkus()
        {
            return this.ListAvailableSkus();
        }

        /// <return>The network interfaces associated with all virtual machine instances in a scale set.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListNetworkInterfaces()
        {
            return this.ListNetworkInterfaces();
        }

        /// <summary>
        /// Lists the network interface associated with a specific virtual machine instance in the scale set.
        /// </summary>
        /// <param name="virtualMachineInstanceId">The instance ID.</param>
        /// <return>The network interfaces.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListNetworkInterfacesByInstanceId(string virtualMachineInstanceId)
        {
            return this.ListNetworkInterfacesByInstanceId(virtualMachineInstanceId);
        }

        /// <return>
        /// The internal load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends()
        {
            return this.ListPrimaryInternalLoadBalancerBackends();
        }

        /// <return>
        /// The inbound NAT pools of the internal load balancer associated with the primary network interface
        /// of the virtual machines in the scale set, if any.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternalLoadBalancerInboundNatPools();
        }

        /// <return>
        /// The Internet-facing load balancer's backends associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends()
        {
            return this.ListPrimaryInternetFacingLoadBalancerBackends();
        }

        /// <return>
        /// The Internet-facing load balancer's inbound NAT pool associated with the primary network interface
        /// of the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            return this.ListPrimaryInternetFacingLoadBalancerInboundNatPools();
        }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PowerOff()
        {

            this.PowerOff();
        }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PowerOffAsync(CancellationToken cancellationToken)
        {

            await this.PowerOffAsync(cancellationToken);
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Reimage()
        {

            this.Reimage();
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ReimageAsync(CancellationToken cancellationToken)
        {

            await this.ReimageAsync(cancellationToken);
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Restart()
        {

            this.Restart();
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.RestartAsync(CancellationToken cancellationToken)
        {

            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Result of execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunCommandInVMInstance(string vmId, RunCommandInput inputCommand)
        {
            return this.RunCommandInVMInstance(vmId, inputCommand);
        }

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunCommandVMInstanceAsync(string vmId, RunCommandInput inputCommand, CancellationToken cancellationToken)
        {
            return await this.RunCommandVMInstanceAsync(vmId, inputCommand, cancellationToken);
        }

        /// <summary>
        /// Run PowerShell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of PowerShell script execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunPowerShellScriptInVMInstance(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters)
        {
            return this.RunPowerShellScriptInVMInstance(vmId, scriptLines, scriptParameters);
        }

        /// <summary>
        /// Run PowerShell in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunPowerShellScriptInVMInstanceAsync(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken)
        {
            return await this.RunPowerShellScriptInVMInstanceAsync(vmId, scriptLines, scriptParameters, cancellationToken);
        }

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of shell script execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunShellScriptInVMInstance(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters)
        {
            return this.RunShellScriptInVMInstance(vmId, scriptLines, scriptParameters);
        }

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.RunShellScriptInVMInstanceAsync(string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken)
        {
            return await this.RunShellScriptInVMInstanceAsync(vmId, scriptLines, scriptParameters, cancellationToken);
        }

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Start()
        {

            this.Start();
        }

        /// <summary>
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.StartAsync(CancellationToken cancellationToken)
        {

            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSet.Update.IWithExtension.UpdateExtension(string name)
        {
            return this.UpdateExtension(name);
        }

        /// <summary>
        /// Specify that accelerated networking should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithAcceleratedNetworking.WithAcceleratedNetworking()
        {
            return this.WithAcceleratedNetworking();
        }

        /// <summary>
        /// Specify that accelerated networking should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithAcceleratedNetworking.WithAcceleratedNetworking()
        {
            return this.WithAcceleratedNetworking();
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword);
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword);
        }

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword);
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
        }

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
        }

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithAutoUpdate()
        {
            return this.WithAutoUpdate();
        }

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithAutoUpdate()
        {
            return this.WithAutoUpdate();
        }

        /// <summary>
        /// Specifies the availability zone for the virtual machine scale set.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithAvailabilityZone.WithAvailabilityZone(AvailabilityZoneId zoneId)
        {
            return this.WithAvailabilityZone(zoneId);
        }

        /// <summary>
        /// Specifies the availability zone for the virtual machine scale set.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithAvailabilityZone.WithAvailabilityZone(AvailabilityZoneId zoneId)
        {
            return this.WithAvailabilityZone(zoneId);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithBootDiagnostics.WithBootDiagnostics()
        {
            return this.WithBootDiagnostics();
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithBootDiagnostics.WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithBootDiagnostics(creatable);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithBootDiagnostics.WithBootDiagnostics(IStorageAccount storageAccount)
        {
            return this.WithBootDiagnostics(storageAccount);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithBootDiagnostics.WithBootDiagnostics(string storageAccountBlobEndpointUri)
        {
            return this.WithBootDiagnostics(storageAccountBlobEndpointUri);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithBootDiagnostics()
        {
            return this.WithBootDiagnostics();
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithBootDiagnostics(creatable);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithBootDiagnostics(IStorageAccount storageAccount)
        {
            return this.WithBootDiagnostics(storageAccount);
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithBootDiagnostics(string storageAccountBlobEndpointUri)
        {
            return this.WithBootDiagnostics(storageAccountBlobEndpointUri);
        }

        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">Number of virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity);
        }

        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity of the scale set.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity);
        }

        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">Number of virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVaultSecret.WithVaultSecret(string vaultId, string certificateUrl, string certificateStore)
        {
            return this.WithVaultSecret(vaultId, certificateUrl, certificateStore);
        }

        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity of the scale set.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithVaultSecret.WithVaultSecret(string vaultId, string certificateUrl, string certificateStore)
        {
            return this.WithVaultSecret(vaultId, certificateUrl, certificateStore);
        }

        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">The prefix for the auto-generated names of the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithComputerNamePrefix.WithComputerNamePrefix(string namePrefix)
        {
            return this.WithComputerNamePrefix(namePrefix);
        }

        /// <summary>
        /// Specifies the custom data for the virtual machine scale set.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCustomData.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData);
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDiskOptionals.WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            return this.WithDataDiskDefaultCachingType(cachingType);
        }

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDiskOptionals.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType);
        }

        /// <summary>
        /// Specify that an application gateway backend pool should be associated with virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithApplicationGateway.WithExistingApplicationGatewayBackendPool(string backendPoolId)
        {
            return this.WithExistingApplicationGatewayBackendPool(backendPoolId);
        }

        /// <summary>
        /// Specify that an application gateway backend pool should be associated with virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithApplicationGateway.WithExistingApplicationGatewayBackendPool(string backendPoolId)
        {
            return this.WithExistingApplicationGatewayBackendPool(backendPoolId);
        }

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroup">The application security group.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithApplicationSecurityGroup.WithExistingApplicationSecurityGroup(IApplicationSecurityGroup applicationSecurityGroup)
        {
            return this.WithExistingApplicationSecurityGroup(applicationSecurityGroup);
        }

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroup">The application security group.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithApplicationSecurityGroup.WithExistingApplicationSecurityGroup(IApplicationSecurityGroup applicationSecurityGroup)
        {
            return this.WithExistingApplicationSecurityGroup(applicationSecurityGroup);
        }

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithApplicationSecurityGroup.WithExistingApplicationSecurityGroupId(string applicationSecurityGroupId)
        {
            return this.WithExistingApplicationSecurityGroupId(applicationSecurityGroupId);
        }

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithApplicationSecurityGroup.WithExistingApplicationSecurityGroupId(string applicationSecurityGroupId)
        {
            return this.WithExistingApplicationSecurityGroupId(applicationSecurityGroupId);
        }

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroup">The network security group to associate.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup);
        }

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroup">The network security group to associate.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup);
        }

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroupId">The network security group to associate.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroupId(string networkSecurityGroupId)
        {
            return this.WithExistingNetworkSecurityGroupId(networkSecurityGroupId);
        }

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroupId">The network security group to associate.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroupId(string networkSecurityGroupId)
        {
            return this.WithExistingNetworkSecurityGroupId(networkSecurityGroupId);
        }

        /// <summary>
        /// Specifies the internal load balancer whose backends and/or NAT pools can be assigned to the primary network
        /// interface of the virtual machines in the scale set.
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set, unless subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">An existing internal load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternalLoadBalancer(loadBalancer);
        }

        /// <summary>
        /// Specifies the load balancer to be used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set unless subset of them is selected in the next stages.
        /// </p>.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer.WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternalLoadBalancer(loadBalancer);
        }

        /// <summary>
        /// Specifies the load balancer to be used as the Internet-facing load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current Internet-facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the virtual machines unless a subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer.WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer);
        }

        /// <summary>
        /// Specifies an Internet-facing load balancer whose backends and/or NAT pools can be assigned to the primary
        /// network interfaces of the virtual machines in the scale set.
        /// By default, all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="loadBalancer">An existing Internet-facing load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer);
        }

        /// <summary>
        /// Associate an existing virtual network subnet with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer VirtualMachineScaleSet.Definition.IWithNetworkSubnet.WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingPrimaryNetworkSubnet(network, subnetName);
        }

        /// <summary>
        /// Specifies an existing storage account for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount);
        }

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUserAssignedManagedServiceIdentity.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        /// <summary>
        /// Specify that ip forwarding should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithIpForwarding.WithIpForwarding()
        {
            return this.WithIpForwarding();
        }

        /// <summary>
        /// Specify that ip forwarding should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithIpForwarding.WithIpForwarding()
        {
            return this.WithIpForwarding();
        }

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">The publisher of the image.</param>
        /// <param name="offer">The offer of the image.</param>
        /// <param name="sku">The SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            return this.WithLatestLinuxImage(publisher, offer, sku);
        }

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            return this.WithLatestWindowsImage(publisher, offer, sku);
        }

        /// <summary>
        /// Specifies the ID of a Linux custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged VirtualMachineScaleSet.Definition.IWithOS.WithLinuxCustomImage(string customImageId)
        {
            return this.WithLinuxCustomImage(customImageId);
        }

        /// <summary>
        /// Specifies the resource ID of a Linux gallery image version to be used as the virtual machine scaleset OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of a gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged VirtualMachineScaleSet.Definition.IWithOSBeta.WithLinuxGalleryImageVersion(string galleryImageVersionId)
        {
            return this.WithLinuxGalleryImageVersion(galleryImageVersionId);
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should be low priority VMs.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVMPriority.WithLowPriorityVirtualMachine()
        {
            return this.WithLowPriorityVirtualMachine();
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should be low priority VMs with
        /// provided eviction policy.
        /// </summary>
        /// <param name="policy">Eviction policy for the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVMPriority.WithLowPriorityVirtualMachine(VirtualMachineEvictionPolicyTypes policy)
        {
            return this.WithLowPriorityVirtualMachine(policy);
        }

        /// <summary>
        /// Specifies the billing related details of the low priority virtual machines in the scale set.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithBillingProfile.WithMaxPrice(double? maxPrice)
        {
            return this.WithMaxPrice(maxPrice);
        }

        /// <summary>
        /// Specifies the billing related details of the low priority virtual machines in the scale set.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBillingProfile.WithMaxPrice(double? maxPrice)
        {
            return this.WithMaxPrice(maxPrice);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB)
        {
            return this.WithNewDataDisk(sizeInGB);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType);
        }

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDisk(sizeInGB, lun, cachingType, storageAccountType);
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun)
        {
            return this.WithNewDataDiskFromImage(imageLun);
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType);
        }

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDataDisk.WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            return this.WithNewDataDiskFromImage(imageLun, newSizeInGB, cachingType, storageAccountType);
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(string name)
        {
            return this.WithNewStorageAccount(name);
        }

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">The storage account definition in a creatable stage.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable);
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated
        /// with the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the
        /// virtual machine scale set.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUserAssignedManagedServiceIdentity.WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOSDiskSettings.WithOSDiskCaching(CachingTypes cachingType)
        {
            return this.WithOSDiskCaching(cachingType);
        }

        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">The OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOSDiskSettings.WithOSDiskName(string name)
        {
            return this.WithOSDiskName(name);
        }

        /// <summary>
        /// Specifies the storage account type for managed OS disk.
        /// </summary>
        /// <param name="accountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDiskOptionals.WithOSDiskStorageAccountType(StorageAccountTypes accountType)
        {
            return this.WithOSDiskStorageAccountType(accountType);
        }

        /// <summary>
        /// Specify that accelerated networking should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithAcceleratedNetworking.WithoutAcceleratedNetworking()
        {
            return this.WithoutAcceleratedNetworking();
        }

        /// <summary>
        /// Specify that accelerated networking should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithAcceleratedNetworking.WithoutAcceleratedNetworking()
        {
            return this.WithoutAcceleratedNetworking();
        }

        /// <summary>
        /// Specify an existing application gateway associated should be removed from the virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithApplicationGateway.WithoutApplicationGatewayBackendPool(string backendPoolId)
        {
            return this.WithoutApplicationGatewayBackendPool(backendPoolId);
        }

        /// <summary>
        /// Specifies that provided application security group should be removed from the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithApplicationSecurityGroup.WithoutApplicationSecurityGroup(string applicationSecurityGroupId)
        {
            return this.WithoutApplicationSecurityGroup(applicationSecurityGroupId);
        }

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate();
        }

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate();
        }

        /// <summary>
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithoutBootDiagnostics()
        {
            return this.WithoutBootDiagnostics();
        }

        /// <summary>
        /// Detaches managed data disk with the given LUN from the virtual machine scale set instances.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithManagedDataDisk.WithoutDataDisk(int lun)
        {
            return this.WithoutDataDisk(lun);
        }

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name);
        }

        /// <summary>
        /// Specify that ip forwarding should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithIpForwarding.WithoutIpForwarding()
        {
            return this.WithoutIpForwarding();
        }

        /// <summary>
        /// Specify that ip forwarding should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithIpForwarding.WithoutIpForwarding()
        {
            return this.WithoutIpForwarding();
        }

        /// <summary>
        /// Set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine
        /// Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed
        /// data disks with UltraSSD_LRS storage account type.
        /// </summary>
        /// <param name="additionalCapabilities">the additionalCapabilities value to set</param>
        /// <returns>the next stage of the definition.</returns>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithAdditionalCapabilities.WithAdditionalCapabilities(AdditionalCapabilities additionalCapabilities)
        {
            return this.WithAdditionalCapabilities(additionalCapabilities);
        }


        /// <summary>
        /// Specifies that network security group association should be removed if exists.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithNetworkSecurityGroup.WithoutNetworkSecurityGroup()
        {
            return this.WithoutNetworkSecurityGroup();
        }

        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithoutOverProvisioning()
        {
            return this.WithoutOverProvisioning();
        }

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithOS VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer();
        }

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer();
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerNatPools(natPoolNames);
        }

        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer();
        }

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer();
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend.WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of an Internet-facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternetFacingLoadBalancerNatPools(natPoolNames);
        }

        /// <summary>
        /// Specify that single placement group should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithSinglePlacementGroup.WithoutSinglePlacementGroup()
        {
            return this.WithoutSinglePlacementGroup();
        }

        /// <summary>
        /// Specify that single placement group should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSinglePlacementGroup.WithoutSinglePlacementGroup()
        {
            return this.WithoutSinglePlacementGroup();
        }

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be disabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedManagedServiceIdentity.WithoutSystemAssignedManagedServiceIdentity()
        {
            return this.WithoutSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that an user assigned identity associated with the virtual machine should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithoutUserAssignedManagedServiceIdentity(string identityId)
        {
            return this.WithoutUserAssignedManagedServiceIdentity(identityId);
        }

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent();
        }

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent();
        }

        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">
        /// True if enabling over-0provisioning of virtual machines in the
        /// scale set, otherwise false.
        /// </param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvision(bool enabled)
        {
            return this.WithOverProvision(enabled);
        }

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithOverProvisioning()
        {
            return this.WithOverProvisioning();
        }

        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage);
        }

        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return this.WithPopularWindowsImage(knownImage);
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">Names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool.WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternalLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Associate internal load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machine.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pool names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithOS VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames);
        }

        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools in the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool.WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternalLoadBalancerInboundNatPools(natPoolNames);
        }

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The backend names.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool.WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerBackends(backendNames);
        }

        /// <summary>
        /// Associates the specified inbound NAT pools of the selected internal load balancer with the primary network
        /// interface of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pools names existing on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames);
        }

        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool.WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            return this.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPoolNames);
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
        }

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
        }

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
        }

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
        }

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming conventions for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
        }

        /// <summary>
        /// Specify that single placement group should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithSinglePlacementGroup.WithSinglePlacementGroup()
        {
            return this.WithSinglePlacementGroup();
        }

        /// <summary>
        /// Specify that single placement group should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSinglePlacementGroup.WithSinglePlacementGroup()
        {
            return this.WithSinglePlacementGroup();
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType);
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup VirtualMachineScaleSet.Definition.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType);
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup VirtualMachineScaleSet.Definition.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Set information about the proximity placement group that the virtual machine scale set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition.</returns>
        VirtualMachineScaleSet.Definition.IWithDoNotRunExtensionsOnOverprovisionedVms VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup.WithProximityPlacementGroup(string promixityPlacementGroupId)
        {
            return this.WithProximityPlacementGroup(promixityPlacementGroupId);
        }

        /// <summary>
        /// Creates a new proximity placement group with the specified name and then adds it to the VM scale set.
        /// </summary>
        /// <param name="proximityPlacementGroupName">the name of the group to be created.</param>
        /// <param name="type">the type of the group</param>
        /// <returns>the next stage of the definition.</returns>
        VirtualMachineScaleSet.Definition.IWithDoNotRunExtensionsOnOverprovisionedVms VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup.WithNewProximityPlacementGroup(string proximityPlacementGroupName, ProximityPlacementGroupType type)
        {
            return this.WithNewProximityPlacementGroup(proximityPlacementGroupName, type);
        }

        /// <summary>
        /// Set when Overprovision is enabled, extensions are launched only on the requested number of VMs which are
        /// finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMS.
        /// </summary>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">the doNotRunExtensionsOnOverprovisionedVMs value to set</param>
        /// <returns>the next stage of the definition.</returns>
        VirtualMachineScaleSet.Definition.IWithAdditionalCapabilities VirtualMachineScaleSet.Definition.IWithDoNotRunExtensionsOnOverprovisionedVms.WithDoNotRunExtensionsOnOverprovisionedVMs(bool doNotRunExtensionsOnOverprovisionedVMs)
        {
            return this.WithDoNotRunExtensionsOnOverprovisionedVMs(doNotRunExtensionsOnOverprovisionedVMs);
        }

        /// <summary> 
        /// Set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine
        /// Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed
        /// data disks with UltraSSD_LRS storage account type.
        /// </summary>
        /// <param name="additionalCapabilities">the additionalCapabilities value to set</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachineScaleSet.Definition.IWithNetworkSubnet VirtualMachineScaleSet.Definition.IWithAdditionalCapabilities.WithAdditionalCapabilities(AdditionalCapabilities additionalCapabilities)
        {
            return this.WithAdditionalCapabilities(additionalCapabilities);
        }

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificLinuxImageVersion(imageReference);
        }

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the marketplace image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            return this.WithSpecificWindowsImageVersion(imageReference);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged.WithSsh(string publicKey)
        {
            return this.WithSsh(publicKey);
        }

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">The URL the the VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl);
        }

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">The URL of the VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithStoredWindowsImage(string imageUrl)
        {
            return this.WithStoredWindowsImage(imageUrl);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID. Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.  Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID.
        /// Applications running on the scale set VM instance will have the same permission (role)
        /// on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that virtual machine scale set 's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.  Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's local identity should have the given access
        /// (described by the role) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the given
        /// access (described by the role) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be enabled in the virtual
        /// machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone);
        }

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone);
        }

        /// <return>The next stage of a unmanaged disk based virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithUnmanagedCreate VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks();
        }

        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks();
        }

        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">An upgrade policy mode.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUpgradePolicy.WithUpgradeMode(UpgradeMode upgradeMode)
        {
            return this.WithUpgradeMode(upgradeMode);
        }

        /// <summary>
        /// Specifies the priority of the virtual machines in the scale set.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVMPriority.WithVirtualMachinePriority(VirtualMachinePriorityTypes priority)
        {
            return this.WithVirtualMachinePriority(priority);
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp()
        {
            return this.WithVirtualMachinePublicIp();
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="leafDomainLabel">The domain name label.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp(string leafDomainLabel)
        {
            return this.WithVirtualMachinePublicIp(leafDomainLabel);
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="ipConfig">The public ip address configuration.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp(VirtualMachineScaleSetPublicIPAddressConfiguration ipConfig)
        {
            return this.WithVirtualMachinePublicIp(ipConfig);
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp()
        {
            return this.WithVirtualMachinePublicIp();
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="leafDomainLabel">The domain name label.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp(string leafDomainLabel)
        {
            return this.WithVirtualMachinePublicIp(leafDomainLabel);
        }

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="ipConfig">The public ip address configuration.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithVirtualMachinePublicIp.WithVirtualMachinePublicIp(VirtualMachineScaleSetPublicIPAddressConfiguration ipConfig)
        {
            return this.WithVirtualMachinePublicIp(ipConfig);
        }

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithVMAgent()
        {
            return this.WithVMAgent();
        }

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithVMAgent()
        {
            return this.WithVMAgent();
        }

        /// <summary>
        /// Specifies the ID of a Windows custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged VirtualMachineScaleSet.Definition.IWithOS.WithWindowsCustomImage(string customImageId)
        {
            return this.WithWindowsCustomImage(customImageId);
        }

        /// <summary>
        /// Specifies the resource ID of a Windows gallery image version to be used as the virtual machine scaleset OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of the gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged VirtualMachineScaleSet.Definition.IWithOSBeta.WithWindowsGalleryImageVersion(string galleryImageVersionId)
        {
            return this.WithWindowsGalleryImageVersion(galleryImageVersionId);
        }

        /// <summary>
        /// Specifies the WinRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener);
        }

        /// <summary>
        /// Specifies the WinRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener);
        }
    }
}