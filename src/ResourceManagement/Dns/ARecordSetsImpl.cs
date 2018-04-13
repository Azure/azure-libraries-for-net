// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ARecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0c0ltcGw=
    internal partial class ARecordSetsImpl :
        DnsRecordSetsBaseImpl<Microsoft.Azure.Management.Dns.Fluent.IARecordSet, Microsoft.Azure.Management.Dns.Fluent.ARecordSetImpl>,
        IARecordSets
    {
        ///GENMHASH:E10F3F1B0497821B014BAFEF65431F45:27F2A74380A4DC207BDE34AFB4DFAE90
        internal ARecordSetsImpl(DnsZoneImpl dnsZone)
            : base(dnsZone, RecordType.A)
        {
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:EEA14E280E95338CD14E31A7F62111C8
        protected override IEnumerable<IARecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:6382D181836A0C870ECE45FB1B78C0A1
        protected async override Task<IPagedCollection<IARecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IARecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:CE9DBED116E6E117C7BF5BDC4CB2151D
        protected override IARecordSet WrapModel(RecordSetInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new ARecordSetImpl(inner.Name, dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:E16F0B1987E35A10ADAE4962EE6952F6
        public async override Task<IARecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            if (inner == null)
            {
                return null;
            }
            return new ARecordSetImpl(inner.Name, dnsZone, inner);
        }
    }
}
