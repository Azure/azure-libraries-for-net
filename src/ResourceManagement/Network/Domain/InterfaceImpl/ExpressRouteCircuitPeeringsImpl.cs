// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    internal partial class ExpressRouteCircuitPeeringsImpl
    {
        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByNameAsync(string name, CancellationToken cancellationToken)
        {

            await this.DeleteByNameAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByName(string name)
        {

            this.DeleteByName(name);
        }

        /// <summary>
        /// Begins definition of Azure private peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IBlank Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings.DefineAzurePrivatePeering()
        {
            return this.DefineAzurePrivatePeering();
        }

        /// <summary>
        /// Begins definition of Azure public peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IBlank Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings.DefineAzurePublicPeering()
        {
            return this.DefineAzurePublicPeering();
        }

        /// <summary>
        /// Begins definition of Microsoft peering.
        /// </summary>
        /// <return>Next peering definition stage.</return>
        ExpressRouteCircuitPeering.Definition.IWithAdvertisedPublicPrefixes Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings.DefineMicrosoftPeering()
        {
            return this.DefineMicrosoftPeering();
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IExpressRouteCircuitPeering>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>.GetByName(string name)
        {
            return this.GetByName(name);
        }

        /// <summary>
        /// Gets the information about a resource based on the resource name.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(name, cancellationToken);
        }
    }
}