// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Reference to an express route circuit.
    /// </summary>
    public partial class ExpressRouteCircuitReference
    {
        /// <summary>
        /// Initializes a new instance of the ExpressRouteCircuitReference
        /// class.
        /// </summary>
        public ExpressRouteCircuitReference()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ExpressRouteCircuitReference
        /// class.
        /// </summary>
        /// <param name="id">Corresponding Express Route Circuit Id.</param>
        public ExpressRouteCircuitReference(string id = default(string))
        {
            Id = id;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets corresponding Express Route Circuit Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
