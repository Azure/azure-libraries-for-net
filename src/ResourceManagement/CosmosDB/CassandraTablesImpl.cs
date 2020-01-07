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
    /// Represents a Cassandra table collection.
    /// </summary>
    internal partial class CassandraTablesImpl :
        ExternalChildResourcesCached<
            CassandraTableImpl,
            ICassandraTable,
            CassandraTableGetResultsInner,
            ICassandraKeyspace,
            CassandraKeyspaceImpl>
    {
        private ICassandraResourcesOperations Client
        {
            get
            {
                return Parent.Parent.Manager.Inner.CassandraResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.Parent.RegionName?.ToLower();
            }
        }
        internal CassandraTablesImpl(CassandraKeyspaceImpl parent)
            : base(parent, "CassandraTable")
        {
        }

        protected override IList<CassandraTableImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override CassandraTableImpl NewChildResource(string name)
        {
            return new CassandraTableImpl(name, Parent, new CassandraTableGetResultsInner(Location, name: name));
        }

        public async Task<CassandraTableImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetCassandraTableAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                name,
                cancellationToken
                );
            return new CassandraTableImpl(name, Parent, inner);
        }

        public CassandraTableImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<CassandraTableImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new CassandraTableImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<CassandraTableGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListCassandraTablesAsync(
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

        public CassandraTableImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddCassandraTable(CassandraTableImpl CassandraTable)
        {
            this.AddChildResource(CassandraTable);
        }
    }
}