// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Storage.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An update history of the ImmutabilityPolicy of a blob container.
    /// </summary>
    public partial class UpdateHistoryProperty
    {
        /// <summary>
        /// Initializes a new instance of the UpdateHistoryProperty class.
        /// </summary>
        public UpdateHistoryProperty()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UpdateHistoryProperty class.
        /// </summary>
        /// <param name="update">The ImmutabilityPolicy update type of a blob
        /// container, possible values include: put, lock and extend. Possible
        /// values include: 'put', 'lock', 'extend'</param>
        /// <param name="immutabilityPeriodSinceCreationInDays">The
        /// immutability period for the blobs in the container since the policy
        /// creation, in days.</param>
        /// <param name="timestamp">Returns the date and time the
        /// ImmutabilityPolicy was updated.</param>
        /// <param name="objectIdentifier">Returns the Object ID of the user
        /// who updated the ImmutabilityPolicy.</param>
        /// <param name="tenantId">Returns the Tenant ID that issued the token
        /// for the user who updated the ImmutabilityPolicy.</param>
        /// <param name="upn">Returns the User Principal Name of the user who
        /// updated the ImmutabilityPolicy.</param>
        public UpdateHistoryProperty(string update = default(string), int? immutabilityPeriodSinceCreationInDays = default(int?), System.DateTime? timestamp = default(System.DateTime?), string objectIdentifier = default(string), string tenantId = default(string), string upn = default(string))
        {
            Update = update;
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            Timestamp = timestamp;
            ObjectIdentifier = objectIdentifier;
            TenantId = tenantId;
            Upn = upn;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the ImmutabilityPolicy update type of a blob container,
        /// possible values include: put, lock and extend. Possible values
        /// include: 'put', 'lock', 'extend'
        /// </summary>
        [JsonProperty(PropertyName = "update")]
        public string Update { get; private set; }

        /// <summary>
        /// Gets the immutability period for the blobs in the container since
        /// the policy creation, in days.
        /// </summary>
        [JsonProperty(PropertyName = "immutabilityPeriodSinceCreationInDays")]
        public int? ImmutabilityPeriodSinceCreationInDays { get; private set; }

        /// <summary>
        /// Gets returns the date and time the ImmutabilityPolicy was updated.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public System.DateTime? Timestamp { get; private set; }

        /// <summary>
        /// Gets returns the Object ID of the user who updated the
        /// ImmutabilityPolicy.
        /// </summary>
        [JsonProperty(PropertyName = "objectIdentifier")]
        public string ObjectIdentifier { get; private set; }

        /// <summary>
        /// Gets returns the Tenant ID that issued the token for the user who
        /// updated the ImmutabilityPolicy.
        /// </summary>
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; private set; }

        /// <summary>
        /// Gets returns the User Principal Name of the user who updated the
        /// ImmutabilityPolicy.
        /// </summary>
        [JsonProperty(PropertyName = "upn")]
        public string Upn { get; private set; }

    }
}
