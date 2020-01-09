// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition
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
    /// The stage of a virtual machine definition containing various settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged
    {

        /// <summary>
        /// Specifies that unmanaged disks will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to select a VM size.
    /// </summary>
    public interface IWithVMSize
    {

        /// <summary>
        /// Selects the size of the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of a size for the virtual machine as text.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithSize(string sizeName);

        /// <summary>
        /// Specifies the size of the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithSize(VirtualMachineSizeTypes size);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged
    {

        /// <summary>
        /// Specifies the SSH public key.
        /// Each call to this method adds the given public key to the list of VM's public keys.
        /// </summary>
        /// <param name="publicKey">The SSH public key in PEM format.</param>
        /// <return>The stage representing creatable Linux VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to
    /// set information about the proximity placement group that the virtual machine scale set should
    /// be assigned to.
    /// </summary>
    public interface IWithProximityPlacementGroup : IWithOS
    {
        /// <summary> 
        /// Set information about the proximity placement group that the virtual machine scale set should
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition.</returns>
        IWithOS WithProximityPlacementGroup(string promixityPlacementGroupId);


        /// <summary>
        /// Creates a new proximity placement group with the specified name and then adds it to the VM
        /// </summary>
        /// <param name="proximityPlacementGroupName">the name of the group to be created.</param>
        /// <param name="type">the type of the group</param>
        /// <returns>the next stage of the definition.</returns>
        IWithOS WithNewProximityPlacementGroup(string proximityPlacementGroupName, ProximityPlacementGroupType type);

    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOS :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOSBeta
    {

        /// <summary>
        /// Specifies that the latest version of a marketplace Linux image is to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of an image.</param>
        /// <param name="offer">Specifies an offer of the image.</param>
        /// <param name="sku">Specifies a SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithLatestLinuxImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies that the latest version of a marketplace Windows image should to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="publisher">Specifies the publisher of the image.</param>
        /// <param name="offer">Specifies the offer of the image.</param>
        /// <param name="sku">Specifies the SKU of the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithLatestWindowsImage(string publisher, string offer, string sku);

        /// <summary>
        /// Specifies the resource ID of a Linux custom image to be used as the virtual machines' OS.
        /// </summary>
        /// <param name="customImageId">The resource ID of a custom image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManaged WithLinuxCustomImage(string customImageId);

        /// <summary>
        /// Specifies a known marketplace Linux image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies a known marketplace Windows image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="knownImage">A known market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage);

        /// <summary>
        /// Specifies a specialized operating system managed disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="disk">The managed disk to attach.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithSpecializedOSDisk(IDisk disk, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies a specialized operating system unmanaged disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="osDiskUrl">OsDiskUrl the URL to the OS disk in the Azure Storage account.</param>
        /// <param name="osType">The OS type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithSpecializedOSUnmanagedDisk(string osDiskUrl, OperatingSystemTypes osType);

        /// <summary>
        /// Specifies a version of a market-place Linux image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="imageReference">Describes the publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged WithSpecificLinuxImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies a version of a marketplace Windows image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="imageReference">Describes publisher, offer, SKU and version of the market-place image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged WithSpecificWindowsImageVersion(ImageReference imageReference);

        /// <summary>
        /// Specifies a user (generalized) Linux image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The URL of a VHD.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged WithStoredLinuxImage(string imageUrl);

        /// <summary>
        /// Specifies the user (generalized) Windows image to be used for the virtual machine's OS.
        /// </summary>
        /// <param name="imageUrl">The URL of a VHD.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged WithStoredWindowsImage(string imageUrl);

        /// <summary>
        /// Specifies the resource ID of a Windows custom image to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="customImageId">The resource ID of the custom image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManaged WithWindowsCustomImage(string customImageId);
    }

    /// <summary>
    /// The stage of a virtual machine definition containing various settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsManaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate
    {

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">A name for the computer.</param>
        /// <return>The next stage stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged WithComputerName(string computerName);

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">The base64 encoded custom data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged WithCustomData(string base64EncodedCustomData);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManaged
    {

        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify the primary network interface.
    /// </summary>
    public interface IWithPrimaryNetworkInterface
    {

        /// <summary>
        /// Associates an existing network interface with the virtual machine as its primary network interface.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine as its primary network interface,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithNewPrimaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify a private IP address within a virtual network subnet.
    /// </summary>
    public interface IWithPrivateIP
    {

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network subnet for
        /// the VM's primary network interface.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress WithPrimaryPrivateIPAddressDynamic();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network subnet to the
        /// VM's primary network interface.
        /// </summary>
        /// <param name="staticPrivateIPAddress">A static IP address within the specified subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to add an unmanaged data disk.
    /// </summary>
    public interface IWithUnmanagedDataDisk
    {

        /// <summary>
        /// Begins definition of an unmanaged data disk to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The first stage of an unmanaged data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate> DefineUnmanagedDataDisk(string name);

        /// <summary>
        /// Attaches an existing unmanaged VHD as a data disk to the virtual machine.
        /// </summary>
        /// <param name="storageAccountName">A storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Attaches a new blank unmanaged data disk to the virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithNewUnmanagedDataDisk(int sizeInGB);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify a virtual network with the new primary network interface.
    /// </summary>
    public interface IWithNetwork :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrimaryNetworkInterface
    {

        /// <summary>
        /// Associates an existing virtual network with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSubnet WithExistingPrimaryNetwork(INetwork network);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the virtual machine's primary network interface.
        /// The virtual network will be created in the same resource group and region as of virtual machine, it will be
        /// created with the specified address space and a default subnet covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithNewPrimaryNetwork(string addressSpace);
    }

    /// <summary>
    /// The stage of a Windows virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateManaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged
    {

        /// <summary>
        /// Disables automatic updates.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithoutAutoUpdate();

        /// <summary>
        /// Prevents the provisioning of a VM agent.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithoutVMAgent();

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">A time zone.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithTimeZone(string timeZone);

        /// <summary>
        /// Specifies  WinRM listener.
        /// Each call to this method adds the given listener to the list of the VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">A WinRM listener.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithWinRM(WinRMListener listener);

        /// <summary>
        /// Specifies a vault secret to add to the vm.
        /// Each call to this method adds to the list of vault secrets.
        /// </summary>
        /// <param name="vaultId">The vault id.</param>
        /// <param name="certificateStore">The vm certificate store e.g. "My".</param>
        /// <param name="certificateUrl">The vault certificate URL.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithVaultSecret(string vaultId, string certificateUrl, string certificateStore);

    }

    /// <summary>
    /// The stage of a Windows virtual machine definition allowing to specify an administrator password.
    /// </summary>
    public interface IWithWindowsAdminPasswordManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the complexity criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension
    {

        /// <summary>
        /// Starts the definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage stage of an extension definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate> DefineNewExtension(string name);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOSDiskSettings,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithVMSize,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithAvailabilitySet,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSecondaryNetworkInterface,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPlan,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithBootDiagnostics,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPriority,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithBillingProfile,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUserAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLicenseType
    {

    }

    /// <summary>
    /// The stage of the Windows virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithWindowsCreateUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged
    {

        /// <summary>
        /// Specifies that automatic updates should be disabled.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithoutAutoUpdate();

        /// <summary>
        /// Specifies that VM Agent should not be provisioned.
        /// </summary>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithoutVMAgent();

        /// <summary>
        /// Specifies the time-zone.
        /// </summary>
        /// <param name="timeZone">The timezone.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithTimeZone(string timeZone);

        /// <summary>
        /// Specifies the WINRM listener.
        /// Each call to this method adds the given listener to the list of VM's WinRM listeners.
        /// </summary>
        /// <param name="listener">The WinRMListener.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithWinRM(WinRMListener listener);

        /// <summary>
        /// Specifies a vault secret to add to the vm.
        /// Each call to this method adds to the list of vault secrets.
        /// </summary>
        /// <param name="vaultId">The vault id.</param>
        /// <param name="certificateStore">The vm certificate store e.g. "My".</param>
        /// <param name="certificateUrl">The vault certificate URL.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithVaultSecret(string vaultId, string certificateUrl, string certificateStore);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify availability set.
    /// </summary>
    public interface IWithAvailabilitySet
    {

        /// <summary>
        /// Specifies an existing availability set to associate with the virtual machine.
        /// </summary>
        /// <param name="availabilitySet">An existing availability set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingAvailabilitySet(IAvailabilitySet availabilitySet);

        /// <summary>
        /// Specifies the name of a new availability set to associate with the virtual machine.
        /// </summary>
        /// <param name="name">The name of an availability set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewAvailabilitySet(string name);

        /// <summary>
        /// Specifies definition of a not-yet-created availability set definition
        /// to associate the virtual machine with.
        /// </summary>
        /// <param name="creatable">A creatable availability set definition.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewAvailabilitySet(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> creatable);
    }

    /// <summary>
    /// The stage of a virtual machine definition which contains all the minimum required inputs for the VM using
    /// storage account (unmanaged based OS disk to be created and optionally allow unmanaged data disk and settings
    /// specific to unmanaged OS disk to be specified.
    /// </summary>
    public interface IWithUnmanagedCreate :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate
    {

        /// <summary>
        /// Specifies the name of an OS disk VHD file and its parent container.
        /// </summary>
        /// <param name="containerName">The name of the container in the selected storage account.</param>
        /// <param name="vhdName">The name for the OS disk VHD.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate WithOSDiskVhdLocation(string containerName, string vhdName);
    }

    /// <summary>
    /// The first stage of a virtual machine definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify that the image or disk that is being used was licensed
    /// on-premises. This element is only used for images that contain the Windows Server operating system.
    /// </summary>
    public interface IWithLicenseType :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises.
        /// </summary>
        /// <param name="licenseType">License type.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithLicenseType(string licenseType);
    }

    /// <summary>
    /// The stage of a virtual machine definition containing various settings when virtual machine is created from image.
    /// </summary>
    public interface IWithFromImageCreateOptionsUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate
    {

        /// <summary>
        /// Specifies the computer name for the virtual machine.
        /// </summary>
        /// <param name="computerName">A computer name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithComputerName(string computerName);

        /// <summary>
        /// Specifies the custom data for the virtual machine.
        /// </summary>
        /// <param name="base64EncodedCustomData">Base64 encoded custom data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged WithCustomData(string base64EncodedCustomData);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to enable unmanaged disks
    /// or continue the definition of the VM with managed disks only.
    /// </summary>
    public interface IWithWindowsCreateManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged
    {

        /// <summary>
        /// Enables unmanaged disk support on this virtual machine.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithUnmanagedDisks();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the VM using managed OS disk
    /// to be created and optionally allow managed data disks specific settings to be specified.
    /// </summary>
    public interface IWithManagedCreate :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithAvailabilityZone,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate
    {

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of teh definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithDataDiskDefaultCachingType(CachingTypes cachingType);

        /// <summary>
        /// Specifies the default caching type for managed data disks.
        /// </summary>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the storage account type for the managed OS disk.
        /// </summary>
        /// <param name="accountType">Storage account type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithOSDiskStorageAccountType(StorageAccountTypes accountType);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to associate a public IP address with its primary network interface.
    /// </summary>
    public interface IWithPublicIPAddress
    {

        /// <summary>
        /// Associates an existing public IP address with the VM's primary network interface.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress);

        /// <summary>
        /// Creates a new public IP address to associate with the VM's primary network interface.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and resource group as the resource, with the specified DNS label
        /// and associates it with the VM's primary network interface.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">A leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithNewPrimaryPublicIPAddress(string leafDnsLabel);

        /// <summary>
        /// Specifies that the VM should not have a public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithProximityPlacementGroup WithoutPrimaryPublicIPAddress();
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify the virtual network subnet for a new primary network interface.
    /// </summary>
    public interface IWithSubnet
    {

        /// <summary>
        /// Associates a subnet with the virtual machine's primary network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled virtual machine allowing to
    /// set access role for the identity.
    /// </summary>
    public interface IWithSystemAssignedIdentityBasedAccessOrCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate
    {

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given access
        /// (described by the role) on an ARM resource identified by the resource ID. Applications running
        /// on the virtual machine will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the virtual machine will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that virtual machine resides. Applications running
        /// on the virtual machine will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides.
        /// Applications running on the virtual machine will have the same permission (role) on the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the Windows virtual machine definition allowing to specify an administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameUnmanaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name following the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify a purchase plan.
    /// </summary>
    public interface IWithPlan
    {

        /// <summary>
        /// Specifies the purchase plan for the virtual machine.
        /// </summary>
        /// <param name="plan">A purchase plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithPlan(PurchasePlan plan);

        /// <summary>
        /// Specifies the purchase plan for the virtual machine.
        /// </summary>
        /// <param name="plan">A purchase plan.</param>
        /// <param name="promotionCode">A promotion code.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithPromotionalPlan(PurchasePlan plan, string promotionCode);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged
    {

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies the SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify a managed data disk.
    /// </summary>
    public interface IWithManagedDataDisk
    {

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine.
        /// </summary>
        /// <param name="disk">An existing managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk);

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine and specifies additional settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType);

        /// <summary>
        /// Associates an existing source managed disk with the virtual machine and specifies additional settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk should be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attach to the virtual machine as data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk.</param>
        /// <param name="lun">The data disk LUN.</param>
        /// <param name="cachingType">A data disk caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType);

        /// <summary>
        /// Specifies the data disk to be created from the data disk image in the virtual machine image.
        /// </summary>
        /// <param name="imageLun">The LUN of the source data disk image.</param>
        /// <param name="newSizeInGB">The new size that overrides the default size specified in the data disk image.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify OS disk configurations.
    /// </summary>
    public interface IWithOSDiskSettings
    {

        /// <summary>
        /// Specifies the caching type for the OS disk.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the ephemeral options for the OS disk.
        /// </summary>
        /// <param name="diffDiskOptions">Specifies the ephemeral disk options for
        /// operating system disk. Possible values include: 'Local'</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithEphemeralOSDisk(DiffDiskOptions diffDiskOptions);

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskEncryptionSettings(DiskEncryptionSettings settings);

        /// <summary>
        /// Specifies the name for the OS Disk.
        /// </summary>
        /// <param name="name">An OS disk name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskName(string name);

        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The next stage of the definition.</return>
        /// <deprecated>Use  .withOSDiskSizeInGB(int) instead.</deprecated>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithOSDiskSizeInGB(int size);
    }

    /// <summary>
    /// The stage of a Windows virtual machine definition allowing to specify an administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name following the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a Windows virtual machine definition allowing to specify an administrator user name.
    /// </summary>
    public interface IWithWindowsAdminUsernameManaged
    {

        /// <summary>
        /// Specifies the administrator user name for the Windows virtual machine.
        /// </summary>
        /// <param name="adminUserName">A user name followinmg the required naming convention for Windows user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManaged WithAdminUsername(string adminUserName);
    }

    /// <summary>
    /// The stage of a Windows virtual machine definition allowing to specify an administrator user name.
    /// </summary>
    public interface IWithWindowsAdminPasswordManaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the complexity criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to enable boot diagnostics.
    /// </summary>
    public interface IWithBootDiagnostics
    {

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithBootDiagnostics(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithBootDiagnostics(string storageAccountBlobEndpointUri);
    }

    /// <summary>
    /// The stage of the Linux virtual machine definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithLinuxCreateManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManagedOrUnmanaged
    {

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a Windows virtual machine definition allowing to specify an administrator password.
    /// </summary>
    public interface IWithWindowsAdminPasswordUnmanaged
    {

        /// <summary>
        /// Specifies the administrator password for the Windows virtual machine.
        /// </summary>
        /// <param name="adminPassword">A password following the criteria for Azure Windows VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged WithAdminPassword(string adminPassword);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root user name.
    /// </summary>
    public interface IWithLinuxRootUsernameUnmanaged
    {

        /// <summary>
        /// Specifies an SSH root user name for the Linux virtual machine.
        /// </summary>
        /// <param name="rootUserName">A user name following the required naming convention for Linux user names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify User Assigned (External) Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to enable System Assigned (Local) Managed Service Identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of the VM definition allowing to specify availability zone.
    /// </summary>
    public interface IWithAvailabilityZone :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the availability zone for the virtual machine.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate WithAvailabilityZone(AvailabilityZoneId zoneId);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify priority.
    /// </summary>
    public interface IWithPriority
    {
        /// <summary>
        /// Specifies that virtual machine should be low priority.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithLowPriority();

        /// <summary>
        /// Specifies that virtual machine should be low priority.
        /// </summary>
        /// <param name="policy">The eviction policy for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithLowPriority(VirtualMachineEvictionPolicyTypes policy);

        /// <summary>
        /// Specifies the priority for the virtual machine.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithPriority(VirtualMachinePriorityTypes priority);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to set the billing related details of a low priority virtual machine.
    /// </summary>
    public interface IWithBillingProfile
    {
        /// <summary>
        /// Specifies the billing related details of a low priority virtual machine.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithMaxPrice(double? maxPrice);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface
    {

        /// <summary>
        /// Associates an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// Note this method's effect is additive, i.e. each time it is used, a new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify a storage account.
    /// </summary>
    public interface IWithStorageAccount
    {

        /// <summary>
        /// Specifies an existing storage account to put the VM's OS and data disk VHD in.
        /// An OS disk based on a marketplace or a user image (generalized image) will be stored in this
        /// storage account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies the name of a new storage account to put the VM's OS and data disk VHD into.
        /// Only an OS disk based on a marketplace image will be stored in the new storage account.
        /// An OS disk based on a user image will be stored in the same storage account as the user image.
        /// </summary>
        /// <param name="name">The name for a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewStorageAccount(string name);

        /// <summary>
        /// Specifies the definition of a not-yet-created storage account
        /// to put the VM's OS and data disk VHDs into.
        /// Only the OS disk based on a marketplace image will be stored in the new storage account.
        /// An OS disk based on a user image will be stored in the same storage account as the user image.
        /// </summary>
        /// <param name="creatable">A creatable storage account definition.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);
    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyManaged
    {

        /// <summary>
        /// Specifies the SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password, following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithNetwork>
    {

    }

    /// <summary>
    /// The stage of a Linux virtual machine definition allowing to specify an SSH root password or public key.
    /// </summary>
    public interface IWithLinuxRootPasswordOrPublicKeyUnmanaged
    {

        /// <summary>
        /// Specifies an SSH root password for the Linux virtual machine.
        /// </summary>
        /// <param name="rootPassword">A password following the complexity criteria for Azure Linux VM passwords.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithRootPassword(string rootPassword);

        /// <summary>
        /// Specifies an SSH public key.
        /// </summary>
        /// <param name="publicKey">An SSH public key in the PEM format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged WithSsh(string publicKey);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify the operating system image.
    /// </summary>
    public interface IWithOSBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the resource ID of a Linux gallery image version to be used as the virtual machines' OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of a gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManaged WithLinuxGalleryImageVersion(string galleryImageVersionId);

        /// <summary>
        /// Specifies the resource ID of a Windows gallery image version to be used as the virtual machine's OS.
        /// </summary>
        /// <param name="galleryImageVersionId">The resource ID of the gallery image version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManaged WithWindowsGalleryImageVersion(string galleryImageVersionId);
    }
}