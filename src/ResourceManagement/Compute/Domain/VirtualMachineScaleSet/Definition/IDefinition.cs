// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the VM scale set to be
    /// created and optionally allow unmanaged data disks specific settings to be specified.
    /// </summary>
    public interface IWithUnmanagedCreate :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSku>
    {

    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate a backend pool and/or an inbound NAT pool
    /// of the selected Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool
    {

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate an inbound NAT pool of the selected
    /// Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer
    {

        /// <summary>
        /// Associates the specified inbound NAT pools of the selected internal load balancer with the primary network
        /// interface of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pools names existing on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure network security group.
    /// </summary>
    public interface IWithNetworkSecurityGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroup">The network security group to associate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup);

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroupId">The network security group to associate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingNetworkSecurityGroupId(string networkSecurityGroupId);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension
    {

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> DefineNewExtension(string name);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithInternalLoadBalancerBackendOrNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool
    {

        /// <summary>
        /// Associates the specified backends of the selected load balancer with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">Names of existing backends in the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManagedOrUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of a Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created, but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateManaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate
    {

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithAutoUpdate();

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithoutAutoUpdate();

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithoutVMAgent();

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithTimeZone(string timeZone);

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithVMAgent();

        /// <summary>
        /// Specifies the WinRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithWinRM(WinRMListener listener);
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManaged
    {

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify managed data disks.
    /// </summary>
    public interface IWithManagedDataDisk
    {

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the storage account.
    /// </summary>
    public interface IWithStorageAccount
    {

        /// <summary>
        /// Specifies an existing storage account for the OS and data disk VHDs of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(string name);

        /// <summary>
        /// Specifies a new storage account for the OS and data disk VHDs of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="creatable">The storage account definition in a creatable stage.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify User Assigned (External)
    /// Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the
        /// virtual machine scale set.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordUnmanaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to
    /// set information about the proximity placement group that the virtual machine scale set should
    /// be assigned to.
    /// </summary>
    public interface IWithProximityPlacementGroup : IWithDoNotRunExtensionsOnOverprovisionedVms
    {
        /// <summary>
        /// Set information about the proximity placement group that the virtual machine scale set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition.</returns>
        IWithDoNotRunExtensionsOnOverprovisionedVms WithProximityPlacementGroup(string promixityPlacementGroupId);


        /// <summary>
        /// Creates a new proximity placement group with the specified name and then adds it to the VM scale set.
        /// </summary>
        /// <param name="proximityPlacementGroupName">the name of the group to be created.</param>
        /// <param name="type">the type of the group</param>
        /// <returns>the next stage of the definition.</returns>
        IWithDoNotRunExtensionsOnOverprovisionedVms WithNewProximityPlacementGroup(string proximityPlacementGroupName, ProximityPlacementGroupType type);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to
    /// set when Overprovision is enabled, extensions are launched only on the requested number of VMs
    /// which are finally kept.
    /// </summary>
    public interface IWithDoNotRunExtensionsOnOverprovisionedVms : IWithAdditionalCapabilities
    {
        /// <summary>
        /// Set when Overprovision is enabled, extensions are launched only on the requested number of VMs which are
        /// finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMS.
        /// </summary>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">the doNotRunExtensionsOnOverprovisionedVMs value to set</param>
        /// <returns>the next stage of the definition.</returns>
        IWithAdditionalCapabilities WithDoNotRunExtensionsOnOverprovisionedVMs(bool doNotRunExtensionsOnOverprovisionedVMs);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to 
    /// set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set.
    /// </summary>
    public interface IWithAdditionalCapabilities : IWithNetworkSubnet
    {
        /// <summary> 
        /// Set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine
        /// Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed
        /// data disks with UltraSSD_LRS storage account type.
        /// </summary>
        /// <param name="additionalCapabilities">the additionalCapabilities value to set</param>
        /// <returns>the next stage of the definition</returns>
        IWithNetworkSubnet WithAdditionalCapabilities(AdditionalCapabilities additionalCapabilities);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the virtual network subnet for the
    /// primary network configuration.
    /// </summary>
    public interface IWithNetworkSubnet
    {

        /// <summary>
        /// Associate an existing virtual network subnet with the primary network interface of the virtual machines
        /// in the scale set.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of a Linux virtual machine scale set definition which contains all the minimum required inputs
    /// for the resource to be created, but also allows for any other optional
    /// settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedCreate
    {

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameUnmanaged
    {

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameUnmanaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify SKU for the virtual machines.
    /// </summary>
    public interface IWithSku
    {

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithProximityPlacementGroup WithSku(IVirtualMachineScaleSetSku sku);
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyUnmanaged
    {

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to enable boot diagnostics.
    /// </summary>
    public interface IWithBootDiagnostics :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithBootDiagnostics(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithBootDiagnostics(string storageAccountBlobEndpointUri);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure single placement group.
    /// </summary>
    public interface IWithSinglePlacementGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that single placement group should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithoutSinglePlacementGroup();

        /// <summary>
        /// Specify that single placement group should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithSinglePlacementGroup();
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify availability zone.
    /// </summary>
    public interface IWithAvailabilityZone :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the availability zone for the virtual machine scale set.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithAvailabilityZone(AvailabilityZoneId zoneId);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure application gateway.
    /// </summary>
    public interface IWithApplicationGateway :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that an application gateway backend pool should be associated with virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingApplicationGatewayBackendPool(string backendPoolId);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to enable System Assigned (Local) Managed
    /// Service Identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be enabled in the virtual
        /// machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the VM scale set to be
    /// created and optionally allow managed data disks specific settings to be specified.
    /// </summary>
    public interface IWithManagedCreate :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedDiskOptionals,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithAvailabilityZone,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManaged
    {

        /// <summary>
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming conventions for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure ip forwarding.
    /// </summary>
    public interface IWithIpForwarding :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that ip forwarding should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithIpForwarding();

        /// <summary>
        /// Specify that ip forwarding should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithoutIpForwarding();
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify an internal load balancer for
    /// the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer
    {

        /// <summary>
        /// Specifies the internal load balancer whose backends and/or NAT pools can be assigned to the primary network
        /// interface of the virtual machines in the scale set.
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set, unless subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">An existing internal load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS WithoutPrimaryInternalLoadBalancer();
    }

    /// <summary>
    /// The first stage of a virtual machine scale set definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of a Linux virtual machine scale set definition which contains all the minimum required inputs
    /// for the resource to be created, but also allows for any other optional
    /// settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate
    {

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);

        /// <return>The next stage of a unmanaged disk based virtual machine scale set definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedCreate WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled virtual machine scale set
    /// allowing to set access for the identity.
    /// </summary>
    public interface IWithSystemAssignedIdentityBasedAccessOrCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate
    {

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID. Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.  Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that virtual machine scale set's local identity should have the given access
        /// (described by the role) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOS :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOSBeta
    {

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image should be used.
        /// </summary>
        /// <param name="publisher">The publisher of the image.</param>
        /// <param name="offer">The offer of the image.</param>
        /// <param name="sku">The SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithLatestLinuxImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies that the latest version of the specified marketplace Windows image should be used.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithLatestWindowsImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the ID of a Linux custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged WithLinuxCustomImage(string customImageId);

        /// <summary>
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies a known marketplace Windows image used as the operating system for the virtual machines in the scale set.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies the specific version of a market-place Linux image that should be used.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithSpecificLinuxImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the specific version of a marketplace Windows image needs to be used.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the marketplace image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithSpecificWindowsImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">The URL the the VHD.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameUnmanaged WithStoredLinuxImage(string imageUrl);

        /// <summary>
        /// Specifies the user (custom) Windows image to be used as the operating system for the virtual machines in the
        /// scale set.
        /// </summary>
        /// <param name="imageUrl">The URL of the VHD.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameUnmanaged WithStoredWindowsImage(string imageUrl);

        /// <summary>
        /// Specifies the ID of a Windows custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged WithWindowsCustomImage(string customImageId);
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOSDiskSettings
    {

        /// <summary>
        /// Specifies the caching type for the operating system disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOSDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the name for the OS disk.
        /// </summary>
        /// <param name="name">The OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOSDiskName(string name);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to associate inbound NAT pools of the selected
    /// internal load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithInternalInternalLoadBalancerNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS
    {

        /// <summary>
        /// Associate internal load balancer inbound NAT pools with the the primary network interface of the
        /// scale set virtual machine.
        /// </summary>
        /// <param name="natPoolNames">Inbound NAT pool names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify an Internet-facing load balancer for
    /// the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancer
    {

        /// <summary>
        /// Specifies an Internet-facing load balancer whose backends and/or NAT pools can be assigned to the primary
        /// network interfaces of the virtual machines in the scale set.
        /// By default, all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the scale set virtual machines.
        /// </summary>
        /// <param name="loadBalancer">An existing Internet-facing load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);

        /// <summary>
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer WithoutPrimaryInternetFacingLoadBalancer();
    }

    /// <summary>
    /// The stage of a Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created, but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged
    {
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of the Windows virtual machine scale set definition allowing to specify administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordManaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the computer name prefix.
    /// </summary>
    public interface IWithComputerNamePrefix
    {

        /// <summary>
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">The prefix for the auto-generated names of the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithComputerNamePrefix(string namePrefix);
    }

    /// <summary>
    /// The stage of a Linux virtual machine scale set definition which contains all the minimum required inputs
    /// for the resource to be created, but also allows for any other optional
    /// settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate
    {

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity
    {

        /// <summary>
        /// Specifies the maximum number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">Number of virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithCapacity(int capacity);
    }

    public interface IWithVaultSecret
    {
        /// <summary>
        /// Specifies a vault secret to add to the vm.
        /// Each call to this method adds to the list of vault secrets.
        /// </summary>
        /// <param name="vaultId">The vault id.</param>
        /// <param name="certificateStore">The vm certificate store e.g. "My".</param>
        /// <param name="certificateUrl">The vault certificate URL.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithVaultSecret(string vaultId, string certificateUrl, string certificateStore);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure accelerated networking.
    /// </summary>
    public interface IWithAcceleratedNetworking :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that accelerated networking should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithAcceleratedNetworking();

        /// <summary>
        /// Specify that accelerated networking should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithoutAcceleratedNetworking();
    }

    /// <summary>
    /// The stage of the Linux virtual machine scale set definition allowing to specify SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the upgrade policy.
    /// </summary>
    public interface IWithUpgradePolicy
    {

        /// <summary>
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">An upgrade policy mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithUpgradeMode(UpgradeMode upgradeMode);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify unmanaged data disk.
    /// </summary>
    public interface IWithUnmanagedDataDisk
    {

    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to enable public ip
    /// for vm instances.
    /// </summary>
    public interface IWithVirtualMachinePublicIp :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithVirtualMachinePublicIp();

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="leafDomainLabel">The domain name label.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithVirtualMachinePublicIp(string leafDomainLabel);

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="ipConfig">The public ip address configuration.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithVirtualMachinePublicIp(VirtualMachineScaleSetPublicIPAddressConfiguration ipConfig);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify the custom data.
    /// </summary>
    public interface IWithCustomData
    {

        /// <summary>
        /// Specifies the custom data for the virtual machine scale set.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage in the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithCustomData(string base64EncodedCustomData);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to configure application security group.
    /// </summary>
    public interface IWithApplicationSecurityGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroup">The application security group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingApplicationSecurityGroup(IApplicationSecurityGroup applicationSecurityGroup);

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithExistingApplicationSecurityGroupId(string applicationSecurityGroupId);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition to set the billing related details of the low priority virtual machines in the scale set.
    /// </summary>
    public interface IWithBillingProfile
    {
        /// <summary>
        /// Specifies the billing related details of the low priority virtual machines in the scale set.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithMaxPrice(double? maxPrice);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify whether
    /// or not to over-provision virtual machines in the scale set.
    /// </summary>
    public interface IWithOverProvision
    {

        /// <summary>
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithoutOverProvisioning();

        /// <summary>
        /// Enables or disables over-provisioning of virtual machines in the scale set.
        /// </summary>
        /// <param name="enabled">
        /// True if enabling over-0provisioning of virtual machines in the
        /// scale set, otherwise false.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvision(bool enabled);

        /// <summary>
        /// Enables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithOverProvisioning();
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify priority for vms in the scale-set.
    /// </summary>
    public interface IWithVMPriority :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that virtual machines in the scale set should be low priority VMs.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithLowPriorityVirtualMachine();

        /// <summary>
        /// Specify that virtual machines in the scale set should be low priority VMs with
        /// provided eviction policy.
        /// </summary>
        /// <param name="policy">Eviction policy for the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithLowPriorityVirtualMachine(VirtualMachineEvictionPolicyTypes policy);

        /// <summary>
        /// Specifies the priority of the virtual machines in the scale set.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate WithVirtualMachinePriority(VirtualMachinePriorityTypes priority);
    }

    /// <summary>
    /// The stage of a Windows virtual machine scale set definition which contains all the minimum required
    /// inputs for the resource to be created, but also allows for any other
    /// optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedCreate
    {

        /// <summary>
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithAutoUpdate();

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithoutAutoUpdate();

        /// <summary>
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithoutVMAgent();

        /// <summary>
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithTimeZone(string timeZone);

        /// <summary>
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithVMAgent();

        /// <summary>
        /// Specifies the WinRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged WithWinRM(WinRMListener listener);
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition containing all the required inputs for the resource
    /// to be created, but also allowing for any other optional settings
    /// to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOSDiskSettings,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithComputerNamePrefix,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCapacity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUpgradePolicy,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOverProvision,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithVaultSecret,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCustomData,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUserAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithBootDiagnostics,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithBillingProfile,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithVMPriority,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithVirtualMachinePublicIp,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithAcceleratedNetworking,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithIpForwarding,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithNetworkSecurityGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSinglePlacementGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithApplicationGateway,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithApplicationSecurityGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The optionals applicable only for managed disks.
    /// </summary>
    public interface IWithManagedDiskOptionals
    {

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithDataDiskDefaultCachingType(CachingTypes cachingType);

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the storage account type for managed OS disk.
        /// </summary>
        /// <param name="accountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate WithOSDiskStorageAccountType(StorageAccountTypes accountType);
    }

    /// <summary>
    /// The stage of a virtual machine scaleset definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOSBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the resource ID of a Linux gallery image version to be used as the virtual machines scaleset OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of a gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged WithLinuxGalleryImageVersion(string galleryImageVersionId);

        /// <summary>
        /// Specifies the resource ID of a Windows gallery image version to be used as the virtual machine scaleset OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of the gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged WithWindowsGalleryImageVersion(string galleryImageVersionId);
    }
}