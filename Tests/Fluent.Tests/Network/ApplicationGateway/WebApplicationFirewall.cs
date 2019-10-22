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
    public class WebApplicationFirewall : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private List<IPublicIPAddress> testPips;
        private ApplicationGatewayHelper applicationGatewayHelper;

        public WebApplicationFirewall([CallerMemberName] string methodName = "testframework_failed")
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


            // Create an application gateway
            try
            {
                string appPublicIp = TestUtilities.GenerateName("pip");
                IPublicIPAddress pip = resources.Manager.PublicIPAddresses
                          .Define(appPublicIp)
                          .WithRegion(applicationGatewayHelper.Region)
                          .WithNewResourceGroup(applicationGatewayHelper.GroupName)
                          .WithSku(PublicIPSkuType.Standard)
                          .WithStaticIP()
                          .Create();

                Assert.NotNull(pip);

                resources.Define(applicationGatewayHelper.AppGatewayName)
                    .WithRegion(applicationGatewayHelper.Region)
                    .WithExistingResourceGroup(applicationGatewayHelper.GroupName)

                    // Request routing rules
                    // Request routing rules
                    .DefineRequestRoutingRule("rule1")
                        .FromPublicFrontend()
                        .FromFrontendHttpsPort(443)
                        .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets", "myTest._pfx")))
                        .WithSslCertificatePassword("Abc123")
                        .ToBackendHttpPort(8080)
                        .ToBackendIPAddress("11.1.1.1")
                        .ToBackendIPAddress("11.1.1.2")
                        .Attach()
                        .WithExistingPublicIPAddress(pip)
                        .WithTier(ApplicationGatewayTier.WAFV2)
                        .WithSize(ApplicationGatewaySkuName.WAFV2)
                        .WithAutoscale(2, 5)
                        .WithWebApplicationFirewall(true, ApplicationGatewayFirewallMode.Prevention)
                        .Create();
            }
            catch
            {
            }

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.Equal(ApplicationGatewayTier.WAFV2, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.WAFV2, appGateway.Size);
            Assert.Equal<int>(2, appGateway.AutoscaleConfiguration.MinCapacity);
            Assert.Equal<int>(5, appGateway.AutoscaleConfiguration.MaxCapacity.Value);

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            ApplicationGatewayWebApplicationFirewallConfiguration config = resource.WebApplicationFirewallConfiguration;
            config.FileUploadLimitInMb = 200;
            config.DisabledRuleGroups = new List<ApplicationGatewayFirewallDisabledRuleGroup> {
                    new ApplicationGatewayFirewallDisabledRuleGroup() {RuleGroupName = "REQUEST-943-APPLICATION-ATTACK-SESSION-FIXATION" }
            };
            config.RequestBodyCheck = true;
            config.MaxRequestBodySizeInKb = 64;
            config.Exclusions = new List<ApplicationGatewayFirewallExclusion> {
                    new ApplicationGatewayFirewallExclusion()
                    {
                        MatchVariable = "RequestHeaderNames",
                        SelectorMatchOperator = "StartsWith",
                        Selector = "User-Agent"
                    }
            };
            resource.Update()
                    .WithWebApplicationFirewall(config)
                    .Apply();

            resource.Refresh();

            // Verify WAF
            Assert.True(resource.WebApplicationFirewallConfiguration.FileUploadLimitInMb == 200);
            Assert.True(resource.WebApplicationFirewallConfiguration.RequestBodyCheck);
            Assert.Equal(64, resource.WebApplicationFirewallConfiguration.MaxRequestBodySizeInKb);

            Assert.Equal(1, resource.WebApplicationFirewallConfiguration.Exclusions.Count);

            Assert.Equal("RequestHeaderNames", resource.WebApplicationFirewallConfiguration.Exclusions[0].MatchVariable);
            Assert.Equal("StartsWith", resource.WebApplicationFirewallConfiguration.Exclusions[0].SelectorMatchOperator);
            Assert.Equal("User-Agent", resource.WebApplicationFirewallConfiguration.Exclusions[0].Selector);

            Assert.Equal(1, resource.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count);
            Assert.Equal("REQUEST-943-APPLICATION-ATTACK-SESSION-FIXATION", resource.WebApplicationFirewallConfiguration.DisabledRuleGroups[0].RuleGroupName);

            return resource;
        }
    }
}
