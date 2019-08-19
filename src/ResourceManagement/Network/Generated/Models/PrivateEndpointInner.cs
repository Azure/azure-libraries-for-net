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
    /// Private endpoint resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PrivateEndpointInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the PrivateEndpointInner class.
        /// </summary>
        public PrivateEndpointInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateEndpointInner class.
        /// </summary>
        /// <param name="subnet">The ID of the subnet from which the private IP
        /// will be allocated.</param>
        /// <param name="networkInterfaces">Gets an array of references to the
        /// network interfaces created for this private endpoint.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// private endpoint. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.</param>
        /// <param name="privateLinkServiceConnections">A grouping of
        /// information about the connection to the remote resource.</param>
        /// <param name="manualPrivateLinkServiceConnections">A grouping of
        /// information about the connection to the remote resource. Used when
        /// the network admin does not have access to approve connections to
        /// the remote resource.</param>
        /// <param name="etag">Gets a unique read-only string that changes
        /// whenever the resource is updated.</param>
        public PrivateEndpointInner(string location = default(string), string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Management.ResourceManager.Fluent.SubResource subnet = default(Management.ResourceManager.Fluent.SubResource), IList<NetworkInterfaceInner> networkInterfaces = default(IList<NetworkInterfaceInner>), string provisioningState = default(string), IList<PrivateLinkServiceConnectionInner> privateLinkServiceConnections = default(IList<PrivateLinkServiceConnectionInner>), IList<PrivateLinkServiceConnectionInner> manualPrivateLinkServiceConnections = default(IList<PrivateLinkServiceConnectionInner>), string etag = default(string))
            : base(location, id, name, type, tags)
        {
            Subnet = subnet;
            NetworkInterfaces = networkInterfaces;
            ProvisioningState = provisioningState;
            PrivateLinkServiceConnections = privateLinkServiceConnections;
            ManualPrivateLinkServiceConnections = manualPrivateLinkServiceConnections;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of the subnet from which the private IP will be
        /// allocated.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public Management.ResourceManager.Fluent.SubResource Subnet { get; set; }

        /// <summary>
        /// Gets an array of references to the network interfaces created for
        /// this private endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkInterfaces")]
        public IList<NetworkInterfaceInner> NetworkInterfaces { get; private set; }

        /// <summary>
        /// Gets the provisioning state of the private endpoint. Possible
        /// values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets a grouping of information about the connection to the
        /// remote resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateLinkServiceConnections")]
        public IList<PrivateLinkServiceConnectionInner> PrivateLinkServiceConnections { get; set; }

        /// <summary>
        /// Gets or sets a grouping of information about the connection to the
        /// remote resource. Used when the network admin does not have access
        /// to approve connections to the remote resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.manualPrivateLinkServiceConnections")]
        public IList<PrivateLinkServiceConnectionInner> ManualPrivateLinkServiceConnections { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NetworkInterfaces != null)
            {
                foreach (var element in NetworkInterfaces)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
