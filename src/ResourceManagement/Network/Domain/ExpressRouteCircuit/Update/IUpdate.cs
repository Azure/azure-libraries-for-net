// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The stage of express route circuit update allowing to enable/disable classic operations.
    /// </summary>
    public interface IWithAllowClassicOperations
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate WithoutClassicOperations();

        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate WithClassicOperations();
    }

    /// <summary>
    /// The stage of express route circuit update allowing to add authorization.
    /// </summary>
    public interface IWithAuthorization
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate WithAuthorization(string authorizationName);
    }

    /// <summary>
    /// The template for a express route circuit update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IWithBandwidth,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IWithAllowClassicOperations,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IWithAuthorization
    {
    }

    /// <summary>
    /// The stage of express route circuit update allowing to specify SKU tier and family.
    /// </summary>
    public interface IWithSku
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate WithSku(ExpressRouteCircuitSkuType sku);
    }

    /// <summary>
    /// The stage of express route circuit update allowing to specify service provider bandwidth.
    /// </summary>
    public interface IWithBandwidth
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update.IUpdate WithBandwidthInMbps(int bandwidthInMbps);
    }
}