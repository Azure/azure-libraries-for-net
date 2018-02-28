// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;

    /// <summary>
    /// Entry point to SQL Server management API.
    /// </summary>
    public interface ISqlServersBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the SQL Server Database API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseOperations Databases { get; }

        /// <summary>
        /// Gets the SQL Server Elastic Pools API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPoolOperations ElasticPools { get; }

        /// <summary>
        /// Gets the SQL Server Firewall Rules API entry point.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRuleOperations FirewallRules { get; }
    }
}