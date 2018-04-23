// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Batch.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Data Disk settings which will be used by the data disks associated to
    /// Compute Nodes in the pool.
    /// </summary>
    public partial class DataDisk
    {
        /// <summary>
        /// Initializes a new instance of the DataDisk class.
        /// </summary>
        public DataDisk()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DataDisk class.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <param name="diskSizeGB">The initial disk size in GB when creating
        /// new data disk.</param>
        /// <param name="caching">The type of caching to be enabled for the
        /// data disks.</param>
        /// <param name="storageAccountType">The storage account type to be
        /// used for the data disk.</param>
        public DataDisk(int lun, int diskSizeGB, CachingType? caching = default(CachingType?), StorageAccountType? storageAccountType = default(StorageAccountType?))
        {
            Lun = lun;
            Caching = caching;
            DiskSizeGB = diskSizeGB;
            StorageAccountType = storageAccountType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the logical unit number.
        /// </summary>
        /// <remarks>
        /// The lun is used to uniquely identify each data disk. If attaching
        /// multiple disks, each should have a distinct lun.
        /// </remarks>
        [JsonProperty(PropertyName = "lun")]
        public int Lun { get; set; }

        /// <summary>
        /// Gets or sets the type of caching to be enabled for the data disks.
        /// </summary>
        /// <remarks>
        /// Values are:
        ///
        /// none - The caching mode for the disk is not enabled.
        /// readOnly - The caching mode for the disk is read only.
        /// readWrite - The caching mode for the disk is read and write.
        ///
        /// The default value for caching is none. For information about the
        /// caching options see:
        /// https://blogs.msdn.microsoft.com/windowsazurestorage/2012/06/27/exploring-windows-azure-drives-disks-and-images/.
        /// Possible values include: 'None', 'ReadOnly', 'ReadWrite'
        /// </remarks>
        [JsonProperty(PropertyName = "caching")]
        public CachingType? Caching { get; set; }

        /// <summary>
        /// Gets or sets the initial disk size in GB when creating new data
        /// disk.
        /// </summary>
        [JsonProperty(PropertyName = "diskSizeGB")]
        public int DiskSizeGB { get; set; }

        /// <summary>
        /// Gets or sets the storage account type to be used for the data disk.
        /// </summary>
        /// <remarks>
        /// If omitted, the default is "Standard_LRS". Values are:
        ///
        /// Standard_LRS - The data disk should use standard locally redundant
        /// storage.
        /// Premium_LRS - The data disk should use premium locally redundant
        /// storage. Possible values include: 'Standard_LRS', 'Premium_LRS'
        /// </remarks>
        [JsonProperty(PropertyName = "storageAccountType")]
        public StorageAccountType? StorageAccountType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
