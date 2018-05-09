// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using CoreFtp;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class WebAppsMsi
    {
        [Fact]
        public void CanCRUDWebAppWithMsi()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName1 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // Create with new app service plan
                    var webApp = appServiceManager.WebApps.Define(WebAppName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .WithNewWindowsPlan(PricingTier.BasicB1)
                        .WithRemoteDebuggingEnabled(RemoteVisualStudioVersion.VS2013)
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Create();
                    Assert.NotNull(webApp);
                    Assert.Equal(Region.USWest, webApp.Region);
                    var plan = appServiceManager.AppServicePlans.GetById(webApp.AppServicePlanId);
                    Assert.NotNull(plan);
                    Assert.Equal(Region.USWest, plan.Region);
                    Assert.Equal(PricingTier.BasicB1, plan.PricingTier);
                    Assert.NotNull(webApp.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(webApp.SystemAssignedManagedServiceIdentityTenantId);

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        UploadFileToWebApp(webApp.GetPublishingProfile(), Path.Combine(".", "Assets", "appservicemsi.war"));

                        SdkContext.DelayProvider.Delay(10000);

                        string response = CheckAddress("http://" + WebAppName1 + "." + "azurewebsites.net/appservicemsi/");
                        Assert.NotNull(response);
                        Assert.Contains(webApp.ResourceGroupName, response);
                        Assert.Contains(webApp.Id, response);
                    }
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

        private static string CheckAddress(string url, IDictionary<string, string> headers = null)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                    return client.GetAsync(url).Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }

            return "[Running in PlaybackMode]";
        }

        private static void UploadFileToWebApp(IPublishingProfile profile, string filePath, string fileName = null)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                string host = profile.FtpUrl.Split(new char[] { '/' }, 2)[0];

                using (var ftpClient = new FtpClient(new FtpClientConfiguration
                {
                    Host = host,
                    Username = profile.FtpUsername,
                    Password = profile.FtpPassword
                }))
                {
                    var fileinfo = new FileInfo(filePath);
                    ftpClient.LoginAsync().GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "site"))
                    {
                        ftpClient.CreateDirectoryAsync("site").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./site").GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "wwwroot"))
                    {
                        ftpClient.CreateDirectoryAsync("wwwroot").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./wwwroot").GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "webapps"))
                    {
                        ftpClient.CreateDirectoryAsync("webapps").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./webapps").GetAwaiter().GetResult();

                    if (fileName == null)
                    {
                        fileName = Path.GetFileName(filePath);
                    }
                    while (fileName.Contains("/"))
                    {
                        int slash = fileName.IndexOf("/");
                        string subDir = fileName.Substring(0, slash);
                        ftpClient.CreateDirectoryAsync(subDir).GetAwaiter().GetResult();
                        ftpClient.ChangeWorkingDirectoryAsync("./" + subDir);
                        fileName = fileName.Substring(slash + 1);
                    }

                    using (var writeStream = ftpClient.OpenFileWriteStreamAsync(fileName).GetAwaiter().GetResult())
                    {
                        var fileReadStream = fileinfo.OpenRead();
                        fileReadStream.CopyToAsync(writeStream).GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}