// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GremlinDatabaseImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database
        /// </summary>
        string IGremlinDatabase.GremlinDatabaseId
        {
            get
            {
                return this.GremlinDatabaseId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string IGremlinDatabase._rid
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
        object IGremlinDatabase._ts
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
        string IGremlinDatabase._etag
        {
            get
            {
                return this._etag();
            }
        }

        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IGremlinDatabase, ICosmosDBAccount>.Id
        {
            get
            {
                return this.Id();
            }
        }

        ThroughputSettingsGetPropertiesResource IGremlinDatabase.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> IGremlinDatabase.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        IEnumerable<IGremlinGraph> IGremlinDatabase.ListGremlinGraphs()
        {
            return this.ListGremlinGraphs();
        }

        Task<IEnumerable<IGremlinGraph>> IGremlinDatabase.ListGremlinGraphsAsync(CancellationToken cancellationToken)
        {
            return this.ListGremlinGraphsAsync(cancellationToken);
        }

        IGremlinGraph IGremlinDatabase.GetGremlinGraph(string name)
        {
            return this.GetGremlinGraph(name);
        }

        Task<IGremlinGraph> IGremlinDatabase.GetGremlinGraphAsync(string name, CancellationToken cancellationToken)
        {
            return this.GetGremlinGraphAsync(name, cancellationToken);
        }

        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinDatabase.Update.IUpdate HasOptions.Update.IWithOptions<GremlinDatabase.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinDatabase.Update.IUpdate HasOptions.Update.IWithOptions<GremlinDatabase.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinDatabase.Update.IUpdate HasOptions.Update.IWithOptions<GremlinDatabase.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        GremlinDatabase.Update.IUpdate HasOptions.Update.IWithOptions<GremlinDatabase.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        GremlinDatabase.Update.IUpdate HasOptions.Update.IWithOptions<GremlinDatabase.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasThroughputSettings.Definition.IWithThroughput<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        GremlinDatabase.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<GremlinDatabase.Update.IUpdate>.WithThroughput(int throughput)
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
        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasThroughputSettings.Definition.IWithThroughput<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Update.IWithOptionals Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Update.IWithOptionals>.Attach()
        {
            return this.Attach();
        }

        GremlinGraph.Definition.IBlank<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>> GremlinDatabase.Definition.IWithChildResource<CosmosDBAccount.Definition.IWithCreate>.DefineNewGremlinGraph(string name)
        {
            return this.DefineNewGremlinGraph(name);
        }

        GremlinGraph.Definition.IBlank<GremlinDatabase.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>> GremlinDatabase.Definition.IWithChildResource<CosmosDBAccount.Update.IWithOptionals>.DefineNewGremlinGraph(string name)
        {
            return this.DefineNewGremlinGraph(name);
        }

        GremlinGraph.Definition.IBlank<GremlinDatabase.Update.IUpdate> GremlinDatabase.Update.IWithChildResource.DefineNewGremlinGraph(string name)
        {
            return this.DefineNewGremlinGraph(name);
        }

        GremlinGraph.Update.IUpdate GremlinDatabase.Update.IWithChildResource.UpdateGremlinGraph(string name)
        {
            return this.UpdateGremlinGraph(name);
        }

        GremlinDatabase.Update.IUpdate GremlinDatabase.Update.IWithChildResource.WithoutGremlinGraph(string name)
        {
            return this.WithoutGremlinGraph(name);
        }
    }
}
