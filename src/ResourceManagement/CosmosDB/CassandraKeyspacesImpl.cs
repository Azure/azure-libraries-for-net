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
    /// Represents a Cassandra keyspace collection.
    /// </summary>
    internal partial class CassandraKeyspacesImpl :
        ExternalChildResourcesCached<
            CassandraKeyspaceImpl,
            ICassandraKeyspace,
            CassandraKeyspaceGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private ICassandraResourcesOperations Client
        {
            get
            {
                return Parent.Manager.Inner.CassandraResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.RegionName?.ToLower();
            }
        }
        internal CassandraKeyspacesImpl(CosmosDBAccountImpl parent)
            : base(parent, "CassandraKeyspace")
        {
        }

        protected override IList<CassandraKeyspaceImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override CassandraKeyspaceImpl NewChildResource(string name)
        {
            return new CassandraKeyspaceImpl(name, Parent, new CassandraKeyspaceGetResultsInner(Location, name: name));
        }

        public async Task<CassandraKeyspaceImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetCassandraKeyspaceAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken
                );
            return new CassandraKeyspaceImpl(name, Parent, inner);
        }

        public CassandraKeyspaceImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<CassandraKeyspaceImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new CassandraKeyspaceImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<CassandraKeyspaceGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListCassandraKeyspacesAsync(
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

        public CassandraKeyspaceImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddCassandraKeyspace(CassandraKeyspaceImpl sqlDatabase)
        {
            this.AddChildResource(sqlDatabase);
        }
    }
}