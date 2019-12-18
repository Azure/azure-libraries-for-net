// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Express Route Circuit management API in Azure.
    /// </summary>
    public interface IExpressRouteCircuit :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.ExpressRouteCircuitInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ExpressRouteCircuit.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>
    {
        /// <summary>
        /// Gets the flag indicating if classic operations allowed.
        /// </summary>
        bool IsAllowClassicOperations { get; }

        /// <summary>
        /// Gets the CircuitProvisioningState state of the resource.
        /// </summary>
        string CircuitProvisioningState { get; }

        /// <summary>
        /// Gets the peerings associated with this express route circuit, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> PeeringsMap { get; }

        /// <summary>
        /// Gets the ServiceProviderNotes.
        /// </summary>
        string ServiceProviderNotes { get; }

        /// <summary>
        /// Gets entry point to manage express route peerings associated with express route circuit.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings Peerings { get; }

        /// <summary>
        /// Gets The ServiceProviderProvisioningState state of the resource.
        /// </summary>
        /// <summary>
        /// Gets serviceProviderProvisioningState.
        /// </summary>
        Models.ServiceProviderProvisioningState ServiceProviderProvisioningState { get; }

        /// <summary>
        /// Gets the ServiceKey.
        /// </summary>
        string ServiceKey { get; }

        /// <summary>
        /// Gets the provisioning state of the express route circuit resource.
        /// </summary>
        /// <summary>
        /// Gets provisioningState.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the SKU type.
        /// </summary>
        ExpressRouteCircuitSkuType Sku { get; }

        /// <summary>
        /// Gets the ServiceProviderProperties.
        /// </summary>
        Models.ExpressRouteCircuitServiceProviderProperties ServiceProviderProperties { get; }
    }
}