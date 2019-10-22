// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition;

    /// <summary>
    /// Implementation for  EventHubAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViQXV0aG9yaXphdGlvblJ1bGVJbXBs
    internal partial class EventHubAuthorizationRuleImpl  :
        AuthorizationRuleBaseImpl<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule, Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRuleImpl, IUpdate>,
        IEventHubAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private TwoAncestor ancestor;

        ///GENMHASH:88DB44BAECF6544F77A2C83BD6FC1C3B:7517BB8CBCB94F9AA4632A3D07863A48
        internal EventHubAuthorizationRuleImpl(string name, AuthorizationRuleInner inner, IEventHubManager manager) : base(name, inner, manager)
        {
            this.ancestor =  new TwoAncestor(inner.Id);
        }

        ///GENMHASH:CE4FC6FAABF2BD5DC85320962AA0B51B:F74F33DC73C74BC484CB104F3A7EEC28
        internal EventHubAuthorizationRuleImpl(string name, IEventHubManager manager) : base(name, new AuthorizationRuleInner(), manager)
        {
        }

        ///GENMHASH:BC796D0A7EFEEA08ADC9653640ACCBCF:E2D0E9C2E913034FE2F5B8204F5797F5
        public string NamespaceResourceGroupName()
        {
            return this.Ancestor().ResourceGroupName;
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:1FD21C33BB571CE08A02624A543D9C3C
        public string NamespaceName()
        {
            return this.Ancestor().Ancestor2Name;
        }

        ///GENMHASH:5BE993289973437601F36360EECCC6F5:44D93BEB0AEB0D232B2497DD293956E3
        public string EventHubName()
        {
            return this.Ancestor().Ancestor1Name;
        }

        ///GENMHASH:0D1A56A2D4975A5117372A4C6EDA24AD:0D55D5CB70DDB4764B2683E09E4F714C
        public EventHubAuthorizationRuleImpl WithExistingEventHubId(string eventHubResourceId)
        {
            this.ancestor = new TwoAncestor(SelfId(eventHubResourceId));
            return this;
        }

        ///GENMHASH:8E558916BC9FD09AB1EE2BAA127372EB:1D4B99B2219FD6B197BBB7366BE9C73B
        public EventHubAuthorizationRuleImpl WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            this.ancestor = new TwoAncestor(resourceGroupName, eventHubName, namespaceName);
            return this;
        }

        ///GENMHASH:F99F3258B7041A2910BA994BB518EAA3:2CC5F403817B58A1E7310EB6F1AF1764
        public EventHubAuthorizationRuleImpl WithExistingEventHub(IEventHub eventHub)
        {
            this.ancestor = new TwoAncestor(SelfId(eventHub.Id));
            return this;
        }

        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:B21407B848292AD05D2EDA15DA7A077A
        protected override async Task<AccessKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.EventHubs
                .ListKeysAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:2A78999F239DA090C8DF19A6D1F08331:C4C36D1AABF35564B2294D36E9FB136D
        protected override async Task<AccessKeysInner> RegenerateKeysInnerAsync(KeyType keyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            RegenerateAccessKeyParameters regenKeyInner = new RegenerateAccessKeyParameters
            {
                KeyType = keyType
            };
            return await this.Manager.Inner.EventHubs
                .RegenerateKeysAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    regenKeyInner,
                    cancellationToken);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AA0C9A4A4BF2840880B12217DDB9B07E
        protected override async Task<AuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.EventHubs
                .GetAuthorizationRuleAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:DBADB41D2B00E35368AACCB70CC342CB
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.EventHubs
                .CreateOrUpdateAuthorizationRuleAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    this.Inner.Rights,
                    cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private TwoAncestor Ancestor()
        {
            return this.ancestor ?? throw new System.ArgumentNullException("this.ancestor");
        }

        ///GENMHASH:BE19D5FA60872E55D3B07FEE99BE7B1F:1DD3F82875B3A7D5130E00C683800B33
        private string SelfId(string parentId)
        {
            return $"{parentId}/authorizationRules/{this.Name}";
        }
    }
}