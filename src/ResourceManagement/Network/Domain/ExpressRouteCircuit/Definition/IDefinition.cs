// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of express route circuit definition allowing to specify service provider peering location.
    /// </summary>
    public interface IWithPeeringLocation
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithBandwidth WithPeeringLocation(string location);
    }

    /// <summary>
    /// The stage of definition allowing to add authorization.
    /// </summary>
    public interface IWithAuthorization
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithCreate WithAuthorization(string authorizationName);
    }

    /// <summary>
    /// The stage of express route circuit definition allowing to enable/disable classic operations.
    /// </summary>
    public interface IWithAllowClassicOperations
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithCreate WithClassicOperations();
    }

    /// <summary>
    /// The first stage of express route circuit definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of express route circuit definition allowing to specify SKU tier and family.
    /// </summary>
    public interface IWithSku
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithCreate WithSku(ExpressRouteCircuitSkuType skuType);
    }

    /// <summary>
    /// The entirety of the express route circuit definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithServiceProvider,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithPeeringLocation,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithBandwidth,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of express route circuit definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithServiceProvider>
    {
    }

    /// <summary>
    /// The stage of the express route circuit definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithAllowClassicOperations,
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithAuthorization
    {
    }

    /// <summary>
    /// The stage of express route circuit definition allowing to specify service provider name.
    /// </summary>
    public interface IWithServiceProvider
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithPeeringLocation WithServiceProvider(string serviceProviderName);
    }

    /// <summary>
    /// The stage of express route circuit definition allowing to specify service provider bandwidth.
    /// </summary>
    public interface IWithBandwidth
    {
        Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition.IWithSku WithBandwidthInMbps(int bandwidthInMbps);
    }
}