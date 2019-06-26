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
    /// Implementation for  EventHubConsumerGroups.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViQ29uc3VtZXJHcm91cHNJbXBs
    internal partial class EventHubConsumerGroupsImpl  :
        Wrapper<IConsumerGroupsOperations>,
        IEventHubConsumerGroups
    {
        private readonly IEventHubManager manager;

        ///GENMHASH:B63462D03D4B7434E9D6929540A77351:613C13F2C9FCEDAC9C25E54C69A403C0
        public EventHubConsumerGroupsImpl(IEventHubManager manager) : base(manager.Inner.ConsumerGroups)
        {
            this.manager = manager;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:6E5B4064E4BE8C80C4446F8857324FF5
        public EventHubConsumerGroupImpl Define(string name)
        {
            return new EventHubConsumerGroupImpl(name, this.manager);
        }

        ///GENMHASH:66A87AACDC6DD496194CABFCB3F2C921:11334768C848BF60B8D5AB5FB915DA76
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            return Extensions.Synchronize(() => this.Inner.ListByEventHubAsync(resourceGroupName,
                    namespaceName,
                    eventHubName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.Inner.ListByEventHubNextAsync(nextLink))).Select(inner => WrapModel(inner));
        }


        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:F081FE980E79F1E88B95F84B83248DFF
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            return await GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:A25618C0BA8BEE57DEC3C4B9D011B985:56F6EEC5F068F7F170A078E589A1892F
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> GetByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var ruleInner = await this.Inner.GetAsync(resourceGroupName,
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

        ///GENMHASH:C98B5924C4B12F70C49985B2AAED62BE:BB3D187E44962B28ED4596C599CB484C
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, CancellationToken cancellationToken = default(CancellationToken), int? skip = default(int?), int? top = default(int?))
        {
            return await PagedCollection<IEventHubConsumerGroup, ConsumerGroupInner>
                .LoadPage(
                    async (cancellation) =>
                        await this.Inner.ListByEventHubAsync(resourceGroupName,
                                namespaceName,
                                eventHubName,
                                skip, 
                                top,
                                cancellation),
                    async (nextLink, cancellation) =>
                        await this.Inner.ListByEventHubNextAsync(nextLink,
                                cancellation),
                    WrapModel, true, cancellationToken);
        }

        ///GENMHASH:D4172B991CD1CF668EFC326060AE2DFF:4F9E54D6532DF8127D59EDCED55C2688
        public IEventHubConsumerGroup GetByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, eventHubName, name));
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IEventHubManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:19014DBA68BF4C143FA6803F3D71AEB6
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            await DeleteByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:9B2A559514B349EBD1BDDF3D29BDBC9E:C4E2F811E63804D39B306A96EAC9A8DE
        public void DeleteByName(string resourceGroupName, string namespaceName, string eventHubName, string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(resourceGroupName, namespaceName, eventHubName, name));

        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:37DAFCA0F979EB14168635F75681B9E4
        public IEventHubConsumerGroup GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:8B61E578211E798393BC11B4706B4C15
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:F75176B567559F61407091313919F2A5:BEE47D83B648578AE6A5C58DC3294324
        public async Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string eventHubName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(resourceGroupName,
                namespaceName,
                eventHubName,
                name,
                cancellationToken);
        }

        ///GENMHASH:C8A58AEE2F5CBB92277D15A09AB930AC:85DE81FA03AE78AFB462762B95A005D9
        private EventHubConsumerGroupImpl WrapModel(ConsumerGroupInner innerModel)
        {
            return new EventHubConsumerGroupImpl(innerModel.Name, innerModel, this.manager);
        }
    }
}