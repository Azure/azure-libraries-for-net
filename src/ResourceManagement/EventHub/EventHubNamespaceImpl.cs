// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHubNamespace.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViTmFtZXNwYWNlSW1wbA==
    internal partial class EventHubNamespaceImpl  :
        GroupableResource<IEventHubNamespace,
            EHNamespaceInner,
            EventHubNamespaceImpl,
            IEventHubManager, 
            EventHubNamespace.Definition.IWithGroup,
            EventHubNamespace.Definition.IWithCreate,
            EventHubNamespace.Definition.IWithCreate,
            EventHubNamespace.Update.IUpdate>,
        IEventHubNamespace,
        IDefinition,
        IUpdate
    {
        //
        // Track the work to be executed after the creation of EventHub
        //
        private IList<Func<CancellationToken, Task>> postRunWorks = new List<Func<CancellationToken, Task>>();

        ///GENMHASH:343DAB60E160C2A04CFD5A82A2EB461A:B6C6A00BFC93336EDE90DB15B3BEA7B7
        public EventHubNamespaceImpl(string name, EHNamespaceInner innerObject, IEventHubManager manager) : base(name, innerObject, manager)
        {
        }

        ///GENMHASH:3962220D937EB4F200D683CECEA45727:F2E0DA6714F4CBB82BD262DD3FAFD7F0
        public string ServiceBusEndpoint()
        {
            return this.Inner.ServiceBusEndpoint;
        }

        ///GENMHASH:DB3834FD93143DA0E9847461A308810F:62F10A3FC658A6F94A54BE67A5B6D5D8
        public bool IsAutoScaleEnabled()
        {
            if (this.Inner.IsAutoInflateEnabled != null)
            {
                return this.Inner.IsAutoInflateEnabled.Value;
            }
            else
            {
                return false;
            }
        }

        ///GENMHASH:9157FD0110376DF53A83D529D7A1A4E1:385804CDAC891325C8D939BDF7A1D4FF
        public DateTime? CreatedAt()
        {
            return this.Inner.CreatedAt;
        }

        ///GENMHASH:B099FD16576099A4F48DB0A0EE87FF9B:12B8A4336CA20EB9E7FE6F8F7F2CC2DF
        public string AzureInsightMetricId()
        {
            return this.Inner.MetricId;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:D97CE2D58226FF4B73B4E8EDF3358463
        public EventHubNamespaceSkuType Sku()
        {
            return new EventHubNamespaceSkuType(this.Inner.Sku);
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime? UpdatedAt()
        {
            return this.Inner.UpdatedAt;
        }

        ///GENMHASH:789F654DD22359E4AE3F3631D51B30ED:4DAC7D59CF4FB874D5CCBD689DB1EA4A
        public int ThroughputUnitsUpperLimit()
        {
            if (this.Inner.MaximumThroughputUnits != null)
            {
                return this.Inner.MaximumThroughputUnits.Value;
            }
            else
            {
                return 0;
            }
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:5DEBE4D95E83E32EAB8F505846564E01:FC9A92134F6FDFEA7A719655E417D29C
        public int CurrentThroughputUnits()
        {
            if (this.Inner.Sku.Capacity != null)
            {
                return this.Inner.Sku.Capacity.Value;
            }
            else
            {
                return 0;
            }
        }

        ///GENMHASH:BDF0DC70A064E2047A24637D4F56F222:FAF8005B914DCF6C71934F11FD2529B7
        public EventHubNamespaceImpl WithNewEventHub(string eventHubName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubs
                    .Define(eventHubName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:C814196F8EEB0C5B07BFF92622AA819D:A674C2CCDB93EE4E81E7E544FF80C76C
        public EventHubNamespaceImpl WithNewEventHub(string eventHubName, int partitionCount)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubs
                    .Define(eventHubName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .WithPartitionCount(partitionCount)
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:526F95D849556843B681D27670765511:623E34B7DADA6AE634DA39CDA1E7B2B3
        public EventHubNamespaceImpl WithNewEventHub(string eventHubName, int partitionCount, int retentionPeriodInDays)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubs
                    .Define(eventHubName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .WithPartitionCount(partitionCount)
                    .WithRetentionPeriodInDays(retentionPeriodInDays)
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:862079539008CC7E94AC16CBADF6ABD4:A90AF9D97254216E18A9267002C865ED
        public IUpdate WithoutEventHub(string eventHubName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubs
                    .DeleteByNameAsync(ResourceGroupName, Name, eventHubName, cancellation);
            });
            return this;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:127073AEE9862FE2D212C62D63A8ADB5
        public EventHubNamespaceImpl WithNewSendRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.NamespaceAuthorizationRules
                    .Define(ruleName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .WithSendAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:38BC74FCFE3423DB778ECCC2B84F251E
        public EventHubNamespaceImpl WithNewListenRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.NamespaceAuthorizationRules
                    .Define(ruleName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .WithListenAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:F865D4E667B3A4216AF7CC76DA8E059E
        public EventHubNamespaceImpl WithNewManageRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.NamespaceAuthorizationRules
                    .Define(ruleName)
                    .WithExistingNamespace(ResourceGroupName, Name)
                    .WithManageAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:7701B5E45C28C739B5610C34A2EF5559:3E36FFFD80999636F7DC51AEE1BDDD60
        public EventHubNamespaceImpl WithoutAuthorizationRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.NamespaceAuthorizationRules
                    .DeleteByNameAsync(ResourceGroupName, Name, ruleName, cancellation);
            });
            return this;
        }

        ///GENMHASH:004035C444C5F4CA10FA722E91350738:A17BB30DC734E527E849483DE6A87DA0
        public EventHubNamespaceImpl WithCurrentThroughputUnits(int units)
        {
            this.SetDefaultSkuIfNotSet();
            this.Inner.Sku.Capacity = units;
            return this;
        }

        ///GENMHASH:172BAABE3E05772DFEBBCC2B31722E5D:C692E2972C39E42DDCFFDCE2B23CDF2F
        public EventHubNamespaceImpl WithAutoScaling()
        {
            // Auto-inflate requires a Sku > 'Basic' with capacity.
            this.SetDefaultSkuIfNotSet();
            this.Inner.IsAutoInflateEnabled = true;
            if (this.Inner.MaximumThroughputUnits == null)
            {
                 // Required when auto-inflate is set & use portal default.
                this.WithThroughputUnitsUpperLimit(20);
            }
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:63444DD8B5D3D65B0B8CC46C8A7D6BFB
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await this.Manager.Inner.Namespaces
                    .CreateOrUpdateAsync(ResourceGroupName, Name, this.Inner, cancellationToken);
                this.SetInner(inner);
                await Task.WhenAll(this.postRunWorks.Select(p => p(cancellationToken)).ToArray());
            }
            finally
            {
                this.postRunWorks.Clear();
            }
            return this;
        }

        ///GENMHASH:8D7EF5ED8462FA82ABA2E5F53002640A:05ED6FB46167AFEF981550F3075A1353
        public EventHubNamespaceImpl WithThroughputUnitsUpperLimit(int units)
        {
            this.Inner.MaximumThroughputUnits = units;
            return this;
        }

        ///GENMHASH:C48A746F5694508AB09E61AAF0F90782:5F8FA9E8CC1C70C9CDDD00BC8211E388
        public EventHubNamespaceImpl WithSku(EventHubNamespaceSkuType namespaceSku)
        {
            Sku newSkuInner = new Sku
            {
                Name = namespaceSku.Name(),
                Tier = namespaceSku.Tier(),
                Capacity = null
            };
            Sku currentSkuInner = this.Inner.Sku;
            bool isDifferent = currentSkuInner == null || !currentSkuInner.Name.Equals(newSkuInner.Name);
            if (isDifferent)
            {
                this.Inner.Sku = newSkuInner;
                if (newSkuInner.Name.Equals(SkuName.Standard))
                {
                    newSkuInner.Capacity = 1;
                }
            }
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:6B59E5250798DE7162AA40D03C37BC76
        protected override async Task<EHNamespaceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:3EE273EE4D62EEBDEF6A6504795341D1:E3F88E10BC75D3AA8E5D63CB31408492
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> ListEventHubs()
        {
            return this.Manager.EventHubs.ListByNamespace(ResourceGroupName, Name);
        }

        ///GENMHASH:A83092260CFC1DE32D6AD56CCB7EF30D:DC02B2383AD2D1413628908699BA0CF2
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> ListEventHubsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.EventHubs.ListByNamespaceAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:2FAF2208689547C6A4D62711AACA378B:48280EAB50AEF29CC837FDD0BD322F89
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> ListAuthorizationRules()
        {
            return this.Manager.NamespaceAuthorizationRules
                .ListByNamespace(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:362D73D3A0A345883DD0DA56D35DF38D:E7BFCBD1276EBB06F22B520CAA9538B3
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.NamespaceAuthorizationRules.ListByNamespaceAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:2A540D3EA5484526657F0DCDF3830DB2:4FD56E792DCEA9C8B4208C7730ED2A42
        private void SetDefaultSkuIfNotSet()
        {
            if (this.Inner.Sku == null)
            {
                this.WithSku(EventHubNamespaceSkuType.Standard);
            }
        }

    }
}