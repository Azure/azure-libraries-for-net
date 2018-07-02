// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlServerDnsAliasImpl 
    {
        /// <summary>
        /// Gets name of the SQL Server to which this DNS alias belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets the fully qualified DNS record for alias.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias.AzureDnsRecord
        {
            get
            {
                return this.AzureDnsRecord();
            }
        }

        /// <summary>
        /// Deletes the DNS alias asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes the DNS alias.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerDnsAliasOperations.Definition.IWithCreate SqlServerDnsAliasOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Server DNS alias.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerDnsAliasOperations.Definition.IWithCreate SqlServerDnsAliasOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Server DNS alias.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerDnsAliasOperations.Definition.IWithCreate SqlServerDnsAliasOperations.Definition.IWithSqlServer.WithExistingSqlServerId(string sqlServerId)
        {
            return this.WithExistingSqlServerId(sqlServerId);
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}