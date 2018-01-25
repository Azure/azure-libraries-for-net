// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The entirety of an application gateway redirect configuration definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttachAndPath<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithType<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify whether the query string should be included in the redirected URL or other optional settings.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachAndPath<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithPathIncluded<ReturnT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway redirect configuration.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithType<ReturnT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway redirect configuration.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithQueryStringIncluded<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify the target URL or listener for the redirection.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithTarget<ReturnT>
    {
        /// <summary>
        /// Specifies the URL to redirect to.
        /// </summary>
        /// <param name="url">A URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ReturnT> WithTargetUrl(string url);

        /// <summary>
        /// Specifies the listener on this application gateway to redirect to.
        /// </summary>
        /// <param name="name">The name of a listener on this application gateway.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttachAndPath<ReturnT> WithTargetListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify whether the query string should be included in the redirected URL.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithQueryStringIncluded<ReturnT>
    {
        /// <summary>
        /// Specifies that the query string should be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ReturnT> WithQueryStringIncluded();
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify whether the path should be included in the redirected URL.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithPathIncluded<ReturnT>
    {
        /// <summary>
        /// Specifies that the path should be included in the redirected URL.
        /// Note that this setting is valid only when the target of the redirection is a listener, not a URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ReturnT> WithPathIncluded();
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify the type of the redirection.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithType<ReturnT>
    {
        /// <summary>
        /// Specifies the redirection type.
        /// </summary>
        /// <param name="redirectType">A redirection type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ReturnT> WithType(ApplicationGatewayRedirectType redirectType);
    }
}