// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerOutboundRule.UpdateDefinition
{
    /// <summary>
    /// The stage of a load balancer outbound rule definition allowing to specify the connection timeout for idle connections.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIdleTimeout<ReturnT>
    {
        /// <summary>
        /// Specifies the timeout for the TCP idle connection.
        /// </summary>
        /// <param name="timtoutInMinutes">The timeout in minutes.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ReturnT> WithIdleTimeoutInMinutes(int timtoutInMinutes);
    }

    /// <summary>
    /// The stage of a load balancer outbound rule definition allowing to specify 
    /// the bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTcpReset<ReturnT>
    {
        /// <summary>
        /// Specifies the bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ReturnT> WithEnableTcpReset();
    }

    /// <summary>
    /// The entirety of a load balancer outbound rule definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ReturnT> :
        IBlank<ReturnT>,
        IWithAttach<ReturnT>,
        IWithProtocol<ReturnT>,
        IWithFrontend<ReturnT>,
        IWithBackend<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancer outbound rule definition allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<IWithBackend<ReturnT>, Models.LoadBalancerOutboundRuleProtocol>
    {
    }

    /// <summary>
    /// The first stage of the load balancer outbound rule definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT> :
        IWithProtocol<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancer outbound rule definition allowing to specify the backend to associate the rule with.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackend<ReturnT>
    {
        /// <summary>
        /// Specifies a backend pool on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="backendName">The name of a backend.</param>
        /// <return>The next stage of the definition.</return>
        IWithFrontend<ReturnT> FromBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancer outbound rule definition allowing to specify the frontends to associate with the rule.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ReturnT>
    {
        /// <summary>
        /// Specifies the frontend on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="frontendName">The name of a frontend.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ReturnT> ToFrontend(string frontendName);

        /// <summary>
        /// Specifies the frontends on this load balancer for outbound traffic.
        /// </summary>
        /// <param name="frontendNames">The names of frontend.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ReturnT> ToFrontends(params string[] frontendNames);
    }

    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ReturnT>,
        IWithIdleTimeout<ReturnT>,
        IWithTcpReset<ReturnT>
    {
    }
}