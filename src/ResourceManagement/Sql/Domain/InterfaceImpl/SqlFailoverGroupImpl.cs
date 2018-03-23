// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupOperationsDefinition;
    using System.Collections.Generic;

    internal partial class SqlFailoverGroupImpl 
    {
        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate SqlFailoverGroupOperations.Definition.IWithReadOnlyEndpointPolicy.WithReadOnlyEndpointPolicyDisabled()
        {
            return this.WithReadOnlyEndpointPolicyDisabled() as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate SqlFailoverGroupOperations.Definition.IWithReadOnlyEndpointPolicy.WithReadOnlyEndpointPolicyEnabled()
        {
            return this.WithReadOnlyEndpointPolicyEnabled() as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithReadOnlyEndpointPolicy.WithReadOnlyEndpointPolicyDisabled()
        {
            return this.WithReadOnlyEndpointPolicyDisabled() as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Sets the SQL Failover Group failover policy of the read-only endpoint to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithReadOnlyEndpointPolicy.WithReadOnlyEndpointPolicyEnabled()
        {
            return this.WithReadOnlyEndpointPolicyEnabled() as SqlFailoverGroup.Update.IUpdate;
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

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="location">The parent SQL server location.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy SqlFailoverGroupOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName, location) as SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy;
        }

        /// <summary>
        /// Sets the parent SQL server for the new Failover Group.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy SqlFailoverGroupOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer) as SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy;
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<SqlFailoverGroupOperations.Definition.IWithCreate>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags) as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<SqlFailoverGroupOperations.Definition.IWithCreate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value) as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the SQL Failover Group partner servers.
        /// </summary>
        /// <param name="ids">The IDs of the databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate SqlFailoverGroupOperations.Definition.IWithDatabase.WithDatabaseIds(params string[] ids)
        {
            return this.WithDatabaseIds(ids) as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithCreate SqlFailoverGroupOperations.Definition.IWithDatabase.WithDatabaseId(string id)
        {
            return this.WithDatabaseId(id) as SqlFailoverGroupOperations.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithDatabase.WithNewDatabaseId(string id)
        {
            return this.WithNewDatabaseId(id) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes the SQL Failover Group database.
        /// </summary>
        /// <param name="id">The ID of the database to be removed.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithDatabase.WithoutDatabaseId(string id)
        {
            return this.WithoutDatabaseId(id) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Sets the SQL Failover Group partner servers.
        /// </summary>
        /// <param name="ids">The IDs of the databases.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithDatabase.WithDatabaseIds(params string[] ids)
        {
            return this.WithDatabaseIds(ids) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        SqlFailoverGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<SqlFailoverGroup.Update.IUpdate>.WithoutTag(string key)
        {
            return this.WithoutTag(key) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        SqlFailoverGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<SqlFailoverGroup.Update.IUpdate>.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        SqlFailoverGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<SqlFailoverGroup.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlFailoverGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlFailoverGroup.Update.IUpdate>.Update()
        {
            return this.Update() as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Sets the SQL Failover Group partner server.
        /// </summary>
        /// <param name="id">The ID of the partner SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithPartnerServer SqlFailoverGroupOperations.Definition.IWithPartnerServer.WithPartnerServerId(string id)
        {
            return this.WithPartnerServerId(id) as SqlFailoverGroupOperations.Definition.IWithPartnerServer;
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets the list of partner server information for the failover group.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PartnerInfo> Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.PartnerServers
        {
            get
            {
                return this.PartnerServers() as System.Collections.Generic.IReadOnlyList<Models.PartnerInfo>;
            }
        }

        /// <summary>
        /// Gets the list of database IDs in the failover group.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.Databases
        {
            get
            {
                return this.Databases() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets the replication state of the failover group instance.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ReplicationState
        {
            get
            {
                return this.ReplicationState();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this Failover Group belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the failover policy of the read-write endpoint for the failover group.
        /// </summary>
        Models.ReadWriteEndpointFailoverPolicy Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ReadWriteEndpointPolicy
        {
            get
            {
                return this.ReadWriteEndpointPolicy() as Models.ReadWriteEndpointFailoverPolicy;
            }
        }

        /// <summary>
        /// Gets the failover policy of the read-only endpoint for the failover group.
        /// </summary>
        Models.ReadOnlyEndpointFailoverPolicy Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ReadOnlyEndpointPolicy
        {
            get
            {
                return this.ReadOnlyEndpointPolicy() as Models.ReadOnlyEndpointFailoverPolicy;
            }
        }

        /// <summary>
        /// Deletes the Failover Group asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes the Failover Group.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the grace period before failover with data loss is attempted for the read-write endpoint.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes
        {
            get
            {
                return this.ReadWriteEndpointDataLossGracePeriodMinutes();
            }
        }

        /// <summary>
        /// Gets the local replication role of the failover group instance.
        /// </summary>
        Models.FailoverGroupReplicationRole Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup.ReplicationRole
        {
            get
            {
                return this.ReplicationRole() as Models.FailoverGroupReplicationRole;
            }
        }

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Automatic".
        /// </summary>
        /// <param name="gracePeriodInMinutes">The grace period before failover with data loss is attempted for the read-write endpoint.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithPartnerServer SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy.WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(int gracePeriodInMinutes)
        {
            return this.WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(gracePeriodInMinutes) as SqlFailoverGroupOperations.Definition.IWithPartnerServer;
        }

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Manual".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroupOperations.Definition.IWithPartnerServer SqlFailoverGroupOperations.Definition.IWithReadWriteEndpointPolicy.WithManualReadWriteEndpointPolicy()
        {
            return this.WithManualReadWriteEndpointPolicy() as SqlFailoverGroupOperations.Definition.IWithPartnerServer;
        }

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Automatic".
        /// </summary>
        /// <param name="gracePeriodInMinutes">The grace period before failover with data loss is attempted for the read-write endpoint.</param>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithReadWriteEndpointPolicy.WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(int gracePeriodInMinutes)
        {
            return this.WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(gracePeriodInMinutes) as SqlFailoverGroup.Update.IUpdate;
        }

        /// <summary>
        /// Sets the SQL Failover Group read-write endpoint failover policy as "Manual".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlFailoverGroup.Update.IUpdate SqlFailoverGroup.Update.IWithReadWriteEndpointPolicy.WithManualReadWriteEndpointPolicy()
        {
            return this.WithManualReadWriteEndpointPolicy() as SqlFailoverGroup.Update.IUpdate;
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
    }
}