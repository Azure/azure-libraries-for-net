// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// TokenProvider that can retrieve AD acess token from the local MSI port & IMDS service (for VM & VMSS) and
    /// from environment (for AppService).
    /// </summary>
    public class MSITokenProvider : ITokenProvider, IBeta
    {
        private readonly IList<int> retrySlots = new List<int>(new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 });
        private ConcurrentDictionary<string, MSIToken> cache = new ConcurrentDictionary<string, MSIToken>();
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        
        private readonly string resource;
        private readonly MSILoginInformation msiLoginInformation;

        private const string  imdsEndpoint = "http://169.254.169.254/metadata/identity/oauth2/token";
        private const int imdsUpgradeTimeInMs = 70 * 1000;
        private const string imdsMsiApiVersion = "2018-02-01";
        private const string appServiceMsiApiVersion = "2017-09-01";


        /// <summary>
        /// Creates MSITokenProvider.
        /// </summary>
        /// <param name="msiLoginInformation">describes the managed service identity configuration</param>
        public MSITokenProvider(string resource, MSILoginInformation msiLoginInformation)
        {
            this.resource = resource ?? throw new ArgumentNullException("resource");
            this.msiLoginInformation = msiLoginInformation ?? throw new ArgumentNullException("msiLoginInformation");
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            if (msiLoginInformation.ResourceType == MSIResourceType.VirtualMachine)
            {
                return await GetAuthenticationHeaderForVirtualMachineAsync(resource, cancellationToken);
            }
            else
            {
                return await GetAuthenticationHeaderForAppServiceAsync(resource, cancellationToken);
            }
        }

        private async Task<AuthenticationHeaderValue> GetAuthenticationHeaderForVirtualMachineAsync(string resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (msiLoginInformation.Port != null)
            {
                // Token retrival from VM extension will be removed in the next v1.10 release as IMDS service
                // replaces VM extension. MsiLoginInformation.Port is marked as deprecated and will be removed
                //
                var token = await GetTokenFromMSIExtensionAsync(msiLoginInformation.Port.Value, 
                    resource, 
                    cancellationToken);
                return new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
            }
            else
            {
                var token = await GetTokenFromIMDSEndpointAsync(resource, cancellationToken);
                return new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
            }
        }

        private async Task<AuthenticationHeaderValue> GetAuthenticationHeaderForAppServiceAsync(string resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            var endpoint = Environment.GetEnvironmentVariable("MSI_ENDPOINT") ?? throw new ArgumentNullException("MSI_ENDPOINT");
            var secret = Environment.GetEnvironmentVariable("MSI_SECRET") ?? throw new ArgumentNullException("MSI_SECRET");

            string extraQueryArgs = string.Empty;
            if (this.msiLoginInformation.UserAssignedIdentityClientId != null)
            {
                extraQueryArgs = $"{extraQueryArgs}&clientid={this.msiLoginInformation.UserAssignedIdentityClientId}";
            }
            else if (this.msiLoginInformation.UserAssignedIdentityObjectId != null || this.msiLoginInformation.UserAssignedIdentityResourceId != null)
            {
                throw new ArgumentException("UserAssignedIdentityObjectId/UserAssignedIdentityResourceId not supported in AppService environments");
            }

            HttpRequestMessage msiRequest = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}?resource={resource}&api-version={MSITokenProvider.appServiceMsiApiVersion}{extraQueryArgs}");
            msiRequest.Headers.Add("Metadata", "true");
            msiRequest.Headers.Add("Secret", secret);

            var msiResponse = await (new HttpClient()).SendAsync(msiRequest, cancellationToken);
            string content = await msiResponse.Content.ReadAsStringAsync();
            dynamic loginInfo = JsonConvert.DeserializeObject(content);
            string tokenType = loginInfo.token_type;
            if (tokenType == null)
            {
                throw MSILoginException.TokenTypeNotFound(content);
            }
            string accessToken = loginInfo.access_token;
            if (accessToken == null)
            {
                throw MSILoginException.AccessTokenNotFound(content);
            }
            return new AuthenticationHeaderValue(tokenType, accessToken);
        }

        private async Task<MSIToken> GetTokenFromMSIExtensionAsync(int port, string resource, CancellationToken cancellationToken)
        {
            HttpRequestMessage msiRequest = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:{port}/oauth2/token");
            msiRequest.Headers.Add("Metadata", "true");

            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "resource", $"{resource}" }
            };
            if (this.msiLoginInformation.UserAssignedIdentityObjectId != null)
            {
                parameters.Add("object_id", this.msiLoginInformation.UserAssignedIdentityObjectId);
            }
            else if (this.msiLoginInformation.UserAssignedIdentityClientId != null)
            {
                parameters.Add("client_id", this.msiLoginInformation.UserAssignedIdentityClientId);
            }
            else if (this.msiLoginInformation.UserAssignedIdentityResourceId != null)
            {
                parameters.Add("msi_res_id", this.msiLoginInformation.UserAssignedIdentityResourceId);
            }

            msiRequest.Content = new FormUrlEncodedContent(parameters);

            var msiResponse = await (new HttpClient()).SendAsync(msiRequest, cancellationToken);
            string content = await msiResponse.Content.ReadAsStringAsync();
            dynamic loginInfo = JsonConvert.DeserializeObject(content);
            if (loginInfo.access_token == null)
            {
                throw MSILoginException.AccessTokenNotFound(content);
            }
            if (loginInfo.token_type == null)
            {
                throw MSILoginException.TokenTypeNotFound(content);
            }
            //
            MSIToken msiToken = new MSIToken
            {
                AccessToken = loginInfo.access_token,
                TokenType = loginInfo.token_type
            };
            return msiToken;
        }

        private async Task<MSIToken> GetTokenFromIMDSEndpointAsync(string resource, CancellationToken cancellationToken)
        {
            // First hit cache
            //
            if (cache.TryGetValue(resource, out MSIToken token) == true && !token.IsExpired)
            {
                return token;
            }

            // if cache miss then retrieve from IMDS endpoint with retry
            //
            await semaphoreSlim.WaitAsync();
            try
            {
                // Try hit cache once again in case another thread already updated the cache while this thread was waiting
                //
                if (cache.TryGetValue(resource, out token) == true && !token.IsExpired)
                {
                    return token;
                }
                else
                {
                    token = await this.RetrieveTokenFromIMDSWithRetryAsync(resource, cancellationToken);
                    cache.AddOrUpdate(resource, token, (key, oldValue) => token);
                    return token;
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        private async Task<MSIToken> RetrieveTokenFromIMDSWithRetryAsync(string resource, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(MSITokenProvider.imdsEndpoint);
            //
            var query = new Dictionary<string, string>
            {
                ["api-version"] = MSITokenProvider.imdsMsiApiVersion,
                ["resource"] = resource
            };
            if (this.msiLoginInformation.UserAssignedIdentityObjectId != null)
            {
                query["object_id"] = this.msiLoginInformation.UserAssignedIdentityObjectId;
            }
            else if (this.msiLoginInformation.UserAssignedIdentityClientId != null)
            {
                query["client_id"] = this.msiLoginInformation.UserAssignedIdentityClientId;
            }
            else if (this.msiLoginInformation.UserAssignedIdentityResourceId != null)
            {
                query["msi_res_id"] = this.msiLoginInformation.UserAssignedIdentityResourceId;
            }
            
            uriBuilder.Query = await new FormUrlEncodedContent(query).ReadAsStringAsync();
            string url = uriBuilder.ToString();
            //
            int retry = 1;
            int maxRetry = retrySlots.Count;
            //
            while (retry <= maxRetry)
            {
                //
                using (HttpRequestMessage msiRequest = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    msiRequest.Headers.Add("Metadata", "true");
                    using (HttpResponseMessage msiResponse = await (new HttpClient()).SendAsync(msiRequest, cancellationToken))
                    {
                        int statusCode = ((int)msiResponse.StatusCode);
                        if (ShouldRetry(statusCode))
                        {

                            int retryTimeoutInMs = retrySlots[new Random().Next(retry)] * 1000;
                            retryTimeoutInMs = (statusCode == 410 && retryTimeoutInMs < imdsUpgradeTimeInMs) ? imdsUpgradeTimeInMs : retryTimeoutInMs;
                            retry++;
                            if (retry > maxRetry)
                            {
                                break;
                            }
                            else
                            {
                                await SdkContext.DelayProvider.DelayAsync(retryTimeoutInMs, cancellationToken);
                            }
                        }
                        else if (statusCode != 200)
                        {
                            string content = await msiResponse.Content.ReadAsStringAsync();
                            throw new HttpRequestException($"Code: {statusCode} ReasonReasonPhrase: {msiResponse.ReasonPhrase} Body: {content}");
                        }
                        else
                        {
                            string content = await msiResponse.Content.ReadAsStringAsync();
                            dynamic loginInfo = JsonConvert.DeserializeObject(content);
                            if (loginInfo.access_token == null)
                            {
                                throw MSILoginException.AccessTokenNotFound(content);
                            }
                            if (loginInfo.token_type == null)
                            {
                                throw MSILoginException.TokenTypeNotFound(content);
                            }
                            //
                            MSIToken msiToken = new MSIToken
                            {
                                AccessToken = loginInfo.access_token,
                                ExpireOn = loginInfo.expires_on,
                                TokenType = loginInfo.token_type
                            };
                            return msiToken;
                        }
                    }
                }
            }
            throw new MSIMaxRetryReachedException(maxRetry);
        }

        private static bool ShouldRetry(int statusCode)
        {
            return (statusCode == 410 || statusCode == 429 || statusCode == 404 || (statusCode >= 500 && statusCode <= 599));
        }

        private class MSIToken
        {
            private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            public string TokenType { get; set; }

            public string AccessToken { get; set; }

            public string ExpireOn { get; set; }

            public bool IsExpired
            {
                get
                {
                    if (this.ExpireOn == null)
                    {
                        return true;
                    }
                    else if (!Int32.TryParse(this.ExpireOn, out int iexpireOn))
                    {
                        return true;
                    }
                    else
                    {
                        return DateTime.UtcNow.AddMinutes(5).CompareTo(epoch.AddSeconds(iexpireOn)) > 0;
                    }
                }
            }
        }
    }

    public class MSITokenProviderFactory: IBeta
    {
        private readonly MSILoginInformation msiLoginInformation;

        public MSITokenProviderFactory(MSILoginInformation msiLoginInformation)
        {
            this.msiLoginInformation = msiLoginInformation ?? throw new ArgumentNullException("msiLoginInformation");
        }

        public MSITokenProvider Create(string resource)
        {
            return new MSITokenProvider(resource, msiLoginInformation);
        }
    }

    public class MSIMaxRetryReachedException : Exception
    {
        public MSIMaxRetryReachedException(int maxRetry) : base($"MSI: Failed to acquire tokens after retrying %{ maxRetry} times")
        {
        }
    }
}
