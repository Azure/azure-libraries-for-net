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

namespace Fluent.Tests
{

    public class KeyVault
    {

        /**
         * Main entry point.
         * @param args the parameters
         */
        [Fact]
        public void CanCRUDKeyVault()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {        
                // Create user service principal
                String sp = SdkContext.RandomResourceName("sp", 20);
                String us = SdkContext.RandomResourceName("us", 20);
                IGraphRbacManager graphManager = TestHelper.CreateGraphRbacManager();
                string vaultName1 = TestUtilities.GenerateName("vault1");
                string rgName = TestUtilities.GenerateName("rgNEMV");

                IKeyVaultManager manager = TestHelper.CreateKeyVaultManager();

                IServicePrincipal servicePrincipal = graphManager.ServicePrincipals
                        .Define(sp)
                        .WithNewApplication("http://" + sp)
                        .Create();

                IActiveDirectoryUser user = graphManager.Users
                        .Define(us)
                        .WithEmailAlias(us)
                        .WithPassword("P@$$w0rd")
                        .Create();
                //var spnCredentialsClientId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];

                try
                {
                    IVault vault = manager.Vaults
                            .Define(vaultName1)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .DefineAccessPolicy()
                                .ForServicePrincipal("http://" + sp)
                                .AllowKeyPermissions(KeyPermissions.List)
                                .AllowSecretAllPermissions()
                                .AllowCertificatePermissions(CertificatePermissions.Get)
                                .Attach()
                            .DefineAccessPolicy()
                                .ForUser(us)
                                .AllowKeyAllPermissions()
                                .AllowSecretAllPermissions()
                                .AllowCertificatePermissions(CertificatePermissions.Get, CertificatePermissions.List, CertificatePermissions.Create)
                                .Attach()
                            .Create();
                    Assert.NotNull(vault);
                    Assert.Equal(vaultName1, vault.Name);
                    foreach (IAccessPolicy policy in vault.AccessPolicies)
                    {
                        if (policy.ObjectId.Equals(servicePrincipal.Id))
                        {
                            Assert.Equal(1, policy.Permissions.Keys.Count);
                            Assert.Equal(KeyPermissions.List, policy.Permissions.Keys[0]);
                            Assert.Equal(8, policy.Permissions.Secrets.Count);
                            Assert.Equal(1, policy.Permissions.Certificates.Count);
                            Assert.Equal(CertificatePermissions.Get, policy.Permissions.Certificates[0]);
                        }
                        if (policy.ObjectId.Equals(user.Id))
                        {
                            Assert.Equal(16, policy.Permissions.Keys.Count);
                            Assert.Equal(8, policy.Permissions.Secrets.Count);
                            Assert.Equal(3, policy.Permissions.Certificates.Count);
                        }
                    }

                    vault = vault.Update()
                        .UpdateAccessPolicy(servicePrincipal.Id)
                            .AllowKeyAllPermissions()
                            .DisallowSecretAllPermissions()
                            .AllowCertificateAllPermissions()
                            .Parent()
                        .Apply();

                    foreach (IAccessPolicy policy in vault.AccessPolicies)
                    {
                        if (policy.ObjectId.Equals(servicePrincipal.Id))
                        {
                            Assert.Equal(16, policy.Permissions.Keys.Count);
                            Assert.Equal(0, policy.Permissions.Secrets.Count);
                            Assert.Equal(16, policy.Permissions.Certificates.Count);
                        }
                    }
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                        if (servicePrincipal.Id != null)
                            TestHelper.CreateGraphRbacManager().ServicePrincipals.DeleteById(servicePrincipal.Id);
                        if (user.Id != null)
                            TestHelper.CreateGraphRbacManager().Users.DeleteById(user.Id);
                    }
                    catch { }
                }
            }
        }

    }
}