// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHubs.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHVic0ltcGw=
    internal partial class EventHubsImpl  :
        Wrapper<IEventHubsOperations>,
        IEventHubs
    {
        private readonly IEventHubManager manager;
        private readonly IStorageManager storageManager;

        ///GENMHASH:033B3D5B0CB5B1CB48112216162F1E15:9FCC807E672DA3E71D7540953C306BD0
        public EventHubsImpl(IEventHubManager manager, IStorageManager storageManager) : base(manager.Inner.EventHubs)
        {
            this.manager = manager;
            this.storageManager = storageManager;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IEventHubManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:CAEAA7B656CCE3621F20FB55E8F156B8
        public EventHubImpl Define(string name)
        {
            return new EventHubImpl(name, this.Manager, this.storageManager);
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:A3AF1EADE39C250534E5C9F3E1000D42
        public IEventHubAuthorizationRules AuthorizationRules()
        {
            return this.Manager.EventHubAuthorizationRules;
        }

        ///GENMHASH:BA5C78D019449627922BF148AC1D7EC1:0BE8F883611ED1ADDB1EF29853C5B32E
        public IEventHubConsumerGroups ConsumerGroups()
        {
            return this.Manager.ConsumerGroups;
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:37DAFCA0F979EB14168635F75681B9E4
        public IEventHub GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:279A0BE8EAAA54434723FD778381D28C
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException("id"));
            return await GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:6F4AD1869ECF2F037CD0AF38FA93C9B0:0A31950E036F62CFC3C4166A8686573F
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Inner.GetAsync(resourceGroupName,
                namespaceName,
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

        ///GENMHASH:AD2574D8A0B41B7543E661226E7079CC:3EAC4D0C83CAC924621C946950DC6EB1
        public IEventHub GetByName(string resourceGroupName, string namespaceName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, name));
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:8B61E578211E798393BC11B4706B4C15
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:9723D6330EE11E0764C52AE608F5F48E
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException("id"));
            await DeleteByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name, 
                cancellationToken);
        }

        ///GENMHASH:666C0465A5F64EEA835CC2DA55F94875:066987FB34F379BFE8B7DD7842362947
        public void DeleteByName(string resourceGroupName, string namespaceName, string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(resourceGroupName, namespaceName, name));
        }

        ///GENMHASH:76D3089A9A4A15E17E55ADC8A99BA937:A7ED93C8E89A6166255AB510D73F3A59
        public async Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(resourceGroupName,
                namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:6EDC0210EC32BAF3169D04C5071B3BA4:C0F3C750FC7EB704999286CDE900CACE
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken), int? skip = default(int?), int? top = default(int?))
        {
            return await PagedCollection<IEventHub, EventhubInner>.LoadPage(cancel => this.Inner.ListByNamespaceAsync(resourceGroupName, namespaceName, skip, top, cancel),
              (nextLink, cancel) => this.Inner.ListByNamespaceNextAsync(nextLink),
              WrapModel, 
              true, 
              cancellationToken);
        }

        ///GENMHASH:BC72564BF6A743AB48443EB9A1982EC5:4EAEA7F11457F47611F9F0234F239A8C
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> ListByNamespace(string resourceGroupName, string namespaceName)
        {
            return Extensions.Synchronize(() => this.Inner.ListByNamespaceAsync(resourceGroupName, namespaceName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.Inner.ListByNamespaceNextAsync(nextLink)))
                .Select(inner => WrapModel(inner));
        }

        ///GENMHASH:B7540FDAF52A09CAAD2AE0F1AEB9D55C:43F9E1DF562D60097594D20716D4D4AF
        private EventHubImpl WrapModel(EventhubInner innerModel)
        {
            return new EventHubImpl(innerModel.Name, innerModel, this.manager, this.storageManager);
        }
    }
}