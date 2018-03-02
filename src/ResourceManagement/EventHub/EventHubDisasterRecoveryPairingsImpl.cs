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
    /// Implementation for  EventHubDisasterRecoveryPairings.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViRGlzYXN0ZXJSZWNvdmVyeVBhaXJpbmdzSW1wbA==
    internal partial class EventHubDisasterRecoveryPairingsImpl  :
        Wrapper<IDisasterRecoveryConfigsOperations>,
        IEventHubDisasterRecoveryPairings
    {
        private readonly IEventHubManager manager;

        ///GENMHASH:4B3A7AB51BC9EC6F022C3C06D893C8EF:890CD058EE13022020E6BA5634A70A25
        public EventHubDisasterRecoveryPairingsImpl(IEventHubManager manager) : base(manager.Inner.DisasterRecoveryConfigs)
        {
            this.manager = manager;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:5C9222024AE5E2132078BA4BC35AE557
        public EventHubDisasterRecoveryPairingImpl Define(string name)
        {
            return new EventHubDisasterRecoveryPairingImpl(name, this.manager);
        }

        ///GENMHASH:BC72564BF6A743AB48443EB9A1982EC5:226D953DF327B3D34CCAF201631B7992
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> ListByNamespace(string resourceGroupName, string namespaceName)
        {
            return Extensions.Synchronize(() => 
                    Inner.ListAsync(resourceGroupName, namespaceName))
                .AsContinuousCollection(nextLink => 
                    Extensions.Synchronize(() => Inner.ListNextAsync(nextLink)))
                .Select(inner => WrapModel(inner));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:279A0BE8EAAA54434723FD778381D28C
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            return await GetByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:37DAFCA0F979EB14168635F75681B9E4
        public IEventHubDisasterRecoveryPairing GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }
        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IEventHubManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:9790D012FA64E47343F12DB13F0AA212
        public IDisasterRecoveryPairingAuthorizationRules AuthorizationRules()
        {
            return this.Manager.DisasterRecoveryPairingAuthorizationRules;
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:9723D6330EE11E0764C52AE608F5F48E
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id ?? throw new ArgumentNullException(id));
            await DeleteByNameAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:6F4AD1869ECF2F037CD0AF38FA93C9B0:1B2445055FB980EE4638ABA384C5DC9E
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> GetByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
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

        ///GENMHASH:6EDC0210EC32BAF3169D04C5071B3BA4:B26E20CB198C0E2FD54328DFD9C6DEAA
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>> ListByNamespaceAsync(string resourceGroupName, string namespaceName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IEventHubDisasterRecoveryPairing, ArmDisasterRecoveryInner>
                .LoadPage(
                    async (cancellation) =>
                        await Inner.ListAsync(resourceGroupName,
                                namespaceName,
                                cancellation),
                    async (nextLink, cancellation) =>
                        await Inner
                            .ListNextAsync(nextLink,
                                cancellation),
                    WrapModel, true, cancellationToken);
        }

        ///GENMHASH:666C0465A5F64EEA835CC2DA55F94875:066987FB34F379BFE8B7DD7842362947
        public void DeleteByName(string resourceGroupName, string namespaceName, string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(resourceGroupName, namespaceName, name));

        }

        ///GENMHASH:AD2574D8A0B41B7543E661226E7079CC:3EAC4D0C83CAC924621C946950DC6EB1
        public IEventHubDisasterRecoveryPairing GetByName(string resourceGroupName, string namespaceName, string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(resourceGroupName, namespaceName, name));
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:8B61E578211E798393BC11B4706B4C15
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:76D3089A9A4A15E17E55ADC8A99BA937:A7ED93C8E89A6166255AB510D73F3A59
        public async Task DeleteByNameAsync(string resourceGroupName, string namespaceName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(resourceGroupName,
                namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:B134FF8AC19473319058888CEDF3D349:F951DE929F3C4EE069E6A4EB30B4CE04
        private EventHubDisasterRecoveryPairingImpl WrapModel(ArmDisasterRecoveryInner innerModel)
        {
            return new EventHubDisasterRecoveryPairingImpl(innerModel.Name, innerModel, this.manager);
        }
    }
}