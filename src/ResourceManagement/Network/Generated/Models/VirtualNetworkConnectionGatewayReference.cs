// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A reference to VirtualNetworkGateway or LocalNetworkGateway resource.
    /// </summary>
    public partial class VirtualNetworkConnectionGatewayReference
    {
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualNetworkConnectionGatewayReference class.
        /// </summary>
        public VirtualNetworkConnectionGatewayReference()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualNetworkConnectionGatewayReference class.
        /// </summary>
        /// <param name="id">The ID of VirtualNetworkGateway or
        /// LocalNetworkGateway resource.</param>
        public VirtualNetworkConnectionGatewayReference(string id)
        {
            Id = id;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of VirtualNetworkGateway or LocalNetworkGateway
        /// resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }
    }
}
