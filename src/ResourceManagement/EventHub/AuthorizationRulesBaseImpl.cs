// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkF1dGhvcml6YXRpb25SdWxlc0Jhc2VJbXBs
    internal abstract partial class AuthorizationRulesBaseImpl<InnerT,RuleT,RuleImpl>  :
        Wrapper<InnerT>,
        IHasManager<IEventHubManager>,
        ISupportsGettingById<RuleT>,
        ISupportsDeletingById
    {
        protected readonly IEventHubManager manager;

        ///GENMHASH:831A87366D0406BFC6A615DBF1A7A542:A717C2810EE8F1B306E46A1DF6ECCE22
        protected AuthorizationRulesBaseImpl(IEventHubManager manager, InnerT inner) : base(inner)
        {
            this.manager = manager;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IEventHubManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:27E486AB74A10242FF421C0798DDC450
        public abstract Task<RuleT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:37DAFCA0F979EB14168635F75681B9E4
        public RuleT GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:27E486AB74A10242FF421C0798DDC450
        public abstract Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:8B61E578211E798393BC11B4706B4C15
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:BCF24D03D2EE33ADFF1E81AD1D0155CB:27E486AB74A10242FF421C0798DDC450
        protected abstract RuleImpl WrapModel(AuthorizationRuleInner innerModel);
    }
}