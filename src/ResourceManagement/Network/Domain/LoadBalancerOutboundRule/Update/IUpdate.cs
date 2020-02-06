// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerOutboundRule.Update
{
    /// <summary>
    /// The stage of a load balancer outbound rule update allowing to specify the connection timeout for idle connections.
    /// </summary>
    public interface IWithIdleTimeout
    {
        /// <summary>
        /// Specifies the timeout for the TCP idle connection.
        /// </summary>
        /// <param name="timtoutInMinutes">The timeout in minutes.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithIdleTimeoutInMinutes(int timtoutInMinutes);
    }

    /// <summary>
    /// The stage of a load balancer outbound rule update allowing to specify 
    /// the bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
    /// </summary>
    public interface IWithTcpReset
    {
        /// <summary>
        /// Specifies the bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        /// <param name="enable">Whether the TCP Reset is enabled or not.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithEnableTcpReset(bool enable);
    }

    /// <summary>
    /// The stage of a load balancer outbound rule update allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    public interface IWithProtocol :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<IUpdate, Models.LoadBalancerOutboundRuleProtocol>
    {
    }

    /// <summary>
    /// The stage of a load balancer outbound rule update allowing to specify the backend to associate the rule with.
    /// </summary>
    public interface IWithBackend
    {
        /// <summary>
        /// Specifies a backend pool on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="backendName">The name of a backend.</param>
        /// <return>The next stage of the update.</return>
        IUpdate FromBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancer outbound rule update allowing to specify the frontends to associate with the rule.
    /// </summary>
    public interface IWithFrontend
    {
        /// <summary>
        /// Specifies the frontend on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="frontendName">The name of a frontend.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate ToFrontend(string frontendName);

        /// <summary>
        /// Specifies the frontends on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="frontendNames">The names of frontend.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate ToFrontends(params string[] frontendNames);
    }

    /// <summary>
    /// The entirety of a load balancer outbound rule update as part of a load balancer update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<LoadBalancer.Update.IUpdate>,
        IWithProtocol,
        IWithBackend,
        IWithFrontend,
        IWithIdleTimeout,
        IWithTcpReset
    {
    }
}