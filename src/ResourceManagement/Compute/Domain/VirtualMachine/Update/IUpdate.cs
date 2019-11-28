// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;

    /// <summary>
    /// The stage of the virtual machine update allowing to enable System Assigned (Local) Managed Service Identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithProximityPlacementGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSecondaryNetworkInterface,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithBootDiagnostics,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithBillingProfile,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithUserAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithPriority,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithLicenseType
    {

        /// <summary>
        /// Specifies the default caching type for the managed data disks.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithDataDiskDefaultCachingType(CachingTypes cachingType);

        /// <summary>
        /// Specifies a storage account type.
        /// </summary>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType);

        /// <summary>
        /// Specifies the caching type for the OS disk.
        /// </summary>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the ephemeral options for the OS disk.
        /// </summary>
        /// <param name="diffDiskOptions">Specifies the ephemeral disk options for
        /// operating system disk. Possible values include: 'Local'</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithEphemeralOSDisk(DiffDiskOptions diffDiskOptions);

        /// <summary>
        /// Specifies the encryption settings for the OS Disk.
        /// </summary>
        /// <param name="settings">The encryption settings.</param>
        /// <return>The stage representing creatable VM update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskEncryptionSettings(DiskEncryptionSettings settings);

        /// <summary>
        /// Specifies the size of the OS disk in GB.
        /// Only unmanaged disks may be resized as part of a VM update. Managed disks must be resized separately, using managed disk API.
        /// </summary>
        /// <param name="size">A disk size.</param>
        /// <return>The next stage of the update.</return>
        /// <deprecated>Use  .withOSDiskSizeInGB(int) instead.</deprecated>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOSDiskSizeInGB(int size);

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of a size for the virtual machine as text.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(string sizeName);

        /// <summary>
        /// Specifies a new size for the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(VirtualMachineSizeTypes size);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify a managed data disk.
    /// </summary>
    public interface IWithManagedDataDisk
    {

        /// <summary>
        /// Associates an existing source managed disk with the VM.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">The managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies an existing source managed disk and settings.
        /// </summary>
        /// <param name="disk">A managed disk.</param>
        /// <param name="newSizeInGB">The disk resize size in GB.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable);

        /// <summary>
        /// Specifies that a managed disk needs to be created explicitly with the given definition and
        /// attached to the virtual machine as a data disk.
        /// </summary>
        /// <param name="creatable">A creatable disk definition.</param>
        /// <param name="lun">The data disk LUN.</param>
        /// <param name="cachingType">A data disk caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">A caching type.</param>
        /// <param name="storageAccountType">A storage account type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Detaches a managed data disk with the given LUN from the virtual machine.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutDataDisk(int lun);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to enable boot diagnostics.
    /// </summary>
    public interface IWithBootDiagnostics
    {

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithBootDiagnostics(string storageAccountBlobEndpointUri);

        /// <summary>
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutBootDiagnostics();
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to
    /// set/remove information about the proximity placement group that the virtual machine scale set should
    /// be assigned to.
    /// </summary>
    public interface IWithProximityPlacementGroup
    {
        /// <summary>
        /// Set information about the proximity placement group that the virtual machineshould
        /// be assigned to.
        /// </summary>
        /// <param name="promixityPlacementGroupId">The Id of the proximity placement group subResource.</param>
        /// <returns>the next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithProximityPlacementGroup(String promixityPlacementGroupId);

        /// <summary>
        /// Removes the Proximity placement group from the VM
        /// </summary>
        /// <returns>the next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutProximityPlacementGroup();
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to set the billing related details of a low priority virtual machine.
    /// </summary>
    public interface IWithBillingProfile
    {
        /// <summary>
        /// Specifies the billing related details of a low priority virtual machine.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithMaxPrice(double? maxPrice);
    }

    /// <summary>
    /// The stage of a virtual machine definition allowing to specify unmanaged data disk configuration.
    /// </summary>
    public interface IWithUnmanagedDataDisk
    {

        /// <summary>
        /// Begins the definition of a blank unmanaged data disk to be attached to the virtual machine along with its configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The first stage of the data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineUnmanagedDataDisk(string name);

        /// <summary>
        /// Begins the description of an update of an existing unmanaged data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing disk.</param>
        /// <return>The first stage of the data disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.Update.IUpdate UpdateUnmanagedDataDisk(string name);

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Specifies that a new blank unmanaged data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewUnmanagedDataDisk(int sizeInGB);

        /// <summary>
        /// Detaches an unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="name">The name of an existing data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutUnmanagedDataDisk(string name);

        /// <summary>
        /// Detaches a unmanaged data disk from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutUnmanagedDataDisk(int lun);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify extensions.
    /// </summary>
    public interface IWithExtension
    {

        /// <summary>
        /// Begins the definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">A reference name for the extension.</param>
        /// <return>The first stage of an extension definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineNewExtension(string name);

        /// <summary>
        /// Begins the description of an update of an existing extension of this virtual machine.
        /// </summary>
        /// <param name="name">The reference name of an existing extension.</param>
        /// <return>The first stage of an extension update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Detaches an extension from the virtual machine.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutExtension(string name);
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled virtual machine allowing
    /// to set access role for the identity.
    /// </summary>
    public interface IWithSystemAssignedIdentityBasedAccessOrUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate
    {

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID.
        /// Applications running on the virtual machine will have the same permission (role) on
        /// the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the virtual machine will have the same permission (role) on
        /// the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that virtual machine resides. Applications running
        /// on the virtual machine will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the access (described by the
        /// role definition) on the resource group that virtual machine resides. Applications running
        /// on the virtual machine will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to specify that the image or disk that is being used was licensed
    /// on-premises. This element is only used for images that contain the Windows Server operating system.
    /// </summary>
    public interface IWithLicenseType :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises.
        /// </summary>
        /// <param name="licenseType">License type.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithLicenseType(string licenseType);
    }

    /// <summary>
    /// The stage of a virtual machine update allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface
    {

        /// <summary>
        /// Associates an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Creates a new network interface to associate with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);

        /// <summary>
        /// Removes a secondary network interface from the virtual machine.
        /// </summary>
        /// <param name="name">The name of a secondary network interface to remove.</param>
        /// <return>The next stage of the update.</return>
        [Obsolete("WithoutSecondaryNetworkInterface is deprecated, use WithoutNetworkInterface instead.")]
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutSecondaryNetworkInterface(string name);

        /// <summary>
        /// Removes a network interface from the virtual machine.
        /// </summary>
        /// <param name="nicId">The id of the network interface to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutNetworkInterface(string nicId);
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to add or remove User Assigned (External) Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity);

        /// <summary>
        /// Specifies that an user assigned identity associated with the virtual machine should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutUserAssignedManagedServiceIdentity(string identityId);
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to update priority.
    /// </summary>
    public interface IWithPriority :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies a new priority for the virtual machine.
        /// </summary>
        /// <param name="priority">a priority from the list of available priority types.</param>
        /// <returns>the next stage of the virtual machine update.</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithPriority(VirtualMachinePriorityTypes priority);
    }
}