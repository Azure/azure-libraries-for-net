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
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters supplied to the Update operation.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ClusterUpdateParametersInner
    {
        /// <summary>
        /// Initializes a new instance of the ClusterUpdateParametersInner
        /// class.
        /// </summary>
        public ClusterUpdateParametersInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClusterUpdateParametersInner
        /// class.
        /// </summary>
        /// <param name="tags">The user specified tags associated with the
        /// Cluster.</param>
        /// <param name="scaleSettings">Desired scale for the cluster</param>
        public ClusterUpdateParametersInner(IDictionary<string, string> tags = default(IDictionary<string, string>), ScaleSettings scaleSettings = default(ScaleSettings))
        {
            Tags = tags;
            ScaleSettings = scaleSettings;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the user specified tags associated with the Cluster.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets desired scale for the cluster
        /// </summary>
        [JsonProperty(PropertyName = "properties.scaleSettings")]
        public ScaleSettings ScaleSettings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ScaleSettings != null)
            {
                ScaleSettings.Validate();
            }
        }
    }
}
