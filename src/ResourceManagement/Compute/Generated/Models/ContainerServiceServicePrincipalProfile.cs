// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Information about a service principal identity for the cluster to use
    /// for manipulating Azure APIs.
    /// </summary>
    public partial class ContainerServiceServicePrincipalProfile
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ContainerServiceServicePrincipalProfile class.
        /// </summary>
        public ContainerServiceServicePrincipalProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ContainerServiceServicePrincipalProfile class.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <param name="secret">The secret password associated with the
        /// service principal.</param>
        public ContainerServiceServicePrincipalProfile(string clientId, string secret)
        {
            ClientId = clientId;
            Secret = secret;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID for the service principal.
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret password associated with the service
        /// principal.
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ClientId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ClientId");
            }
            if (Secret == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Secret");
            }
        }
    }
}
