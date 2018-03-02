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
    /// Implementation for  EventHubAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViQXV0aG9yaXphdGlvblJ1bGVzSW1wbA==
    internal partial class EventHubAuthorizationRulesImpl  :
        AuthorizationRulesBaseImpl<IEventHubsOperations,
            Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule,
            Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRuleImpl>,
        IEventHubAuthorizationRules
    {
        ///GENMHASH:1642031856E30EE20D95D3D070FD2EB5:6591C3058C27F4799E76F6FECB0EC307
        internal EventHubAuthorizationRulesImpl(IEventHubManager manager) : base(manager, manager.Inner.EventHubs)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:19B6B60B4510361D59C510F0C90DE4C9
        public EventHubAuthorizationRuleImpl Define(string name)
        {
            return new EventHubAuthorizationRuleImpl(name, this.Manager);
        }

        ///GENMHASH:66A87AACDC6DD496194CABFCB3F2C921:E9A51CD479436338CBCF0CC9ED036074
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            return Extensions.Synchronize(() => this.Inner.ListAuthorizationRulesAsync(resourceGroupName,
                    namespaceName,
                    eventHubName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.Inner.ListAuthorizationRulesNextAsync(nextLink))).Select(inner => WrapModel(inner));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:F081FE980E79F1E88B95F84B83248DFF
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            return await GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:A25618C0BA8BEE57DEC3C4B9D011B985:A72E432AF0588A7D990B65A601144036
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var ruleInner = await this.Inner.GetAuthorizationRuleAsync(resourceGroupName,
                    namespaceName,
                    eventHubName,
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

        ///GENMHASH:D4172B991CD1CF668EFC326060AE2DFF:4F9E54D6532DF8127D59EDCED55C2688
        public IEventHubAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, eventHubName, name));
        }

        ///GENMHASH:C98B5924C4B12F70C49985B2AAED62BE:1C1485D42A8FCEC5650D8914CCD5B0E7
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IEventHubAuthorizationRule, AuthorizationRuleInner>
                .LoadPage(
                    async (cancellation) =>
                        await this.Inner.ListAuthorizationRulesAsync(resourceGroupName,
                                namespaceName,
                                eventHubName,
                                cancellation),
                    async (nextLink, cancellation) =>
                        await this.Inner.ListAuthorizationRulesNextAsync(nextLink,
                                cancellation),
                    WrapModel, true, cancellationToken);
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:19014DBA68BF4C143FA6803F3D71AEB6
        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            await DeleteByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:F75176B567559F61407091313919F2A5:D3C1F51C5327EA2CD938D8A8075EEE34
        public async Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAuthorizationRuleAsync(resourceGroupName,
                namespaceName,
                eventHubName,
                name,
                cancellationToken);
        }

        ///GENMHASH:9B2A559514B349EBD1BDDF3D29BDBC9E:C4E2F811E63804D39B306A96EAC9A8DE
        public void DeleteByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(resourceGroupName, namespaceName, eventHubName, name));
        }

        ///GENMHASH:BCF24D03D2EE33ADFF1E81AD1D0155CB:6AE3706867B3B82037FF77182EC78624
        protected override EventHubAuthorizationRuleImpl WrapModel(AuthorizationRuleInner innerModel)
        {
            return new EventHubAuthorizationRuleImpl(innerModel.Name, innerModel, this.Manager);
        }
    }
}