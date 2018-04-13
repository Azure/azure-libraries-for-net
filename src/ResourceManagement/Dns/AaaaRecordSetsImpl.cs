// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of AaaaRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BYWFhUmVjb3JkU2V0c0ltcGw=
    internal partial class AaaaRecordSetsImpl :
        DnsRecordSetsBaseImpl<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet, Microsoft.Azure.Management.Dns.Fluent.AaaaRecordSetImpl>,
        IAaaaRecordSets
    {
        ///GENMHASH:4DBB29DC0AB074A2ADEBE0995A37B2FD:26612A7251FED5BBA8E632A591DFE1BF
        internal AaaaRecordSetsImpl(DnsZoneImpl dnsZone)
            : base(dnsZone, RecordType.AAAA)
        {
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:EEA14E280E95338CD14E31A7F62111C8
        protected override IEnumerable<IAaaaRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                    dnsZone.Name,
                                                                    recordType,
                                                                    top: pageSize,
                                                                    recordsetnamesuffix: recordSetNameSuffix))
                                                                .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:6382D181836A0C870ECE45FB1B78C0A1
        protected async override Task<IPagedCollection<IAaaaRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAaaaRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }


        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:0B3E2A2CA99FEE8D024AAE98E6686F31
        protected override IAaaaRecordSet WrapModel(RecordSetInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new AaaaRecordSetImpl(inner.Name, dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:1C98931F95D44FECAC6AD9E31FBF6559
        public async override Task<IAaaaRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
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
            return new AaaaRecordSetImpl(inner.Name, dnsZone, inner);
        }
    }
}
