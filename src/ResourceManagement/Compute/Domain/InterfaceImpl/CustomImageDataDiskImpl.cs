// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    internal partial class CustomImageDataDiskImpl
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.FromManagedDisk(string sourceManagedDiskId)
        {
            return this.FromManagedDisk(sourceManagedDiskId);
        }

        /// <summary>
        /// Specifies the source managed disk for the data disk image.
        /// </summary>
        /// <param name="sourceManagedDisk">Source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.FromManagedDisk(IDisk sourceManagedDisk)
        {
            return this.FromManagedDisk(sourceManagedDisk);
        }

        /// <summary>
        /// Specifies the source snapshot for the data disk image.
        /// </summary>
        /// <param name="sourceSnapshotId">Source snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.FromSnapshot(string sourceSnapshotId)
        {
            return this.FromSnapshot(sourceSnapshotId);
        }

        /// <summary>
        /// Specifies the source VHD for the data disk image.
        /// </summary>
        /// <param name="sourceVhdUrl">Source virtual hard disk URL.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.FromVhd(string sourceVhdUrl)
        {
            return this.FromVhd(sourceVhdUrl);
        }

        /// <summary>
        /// Specifies the caching type for data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskSettings<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.WithDiskCaching(CachingTypes cachingType)
        {
            return this.WithDiskCaching(cachingType);
        }

        /// <summary>
        /// Specifies the size in GB for data disk.
        /// </summary>
        /// <param name="diskSizeGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithAttach<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskSettings<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.WithDiskSizeInGB(int diskSizeGB)
        {
            return this.WithDiskSizeInGB(diskSizeGB);
        }

        /// <summary>
        /// Specifies the LUN for the data disk to be created from the disk image.
        /// </summary>
        /// <param name="lun">The unique LUN for the data disk.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithImageSource<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings> VirtualMachineCustomImage.CustomImageDataDisk.Definition.IWithDiskLun<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>.WithLun(int lun)
        {
            return this.WithLun(lun);
        }
    }
}