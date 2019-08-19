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
    using System.Linq;

    /// <summary>
    /// Frontend port of an application gateway.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ApplicationGatewayFrontendPortInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayFrontendPortInner class.
        /// </summary>
        public ApplicationGatewayFrontendPortInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayFrontendPortInner class.
        /// </summary>
        /// <param name="port">Frontend port.</param>
        /// <param name="provisioningState">Provisioning state of the frontend
        /// port resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.</param>
        /// <param name="name">Name of the frontend port that is unique within
        /// an Application Gateway.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        /// <param name="type">Type of the resource.</param>
        public ApplicationGatewayFrontendPortInner(string id = default(string), int? port = default(int?), string provisioningState = default(string), string name = default(string), string etag = default(string), string type = default(string))
            : base(id)
        {
            Port = port;
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
        /// Gets or sets frontend port.
        /// </summary>
        [JsonProperty(PropertyName = "properties.port")]
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets provisioning state of the frontend port resource.
        /// Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets name of the frontend port that is unique within an
        /// Application Gateway.
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
        /// Gets or sets type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
