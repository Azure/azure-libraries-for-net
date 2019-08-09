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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Details of PrepareNetworkPolicies for Subnet.
    /// </summary>
    public partial class PrepareNetworkPoliciesRequest
    {
        /// <summary>
        /// Initializes a new instance of the PrepareNetworkPoliciesRequest
        /// class.
        /// </summary>
        public PrepareNetworkPoliciesRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrepareNetworkPoliciesRequest
        /// class.
        /// </summary>
        /// <param name="serviceName">The name of the service for which subnet
        /// is being prepared for.</param>
        /// <param name="networkIntentPolicyConfigurations">A list of
        /// NetworkIntentPolicyConfiguration.</param>
        public PrepareNetworkPoliciesRequest(string serviceName = default(string), IList<NetworkIntentPolicyConfiguration> networkIntentPolicyConfigurations = default(IList<NetworkIntentPolicyConfiguration>))
        {
            ServiceName = serviceName;
            NetworkIntentPolicyConfigurations = networkIntentPolicyConfigurations;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the service for which subnet is being
        /// prepared for.
        /// </summary>
        [JsonProperty(PropertyName = "serviceName")]
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets a list of NetworkIntentPolicyConfiguration.
        /// </summary>
        [JsonProperty(PropertyName = "networkIntentPolicyConfigurations")]
        public IList<NetworkIntentPolicyConfiguration> NetworkIntentPolicyConfigurations { get; set; }

    }
}
