// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An Azure SQL Database sync agent.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class SyncAgentInner : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the SyncAgentInner class.
        /// </summary>
        public SyncAgentInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SyncAgentInner class.
        /// </summary>
        /// <param name="syncAgentName">Name of the sync agent.</param>
        /// <param name="syncDatabaseId">ARM resource id of the sync database
        /// in the sync agent.</param>
        /// <param name="lastAliveTime">Last alive time of the sync
        /// agent.</param>
        /// <param name="state">State of the sync agent. Possible values
        /// include: 'Online', 'Offline', 'NeverConnected'</param>
        /// <param name="isUpToDate">If the sync agent version is up to
        /// date.</param>
        /// <param name="expiryTime">Expiration time of the sync agent
        /// version.</param>
        /// <param name="version">Version of the sync agent.</param>
        public SyncAgentInner(string id = default(string), string name = default(string), string type = default(string), string syncAgentName = default(string), string syncDatabaseId = default(string), System.DateTime? lastAliveTime = default(System.DateTime?), SyncAgentState state = default(SyncAgentState), bool? isUpToDate = default(bool?), System.DateTime? expiryTime = default(System.DateTime?), string version = default(string))
            : base(id, name, type)
        {
            SyncAgentName = syncAgentName;
            SyncDatabaseId = syncDatabaseId;
            LastAliveTime = lastAliveTime;
            State = state;
            IsUpToDate = isUpToDate;
            ExpiryTime = expiryTime;
            Version = version;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets name of the sync agent.
        /// </summary>
        [JsonProperty(PropertyName = "properties.name")]
        public string SyncAgentName { get; private set; }

        /// <summary>
        /// Gets or sets ARM resource id of the sync database in the sync
        /// agent.
        /// </summary>
        [JsonProperty(PropertyName = "properties.syncDatabaseId")]
        public string SyncDatabaseId { get; set; }

        /// <summary>
        /// Gets last alive time of the sync agent.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastAliveTime")]
        public System.DateTime? LastAliveTime { get; private set; }

        /// <summary>
        /// Gets state of the sync agent. Possible values include: 'Online',
        /// 'Offline', 'NeverConnected'
        /// </summary>
        [JsonProperty(PropertyName = "properties.state")]
        public SyncAgentState State { get; private set; }

        /// <summary>
        /// Gets if the sync agent version is up to date.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isUpToDate")]
        public bool? IsUpToDate { get; private set; }

        /// <summary>
        /// Gets expiration time of the sync agent version.
        /// </summary>
        [JsonProperty(PropertyName = "properties.expiryTime")]
        public System.DateTime? ExpiryTime { get; private set; }

        /// <summary>
        /// Gets version of the sync agent.
        /// </summary>
        [JsonProperty(PropertyName = "properties.version")]
        public string Version { get; private set; }

    }
}
