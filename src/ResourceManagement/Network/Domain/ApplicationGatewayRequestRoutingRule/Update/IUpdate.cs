// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The entirety of an application gateway request routing rule update as part of an application gateway update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithListener,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithBackendHttpConfiguration,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithSslCertificate,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithSslPassword,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithRedirectConfig
    {
    }

    /// <summary>
    /// The stage of an application gateway request routing rule allowing to specify an SSL certificate.
    /// </summary>
    public interface IWithSslCertificate :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update.IWithSslCertificate<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway request routing rule allowing to specify password of the SSL certificate pfx file.
    /// </summary>
    public interface IWithSslPassword :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update.IWithSslPassword<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify the backend to associate the routing rule with.
    /// </summary>
    public interface IWithBackend
    {
        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the specified backend does not yet exist, it will be automatically created.
        /// </summary>
        /// <param name="name">The name of a backend.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate ToBackend(string name);
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to associate the rule with a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfig :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IWithRedirectConfigBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify an existing listener to
    /// associate the routing rule with.
    /// </summary>
    public interface IWithListener
    {
        /// <summary>
        /// Associates the request routing rule with an existing frontend listener.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate FromListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify the backend HTTP settings configuration
    /// to associate the routing rule with.
    /// </summary>
    public interface IWithBackendHttpConfiguration
    {
        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate ToBackendHttpConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to associate the rule with a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfigBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Associates the specified redirect configuration with this request routing rule.
        /// Note that no backend can be associated with this request routing rule if it has a redirect configuration assigned to it,
        /// so this will also remove any backend and backend HTTP settings configuration.
        /// </summary>
        /// <param name="name">The name of a redirect configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate WithRedirectConfiguration(string name);

        /// <summary>
        /// Removes the association with a redirect configuration, if any.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate WithoutRedirectConfiguration();
    }
}