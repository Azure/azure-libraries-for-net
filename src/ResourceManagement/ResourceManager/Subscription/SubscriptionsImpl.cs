// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class SubscriptionsImpl :
        ISubscriptions
    {
        private ISubscriptionsOperations innerCollection;

        internal SubscriptionsImpl(ISubscriptionsOperations client)
        {
            this.innerCollection = client;
        }

        public IEnumerable<ISubscription> List()
        {
            return Extensions.Synchronize(() => innerCollection.ListAsync())
                                  .AsContinuousCollection(link => Extensions.Synchronize(() => innerCollection.ListNextAsync(link)))
                                  .Select(inner => WrapModel(inner));
        }

        public ISubscription GetById(string id)
        {
            var inner = Extensions.Synchronize(() => innerCollection.GetAsync(id));
            if (inner == null)
            {
                return null;
            }
            else
            {
                return new SubscriptionImpl(inner, innerCollection);
            }
        }

        public async Task<ISubscription> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await innerCollection.GetAsync(id, cancellationToken);
            if (inner == null)
            {
                return null;
            }
            else
            {
                return WrapModel(inner);
            }
        }

        private ISubscription WrapModel(SubscriptionInner innerModel)
        {
            return new SubscriptionImpl(innerModel, innerCollection);
        }

        public async Task<IPagedCollection<ISubscription>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ISubscription, SubscriptionInner>.LoadPage(
                async (cancellation) => await innerCollection.ListAsync(cancellation),
                innerCollection.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}