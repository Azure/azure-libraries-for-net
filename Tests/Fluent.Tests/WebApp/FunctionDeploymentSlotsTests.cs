// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class FunctionDeploymentSlots
    {
        [Fact]
        public void CanCRUDSwapSlots()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string WebAppName = TestUtilities.GenerateName("java-webapp-");
                string SlotName1 = TestUtilities.GenerateName("java-slot-");
                string SlotName2 = TestUtilities.GenerateName("java-slot-");
                string SlotName3 = TestUtilities.GenerateName("java-slot-");
                string AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create function app
                    var functionApp = appServiceManager.FunctionApps.Define(WebAppName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName)
                        .WithNewAppServicePlan(PricingTier.StandardS2)
                        .WithAppSetting("appkey", "appvalue")
                        .WithStickyAppSetting("stickykey", "stickyvalue")
                        .WithConnectionString("connectionName", "connectionValue", ConnectionStringType.Custom)
                        .WithStickyConnectionString("stickyName", "stickyValue", ConnectionStringType.Custom)
                        .WithJavaVersion(JavaVersion.V11Newest)
                        .WithWebContainer(WebContainer.Tomcat8_5Newest)
                        .Create();
                    Assert.NotNull(functionApp);
                    Assert.Equal(Region.USWest, functionApp.Region);

                    // Create a deployment slot with empty config
                    var slot1 = functionApp.DeploymentSlots.Define(SlotName1)
                        .WithBrandNewConfiguration()
                        .WithPythonVersion(PythonVersion.V27)
                        .Create();
                    Assert.NotNull(slot1);
                    Assert.NotEqual(JavaVersion.V8Newest, slot1.JavaVersion);
                    Assert.Equal(PythonVersion.V27, slot1.PythonVersion);
                    var appSettingMap = slot1.GetAppSettings();
                    Assert.False(appSettingMap.ContainsKey("appkey"));
                    Assert.False(appSettingMap.ContainsKey("stickykey"));
                    var connectionStringMap = slot1.GetConnectionStrings();
                    Assert.False(connectionStringMap.ContainsKey("connectionName"));
                    Assert.False(connectionStringMap.ContainsKey("stickyName"));
                  

                    // Create a deployment slot with web app's config
                    var slot2 = functionApp.DeploymentSlots.Define(SlotName2)
                        .WithConfigurationFromParent()
                        .Create();
                    Assert.NotNull(slot2);
                    Assert.Equal(JavaVersion.V11Newest, slot2.JavaVersion);
                    appSettingMap = slot2.GetAppSettings();
                    Assert.Equal("appvalue", appSettingMap["appkey"].Value);
                    Assert.False(appSettingMap["appkey"].Sticky);
                    Assert.Equal("stickyvalue", appSettingMap["stickykey"].Value);
                    Assert.True(appSettingMap["stickykey"].Sticky);
                    connectionStringMap = slot2.GetConnectionStrings();
                    Assert.Equal("connectionValue", connectionStringMap["connectionName"].Value);
                    Assert.False(connectionStringMap["connectionName"].Sticky);
                    Assert.Equal("stickyValue", connectionStringMap["stickyName"].Value);
                    Assert.True(connectionStringMap["stickyName"].Sticky);

                    // Update deployment slot
                    slot2.Update()
                            .WithoutJava()
                            .WithPythonVersion(PythonVersion.V34)
                            .WithAppSetting("slot2key", "slot2value")
                            .WithStickyAppSetting("sticky2key", "sticky2value")
                            .Apply();
                    Assert.NotNull(slot2);
                    Assert.Equal(JavaVersion.Off, slot2.JavaVersion);
                    Assert.Equal(PythonVersion.V34, slot2.PythonVersion);
                    appSettingMap = slot2.GetAppSettings();
                    Assert.Equal("slot2value", appSettingMap["slot2key"].Value);

                    // Create 3rd deployment slot with configuration from slot 2
                    var slot3 = functionApp.DeploymentSlots.Define(SlotName3)
                            .WithConfigurationFromDeploymentSlot(slot2)
                            .Create();
                    Assert.NotNull(slot3);
                    Assert.Equal(JavaVersion.Off, slot3.JavaVersion);
                    Assert.Equal(PythonVersion.V34, slot3.PythonVersion);
                    appSettingMap = slot3.GetAppSettings();
                    Assert.Equal("slot2value", appSettingMap["slot2key"].Value);

                    // Get
                    var deploymentSlot = functionApp.DeploymentSlots.GetByName(SlotName3);
                    Assert.Equal(slot3.Id, deploymentSlot.Id);

                    // List
                    var deploymentSlots = functionApp.DeploymentSlots.List();
                    Assert.Equal(3, deploymentSlots.Count());

                    // Swap
                    slot3.Swap(slot1.Name);
                    slot1 = functionApp.DeploymentSlots.GetByName(SlotName1);
                    Assert.Equal(JavaVersion.Off, slot1.JavaVersion);
                    Assert.Equal(PythonVersion.V34, slot1.PythonVersion);
                    Assert.Equal(PythonVersion.V27, slot3.PythonVersion);
                    var appSettings1 = slot1.GetAppSettings();
                    var appSettings3 = slot3.GetAppSettings();
                    Assert.Equal("appvalue", appSettings1["appkey"].Value);
                    Assert.Equal("slot2value", appSettings1["slot2key"].Value);
                    Assert.Equal("sticky2value", appSettings3["sticky2key"].Value);
                    Assert.Equal("stickyvalue", appSettings3["stickykey"].Value);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }
    }
}
