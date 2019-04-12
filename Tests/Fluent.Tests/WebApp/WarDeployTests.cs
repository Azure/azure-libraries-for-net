// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Dns.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class WarDeploy
    {
        [Fact]
        public async Task CanDeployWar()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("javacsmrg");
                var WebAppName = TestUtilities.GenerateName("java-webapp-");
                var AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create web app
                    var webApp = appServiceManager.WebApps.Define(WebAppName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_5Newest)
                        .Create();

                    webApp.WarDeploy(new System.IO.FileInfo(Path.Combine(".", "Assets", "helloworld.war")));

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotNull(webApp);
                        var response = await TestHelper.CheckAddress("http://" + WebAppName + "." + "azurewebsites.net");
                        Assert.Equal(System.Net.HttpStatusCode.OK.ToString(), response.StatusCode.ToString());

                        var body = await response.Content.ReadAsStringAsync();
                        Assert.NotNull(body);
                        Assert.Contains("Azure Samples Hello World", body);
                    }
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

        [Fact]
        public async Task CanDeployWarOnJava11()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("javacsmrg");
                var WebAppName = TestUtilities.GenerateName("java-webapp-");
                var AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create web app
                    var webApp = appServiceManager.WebApps.Define(WebAppName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .WithJavaVersion(JavaVersion.V11Newest)
                        .WithWebContainer(WebContainer.Tomcat8_5Newest)
                        .Create();

                    webApp.WarDeploy(new System.IO.FileInfo(Path.Combine(".", "Assets", "helloworld.war")));

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotNull(webApp);
                        var response = await TestHelper.CheckAddress("https://" + WebAppName + "." + "azurewebsites.net");
                        Assert.Equal(System.Net.HttpStatusCode.OK.ToString(), response.StatusCode.ToString());

                        var body = await response.Content.ReadAsStringAsync();
                        Assert.NotNull(body);
                        Assert.Contains("Azure Samples Hello World", body);
                    }
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