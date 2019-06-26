// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.EventHub.Fluent;
    /// <summary>
    /// Implementation for  DisasterRecoveryPairingAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkRpc2FzdGVyUmVjb3ZlcnlQYWlyaW5nQXV0aG9yaXphdGlvblJ1bGVJbXBs
    internal partial class DisasterRecoveryPairingAuthorizationRuleImpl  :
        Wrapper<AuthorizationRuleInner>,
        IDisasterRecoveryPairingAuthorizationRule
    {
        private EventHubManager manager;
        private TwoAncestor ancestor;


        ///GENMHASH:D4CA07DF69C5770C25C54C590A72C9A3:84E3CA373B4BC562253F7D0744B26A1E
        public DisasterRecoveryPairingAuthorizationRuleImpl(AuthorizationRuleInner inner, EventHubManager manager) : base(inner)
        {
            this.manager = manager;
            this.ancestor =  new TwoAncestor(inner.Id);

        }
        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public EventHubManager Manager()
        {
            return this.manager;
        }

        ///GENMHASH:AB1BA95F78B711F10D574A0046DE17B7:48E9016EAAA91C077AE80CE4E05CD218
        public IReadOnlyList<AccessRights> Rights()
        {
            if (this.Inner.Rights == null)
            {
                return new List<AccessRights>();
            }
            else
            {
                return new List<AccessRights>(this.Inner.Rights);
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:2751D8683222AD34691166D915065302:6CF6C0674C2EAF23B50944FED4A92C28
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var configs = this.manager.Inner.DisasterRecoveryConfigs;
            AccessKeysInner innerKeys = await configs.ListKeysAsync(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor2Name,
                this.Ancestor().Ancestor1Name,
                this.Name(),
                cancellationToken);
             if (innerKeys == null)
            {
                return null;
            }
            else
            {
                return new DisasterRecoveryPairingAuthorizationKeyImpl(innerKeys);
            }
        }

        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:1BCD5CF569F11AB6F798D4F3A5BFC786
        public IDisasterRecoveryPairingAuthorizationKey GetKeys()
        {
            return Extensions.Synchronize(() => this.GetKeysAsync());
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private TwoAncestor Ancestor()
        {
            return this.ancestor ?? throw new System.ArgumentNullException("this.ancestor");
        }
    }
}