// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of the SQL Failover Group definition.
    /// </summary>
    public interface IWithSqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location);

        /// <summary>
        /// Sets the parent SQL server for the new Failover Group.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy WithExistingSqlServer(ISqlServer sqlServer);
    }

    /// <summary>
    /// The SQL Failover Group definition to set the read-write endpoint failover policy.
    /// </summary>
    public interface IWithReadWriteEndpointPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Automatic".
        /// </summary>
        /// <param name="gracePeriodInMinutes">The grace period before failover with data loss is attempted for the read-write endpoint.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithPartnerServer WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(int gracePeriodInMinutes);

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Manual".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithPartnerServer WithManualReadWriteEndpointPolicy();
    }

    /// <summary>
    /// The SQL Failover Group definition to set the partner servers.
    /// </summary>
    public interface IWithPartnerServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate
    {
        /// <summary>
        /// Sets the SQL Failover Group partner server.
        /// </summary>
        /// <param name="id">The ID of the partner SQL server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithPartnerServer WithPartnerServerId(string id);
    }

    /// <summary>
    /// The SQL Failover Group definition to set the partner servers.
    /// </summary>
    public interface IWithDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Failover Group partner servers.
        /// </summary>
        /// <param name="ids">The IDs of the databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate WithDatabaseIds(params string[] ids);

        /// <summary>
        /// Sets the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate WithDatabaseId(string id);
    }

    /// <summary>
    /// The final stage of the SQL Failover Group definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithReadOnlyEndpointPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithDatabase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>
    {
    }

    /// <summary>
    /// The SQL Failover Group definition to set the failover policy of the read-only endpoint.
    /// </summary>
    public interface IWithReadOnlyEndpointPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate WithReadOnlyEndpointPolicyDisabled();

        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition.IWithCreate WithReadOnlyEndpointPolicyEnabled();
    }
}