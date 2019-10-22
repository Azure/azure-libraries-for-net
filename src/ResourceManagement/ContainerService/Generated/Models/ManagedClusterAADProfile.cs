// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// AADProfile specifies attributes for Azure Active Directory integration.
    /// </summary>
    public partial class ManagedClusterAADProfile
    {
        /// <summary>
        /// Initializes a new instance of the ManagedClusterAADProfile class.
        /// </summary>
        public ManagedClusterAADProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ManagedClusterAADProfile class.
        /// </summary>
        /// <param name="clientAppID">The client AAD application ID.</param>
        /// <param name="serverAppID">The server AAD application ID.</param>
        /// <param name="serverAppSecret">The server AAD application
        /// secret.</param>
        /// <param name="tenantID">The AAD tenant ID to use for authentication.
        /// If not specified, will use the tenant of the deployment
        /// subscription.</param>
        public ManagedClusterAADProfile(string clientAppID, string serverAppID, string serverAppSecret = default(string), string tenantID = default(string))
        {
            ClientAppID = clientAppID;
            ServerAppID = serverAppID;
            ServerAppSecret = serverAppSecret;
            TenantID = tenantID;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the client AAD application ID.
        /// </summary>
        [JsonProperty(PropertyName = "clientAppID")]
        public string ClientAppID { get; set; }

        /// <summary>
        /// Gets or sets the server AAD application ID.
        /// </summary>
        [JsonProperty(PropertyName = "serverAppID")]
        public string ServerAppID { get; set; }

        /// <summary>
        /// Gets or sets the server AAD application secret.
        /// </summary>
        [JsonProperty(PropertyName = "serverAppSecret")]
        public string ServerAppSecret { get; set; }

        /// <summary>
        /// Gets or sets the AAD tenant ID to use for authentication. If not
        /// specified, will use the tenant of the deployment subscription.
        /// </summary>
        [JsonProperty(PropertyName = "tenantID")]
        public string TenantID { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ClientAppID == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ClientAppID");
            }
            if (ServerAppID == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ServerAppID");
            }
        }
    }
}
