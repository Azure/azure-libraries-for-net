// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// TokenProvider that can retrieve AD acess token from the local MSI port.
    /// </summary>
    public class MSITokenProvider : ITokenProvider, IBeta
    {
        private readonly string resource;
        private readonly MSILoginInformation msiLoginInformation;

        /// <summary>
        /// Creates MSITokenProvider.
        /// </summary>
        /// <param name="resource">the resource to access using the MSI token</param>
        /// <param name="msiLoginInformation">describes the managed service identity configuration</param>
        public MSITokenProvider(string resource, MSILoginInformation msiLoginInformation)
        {
            this.resource = resource ?? throw new ArgumentNullException("resource");
            this.msiLoginInformation = msiLoginInformation ?? throw new ArgumentNullException("msiLoginInformation");
            this.msiLoginInformation = msiLoginInformation;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            int port = msiLoginInformation.Port == null ? 50342 : msiLoginInformation.Port.Value;
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
            string tokenType = loginInfo.token_type;
            if (tokenType == null)
            {
                throw MSILoginException.TokenTypeNotFound(content);
            }
            string accessToken = loginInfo.access_token;
            if (accessToken == null)
            {
                throw MSILoginException.AcessTokenNotFound(content);
            }
            return new AuthenticationHeaderValue(tokenType, accessToken);
        }
    }
}
