// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Fluent.Tests
{
    public class ContainerInstanceTest
    {
        [Fact]
        public void ContainerInstanceCRD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgaci");
                var cgName = TestUtilities.GenerateName("aci");
                var containerInstanceManager = TestHelper.CreateContainerInstanceManager();
                var resourceManager = TestHelper.CreateResourceManager();
                IContainerGroup containerGroup = null;

                try
                {
                    containerGroup = containerInstanceManager.ContainerGroups.Define(cgName)
                            .WithRegion(Region.USEast)
                            .WithNewResourceGroup(rgName)
                            .WithLinux()
                            .WithPublicImageRegistryOnly()
                            .WithEmptyDirectoryVolume("emptydir1")
                            .DefineContainerInstance("tomcat")
                                .WithImage("tomcat")
                                .WithExternalTcpPort(8080)
                                .WithCpuCoreCount(1)
                                .WithEnvironmentVariable("ENV1", "value1")
                                .Attach()
                            .DefineContainerInstance("nginx")
                                .WithImage("nginx")
                                .WithExternalTcpPort(80)
                                .WithEnvironmentVariableWithSecuredValue("ENV2", "securedValue1")
                                .Attach()
                            .WithRestartPolicy(ContainerGroupRestartPolicy.Never)
                            .WithDnsPrefix(cgName)
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.Equal(cgName, containerGroup.Name);
                    Assert.Equal("Linux", containerGroup.OSType.Value);
                    Assert.Equal(0, containerGroup.ImageRegistryServers.Count);
                    Assert.Equal(1, containerGroup.Volumes.Count);
                    Assert.NotNull(containerGroup.Volumes["emptydir1"]);
                    Assert.NotNull(containerGroup.IPAddress);
                    Assert.True(containerGroup.IsIPAddressPublic);
                    Assert.Equal(2, containerGroup.ExternalTcpPorts.Length);
                    Assert.Equal(2, containerGroup.ExternalPorts.Count);
                    Assert.Empty(containerGroup.ExternalUdpPorts);
                    Assert.Equal(8080, containerGroup.ExternalTcpPorts[0]);
                    Assert.Equal(80, containerGroup.ExternalTcpPorts[1]);
                    Assert.Equal(2, containerGroup.Containers.Count);
                    Container tomcatContainer = containerGroup.Containers["tomcat"];
                    Assert.NotNull(tomcatContainer);
                    Container nginxContainer = containerGroup.Containers["nginx"];
                    Assert.NotNull(nginxContainer);
                    Assert.Equal("tomcat", tomcatContainer.Name);
                    Assert.Equal("tomcat", tomcatContainer.Image);
                    Assert.Equal(1.0, tomcatContainer.Resources.Requests.Cpu);
                    Assert.Equal(1.5, tomcatContainer.Resources.Requests.MemoryInGB);
                    Assert.Equal(1, tomcatContainer.Ports.Count);
                    Assert.Equal(8080, tomcatContainer.Ports[0].Port);
                    Assert.Null(tomcatContainer.VolumeMounts);
                    Assert.Null(tomcatContainer.Command);
                    Assert.NotNull(tomcatContainer.EnvironmentVariables);
                    Assert.Empty(tomcatContainer.EnvironmentVariables);
                    Assert.Equal("nginx", nginxContainer.Name);
                    Assert.Equal("nginx", nginxContainer.Image);
                    Assert.Equal(1.0, nginxContainer.Resources.Requests.Cpu);
                    Assert.Equal(1.5, nginxContainer.Resources.Requests.MemoryInGB);
                    Assert.Equal(1, nginxContainer.Ports.Count);
                    Assert.Equal(80, nginxContainer.Ports[0].Port);
                    Assert.Null(nginxContainer.VolumeMounts);
                    Assert.Null(nginxContainer.Command);
                    Assert.NotNull(nginxContainer.EnvironmentVariables);
                    Assert.Empty(nginxContainer.EnvironmentVariables);
                    Assert.Equal(cgName, containerGroup.DnsPrefix);
                    Assert.True(containerGroup.Tags.ContainsKey("tag1"));
                    Assert.Equal(ContainerGroupRestartPolicy.Never, containerGroup.RestartPolicy);

                    IContainerGroup containerGroup2 = containerInstanceManager.ContainerGroups.GetByResourceGroup(rgName, cgName);

                    var containerGroupList = containerInstanceManager.ContainerGroups.ListByResourceGroup(rgName);
                    Assert.True(containerGroupList.Count() > 0);
                    Assert.NotNull(containerGroupList.First().State);

                    containerGroup.Refresh();

                    var containerOperationsList = containerInstanceManager.ContainerGroups.ListOperations();
                    Assert.Equal(10, containerOperationsList.Count());

                    containerGroup.Update()
                        .WithoutTag("tag1")
                        .WithTag("tag2", "value2")
                        .Apply();
                    Assert.False(containerGroup.Tags.ContainsKey("tag1"));
                    Assert.True(containerGroup.Tags.ContainsKey("tag2"));

                    containerInstanceManager.ContainerGroups.DeleteById(containerGroup.Id);
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
