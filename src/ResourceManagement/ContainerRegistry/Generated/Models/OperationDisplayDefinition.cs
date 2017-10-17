// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 2.2.27.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The display information for a container registry operation.
    /// </summary>
    public partial class OperationDisplayDefinition
    {
        /// <summary>
        /// Initializes a new instance of the OperationDisplayDefinition class.
        /// </summary>
        public OperationDisplayDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OperationDisplayDefinition class.
        /// </summary>
        /// <param name="provider">The resource provider name:
        /// Microsoft.ContainerRegistry.</param>
        /// <param name="resource">The resource on which the operation is
        /// performed.</param>
        /// <param name="operation">The operation that users can
        /// perform.</param>
        /// <param name="description">The description for the
        /// operation.</param>
        public OperationDisplayDefinition(string provider = default(string), string resource = default(string), string operation = default(string), string description = default(string))
        {
            Provider = provider;
            Resource = resource;
            Operation = operation;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the resource provider name:
        /// Microsoft.ContainerRegistry.
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the resource on which the operation is performed.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the operation that users can perform.
        /// </summary>
        [JsonProperty(PropertyName = "operation")]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the description for the operation.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
