// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Rest.Azure;
using System;

namespace Fluent.Tests
{
    public class ManagementClientTest
    {
        [Fact]
        public void ManagementClientBaseUri()
        {
            AzureEnvironment environment = AzureEnvironment.AzureUSGovernment;
            AzureCredentials credentials = new AzureCredentialsFactory().FromServicePrincipal("mockId", "mockSecret", "mockTenant", environment);
            IAzure azure = Microsoft.Azure.Management.Fluent.Azure.Authenticate(credentials).WithSubscription("mockSubscription");

            // check that BaseUri in client is correctly set
            foreach (IAzureClient client in azure.ManagementClients)
            {
                if (client is Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDB)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDB).BaseUri.Host);
                }
            }
        }
    }
}
