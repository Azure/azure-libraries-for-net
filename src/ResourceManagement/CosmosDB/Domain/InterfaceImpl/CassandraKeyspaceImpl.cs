// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class CassandraKeyspaceImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB Cassandra keyspace
        /// </summary>
        string ICassandraKeyspace.CassandraKeyspaceId
        {
            get
            {
                return this.CassandraKeyspaceId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string ICassandraKeyspace._rid
        {
            get
            {
                return this._rid();
            }
        }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object ICassandraKeyspace._ts
        {
            get
            {
                return this._ts();
            }
        }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string ICassandraKeyspace._etag
        {
            get
            {
                return this._etag();
            }
        }

        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ICassandraKeyspace, ICosmosDBAccount>.Id
        {
            get
            {
                return this.Id();
            }
        }

        ThroughputSettingsGetPropertiesResource ICassandraKeyspace.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> ICassandraKeyspace.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        IEnumerable<ICassandraTable> ICassandraKeyspace.ListCassandraTables()
        {
            return this.ListCassandraTables();
        }

        Task<IEnumerable<ICassandraTable>> ICassandraKeyspace.ListCassandraTablesAsync(CancellationToken cancellationToken)
        {
            return this.ListCassandraTablesAsync(cancellationToken);
        }

        ICassandraTable ICassandraKeyspace.GetCassandraTable(string name)
        {
            return this.GetCassandraTable(name);
        }

        Task<ICassandraTable> ICassandraKeyspace.GetCassandraTableAsync(string name, CancellationToken cancellationToken)
        {
            return this.GetCassandraTableAsync(name, cancellationToken);
        }

        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraKeyspace.Update.IUpdate HasOptions.Update.IWithOptions<CassandraKeyspace.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraKeyspace.Update.IUpdate HasOptions.Update.IWithOptions<CassandraKeyspace.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraKeyspace.Update.IUpdate HasOptions.Update.IWithOptions<CassandraKeyspace.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        CassandraKeyspace.Update.IUpdate HasOptions.Update.IWithOptions<CassandraKeyspace.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        CassandraKeyspace.Update.IUpdate HasOptions.Update.IWithOptions<CassandraKeyspace.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasThroughputSettings.Definition.IWithThroughput<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CassandraKeyspace.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<CassandraKeyspace.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        CosmosDBAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        // definition for parent update
        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasThroughputSettings.Definition.IWithThroughput<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Update.IWithOptionals Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Update.IWithOptionals>.Attach()
        {
            return this.Attach();
        }

        CassandraTable.Definition.IBlank<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>> CassandraKeyspace.Definition.IWithChildResource<CosmosDBAccount.Definition.IWithCreate>.DefineNewCassandraTable(string name)
        {
            return this.DefineNewCassandraTable(name);
        }

        CassandraTable.Definition.IBlank<CassandraKeyspace.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>> CassandraKeyspace.Definition.IWithChildResource<CosmosDBAccount.Update.IWithOptionals>.DefineNewCassandraTable(string name)
        {
            return this.DefineNewCassandraTable(name);
        }

        CassandraTable.Definition.IBlank<CassandraKeyspace.Update.IUpdate> CassandraKeyspace.Update.IWithChildResource.DefineNewCassandraTable(string name)
        {
            return this.DefineNewCassandraTable(name);
        }

        CassandraTable.Update.IUpdate CassandraKeyspace.Update.IWithChildResource.UpdateCassandraTable(string name)
        {
            return this.UpdateCassandraTable(name);
        }

        CassandraKeyspace.Update.IUpdate CassandraKeyspace.Update.IWithChildResource.WithoutCassandraTable(string name)
        {
            return this.WithoutCassandraTable(name);
        }
    }
}
