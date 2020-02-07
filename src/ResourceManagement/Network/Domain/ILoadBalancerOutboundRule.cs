// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an outbound rule of the load balancer.
    /// </summary>
    public interface ILoadBalancerOutboundRule :
        IHasInner<OutboundRuleInner>,
        IChildResource<ILoadBalancer>,
        IHasProtocol<LoadBalancerOutboundRuleProtocol>
    {
        /// <summary>
        /// Gets the frontend IP addresses.
        /// </summary>
        IReadOnlyList<ILoadBalancerFrontend> Frontends { get; }

        /// <summary>
        /// Gets the backend pool of DIPs. Outbound traffic is
        /// randomly load balanced across IPs in the backend IPs.
        /// </summary>
        ILoadBalancerBackend Backend { get; }

        /// <summary>
        /// Gets the timeout for the TCP idle connection.
        /// </summary>
        int IdleTimeoutInMinutes { get; }

        /// <summary>
        /// Gets receive bidirectional TCP Reset on TCP flow idle
        /// timeout or unexpected connection termination. This element is only
        /// used when the protocol is set to TCP.
        /// </summary>
        bool TcpResetEnabled { get; }
    }
}
