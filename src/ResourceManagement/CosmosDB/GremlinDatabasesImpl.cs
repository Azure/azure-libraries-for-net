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
    /// Represents a Gremlin Database collection.
    /// </summary>
    internal partial class GremlinDatabasesImpl :
        ExternalChildResourcesCached<
            GremlinDatabaseImpl,
            IGremlinDatabase,
            GremlinDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private IGremlinResourcesOperations Client
        {
            get
            {
                return Parent.Manager.Inner.GremlinResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.RegionName?.ToLower();
            }
        }
        internal GremlinDatabasesImpl(CosmosDBAccountImpl parent)
            : base(parent, "GremlinDatabase")
        {
        }

        protected override IList<GremlinDatabaseImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override GremlinDatabaseImpl NewChildResource(string name)
        {
            return new GremlinDatabaseImpl(name, Parent, new GremlinDatabaseGetResultsInner(Location, name: name));
        }

        public async Task<GremlinDatabaseImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetGremlinDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken
                );
            return new GremlinDatabaseImpl(name, Parent, inner);
        }

        public GremlinDatabaseImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<GremlinDatabaseImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new GremlinDatabaseImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<GremlinDatabaseGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListGremlinDatabasesAsync(
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

        public GremlinDatabaseImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddGremlinDatabase(GremlinDatabaseImpl sqlDatabase)
        {
            this.AddChildResource(sqlDatabase);
        }
    }
}