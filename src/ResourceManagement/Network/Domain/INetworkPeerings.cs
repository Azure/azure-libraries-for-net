// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NetworkPeering.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to network peering management API.
    /// </summary>
    public interface INetworkPeerings :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NetworkPeering.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByParent,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkPeering>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Network.Fluent.IVirtualNetworkPeeringsOperations>
    {
        /// <summary>
        /// Asynchronously finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>A representation of the future computation of this call, evaluating to null if no such peering is found.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> GetByRemoteNetworkAsync(INetwork network, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="remoteNetworkResourceId">The resource ID of an existing network.</param>
        /// <return>A representation of the future computation of this call, evaluating to null if no such peering is found.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.INetworkPeering> GetByRemoteNetworkAsync(string remoteNetworkResourceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <return>A network peering, or null if none exists.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering GetByRemoteNetwork(INetwork network);

        /// <summary>
        /// Finds the peering, if any, that is associated with the specified network.
        /// (Note that this makes a separate call to Azure.).
        /// </summary>
        /// <param name="remoteNetworkResourceId">The resource ID of an existing network.</param>
        /// <return>A network peering, or null if none exists.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeering GetByRemoteNetwork(string remoteNetworkResourceId);
    }
}