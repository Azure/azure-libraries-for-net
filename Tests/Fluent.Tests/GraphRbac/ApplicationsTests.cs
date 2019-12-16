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
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Fluent.Tests.Graph.RBAC
{
    public class Applications
    {

        [Fact]
        public void CanCRUDApplication()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                String name = SdkContext.RandomResourceName("javasdkapp", 20);

                IActiveDirectoryApplication application = null;
                try
                {
                    application = manager.Applications.Define(name)
                            .WithSignOnUrl("http://easycreate.azure.com/" + name)
                            .DefinePasswordCredential("passwd")
                                .WithPasswordValue("P@ssw0rd")
                                .WithDuration(TimeSpan.FromDays(100))
                                .Attach()
                            .DefineCertificateCredential("cert")
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest.cer"))
                                .WithDuration(TimeSpan.FromDays(100))
                                .Attach()
                            .DefineCertificateCredential()
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest2.cer"))
                                .WithDuration(TimeSpan.FromDays(80))
                                .Attach()
                            .Create();
                    Console.WriteLine(application.Id + " - " + application.ApplicationId);
                    Assert.NotNull(application.Id);
                    Assert.NotNull(application.ApplicationId);
                    Assert.Equal(name, application.Name);
                    Assert.Equal(2, application.CertificateCredentials.Count);
                    Assert.Equal(1, application.PasswordCredentials.Count);
                    Assert.Equal(1, application.ReplyUrls.Count);
                    Assert.Equal(1, application.IdentifierUris.Count);
                    Assert.Equal("http://easycreate.azure.com/" + name, application.SignOnUrl.ToString());

                    // check thumbprint, the customKeyIdentifier would be thumbprint if not set
                    var certificate = new X509Certificate("Assets/myTest2.cer");
                    var certificateCount = 0;
                    foreach (var certificateCredential in application.CertificateCredentials.Values)
                    {
                        if (certificateCredential.Name != "cert")
                        {
                            certificateCount++;
                            Assert.Equal(certificate.GetCertHashString(), certificateCredential.CustomKeyIdentifier);
                        }
                    }
                    Assert.True(certificateCount > 0);

                    application.Update()
                            .DefinePasswordCredential("passwd2")
                                .WithPasswordValue("StrongPass!12")
                                .WithDuration(TimeSpan.FromDays(20))
                                .Attach()
                            .DefineCertificateCredential("cert")
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest2.cer"))
                                .WithDuration(TimeSpan.FromDays(1))
                                .Attach()
                            .WithoutCredentialByIdentifier(certificate.GetCertHashString())
                            .Apply();

                    Console.WriteLine(application.Id + " - " + application.ApplicationId);
                    Assert.Equal(2, application.PasswordCredentials.Count);
                    Assert.Equal(2, application.CertificateCredentials.Count);

                    application.Update()
                            .WithoutCredential("passwd")
                            .Apply();
                    Console.WriteLine(application.Id + " - " + application.ApplicationId);
                    Assert.Equal(1, application.PasswordCredentials.Count);
                    Assert.Equal("passwd2", application.PasswordCredentials.First().Value.Name);
                }
                finally
                {
                    if (application != null)
                    {
                        manager.Applications.DeleteById(application.Id);
                    }
                }
            }
        }
    }
}