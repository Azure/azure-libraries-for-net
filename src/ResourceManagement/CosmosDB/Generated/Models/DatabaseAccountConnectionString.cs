// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.CosmosDB;
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Connection string for the DocumentDB account
    /// </summary>
    public partial class DatabaseAccountConnectionString
    {
        /// <summary>
        /// Initializes a new instance of the DatabaseAccountConnectionString
        /// class.
        /// </summary>
        public DatabaseAccountConnectionString()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatabaseAccountConnectionString
        /// class.
        /// </summary>
        /// <param name="connectionString">Value of the connection
        /// string</param>
        /// <param name="description">Description of the connection
        /// string</param>
        public DatabaseAccountConnectionString(string connectionString = default(string), string description = default(string))
        {
            ConnectionString = connectionString;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets value of the connection string
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Gets description of the connection string
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

    }
}
