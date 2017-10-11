// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xunit;

namespace Fluent.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PrivateComplex : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private INetworks networks;
        private List<IPublicIPAddress> testPips;
        private ApplicationGatewayHelper applicationGatewayHelper;

        public PrivateComplex([CallerMemberName] string methodName = "testframework_failed")
            : base(methodName)
        {
            applicationGatewayHelper = new ApplicationGatewayHelper(TestUtilities.GenerateName("", methodName));
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {
            testPips = new List<IPublicIPAddress>(applicationGatewayHelper.EnsurePIPs(resources.Manager.PublicIPAddresses));
            networks = resources.Manager.Networks;

            INetwork vnet = networks.Define("net" + applicationGatewayHelper.TestId)
                .WithRegion(applicationGatewayHelper.Region)
                .WithNewResourceGroup(applicationGatewayHelper.GroupName)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/29")
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            Thread creationThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
            // Create an application gateway
            resources.Define(applicationGatewayHelper.AppGatewayName)
                .WithRegion(applicationGatewayHelper.Region)
                .WithExistingResourceGroup(applicationGatewayHelper.GroupName)

                // Request routing rules
                .DefineRequestRoutingRule("rule80")
                    .FromPrivateFrontend()
                    .FromFrontendHttpPort(80)
                    .ToBackendHttpPort(8080)
                    .ToBackendIPAddress("11.1.1.1")
                    .ToBackendIPAddress("11.1.1.2")
                    .WithCookieBasedAffinity()
                    .Attach()
                .DefineRequestRoutingRule("rule443")
                    .FromPrivateFrontend()
                    .FromFrontendHttpsPort(443)
                    .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets", "myTest._pfx")))
                    .WithSslCertificatePassword("Abc123")
                    .ToBackendHttpConfiguration("config1")
                    .ToBackend("backend1")
                .Attach()
                .DefineRequestRoutingRule("rule9000")
                    .FromListener("listener1")
                    .ToBackendHttpConfiguration("config1")
                    .ToBackend("backend1")
                    .Attach()
                .DefineRequestRoutingRule("ruleRedirect")
                    .FromPrivateFrontend()
                    .FromFrontendHttpsPort(444)
                    .WithSslCertificate("cert1")
                    .WithRedirectConfiguration("redirect1")
                    .Attach()

                // Additional/explicit backend HTTP setting configs
                .DefineBackendHttpConfiguration("config1")
                    .WithPort(8081)
                    .WithRequestTimeout(45)
                    .Attach()
                .DefineBackendHttpConfiguration("config2")
                    .Attach()

                // Additional/explicit backends
                .DefineBackend("backend1")
                    .WithIPAddress("11.1.1.3")
                    .WithIPAddress("11.1.1.4")
                    .Attach()
                .DefineBackend("backend2")
                    .Attach()

                // Additional/explicit frontend listeners
                .DefineListener("listener1")
                    .WithPrivateFrontend()
                    .WithFrontendPort(9000)
                    .WithHttp()
                    .Attach()

                // Additional/explicit certificates
                .DefineSslCertificate("cert1")
                    .WithPfxFromFile(new FileInfo(Path.Combine("Assets", "myTest2._pfx")))
                    .WithPfxPassword("Abc123")
                    .Attach()

                // Authentication certificates
                .DefineAuthenticationCertificate("auth2")
                    .FromFile(new FileInfo(Path.Combine("Assets", "myTest2.cer")))
                    .Attach()

                // Additional/explicit backend HTTP setting configs
                .DefineBackendHttpConfiguration("config1")
                    .WithPort(8081)
                    .WithRequestTimeout(45)
                    .WithHttps()
                    .WithAuthenticationCertificateFromFile(new FileInfo(Path.Combine("Assets", "myTest.cer")))
                    .Attach()

                .DefineBackendHttpConfiguration("config2")
                    .WithPort(8082)
                    .WithHttps()
                    .WithAuthenticationCertificate("auth2")
                    // Add the same cert, so only one should be added
                    .WithAuthenticationCertificateFromFile(new FileInfo(Path.Combine("Assets", "myTest2.cer")))
                    .Attach()

                // Redirect configurations
                .DefineRedirectConfiguration("redirect1")
                    .WithType(ApplicationGatewayRedirectType.Permanent)
                    .WithTargetListener("listener1")
                    .WithPathIncluded()
                    .Attach()
                .DefineRedirectConfiguration("redirect2")
                    .WithType(ApplicationGatewayRedirectType.Temporary)
                    .WithTargetUrl("http://www.microsoft.com")
                    .WithQueryStringIncluded()
                    .Attach()

                .WithExistingSubnet(vnet, "subnet1")
                .WithSize(ApplicationGatewaySkuName.StandardMedium)
                .WithInstanceCount(2)
                .Create();
            });

            // Start creating in a separate thread...
            creationThread.Start();

            // ...But don't wait till the end - not needed for the test, 30 sec should be enough
            TestHelper.Delay(30 * 1000);

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, appGateway.Size);
            Assert.Equal(2, appGateway.InstanceCount);
            Assert.False(appGateway.IsPublic);
            Assert.True(appGateway.IsPrivate);
            Assert.Single(appGateway.IPConfigurations);

            // Verify redirect configurations
            Assert.Equal(2, appGateway.RedirectConfigurations.Count);
            IApplicationGatewayRedirectConfiguration redirect = null;
            Assert.True(appGateway.RedirectConfigurations.TryGetValue("redirect1", out redirect));
            Assert.NotNull(redirect);
            Assert.Equal(ApplicationGatewayRedirectType.Permanent, redirect.Type);
            Assert.NotNull(redirect.TargetListener);
            Assert.Equal("listener1", redirect.TargetListener.Name, true);
            Assert.Null(redirect.TargetUrl);
            Assert.True(redirect.IsPathIncluded);
            Assert.False(redirect.IsQueryStringIncluded);
            Assert.Single(redirect.RequestRoutingRules);

            Assert.True(appGateway.RedirectConfigurations.TryGetValue("redirect2", out redirect));
            Assert.NotNull(redirect);
            Assert.Equal(ApplicationGatewayRedirectType.Temporary, redirect.Type);
            Assert.Null(redirect.TargetListener);
            Assert.NotNull(redirect.TargetUrl);
            Assert.Equal("http://www.microsoft.com", redirect.TargetUrl, true);
            Assert.True(redirect.IsQueryStringIncluded);
            Assert.False(redirect.IsPathIncluded);

            // Verify frontend ports
            Assert.Equal(4, appGateway.FrontendPorts.Count);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(443));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(9000));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(444));

            // Verify frontends
            Assert.Single(appGateway.Frontends);
            Assert.Empty(appGateway.PublicFrontends);
            Assert.Single(appGateway.PrivateFrontends);
            IApplicationGatewayFrontend frontend = appGateway.PrivateFrontends.Values.FirstOrDefault();
            Assert.False(frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(4, appGateway.Listeners.Count);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.NotNull(listener);
            Assert.Equal(9000, listener.FrontendPortNumber);
            Assert.Equal(ApplicationGatewayProtocol.Http, listener.Protocol);
            Assert.NotNull(listener.Frontend);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.False(listener.Frontend.IsPublic);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));
            Assert.NotNull(appGateway.ListenerByPortNumber(443));
            Assert.NotNull(appGateway.ListenerByPortNumber(444));

            // Verify SSL certificates
            Assert.Equal(2, appGateway.SslCertificates.Count);
            Assert.Contains("cert1", appGateway.SslCertificates.Keys);

            // Verify backend HTTP settings configs
            Assert.Equal(3, appGateway.BackendHttpConfigurations.Count);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.NotNull(config);
            Assert.Equal(8081, config.Port);
            Assert.Equal(45, config.RequestTimeout);
            Assert.Single(config.AuthenticationCertificates);

            var config2 = appGateway.BackendHttpConfigurations["config2"];
            Assert.NotNull(config2);

            // Verify authentication certificates
            Assert.Equal(2, appGateway.AuthenticationCertificates.Count);
            var authCert2 = appGateway.AuthenticationCertificates["auth2"];
            Assert.NotNull(authCert2);
            Assert.NotNull(authCert2.Data);

            var authCert = config.AuthenticationCertificates.Values.FirstOrDefault();
            Assert.NotNull(authCert);

            Assert.Single(config2.AuthenticationCertificates);
            Assert.Equal(authCert2.Name, config2.AuthenticationCertificates.Values.FirstOrDefault().Name, true);

            // Verify backends
            Assert.Equal(3, appGateway.Backends.Count);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(2, backend.Addresses.Count);
            Assert.True(backend.ContainsIPAddress("11.1.1.3"));
            Assert.True(backend.ContainsIPAddress("11.1.1.4"));
            Assert.True(appGateway.Backends.ContainsKey("backend2"));

            // Verify request routing rules
            Assert.Equal(4, appGateway.RequestRoutingRules.Count);
            IApplicationGatewayRequestRoutingRule rule;

            rule = appGateway.RequestRoutingRules["rule80"];
            Assert.NotNull(rule);
            Assert.Equal(vnet.Id, rule.Listener.Frontend.NetworkId);
            Assert.Equal(80, rule.FrontendPort);
            Assert.Equal(8080, rule.BackendPort);
            Assert.True(rule.CookieBasedAffinity);
            Assert.Equal(2, rule.BackendAddresses.Count);
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.2"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal(vnet.Id, rule.Listener.Frontend.NetworkId);
            Assert.Equal(443, rule.FrontendPort);
            Assert.Equal(ApplicationGatewayProtocol.Https, rule.FrontendProtocol);
            Assert.NotNull(rule.SslCertificate);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config1", rule.BackendHttpConfiguration.Name, true);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend1", rule.Backend.Name, true);

            rule = appGateway.RequestRoutingRules["rule9000"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal("listener1", rule.Listener.Name);
            Assert.NotNull(rule.Listener.SubnetName);
            Assert.NotNull(rule.Listener.NetworkId);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config1", rule.BackendHttpConfiguration.Name, true);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend1", rule.Backend.Name, true);

            rule = appGateway.RequestRoutingRules["ruleRedirect"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.RedirectConfiguration);
            Assert.Equal("redirect1", rule.RedirectConfiguration.Name, true);

            creationThread.Join();

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            int portCount = resource.FrontendPorts.Count;
            int frontendCount = resource.Frontends.Count;
            int listenerCount = resource.Listeners.Count;
            int ruleCount = resource.RequestRoutingRules.Count;
            int backendCount = resource.Backends.Count;
            int configCount = resource.BackendHttpConfigurations.Count;
            int sslCertCount = resource.SslCertificates.Count;
            int authCertCount = resource.AuthenticationCertificates.Count;
            var authCert1 = resource.BackendHttpConfigurations["config1"].AuthenticationCertificates.Values.FirstOrDefault();
            Assert.NotNull(authCert1);

            var pip = resource.Manager.PublicIPAddresses.GetByResourceGroup(applicationGatewayHelper.GroupName, applicationGatewayHelper.PipNames[0]);
            var listener443 = resource.RequestRoutingRules["rule443"].Listener;
            Assert.NotNull(listener443);
            var listenerRedirect = resource.RequestRoutingRules["ruleRedirect"].Listener;
            Assert.NotNull(listenerRedirect);

            resource.Update()
                .WithSize(ApplicationGatewaySkuName.StandardSmall)
                .WithInstanceCount(1)
                .WithoutFrontendPort(9000)
                .WithoutListener("listener1")
                .WithoutBackendIPAddress("11.1.1.4")
                .WithoutBackendHttpConfiguration("config2")
                .WithoutBackend("backend2")
                .WithoutRequestRoutingRule("rule9000")
                .WithoutSslCertificate("cert1")
                .WithoutAuthenticationCertificate(authCert1.Name)

                .UpdateListener(listener443.Name)
                    .WithHostName("foobar")
                    .Parent()
                .UpdateListener(listenerRedirect.Name)
                    .WithHttp()
                    .Parent()

                .UpdateBackendHttpConfiguration("config1")
                    .WithPort(8082)
                    .WithCookieBasedAffinity()
                    .WithRequestTimeout(20)
                    .WithAuthenticationCertificate("auth2")
                    .Parent()

                .UpdateBackend("backend1")
                    .WithoutIPAddress("11.1.1.3")
                    .WithIPAddress("11.1.1.5")
                    .Parent()

                .UpdateRequestRoutingRule("rule80")
                    .ToBackend("backend1")
                    .ToBackendHttpConfiguration("config1")
                    .Parent()
                .UpdateRequestRoutingRule("rule443")
                    .WithoutRedirectConfiguration()
                    .Parent()

                .UpdateRedirectConfiguration("redirect1")
                    .WithTargetUrl("http://azure.com")
                    .WithType(ApplicationGatewayRedirectType.Found)
                    .WithQueryStringIncluded()
                    .WithoutPathIncluded()
                    .Parent()
                .WithoutRedirectConfiguration("redirect2")

                .WithExistingPublicIPAddress(testPips[0]) // Associate with a public IP as well
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            // Get the resource created so far
            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Tags.ContainsKey("tag2"));
            Assert.Equal(ApplicationGatewaySkuName.StandardSmall, resource.Size);
            Assert.Equal(1, resource.InstanceCount);

            // Verify redirect configurations
            Assert.Single(resource.RedirectConfigurations);
            var redirect = resource.RedirectConfigurations["redirect1"];
            Assert.NotNull(redirect);
            Assert.Equal(ApplicationGatewayRedirectType.Found, redirect.Type);
            Assert.Null(redirect.TargetListener);
            Assert.NotNull(redirect.TargetUrl);
            Assert.Equal("http://azure.com", redirect.TargetUrl);

            // Verify frontend ports
            Assert.Equal(portCount - 1, resource.FrontendPorts.Count);
            Assert.Null(resource.FrontendPortNameFromNumber(9000));

            // Verify frontends
            Assert.Equal(frontendCount + 1, resource.Frontends.Count);
            Assert.Single(resource.PublicFrontends);
            Assert.Equal(pip.Id, resource.PublicFrontends.Values.FirstOrDefault().PublicIPAddressId, true);
            Assert.Single(resource.PrivateFrontends);
            IApplicationGatewayFrontend frontend = resource.PrivateFrontends.Values.FirstOrDefault();
            Assert.NotNull(frontend);
            Assert.False(frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(listenerCount - 1, resource.Listeners.Count);
            Assert.DoesNotContain("listener1", resource.Listeners.Keys);

            // Verify backends
            Assert.Equal(backendCount - 1, resource.Backends.Count);
            Assert.DoesNotContain("backend2", resource.Backends.Keys);
            IApplicationGatewayBackend backend = resource.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(1, backend.Addresses.Count);
            Assert.True(backend.ContainsIPAddress("11.1.1.5"));
            Assert.False(backend.ContainsIPAddress("11.1.1.3"));
            Assert.False(backend.ContainsIPAddress("11.1.1.4"));

            // Verify HTTP configs
            Assert.Equal(configCount - 1, resource.BackendHttpConfigurations.Count);
            Assert.False(resource.BackendHttpConfigurations.ContainsKey("config2"));
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config1"];
            Assert.Equal(8082, config.Port);
            Assert.Equal(20, config.RequestTimeout);
            Assert.True(config.CookieBasedAffinity);
            Assert.Single(config.AuthenticationCertificates);
            Assert.DoesNotContain(authCert1.Name, config.AuthenticationCertificates.Keys);
            Assert.Contains("auth2", config.AuthenticationCertificates.Keys);

            // Verify rules
            Assert.Equal(ruleCount - 1, resource.RequestRoutingRules.Count);
            Assert.False(resource.RequestRoutingRules.ContainsKey("rule9000"));

            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule80"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend1", rule.Backend.Name);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config1", rule.BackendHttpConfiguration.Name, true);

            rule = resource.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal("foobar", rule.Listener.HostName);
            Assert.Null(rule.RedirectConfiguration);

            // Verify SSL certificates
            Assert.Equal(sslCertCount - 1, resource.SslCertificates.Count);
            Assert.False(resource.SslCertificates.ContainsKey("cert1"));

            // Verify authentication certificates
            Assert.Equal(authCertCount - 1, resource.AuthenticationCertificates.Count);
            Assert.DoesNotContain("auth1", resource.AuthenticationCertificates.Keys);

            return resource;
        }
    }
}
