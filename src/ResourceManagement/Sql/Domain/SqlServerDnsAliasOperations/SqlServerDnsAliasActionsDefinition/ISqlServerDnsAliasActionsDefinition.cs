// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;

    /// <summary>
    /// Grouping of the Azure SQL Server DNS alias common actions.
    /// </summary>
    public interface ISqlServerDnsAliasActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition.ISqlChildrenActionsDefinition<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>
    {
        /// <summary>
        /// Acquires server DNS alias from another server asynchronously.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task AcquireAsync(string dnsAliasName, string sqlServerId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Begins the definition of a new SQL Server DNS alias to be added to this server.
        /// </summary>
        /// <param name="serverDnsAliasName">The name of the new DNS alias to be created for the selected SQL server.</param>
        /// <return>The first stage of the new SQL Server DNS alias definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition.IWithCreate Define(string serverDnsAliasName);

        /// <summary>
        /// Acquires server DNS alias from another server.
        /// </summary>
        /// <param name="dnsAliasName">The name of the Server DNS alias.</param>
        /// <param name="sqlServerId">The id of the other SQL server that the DNS alias was pointing to.</param>
        void Acquire(string dnsAliasName, string sqlServerId);
    }
}