// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class WebApps
    {
        [Fact]
        public void CanCRUDWebApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string GroupName2 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName2 = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName1 = TestUtilities.GenerateName("java-asp-");
                string AppServicePlanName2 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create with new app service plan
                    var webApp1 = appServiceManager.WebApps.Define(WebAppName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .WithNewWindowsPlan(PricingTier.BasicB1)
                        .WithRemoteDebuggingEnabled(RemoteVisualStudioVersion.VS2019)
                        .Create();
                    Assert.NotNull(webApp1);
                    Assert.Equal(Region.USWest, webApp1.Region);
                    var plan1 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                    Assert.NotNull(plan1);
                    Assert.Equal(Region.USWest, plan1.Region);
                    Assert.Equal(PricingTier.BasicB1, plan1.PricingTier);

                    // Create in a new group with existing app service plan
                    var webApp2 = appServiceManager.WebApps.Define(WebAppName2)
                        .WithExistingWindowsPlan(plan1)
                        .WithNewResourceGroup(GroupName2)
                        .Create();
                    Assert.NotNull(webApp2);
                    Assert.Equal(Region.USWest, webApp1.Region);

                    // Get
                    var webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName1, webApp1.Name);
                    Assert.Equal(webApp1.Id, webApp.Id);
                    webApp = appServiceManager.WebApps.GetById(webApp2.Id);
                    Assert.Equal(webApp2.Name, webApp.Name);
                    webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName1, "nonexist");
                    Assert.Null(webApp);

                    // List
                    var webApps = appServiceManager.WebApps.ListByResourceGroup(GroupName1);
                    Assert.Single(webApps);
                    webApps = appServiceManager.WebApps.ListByResourceGroup(GroupName2);
                    Assert.Single(webApps);

                    // Update
                    webApp1.Update()
                        .WithNewAppServicePlan(PricingTier.StandardS2)
                        .WithRuntimeStack(WebAppRuntimeStack.NETCore)
                        .Apply();
                    var plan2 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                    Assert.NotNull(plan2);
                    Assert.NotEqual(plan1.Id, plan2.Id);
                    Assert.Equal(Region.USWest, plan2.Region);
                    Assert.Equal(PricingTier.StandardS2, plan2.PricingTier);
                    Assert.Equal(WebAppRuntimeStack.NETCore.Runtime, appServiceManager.Inner.WebApps.ListMetadataAsync(webApp1.ResourceGroupName, webApp1.Name).Result.Properties["CURRENT_STACK"]);

                    // Delete
                    string planId = webApp2.AppServicePlanId;
                    Assert.NotNull(appServiceManager.AppServicePlans.GetById(planId));
                    appServiceManager.WebApps.DeleteById(webApp2.Id, null, false);
                    Assert.NotNull(appServiceManager.AppServicePlans.GetById(planId));

                    planId = webApp1.AppServicePlanId;
                    Assert.NotNull(appServiceManager.AppServicePlans.GetById(planId));
                    appServiceManager.WebApps.DeleteById(webApp1.Id, null, true);
                    Assert.Null(appServiceManager.AppServicePlans.GetById(planId)); // empty plan been deleted
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName1);
                    }
                    catch { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName2);
                    }
                    catch { }
                }
            }
        }

        // Bugfix from github
        [Fact]
        public void WebAppWithoutPhp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName1 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    var appServicePlan = appServiceManager.AppServicePlans
                        .Define(AppServicePlanName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .WithPricingTier(PricingTier.PremiumP1)
                        .WithOperatingSystem(OperatingSystem.Windows)
                        .WithPerSiteScaling(false)
                        .WithCapacity(2)
                        .Create();

                    var webappSettings = new Dictionary<string, string>();
                    webappSettings.Add("settingKey", "settingValue");

                    var webApp = appServiceManager.WebApps.Define(WebAppName1)
                        .WithExistingWindowsPlan(appServicePlan)
                        .WithExistingResourceGroup(GroupName1)
                        .WithPythonVersion(PythonVersion.Off)
                        .WithAppSettings(webappSettings)
                        .WithConnectionString("connectionName", "connectionValue", ConnectionStringType.Custom)
                        .WithTag("PR", GroupName1.Split('-').Last())
                        .WithPhpVersion(PhpVersion.Off)
                        .WithWebSocketsEnabled(true)
                        .CreateAsync()
                        .Result;
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName1);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDWebAppWithContainer()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName1 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    var appServicePlan = appServiceManager.AppServicePlans
                        .Define(AppServicePlanName1)
                        .WithRegion(Region.USEast)          // many other regions does not have quota for PremiumP1v3
                        .WithNewResourceGroup(GroupName1)
                        .WithPricingTier(PricingTier.PremiumP1v3)
                        .WithOperatingSystem(OperatingSystem.Windows)
                        .Create();

                    var webApp = appServiceManager.WebApps.Define(WebAppName1)
                        .WithExistingWindowsPlan(appServicePlan)
                        .WithExistingResourceGroup(GroupName1)
                        .WithPublicDockerHubImage("mcr.microsoft.com/azure-app-service/samples/aspnethelloworld:latest")
                        .Create();
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.BeginDeleteByName(GroupName1);
                    }
                    catch { }
                }
            }
        }
    }
}