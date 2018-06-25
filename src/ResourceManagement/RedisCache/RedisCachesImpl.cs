// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of RedisCaches and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzQ2FjaGVzSW1wbA==
    internal partial class RedisCachesImpl :
        TopLevelModifiableResources<IRedisCache,
            RedisCacheImpl,
            RedisResourceInner,
            IRedisOperations,
            IRedisManager>,
        IRedisCaches
    {
        ///GENMHASH:55E32329D71B4595EABF3D089132B67C:EDB70CEF22496ADB4A0D49A2E119F24F
        internal RedisCachesImpl(IRedisManager redisManager)
            : base(redisManager.Inner.Redis, redisManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:730E62C21B719C19E70A1F3FC92CEBE5
        protected override RedisCacheImpl WrapModel(string name)
        {
            return new RedisCacheImpl(
                name,
                new RedisResourceInner(),
                this.Manager);
        }

        ///GENMHASH:CBAFA6E0018A4E2E5B9C07BDC6094FEA:2938EF1204E81FE99C42C7758381BB99
        protected override IRedisCache WrapModel(RedisResourceInner redisResourceInner)
        {
			if (redisResourceInner == null) 
			{
				return null;
			}
            return new RedisCacheImpl(
                redisResourceInner.Name,
                redisResourceInner,
                this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RedisCacheImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2CEB6E35574F5C7F1D19ADAC97C93D65:E562631A6A8C1B378A3E7DBE80F7FF29
        public IEnumerable<Models.Operation> ListOperations()
        {
            return Extensions.Synchronize(() => this.ListOperationsAsync());
        }

        ///GENMHASH:B1063F1468B82C4392D0981460DF0EE4:C67291A5B3D38919C766B2615DDE1A88
        public async Task<IEnumerable<Models.Operation>> ListOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<Models.Operation, Models.Operation>.LoadPage(
                async (cancellation) => await this.Manager.Inner.Operations.ListAsync(cancellation),
                this.Manager.Inner.Operations.ListNextAsync, (i) => i, true, cancellationToken);
        }

        // Catch-up methods
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected async override Task<RedisResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task<IPage<RedisResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<RedisResourceInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<RedisResourceInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }
        
        protected async override Task<IPage<RedisResourceInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }
    }
}
