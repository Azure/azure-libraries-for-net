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
    /// HubVirtualNetworkConnection Resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class HubVirtualNetworkConnectionInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the HubVirtualNetworkConnectionInner
        /// class.
        /// </summary>
        public HubVirtualNetworkConnectionInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HubVirtualNetworkConnectionInner
        /// class.
        /// </summary>
        /// <param name="remoteVirtualNetwork">Reference to the remote virtual
        /// network.</param>
        /// <param name="allowHubToRemoteVnetTransit">VirtualHub to RemoteVnet
        /// transit to enabled or not.</param>
        /// <param name="allowRemoteVnetToUseHubVnetGateways">Allow RemoteVnet
        /// to use Virtual Hub's gateways.</param>
        /// <param name="enableInternetSecurity">Enable internet
        /// security.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'</param>
        /// <param name="name">The name of the resource that is unique within a
        /// resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">Gets a unique read-only string that changes
        /// whenever the resource is updated.</param>
        public HubVirtualNetworkConnectionInner(string id = default(string), Management.ResourceManager.Fluent.SubResource remoteVirtualNetwork = default(Management.ResourceManager.Fluent.SubResource), bool? allowHubToRemoteVnetTransit = default(bool?), bool? allowRemoteVnetToUseHubVnetGateways = default(bool?), bool? enableInternetSecurity = default(bool?), ProvisioningState provisioningState = default(ProvisioningState), string name = default(string), string etag = default(string))
            : base(id)
        {
            RemoteVirtualNetwork = remoteVirtualNetwork;
            AllowHubToRemoteVnetTransit = allowHubToRemoteVnetTransit;
            AllowRemoteVnetToUseHubVnetGateways = allowRemoteVnetToUseHubVnetGateways;
            EnableInternetSecurity = enableInternetSecurity;
            ProvisioningState = provisioningState;
            Name = name;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets reference to the remote virtual network.
        /// </summary>
        [JsonProperty(PropertyName = "properties.remoteVirtualNetwork")]
        public Management.ResourceManager.Fluent.SubResource RemoteVirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets virtualHub to RemoteVnet transit to enabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowHubToRemoteVnetTransit")]
        public bool? AllowHubToRemoteVnetTransit { get; set; }

        /// <summary>
        /// Gets or sets allow RemoteVnet to use Virtual Hub's gateways.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowRemoteVnetToUseHubVnetGateways")]
        public bool? AllowRemoteVnetToUseHubVnetGateways { get; set; }

        /// <summary>
        /// Gets or sets enable internet security.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableInternetSecurity")]
        public bool? EnableInternetSecurity { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the resource. Possible
        /// values include: 'Succeeded', 'Updating', 'Deleting', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource that is unique within a
        /// resource group. This name can be used to access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

    }
}
