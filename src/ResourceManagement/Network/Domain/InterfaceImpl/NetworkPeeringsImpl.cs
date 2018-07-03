// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class NetworkPeeringsImpl
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        NetworkPeering.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NetworkPeering.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Asynchronously finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>A representation of the future computation of this call, evaluating to null if no such peering is found.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> Microsoft.Azure.Management.Network.Fluent.INetworkPeerings.GetByRemoteNetworkAsync(INetwork network, CancellationToken cancellationToken)
        {
            return await this.GetByRemoteNetworkAsync(network, cancellationToken);
        }

        /// <summary>
        /// Asynchronously finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="remoteNetworkResourceId">The resource ID of an existing network.</param>
        /// <return>A representation of the future computation of this call, evaluating to null if no such peering is found.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> Microsoft.Azure.Management.Network.Fluent.INetworkPeerings.GetByRemoteNetworkAsync(string remoteNetworkResourceId, CancellationToken cancellationToken)
        {
            return await this.GetByRemoteNetworkAsync(remoteNetworkResourceId, cancellationToken);
        }

        /// <summary>
        /// Finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>A network peering, or null if none exists.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering Microsoft.Azure.Management.Network.Fluent.INetworkPeerings.GetByRemoteNetwork(INetwork network)
        {
            return this.GetByRemoteNetwork(network);
        }

        /// <summary>
        /// Finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="remoteNetworkResourceId">The resource ID of an existing network.</param>
        /// <return>A network peering, or null if none exists.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering Microsoft.Azure.Management.Network.Fluent.INetworkPeerings.GetByRemoteNetwork(string remoteNetworkResourceId)
        {
            return this.GetByRemoteNetwork(remoteNetworkResourceId);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">The group the resource is part of.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByParent.DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken)
        {

            await this.DeleteByParentAsync(groupName, parentName, name, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<INetworkPeering>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }
    }
}