// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of TxtRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRzSW1wbA==
    internal partial class TxtRecordSetsImpl :
        DnsRecordSetsBaseImpl<ITxtRecordSet, TxtRecordSetImpl>,
        ITxtRecordSets
    {
        ///GENMHASH:DE142040F109CD3B229E5070C0CA4D4F:3D4AA50D3AD17F26B290CAD1D1D863EA
        internal TxtRecordSetsImpl(DnsZoneImpl dnsZone)
            : base(dnsZone, RecordType.TXT)
        {
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:F9073E112F17454F48F8E8DCD9BA7F1A
        protected override IEnumerable<ITxtRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:5F25733DC447575DB09A90567FCC2BB9
        protected async override Task<IPagedCollection<ITxtRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ITxtRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:130D11B36B3C96A2E5061419A038F3A8
        protected override ITxtRecordSet WrapModel(RecordSetInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new TxtRecordSetImpl(inner.Name, dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:7A58A7976A00272F010877CCB1285AFF
        public async override Task<ITxtRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
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
            return new TxtRecordSetImpl(inner.Name, dnsZone, inner);
        }


    }
}
