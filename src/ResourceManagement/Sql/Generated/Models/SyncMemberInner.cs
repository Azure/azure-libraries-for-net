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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An Azure SQL Database sync member.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class SyncMemberInner : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the SyncMemberInner class.
        /// </summary>
        public SyncMemberInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SyncMemberInner class.
        /// </summary>
        /// <param name="databaseType">Database type of the sync member.
        /// Possible values include: 'AzureSqlDatabase',
        /// 'SqlServerDatabase'</param>
        /// <param name="syncAgentId">ARM resource id of the sync agent in the
        /// sync member.</param>
        /// <param name="sqlServerDatabaseId">SQL Server database id of the
        /// sync member.</param>
        /// <param name="serverName">Server name of the member database in the
        /// sync member</param>
        /// <param name="databaseName">Database name of the member database in
        /// the sync member.</param>
        /// <param name="userName">User name of the member database in the sync
        /// member.</param>
        /// <param name="password">Password of the member database in the sync
        /// member.</param>
        /// <param name="syncDirection">Sync direction of the sync member.
        /// Possible values include: 'Bidirectional', 'OneWayMemberToHub',
        /// 'OneWayHubToMember'</param>
        /// <param name="syncState">Sync state of the sync member. Possible
        /// values include: 'SyncInProgress', 'SyncSucceeded', 'SyncFailed',
        /// 'DisabledTombstoneCleanup', 'DisabledBackupRestore',
        /// 'SyncSucceededWithWarnings', 'SyncCancelling', 'SyncCancelled',
        /// 'UnProvisioned', 'Provisioning', 'Provisioned', 'ProvisionFailed',
        /// 'DeProvisioning', 'DeProvisioned', 'DeProvisionFailed',
        /// 'Reprovisioning', 'ReprovisionFailed', 'UnReprovisioned'</param>
        public SyncMemberInner(string id = default(string), string name = default(string), string type = default(string), string databaseType = default(string), string syncAgentId = default(string), System.Guid? sqlServerDatabaseId = default(System.Guid?), string serverName = default(string), string databaseName = default(string), string userName = default(string), string password = default(string), string syncDirection = default(string), string syncState = default(string))
            : base(id, name, type)
        {
            DatabaseType = databaseType;
            SyncAgentId = syncAgentId;
            SqlServerDatabaseId = sqlServerDatabaseId;
            ServerName = serverName;
            DatabaseName = databaseName;
            UserName = userName;
            Password = password;
            SyncDirection = syncDirection;
            SyncState = syncState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets database type of the sync member. Possible values
        /// include: 'AzureSqlDatabase', 'SqlServerDatabase'
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseType")]
        public string DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets ARM resource id of the sync agent in the sync member.
        /// </summary>
        [JsonProperty(PropertyName = "properties.syncAgentId")]
        public string SyncAgentId { get; set; }

        /// <summary>
        /// Gets or sets SQL Server database id of the sync member.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sqlServerDatabaseId")]
        public System.Guid? SqlServerDatabaseId { get; set; }

        /// <summary>
        /// Gets or sets server name of the member database in the sync member
        /// </summary>
        [JsonProperty(PropertyName = "properties.serverName")]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets database name of the member database in the sync
        /// member.
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseName")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets user name of the member database in the sync member.
        /// </summary>
        [JsonProperty(PropertyName = "properties.userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets password of the member database in the sync member.
        /// </summary>
        [JsonProperty(PropertyName = "properties.password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets sync direction of the sync member. Possible values
        /// include: 'Bidirectional', 'OneWayMemberToHub', 'OneWayHubToMember'
        /// </summary>
        [JsonProperty(PropertyName = "properties.syncDirection")]
        public string SyncDirection { get; set; }

        /// <summary>
        /// Gets sync state of the sync member. Possible values include:
        /// 'SyncInProgress', 'SyncSucceeded', 'SyncFailed',
        /// 'DisabledTombstoneCleanup', 'DisabledBackupRestore',
        /// 'SyncSucceededWithWarnings', 'SyncCancelling', 'SyncCancelled',
        /// 'UnProvisioned', 'Provisioning', 'Provisioned', 'ProvisionFailed',
        /// 'DeProvisioning', 'DeProvisioned', 'DeProvisionFailed',
        /// 'Reprovisioning', 'ReprovisionFailed', 'UnReprovisioned'
        /// </summary>
        [JsonProperty(PropertyName = "properties.syncState")]
        public string SyncState { get; private set; }

    }
}
