// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Implementation for RouteFilters.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVGaWx0ZXJzSW1wbA==
    internal partial class RouteFiltersImpl  :
        TopLevelModifiableResources<Microsoft.Azure.Management.Network.Fluent.IRouteFilter,
            Microsoft.Azure.Management.Network.Fluent.RouteFilterImpl,
            Models.RouteFilterInner, 
            IRouteFiltersOperations,
            Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IRouteFilters
    {

        ///GENMHASH:E3F223DA98A8A789ECDC0F18F0162EF6:08FA0E6457DAABABD7D699EF88084645
        internal RouteFiltersImpl(NetworkManager networkManager) : base(networkManager.Inner.RouteFilters, networkManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:C90ECB22096454819F1952D99A71D0F5
        protected override RouteFilterImpl WrapModel(string name)
        {
            RouteFilterInner inner = new RouteFilterInner();
            return new RouteFilterImpl(name, inner, Manager);
        }

        ///GENMHASH:171A48C3C1C3B51D4825DFBE47581089:00A3A02E83990C5035A9D728BAA7D9E2
        protected override IRouteFilter WrapModel(RouteFilterInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new RouteFilterImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RouteFilterImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override async Task<RouteFilterInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override async Task<IPage<RouteFilterInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<RouteFilterInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<RouteFilterInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<RouteFilterInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}