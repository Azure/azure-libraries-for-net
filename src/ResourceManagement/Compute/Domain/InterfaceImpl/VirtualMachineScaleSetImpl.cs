// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionManaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionManagedOrUnmanaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionUnmanaged;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Rest;
    using System;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;

    internal partial class VirtualMachineScaleSetImpl
    {
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
        /// Disables over-provisioning of virtual machines.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithOverProvision.WithoutOverProvisioning()
        {
            return this.WithoutOverProvisioning();
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
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
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
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
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
        /// Detaches managed data disk with the given LUN from the virtual machine scale set instances.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithManagedDataDisk.WithoutDataDisk(int lun)
        {
            return this.WithoutDataDisk(lun);
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
        /// Specifies the user (custom) Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="imageUrl">The URL the the VHD.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithStoredLinuxImage(string imageUrl)
        {
            return this.WithStoredLinuxImage(imageUrl);
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
        /// Specifies the ID of a Linux custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged VirtualMachineScaleSet.Definition.IWithOS.WithLinuxCustomImage(string customImageId)
        {
            return this.WithLinuxCustomImage(customImageId);
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
        /// Specifies the ID of a Windows custom image to be used.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged VirtualMachineScaleSet.Definition.IWithOS.WithWindowsCustomImage(string customImageId)
        {
            return this.WithWindowsCustomImage(customImageId);
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
        /// Specifies a known marketplace Linux image used as the virtual machine's operating system.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithOS.WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return this.WithPopularLinuxImage(knownImage);
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
        VirtualMachineScaleSet.Definition.IWithNetworkSubnet VirtualMachineScaleSet.Definition.IWithSku.WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            return this.WithSku(skuType);
        }

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithNetworkSubnet VirtualMachineScaleSet.Definition.IWithSku.WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku);
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
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
        }

        /// <return>The next stage of a unmanaged disk based virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithUnmanagedCreate VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks();
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
        /// Enables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithAutoUpdate()
        {
            return this.WithAutoUpdate();
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
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithoutAutoUpdate()
        {
            return this.WithoutAutoUpdate();
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
        /// Enables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged.WithVMAgent()
        {
            return this.WithVMAgent();
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
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity);
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
        /// Disables the VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithoutVMAgent()
        {
            return this.WithoutVMAgent();
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
        /// Specifies the WinRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithWinRM(WinRMListener listener)
        {
            return this.WithWinRM(listener);
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
        /// Specifies the time zone for the virtual machines to use.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged.WithTimeZone(string timeZone)
        {
            return this.WithTimeZone(timeZone);
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
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
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
        /// Specifies that no internal load balancer should be associated with the primary network interfaces of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithOS VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer.WithoutPrimaryInternalLoadBalancer()
        {
            return this.WithoutPrimaryInternalLoadBalancer();
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
        /// Specifies the name prefix to use for auto-generating the names for the virtual machines in the scale set.
        /// </summary>
        /// <param name="namePrefix">The prefix for the auto-generated names of the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithComputerNamePrefix.WithComputerNamePrefix(string namePrefix)
        {
            return this.WithComputerNamePrefix(namePrefix);
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
        /// Gets the extensions attached to the virtual machines in the scale set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Extensions
        {
            get
            {
                return this.Extensions();
            }
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

        /// <return>The network interfaces associated with all virtual machine instances in a scale set.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListNetworkInterfaces()
        {
            return this.ListNetworkInterfaces();
        }

        /// <return>
        /// The virtual network associated with the primary network interfaces of the virtual machines
        /// in the scale set.
        /// A primary internal load balancer associated with the primary network interfaces of the scale set
        /// virtual machine will be also belong to this network
        /// </p>.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryNetwork()
        {
            return this.GetPrimaryNetwork();
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

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Reimage()
        {

            this.Reimage();
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
        /// Starts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Start()
        {

            this.Start();
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

        /// <return>
        /// Available SKUs for the virtual machine scale set, including the minimum and maximum virtual machine instances
        /// allowed for a particular SKU.
        /// </return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.ListAvailableSkus()
        {
            return this.ListAvailableSkus();
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
        /// Gets the type of Managed Service Identity used for the virtual machine scale set.
        /// </summary>
        Models.VirtualMachinePriorityTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.VirtualMachinePriority
        {
            get
            {
                return this.VirtualMachinePriority();
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
        /// Check whether Managed Service Identity is enabled for the virtual machine scale set.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetBeta.IsManagedServiceIdentityEnabled
        {
            get
            {
                return this.IsManagedServiceIdentityEnabled();
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
        /// Shuts down the virtual machines in the scale set and releases its compute resources.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Deallocate()
        {

            this.Deallocate();
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
        /// The internal load balancer associated with the primary network interface of
        /// the virtual machines in the scale set.
        /// </return>
        /// <throws>IOException the IO exception.</throws>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.GetPrimaryInternalLoadBalancer()
        {
            return this.GetPrimaryInternalLoadBalancer();
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

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PowerOff()
        {

            this.PowerOff();
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
        /// Gets the upgrade model.
        /// </summary>
        Models.UpgradeMode Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.UpgradeModel
        {
            get
            {
                return this.UpgradeModel();
            }
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Restart()
        {

            this.Restart();
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
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.StartAsync(CancellationToken cancellationToken)
        {

            await this.StartAsync(cancellationToken);
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
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.PowerOffAsync(CancellationToken cancellationToken)
        {

            await this.PowerOffAsync(cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.DeallocateAsync(CancellationToken cancellationToken)
        {

            await this.DeallocateAsync(cancellationToken);
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

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.RestartAsync(CancellationToken cancellationToken)
        {

            await this.RestartAsync(cancellationToken);
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
        /// Gets the number of virtual machine instances in the scale set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet.Capacity
        {
            get
            {
                return this.Capacity();
            }
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
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool.WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            return this.WithoutPrimaryInternalLoadBalancerNatPools(natPoolNames);
        }

        VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsCreateManagedOrUnmanaged.WithUnmanagedDisks()
        {
            return this.WithUnmanagedDisks();
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
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged.WithRootPassword(string rootPassword)
        {
            return this.WithRootPassword(rootPassword);
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
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The stage representing creatable VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithManagedCreate VirtualMachineScaleSet.Definition.IWithManagedDiskOptionals.WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            return this.WithDataDiskDefaultStorageAccountType(storageAccountType);
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
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordUnmanaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameUnmanaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
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
        /// Specifies the virtual machine scale set upgrade policy mode.
        /// </summary>
        /// <param name="upgradeMode">An upgrade policy mode.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUpgradePolicy.WithUpgradeMode(UpgradeMode upgradeMode)
        {
            return this.WithUpgradeMode(upgradeMode);
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
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">The Windows administrator user name. This must follow the required naming convention for Windows user name.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged.WithAdminUsername(string adminUserName)
        {
            return this.WithAdminUsername(adminUserName);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
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
        /// Specifies that no public load balancer should be associated with the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer.WithoutPrimaryInternetFacingLoadBalancer()
        {
            return this.WithoutPrimaryInternetFacingLoadBalancer();
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
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithExtension.WithoutExtension(string name)
        {
            return this.WithoutExtension(name);
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
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for an extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSet.Update.IWithExtension.DefineNewExtension(string name)
        {
            return this.DefineNewExtension(name);
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
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">The administrator password. This must follow the criteria for Azure Windows VM password.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged.WithAdminPassword(string adminPassword)
        {
            return this.WithAdminPassword(adminPassword);
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
        /// Specifies the custom data for the virtual machine scale set.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage in the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithCustomData.WithCustomData(string base64EncodedCustomData)
        {
            return this.WithCustomData(base64EncodedCustomData);
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
        /// Specifies the SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A root user name following the required naming conventions for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName);
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
        /// Specifies an existing user assigned identity to be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUserAssignedManagedServiceIdentity.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale set definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithUserAssignedManagedServiceIdentity.WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the defintion.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <param name="tokenPort">The port on the virtual machine scale set instance where access token is available.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity(int tokenPort)
        {
            return this.WithSystemAssignedManagedServiceIdentity(tokenPort);
        }

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale setupdate.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        /// <summary>
        /// Specifies that an user assigned identity associated with the virtual machine scale setshould be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine scale setupdate.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithoutUserAssignedManagedServiceIdentity(string identityId)
        {
            return this.WithoutUserAssignedManagedServiceIdentity(identityId);
        }

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the virtual machinescale set.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale setupdate.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity.WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
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
        /// Specifies that System assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <param name="tokenPort">The port on the virtual machine scale set instance where access token is available.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply VirtualMachineScaleSet.Update.IWithSystemAssignedManagedServiceIdentity.WithSystemAssignedManagedServiceIdentity(int tokenPort)
        {
            return this.WithSystemAssignedManagedServiceIdentity(tokenPort);
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires the access
        /// described in the given role definition with scope of access limited to the ARM resource identified by
        /// the resource ID specified in the scope parameter.
        /// </summary>
        /// <param name="resourceId">scope of the access represented in ARM resource ID format</param>
        /// <param name="roleDefinitionId">role definition to assigned to the virtual machine scale set</param>
        /// <returns>the next stage of the definition</returns>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the given
        /// access (described by the role) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definiton.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID.
        /// Applications running on the scale set VM instance will have the same permission (role)
        /// on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definiton.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the definiton.</return>
        VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate VirtualMachineScaleSet.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
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
        /// Specifies the priority of the virtual machines in the scale set.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <return>The next stage of the definition.</return>urn>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVMPriority.WithVirtualMachinePriority(VirtualMachinePriorityTypes priority)
        {
            return this.WithVirtualMachinePriority(priority);
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
        /// <param name="policy">eviction policy for the virtual machines in the scale set.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate VirtualMachineScaleSet.Definition.IWithVMPriority.WithLowPriorityVirtualMachine(VirtualMachineEvictionPolicyTypes policy)
        {
            return this.WithLowPriorityVirtualMachine(policy);
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
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSet.Update.IUpdate VirtualMachineScaleSet.Update.IWithBootDiagnostics.WithoutBootDiagnostics()
        {
            return this.WithoutBootDiagnostics();
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
    }

    public partial class ManagedDataDiskCollection
    {
    }
}