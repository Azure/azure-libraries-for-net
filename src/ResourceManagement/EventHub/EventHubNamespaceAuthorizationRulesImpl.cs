// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHubNamespaceAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVzSW1wbA==
    internal partial class EventHubNamespaceAuthorizationRulesImpl  :
        AuthorizationRulesBaseImpl<INamespacesOperations, 
            Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule,
            Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRuleImpl>,
        IEventHubNamespaceAuthorizationRules
    {

        ///GENMHASH:E437E46480BE44E394F53E9A6BFE28BA:8926504F02C347CA02F0675141CC6886
        internal EventHubNamespaceAuthorizationRulesImpl(IEventHubManager manager) : base(manager, manager.Inner.Namespaces)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:83A430614DE35EF32CFB74DF9354B876
        public EventHubNamespaceAuthorizationRuleImpl Define(string name)
        {
            return new EventHubNamespaceAuthorizationRuleImpl(name, this.Manager);
        }

        ///GENMHASH:BC72564BF6A743AB48443EB9A1982EC5:80550B43022569815309809F2CBBDA95
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> ListByNamespace(string resourceGroupName, string namespaceName)
        {
            return Extensions.Synchronize(() => this.Inner.ListAuthorizationRulesAsync(resourceGroupName,
                    namespaceName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.manager.Inner
                .EventHubs.ListAuthorizationRulesNextAsync(nextLink))).Select(inner => WrapModel(inner));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:279A0BE8EAAA54434723FD778381D28C
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            return await GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:6F4AD1869ECF2F037CD0AF38FA93C9B0:19722DEED92F1185ACBA6D92EDA3D8DE
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var ruleInner = await this.Inner.GetAuthorizationRuleAsync(resourceGroupName,
                namespaceName,
                name,
                cancellationToken);
            if (ruleInner == null)
            {
                return null;
            }
            else
            {
                return WrapModel(ruleInner);
            }
        }

        ///GENMHASH:AD2574D8A0B41B7543E661226E7079CC:3EAC4D0C83CAC924621C946950DC6EB1
        public IEventHubNamespaceAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, name));
        }


        ///GENMHASH:6EDC0210EC32BAF3169D04C5071B3BA4:54F9D6A33D05715D4CB7802330AC72D7
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IEventHubNamespaceAuthorizationRule, AuthorizationRuleInner>
                .LoadPage(
                    async (cancellation) =>
                        await this.Inner.ListAuthorizationRulesAsync(resourceGroupName,
                                namespaceName,
                                cancellation),
                    async (nextLink, cancellation) =>
                        await this.Inner.ListAuthorizationRulesNextAsync(nextLink,
                                cancellation),
                    WrapModel, true, cancellationToken);
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:9723D6330EE11E0764C52AE608F5F48E
        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            await DeleteByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name, 
                cancellationToken);
        }

        ///GENMHASH:76D3089A9A4A15E17E55ADC8A99BA937:E8BD721EA1BF8023D343EC06264E59C2
        public async Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAuthorizationRuleAsync(resourceGroupName,
                namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:666C0465A5F64EEA835CC2DA55F94875:066987FB34F379BFE8B7DD7842362947
        public void DeleteByName(string resourceGroupName, string namespaceName, string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(resourceGroupName, namespaceName, name));

        }

        ///GENMHASH:BCF24D03D2EE33ADFF1E81AD1D0155CB:D8ACC36215F5764A5A6952D3F104FC21
        protected override EventHubNamespaceAuthorizationRuleImpl WrapModel(AuthorizationRuleInner innerModel)
        {
            return new EventHubNamespaceAuthorizationRuleImpl(innerModel.Name, innerModel, this.Manager);
        }
    }
}