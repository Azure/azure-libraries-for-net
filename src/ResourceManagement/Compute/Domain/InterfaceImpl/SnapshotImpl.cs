// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class SnapshotImpl
    {
        /// <summary>
        /// Gets the snapshot creation method.
        /// </summary>
        Models.DiskCreateOption Microsoft.Azure.Management.Compute.Fluent.ISnapshot.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets the type of operating system in the snapshot.
        /// </summary>
        Models.OperatingSystemTypes? Microsoft.Azure.Management.Compute.Fluent.ISnapshot.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.ISnapshot.SizeInGB
        {
            get
            {
                return this.SizeInGB();
            }
        }

        /// <return>Gets the snapshot SKU type.</return>
        /// <summary>
        /// Gets use  Snapshot.skuType() instead.
        /// </summary>
        Models.DiskSkuTypes Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the snapshot SKU type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.SnapshotSkuType Microsoft.Azure.Management.Compute.Fluent.ISnapshot.SkuType
        {
            get
            {
                return this.SkuType();
            }
        }

        /// <summary>
        /// Gets whether a snapshot is incremental.
        /// </summary>
        bool?  Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Incremental
        {
            get
            {
                return this.Incremental();
            }
        }

        /// <summary>
        /// Gets the details of the source from which snapshot is created.
        /// </summary>
        Models.CreationSource Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Source
        {
            get
            {
                return this.Source();
            }
        }

        /// <summary>
        /// Grants access to the snapshot.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The read-only SAS URI to the snapshot.</return>
        string Microsoft.Azure.Management.Compute.Fluent.ISnapshot.GrantAccess(int accessDurationInSeconds)
        {
            return this.GrantAccess(accessDurationInSeconds);
        }

        /// <summary>
        /// Grants access to the snapshot asynchronously.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>A representation of the deferred computation of this call returning a read-only SAS URI to the disk.</return>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.ISnapshot.GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken)
        {
            return await this.GrantAccessAsync(accessDurationInSeconds, cancellationToken);
        }

        /// <summary>
        /// Revoke access granted to the snapshot.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.ISnapshot.RevokeAccess()
        {

            this.RevokeAccess();
        }

        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.ISnapshot.RevokeAccessAsync(CancellationToken cancellationToken)
        {

            await this.RevokeAccessAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the ID of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(string managedDiskId)
        {
            return this.WithDataFromDisk(managedDiskId);
        }

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(IDisk managedDisk)
        {
            return this.WithDataFromDisk(managedDisk);
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(string snapshotId)
        {
            return this.WithDataFromSnapshot(snapshotId);
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">A snapshot resource.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(ISnapshot snapshot)
        {
            return this.WithDataFromSnapshot(snapshot);
        }

        /// <summary>
        /// Specifies the source data VHD.
        /// </summary>
        /// <param name="vhdUrl">A source VHD URL.</param>
        /// <param name="storageAccountId">A storage account ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromVhd.WithDataFromVhd(string vhdUrl, string storageAccountId)
        {
            return this.WithDataFromVhd(vhdUrl, storageAccountId);
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(string sourceDiskId)
        {
            return this.WithLinuxFromDisk(sourceDiskId);
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(IDisk sourceDisk)
        {
            return this.WithLinuxFromDisk(sourceDisk);
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshotId);
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshot);
        }

        /// <summary>
        /// Specifies the source specialized or generalized Linux OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <param name="storageAccountId">The storage account ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromVhd(string vhdUrl, string storageAccountId)
        {
            return this.WithLinuxFromVhd(vhdUrl, storageAccountId);
        }

        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithOSSettings.WithOSType(OperatingSystemTypes osType)
        {
            return this.WithOSType(osType);
        }

        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB);
        }

        /// <summary>
        /// Specifies whether a snapshot is incremental.
        /// </summary>
        /// <param name="enabled">Whether to enable incremental snapshot</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithIncremental.WithIncremental(bool enabled)
        {
            return this.WithIncremental(enabled);
        }

        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <deprecated>Use  WithSku.withSku(SnapshotSkuType) instead.</deprecated>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithSku.WithSku(SnapshotSkuType sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <deprecated>Use  WithSku.withSku(SnapshotSkuType) instead.</deprecated>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSku.WithSku(SnapshotSkuType sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(string sourceDiskId)
        {
            return this.WithWindowsFromDisk(sourceDiskId);
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(IDisk sourceDisk)
        {
            return this.WithWindowsFromDisk(sourceDisk);
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshotId);
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshot);
        }

        /// <summary>
        /// Specifies the source specialized or generalized Windows OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <param name="storageAccountId">The storage account ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromVhd(string vhdUrl, string storageAccountId)
        {
            return this.WithWindowsFromVhd(vhdUrl, storageAccountId);
        }
    }
}