// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests
{
    public class ContainerInstanceTest
    {
        [Fact]
        public void ContainerRegistryCRD()
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
                    var temp = containerInstanceManager.ContainerGroups.Define(cgName);

                    containerGroup = containerInstanceManager.ContainerGroups.Define(cgName)
                            .WithRegion(Region.USEast)
                            .WithNewResourceGroup(rgName)
                            .WithLinux()
                            .WithPublicImageRegistryOnly()
                            .WithoutVolume()
                            .DefineContainerInstance("tomcat")
                                .WithImage("tomcat")
                                .WithExternalTcpPort(8080)
                                .WithCpuCoreCount(1)
                                .Attach()
                            .DefineContainerInstance("nginx")
                                .WithImage("nginx")
                                .WithExternalTcpPort(80)
                                .Attach()
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.Equal(cgName, containerGroup.Name);
                    Assert.Equal("Linux", containerGroup.OSType.Value);
                    Assert.Equal(0, containerGroup.ImageRegistryServers.Count);
                    Assert.Equal(0, containerGroup.Volumes.Count);
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
                    Assert.True(containerGroup.Tags.ContainsKey("tag1"));

                    IContainerGroup containerGroup2 = containerInstanceManager.ContainerGroups.GetByResourceGroup(rgName, cgName);

                    var containerGroupList = containerInstanceManager.ContainerGroups.ListByResourceGroup(rgName);

                    containerGroup.Refresh();

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
