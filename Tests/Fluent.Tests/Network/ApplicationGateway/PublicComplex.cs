// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Fluent.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PublicComplex : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private List<IPublicIPAddress> testPips;
        private ApplicationGatewayHelper applicationGatewayHelper;

        public PublicComplex([CallerMemberName] string methodName = "testframework_failed")
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
            var pip = resources.Manager.PublicIPAddresses.GetByResourceGroup(applicationGatewayHelper.GroupName, applicationGatewayHelper.PipNames[0]);
            Assert.NotNull(pip);

            // Create an application gateway
            try
            {
                resources.Define(applicationGatewayHelper.AppGatewayName)
                    .WithRegion(applicationGatewayHelper.Region)
                    .WithExistingResourceGroup(applicationGatewayHelper.GroupName)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule80")
                        .FromPublicFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendFqdn("www.microsoft.com")
                        .ToBackendFqdn("www.example.com")
                        .ToBackendIPAddress("11.1.1.1")
                        .ToBackendIPAddress("11.1.1.2")
                        .WithCookieBasedAffinity()
                        .Attach()
                    .DefineRequestRoutingRule("rule443")
                        .FromPublicFrontend()
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

                    // Additional/explicit frontend listeners
                    .DefineListener("listener1")
                        .WithPublicFrontend()
                        .WithFrontendPort(9000)
                        .WithHttps()
                        .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets", "myTest2._pfx")))
                        .WithSslCertificatePassword("Abc123")
                        .WithServerNameIndication()
                        .WithHostName("www.fabricam.com")
                        .Attach()

                    // Additional/explicit backends
                    .DefineBackend("backend1")
                        .WithIPAddress("11.1.1.1")
                        .WithIPAddress("11.1.1.2")
                        .Attach()

                    .WithExistingPublicIPAddress(testPips[0])
                    .WithSize(ApplicationGatewaySkuName.StandardMedium)
                    .WithInstanceCount(2)

                    // Probes
                    .DefineProbe("probe1")
                        .WithHost("microsoft.com")
                        .WithPath("/")
                        .WithHttp()
                        .WithTimeoutInSeconds(10)
                        .WithTimeBetweenProbesInSeconds(9)
                        .WithRetriesBeforeUnhealthy(5)
                        .WithHealthyHttpResponseStatusCodeRange(200, 249)
                        .Attach()
                    .DefineProbe("probe2")
                        .WithHost("microsoft.com")
                        .WithPath("/")
                        .WithHttps()
                        .WithTimeoutInSeconds(11)
                        .WithHealthyHttpResponseStatusCodeRange(600, 610)
                        .WithHealthyHttpResponseStatusCodeRange(650, 660)
                        .WithHealthyHttpResponseBodyContents("I am too healthy for this test.")
                        .Attach()

                    // Additional/explicit backend HTTP setting configs
                    .DefineBackendHttpConfiguration("config1")
                        .WithPort(8081)
                        .WithRequestTimeout(45)
                        .WithProbe("probe1")
                        .WithHostHeader("foo")
                        .WithConnectionDrainingTimeoutInSeconds(100)
                        .WithPath("path")
                        .WithAffinityCookieName("cookie")
                        .Attach()

                    .WithDisabledSslProtocols(ApplicationGatewaySslProtocol.TLSv10, ApplicationGatewaySslProtocol.TLSv11)
                    .Create();
            }
            catch
            {
            }

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.True(appGateway.IsPublic);
            Assert.True(!appGateway.IsPrivate);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, appGateway.Size);
            Assert.Equal(2, appGateway.InstanceCount);
            Assert.Equal(1, appGateway.IPConfigurations.Count);

            // Verify frontend ports
            Assert.Equal(3, appGateway.FrontendPorts.Count);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(443));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(9000));

            // Verify frontends
            Assert.Single(appGateway.Frontends);
            Assert.Single(appGateway.PublicFrontends);
            Assert.Empty(appGateway.PrivateFrontends);
            IApplicationGatewayFrontend frontend = appGateway.PublicFrontends.Values.First();
            Assert.True(frontend.IsPublic);
            Assert.False(frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(3, appGateway.Listeners.Count);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.NotNull(listener);
            Assert.Equal(9000, listener.FrontendPortNumber);
            Assert.Equal("www.fabricam.com", listener.HostName);
            Assert.True(listener.RequiresServerNameIndication);
            Assert.NotNull(listener.Frontend);
            Assert.False(listener.Frontend.IsPrivate);
            Assert.True(listener.Frontend.IsPublic);
            Assert.Equal(ApplicationGatewayProtocol.Https, listener.Protocol);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));
            Assert.NotNull(appGateway.ListenerByPortNumber(443));

            // Verify SSL certificates
            Assert.Equal(2, appGateway.SslCertificates.Count);
            
            // Verify backends
            Assert.Equal(2, appGateway.Backends.Count);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(2, backend.Addresses.Count);

            // Verify request routing rules
            Assert.Equal(3, appGateway.RequestRoutingRules.Count);
            IApplicationGatewayRequestRoutingRule rule, rule80;

            rule80 = appGateway.RequestRoutingRules["rule80"];
            Assert.NotNull(rule80);
            Assert.Equal(pip.Id, rule80.PublicIPAddressId, true);
            Assert.Equal(80, rule80.FrontendPort);
            Assert.Equal(8080, rule80.BackendPort);
            Assert.True(rule80.CookieBasedAffinity);
            Assert.Equal(4, rule80.BackendAddresses.Count);
            Assert.True(rule80.Backend.ContainsIPAddress("11.1.1.2"));
            Assert.True(rule80.Backend.ContainsIPAddress("11.1.1.1"));
            Assert.True(rule80.Backend.ContainsFqdn("www.microsoft.com"));
            Assert.True(rule80.Backend.ContainsFqdn("www.example.com"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal(pip.Id, rule.PublicIPAddressId);
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
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config1", rule.BackendHttpConfiguration.Name, true);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend1", rule.Backend.Name, true);

            // Verify backend HTTP settings configs
            Assert.Equal(2, appGateway.BackendHttpConfigurations.Count);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.NotNull(config);
            Assert.Equal(8081, config.Port);
            Assert.Equal(45, config.RequestTimeout);
            Assert.NotNull(config.Probe);
            Assert.Equal("probe1", config.Probe.Name);
            Assert.False(config.IsHostHeaderFromBackend);
            Assert.Equal("foo", config.HostHeader, true);
            Assert.Equal(100, config.ConnectionDrainingTimeoutInSeconds);
            Assert.Equal("/path/", config.Path, true);
            Assert.Equal("cookie", config.AffinityCookieName, true);

            // Verify probes
            Assert.Equal(2, appGateway.Probes.Count);
            IApplicationGatewayProbe probe;
            probe = appGateway.Probes["probe1"];
            Assert.NotNull(probe);
            Assert.Equal("microsoft.com", probe.Host, true);
            Assert.Equal(ApplicationGatewayProtocol.Http, probe.Protocol);
            Assert.Equal("/", probe.Path);
            Assert.Equal(5,  probe.RetriesBeforeUnhealthy);
            Assert.Equal(9, probe.TimeBetweenProbesInSeconds);
            Assert.Equal(10, probe.TimeoutInSeconds);
            Assert.NotNull(probe.HealthyHttpResponseStatusCodeRanges);
            Assert.Single(probe.HealthyHttpResponseStatusCodeRanges);
            Assert.Contains("200-249", probe.HealthyHttpResponseStatusCodeRanges);

            probe = appGateway.Probes["probe2"];
            Assert.NotNull(probe);
            Assert.Equal(ApplicationGatewayProtocol.Https, probe.Protocol);
            Assert.Equal(2, probe.HealthyHttpResponseStatusCodeRanges.Count);
            Assert.Contains("600-610", probe.HealthyHttpResponseStatusCodeRanges);
            Assert.Contains("650-660", probe.HealthyHttpResponseStatusCodeRanges);
            Assert.Equal("I am too healthy for this test.", probe.HealthyHttpResponseBodyContents, true);

            // Verify SSL policy - disabled protocols  
            Assert.Equal(2, appGateway.DisabledSslProtocols.Count);
            Assert.Contains(ApplicationGatewaySslProtocol.TLSv10, appGateway.DisabledSslProtocols);
            Assert.Contains(ApplicationGatewaySslProtocol.TLSv11, appGateway.DisabledSslProtocols);
            Assert.True(!appGateway.DisabledSslProtocols.Contains(ApplicationGatewaySslProtocol.TLSv12));

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            int rulesCount = resource.RequestRoutingRules.Count;
            Assert.Contains("rule80", resource.RequestRoutingRules.Keys);
            var rule80 = resource.RequestRoutingRules["rule80"];
            var backendConfig80 = rule80.BackendHttpConfiguration;
            Assert.NotNull(backendConfig80);

            resource.Update()
                .WithSize(ApplicationGatewaySkuName.StandardSmall)
                .WithInstanceCount(1)
                .UpdateListener("listener1")
                    .WithHostName("www.contoso.com")
                    .Parent()
                .UpdateRequestRoutingRule("rule443")
                    .FromListener("listener1")
                    .Parent()
                .UpdateBackendHttpConfiguration("config1")
                    .WithoutHostHeader()
                    .WithoutConnectionDraining()
                    .WithAffinityCookieName(null)
                    .WithPath(null)
                    .Parent()
                .UpdateBackendHttpConfiguration(backendConfig80.Name)
                    .WithHostHeaderFromBackend()
                    .Parent()
                .WithoutRequestRoutingRule("rule9000")
                .WithoutProbe("probe1")
                .UpdateProbe("probe2")
                    .WithoutHealthyHttpResponseStatusCodeRanges()
                    .WithHealthyHttpResponseBodyContents(null)
                    .Parent()
                .WithoutDisabledSslProtocols(ApplicationGatewaySslProtocol.TLSv10, ApplicationGatewaySslProtocol.TLSv11)
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            // Get the resource created so far
            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.Equal(resource.Size, ApplicationGatewaySkuName.StandardSmall);
            Assert.Equal(1, resource.InstanceCount);

            // Verify listeners
            IApplicationGatewayListener listener = resource.Listeners["listener1"];
            Assert.Equal("www.contoso.com", listener.HostName, true);

            // Verify request routing rules
            Assert.Equal(resource.RequestRoutingRules.Count, rulesCount - 1);
            Assert.DoesNotContain("rule9000", resource.RequestRoutingRules.Keys);
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal("listener1", rule.Listener.Name, true);

            // Verify probes
            Assert.Single(resource.Probes);
            var probe = resource.Probes["probe2"];
            Assert.NotNull(probe);
            Assert.Empty(probe.HealthyHttpResponseStatusCodeRanges);
            Assert.Null(probe.HealthyHttpResponseBodyContents);

            // Verify backend configs
            var backendConfig = resource.BackendHttpConfigurations["config1"];
            Assert.NotNull(backendConfig);
            Assert.Null(backendConfig.Probe);
            Assert.False(backendConfig.IsHostHeaderFromBackend);
            Assert.Null(backendConfig.HostHeader);
            Assert.Equal(0, backendConfig.ConnectionDrainingTimeoutInSeconds);
            Assert.Null(backendConfig.AffinityCookieName);
            Assert.Null(backendConfig.Path);

            rule80 = resource.RequestRoutingRules["rule80"];
            Assert.NotNull(rule80);
            backendConfig80 = rule80.BackendHttpConfiguration;
            Assert.NotNull(backendConfig80);
            Assert.True(backendConfig80.IsHostHeaderFromBackend);
            Assert.Null(backendConfig80.HostHeader);

            // Verify SSL policy - disabled protocols  
            Assert.Equal(0, resource.DisabledSslProtocols.Count);

            return resource;
        }
    }
}
