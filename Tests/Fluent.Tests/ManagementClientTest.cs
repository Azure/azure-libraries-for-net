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
                // GENERATED_CODE
                if (client is Microsoft.Azure.Management.AppService.Fluent.WebSiteManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.AppService.Fluent.WebSiteManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.BatchAI.Fluent.BatchAIManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.BatchAI.Fluent.BatchAIManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Cdn.Fluent.CdnManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Cdn.Fluent.CdnManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Compute.Fluent.ComputeManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Compute.Fluent.ComputeManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerInstanceManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerInstanceManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ContainerRegistry.Fluent.ContainerRegistryManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ContainerRegistry.Fluent.ContainerRegistryManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Dns.Fluent.DnsManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Dns.Fluent.DnsManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.EventHub.Fluent.EventHubManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.EventHub.Fluent.EventHubManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.KeyVault.Fluent.KeyVaultManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.KeyVault.Fluent.KeyVaultManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Locks.Fluent.ManagementLockClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Locks.Fluent.ManagementLockClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Monitor.Fluent.MonitorManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Monitor.Fluent.MonitorManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Network.Fluent.NetworkManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Network.Fluent.NetworkManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Redis.Fluent.RedisManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Redis.Fluent.RedisManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ResourceManager.Fluent.FeatureClient)
                {
                    //Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ResourceManager.Fluent.FeatureClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Search.Fluent.SearchManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Search.Fluent.SearchManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Sql.Fluent.SqlManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Sql.Fluent.SqlManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.Storage.Fluent.StorageManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.Storage.Fluent.StorageManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerManagementClient).BaseUri.Host);
                }
                else if (client is Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricManagementClient)
                {
                    Assert.Equal(new Uri(environment.ResourceManagerEndpoint).Host, (client as Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricManagementClient).BaseUri.Host);
                }
            }
        }
    }
}
