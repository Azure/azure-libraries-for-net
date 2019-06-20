// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests
{
    public class ContainerInstanceTest
    {
        [Fact]
        public void ContainerInstanceWithPublicIpAddressWithSystemAssignedMSI()
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
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
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
                    Assert.Equal(1, tomcatContainer.EnvironmentVariables.Count);
                    Assert.Equal("nginx", nginxContainer.Name);
                    Assert.Equal("nginx", nginxContainer.Image);
                    Assert.Equal(1.0, nginxContainer.Resources.Requests.Cpu);
                    Assert.Equal(1.5, nginxContainer.Resources.Requests.MemoryInGB);
                    Assert.Equal(1, nginxContainer.Ports.Count);
                    Assert.Equal(80, nginxContainer.Ports[0].Port);
                    Assert.Null(nginxContainer.VolumeMounts);
                    Assert.Null(nginxContainer.Command);
                    Assert.NotNull(nginxContainer.EnvironmentVariables);
                    Assert.Equal(cgName, containerGroup.DnsPrefix);
                    Assert.True(containerGroup.Tags.ContainsKey("tag1"));
                    Assert.Equal(ContainerGroupRestartPolicy.Never, containerGroup.RestartPolicy);
                    Assert.True(containerGroup.IsManagedServiceIdentityEnabled);
                    Assert.Equal(ResourceIdentityType.SystemAssigned, containerGroup.ManagedServiceIdentityType);

                    IContainerGroup containerGroup2 = containerInstanceManager.ContainerGroups.GetByResourceGroup(rgName, cgName);

                    var containerGroupList = containerInstanceManager.ContainerGroups.ListByResourceGroup(rgName);
                    Assert.True(containerGroupList.Count() > 0);
                    Assert.NotNull(containerGroupList.First().State);

                    containerGroup.Refresh();

                    var containerOperationsList = containerInstanceManager.ContainerGroups.ListOperations();
                    Assert.True(containerOperationsList.Count() > 0);

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

        [Fact]
        public void ContainerInstanceWithPublicIpAddressWithUserAssignedMSI()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgaci");
                var cgName = TestUtilities.GenerateName("aci");
                var msiManager = TestHelper.CreateMsiManager();
                var containerInstanceManager = TestHelper.CreateContainerInstanceManager();
                var resourceManager = TestHelper.CreateResourceManager();
                string identityName1 = TestUtilities.GenerateName("msi-id");
                string identityName2 = TestUtilities.GenerateName("msi-id");
                IList<string> dnsServers = new List<string>();
                dnsServers.Add("dnsServer1");
                IContainerGroup containerGroup = null;

                IIdentity createdIdentity = msiManager.Identities
                    .Define(identityName1)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(rgName)
                    .WithAccessToCurrentResourceGroup(BuiltInRole.Reader)
                    .Create();

                Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate creatableIdentity = msiManager.Identities
                     .Define(identityName2)
                     .WithRegion(Region.USWest)
                     .WithExistingResourceGroup(rgName)
                     .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                try
                {
                    containerGroup = containerInstanceManager.ContainerGroups.Define(cgName)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(rgName)
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
                            .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
                            .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
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
                    Assert.Equal(1, tomcatContainer.EnvironmentVariables.Count);
                    Assert.Equal("nginx", nginxContainer.Name);
                    Assert.Equal("nginx", nginxContainer.Image);
                    Assert.Equal(1.0, nginxContainer.Resources.Requests.Cpu);
                    Assert.Equal(1.5, nginxContainer.Resources.Requests.MemoryInGB);
                    Assert.Equal(1, nginxContainer.Ports.Count);
                    Assert.Equal(80, nginxContainer.Ports[0].Port);
                    Assert.Null(nginxContainer.VolumeMounts);
                    Assert.Null(nginxContainer.Command);
                    Assert.NotNull(nginxContainer.EnvironmentVariables);
                    Assert.Equal(cgName, containerGroup.DnsPrefix);
                    Assert.True(containerGroup.Tags.ContainsKey("tag1"));
                    Assert.Equal(ContainerGroupRestartPolicy.Never, containerGroup.RestartPolicy);
                    Assert.True(containerGroup.IsManagedServiceIdentityEnabled);
                    Assert.Null(containerGroup.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.Equal(ResourceIdentityType.UserAssigned, containerGroup.ManagedServiceIdentityType);
                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    IReadOnlyCollection<string> emsiIds = containerGroup.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(2, emsiIds.Count);

                    IContainerGroup containerGroup2 = containerInstanceManager.ContainerGroups.GetByResourceGroup(rgName, cgName);

                    var containerGroupList = containerInstanceManager.ContainerGroups.ListByResourceGroup(rgName);
                    Assert.True(containerGroupList.Count() > 0);
                    Assert.NotNull(containerGroupList.First().State);

                    containerGroup.Refresh();

                    var containerOperationsList = containerInstanceManager.ContainerGroups.ListOperations();
                    Assert.True(containerOperationsList.Count() > 0);

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
        [Fact(Skip = "Needs subscription ID and log analytics workspace ID to run")]
        public void ContainerInstanceWithPrivateIpAddress()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgaci");
                var cgName = TestUtilities.GenerateName("aci");
                string logAnalyticsWorkspaceId = "REPLACE WITH YOUR LOG ANALYTICS WORKSPACE ID";
                string logAnalyticsWorkspaceKey = "REPLACE WITH YOUR LOG ANALYTICS WORKSPACE KEY";
                string networkProfileSubscriptionId = "REPLACE WITH YOUR NETWORK PROFILE SUBSCRIPTION ID";
                string networkProfileResourceGroupName = "REPLACE WITH YOUR NETWORK PROFILE RESOURCE GROUP NAME";
                string networkProfileName = "REPLACE WITH YOUR NETWORK PROFILE NAME";
                var containerInstanceManager = TestHelper.CreateContainerInstanceManager();
                var resourceManager = TestHelper.CreateResourceManager();
                IList<string> dnsServerNames = new List<string>();
                dnsServerNames.Add("dnsServer1");
                IContainerGroup containerGroup = null;

                try
                {
                    containerGroup = containerInstanceManager.ContainerGroups.Define(cgName)
                            .WithRegion(Region.USWest)
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
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                            .WithRestartPolicy(ContainerGroupRestartPolicy.Never)
                            .WithLogAnalytics(logAnalyticsWorkspaceId, "isabellaTest")
                            .WithNetworkProfileId(networkProfileSubscriptionId, networkProfileResourceGroupName, networkProfileName)
                            .WithDnsConfiguration(dnsServerNames, "dnsSearchDomains", "dnsOptions")
                            .WithTag("tag1", "value1")
                            .Create();

                    Assert.Equal(cgName, containerGroup.Name);
                    Assert.Equal("Linux", containerGroup.OSType.Value);
                    Assert.Equal(0, containerGroup.ImageRegistryServers.Count);
                    Assert.Equal(1, containerGroup.Volumes.Count);
                    Assert.NotNull(containerGroup.Volumes["emptydir1"]);
                    Assert.NotNull(containerGroup.IPAddress);
                    Assert.True(containerGroup.IsIPAddressPrivate);
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
                    Assert.Equal(1, tomcatContainer.EnvironmentVariables.Count);
                    Assert.Equal("nginx", nginxContainer.Name);
                    Assert.Equal("nginx", nginxContainer.Image);
                    Assert.Equal(1.0, nginxContainer.Resources.Requests.Cpu);
                    Assert.Equal(1.5, nginxContainer.Resources.Requests.MemoryInGB);
                    Assert.Equal(1, nginxContainer.Ports.Count);
                    Assert.Equal(80, nginxContainer.Ports[0].Port);
                    Assert.Null(nginxContainer.VolumeMounts);
                    Assert.Null(nginxContainer.Command);
                    Assert.NotNull(nginxContainer.EnvironmentVariables);
                    Assert.True(containerGroup.Tags.ContainsKey("tag1"));
                    Assert.Equal(ContainerGroupRestartPolicy.Never, containerGroup.RestartPolicy);
                    Assert.True(containerGroup.IsManagedServiceIdentityEnabled);
                    Assert.Equal(ResourceIdentityType.SystemAssigned, containerGroup.ManagedServiceIdentityType);
                    Assert.Equal(logAnalyticsWorkspaceId, containerGroup.LogAnalytics.WorkspaceId);
                    Assert.Equal("/subscriptions/" + networkProfileSubscriptionId + "/resourceGroups/" + networkProfileResourceGroupName + "/providers/Microsoft.Network/networkProfiles/" + networkProfileName, containerGroup.NetworkProfileId);
                    Assert.Equal("dnsServer1", containerGroup.DnsConfig.NameServers[0]);
                    Assert.Equal("dnsSearchDomains", containerGroup.DnsConfig.SearchDomains);
                    Assert.Equal("dnsOptions", containerGroup.DnsConfig.Options);

                    IContainerGroup containerGroup2 = containerInstanceManager.ContainerGroups.GetByResourceGroup(rgName, cgName);

                    var containerGroupList = containerInstanceManager.ContainerGroups.ListByResourceGroup(rgName);
                    Assert.True(containerGroupList.Count() > 0);
                    Assert.NotNull(containerGroupList.First().State);

                    containerGroup.Refresh();

                    var containerOperationsList = containerInstanceManager.ContainerGroups.ListOperations();
                    Assert.True(containerOperationsList.Count() > 0);

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
