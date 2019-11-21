// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
#if NETSTANDARD1_4
    using System.Runtime.InteropServices;
#endif

    public class AzureCliCredentials
    {
        private static readonly string userProfile = "%USERPROFILE%";
        private static readonly string home = "HOME";
        private static readonly string azureCliFolder = ".azure";
        private static readonly string azureProfileFile = "azureProfile.json";
        private static readonly string accessTokensFile = "accessTokens.json";
        private AzureCliSubscription defaultSubscription;

        private AzureCliCredentials()
        {
        }

        public static AzureCredentials Create()
        {
            AzureCliCredentials azureCliCredentials = new AzureCliCredentials();
            string homeDir = Environment.ExpandEnvironmentVariables(userProfile);
#if NETSTANDARD1_4
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                homeDir = Environment.GetEnvironmentVariable(home);
            }
#else
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                homeDir = Environment.GetEnvironmentVariable(home);
            }
#endif
            azureCliCredentials.Create(
                Path.Combine(homeDir, azureCliFolder, azureProfileFile),
                Path.Combine(homeDir, azureCliFolder, accessTokensFile)
                );

            if (azureCliCredentials.Subscription() == null)
            {
                throw new Exception("Please login in Azure CLI with service principal.");
            }

            AzureCliSubscription subscription = azureCliCredentials.Subscription();
            return SdkContext.AzureCredentialsFactory.FromServicePrincipal(subscription.ClientId, subscription.Token().AccessToken, subscription.TenantId, subscription.Environment());
        }

        private void Create(string azureProfilePath, string accessTokensPath)
        {
            try
            {
                AzureCliSubscriptionWrapper wrapper = JsonConvert.DeserializeObject<AzureCliSubscriptionWrapper>(File.ReadAllText(azureProfilePath));
                IEnumerable<AzureCliToken> tokens = JsonConvert.DeserializeObject<IEnumerable<AzureCliToken>>(File.ReadAllText(accessTokensPath));

                while(true)
                {
                    wrapper = JsonConvert.DeserializeObject<AzureCliSubscriptionWrapper>(File.ReadAllText(azureProfilePath));
                    tokens = JsonConvert.DeserializeObject<IEnumerable<AzureCliToken>>(File.ReadAllText(accessTokensPath));

                    if (wrapper == null || tokens == null || !tokens.Any() || wrapper.Subscriptions == null || !wrapper.Subscriptions.Any())
                    {
                        Console.Error.WriteLine("Please login in Azure CLI and press any key to continue after you've successfully logged in.");
                        Console.In.Read();
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (AzureCliSubscription subscription in wrapper.Subscriptions)
                {
                    foreach (AzureCliToken token in tokens)
                    {
                        if (subscription.IsServicePrincipal() == token.IsServicePrincipal()
                            && string.Equals(subscription.UserName(), token.User(),StringComparison.OrdinalIgnoreCase)
                            && string.Equals(subscription.TenantId, token.Tenant(), StringComparison.OrdinalIgnoreCase))
                        {
                            if (subscription.IsDefault)
                            {
                                defaultSubscription = subscription.WithToken(token);
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.Error.WriteLine(string.Format("Cannot read files {0} and {1}.Are you logged in Azure CLI ?", azureProfilePath, accessTokensPath));
            }
        }

        internal AzureCliSubscription Subscription()
        {
            return defaultSubscription;
        }
    }
}
