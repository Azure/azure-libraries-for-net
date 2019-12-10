// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class DiskImpl
    {
        /// <summary>
        /// Gets the availability zones assigned to the disk.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> Microsoft.Azure.Management.Compute.Fluent.IDiskBeta.AvailabilityZones
        {
            get
            {
                return this.AvailabilityZones();
            }
        }

        /// <summary>
        /// Gets the the disk encryption settings.
        /// </summary>
        EncryptionSettingsCollection Microsoft.Azure.Management.Compute.Fluent.IDiskBeta.EncryptionSettings
        {
            get
            {
                return this.EncryptionSettings();
            }
        }

        /// <summary>
        /// Gets the disk creation method.
        /// </summary>
        Models.DiskCreateOption Microsoft.Azure.Management.Compute.Fluent.IDisk.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets true if the disk is attached to a virtual machine, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IDisk.IsAttachedToVirtualMachine
        {
            get
            {
                return this.IsAttachedToVirtualMachine();
            }
        }

        /// <summary>
        /// Gets the type of the operating system on the disk.
        /// </summary>
        Models.OperatingSystemTypes? Microsoft.Azure.Management.Compute.Fluent.IDisk.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// The stage of the managed disk update allowing to specify the hypervisor generation.
        /// </summary>
        HyperVGeneration IDisk.HyperVGeneration
        {
            get
            {
                return this.HyperVGeneration();
            }
        }

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IDisk.SizeInGB
        {
            get
            {
                return this.SizeInGB();
            }
        }

        /// <summary>
        /// Gets the size of the disk in bytes.
        /// </summary>
        long Microsoft.Azure.Management.Compute.Fluent.IDisk.SizeInByte
        {
            get
            {
                return this.SizeInByte();
            }
        }

        /// <summary>
        /// Gets the disk SKU.
        /// </summary>
        Models.DiskSkuTypes Microsoft.Azure.Management.Compute.Fluent.IDisk.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the details of the source from which the disk is created.
        /// </summary>
        Models.CreationSource Microsoft.Azure.Management.Compute.Fluent.IDisk.Source
        {
            get
            {
                return this.Source();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual machine this disk is attached to, or null
        /// if the disk is in a detached state.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IDisk.VirtualMachineId
        {
            get
            {
                return this.VirtualMachineId();
            }
        }

        /// <summary>
        /// Specifies the ID of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithDataDiskFromDisk.FromDisk(string managedDiskId)
        {
            return this.FromDisk(managedDiskId);
        }

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithDataDiskFromDisk.FromDisk(IDisk managedDisk)
        {
            return this.FromDisk(managedDisk);
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithDataDiskFromSnapshot.FromSnapshot(string snapshotId)
        {
            return this.FromSnapshot(snapshotId);
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot resource.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithDataDiskFromSnapshot.FromSnapshot(ISnapshot snapshot)
        {
            return this.FromSnapshot(snapshot);
        }

        /// <summary>
        /// Specifies the source data VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithStorageAccount Disk.Definition.IWithDataDiskFromVhd.FromVhd(string vhdUrl)
        {
            return this.FromVhd(vhdUrl);
        }

        /// <summary>
        /// Gets or sets if createOption is Upload, this is the size of the
        /// contents of the upload including the VHD footer. This value should
        /// be between 20 (20 MiB) and 33554432 bytes (32 TiB).
        /// </summary>
        /// <param name="uploadSizeInMB">The size of the contents of the upload</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreate Disk.Definition.IWithDataDiskFromUpload.WithUploadSizeInMB(long? uploadSizeInMB)
        {
            return this.WithUploadSizeInMB(uploadSizeInMB);
        }

        /// <summary>
        /// Grants access to the disk.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The read-only SAS URI to the disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IDisk.GrantAccess(int accessDurationInSeconds)
        {
            return this.GrantAccess(accessDurationInSeconds);
        }

        /// <summary>
        /// Grants access to the disk asynchronously.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>A representation of the deferred computation of this call returning a read-only SAS URI to the disk.</return>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.IDisk.GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken)
        {
            return await this.GrantAccessAsync(accessDurationInSeconds, cancellationToken);
        }

        /// <summary>
        /// Revokes access granted to the disk.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IDisk.RevokeAccess()
        {

            this.RevokeAccess();
        }

        /// <summary>
        /// Revokes access granted to the disk asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IDisk.RevokeAccessAsync(CancellationToken cancellationToken)
        {

            await this.RevokeAccessAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the availability zone for the managed disk.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreate Disk.Definition.IWithAvailabilityZone.WithAvailabilityZone(AvailabilityZoneId zoneId)
        {
            return this.WithAvailabilityZone(zoneId);
        }

        /// <summary>
        /// Begins definition of managed disk containing data.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithDataDiskSource Disk.Definition.IWithData.WithData()
        {
            return this.WithData();
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithLinuxDiskSource.WithLinuxFromDisk(string sourceDiskId)
        {
            return this.WithLinuxFromDisk(sourceDiskId);
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithLinuxDiskSource.WithLinuxFromDisk(IDisk sourceDisk)
        {
            return this.WithLinuxFromDisk(sourceDisk);
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithLinuxDiskSource.WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshotId);
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithLinuxDiskSource.WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshot);
        }

        /// <summary>
        /// Specifies the source specialized or generalized Linux OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithStorageAccount Disk.Definition.IWithLinuxDiskSource.WithLinuxFromVhd(string vhdUrl)
        {
            return this.WithLinuxFromVhd(vhdUrl);
        }

        /// <summary>
        /// Specifies the operating system.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the update.</return>
        Disk.Update.IUpdate Disk.Update.IWithOSSettings.WithOSType(OperatingSystemTypes osType)
        {
            return this.WithOSType(osType);
        }

        /// <summary>
        /// Specifies the hypervisor generation of the managed disk.
        /// </summary>
        /// <param name="hyperVGeneration">The hypervisor generation.</param>
        /// <return>The next stage of the update.</return>
        IUpdate Disk.Update.IWithHyperVGeneration.WithHyperVGeneration(HyperVGeneration hyperVGeneration)
        {
            return this.WithHyperVGeneration(hyperVGeneration);
        }

        /// <summary>
        /// Specifies the hypervisor generation of the managed disk.
        /// </summary>
        /// <param name="hyperVGeneration">The hypervisor generation.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate Disk.Definition.IWithHyperVGeneration.WithHyperVGeneration(HyperVGeneration hyperVGeneration)
        {
            return this.WithHyperVGeneration(hyperVGeneration);
        }

        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreate Disk.Definition.IWithCreateAndSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB);
        }

        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the update.</return>
        Disk.Update.IUpdate Disk.Update.IWithSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB);
        }

        /// <summary>
        /// Specifies the disk size for an empty disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreate Disk.Definition.IWithDataDiskSource.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB);
        }

        /// <summary>
        /// Specifies the SKU.
        /// </summary>
        /// <param name="sku">A SKU.</param>
        /// <return>The next stage of the update.</return>
        Disk.Update.IUpdate Disk.Update.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the SKU.
        /// </summary>
        /// <param name="sku">The SKU.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreate Disk.Definition.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies a source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithWindowsDiskSource.WithWindowsFromDisk(string sourceDiskId)
        {
            return this.WithWindowsFromDisk(sourceDiskId);
        }

        /// <summary>
        /// Specifies a source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithWindowsDiskSource.WithWindowsFromDisk(IDisk sourceDisk)
        {
            return this.WithWindowsFromDisk(sourceDisk);
        }

        /// <summary>
        /// Specifies a source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithWindowsDiskSource.WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshotId);
        }

        /// <summary>
        /// Specifies a source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithCreateAndSize Disk.Definition.IWithWindowsDiskSource.WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshot);
        }

        /// <summary>
        /// Specifies a source specialized or generalized Windows OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Disk.Definition.IWithStorageAccount Disk.Definition.IWithWindowsDiskSource.WithWindowsFromVhd(string vhdUrl)
        {
            return this.WithWindowsFromVhd(vhdUrl);
        }

        /// <summary>
        /// Specifies the storage account id.
        /// </summary>
        /// <param name="storageAccountId">The storage account id.</param>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize IWithStorageAccount.WithStorageAccountId(string storageAccountId)
        {
            return this.WithStorageAccountId(storageAccountId);
        }

        /// <summary>
        /// Specifies the storage account name in same resource group.
        /// </summary>
        /// <param name="storageAccountName">The storage account name in same resource group.</param>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize IWithStorageAccount.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName);
        }

        /// <summary>
        /// Specifies the storage account.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Definition.IWithCreateAndSize IWithStorageAccount.WithStorageAccount(IStorageAccount account)
        {
            return this.WithStorageAccount(account);
        }
    }
}