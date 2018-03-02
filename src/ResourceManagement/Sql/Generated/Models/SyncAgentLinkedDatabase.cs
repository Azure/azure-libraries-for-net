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
    /// An Azure SQL Database sync agent linked database.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class SyncAgentLinkedDatabase : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the SyncAgentLinkedDatabase class.
        /// </summary>
        public SyncAgentLinkedDatabase()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SyncAgentLinkedDatabase class.
        /// </summary>
        /// <param name="databaseType">Type of the sync agent linked database.
        /// Possible values include: 'AzureSqlDatabase',
        /// 'SqlServerDatabase'</param>
        /// <param name="databaseId">Id of the sync agent linked
        /// database.</param>
        /// <param name="description">Description of the sync agent linked
        /// database.</param>
        /// <param name="serverName">Server name of the sync agent linked
        /// database.</param>
        /// <param name="databaseName">Database name of the sync agent linked
        /// database.</param>
        /// <param name="userName">User name of the sync agent linked
        /// database.</param>
        public SyncAgentLinkedDatabase(string id = default(string), string name = default(string), string type = default(string), string databaseType = default(string), string databaseId = default(string), string description = default(string), string serverName = default(string), string databaseName = default(string), string userName = default(string))
            : base(id, name, type)
        {
            DatabaseType = databaseType;
            DatabaseId = databaseId;
            Description = description;
            ServerName = serverName;
            DatabaseName = databaseName;
            UserName = userName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets type of the sync agent linked database. Possible values
        /// include: 'AzureSqlDatabase', 'SqlServerDatabase'
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseType")]
        public string DatabaseType { get; private set; }

        /// <summary>
        /// Gets id of the sync agent linked database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseId")]
        public string DatabaseId { get; private set; }

        /// <summary>
        /// Gets description of the sync agent linked database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets server name of the sync agent linked database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.serverName")]
        public string ServerName { get; private set; }

        /// <summary>
        /// Gets database name of the sync agent linked database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseName")]
        public string DatabaseName { get; private set; }

        /// <summary>
        /// Gets user name of the sync agent linked database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.userName")]
        public string UserName { get; private set; }

    }
}
