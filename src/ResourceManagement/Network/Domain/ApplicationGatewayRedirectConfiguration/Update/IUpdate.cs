// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify the type of the redirection.
    /// </summary>
    public interface IWithType
    {
        /// <summary>
        /// Specifies the redirection type.
        /// </summary>
        /// <param name="redirectType">A redirection type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithType(ApplicationGatewayRedirectType redirectType);
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify whether the path should be included in the redirected URL.
    /// </summary>
    public interface IWithPathIncluded
    {
        /// <summary>
        /// Specifies that the path should be included in the redirected URL.
        /// Note that this setting is valid only when the target of the redirection is a listener, not a URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithPathIncluded();

        /// <summary>
        /// Specifies that the path should not be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithoutPathIncluded();
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify the target URL or listener for the redirection.
    /// </summary>
    public interface IWithTarget
    {
        /// <summary>
        /// Removes the reference to the target listener.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithoutTargetListener();

        /// <summary>
        /// Specifies the URL to redirect to.
        /// </summary>
        /// <param name="url">A URL.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithTargetUrl(string url);

        /// <summary>
        /// Removes the reference to the target URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithoutTargetUrl();

        /// <summary>
        /// Specifies the listener on this application gateway to redirect to.
        /// </summary>
        /// <param name="name">The name of a listener on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithTargetListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway redirect configuration allowing to specify whether the query string should be included in the redirected URL.
    /// </summary>
    public interface IWithQueryStringIncluded
    {
        /// <summary>
        /// Specifies that the query string should be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithQueryStringIncluded();

        /// <summary>
        /// Specifies that the query string should not be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate WithoutQueryStringIncluded();
    }

    /// <summary>
    /// The entirety of an application gateway redirect configuration update as part of an application gateway update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IWithTarget,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IWithType,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IWithPathIncluded,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IWithQueryStringIncluded
    {
    }
}