// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using ApplicationGatewayRedirectConfiguration.Definition;
    using ApplicationGatewayRedirectConfiguration.UpdateDefinition;
    using ApplicationGateway.Update;
    using Models;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    /// <summary>
    /// Implementation for ApplicationGatewayRedirectConfiguration.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5UmVkaXJlY3RDb25maWd1cmF0aW9uSW1wbA==
    internal partial class ApplicationGatewayRedirectConfigurationImpl :
        ChildResource<ApplicationGatewayRedirectConfigurationInner, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IApplicationGatewayRedirectConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayRedirectConfiguration.Update.IUpdate
    {
        IUpdate ISettable<IUpdate>.Parent()
        {
            return Parent;
        }

        ///GENMHASH:05666BDEA44C8FE0CEC4404EF663AD02:35242E50A551D6EA64312743B06467F2
        public ApplicationGatewayRedirectConfigurationImpl WithoutTargetListener()
        {
            Inner.TargetListener = null;
            return this;
        }

        ///GENMHASH:2A99DC3290C18B217CDB2B7180E670EC:CB89C2717D96CF97D4B9D3AAFDB88039
        public bool IsPathIncluded()
        {
            return (Inner.IncludePath != null) ? Inner.IncludePath.HasValue : false;
        }

        ///GENMHASH:BC089F857B1563F063BBDB5325807141:E13AD119C69BE70A80062C9058729B59
        public ApplicationGatewayRedirectConfigurationImpl WithPathIncluded()
        {
            Inner.IncludePath = true;
            return this;
        }

        ///GENMHASH:B6971E69C4C31ECEC3589B53635834F3:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayRedirectConfigurationImpl(ApplicationGatewayRedirectConfigurationInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:4DC312D52DE9291EAE35FD8AADE789F2:636B0941A8A514AD0F52784FB9CC0CE3
        public ApplicationGatewayRedirectConfigurationImpl WithTargetUrl(string url)
        {
            Inner.TargetUrl = url;
            Inner.TargetListener = null;
            Inner.IncludePath = null;
            return this;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:B2FD2E689A3D5C83A53AB170D8E5D8DA
        public ApplicationGatewayRedirectType Type()
        {
            return Inner.RedirectType;
        }

        ///GENMHASH:9B4152A79A63ABA2300034A9B0E203BE:AD804E3F5A0A2B29EC6FA82A929F31D4
        public ApplicationGatewayRedirectConfigurationImpl WithType(ApplicationGatewayRedirectType redirectType)
        {
            Inner.RedirectType = redirectType;
            return this;
        }

        ///GENMHASH:691BBD1A543FA3E8C9A27D451AEF177E:9467BB08B825C61781DD6029C8047DFB
        public IReadOnlyDictionary<string, IApplicationGatewayRequestRoutingRule> RequestRoutingRules()
        {
            Dictionary<string, IApplicationGatewayRequestRoutingRule> rules = new Dictionary<string, IApplicationGatewayRequestRoutingRule>();
            if (null != Inner.RequestRoutingRules)
            {
                foreach (var ruleRef in Inner.RequestRoutingRules)
                {
                    string ruleName = ResourceUtils.NameFromResourceId(ruleRef.Id);
                    IApplicationGatewayRequestRoutingRule rule = null;
                    if (Parent.RequestRoutingRules().TryGetValue(ruleName, out rule))
                    {
                        rules[ruleName] = rule;
                    }
                }
            }
            return rules;
        }

        ///GENMHASH:F313880A7EB61D732B555F98C40F8772:470F642C47F5F1FFB40BE40B3D27630F
        public IApplicationGatewayListener TargetListener()
        {
            SubResource listenerRef = Inner.TargetListener;
            if (listenerRef == null)
            {
                return null;
            }

            string name = ResourceUtils.NameFromResourceId(listenerRef.Id);
            IApplicationGatewayListener listener = null;
            Parent.Listeners().TryGetValue(name, out listener);
            return listener;
        }

        ///GENMHASH:7E6FE5717689C90FD7F1456E90ED6159:F5420B14D666B44DF3857BC55374C41D
        public ApplicationGatewayRedirectConfigurationImpl WithQueryStringIncluded()
        {
            Inner.IncludeQueryString = true;
            return this;
        }

        ///GENMHASH:ED2C776515E1B721153CEB68EB989491:0FDF659FC232B6658E940B4A0DB7A1E8
        public ApplicationGatewayRedirectConfigurationImpl WithoutPathIncluded()
        {
            Inner.IncludePath = null;
            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:290C201FB05DCD12F16B71A4BA7B0160:142FA4BE99CD413AC25E04A28DA18542
        public ApplicationGatewayRedirectConfigurationImpl WithoutTargetUrl()
        {
            Inner.TargetUrl = null;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:EE0080DB856E6DB43FE097DF2C59481E
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithRedirectConfiguration(this);
        }

        ///GENMHASH:9D98CE79026D5A3B107B7BF17272A1F4:DA55B461FC052ABC2208D0999F3D6B7B
        public bool IsQueryStringIncluded()
        {
            return (Inner.IncludeQueryString != null) ? Inner.IncludeQueryString.Value : false;
        }

        ///GENMHASH:832D1B235C25BE3D4EA992B78F0A5B3F:5135D48FCBB7B68D6D0FD5F180CF79C7
        public string TargetUrl()
        {
            return Inner.TargetUrl;
        }

        ///GENMHASH:8DFAD98BF8308CE080E13A96C04638A7:8BBD321E288389D910F8EC3F04E2CD3C
        public ApplicationGatewayRedirectConfigurationImpl WithTargetListener(string name)
        {
            if (name == null)
            {
                Inner.TargetListener = null;
            }
            else
            {
                SubResource listenerRef = new SubResource()
                {
                    Id = Parent.FutureResourceId() + "/httpListeners/" + name
                };
                Inner.TargetListener = listenerRef;
                Inner.TargetUrl = null;
            }
            return this;
        }

        ///GENMHASH:6D38F94A105504429E26D6C96E97BECE:04C0AFE1CA8B656A47CB890CD3B1B4A0
        public ApplicationGatewayRedirectConfigurationImpl WithoutQueryStringIncluded()
        {
            Inner.IncludeQueryString = null;
            return this;
        }
    }
}