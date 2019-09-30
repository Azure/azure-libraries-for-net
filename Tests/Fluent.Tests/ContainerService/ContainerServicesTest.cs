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
    public class ContainerServices
    {
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        [Fact]
        public void ContainerServiceCRUDTest()
        {
            
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var acsName = TestUtilities.GenerateName("acs");
                var dnsPrefix = "dns" + acsName;
                var rgName = "rg" + acsName;
                var agentPoolName = "ap0" + acsName;
                IContainerService containerService = null;
                var containerServiceManager = TestHelper.CreateContainerServiceManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    containerService = containerServiceManager.ContainerServices.Define(acsName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithDcosOrchestration()
                        .WithLinux()
                        .WithRootUsername("testacs")
                        .WithSshKey(SshKey)
                        .WithMasterNodeCount(ContainerServiceMasterProfileCount.MIN)
                        .DefineAgentPool(agentPoolName)
                            .WithVirtualMachineCount(1)
                            .WithVirtualMachineSize(ContainerServiceVMSizeTypes.StandardA1)
                            .WithDnsPrefix("ap0" + dnsPrefix)
                            .Attach()
                        .WithMasterDnsPrefix("mp0" + dnsPrefix)
                        .WithDiagnostics()
                        .WithTag("tag1", "value1")
                        .Create();

                    Assert.NotNull(containerService.Id);
                    Assert.Equal(Region.USEast, containerService.Region);
                    Assert.Equal((int)ContainerServiceMasterProfileCount.MIN, containerService.MasterNodeCount);
                    Assert.Equal("testacs", containerService.LinuxRootUsername);
                    Assert.Equal(1, containerService.AgentPools.Count);
                    Assert.NotNull(containerService.AgentPools[agentPoolName]);
                    Assert.Equal(1, containerService.AgentPools[agentPoolName].Count);
                    Assert.Equal("ap0" + dnsPrefix, containerService.AgentPools[agentPoolName].DnsPrefix);
                    Assert.Equal(ContainerServiceVMSizeTypes.StandardA1, containerService.AgentPools[agentPoolName].VMSize);
                    Assert.Equal(ContainerServiceOrchestratorTypes.DCOS, containerService.OrchestratorType);
                    Assert.True(containerService.IsDiagnosticsEnabled);
                    Assert.NotNull(containerService.Tags["tag1"]);

                    // Updates resource
                    containerService = containerService.Update()
                        .WithAgentVirtualMachineCount(5)
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.Equal(1, containerService.AgentPools.Count);
                    Assert.Equal(5, containerService.AgentPools[agentPoolName].Count);
                    Assert.NotNull(containerService.Tags["tag2"]);
                    Assert.True(!containerService.Tags.ContainsKey("tag1"));

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
