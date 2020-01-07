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
    /// Represents a collection of mongo db collection.
    /// </summary>
    internal partial class MongoCollectionsImpl :
        ExternalChildResourcesCached<
            MongoCollectionImpl,
            IMongoCollection,
            MongoDBCollectionGetResultsInner,
            IMongoDB,
            MongoDBImpl>
    {
        private IMongoDBResourcesOperations Client
        {
            get
            {
                return Parent.Parent.Manager.Inner.MongoDBResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.Parent.RegionName?.ToLower();
            }
        }
        internal MongoCollectionsImpl(MongoDBImpl parent)
            : base(parent, "MongoCollection")
        {
        }

        protected override IList<MongoCollectionImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override MongoCollectionImpl NewChildResource(string name)
        {
            return new MongoCollectionImpl(name, Parent, new MongoDBCollectionGetResultsInner(Location, name: name));
        }

        public async Task<MongoCollectionImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetMongoDBCollectionAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                name,
                cancellationToken
                );
            return new MongoCollectionImpl(name, Parent, inner);
        }

        public MongoCollectionImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<MongoCollectionImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new MongoCollectionImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<MongoDBCollectionGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListMongoDBCollectionsAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
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

        public MongoCollectionImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddMongoCollection(MongoCollectionImpl MongoCollection)
        {
            this.AddChildResource(MongoCollection);
        }
    }
}