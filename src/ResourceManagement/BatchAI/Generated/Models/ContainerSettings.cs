// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Settings for the container to be downloaded.
    /// </summary>
    public partial class ContainerSettings
    {
        /// <summary>
        /// Initializes a new instance of the ContainerSettings class.
        /// </summary>
        public ContainerSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ContainerSettings class.
        /// </summary>
        /// <param name="imageSourceRegistry">Registry to download the
        /// container from.</param>
        public ContainerSettings(ImageSourceRegistry imageSourceRegistry)
        {
            ImageSourceRegistry = imageSourceRegistry;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets registry to download the container from.
        /// </summary>
        [JsonProperty(PropertyName = "imageSourceRegistry")]
        public ImageSourceRegistry ImageSourceRegistry { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ImageSourceRegistry == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ImageSourceRegistry");
            }
            if (ImageSourceRegistry != null)
            {
                ImageSourceRegistry.Validate();
            }
        }
    }
}
