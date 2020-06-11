// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
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

        public AzureCredentials(MSILoginInformation msiLoginInformation, AzureEnvironment environment, string tenantId = null)
            : this(tenantId: tenantId, environment: environment)
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
            credentialsCache = new ConcurrentDictionary<Uri, ServiceClientCredentials>();
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

            string host = request.RequestUri.Host;
            if (host.EndsWith(Environment.KeyVaultSuffix, StringComparison.OrdinalIgnoreCase))
            {
                var resource = new Uri(Regex.Replace(Environment.KeyVaultSuffix, "^.", "https://"));
                if (credentialsCache.ContainsKey(new Uri(Regex.Replace(Environment.KeyVaultSuffix, "^.", "https://"))))
                {
                    adSettings.TokenAudience = resource;
                }
                else
                {
                    using (var r = new HttpRequestMessage(request.Method, url))
                    {
                        var response = await new HttpClient().SendAsync(r).ConfigureAwait(false);

                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate != null)
                        {
                            var header = response.Headers.WwwAuthenticate.ElementAt(0).ToString();
                            var regex = new Regex("authorization=\"([^\"]+)\"");
                            var match = regex.Match(header);
                            adSettings.AuthenticationEndpoint = new Uri(match.Groups[1].Value);
                            regex = new Regex("resource=\"([^\"]+)\"");
                            match = regex.Match(header);
                            adSettings.TokenAudience = new Uri(match.Groups[1].Value);
                        }
                    }
                }
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
                        IdentityModel.Clients.ActiveDirectory.ClientAssertionCertificate clientAssertionCertificate = 
                            new IdentityModel.Clients.ActiveDirectory.ClientAssertionCertificate(servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.X509Certificate);
                        CertificateAuthenticationProvider certificateAuthenticationProvider = 
                            new CertificateAuthenticationProvider(clientAssertionCertificate, servicePrincipalLoginInformation.IsCertificateRollOverEnabled);

                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, certificateAuthenticationProvider, adSettings, TokenCache.DefaultShared);
                    }
                    else if (servicePrincipalLoginInformation.Certificate != null)
                    {
                        IdentityModel.Clients.ActiveDirectory.ClientAssertionCertificate clientAssertionCertificate = 
                            new IdentityModel.Clients.ActiveDirectory.ClientAssertionCertificate(
                                servicePrincipalLoginInformation.ClientId,
                                new X509Certificate2(servicePrincipalLoginInformation.Certificate, servicePrincipalLoginInformation.CertificatePassword));
                        CertificateAuthenticationProvider certificateAuthenticationProvider = 
                            new CertificateAuthenticationProvider(clientAssertionCertificate, servicePrincipalLoginInformation.IsCertificateRollOverEnabled);

                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, certificateAuthenticationProvider, adSettings, TokenCache.DefaultShared);
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

#if !NET45
        class CertificateAuthenticationProvider : IApplicationAuthenticationProvider
        {
            private IClientAssertionCertificate certificate;
            private bool isCertRollOverEnabled;

            public CertificateAuthenticationProvider(IClientAssertionCertificate certificate, bool isCertRollOverEnabled)
            {
                this.certificate = certificate;
                this.isCertRollOverEnabled = isCertRollOverEnabled;
            }

            public Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context)
            {
                return context.AcquireTokenAsync(audience, certificate, isCertRollOverEnabled);
            }
        }
#endif
    }
}