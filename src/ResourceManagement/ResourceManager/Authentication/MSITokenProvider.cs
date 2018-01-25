// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest;
using Newtonsoft.Json;
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
        private string resource;
        private int? port;

        /// <summary>
        /// Creates MSITokenProvider.
        /// </summary>
        /// <param name="resource">the resource to access using the MSI token</param>
        /// <param name="port">the local endpoint port to retrieve the token from</param>
        public MSITokenProvider(string resource, int? port = 50342)
        {
            this.resource = resource;
            this.port = port;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            HttpRequestMessage msiRequest = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:{port}/oauth2/token");
            msiRequest.Headers.Add("Metadata", "true");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("resource", $"{resource}");
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
