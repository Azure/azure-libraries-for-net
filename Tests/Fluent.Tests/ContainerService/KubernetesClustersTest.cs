// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ContainerService.Fluent;
using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using System.IO;
using Xunit;

namespace Fluent.Tests.ContainerService
{
    public class KubernetesClustersTest
    {
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        [Fact(Skip = "The deployment will record client id and secret")]
        public void KubernetesClusterCRUDTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var aksName = TestUtilities.GenerateName("aks");
                var dnsPrefix = "dns" + aksName;
                var rgName = "rg" + aksName;
                var agentPoolName = "ap0" + aksName;
                var networkName = "net" + aksName;
                var agentPoolSubnetName = "agentsub" + networkName;
                var virtualNodeSubnetName = "virtualNodesub" + networkName;
                IKubernetesCluster kubernetesCluster = null;
                var containerServiceManager = TestHelper.CreateContainerServiceManager();
                var resourceManager = TestHelper.CreateResourceManager();
                var networkManager = TestHelper.CreateNetworkManager();

                try
                {
                    string envSecondaryServicePrincipal = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION_2");

                    if (String.IsNullOrWhiteSpace(envSecondaryServicePrincipal) || !File.Exists(envSecondaryServicePrincipal))
                    {
                        envSecondaryServicePrincipal = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");
                    }

                    string servicePrincipalClientId = GetSecondaryServicePrincipalClientID(envSecondaryServicePrincipal);
                    string servicePrincipalSecret = GetSecondaryServicePrincipalSecret(envSecondaryServicePrincipal);

                    var network = networkManager.Networks.Define(networkName)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.100.0.0/16")
                        .DefineSubnet(agentPoolSubnetName)
                            .WithAddressPrefix("10.100.0.0/24")
                            .Attach()
                        .DefineSubnet(virtualNodeSubnetName)
                            .WithAddressPrefix("10.100.1.0/24")
                            .Attach()
                        .Create();

                    kubernetesCluster = containerServiceManager.KubernetesClusters.Define(aksName)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithLatestVersion()
                        .WithRootUsername("testaks")
                        .WithSshKey(SshKey)
                        .WithServicePrincipalClientId(servicePrincipalClientId)
                        .WithServicePrincipalSecret(servicePrincipalSecret)
                        .DefineAgentPool(agentPoolName)
                            .WithVirtualMachineSize(ContainerServiceVMSizeTypes.StandardD2V2)
                            .WithAgentPoolVirtualMachineCount(1)
                            .WithAgentPoolType(AgentPoolType.VirtualMachineScaleSets)
                            .WithAgentPoolMode(AgentPoolMode.System)
                            .WithVirtualNetwork(network.Id, agentPoolSubnetName)
                            .Attach()
                        .WithDnsPrefix("mp1" + dnsPrefix)
                        .WithVirtualNode(virtualNodeSubnetName)
                        .DefineNetworkProfile
                            .WithNetworkPlugin(NetworkPlugin.Azure)
                            .Attach()
                        .WithTag("tag1", "value1")
                        .Create();

                    Assert.NotNull(kubernetesCluster.Id);
                    Assert.Equal(Region.USCentral, kubernetesCluster.Region);
                    Assert.Equal("testaks", kubernetesCluster.LinuxRootUsername);
                    Assert.Equal(1, kubernetesCluster.AgentPools.Count);
                    Assert.NotNull(kubernetesCluster.AgentPools[agentPoolName]);
                    Assert.Equal(1, kubernetesCluster.AgentPools[agentPoolName].Count);
                    Assert.Equal(ContainerServiceVMSizeTypes.StandardD2V2, kubernetesCluster.AgentPools[agentPoolName].VMSize);
                    Assert.Equal(AgentPoolType.VirtualMachineScaleSets, kubernetesCluster.AgentPools[agentPoolName].Type);
                    Assert.NotNull(kubernetesCluster.Tags["tag1"]);

                    kubernetesCluster = containerServiceManager.KubernetesClusters.GetByResourceGroup(rgName, aksName);

                    // Updates resource
                    kubernetesCluster = kubernetesCluster.Update()
                        .WithAgentPoolVirtualMachineCount(agentPoolName, 5)
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.Equal(1, kubernetesCluster.AgentPools.Count);
                    Assert.Equal(5, kubernetesCluster.AgentPools[agentPoolName].Count);
                    Assert.NotNull(kubernetesCluster.Tags["tag2"]);
                    Assert.True(!kubernetesCluster.Tags.ContainsKey("tag1"));

                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }

            }
        }

        /**
     * Retrieve the secondary service principal client ID.
     * @param envSecondaryServicePrincipal an Azure Container Registry
     * @return a service principal client ID
     */
        private static string GetSecondaryServicePrincipalClientID(string envServicePrincipal)
        {
            string clientId = "spId";
            if (!String.IsNullOrEmpty(envServicePrincipal))
            {
                File.ReadAllLines(envServicePrincipal).All(line =>
                {
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    if (keyVal.Length < 2)
                        return true; // Ignore lines that don't look like $$$=$$$
                    if (keyVal[0].Equals("client"))
                        clientId = keyVal[1];
                    return true;
                });
            }
            return clientId;
        }

        /**
         * Retrieve the secondary service principal secret.
         * @param envSecondaryServicePrincipal an Azure Container Registry
         * @return a service principal secret
         */
        private static string GetSecondaryServicePrincipalSecret(string envServicePrincipalSecret)
        {
            string secret = "spSecret";
            if (!String.IsNullOrEmpty(envServicePrincipalSecret))
            {
                File.ReadAllLines(envServicePrincipalSecret).All(line =>
                {
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    if (keyVal.Length < 2)
                        return true; // Ignore lines that don't look like $$$=$$$
                    if (keyVal[0].Equals("key"))
                        secret = keyVal[1];
                    return true;
                });
            }
            return secret;
        }
    }
}
