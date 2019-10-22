// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Pool of backend IP addresses.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class BackendAddressPoolInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the BackendAddressPoolInner class.
        /// </summary>
        public BackendAddressPoolInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BackendAddressPoolInner class.
        /// </summary>
        /// <param name="backendIPConfigurations">Gets collection of references
        /// to IP addresses defined in network interfaces.</param>
        /// <param name="loadBalancingRules">Gets load balancing rules that use
        /// this backend address pool.</param>
        /// <param name="outboundRule">Gets outbound rules that use this
        /// backend address pool.</param>
        /// <param name="outboundRules">Gets outbound rules that use this
        /// backend address pool.</param>
        /// <param name="provisioningState">Get provisioning state of the
        /// public IP resource. Possible values are: 'Updating', 'Deleting',
        /// and 'Failed'.</param>
        /// <param name="name">Gets name of the resource that is unique within
        /// the set of backend address pools used by the load balancer. This
        /// name can be used to access the resource.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        /// <param name="type">Type of the resource.</param>
        public BackendAddressPoolInner(string id = default(string), IList<NetworkInterfaceIPConfigurationInner> backendIPConfigurations = default(IList<NetworkInterfaceIPConfigurationInner>), IList<Management.ResourceManager.Fluent.SubResource> loadBalancingRules = default(IList<Management.ResourceManager.Fluent.SubResource>), Management.ResourceManager.Fluent.SubResource outboundRule = default(Management.ResourceManager.Fluent.SubResource), IList<Management.ResourceManager.Fluent.SubResource> outboundRules = default(IList<Management.ResourceManager.Fluent.SubResource>), string provisioningState = default(string), string name = default(string), string etag = default(string), string type = default(string))
            : base(id)
        {
            BackendIPConfigurations = backendIPConfigurations;
            LoadBalancingRules = loadBalancingRules;
            OutboundRule = outboundRule;
            OutboundRules = outboundRules;
            ProvisioningState = provisioningState;
            Name = name;
            Etag = etag;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets collection of references to IP addresses defined in network
        /// interfaces.
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendIPConfigurations")]
        public IList<NetworkInterfaceIPConfigurationInner> BackendIPConfigurations { get; private set; }

        /// <summary>
        /// Gets load balancing rules that use this backend address pool.
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancingRules")]
        public IList<Management.ResourceManager.Fluent.SubResource> LoadBalancingRules { get; private set; }

        /// <summary>
        /// Gets outbound rules that use this backend address pool.
        /// </summary>
        [JsonProperty(PropertyName = "properties.outboundRule")]
        public Management.ResourceManager.Fluent.SubResource OutboundRule { get; private set; }

        /// <summary>
        /// Gets outbound rules that use this backend address pool.
        /// </summary>
        [JsonProperty(PropertyName = "properties.outboundRules")]
        public IList<Management.ResourceManager.Fluent.SubResource> OutboundRules { get; private set; }

        /// <summary>
        /// Gets or sets get provisioning state of the public IP resource.
        /// Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets name of the resource that is unique within the set of backend
        /// address pools used by the load balancer. This name can be used to
        /// access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a unique read-only string that changes whenever the
        /// resource is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

    }
}
