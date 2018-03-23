// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL Failover Group update definition to set the read-write endpoint failover policy.
    /// </summary>
    public interface IWithReadWriteEndpointPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Automatic".
        /// </summary>
        /// <param name="gracePeriodInMinutes">The grace period before failover with data loss is attempted for the read-write endpoint.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(int gracePeriodInMinutes);

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Manual".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithManualReadWriteEndpointPolicy();
    }

    /// <summary>
    /// The SQL Failover Group update definition to set the failover policy of the read-only endpoint.
    /// </summary>
    public interface IWithReadOnlyEndpointPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithReadOnlyEndpointPolicyDisabled();

        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithReadOnlyEndpointPolicyEnabled();
    }

    /// <summary>
    /// The template for a SQL Failover Group update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IWithReadWriteEndpointPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IWithReadOnlyEndpointPolicy,
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IWithDatabase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>
    {
    }

    /// <summary>
    /// The SQL Failover Group update definition to set the partner servers.
    /// </summary>
    public interface IWithDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Removes the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database to be removed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithoutDatabaseId(string id);

        /// <summary>
        /// Sets the SQL Failover Group partner servers.
        /// </summary>
        /// <param name="ids">The IDs of the databases.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithDatabaseIds(params string[] ids);

        /// <summary>
        /// Sets the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update.IUpdate WithNewDatabaseId(string id);
    }
}