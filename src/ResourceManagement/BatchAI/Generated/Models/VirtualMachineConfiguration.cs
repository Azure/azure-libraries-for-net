// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// VM configuration.
    /// </summary>
    public partial class VirtualMachineConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineConfiguration
        /// class.
        /// </summary>
        public VirtualMachineConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineConfiguration
        /// class.
        /// </summary>
        /// <param name="imageReference">Image reference.</param>
        public VirtualMachineConfiguration(ImageReference imageReference = default(ImageReference))
        {
            ImageReference = imageReference;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets image reference.
        /// </summary>
        /// <remarks>
        /// OS image reference for cluster nodes.
        /// </remarks>
        [JsonProperty(PropertyName = "imageReference")]
        public ImageReference ImageReference { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ImageReference != null)
            {
                ImageReference.Validate();
            }
        }
    }
}
