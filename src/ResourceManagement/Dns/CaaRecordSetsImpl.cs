// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of CaaRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DYWFSZWNvcmRTZXRzSW1wbA==
    internal partial class CaaRecordSetsImpl :
        DnsRecordSetsBaseImpl<ICaaRecordSet, CaaRecordSetImpl>,
        ICaaRecordSets
    {
        ///GENMHASH:EEB410A5EA919445D4E5698B664F7830:3C4EDE8D8CC940E4AB5B511F7C19D5EA
        internal CaaRecordSetsImpl(DnsZoneImpl dnsZone)
            : base(dnsZone, RecordType.CAA)
        {
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:EEA14E280E95338CD14E31A7F62111C8
        protected override IEnumerable<ICaaRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:6382D181836A0C870ECE45FB1B78C0A1
        protected override async Task<IPagedCollection<ICaaRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ICaaRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:6C3DDD07D6E662492FE24CA780BD53B1
        protected override ICaaRecordSet WrapModel(RecordSetInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new CaaRecordSetImpl(inner.Name, dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:CB4F1D0A062390E60C8573A2C1C7AE16
        public async override Task<ICaaRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
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
            return new CaaRecordSetImpl(inner.Name, dnsZone, inner);
        }
    }
}