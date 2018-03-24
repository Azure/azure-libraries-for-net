// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;

    /// <summary>
    /// A representation of the Azure SQL Server DNS alias operations.
    /// </summary>
    public interface ISqlServerDnsAliasOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlServerDnsAliasOperations.Definition.IWithSqlServer>,
        Microsoft.Azure.Management.Sql.Fluent.ISqlChildrenOperations<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>
    {
        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server that the alias is pointing to.</param>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task AcquireAsync(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="oldSqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <param name="newSqlServerId">The id of the server that the alias is pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task AcquireAsync(string dnsAliasName, string oldSqlServerId, string newSqlServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group that contains the resource.</param>
        /// <param name="serverName">The name of the server that the alias is pointing to.</param>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        void Acquire(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId);

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="oldSqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <param name="newSqlServerId">The id of the server that the alias is pointing to.</param>
        void Acquire(string dnsAliasName, string oldSqlServerId, string newSqlServerId);
    }
}