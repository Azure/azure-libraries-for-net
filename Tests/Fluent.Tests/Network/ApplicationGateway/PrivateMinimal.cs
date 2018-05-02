// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Runtime.CompilerServices;
using Xunit;

namespace Fluent.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal minimalistic app gateway test.
    /// </summary>
    public class PrivateMinimal : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private INetworks networks;
        private ApplicationGatewayHelper applicationGatewayHelper;
        public PrivateMinimal([CallerMemberName] string methodName = "testframework_failed")
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
            networks = resources.Manager.Networks;

            // Create an app gateway
            resources.Define(applicationGatewayHelper.AppGatewayName)
                .WithRegion(applicationGatewayHelper.Region)
                .WithNewResourceGroup(applicationGatewayHelper.GroupName)

                // Request routing rule
                .DefineRequestRoutingRule("rule1")
                    .FromPrivateFrontend()
                    .FromFrontendHttpPort(80)
                    .ToBackendHttpPort(8080)
                    .ToBackendIPAddress("11.1.1.1")
                    .ToBackendIPAddress("11.1.1.2")
                    .Attach()
                .Create();

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            var appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardSmall, appGateway.Size);
            Assert.Equal(1, appGateway.InstanceCount);

            // Verify frontend ports
            Assert.Single(appGateway.FrontendPorts.Values);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));

            // Verify frontends
            Assert.True(appGateway.IsPrivate);
            Assert.True(!appGateway.IsPublic);
            Assert.Single(appGateway.Frontends.Values);

            // Verify listeners
            Assert.Single(appGateway.Listeners.Values);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));

            // Verify backends
            Assert.Single(appGateway.Backends.Values);

            // Verify backend HTTP configs
            Assert.Single(appGateway.BackendHttpConfigurations.Values);

            // Verify rules
            Assert.Single(appGateway.RequestRoutingRules.Values);
            var rule = appGateway.RequestRoutingRules["rule1"];
            Assert.NotNull(rule);
            Assert.Equal(80, rule.FrontendPort);
            Assert.Equal(ApplicationGatewayProtocol.Http, rule.FrontendProtocol);
            Assert.NotNull(rule.Listener);
            Assert.NotNull(rule.Listener.Frontend);
            Assert.True(!rule.Listener.Frontend.IsPublic);
            Assert.True(rule.Listener.Frontend.IsPrivate);
            Assert.NotNull(rule.Listener.SubnetName);
            Assert.NotNull(rule.Listener.NetworkId);
            Assert.Equal(2, rule.BackendAddresses.Count);
            Assert.NotNull(rule.Backend);
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.2"));
            Assert.Equal(8080, rule.BackendPort);

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            resource.Update()
                .WithInstanceCount(2)
                .WithSize(ApplicationGatewaySkuName.StandardMedium)
                .WithFrontendPort(81, "port81")         // Add a new port
                .WithoutBackendIPAddress("11.1.1.1")    // Remove from all existing backends
                .DefineSslCertificate("testSSL")
                    .WithPfxFromFile(new FileInfo(Path.Combine("Assets", "myTest._pfx")))
                    .WithPfxPassword("Abc123")
                    .Attach()
                .DefineListener("listener2")
                    .WithPrivateFrontend()
                    .WithFrontendPort(81)
                    .WithHttps()
                    .WithSslCertificate("testSSL")
                    .Attach()
                .DefineBackend("backend2")
                    .WithIPAddress("11.1.1.3")
                    .Attach()
                .DefineBackendHttpConfiguration("config2")
                    .WithCookieBasedAffinity()
                    .WithPort(8081)
                    .WithRequestTimeout(33)
                    .Attach()
                .DefineRequestRoutingRule("rule2")
                    .FromListener("listener2")
                    .ToBackendHttpConfiguration("config2")
                    .ToBackend("backend2")
                    .Attach()
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Tags.ContainsKey("tag2"));
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, resource.Size);
            Assert.Equal(2, resource.InstanceCount);

            // Verify frontend ports
            Assert.Equal(2, resource.FrontendPorts.Count);
            Assert.True(resource.FrontendPorts.ContainsKey("port81"));
            Assert.Equal("port81", resource.FrontendPortNameFromNumber(81));

            // Verify listeners
            Assert.Equal(2, resource.Listeners.Count);
            IApplicationGatewayListener listener = resource.Listeners["listener2"];
            Assert.NotNull(listener);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.True(!listener.Frontend.IsPublic);
            Assert.Equal("port81", listener.FrontendPortName);
            Assert.Equal(ApplicationGatewayProtocol.Https, listener.Protocol);
            Assert.NotNull(listener.SslCertificate);

            // Verify backends
            Assert.Equal(2, resource.Backends.Count);
            IApplicationGatewayBackend backend = resource.Backends["backend2"];
            Assert.NotNull(backend);
            Assert.Single(backend.Addresses);
            Assert.True(backend.ContainsIPAddress("11.1.1.3"));

            // Verify HTTP configs
            Assert.Equal(2, resource.BackendHttpConfigurations.Count);
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config2"];
            Assert.NotNull(config);
            Assert.True(config.CookieBasedAffinity);
            Assert.Equal(8081, config.Port);
            Assert.Equal(33, config.RequestTimeout);

            // Verify request routing rules
            Assert.Equal(2, resource.RequestRoutingRules.Count);
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule2"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal("listener2", rule.Listener.Name);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config2", rule.BackendHttpConfiguration.Name);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend2", rule.Backend.Name);

            return resource;
        }
    }
}
