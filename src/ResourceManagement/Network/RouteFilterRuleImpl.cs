// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for  RouteFilterRule and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVGaWx0ZXJSdWxlSW1wbA==
    internal partial class RouteFilterRuleImpl :
        ChildResource<RouteFilterRuleInner,
            RouteFilterImpl,
            IRouteFilter>,
        IRouteFilterRule,
        IDefinition<RouteFilter.Definition.IWithCreate>,
        IUpdateDefinition<RouteFilter.Update.IUpdate>,
        RouteFilterRule.Update.IUpdate
    {

        ///GENMHASH:13DC7420187ABBB7C8DD8DB9BB60179C:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal RouteFilterRuleImpl(RouteFilterRuleInner inner, RouteFilterImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:AD2631B1DB33BADA121356C1B30A8CEF:712518012E1A4F3E83477E33263C9F08
        public Access Access()
        {
            return Inner.Access;
        }

        ///GENMHASH:30156233BD16F2042F055861C60E11E5:7794A365075E679AD4238AF2A4064907
        public RouteFilterRuleImpl AllowAccess()
        {
            Inner.Access = Models.Access.Allow;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:5D4BF21E49789459EF95BA820BF19FF2
        public RouteFilterImpl Attach()
        {
            return base.Parent.WithRule(this);
        }

        ///GENMHASH:1CAA7CDA757B61DD12C2FA4A0E0CD040:ADCADCD34C378242E7F8E63B22D82C45
        public IReadOnlyList<string> Communities()
        {
            return Inner.Communities.ToList();
        }

        ///GENMHASH:66151C2B93BD44690D573368404CB84F:ADD6DC93376B741B1DDC340E3BFC2B02
        public RouteFilterRuleImpl DenyAccess()
        {
            Inner.Access = Models.Access.Deny;
            return this;
        }

        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:0D9EEC636DF1E11A81923129881E6F92
        public string Location()
        {
            return Inner.Location;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:30DB844B43E777921690A6FEC9C0DD25:2B94153A65AA389ED129EB5302FDB738
        public string RouteFilterRuleType()
        {
            return RouteFilterRuleInner.RouteFilterRuleType;

        }

        ///GENMHASH:16F7C45243A612D87C78AE426C45F5FF:DDE981312440502ADDA28149709EC2EC
        public RouteFilterRuleImpl WithBgpCommunities(params string[] communities)
        {
            this.Inner.Communities = new List<String>();
            foreach (var community in communities)
            {
                this.Inner.Communities.Add(community);
            }

            return this;
        }

        ///GENMHASH:89D4559CBD4F10C45690195FC3D6ECC4:65076E0C66A04C9C26AFAD5C44678F26
        public RouteFilterRuleImpl WithBgpCommunity(string community)
        {
            if (Inner.Communities == null)
            {
                Inner.Communities = new List<String>();
            }
            Inner.Communities.Add(community);
            return this;
        }

        ///GENMHASH:1476851D4F765746DC0AA804511565D4:7A9A2772D4B99BB109C74D109DDD7E66
        public RouteFilterRule.Update.IUpdate WithoutBgpCommunity(string community)
        {
            if (Inner.Communities != null && Inner.Communities.Any())
            {
                var cleanList = Inner.Communities
                    .Where(s => !s.Equals(community, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
                Inner.Communities = cleanList;
            }
            return this;
        }

        public RouteFilter.Update.IUpdate Parent()
        {
            return base.Parent;
        }
    }
}