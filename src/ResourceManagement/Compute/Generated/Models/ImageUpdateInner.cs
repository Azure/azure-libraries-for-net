// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The source user image virtual hard disk. The virtual hard disk will be
    /// copied before being attached to the virtual machine. If SourceImage is
    /// provided, the destination virtual hard drive must not exist.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ImageUpdateInner : UpdateResource
    {
        /// <summary>
        /// Initializes a new instance of the ImageUpdateInner class.
        /// </summary>
        public ImageUpdateInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ImageUpdateInner class.
        /// </summary>
        /// <param name="tags">Resource tags</param>
        /// <param name="sourceVirtualMachine">The source virtual machine from
        /// which Image is created.</param>
        /// <param name="storageProfile">Specifies the storage settings for the
        /// virtual machine disks.</param>
        /// <param name="provisioningState">The provisioning state.</param>
        public ImageUpdateInner(IDictionary<string, string> tags = default(IDictionary<string, string>), ResourceManager.Fluent.SubResource sourceVirtualMachine = default(ResourceManager.Fluent.SubResource), ImageStorageProfile storageProfile = default(ImageStorageProfile), string provisioningState = default(string))
            : base(tags)
        {
            SourceVirtualMachine = sourceVirtualMachine;
            StorageProfile = storageProfile;
            ProvisioningState = provisioningState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the source virtual machine from which Image is
        /// created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sourceVirtualMachine")]
        public ResourceManager.Fluent.SubResource SourceVirtualMachine { get; set; }

        /// <summary>
        /// Gets or sets specifies the storage settings for the virtual machine
        /// disks.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageProfile")]
        public ImageStorageProfile StorageProfile { get; set; }

        /// <summary>
        /// Gets the provisioning state.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (StorageProfile != null)
            {
                StorageProfile.Validate();
            }
        }
    }
}
