// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    using Newtonsoft.Json;

    internal class AzureCliToken
    {
        [JsonProperty(PropertyName = "_authority")]
        public string Authority { get; set; }

        [JsonProperty(PropertyName = "_clientId")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "tokenType")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expiresIn")]
        public long ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "expiresOn")]
        public string ExpiresOn { get; set; }

        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "servicePrincipalId")]
        public string ServicePrincipalId { get; set; }

        [JsonProperty(PropertyName = "servicePrincipalTenant")]
        public string ServicePrincipalTenant { get; set; }

        [JsonProperty(PropertyName = "isMRRT")]
        public bool IsMRRT { get; set; }

        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "identityProvider")]
        public string IdentityProvider { get; set; }

        public bool IsServicePrincipal()
        {
            return ServicePrincipalId != null;
        }

        public string Tenant()
        {
            if (IsServicePrincipal())
            {
                return ServicePrincipalTenant;
            }
            else
            {
                string[] parts = Authority.Split('/');
                return parts[parts.Length - 1];
            }
        }

        public string User()
        {
            if (IsServicePrincipal())
            {
                return ServicePrincipalId;
            }
            else
            {
                return UserId;
            }
        }

        public string ClientId()
        {
            if (IsServicePrincipal())
            {
                return ServicePrincipalId;
            }
            else
            {
                return Id;
            }
        }
    }
}
