// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for  EventHubDisasterRecoveryPairing.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViRGlzYXN0ZXJSZWNvdmVyeVBhaXJpbmdJbXBs
    internal partial class EventHubDisasterRecoveryPairingImpl  :
        NestedResourceImpl<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing, ArmDisasterRecoveryInner,Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairingImpl, IUpdate>,
        IEventHubDisasterRecoveryPairing,
        IDefinition,
        IUpdate
    {
        private OneAncestor ancestor;

        ///GENMHASH:04F6B650E0C76ECE13EA9B3998E66D77:615AAB077A4DA6D0FB4F0A984736F066
        internal  EventHubDisasterRecoveryPairingImpl(string name, ArmDisasterRecoveryInner inner, IEventHubManager manager) : base(name, inner, manager)
        {
            this.ancestor = new OneAncestor(inner.Id);
        }

        ///GENMHASH:F83205D143F4F7C46558022FA548F677:0CCE028AD9D78047FAADDB9BEB1C0669
        internal  EventHubDisasterRecoveryPairingImpl(string name, IEventHubManager manager) : base(name, new ArmDisasterRecoveryInner(), manager)
        {
        }

        ///GENMHASH:A476AEE01E31EA369D13539C554EBCA9:E2D0E9C2E913034FE2F5B8204F5797F5
        public string PrimaryNamespaceResourceGroupName()
        {
            return this.Ancestor().ResourceGroupName;
        }

        ///GENMHASH:7136E7A51AF07AE271F03196057663FC:44D93BEB0AEB0D232B2497DD293956E3
        public string PrimaryNamespaceName()
        {
            return this.Ancestor().Ancestor1Name;
        }

        ///GENMHASH:E0357E0580C347972135EDB6120F342A:9FDFD248866EC233B8594E72273D7B1B
        public string SecondaryNamespaceId()
        {
            return this.Inner.PartnerNamespace;
        }

        ///GENMHASH:D38FA0E041C069D6652DA234269D8B6C:FD23977BD91FE98C3065B6E757B7B31A
        public RoleDisasterRecovery? NamespaceRole()
        {
            return this.Inner.Role;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public ProvisioningStateDR? ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:E44B2C1A872FCC1923371FF81AF28CA0:EDA80D678FC3FF2592A13E3E96233046
        public EventHubDisasterRecoveryPairingImpl WithExistingPrimaryNamespace(IEventHubNamespace nhNamespace)
        {
            this.ancestor = new OneAncestor(SelfId(nhNamespace.Id));
            return this;
        }

        ///GENMHASH:E5CEA9FED3A7366B27CB76E03413FB9F:A8B398067B717526C75A7C5710E725B0
        public EventHubDisasterRecoveryPairingImpl WithExistingPrimaryNamespace(string resourceGroupName, string primaryNamespaceName)
        {
            this.ancestor = new OneAncestor(resourceGroupName, primaryNamespaceName);
            return this;
        }

        ///GENMHASH:CEA9DD829EF21ABA2570791028266A17:CE786D4FB6D8E17D92A67502DF4FD6E0
        public EventHubDisasterRecoveryPairingImpl WithExistingPrimaryNamespaceId(string namespaceId)
        {
            this.ancestor = new OneAncestor(SelfId(namespaceId));
            return this;
        }

        ///GENMHASH:FAD97508A22E3D753BD22A120446C426:25F30D04BAADB2D9857456903299E903
        public EventHubDisasterRecoveryPairingImpl WithNewPrimaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            this.AddCreatableDependency(namespaceCreatable as IResourceCreator<IHasId>);
            EventHubNamespaceImpl ehNamespace = ((EventHubNamespaceImpl) namespaceCreatable);
            this.ancestor = new OneAncestor(ehNamespace.ResourceGroupName, namespaceCreatable.Name);
            return this;
        }

        ///GENMHASH:C0D4E0E0BD08B22D12CF95D0B0756897:DA0B7CAC98D64910412CB27D6CFA6B12
        public EventHubDisasterRecoveryPairingImpl WithExistingSecondaryNamespace(IEventHubNamespace nhNamespace)
        {
            this.Inner.PartnerNamespace = nhNamespace.Id ?? throw new ArgumentNullException("nhNamespace.Id");
            return this;
        }

        ///GENMHASH:1D533DD7E302ADE1C56C36EDE3B1C11C:9E1F8BA0AD2B7CBB09BA2EF808F68B64
        public EventHubDisasterRecoveryPairingImpl WithExistingSecondaryNamespaceId(string namespaceId)
        {
            this.Inner.PartnerNamespace = namespaceId ?? throw new ArgumentNullException("namespaceId");
            return this;
        }

        ///GENMHASH:7D841E597D17BCD179F2A65D493BE179:15B38D169822D948E4502A0888DA84AA
        public EventHubDisasterRecoveryPairingImpl WithNewSecondaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            this.AddCreatableDependency(namespaceCreatable as IResourceCreator<IHasId>);
            EventHubNamespaceImpl ehNamespace = ((EventHubNamespaceImpl)namespaceCreatable);
            this.Inner.PartnerNamespace = ehNamespace.Name;
            return this;
        }

        ///GENMHASH:9A4E3F41A871CC515D8BB55194E60320:2B91B629CA6F0A9D80277F4EEC031BB9
        public async Task BreakPairingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DisasterRecoveryConfigs.BreakPairingAsync(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor1Name,
                this.Name, 
                cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:672258F380132668907B1425A93D74E1:26CA102DFF02D40B2C832DF17782E023
        public void BreakPairing()
        {
            Extensions.Synchronize(() => BreakPairingAsync());
        }

        ///GENMHASH:E42A0416DF558FB7762C4D5D91B98C8D:463AE6BF52FF214D6396DD09F1B3EED4
        public async Task FailOverAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Fail over is run against secondary namespace (because primary might be down at time of failover)
            //
            ResourceId secondaryNs = ResourceId.FromString(this.Inner.PartnerNamespace);
            await this.Manager.Inner.DisasterRecoveryConfigs.FailOverAsync(secondaryNs.ResourceGroupName,
                secondaryNs.Name,
                this.Name,
                cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:5E571B5874E00595C35082DC9F3F8633:420B820CBA0F4722F8ED8B776C30C228
        public void FailOver()
        {
            Extensions.Synchronize(() => this.FailOverAsync());
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AF5F5922BA778F862B0E5C20EC36C636
        protected override async Task<ArmDisasterRecoveryInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DisasterRecoveryConfigs.GetAsync(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor1Name,
                this.Name,
                cancellationToken);
        }

        ///GENMHASH:2FAF2208689547C6A4D62711AACA378B:6D92B86A1B6F88C1B61B6BE18CF67B2A
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> ListAuthorizationRules()
        {
            return this.Manager.DisasterRecoveryPairingAuthorizationRules.ListByDisasterRecoveryPairing(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor1Name,
                this.Name);
        }

        ///GENMHASH:362D73D3A0A345883DD0DA56D35DF38D:22F7986A4794FFC098CC3B1C19AEDA41
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.DisasterRecoveryPairingAuthorizationRules.ListByDisasterRecoveryPairingAsync(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor1Name,
                this.Name,
                cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:88CDF0BB761FBA6BFF95AB17A7238BAE
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.DisasterRecoveryConfigs.CreateOrUpdateAsync(this.Ancestor().ResourceGroupName,
                this.Ancestor().Ancestor1Name,
                this.Name,
                this.Inner,
                cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private OneAncestor Ancestor()
        {
            return this.ancestor ?? throw new System.ArgumentNullException("this.ancestor");
        }

        ///GENMHASH:BE19D5FA60872E55D3B07FEE99BE7B1F:8CB57954920CADF9ADC6CC1E4BB859E3
        private string SelfId(string parentId)
        {
            return $"{parentId}/disasterRecoveryConfig/{this.Name}";
        }
    }
}