// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a Mongo DB collection.
    /// </summary>
    internal partial class MongoDBsImpl :
        ExternalChildResourcesCached<
            MongoDBImpl,
            IMongoDB,
            MongoDBDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private IMongoDBResourcesOperations Client
        {
            get
            {
                return Parent.Manager.Inner.MongoDBResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.RegionName?.ToLower();
            }
        }
        internal MongoDBsImpl(CosmosDBAccountImpl parent)
            : base(parent, "MongoDB")
        {
        }

        protected override IList<MongoDBImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override MongoDBImpl NewChildResource(string name)
        {
            return new MongoDBImpl(name, Parent, new MongoDBDatabaseGetResultsInner(Location, name: name));
        }

        public async Task<MongoDBImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetMongoDBDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken
                );
            return new MongoDBImpl(name, Parent, inner);
        }

        public MongoDBImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<MongoDBImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new MongoDBImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<MongoDBDatabaseGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListMongoDBDatabasesAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                cancellationToken
                );
        }

        public void Remove(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            this.PrepareRemove(name);
        }

        public MongoDBImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddMongoDB(MongoDBImpl sqlDatabase)
        {
            this.AddChildResource(sqlDatabase);
        }
    }
}