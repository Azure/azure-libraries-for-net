// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition;

    /// <summary>
    /// Implementation for  EventHubNamespaceAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVJbXBs
    internal partial class EventHubNamespaceAuthorizationRuleImpl  :
        AuthorizationRuleBaseImpl<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule,Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRuleImpl, IUpdate>,
        IEventHubNamespaceAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private OneAncestor ancestor;

        ///GENMHASH:C96B666280F600C10217B7A05A74AEC9:615AAB077A4DA6D0FB4F0A984736F066
        internal EventHubNamespaceAuthorizationRuleImpl(string name, AuthorizationRuleInner inner, IEventHubManager manager) : base(name,inner, manager)
        {
            this.ancestor = new OneAncestor(inner.Id);
        }

        ///GENMHASH:A72B698CF32507F2FF3705453617EF4E:F74F33DC73C74BC484CB104F3A7EEC28
        internal EventHubNamespaceAuthorizationRuleImpl(string name, IEventHubManager manager) : base(name, new AuthorizationRuleInner(), manager)
        {
        }

        ///GENMHASH:BC796D0A7EFEEA08ADC9653640ACCBCF:E2D0E9C2E913034FE2F5B8204F5797F5
        public string NamespaceResourceGroupName()
        {
            return this.Ancestor().ResourceGroupName;
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:44D93BEB0AEB0D232B2497DD293956E3
        public string NamespaceName()
        {
            return this.Ancestor().Ancestor1Name;
        }

        ///GENMHASH:4837927A8B032D3939D5AB13E184B3C5:FB6F1C9A73A5E79F2C672D7DBB2A6B3C
        public EventHubNamespaceAuthorizationRuleImpl WithExistingNamespaceId(string namespaceResourceId)
        {
            this.ancestor = new OneAncestor(SelfId(namespaceResourceId));
            return this;
        }

        ///GENMHASH:560B7FEB95690F0039CAE6B6DF34A025:3F7E53D855C5660E045E1F2614E2F3C8
        public EventHubNamespaceAuthorizationRuleImpl WithExistingNamespace(string resourceGroupName, string namespaceName)
        {
            this.ancestor = new OneAncestor(resourceGroupName, namespaceName);
            return this;
        }

        ///GENMHASH:7D61807B58437D7B0611B991EE834B27:EDA80D678FC3FF2592A13E3E96233046
        public EventHubNamespaceAuthorizationRuleImpl WithExistingNamespace(IEventHubNamespace nhNamespace)
        {
            this.ancestor = new OneAncestor(SelfId(nhNamespace.Id));
            return this;
        }

        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:3A8604878A4599454D9E6CBEA196DA57
        protected override async Task<AccessKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces
                .ListKeysAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:2A78999F239DA090C8DF19A6D1F08331:8F91E65E832D3679B5CB708B68F15EFC
        protected override async Task<AccessKeysInner> RegenerateKeysInnerAsync(KeyType keyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            RegenerateAccessKeyParameters regenKeyInner = new RegenerateAccessKeyParameters
            {
                KeyType = keyType
            };
            return await this.Manager.Inner.Namespaces
                .RegenerateKeysAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    regenKeyInner,
                    cancellationToken);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:D5BDED52BBBA3F06ABF8C110A013F75E
        protected override async Task<AuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces
                .GetAuthorizationRuleAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4976A31B4E2EC0D0A418982366927799
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.Namespaces
                .CreateOrUpdateAuthorizationRuleAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    this.Inner.Rights,
                    cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private OneAncestor Ancestor()
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