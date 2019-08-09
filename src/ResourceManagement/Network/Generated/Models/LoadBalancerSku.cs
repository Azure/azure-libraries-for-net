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
    /// SKU of a load balancer.
    /// </summary>
    public partial class LoadBalancerSku
    {
        /// <summary>
        /// Initializes a new instance of the LoadBalancerSku class.
        /// </summary>
        public LoadBalancerSku()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LoadBalancerSku class.
        /// </summary>
        /// <param name="name">Name of a load balancer SKU. Possible values
        /// include: 'Basic', 'Standard'</param>
        public LoadBalancerSku(LoadBalancerSkuName name = default(LoadBalancerSkuName))
        {
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of a load balancer SKU. Possible values include:
        /// 'Basic', 'Standard'
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public LoadBalancerSkuName Name { get; set; }

    }
}
