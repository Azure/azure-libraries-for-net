// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using DefinitionParentT = CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>;
    using UpdateDefinitionParentT = CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>;
    using UpdateParentT = CassandraKeyspace.Update.IUpdate;
    internal partial class CassandraTableImpl
    {
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ICassandraTable, ICassandraKeyspace>.Id
        {
            get
            {
                return this.Id();
            }
        }

        string ICassandraTable.CassandraTableId
        {
            get
            {
                return this.CassandraTableId();
            }
        }

        string ICassandraTable._rid
        {
            get
            {
                return this._rid();
            }
        }

        object ICassandraTable._ts
        {
            get
            {
                return this._ts();
            }
        }

        string ICassandraTable._etag
        {
            get
            {
                return this._etag();
            }
        }

        Models.CassandraSchema ICassandraTable.Schema
        {
            get
            {
                return this.Schema();
            }
        }

        int? ICassandraTable.DefaultTtl
        {
            get
            {
                return this.DefaultTtl();
            }
        }

        ThroughputSettingsGetPropertiesResource ICassandraTable.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> ICassandraTable.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        CassandraTable.Update.IUpdate HasOptions.Update.IWithOptions<CassandraTable.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraTable.Update.IUpdate HasOptions.Update.IWithOptions<CassandraTable.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraTable.Update.IUpdate HasOptions.Update.IWithOptions<CassandraTable.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        CassandraTable.Update.IUpdate HasOptions.Update.IWithOptions<CassandraTable.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        CassandraTable.Update.IUpdate HasOptions.Update.IWithOptions<CassandraTable.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        CassandraTable.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<CassandraTable.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CassandraKeyspace.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CassandraKeyspace.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithDefaultTtl.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithDefaultTtl.WithoutDefaultTtl()
        {
            return this.WithoutDefaultTtl();
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithColumn(Models.Column column)
        {
            return this.WithColumn(column);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithColumn(string name, string type)
        {
            return this.WithColumn(name, type);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithoutColumn(string name)
        {
            return this.WithoutColumn(name);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithColumnsAppend(IList<Models.Column> columns)
        {
            return this.WithColumnsAppend(columns);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithColumnsReplace(IList<Models.Column> columns)
        {
            return this.WithColumnsAppend(columns);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithColumn.WithoutColumns()
        {
            return this.WithoutColumns();
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithPartitionKey(Models.CassandraPartitionKey partitionKey)
        {
            return this.WithPartitionKey(partitionKey);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithPartitionKey(string name)
        {
            return this.WithPartitionKey(name);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithoutPartitionKey(string name)
        {
            return this.WithoutPartitionKey(name);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithPartitionKeysAppend(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            return this.WithPartitionKeysAppend(partitionKeys);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithPartitionKeysReplace(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            return this.WithPartitionKeysReplace(partitionKeys);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithPartitionKey.WithoutPartitionKeys()
        {
            return this.WithoutPartitionKeys();
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithClusterKey(Models.ClusterKey clusterKey)
        {
            return this.WithClusterKey(clusterKey);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithClusterKey(string name, string orderBy)
        {
            return this.WithClusterKey(name, orderBy);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithoutClusterKey(string name)
        {
            return this.WithoutClusterKey(name);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithClusterKeysAppend(IList<Models.ClusterKey> clusterKeys)
        {
            return this.WithClusterKeysAppend(clusterKeys);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithClusterKeysReplace(IList<Models.ClusterKey> clusterKeys)
        {
            return this.WithClusterKeysReplace(clusterKeys);
        }

        CassandraTable.Update.IUpdate CassandraTable.Update.IWithClusterKey.WithoutClusterKeys()
        {
            return this.WithoutClusterKeys();
        }

        // definition for DefinitionParentT

        CassandraTable.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<DefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<DefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<CassandraTable.Definition.IWithAttach<DefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        DefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<DefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithDefaultTtl<DefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithColumn<DefinitionParentT>.WithColumn(Models.Column column)
        {
            return this.WithColumn(column);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithColumn<DefinitionParentT>.WithColumn(string name, string type)
        {
            return this.WithColumn(name, type);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithColumn<DefinitionParentT>.WithColumns(IList<Models.Column> columns)
        {
            return this.WithColumnsAppend(columns);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithPartitionKey<DefinitionParentT>.WithPartitionKey(Models.CassandraPartitionKey partitionKey)
        {
            return this.WithPartitionKey(partitionKey);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithPartitionKey<DefinitionParentT>.WithPartitionKey(string name)
        {
            return this.WithPartitionKey(name);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithPartitionKey<DefinitionParentT>.WithPartitionKeys(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            return this.WithPartitionKeysAppend(partitionKeys);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithClusterKey<DefinitionParentT>.WithClusterKey(Models.ClusterKey clusterKey)
        {
            return this.WithClusterKey(clusterKey);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithClusterKey<DefinitionParentT>.WithClusterKey(string name, string orderBy)
        {
            return this.WithClusterKey(name, orderBy);
        }

        CassandraTable.Definition.IWithAttach<DefinitionParentT> CassandraTable.Definition.IWithClusterKey<DefinitionParentT>.WithClusterKeys(IList<Models.ClusterKey> clusterKeys)
        {
            return this.WithClusterKeysAppend(clusterKeys);
        }

        // definition for UpdateDefinitionParentT
        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> HasThroughputSettings.Definition.IWithThroughput<CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateDefinitionParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateDefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithDefaultTtl<UpdateDefinitionParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithColumn<UpdateDefinitionParentT>.WithColumn(Models.Column column)
        {
            return this.WithColumn(column);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithColumn<UpdateDefinitionParentT>.WithColumn(string name, string type)
        {
            return this.WithColumn(name, type);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithColumn<UpdateDefinitionParentT>.WithColumns(IList<Models.Column> columns)
        {
            return this.WithColumnsAppend(columns);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithPartitionKey(Models.CassandraPartitionKey partitionKey)
        {
            return this.WithPartitionKey(partitionKey);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithPartitionKey(string name)
        {
            return this.WithPartitionKey(name);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithPartitionKey<UpdateDefinitionParentT>.WithPartitionKeys(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            return this.WithPartitionKeysAppend(partitionKeys);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithClusterKey<UpdateDefinitionParentT>.WithClusterKey(Models.ClusterKey clusterKey)
        {
            return this.WithClusterKey(clusterKey);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithClusterKey<UpdateDefinitionParentT>.WithClusterKey(string name, string orderBy)
        {
            return this.WithClusterKey(name, orderBy);
        }

        CassandraTable.Definition.IWithAttach<UpdateDefinitionParentT> CassandraTable.Definition.IWithClusterKey<UpdateDefinitionParentT>.WithClusterKeys(IList<Models.ClusterKey> clusterKeys)
        {
            return this.WithClusterKeysAppend(clusterKeys);
        }

        // definition for UpdateParentT
        CassandraTable.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<UpdateParentT>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> HasOptions.Definition.IWithOptions<CassandraTable.Definition.IWithAttach<UpdateParentT>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> HasThroughputSettings.Definition.IWithThroughput<CassandraTable.Definition.IWithAttach<UpdateParentT>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        UpdateParentT Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<UpdateParentT>.Attach()
        {
            return this.Attach();
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithDefaultTtl<UpdateParentT>.WithDefaultTtl(int ttl)
        {
            return this.WithDefaultTtl(ttl);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithColumn<UpdateParentT>.WithColumn(Models.Column column)
        {
            return this.WithColumn(column);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithColumn<UpdateParentT>.WithColumn(string name, string type)
        {
            return this.WithColumn(name, type);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithColumn<UpdateParentT>.WithColumns(IList<Models.Column> columns)
        {
            return this.WithColumnsAppend(columns);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithPartitionKey<UpdateParentT>.WithPartitionKey(Models.CassandraPartitionKey partitionKey)
        {
            return this.WithPartitionKey(partitionKey);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithPartitionKey<UpdateParentT>.WithPartitionKey(string name)
        {
            return this.WithPartitionKey(name);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithPartitionKey<UpdateParentT>.WithPartitionKeys(IList<Models.CassandraPartitionKey> partitionKeys)
        {
            return this.WithPartitionKeysAppend(partitionKeys);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithClusterKey<UpdateParentT>.WithClusterKey(Models.ClusterKey clusterKey)
        {
            return this.WithClusterKey(clusterKey);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithClusterKey<UpdateParentT>.WithClusterKey(string name, string orderBy)
        {
            return this.WithClusterKey(name, orderBy);
        }

        CassandraTable.Definition.IWithAttach<UpdateParentT> CassandraTable.Definition.IWithClusterKey<UpdateParentT>.WithClusterKeys(IList<Models.ClusterKey> clusterKeys)
        {
            return this.WithClusterKeysAppend(clusterKeys);
        }
    }
}
