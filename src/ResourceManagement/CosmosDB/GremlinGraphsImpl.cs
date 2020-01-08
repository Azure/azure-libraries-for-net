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
    /// Represents a Gremlin Graph collection.
    /// </summary>
    internal partial class GremlinGraphsImpl :
        ExternalChildResourcesCached<
            GremlinGraphImpl,
            IGremlinGraph,
            GremlinGraphGetResultsInner,
            IGremlinDatabase,
            GremlinDatabaseImpl>
    {
        private IGremlinResourcesOperations Client
        {
            get
            {
                return Parent.Parent.Manager.Inner.GremlinResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.Parent.RegionName?.ToLower();
            }
        }
        internal GremlinGraphsImpl(GremlinDatabaseImpl parent)
            : base(parent, "GremlinGraph")
        {
        }

        protected override IList<GremlinGraphImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override GremlinGraphImpl NewChildResource(string name)
        {
            return new GremlinGraphImpl(name, Parent, new GremlinGraphGetResultsInner(Location, name: name));
        }

        public async Task<GremlinGraphImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetGremlinGraphAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                name,
                cancellationToken
                );
            return new GremlinGraphImpl(name, Parent, inner);
        }

        public GremlinGraphImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<GremlinGraphImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new GremlinGraphImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<GremlinGraphGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListGremlinGraphsAsync(
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

        public GremlinGraphImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddGremlinGraph(GremlinGraphImpl GremlinGraph)
        {
            this.AddChildResource(GremlinGraph);
        }
    }
}