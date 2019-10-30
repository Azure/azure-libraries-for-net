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
                var groupName = TestUtilities.GenerateName("rgmsi");

                String identityName1 = TestUtilities.GenerateName("msi-id");
                String identityName2 = TestUtilities.GenerateName("msi-id");

                var appServiceManager = TestHelper.CreateAppServiceManager();
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    // Prepare a definition for yet-to-be-created resource group
                    //
                    var creatableRG = azure.ResourceGroups
                            .Define(groupName)
                            .WithRegion(Region.USSouthCentral);

                    // Create an "User Assigned (External) MSI" residing in the above RG and assign reader access to the virtual network
                    //
                    var createdIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(creatableRG)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Reader)
                            .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName2)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(creatableRG)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Create with new app service plan
                    var webApp = appServiceManager.WebApps.Define(WebAppName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(GroupName1)
                        .WithNewWindowsPlan(PricingTier.BasicB1)
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .WithUserAssignedManagedServiceIdentity()
                        .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                        .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
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
                    Assert.NotNull(webApp.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, webApp.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.True(SetContainsStringWithSubstring(webApp.UserAssignedManagedServiceIdentityIds, identityName1));
                    Assert.True(SetContainsStringWithSubstring(webApp.UserAssignedManagedServiceIdentityIds, identityName2));

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        UploadFileToWebApp(webApp.GetPublishingProfile(), Path.Combine(".", "Assets", "appservicemsi.war"));

                        SdkContext.DelayProvider.Delay(30000);

                        string response = CheckAddress("http://" + WebAppName1 + "." + "azurewebsites.net/appservicemsi/");
                        Assert.NotNull(response);
                        Assert.Contains(webApp.ResourceGroupName, response);
                        Assert.Contains(webApp.Id, response);
                    }

                    //Remove the system assigned identity
                    webApp.Update().
                        WithoutSystemAssignedManagedServiceIdentity().
                        Apply();

                    //Do a fetch so that we can test the update path 
                    webApp = appServiceManager.WebApps.GetById(webApp.Id);

                    Assert.NotNull(webApp);

                    Assert.Null(webApp.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.Null(webApp.SystemAssignedManagedServiceIdentityTenantId);
                    Assert.NotNull(webApp.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, webApp.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.True(SetContainsStringWithSubstring(webApp.UserAssignedManagedServiceIdentityIds, identityName1));
                    Assert.True(SetContainsStringWithSubstring(webApp.UserAssignedManagedServiceIdentityIds, identityName2));
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(GroupName1);
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(groupName);
                    }
                    catch { }
                }
            }
        }

        private static bool SetContainsStringWithSubstring(ISet<string> setOfStrings, string stringToSearch)
        {
            foreach (var value in setOfStrings)
            {
                if (value.Contains(stringToSearch))
                {
                    return true;
                }
            }

            return false;
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