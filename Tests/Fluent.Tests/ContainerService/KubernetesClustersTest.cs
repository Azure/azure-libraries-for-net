// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ContainerService.Fluent;
using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Azure.Tests;

namespace Fluent.Tests.ContainerService
{
    public class KubernetesClustersTest
    {
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        [Fact]
        public void KubernetesClusterCRUDTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var aksName = TestUtilities.GenerateName("aks");
                var dnsPrefix = "dns" + aksName;
                var rgName = "rg" + aksName;
                var agentPoolName = "ap0" + aksName;
                IKubernetesCluster kubernetesCluster = null;
                var containerServiceManager = TestHelper.CreateContainerServiceManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    kubernetesCluster = containerServiceManager.KubernetesClusters.Define(aksName)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithLatestVersion()
                        .WithRootUsername("testaks")
                        .WithSshKey(SshKey)
                        .WithServicePrincipalClientId("spId")
                        .WithServicePrincipalSecret("spSecret")
                        .DefineAgentPool(agentPoolName)
                            .WithVirtualMachineCount(1)
                            .WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes.StandardD1V2)
                            .Attach()
                        .WithDnsPrefix("mp1" + dnsPrefix)
                        .WithTag("tag1", "value1")
                        .Create();

                    Assert.NotNull(kubernetesCluster.Id);
                    Assert.Equal(Region.USCentral, kubernetesCluster.Region);
                    Assert.Equal("testaks", kubernetesCluster.LinuxRootUsername);
                    Assert.Equal(1, kubernetesCluster.AgentPools.Count);
                    Assert.NotNull(kubernetesCluster.AgentPools[agentPoolName]);
                    Assert.Equal(1, kubernetesCluster.AgentPools[agentPoolName].Count);
                    Assert.Equal(ContainerServiceVirtualMachineSizeTypes.StandardD1V2, kubernetesCluster.AgentPools[agentPoolName].VMSize);
                    Assert.NotNull(kubernetesCluster.Tags["tag1"]);

                    kubernetesCluster = containerServiceManager.KubernetesClusters.GetByResourceGroup(rgName, aksName);

                    // Updates resource
                    kubernetesCluster = kubernetesCluster.Update()
                        .WithAgentVirtualMachineCount(agentPoolName, 5)
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
    }
}
