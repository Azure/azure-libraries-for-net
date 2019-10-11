// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal partial class PoolsImpl :
        ExternalChildResourcesCached<
            PoolImpl,
            IPool,
            PoolInner,
            IBatchAccount,
            BatchAccountImpl>
    {
        private BatchAccountImpl parent;

        internal PoolsImpl(BatchAccountImpl parent)
            : base(parent, "Pool")
        {
            this.parent = parent;
            CacheCollection();
        }

        internal IReadOnlyDictionary<string, IPool> AsMap()
        {
            var result = new Dictionary<string, IPool>();

            foreach (var entry in Collection)
            {
                result.Add(entry.Key, entry.Value);
            }

            return new ReadOnlyDictionary<string, IPool>(result);
        }

        internal PoolImpl Define(string name)
        {
            return PrepareDefine(name);
        }

        internal PoolImpl Update(string name)
        {
            return PrepareUpdate(name);
        }

        internal void Remove(string name)
        {
            PrepareRemove(name);
        }

        internal void AddPool(PoolImpl pool)
        {
            AddChildResource(pool);
        }

        protected override IList<PoolImpl> ListChildResources()
        {
            var childResources = new List<PoolImpl>();
            if (Parent.Inner.Id == null || Parent.AutoStorage() == null)
            {
                return childResources;
            }

            var poolList = Extensions.Synchronize(() => Parent.Manager.Inner.Pool.ListByBatchAccountAsync(Parent.ResourceGroupName, Parent.Name));

            foreach (var pool in poolList)
            {
                childResources.Add(new PoolImpl(
                    pool.Name,
                    parent,
                    pool));
            }

            return childResources;
        }

        protected override PoolImpl NewChildResource(string name)
        {
            PoolImpl pool = PoolImpl.NewPool(name, parent);
            return pool;
        }
    }
}
