// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
    {
        /// <summary>
        /// Adds an external redirect URL.
        /// </summary>
        /// <param name="url">The external redirect URL.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithExternalRedirectUrls<WebAppBase.Definition.IWithCreate<FluentT>>.WithAllowedExternalRedirectUrl(string url)
        {
            return this.WithAllowedExternalRedirectUrl(url);
        }

        /// <summary>
        /// Adds an external redirect URL.
        /// </summary>
        /// <param name="url">The external redirect URL.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithExternalRedirectUrls<WebAppBase.Update.IUpdate<FluentT>>.WithAllowedExternalRedirectUrl(string url)
        {
            return this.WithAllowedExternalRedirectUrl(url);
        }

        /// <summary>
        /// Does not require login by default.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithDefaultAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithAnonymousAuthentication()
        {
            return this.WithAnonymousAuthentication();
        }

        /// <summary>
        /// Specifies the default authentication provider.
        /// </summary>
        /// <param name="provider">The default authentication provider.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithDefaultAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider)
        {
            return this.WithDefaultAuthenticationProvider(provider);
        }

        /// <summary>
        /// Does not require login by default.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithDefaultAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithAnonymousAuthentication()
        {
            return this.WithAnonymousAuthentication();
        }

        /// <summary>
        /// Specifies the default authentication provider.
        /// </summary>
        /// <param name="provider">The default authentication provider.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithDefaultAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider)
        {
            return this.WithDefaultAuthenticationProvider(provider);
        }

        /// <summary>
        /// Specifies the provider to be Active Directory and its client ID and issuer URL.
        /// </summary>
        /// <param name="clientId">The AAD app's client ID.</param>
        /// <param name="issuerUrl">The token issuer URL in the format of https://sts.windows.net/(tenantId).</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithActiveDirectory(string clientId, string issuerUrl)
        {
            return this.WithActiveDirectory(clientId, issuerUrl);
        }

        /// <summary>
        /// Specifies the provider to be Microsoft and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Microsoft app's client ID.</param>
        /// <param name="clientSecret">The Microsoft app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithMicrosoft(string clientId, string clientSecret)
        {
            return this.WithMicrosoft(clientId, clientSecret);
        }

        /// <summary>
        /// Specifies the provider to be Twitter and its API key and API secret.
        /// </summary>
        /// <param name="apiKey">The Twitter app's API key.</param>
        /// <param name="apiSecret">The Twitter app's API secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithTwitter(string apiKey, string apiSecret)
        {
            return this.WithTwitter(apiKey, apiSecret);
        }

        /// <summary>
        /// Specifies the provider to be Google and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Google app's client ID.</param>
        /// <param name="clientSecret">The Google app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithGoogle(string clientId, string clientSecret)
        {
            return this.WithGoogle(clientId, clientSecret);
        }

        /// <summary>
        /// Specifies the provider to be Facebook and its app ID and app secret.
        /// </summary>
        /// <param name="appId">The Facebook app ID.</param>
        /// <param name="appSecret">The Facebook app secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithFacebook(string appId, string appSecret)
        {
            return this.WithFacebook(appId, appSecret);
        }

        /// <summary>
        /// Specifies the provider to be Active Directory and its client ID and issuer URL.
        /// </summary>
        /// <param name="clientId">The AAD app's client ID.</param>
        /// <param name="issuerUrl">The token issuer URL in the format of https://sts.windows.net/(tenantId).</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithActiveDirectory(string clientId, string issuerUrl)
        {
            return this.WithActiveDirectory(clientId, issuerUrl);
        }

        /// <summary>
        /// Specifies the provider to be Microsoft and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Microsoft app's client ID.</param>
        /// <param name="clientSecret">The Microsoft app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithMicrosoft(string clientId, string clientSecret)
        {
            return this.WithMicrosoft(clientId, clientSecret);
        }

        /// <summary>
        /// Specifies the provider to be Twitter and its API key and API secret.
        /// </summary>
        /// <param name="apiKey">The Twitter app's API key.</param>
        /// <param name="apiSecret">The Twitter app's API secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithTwitter(string apiKey, string apiSecret)
        {
            return this.WithTwitter(apiKey, apiSecret);
        }

        /// <summary>
        /// Specifies the provider to be Google and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Google app's client ID.</param>
        /// <param name="clientSecret">The Google app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithGoogle(string clientId, string clientSecret)
        {
            return this.WithGoogle(clientId, clientSecret);
        }

        /// <summary>
        /// Specifies the provider to be Facebook and its app ID and app secret.
        /// </summary>
        /// <param name="appId">The Facebook app ID.</param>
        /// <param name="appSecret">The Facebook app secret.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithFacebook(string appId, string appSecret)
        {
            return this.WithFacebook(appId, appSecret);
        }

        /// <summary>
        /// Specifies if token store should be enabled.
        /// </summary>
        /// <param name="enabled">True if token store should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithTokenStore<WebAppBase.Definition.IWithCreate<FluentT>>.WithTokenStore(bool enabled)
        {
            return this.WithTokenStore(enabled);
        }

        /// <summary>
        /// Specifies if token store should be enabled.
        /// </summary>
        /// <param name="enabled">True if token store should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithTokenStore<WebAppBase.Update.IUpdate<FluentT>>.WithTokenStore(bool enabled)
        {
            return this.WithTokenStore(enabled);
        }

        WebAppAuthentication.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppAuthentication.Definition.IWithAuthenticationProvider<WebAppBase.Definition.IWithCreate<FluentT>>.WithActiveDirectory(string clientId, string clientSecret, string issuerUrl)
        {
            return this.WithActiveDirectory(clientId, clientSecret, issuerUrl);
        }

        WebAppAuthentication.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<WebAppBase.Update.IUpdate<FluentT>>.WithActiveDirectory(string clientId, string clientSecret, string issuerUrl)
        {
            return this.WithActiveDirectory(clientId, clientSecret, issuerUrl);
        }

    }
}