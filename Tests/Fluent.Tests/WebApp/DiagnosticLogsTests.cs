// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class DiagnosticLogs
    {
        [Fact]
        public void CanCRUDWebAppWithDiagnosticLogs()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string WebAppName = TestUtilities.GenerateName("java-web-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                try
                {
                    // CREATE
                    var webApp = appServiceManager.WebApps.Define(WebAppName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(GroupName)
                        .WithNewWindowsPlan(PricingTier.BasicB1)
                        .DefineDiagnosticLogsConfiguration()
                            .WithApplicationLogging()
                            .WithLogLevel(LogLevel.Information)
                            .WithApplicationLogsStoredOnFileSystem()
                            .Attach()
                        .DefineDiagnosticLogsConfiguration()
                            .WithWebServerLogging()
                            .WithWebServerLogsStoredOnFileSystem()
                            .WithWebServerFileSystemQuotaInMB(50)
                            .WithUnlimitedLogRetentionDays()
                            .Attach()
                        .Create();

                    Assert.NotNull(webApp);
                    Assert.NotNull(webApp.DiagnosticLogsConfig);
                    Assert.Equal(LogLevel.Information, webApp.DiagnosticLogsConfig.ApplicationLoggingFileSystemLogLevel);
                    Assert.Equal(LogLevel.Off, webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobLogLevel);
                    Assert.Null(webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobContainer);
                    Assert.Equal(0, webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobRetentionDays);
                    Assert.Equal(50, webApp.DiagnosticLogsConfig.WebServerLoggingFileSystemQuotaInMB);
                    Assert.Equal(0, webApp.DiagnosticLogsConfig.WebServerLoggingFileSystemRetentionDays);
                    Assert.Null(webApp.DiagnosticLogsConfig.WebServerLoggingStorageBlobContainer);
                    Assert.Equal(0, webApp.DiagnosticLogsConfig.WebServerLoggingStorageBlobRetentionDays);
                    Assert.False(webApp.DiagnosticLogsConfig.DetailedErrorMessages);
                    Assert.False(webApp.DiagnosticLogsConfig.FailedRequestsTracing);

                    webApp.Update()
                        .UpdateDiagnosticLogsConfiguration()
                            .WithoutApplicationLogging()
                            .Parent()
                        .UpdateDiagnosticLogsConfiguration()
                            .WithWebServerLogging()
                            .WithWebServerLogsStoredOnFileSystem()
                            .WithWebServerFileSystemQuotaInMB(80)
                            .WithLogRetentionDays(3)
                            .WithDetailedErrorMessages(true)
                            .WithFailedRequestTracing(true)
                            .Parent()
                        .Apply();

                    Assert.NotNull(webApp);
                    Assert.NotNull(webApp.DiagnosticLogsConfig);
                    Assert.Equal(LogLevel.Off, webApp.DiagnosticLogsConfig.ApplicationLoggingFileSystemLogLevel);
                    Assert.Equal(LogLevel.Off, webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobLogLevel);
                    Assert.Null(webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobContainer);
                    Assert.Equal(0, webApp.DiagnosticLogsConfig.ApplicationLoggingStorageBlobRetentionDays);
                    Assert.Equal(80, webApp.DiagnosticLogsConfig.WebServerLoggingFileSystemQuotaInMB);
                    Assert.Equal(3, webApp.DiagnosticLogsConfig.WebServerLoggingFileSystemRetentionDays);
                    Assert.Null(webApp.DiagnosticLogsConfig.WebServerLoggingStorageBlobContainer);
                    Assert.Equal(3, webApp.DiagnosticLogsConfig.WebServerLoggingStorageBlobRetentionDays);
                    Assert.True(webApp.DiagnosticLogsConfig.DetailedErrorMessages);
                    Assert.True(webApp.DiagnosticLogsConfig.FailedRequestsTracing);
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