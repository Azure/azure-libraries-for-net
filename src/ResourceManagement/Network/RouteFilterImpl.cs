// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilter.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.RouteFilterRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for RouteFilter and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUm91dGVGaWx0ZXJJbXBs
    internal partial class RouteFilterImpl :
        GroupableParentResource<
            IRouteFilter,
            RouteFilterInner,
            RouteFilterImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            RouteFilter.Update.IUpdate>,
        IRouteFilter,
        IDefinition,
        RouteFilter.Update.IUpdate
    {
        private Dictionary<string, Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> peerings;
        private Dictionary<string, Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule> rules = new Dictionary<string, IRouteFilterRule>();

        ///GENMHASH:C2FD30D8052EB6327C4D154A64924D82:3881994DCADCE14215F82F0CC81BDD88
        internal RouteFilterImpl(string name, RouteFilterInner innerModel, INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        ///GENMHASH:7B375AAF9D3CBD34EA122BD5C879EFF0:E49A6315EAB2204516FEF948739183C2
        internal RouteFilterImpl WithRule(RouteFilterRuleImpl rule)
        {
            rules[rule.Name()] = rule;
            return this;
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:27E486AB74A10242FF421C0798DDC450
        protected override void AfterCreating()
        {

        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:6B5FEA60100196D0796FB383009C539A
        protected override void BeforeCreating()
        {
            if (this.rules.Count > 0)
            {
                Inner.Rules = new List<RouteFilterRuleInner>();
                foreach (IRouteFilterRule rule in this.rules.Values)
                {
                    Inner.Rules.Add(rule.Inner);
                }
            }
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:324955E43B53E820C115122A9B2E1038
        protected override async Task<Models.RouteFilterInner> CreateInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.RouteFilters.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AAC56B9AF93DB5A1FE5E71C6B5316254
        protected override async Task<Models.RouteFilterInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.RouteFilters.GetAsync(this.ResourceGroupName, this.Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:6E5895BA20C96C9A69E8F96FF93CA745
        protected override void InitializeChildrenFromInner()
        {
            this.rules = new Dictionary<string, IRouteFilterRule>();
            if (Inner.Rules != null)
            {
                foreach (var rule in Inner.Rules)
                {
                    this.rules.Add(rule.Name, new RouteFilterRuleImpl(rule, this));
                }
            }
        }

        ///GENMHASH:6823FCC8CD86F0A33002CFB751DEA302:55F26134BAE71A69C52B7345D27F11FD
        public RouteFilterRuleImpl DefineRule(string name)
        {
            RouteFilterRuleInner inner = new RouteFilterRuleInner()
            {
                Name = name,
                Access = Access.Allow
            };
            return new RouteFilterRuleImpl(inner, this);
        }

        ///GENMHASH:DAC0ADBD485D3FA7934FDCF3DF6AFB33:FD9760FB9C19877AA8BD26C189E8917A
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> Peerings()
        {
            return this.peerings;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:B5AF408C480FD0F75A216B4D78CC9E3B
        public override async Task<Microsoft.Azure.Management.Network.Fluent.IRouteFilter> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetInnerAsync(cancellationToken);
            SetInner(response);
            InitializeChildrenFromInner();
            return this;
        }

        ///GENMHASH:72B8E1071F896522FFFEF85D9357CBCC:FC8B3AE517369B64F33F8DC475426F01
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IRouteFilterRule> Rules()
        {
            return this.rules;
        }

        ///GENMHASH:0E516034DD6EAC0154C689EE19E8DACC:F1D272BA2CF3403B8640F386D36F9C9E
        public RouteFilterRule.Update.IUpdate UpdateRule(string name)
        {
            return (RouteFilterRuleImpl)this.rules[name];
        }

        ///GENMHASH:EC4B0EE9E5C17F0368D305042F19A0FD:BB6B3B198CEC808EF295F8AE72D11548
        public RouteFilter.Update.IUpdate WithoutRule(string name)
        {
            this.rules.Remove(name);
            return this;
        }
    }
}