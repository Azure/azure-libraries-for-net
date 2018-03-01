// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroup.Update;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHubConsumerGroup.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViQ29uc3VtZXJHcm91cEltcGw=
    internal partial class EventHubConsumerGroupImpl  :
        NestedResourceImpl<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup, ConsumerGroupInner, Microsoft.Azure.Management.Eventhub.Fluent.EventHubConsumerGroupImpl, IUpdate>,
        IEventHubConsumerGroup,
        IDefinition,
        IUpdate
    {
        private TwoAncestor ancestor;

        ///GENMHASH:88ACEE67E968823C2BF1792E4FD65454:7517BB8CBCB94F9AA4632A3D07863A48
        internal  EventHubConsumerGroupImpl(string name, ConsumerGroupInner inner, IEventHubManager manager) :base(name, inner, manager)
        {
            this.ancestor =  new TwoAncestor(inner.Id);
        }

        ///GENMHASH:D63A3300E6A87CE8E930594169FA259A:8D85D12E83928751758F7A4839B602E6
        internal  EventHubConsumerGroupImpl(string name, IEventHubManager manager) : base(name, new ConsumerGroupInner(), manager)
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

        ///GENMHASH:2D77B063E1C3B0F97DD6DC64CE1C3E91:FA03FEFF789BA14FF876F3856232C7AC
        public string UserMetadata()
        {
            return this.Inner.UserMetadata;
        }

        ///GENMHASH:9157FD0110376DF53A83D529D7A1A4E1:385804CDAC891325C8D939BDF7A1D4FF
        public DateTime? CreatedAt()
        {
            return this.Inner.CreatedAt;
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime? UpdatedAt()
        {
            return this.Inner.UpdatedAt;
        }

        ///GENMHASH:F99F3258B7041A2910BA994BB518EAA3:2CC5F403817B58A1E7310EB6F1AF1764
        public EventHubConsumerGroupImpl WithExistingEventHub(IEventHub eventHub)
        {
            this.ancestor = new TwoAncestor(SelfId(eventHub.Id));
            return this;
        }

        ///GENMHASH:0D1A56A2D4975A5117372A4C6EDA24AD:FC5A569B96738DB334A09C4983B592F2
        public EventHubConsumerGroupImpl WithExistingEventHubId(string eventHubId)
        {
            this.ancestor = new TwoAncestor(SelfId(eventHubId));
            return this;
        }

        ///GENMHASH:8E558916BC9FD09AB1EE2BAA127372EB:1D4B99B2219FD6B197BBB7366BE9C73B
        public EventHubConsumerGroupImpl WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            this.ancestor = new TwoAncestor(resourceGroupName, eventHubName, namespaceName);
            return this;
        }

        ///GENMHASH:5971052055EFE90F23AF7D6A14431CD6:C6B2145DD801A91C072D8A36FEA54D32
        public EventHubConsumerGroupImpl WithUserMetadata(string metadata)
        {
            this.Inner.UserMetadata = metadata;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:C2C0330D0A79CA5A25B339EE0B2AC41B
        protected override async Task<ConsumerGroupInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ConsumerGroups
                .GetAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:5269A9EDA6AB1482647023603A076662
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.ConsumerGroups
                .CreateOrUpdateAsync(this.Ancestor().ResourceGroupName,
                    this.Ancestor().Ancestor2Name,
                    this.Ancestor().Ancestor1Name,
                    this.Name,
                    this.Inner.UserMetadata,
                    cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private TwoAncestor Ancestor()
        {
            return this.ancestor ?? throw new ArgumentNullException("this.ancestor");
        }

        ///GENMHASH:BE19D5FA60872E55D3B07FEE99BE7B1F:253F243DDA7EF758EA426F1EFD9797BE
        private string SelfId(string parentId)
        {
            return $"{parentId}/consumerGroups/{this.Name}";
        }
    }
}