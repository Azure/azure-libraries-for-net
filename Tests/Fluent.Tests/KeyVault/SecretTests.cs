// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using System.Collections.Generic;

namespace Fluent.Tests
{

    public class Secrets
    {

        /**
         * Main entry point.
         * @param args the parameters
         */
        [Fact]
        public void CanCRUDSecret()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {        
                IGraphRbacManager graphManager = TestHelper.CreateGraphRbacManager();
                string vaultName1 = TestUtilities.GenerateName("vault1");
                string secretName = TestUtilities.GenerateName("secret1");
                string rgName = TestUtilities.GenerateName("rgNEMV");

                IKeyVaultManager manager = TestHelper.CreateKeyVaultManager();

                var spnCredentialsClientId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];

                try
                {
                    IVault vault = manager.Vaults
                            .Define(vaultName1)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .DefineAccessPolicy()
                                .ForServicePrincipal(spnCredentialsClientId)
                                .AllowKeyAllPermissions()
                                .AllowSecretAllPermissions()
                                .Attach()
                            .Create();
                    Assert.NotNull(vault);

                    SdkContext.DelayProvider.Delay(10000);

                    var secret = vault.Secrets.Define(secretName)
                            .WithValue("Some secret value")
                            .Create();

                    Assert.NotNull(secret);
                    Assert.NotNull(secret.Id);
                    Assert.Equal("Some secret value", secret.Value);

                    secret = secret.Update()
                            .WithValue("Some updated value")
                            .Apply();

                    Assert.Equal("Some updated value", secret.Value);

                    var versions = secret.ListVersions();

                    int count = 2;
                    foreach (var version in versions)
                    {
                        if ("Some secret value" == version.Value)
                        {
                            count--;
                        }
                        if ("Some updated value" == version.Value)
                        {
                            count--;
                        }
                    }
                    Assert.Equal(0, count);

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