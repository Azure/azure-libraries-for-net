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
    /// Represents a SQL container collection.
    /// </summary>
    internal partial class SqlContainersImpl :
        ExternalChildResourcesCached<
            SqlContainerImpl,
            ISqlContainer,
            SqlContainerGetResultsInner,
            ISqlDatabase,
            SqlDatabaseImpl>
    {
        private ISqlResourcesOperations Client
        {
            get
            {
                return Parent.Parent.Manager.Inner.SqlResources;
            }
        }
        private string Location
        {
            get
            {
                return Parent.Parent.RegionName?.ToLower();
            }
        }
        internal SqlContainersImpl(SqlDatabaseImpl parent)
            : base(parent, "SqlContainer")
        {
        }

        protected override IList<SqlContainerImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override SqlContainerImpl NewChildResource(string name)
        {
            return new SqlContainerImpl(name, Parent, new SqlContainerGetResultsInner(Location, name: name));
        }

        public async Task<SqlContainerImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetSqlContainerAsync(
                Parent.Parent.ResourceGroupName,
                Parent.Parent.Name,
                Parent.Name(),
                name,
                cancellationToken
                );
            return new SqlContainerImpl(name, Parent, inner);
        }

        public SqlContainerImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<SqlContainerImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new SqlContainerImpl(inner.Name, Parent, inner));
        }

        private async Task<IEnumerable<SqlContainerGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListSqlContainersAsync(
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

        public SqlContainerImpl Update(string name)
        {
            if (this.Collection.Count == 0)
            {
                this.Refresh();
            }
            return this.PrepareUpdate(name);
        }

        public void AddSqlContainer(SqlContainerImpl SqlContainer)
        {
            this.AddChildResource(SqlContainer);
        }
    }
}