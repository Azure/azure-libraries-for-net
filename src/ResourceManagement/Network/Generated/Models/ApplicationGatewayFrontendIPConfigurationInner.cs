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
    /// Frontend IP configuration of an application gateway.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ApplicationGatewayFrontendIPConfigurationInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayFrontendIPConfigurationInner class.
        /// </summary>
        public ApplicationGatewayFrontendIPConfigurationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayFrontendIPConfigurationInner class.
        /// </summary>
        /// <param name="privateIPAddress">PrivateIPAddress of the network
        /// interface IP Configuration.</param>
        /// <param name="privateIPAllocationMethod">The private IP address
        /// allocation method. Possible values include: 'Static',
        /// 'Dynamic'</param>
        /// <param name="subnet">Reference of the subnet resource.</param>
        /// <param name="publicIPAddress">Reference of the PublicIP
        /// resource.</param>
        /// <param name="provisioningState">Provisioning state of the public IP
        /// resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.</param>
        /// <param name="name">Name of the frontend IP configuration that is
        /// unique within an Application Gateway.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        /// <param name="type">Type of the resource.</param>
        public ApplicationGatewayFrontendIPConfigurationInner(string id = default(string), string privateIPAddress = default(string), IPAllocationMethod privateIPAllocationMethod = default(IPAllocationMethod), Management.ResourceManager.Fluent.SubResource subnet = default(Management.ResourceManager.Fluent.SubResource), Management.ResourceManager.Fluent.SubResource publicIPAddress = default(Management.ResourceManager.Fluent.SubResource), string provisioningState = default(string), string name = default(string), string etag = default(string), string type = default(string))
            : base(id)
        {
            PrivateIPAddress = privateIPAddress;
            PrivateIPAllocationMethod = privateIPAllocationMethod;
            Subnet = subnet;
            PublicIPAddress = publicIPAddress;
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
        /// Gets or sets privateIPAddress of the network interface IP
        /// Configuration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Gets or sets the private IP address allocation method. Possible
        /// values include: 'Static', 'Dynamic'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAllocationMethod")]
        public IPAllocationMethod PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets or sets reference of the subnet resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public Management.ResourceManager.Fluent.SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets reference of the PublicIP resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddress")]
        public Management.ResourceManager.Fluent.SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// Gets or sets provisioning state of the public IP resource. Possible
        /// values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets name of the frontend IP configuration that is unique
        /// within an Application Gateway.
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
