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

    public partial class ManagedServiceIdentityUserAssignedIdentitiesValue
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ManagedServiceIdentityUserAssignedIdentitiesValue class.
        /// </summary>
        public ManagedServiceIdentityUserAssignedIdentitiesValue()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ManagedServiceIdentityUserAssignedIdentitiesValue class.
        /// </summary>
        /// <param name="principalId">The principal id of user assigned
        /// identity.</param>
        /// <param name="clientId">The client id of user assigned
        /// identity.</param>
        public ManagedServiceIdentityUserAssignedIdentitiesValue(string principalId = default(string), string clientId = default(string))
        {
            PrincipalId = principalId;
            ClientId = clientId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the principal id of user assigned identity.
        /// </summary>
        [JsonProperty(PropertyName = "principalId")]
        public string PrincipalId { get; private set; }

        /// <summary>
        /// Gets the client id of user assigned identity.
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; private set; }

    }
}
