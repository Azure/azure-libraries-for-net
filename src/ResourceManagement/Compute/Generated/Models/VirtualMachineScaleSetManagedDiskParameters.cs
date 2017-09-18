// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes the parameters of a ScaleSet managed disk.
    /// </summary>
    public partial class VirtualMachineScaleSetManagedDiskParameters
    {
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetManagedDiskParameters class.
        /// </summary>
        public VirtualMachineScaleSetManagedDiskParameters()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetManagedDiskParameters class.
        /// </summary>
        /// <param name="storageAccountType">Specifies the storage account type
        /// for the managed disk. Possible values are: Standard_LRS or
        /// Premium_LRS. Possible values include: 'Standard_LRS',
        /// 'Premium_LRS'</param>
        public VirtualMachineScaleSetManagedDiskParameters(StorageAccountTypes? storageAccountType = default(StorageAccountTypes?))
        {
            StorageAccountType = storageAccountType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets specifies the storage account type for the managed
        /// disk. Possible values are: Standard_LRS or Premium_LRS. Possible
        /// values include: 'Standard_LRS', 'Premium_LRS'
        /// </summary>
        [JsonProperty(PropertyName = "storageAccountType")]
        public StorageAccountTypes? StorageAccountType { get; set; }

    }
}
