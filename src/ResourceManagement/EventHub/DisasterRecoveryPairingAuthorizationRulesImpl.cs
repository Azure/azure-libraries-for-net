// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  DisasterRecoveryPairingAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkRpc2FzdGVyUmVjb3ZlcnlQYWlyaW5nQXV0aG9yaXphdGlvblJ1bGVzSW1wbA==
    internal partial class DisasterRecoveryPairingAuthorizationRulesImpl  :
        ReadableWrappers<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule,Microsoft.Azure.Management.Eventhub.Fluent.DisasterRecoveryPairingAuthorizationRuleImpl, AuthorizationRuleInner>,
        IDisasterRecoveryPairingAuthorizationRules
    {
        private EventHubManager manager;

        ///GENMHASH:02FC52656FED15BFC1B5B9216A451178:D544D70B59C64F2C67EC02DE16CBAEF6
        internal DisasterRecoveryPairingAuthorizationRulesImpl(EventHubManager manager)
        {
            this.manager = manager;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:923C568F9C937CABC37C177B4522018B
        public IDisasterRecoveryConfigsOperations Inner()
        {
            return this.manager.Inner.DisasterRecoveryConfigs;
        }

        IDisasterRecoveryConfigsOperations IHasInner<IDisasterRecoveryConfigsOperations>.Inner => this.Inner();

        ///GENMHASH:62C00EEB1DF1BD51BEAC5339F5198000:2532064C6301665404E8957355D963BC
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> ListByDisasterRecoveryPairing(string resourceGroupName, string namespaceName, string pairingName)
        {
            return WrapList(Extensions.Synchronize(() => this.manager.Inner
                            .DisasterRecoveryConfigs.ListAuthorizationRulesAsync(resourceGroupName,
                                namespaceName,
                                pairingName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.manager.Inner
                            .DisasterRecoveryConfigs.ListAuthorizationRulesNextAsync(nextLink))));
        }

        ///GENMHASH:29A726C59C9E8C7255A01C36C8AE6852:255DF06AA43E1C1CE6ED97FA24392A0F
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> ListByDisasterRecoveryPairingAsync(string resourceGroupName, string namespaceName, string pairingName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IDisasterRecoveryPairingAuthorizationRule, AuthorizationRuleInner>
                .LoadPage(
                    async (cancellation) =>
                        await this.manager.Inner
                            .DisasterRecoveryConfigs.ListAuthorizationRulesAsync(resourceGroupName,
                                namespaceName,
                                pairingName,
                                cancellation),
                    async (nextLink, cancellation) => 
                        await this.manager.Inner
                            .DisasterRecoveryConfigs.ListAuthorizationRulesNextAsync(nextLink,
                                cancellation),
                    WrapModel, true, cancellationToken);
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public EventHubManager Manager()
        {
            return this.manager;
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:37DAFCA0F979EB14168635F75681B9E4
        public IDisasterRecoveryPairingAuthorizationRule GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:75BCE9962F8F51C054B48D3344BFE162
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);
            return await this.GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Parent.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:D4172B991CD1CF668EFC326060AE2DFF:0706A02D75607FE8C57BF482CF5BD842
        public IDisasterRecoveryPairingAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string pairingName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, pairingName, name));
        }

        ///GENMHASH:A25618C0BA8BEE57DEC3C4B9D011B985:0D41DFBD0DA616BDF2B347AB0F670014
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string pairingName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.manager.Inner.DisasterRecoveryConfigs.GetAuthorizationRuleAsync(resourceGroupName,
                namespaceName,
                pairingName,
                name,
                cancellationToken);
            if (inner == null)
            {
                return null;
            }
            else
            {
                return WrapModel(inner);
            }
        }

        ///GENMHASH:BCF24D03D2EE33ADFF1E81AD1D0155CB:DC62DAFBF302382B8C3DFD33D1E1D992
        protected override IDisasterRecoveryPairingAuthorizationRule WrapModel(AuthorizationRuleInner inner)
        {
            return new DisasterRecoveryPairingAuthorizationRuleImpl(inner, manager);
        }
    }
}