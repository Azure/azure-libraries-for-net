// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class FunctionApps
    {
        [Fact]
        public void CanCRUDFunctionApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string GroupName2 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName2 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName3 = TestUtilities.GenerateName("java-webapp-");
                string StorageName1 = TestUtilities.GenerateName("javast");
                if (StorageName1.Length >= 23)
                {
                    StorageName1 = StorageName1.Substring(0, 20);
                }
                StorageName1 = StorageName1.Replace("-", string.Empty);

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create with consumption plan
                    var functionApp1 = appServiceManager.FunctionApps.Define(WebAppName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .Create();
                    Assert.NotNull(functionApp1);
                    Assert.Equal(Region.USWest, functionApp1.Region);
                    var plan1 = appServiceManager.AppServicePlans.GetById(functionApp1.AppServicePlanId);
                    Assert.NotNull(plan1);
                    Assert.Equal(Region.USWest, plan1.Region);
                    Assert.Equal(new PricingTier("Dynamic", "Y1"), plan1.PricingTier);

                    IStorageAccount storageAccount1 = getStorageAccount(appServiceManager.StorageManager, functionApp1,
                        out IReadOnlyDictionary<string, IAppSetting> appSettings1, out StorageSettings storageSettings1);
                    // consumption plan requires this 2 settings
                    Assert.True(appSettings1.ContainsKey(KeyContentAzureFileConnectionString));
                    Assert.True(appSettings1.ContainsKey(KeyContentShare));
                    Assert.Equal(appSettings1[KeyAzureWebJobsStorage].Value, appSettings1[KeyContentAzureFileConnectionString].Value);
                    // verify accountKey
                    Assert.Equal(storageAccount1.GetKeys()[0].Value, storageSettings1.AccountKey);

                    // List functions of App1 before deployement
                    IEnumerable<IFunctionEnvelope> envelopes = functionApp1.ListFunctions();
                    Assert.Empty(envelopes);

                    // Deploy function into App1
                    functionApp1.Deploy()
                        .WithPackageUri("https://github.com/Azure/azure-libraries-for-net/raw/master/Samples/Asset/square-function-app.zip")
                        .WithExistingDeploymentsDeleted(true)
                        .Execute();

                    // List functions of App1 after deployement
                    envelopes = functionApp1.ListFunctions();
                    Assert.Single(envelopes);

                    IPagedCollection<IFunctionEnvelope> envelopesFromAsync = Extensions.Synchronize(() => functionApp1.ListFunctionsAsync(true));
                    Assert.Single(envelopesFromAsync);

                    // Verify function envelope
                    IFunctionEnvelope envelope = envelopes.First();
                    Assert.NotEmpty(envelope.Id);
                    Assert.Equal(WebAppName1 + "/square", envelope.Name);
                    Assert.Equal("Microsoft.Web/sites/functions", envelope.Type);
                    Assert.Equal(Region.USWest, envelope.Region);
                    Assert.NotEmpty(envelope.ScriptRootPathHref);
                    Assert.NotEmpty(envelope.ScriptHref);
                    Assert.NotEmpty(envelope.ConfigHref);
                    Assert.NotEmpty(envelope.SecretsFileHref);
                    Assert.NotEmpty(envelope.Href);
                    Assert.NotNull(envelope.Config);

                    // Create in a new group with existing consumption plan
                    var functionApp2 = appServiceManager.FunctionApps.Define(WebAppName2)
                        .WithExistingAppServicePlan(plan1)
                        .WithNewResourceGroup(GroupName2)
                        .WithExistingStorageAccount(functionApp1.StorageAccount)
                        .Create();
                    Assert.NotNull(functionApp2);
                    Assert.Equal(Region.USWest, functionApp2.Region);

                    // Create with app service plan
                    var functionApp3 = appServiceManager.FunctionApps.Define(WebAppName3)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(GroupName2)
                        .WithNewAppServicePlan(PricingTier.BasicB1)
                        .WithExistingStorageAccount(functionApp1.StorageAccount)
                        .Create();
                    Assert.NotNull(functionApp3);
                    Assert.Equal(Region.USWest, functionApp3.Region);

                    IStorageAccount storageAccount3 = getStorageAccount(appServiceManager.StorageManager, functionApp3,
                        out IReadOnlyDictionary<string, IAppSetting> appSettings3, out StorageSettings storageSettings3);
                    // app service plan does not have this 2 settings
                    // https://github.com/Azure/azure-libraries-for-net/issues/485
                    Assert.False(appSettings3.ContainsKey(KeyContentAzureFileConnectionString));
                    Assert.False(appSettings3.ContainsKey(KeyContentShare));
                    // verify accountKey
                    Assert.Equal(storageAccount3.GetKeys()[0].Value, storageSettings3.AccountKey);

                    // Get
                    var functionApp = appServiceManager.FunctionApps.GetByResourceGroup(GroupName1, functionApp1.Name);
                    Assert.Equal(functionApp1.Id, functionApp.Id);
                    functionApp = appServiceManager.FunctionApps.GetById(functionApp2.Id);
                    Assert.Equal(functionApp2.Name, functionApp.Name);

                    // List
                    var functionApps = appServiceManager.FunctionApps.ListByResourceGroup(GroupName1);
                    Assert.Single(functionApps);
                    functionApps = appServiceManager.FunctionApps.ListByResourceGroup(GroupName2);
                    Assert.Equal(2, functionApps.Count());

                    // Update
                    functionApp2.Update()
                        .WithNewStorageAccount(StorageName1, Microsoft.Azure.Management.Storage.Fluent.Models.SkuName.StandardGRS)
                        .Apply();
                    Assert.Equal(StorageName1, functionApp2.StorageAccount.Name);
                    IStorageAccount storageAccount2 = getStorageAccount(appServiceManager.StorageManager, functionApp2,
                         out IReadOnlyDictionary<string, IAppSetting> appSettings2, out StorageSettings storageSettings2);
                    Assert.True(appSettings2.ContainsKey(KeyContentAzureFileConnectionString));
                    Assert.True(appSettings2.ContainsKey(KeyContentShare));
                    Assert.Equal(appSettings2[KeyAzureWebJobsStorage].Value, appSettings2[KeyContentAzureFileConnectionString].Value);
                    Assert.Equal(StorageName1, storageAccount2.Name);
                    Assert.Equal(storageAccount2.GetKeys()[0].Value, storageSettings2.AccountKey);

                    // Update, verify modify AppSetting does not create new storage account
                    // https://github.com/Azure/azure-libraries-for-net/issues/457
                    int numStorageAccountBefore = appServiceManager.StorageManager.StorageAccounts.ListByResourceGroup(GroupName1).Count();
                    functionApp1.Update()
                        .WithAppSetting("newKey", "newValue")
                        .Apply();
                    int numStorageAccountAfter = appServiceManager.StorageManager.StorageAccounts.ListByResourceGroup(GroupName1).Count();
                    Assert.Equal(numStorageAccountBefore, numStorageAccountAfter);
                    IStorageAccount storageAccount1Updated = getStorageAccount(appServiceManager.StorageManager, functionApp1, 
                        out IReadOnlyDictionary<string, IAppSetting> appSettings1Updated, out _);
                    Assert.True(appSettings1Updated.ContainsKey("newKey"));
                    Assert.Equal(appSettings1[KeyAzureWebJobsStorage].Value, appSettings1Updated[KeyAzureWebJobsStorage].Value);
                    Assert.Equal(appSettings1[KeyContentAzureFileConnectionString].Value, appSettings1Updated[KeyContentAzureFileConnectionString].Value);
                    Assert.Equal(appSettings1[KeyContentShare].Value, appSettings1Updated[KeyContentShare].Value);
                    Assert.Equal(storageAccount1.Name, storageAccount1Updated.Name);

                    // Scale
                    functionApp3.Update()
                        .WithNewAppServicePlan(PricingTier.StandardS2)
                        .Apply();
                    var plan2 = appServiceManager.AppServicePlans.GetById(functionApp3.AppServicePlanId);
                    Assert.NotNull(plan2);
                    Assert.NotEqual(plan1.Id, plan2.Id);
                    Assert.Equal(Region.USWest, plan2.Region);
                    Assert.Equal(PricingTier.StandardS2, plan2.PricingTier);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName2);
                    }
                    catch { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName1);
                    }
                    catch { }
                }
            }
        }
        
        [Fact]
        public void FunctionAppLongNameBug()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("IAmAFuncitonNameThatIsLonger");
                string StorageName1 = TestUtilities.GenerateName("javast");
                if (StorageName1.Length >= 23)
                {
                    StorageName1 = StorageName1.Substring(0, 20);
                }
                StorageName1 = StorageName1.Replace("-", string.Empty);

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create with consumption plan
                    var functionApp1 = appServiceManager.FunctionApps.Define(WebAppName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .WithNewStorageAccount(StorageName1, Microsoft.Azure.Management.Storage.Fluent.Models.SkuName.StandardGRS)
                        .WithNewAppServicePlan(PricingTier.PremiumP1)
                        .Create();

                    Assert.NotNull(functionApp1);
                    functionApp1
                        .Update()
                        .WithTag("PackageUpdateDate", "07/17/2018")
                        .Apply();

                    Assert.NotNull(functionApp1.Tags);
                    Assert.Equal(1, functionApp1.Tags.Count);
                    Assert.Equal("07/17/2018", functionApp1.Tags["PackageUpdateDate"]);

                    var functionAppFromGet = appServiceManager.FunctionApps.GetById(functionApp1.Id);
                    Assert.NotNull(functionAppFromGet.Tags);
                    Assert.Equal(1, functionAppFromGet.Tags.Count);
                    Assert.Equal("07/17/2018", functionAppFromGet.Tags["PackageUpdateDate"]);

                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName1);
                    }
                    catch { }
                }
            }
        }

        private static readonly string KeyAzureWebJobsStorage = "AzureWebJobsStorage";
        private static readonly string KeyContentAzureFileConnectionString = "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING";
        private static readonly string KeyContentShare = "WEBSITE_CONTENTSHARE";

        private static readonly string AccountNameSegment = "AccountName=";
        private static readonly string AccountKeySegment = "AccountKey=";

        private class StorageSettings
        {
            internal string AccountName { get; set; }
            internal string AccountKey { get; set; }
        }

        private static IStorageAccount getStorageAccount(IStorageManager storageManager, IFunctionApp functionApp,
            out IReadOnlyDictionary<string, IAppSetting> appSettings, out StorageSettings storageSettings)
        {
            appSettings = functionApp.GetAppSettings();
            storageSettings = new StorageSettings();

            string storageAccountConnectionString = appSettings[KeyAzureWebJobsStorage].Value;
            string[] segments = storageAccountConnectionString.Split(";");
            foreach (string segment in segments)
            {
                if (segment.StartsWith(AccountNameSegment))
                {
                    storageSettings.AccountName = segment.Remove(0, AccountNameSegment.Length);
                }
                else if (segment.StartsWith(AccountKeySegment))
                {
                    storageSettings.AccountKey = segment.Remove(0, AccountKeySegment.Length);
                }
            }
            if (storageSettings.AccountName != null)
            {
                IEnumerable<IStorageAccount> storageAccounts = storageManager.StorageAccounts.List();
                foreach (IStorageAccount storageAccount in storageAccounts)
                {
                    if (storageAccount.Name == storageSettings.AccountName)
                    {
                        return storageAccount;
                    }
                }
            }

            throw new System.InvalidOperationException("storage account not found for connection string: " + storageAccountConnectionString);
        }
    }
}