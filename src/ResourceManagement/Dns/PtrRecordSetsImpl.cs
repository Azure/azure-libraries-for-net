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
    /// Implementation of PtrRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRzSW1wbA==
    internal partial class PtrRecordSetsImpl :
        DnsRecordSetsBaseImpl<IPtrRecordSet, PtrRecordSetImpl>,
        IPtrRecordSets
    {
        ///GENMHASH:698FCAC9EA6BAA4A563CD91E904DAC5A:8A04418FAAE6586C1CDA7FE62754D54A
        internal PtrRecordSetsImpl(DnsZoneImpl dnsZone)
            : base(dnsZone, RecordType.PTR)
        {
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:F9073E112F17454F48F8E8DCD9BA7F1A
        protected override IEnumerable<IPtrRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:6382D181836A0C870ECE45FB1B78C0A1
        protected async override Task<IPagedCollection<IPtrRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPtrRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }


        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:5790D7FC3ED2AF18F18B8F18EC95B804
        protected override IPtrRecordSet WrapModel(RecordSetInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new PtrRecordSetImpl(inner.Name, dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:93E660F67B8C926701C7F877ABD264AD
        public async override Task<IPtrRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
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
            return new PtrRecordSetImpl(inner.Name, dnsZone, inner);
        }
    }
}
