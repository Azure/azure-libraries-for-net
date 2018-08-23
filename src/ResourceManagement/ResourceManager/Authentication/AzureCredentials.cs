// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Credentials used for authenticating a fluent management client to Azure.
    /// </summary>
    public class AzureCredentials : ServiceClientCredentials
    {
        private ServicePrincipalLoginInformation servicePrincipalLoginInformation;
        private MSITokenProviderFactory msiTokenProviderFactory;
        private IDictionary<Uri, ServiceClientCredentials> credentialsCache;
#if NET45
        private UserLoginInformation userLoginInformation;
#else
        private DeviceCredentialInformation deviceCredentialInformation;
#endif

        public string DefaultSubscriptionId { get; private set; }

        public string TenantId { get; private set; }

        public string ClientId
        {
            get
            {
#if NET45
                if (userLoginInformation != null && userLoginInformation.ClientId != null)
                {
                    return userLoginInformation.ClientId;
                }
#else
                if (deviceCredentialInformation != null && deviceCredentialInformation.ClientId != null)
                {
                    return deviceCredentialInformation.ClientId;
                }
#endif

                return servicePrincipalLoginInformation?.ClientId;
            }
        }

        public AzureEnvironment Environment { get; private set; }

#if NET45
        public AzureCredentials(UserLoginInformation userLoginInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.userLoginInformation = userLoginInformation;
        }
#else
        public AzureCredentials(DeviceCredentialInformation deviceCredentialInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.deviceCredentialInformation = deviceCredentialInformation;

        }
#endif

        public AzureCredentials(ServicePrincipalLoginInformation servicePrincipalLoginInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.servicePrincipalLoginInformation = servicePrincipalLoginInformation;
        }

        public AzureCredentials(MSILoginInformation msiLoginInformation, AzureEnvironment environment)
            : this(tenantId: null, environment: environment)
        {
            this.msiTokenProviderFactory = new MSITokenProviderFactory(msiLoginInformation);
        }

        public AzureCredentials(
            ServiceClientCredentials armCredentials,
            ServiceClientCredentials graphCredentials,
            string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            if (armCredentials != null)
            {
                credentialsCache[new Uri(Environment.ManagementEndpoint)] = armCredentials;
            }
            if (graphCredentials != null)
            {
                credentialsCache[new Uri(Environment.GraphEndpoint)] = graphCredentials;
            }
        }

        private AzureCredentials(string tenantId, AzureEnvironment environment)
        {
            TenantId = tenantId;
            Environment = environment;
            credentialsCache = new Dictionary<Uri, ServiceClientCredentials>();
        }

        public AzureCredentials WithDefaultSubscription(string subscriptionId)
        {
            DefaultSubscriptionId = subscriptionId;
            return this;
        }

        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(Environment.AuthenticationEndpoint),
                TokenAudience = new Uri(Environment.ManagementEndpoint),
                ValidateAuthority = true
            };
            string url = request.RequestUri.ToString();
            if (url.StartsWith(Environment.GraphEndpoint, StringComparison.OrdinalIgnoreCase))
            {
                adSettings.TokenAudience = new Uri(Environment.GraphEndpoint);
            }

            if (!credentialsCache.ContainsKey(adSettings.TokenAudience))
            {
                if (servicePrincipalLoginInformation != null)
                {
                    if(servicePrincipalLoginInformation.ClientId == null)
                    {
                        throw new RestException($"Cannot communicate with server. ServicePrincipalLoginInformation should contain a valid ClientId information.");
                    }
                    if (servicePrincipalLoginInformation.ClientSecret != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.ClientSecret, adSettings, TokenCache.DefaultShared);
                    }
#if NET45
                    else if (servicePrincipalLoginInformation.X509Certificate != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, new ClientAssertionCertificate(servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.X509Certificate), adSettings, TokenCache.DefaultShared);
                    }
#else
                    else if (servicePrincipalLoginInformation.X509Certificate != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, new Microsoft.Rest.Azure.Authentication.ClientAssertionCertificate(servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.X509Certificate), adSettings, TokenCache.DefaultShared);
                    }
#endif
                    else if (servicePrincipalLoginInformation.Certificate != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.Certificate, servicePrincipalLoginInformation.CertificatePassword, adSettings, TokenCache.DefaultShared);
                    }
                    else
                    {
                        throw new RestException($"Cannot communicate with server. ServicePrincipalLoginInformation should contain either a valid ClientSecret or Certificate information.");
                    }
                }
#if NET45
                else if (userLoginInformation != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginSilentAsync(
                        userLoginInformation.ClientId, TenantId, userLoginInformation.UserName,
                        userLoginInformation.Password, adSettings, TokenCache.DefaultShared);
                }
#else
                else if (deviceCredentialInformation != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginByDeviceCodeAsync(
                        deviceCredentialInformation.ClientId, TenantId, adSettings, TokenCache.DefaultShared, deviceCredentialInformation.DeviceCodeFlowHandler);
                }
#endif
                else if (msiTokenProviderFactory != null)
                {
                    credentialsCache[adSettings.TokenAudience] = new TokenCredentials(this.msiTokenProviderFactory.Create(adSettings.TokenAudience.OriginalString));
                }
                // no token available for communication
                else
                {
                    throw new RestException($"Cannot communicate with server. No authentication token available for '{adSettings.TokenAudience}'.");
                }
            }
            await credentialsCache[adSettings.TokenAudience].ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}