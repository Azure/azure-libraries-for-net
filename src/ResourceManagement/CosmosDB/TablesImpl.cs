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
    /// Represents a Table database collection.
    /// </summary>
    internal partial class TablesImpl :
        ExternalChildResourcesCached<
            TableImpl,
            ITable,
            TableGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private ITableResourcesOperations Client
        {
            get
            {
                return Parent.Manager.Inner.TableResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.RegionName?.ToLower();
            }
        }
        internal TablesImpl(CosmosDBAccountImpl parent)
            : base(parent, "Table")
        {
        }

        protected override IList<TableImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override TableImpl NewChildResource(string name)
        {
            return new TableImpl(name, Parent, new TableGetResultsInner(Location, name: name));
        }

        public async Task<TableImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetTableAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken
                );
            return new TableImpl(name, Parent, inner);
        }

        public TableImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<TableImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new TableImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<TableGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListTablesAsync(
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

        public TableImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddTable(TableImpl sqlDatabase)
        {
            this.AddChildResource(sqlDatabase);
        }
    }
}