// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRXhwcmVzc1JvdXRlQ2lyY3VpdHNJbXBs
    internal partial class ExpressRouteCircuitsImpl :
        TopLevelModifiableResources<
            IExpressRouteCircuit,
            ExpressRouteCircuitImpl,
            ExpressRouteCircuitInner,
            IExpressRouteCircuitsOperations,
            INetworkManager>,
        IExpressRouteCircuits
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ExpressRouteCircuitImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:74C147F51734F6E4EC03A356084B460C:E16DF8EB37E114D266AE190649DA3B11
        internal ExpressRouteCircuitsImpl(INetworkManager manager) : base(manager.Inner.ExpressRouteCircuits, manager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:80F4B7CC871BAA6260E7A0D114F17E2D
        protected override ExpressRouteCircuitImpl WrapModel(string name)
        {
            ExpressRouteCircuitInner inner = new ExpressRouteCircuitInner();
            return new ExpressRouteCircuitImpl(name, inner, Manager);
        }

        ///GENMHASH:F32389B8819CBE432743FBA0DF5A37FB:8233507747ADC00D20A4E6B1CCB583F7
        protected override IExpressRouteCircuit WrapModel(ExpressRouteCircuitInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new ExpressRouteCircuitImpl(inner.Name, inner, Manager);
        }

        protected override async Task<ExpressRouteCircuitInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected async override Task<IPage<ExpressRouteCircuitInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected override async Task<IPage<ExpressRouteCircuitInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<ExpressRouteCircuitInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected override async Task<IPage<ExpressRouteCircuitInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }
    }
}