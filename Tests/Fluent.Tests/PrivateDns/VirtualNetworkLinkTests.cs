// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.PrivateDns
{
    public class VirtualNetworkLink
    {
        [Fact]
        public void CanCreateWithDefaultETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";
                var virtualNetworkName = TestUtilities.GenerateName("vnprdns");
                var virtualNetworkLinkName = TestUtilities.GenerateName("vnlinkprdns");
                var nsgName = TestUtilities.GenerateName("nsgprdns");

                var azure = TestHelper.CreateRollupClient();
                var networkManager = TestHelper.CreateNetworkManager();
                try
                {
                    var nsg = networkManager.NetworkSecurityGroups.Define(nsgName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    // Create a network
                    INetwork network = networkManager.Networks.Define(virtualNetworkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithAddressSpace("10.1.0.0/28")
                            .WithSubnet("subnetA", "10.0.0.0/29")
                            .DefineSubnet("subnetB")
                                .WithAddressPrefix("10.0.0.8/29")
                                .WithExistingNetworkSecurityGroup(nsg)
                                .Attach()
                            .Create();

                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithExistingResourceGroup(groupName)
                        .DefineVirtualNetworkLink(virtualNetworkLinkName)
                            .DisableAutoRegistration()
                            .WithReferencedVirtualNetworkId(network.Id)
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check virtual network links
                    var virtualNetworkLinks = privateDnsZone.VirtualNetworkLinks.List();
                    Assert.NotNull(virtualNetworkLinks);
                    Assert.True(virtualNetworkLinks.Count() == 1);
                    var link = virtualNetworkLinks.ElementAt(0);
                    Assert.False(link.IsAutoRegistrationEnabled);

                    AggregateException compositeException = null;
                    try
                    {
                        privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                            .WithExistingResourceGroup(groupName)
                            .DefineVirtualNetworkLink(virtualNetworkLinkName)
                                .DisableAutoRegistration()
                                .WithReferencedVirtualNetworkId(network.Id)
                                .WithETagCheck()
                                .Attach()
                            .Create();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.NotNull(compositeException.InnerExceptions);
                    Assert.True(compositeException.InnerExceptions.Count == 1);
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanUpdateWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";
                var virtualNetworkName = TestUtilities.GenerateName("vnprdns");
                var virtualNetworkLinkName = TestUtilities.GenerateName("vnlinkprdns");
                var nsgName = TestUtilities.GenerateName("nsgprdns");

                var azure = TestHelper.CreateRollupClient();
                var networkManager = TestHelper.CreateNetworkManager();
                try
                {
                    var nsg = networkManager.NetworkSecurityGroups.Define(nsgName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    // Create a network
                    INetwork network = networkManager.Networks.Define(virtualNetworkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithAddressSpace("10.1.0.0/28")
                            .WithSubnet("subnetA", "10.0.0.0/29")
                            .DefineSubnet("subnetB")
                                .WithAddressPrefix("10.0.0.8/29")
                                .WithExistingNetworkSecurityGroup(nsg)
                                .Attach()
                            .Create();

                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithExistingResourceGroup(groupName)
                        .DefineVirtualNetworkLink(virtualNetworkLinkName)
                            .DisableAutoRegistration()
                            .WithReferencedVirtualNetworkId(network.Id)
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check virtual network links
                    var virtualNetworkLinks = privateDnsZone.VirtualNetworkLinks.List();
                    Assert.NotNull(virtualNetworkLinks);
                    Assert.True(virtualNetworkLinks.Count() == 1);
                    var link = virtualNetworkLinks.ElementAt(0);
                    Assert.False(link.IsAutoRegistrationEnabled);

                    AggregateException compositeException = null;
                    try
                    {
                        privateDnsZone.Update()
                            .UpdateVirtualNetworkLink(virtualNetworkLinkName)
                                .EnableAutoRegistration()
                                .WithETagCheck(link.ETag + "-foo")
                                .Parent()
                            .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.NotNull(compositeException.InnerExceptions);
                    Assert.True(compositeException.InnerExceptions.Count == 1);
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }

                    privateDnsZone.Update()
                            .UpdateVirtualNetworkLink(virtualNetworkLinkName)
                                .EnableAutoRegistration()
                                .WithETagCheck(link.ETag)
                                .Parent()
                            .Apply();

                    virtualNetworkLinks = privateDnsZone.VirtualNetworkLinks.List();
                    Assert.NotNull(virtualNetworkLinks);
                    Assert.True(virtualNetworkLinks.Count() == 1);
                    link = virtualNetworkLinks.ElementAt(0);
                    Assert.True(link.IsAutoRegistrationEnabled);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }


        [Fact]
        public void CanDeleteWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.AsiaSouthEast;
                var groupName = TestUtilities.GenerateName("rgprdnshash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";
                var virtualNetworkName = TestUtilities.GenerateName("vnprdns");
                var virtualNetworkLinkName = TestUtilities.GenerateName("vnlinkprdns");
                var nsgName = TestUtilities.GenerateName("nsgprdns");

                var azure = TestHelper.CreateRollupClient();
                var networkManager = TestHelper.CreateNetworkManager();
                try
                {
                    var nsg = networkManager.NetworkSecurityGroups.Define(nsgName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .Create();

                    // Create a network
                    INetwork network = networkManager.Networks.Define(virtualNetworkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithAddressSpace("10.1.0.0/28")
                            .WithSubnet("subnetA", "10.0.0.0/29")
                            .DefineSubnet("subnetB")
                                .WithAddressPrefix("10.0.0.8/29")
                                .WithExistingNetworkSecurityGroup(nsg)
                                .Attach()
                            .Create();

                    var privateDnsZone = azure.PrivateDnsZones.Define(topLevelDomain)
                        .WithExistingResourceGroup(groupName)
                        .DefineVirtualNetworkLink(virtualNetworkLinkName)
                            .DisableAutoRegistration()
                            .WithReferencedVirtualNetworkId(network.Id)
                            .WithETagCheck()
                            .Attach()
                        .Create();

                    //check virtual network links
                    var virtualNetworkLinks = privateDnsZone.VirtualNetworkLinks.List();
                    Assert.NotNull(virtualNetworkLinks);
                    Assert.True(virtualNetworkLinks.Count() == 1);
                    var link = virtualNetworkLinks.ElementAt(0);
                    Assert.False(link.IsAutoRegistrationEnabled);

                    AggregateException compositeException = null;
                    try
                    {
                        privateDnsZone.Update()
                            .WithoutVirtualNetworkLink(virtualNetworkLinkName, link.ETag + "-foo")
                            .Apply();
                    }
                    catch (AggregateException exception)
                    {
                        compositeException = exception;
                    }
                    Assert.NotNull(compositeException);
                    Assert.NotNull(compositeException.InnerExceptions);
                    Assert.True(compositeException.InnerExceptions.Count == 1);
                    foreach (var exception in compositeException.InnerExceptions)
                    {
                        Assert.True(exception is CloudException);
                        CloudError cloudError = ((CloudException)exception).Body;
                        Assert.NotNull(cloudError);
                        Assert.NotNull(cloudError.Code);
                        Assert.Contains("PreconditionFailed", cloudError.Code);
                    }

                    privateDnsZone.Update()
                            .WithoutVirtualNetworkLink(virtualNetworkLinkName, link.ETag)
                            .Apply();

                    virtualNetworkLinks = privateDnsZone.VirtualNetworkLinks.List();
                    Assert.NotNull(virtualNetworkLinks);
                    Assert.True(virtualNetworkLinks.Count() == 0);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
