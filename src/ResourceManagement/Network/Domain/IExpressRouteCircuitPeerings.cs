// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for express route circuit peerings management API in Azure.
    /// </summary>
    public interface IExpressRouteCircuitPeerings :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IExpressRouteCircuitPeeringsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>
    {
        /// <summary>
        /// Begins definition of Microsoft peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IWithAdvertisedPublicPrefixes DefineMicrosoftPeering();

        /// <summary>
        /// Begins definition of Azure public peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IBlank DefineAzurePublicPeering();

        /// <summary>
        /// Begins definition of Azure private peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IBlank DefineAzurePrivatePeering();
    }
}