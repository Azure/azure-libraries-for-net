// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    internal class AzureCliSubscription
    {
        [JsonProperty(PropertyName = "environmentName")]
        public string EnvironmentName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "user")]
        public UserInfo User { get; set; }

        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "isDefault")]
        public bool IsDefault { get; set; }


        private AzureCliToken azureCliToken;

        public bool IsServicePrincipal()
        {
            return string.Equals(User.Type, "ServicePrincipal", StringComparison.OrdinalIgnoreCase);
        }

        public string UserName()
        {
            return User.Name;
        }

        public AzureCliSubscription WithToken(AzureCliToken token)
        {
            if (ClientId == null)
            {
                ClientId = token.ClientId();
            }  
            azureCliToken = token;
            return this;
        }

        public AzureCliToken Token()
        {
            return azureCliToken;
        }

        public AzureEnvironment Environment()
        {
            if (EnvironmentName == null)
            {
                return null;
            }
            else if (string.Equals(EnvironmentName, "AzureCloud", StringComparison.OrdinalIgnoreCase))
            {
                return AzureEnvironment.AzureGlobalCloud;
            }
            else if (string.Equals(EnvironmentName, "AzureChinaCloud", StringComparison.OrdinalIgnoreCase))
            {
                return AzureEnvironment.AzureChinaCloud;
            }
            else if (string.Equals(EnvironmentName, "AzureGermanCloud", StringComparison.OrdinalIgnoreCase))
            {
                return AzureEnvironment.AzureGermanCloud;
            }
            else if (string.Equals(EnvironmentName, "AzureUSGovernment", StringComparison.OrdinalIgnoreCase))
            {
                return AzureEnvironment.AzureUSGovernment;
            }
            else
            {
                return null;
            }
        }
    }

    internal class UserInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    internal class AzureCliSubscriptionWrapper
    {
        [JsonProperty(PropertyName = "subscriptions")]
        public IEnumerable<AzureCliSubscription> Subscriptions { get; set; }
    }
}
