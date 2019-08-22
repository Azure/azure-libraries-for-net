// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetVM.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate : IBeta, IAppliable<IVirtualMachineScaleSetVM>
    {
        /// <summary>
        /// Attaches an existing data disk to this VMSS virtual machine.
        /// </summary>
        /// <param name="disk">the data disk, need to be in DiskState.UNATTACHED state</param>
        /// <param name="lun">the disk LUN, cannot conflict with existing LUNs</param>
        /// <param name="cachingType">the caching type</param>
        /// <returns>the next stage of the update</returns>
        IUpdate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType);

        /// <summary>
        /// Attaches an existing data disk to this VMSS virtual machine.
        /// </summary>
        /// <param name="disk">the data disk, need to be in DiskState.UNATTACHED state</param>
        /// <param name="lun">the disk LUN, cannot conflict with existing LUNs</param>
        /// <param name="cachingType">the caching type</param>
        /// <param name="storageAccountType">the storage account type</param>
        /// <returns>the next stage of the update</returns>
        IUpdate WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Detaches an existing data disk from this VMSS virtual machine.
        /// </summary>
        /// <param name="lun">the disk LUN</param>
        /// <returns>the next stage of the update</returns>
        IUpdate WithoutDataDisk(int lun);
    }
}
