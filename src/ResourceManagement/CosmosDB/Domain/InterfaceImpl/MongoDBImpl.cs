// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class MongoDBImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database
        /// </summary>
        string IMongoDB.MongoDBId
        {
            get
            {
                return this.MongoDBId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string IMongoDB._rid
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
        object IMongoDB._ts
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
        string IMongoDB._etag
        {
            get
            {
                return this._etag();
            }
        }



        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<IMongoDB, ICosmosDBAccount>.Id
        {
            get
            {
                return this.Id();
            }
        }

        ThroughputSettingsGetPropertiesResource IMongoDB.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> IMongoDB.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        IEnumerable<IMongoCollection> IMongoDB.ListCollections()
        {
            return this.ListCollections();
        }

        Task<IEnumerable<IMongoCollection>> IMongoDB.ListCollectionsAsync(CancellationToken cancellationToken)
        {
            return this.ListCollectionsAsync(cancellationToken);
        }

        IMongoCollection IMongoDB.GetCollection(string name)
        {
            return this.GetCollection(name);
        }

        Task<IMongoCollection> IMongoDB.GetCollectionAsync(string name, CancellationToken cancellationToken)
        {
            return this.GetCollectionAsync(name, cancellationToken);
        }

        MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoDB.Update.IUpdate HasOptions.Update.IWithOptions<MongoDB.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoDB.Update.IUpdate HasOptions.Update.IWithOptions<MongoDB.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoDB.Update.IUpdate HasOptions.Update.IWithOptions<MongoDB.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        MongoDB.Update.IUpdate HasOptions.Update.IWithOptions<MongoDB.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        MongoDB.Update.IUpdate HasOptions.Update.IWithOptions<MongoDB.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasThroughputSettings.Definition.IWithThroughput<MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        MongoDB.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<MongoDB.Update.IUpdate>.WithThroughput(int throughput)
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
        MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasThroughputSettings.Definition.IWithThroughput<MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Update.IWithOptionals Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Update.IWithOptionals>.Attach()
        {
            return this.Attach();
        }

        MongoCollection.Definition.IBlank<MongoDB.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>> MongoDB.Definition.IWithChildResource<CosmosDBAccount.Definition.IWithCreate>.DefineNewCollection(string name)
        {
            return this.DefineNewCollection(name);
        }

        MongoCollection.Definition.IBlank<MongoDB.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>> MongoDB.Definition.IWithChildResource<CosmosDBAccount.Update.IWithOptionals>.DefineNewCollection(string name)
        {
            return this.DefineNewCollection(name);
        }

        MongoCollection.Definition.IBlank<MongoDB.Update.IUpdate> MongoDB.Update.IWithChildResource.DefineNewCollection(string name)
        {
            return this.DefineNewCollection(name);
        }

        MongoCollection.Update.IUpdate MongoDB.Update.IWithChildResource.UpdateCollection(string name)
        {
            return this.UpdateCollection(name);
        }

        MongoDB.Update.IUpdate MongoDB.Update.IWithChildResource.WithoutCollection(string name)
        {
            return this.WithoutCollection(name);
        }
    }
}
