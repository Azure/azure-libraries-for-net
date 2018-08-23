// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of  BatchAIUsages.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoYWkuaW1wbGVtZW50YXRpb24uQmF0Y2hBSVVzYWdlc0ltcGw=
    internal partial class BatchAIUsagesImpl : ReadableWrappers<IBatchAIUsage, BatchAIUsageImpl, UsageInner>,
        IBatchAIUsages
    {
        private readonly IBatchAIManager manager;

        ///GENMHASH:420D51D278F4BC7747DFCC9CEEF881BD:FCBE9313644315745EDD2396965C2FE2
        internal  BatchAIUsagesImpl(IBatchAIManager manager)
        {
            this.manager = manager;
        }

        ///GENMHASH:438AA0AEE9E5AB3F7FB0CB3404AB0062:721A1AF5B7A50286838CF749239E931B
        protected override IBatchAIUsage WrapModel(UsageInner usageInner)
        {
            if (usageInner == null)
            {
                return null;
            }
            return new BatchAIUsageImpl(usageInner);
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:278D096DC6C27545470C89C8D1259A16
        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:34BF45703D53DEAC832C7449858B69FC
        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage> ListByRegion(string regionName)
        {
            return WrapList(Extensions.Synchronize(() => manager.Inner.Usages.ListWithHttpMessagesAsync(regionName)).Body.AsContinuousCollection(link => Extensions.Synchronize(() => manager.Inner.Usages.ListNextAsync(link))));
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:039795D842B96323D94D260F3FF83299
        public async Task<IPagedCollection<IBatchAIUsage>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:DBED7C5E8F3D15AA49FB5B3D4C6C961C
        public async Task<IPagedCollection<IBatchAIUsage>> ListByRegionAsync(string regionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.BatchAIUsages.ListByRegionAsync(regionName, cancellationToken);
        }
    }
}