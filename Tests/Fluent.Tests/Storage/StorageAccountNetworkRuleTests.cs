// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class NetworkRules
    {
        [Fact]
        public void CanConfigureWithCreate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var saName1 = TestUtilities.GenerateName("javacsmsa");
                var saName2 = TestUtilities.GenerateName("javacsmsa");
                var saName3 = TestUtilities.GenerateName("javacsmsa");
                var saName4 = TestUtilities.GenerateName("javacsmsa");

                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var storageAccount1 = storageManager.StorageAccounts
                        .Define(saName1)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .Create();

                    Assert.NotNull(storageAccount1.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount1.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressesWithAccess);
                    Assert.Equal(0, storageAccount1.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressRangesWithAccess);
                    Assert.Equal(0, storageAccount1.IPAddressRangesWithAccess.Count);

                    Assert.True(storageAccount1.IsAccessAllowedFromAllNetworks);
                    Assert.True(storageAccount1.CanAccessFromAzureServices);
                    Assert.True(storageAccount1.CanReadLogEntriesFromAnyNetwork);
                    Assert.True(storageAccount1.CanReadMetricsFromAnyNetwork);

                    var resourceGroup = storageManager.ResourceManager
                            .ResourceGroups
                            .GetByName(storageAccount1.ResourceGroupName);

                    var storageAccount2 = storageManager.StorageAccounts
                            .Define(saName2)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAccessFromIpAddress("23.20.0.0")
                            .Create();

                    Assert.NotNull(storageAccount2.Inner.NetworkRuleSet);
                    Assert.NotNull(storageAccount2.Inner.NetworkRuleSet.DefaultAction);
                    Assert.Equal(DefaultAction.Deny, storageAccount2.Inner.NetworkRuleSet.DefaultAction);

                    Assert.NotNull(storageAccount2.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount2.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount2.IPAddressesWithAccess);
                    Assert.Equal(1, storageAccount2.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount2.IPAddressRangesWithAccess);
                    Assert.Equal(0, storageAccount2.IPAddressRangesWithAccess.Count);

                    Assert.False(storageAccount2.IsAccessAllowedFromAllNetworks);
                    Assert.False(storageAccount2.CanAccessFromAzureServices);
                    Assert.False(storageAccount2.CanReadLogEntriesFromAnyNetwork);
                    Assert.False(storageAccount2.CanReadMetricsFromAnyNetwork);

                    var storageAccount3 = storageManager.StorageAccounts
                            .Define(saName3)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAccessFromAllNetworks()
                            .WithAccessFromIpAddress("23.20.0.0")
                            .Create();

                    Assert.NotNull(storageAccount3.Inner.NetworkRuleSet);
                    Assert.NotNull(storageAccount3.Inner.NetworkRuleSet.DefaultAction);
                    Assert.Equal(DefaultAction.Allow, storageAccount3.Inner.NetworkRuleSet.DefaultAction);

                    Assert.NotNull(storageAccount3.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount3.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount3.IPAddressesWithAccess);
                    Assert.Equal(1, storageAccount3.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount3.IPAddressRangesWithAccess);
                    Assert.Equal(0, storageAccount3.IPAddressRangesWithAccess.Count);

                    Assert.True(storageAccount3.IsAccessAllowedFromAllNetworks);
                    Assert.True(storageAccount3.CanAccessFromAzureServices);
                    Assert.True(storageAccount3.CanReadMetricsFromAnyNetwork);
                    Assert.True(storageAccount3.CanReadLogEntriesFromAnyNetwork);

                    var storageAccount4 = storageManager.StorageAccounts
                            .Define(saName4)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithReadAccessToLogEntriesFromAnyNetwork()
                            .WithReadAccessToMetricsFromAnyNetwork()
                            .Create();

                    Assert.NotNull(storageAccount4.Inner.NetworkRuleSet);
                    Assert.NotNull(storageAccount4.Inner.NetworkRuleSet.DefaultAction);
                    Assert.Equal(DefaultAction.Deny, storageAccount4.Inner.NetworkRuleSet.DefaultAction);

                    Assert.NotNull(storageAccount4.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount4.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount4.IPAddressesWithAccess);
                    Assert.Equal(0, storageAccount4.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount3.IPAddressRangesWithAccess);
                    Assert.Equal(0, storageAccount4.IPAddressRangesWithAccess.Count);

                    Assert.False(storageAccount4.IsAccessAllowedFromAllNetworks);
                    Assert.False(storageAccount4.CanAccessFromAzureServices);
                    Assert.True(storageAccount4.CanReadMetricsFromAnyNetwork);
                    Assert.True(storageAccount4.CanReadLogEntriesFromAnyNetwork);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanConfigureWithUpdate()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var saName1 = TestUtilities.GenerateName("javacsmsa");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    var storageAccount1 = storageManager.StorageAccounts
                        .Define(saName1)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .Create();

                    Assert.NotNull(storageAccount1.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount1.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressesWithAccess);
                    Assert.Equal(0, storageAccount1.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressRangesWithAccess);
                    Assert.Equal(0, storageAccount1.IPAddressRangesWithAccess.Count);

                    Assert.True(storageAccount1.IsAccessAllowedFromAllNetworks);
                    Assert.True(storageAccount1.CanAccessFromAzureServices);
                    Assert.True(storageAccount1.CanReadMetricsFromAnyNetwork);
                    Assert.True(storageAccount1.CanReadMetricsFromAnyNetwork);

                    storageAccount1.Update()
                            .WithAccessFromSelectedNetworks()
                            .WithAccessFromIpAddressRange("23.20.0.0/20")
                            .Apply();

                    Assert.NotNull(storageAccount1.NetworkSubnetsWithAccess);
                    Assert.Equal(0, storageAccount1.NetworkSubnetsWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressesWithAccess);
                    Assert.Equal(0, storageAccount1.IPAddressesWithAccess.Count);

                    Assert.NotNull(storageAccount1.IPAddressRangesWithAccess);
                    Assert.Equal(1, storageAccount1.IPAddressRangesWithAccess.Count);

                    Assert.False(storageAccount1.IsAccessAllowedFromAllNetworks);
                    Assert.True(storageAccount1.CanAccessFromAzureServices);
                    Assert.False(storageAccount1.CanReadMetricsFromAnyNetwork);
                    Assert.False(storageAccount1.CanReadMetricsFromAnyNetwork);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

    }
}
