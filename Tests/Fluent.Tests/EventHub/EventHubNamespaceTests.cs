// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.EventHub.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests.EventHub
{
    public class Namespace
    {
        [Fact]
        public void CanManageBasicSettings()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var namespaceName1 = TestUtilities.GenerateName("ns111");
                var namespaceName2 = TestUtilities.GenerateName("ns222");
                var namespaceName3 = TestUtilities.GenerateName("ns333");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    IEventHubNamespace namespace1 = azure.EventHubNamespaces
                        .Define(namespaceName1)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        // SDK should use Sku as 'Standard' and set capacity.capacity in it as 1
                        .WithAutoScaling()
                        .Create();

                    Assert.NotNull(namespace1);
                    Assert.NotNull(namespace1.Inner);
                    Assert.NotNull(namespace1.Sku);
                    Assert.True(namespace1.Sku.Equals(EventHubNamespaceSkuType.Standard));
                    Assert.True(namespace1.IsAutoScaleEnabled);
                    Assert.NotNull(namespace1.Inner.MaximumThroughputUnits);
                    Assert.NotNull(namespace1.Inner.Sku.Capacity);

                    IEventHubNamespace namespace2 = azure.EventHubNamespaces
                        .Define(namespaceName2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(groupName)
                        // SDK should use Sku as 'Standard' and set capacity.capacity in it as 11
                        .WithCurrentThroughputUnits(11)
                        .Create();

                    Assert.NotNull(namespace2);
                    Assert.NotNull(namespace2.Inner);
                    Assert.NotNull(namespace2.Sku);
                    Assert.True(namespace2.Sku.Equals(EventHubNamespaceSkuType.Standard));
                    Assert.NotNull(namespace2.Inner.MaximumThroughputUnits);
                    Assert.NotNull(namespace2.Inner.Sku.Capacity);
                    Assert.Equal(11, namespace2.CurrentThroughputUnits);

                    IEventHubNamespace namespace3 = azure.EventHubNamespaces
                            .Define(namespaceName3)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithSku(EventHubNamespaceSkuType.Basic)
                            .Create();

                    Assert.NotNull(namespace3);
                    Assert.NotNull(namespace3.Inner);
                    Assert.NotNull(namespace3.Sku);
                    Assert.True(namespace3.Sku.Equals(EventHubNamespaceSkuType.Basic));

                    namespace3.Update()
                            .WithSku(EventHubNamespaceSkuType.Standard)
                            .WithTag("aa", "bb")
                            .Apply();

                    Assert.NotNull(namespace3.Sku);
                    Assert.True(namespace3.Sku.Equals(EventHubNamespaceSkuType.Standard));
                    Assert.NotNull(namespace3.Tags);
                    Assert.True(namespace3.Tags.Count > 0);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanManageAuthorizationRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var namespaceName = TestUtilities.GenerateName("ns111");
                var namespaceName2 = TestUtilities.GenerateName("ns222");
                var namespaceName3 = TestUtilities.GenerateName("ns333");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    IEventHubNamespace ehNamespace = azure.EventHubNamespaces
                        .Define(namespaceName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewManageRule("mngRule1")
                            .WithNewSendRule("sndRule1")
                            .Create();

                    Assert.NotNull(ehNamespace);
                    Assert.NotNull(ehNamespace.Inner);

                    var rules = ehNamespace.ListAuthorizationRules();
                    HashSet<string> set = new HashSet<string>();

                    foreach (IEventHubNamespaceAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);

                    rules = azure.EventHubNamespaces
                            .AuthorizationRules
                            .ListByNamespace(ehNamespace.ResourceGroupName, ehNamespace.Name);

                    set.Clear();

                    foreach (IEventHubNamespaceAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);

                    azure.EventHubNamespaces
                            .AuthorizationRules
                                .Define("sndRule2")
                                .WithExistingNamespaceId(ehNamespace.Id)
                                .WithSendAccess()
                                .Create();

                    rules = ehNamespace.ListAuthorizationRules();
                    set.Clear();
                    foreach (IEventHubNamespaceAuthorizationRule rule in rules)
                    {
                        set.Add(rule.Name);
                    }
                    Assert.Contains("mngRule1", set);
                    Assert.Contains("sndRule1", set);
                    Assert.Contains("sndRule2", set);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact(Skip = "Server side: resource group delete operation (final clean up) keep running for hours when it contains pairing")]
        public void CanManageGeoDisasterRecoveryPairing()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");
                var geodrName = TestUtilities.GenerateName("geodr");
                var namespaceName1 = TestUtilities.GenerateName("ns111");
                var namespaceName2 = TestUtilities.GenerateName("ns222");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    IEventHubNamespace primaryNamespace = azure.EventHubNamespaces
                            .Define(namespaceName1)
                            .WithRegion(Region.USSouthCentral)
                            .WithNewResourceGroup(groupName)
                            .Create();

                    IEventHubNamespace secondaryNamespace = azure.EventHubNamespaces
                            .Define(namespaceName2)
                            .WithRegion(Region.USNorthCentral)
                            .WithExistingResourceGroup(groupName)
                            .Create();

                    Exception exception = null;
                    Exception breakingFailed = null;
                    IEventHubDisasterRecoveryPairing pairing = null;
                    try
                    {
                        pairing = azure.EventHubDisasterRecoveryPairings
                                .Define(geodrName)
                                .WithExistingPrimaryNamespace(primaryNamespace)
                                .WithExistingSecondaryNamespace(secondaryNamespace)
                                .Create();

                        while (pairing.ProvisioningState != ProvisioningStateDR.Succeeded)
                        {
                            pairing = pairing.Refresh();
                            SdkContext.DelayProvider.Delay(15 * 1000);
                            if (pairing.ProvisioningState == ProvisioningStateDR.Failed)
                            {
                                Assert.True(false, "Provisioning state of the pairing is FAILED");
                            }
                        }

                        Assert.Equal(pairing.Name, geodrName, ignoreCase: true);
                        Assert.Equal(pairing.PrimaryNamespaceResourceGroupName, groupName, ignoreCase: true);
                        Assert.Equal(pairing.PrimaryNamespaceName, primaryNamespace.Name, ignoreCase: true);
                        Assert.Equal(pairing.SecondaryNamespaceId, secondaryNamespace.Id, ignoreCase: true);

                        var rules = pairing.ListAuthorizationRules();
                        Assert.True(rules.Count() > 0);
                        foreach (IDisasterRecoveryPairingAuthorizationRule rule in rules)
                        {
                            IDisasterRecoveryPairingAuthorizationKey keys = rule.GetKeys();
                            Assert.NotNull(keys.AliasPrimaryConnectionString);
                            Assert.NotNull(keys.AliasPrimaryConnectionString);
                            Assert.NotNull(keys.PrimaryKey);
                            Assert.NotNull(keys.SecondaryKey);
                        }

                        IEventHubDisasterRecoveryPairings pairingsCol = azure.EventHubDisasterRecoveryPairings;
                        var pairings = pairingsCol
                                .ListByNamespace(primaryNamespace.ResourceGroupName, primaryNamespace.Name);

                        Assert.True(pairings.Count() > 0);

                        bool found = false;
                        foreach (IEventHubDisasterRecoveryPairing pairing1 in pairings)
                        {
                            if (pairing1.Name.Equals(pairing.Name, StringComparison.OrdinalIgnoreCase))
                            {
                                found = true;
                                Assert.Equal(pairing1.PrimaryNamespaceResourceGroupName, groupName);
                                Assert.Equal(pairing1.PrimaryNamespaceName, primaryNamespace.Name);
                                Assert.Equal(pairing1.SecondaryNamespaceId, secondaryNamespace.Id);
                            }
                        }
                        Assert.True(found);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }
                    finally
                    {
                        if (exception != null && pairing != null)
                        {
                            // Resource group cannot be deleted if the pairing-replication is 
                            // (backgroud work by RP) progress so pairing must forcefully break.
                            try
                            {
                                pairing.BreakPairing();
                            }
                            catch (Exception ex)
                            {
                                breakingFailed = ex;
                            }
                        }
                    }
                    if (exception != null && breakingFailed != null)
                    {
                        AggregateException cex = new AggregateException(exception, breakingFailed);
                        throw cex;
                    }
                    if (exception != null)
                    {
                        throw exception;
                    }
                    if (breakingFailed != null)
                    {
                        throw breakingFailed;
                    }
                    pairing.Refresh();
                    pairing.FailOver();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
