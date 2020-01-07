// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for private link service management API in Azure.
    /// </summary>
    public interface IPrivateLinkService :
        IGroupableResource<INetworkManager, PrivateLinkServiceInner>,
        IRefreshable<IPrivateLinkService>,
        IUpdatable<PrivateLinkService.Update.IUpdate>
    {
        /// <summary>
        /// Gets an array of references to the load balancer IP configurations.
        /// </summary>
        IReadOnlyList<ILoadBalancerFrontend> LoadBalancerFrontendIpConfigurations { get; }

        /// <summary>
        /// Gets an array of private link service IP configurations.
        /// </summary>
        IReadOnlyList<IPrivateLinkServiceIPConfiguration> IpConfigurations { get; }

        /// <summary>
        /// Gets an array of references to the network interfaces created for this private link service.
        /// </summary>
        IReadOnlyList<INetworkInterface> NetworkInterfaces { get; }

        /// <summary>
        /// Gets the provisioning state of the private link service resource.
        /// Possible values include: 'Succeeded', 'Updating', 'Deleting',
        /// 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets an array of list about connections to the private endpoint.
        /// </summary>
        IReadOnlyList<IPrivateEndpointConnection> PrivateEndpointConnections { get; }

        /// <summary>
        /// Gets the visibility list of the private link service.
        /// </summary>
        IReadOnlyList<string> VisiblePrivateLinkServiceIds { get; }

        /// <summary>
        /// Gets the auto-approval list of the private link service.
        /// </summary>
        IReadOnlyList<string> AutoApprovedPrivateLinkServiceIds { get; }

        /// <summary>
        /// Gets the list of Fqdn.
        /// </summary>
        IReadOnlyList<string> Fqdns { get; }

        /// <summary>
        /// Gets the alias of the private link service.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Gets whether the private link service is enabled for proxy protocol or not.
        /// </summary>
        bool IsProxyProtocolEnabled { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        string Etag { get; }
    }
}
