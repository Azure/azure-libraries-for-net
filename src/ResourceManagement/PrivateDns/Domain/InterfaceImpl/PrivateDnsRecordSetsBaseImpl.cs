// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The base implementation for private Dns record sets.
    /// </summary>
    internal abstract class PrivateDnsRecordSetsBaseImpl<RecordSetT, RecordSetImplT> :
        ReadableWrappers<RecordSetT, RecordSetImplT, RecordSetInner>,
        IPrivateDnsRecordSets<RecordSetT>
        where RecordSetImplT : RecordSetT
    {
        protected readonly PrivateDnsZoneImpl parent;
        protected readonly RecordType recordType;

        internal PrivateDnsRecordSetsBaseImpl(PrivateDnsZoneImpl parent, RecordType recordType)
        {
            this.parent = parent;
            this.recordType = recordType;
        }

        IPrivateDnsZone IHasParent<IPrivateDnsZone>.Parent
        {
            get
            {
                return parent;
            }
        }

        public void DeleteById(string id, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, eTagValue, CancellationToken.None));
        }

        public async Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await parent.Manager.Inner.RecordSets.DeleteAsync(parent.ResourceGroupName,
                parent.Name,
                recordType,
                ResourceUtils.NameFromResourceId(id),
                ifMatch: eTagValue,
                cancellationToken: cancellationToken);
        }

        

        public void DeleteByName(string recordSetName, string eTagValue = default(string))
        {
            Extensions.Synchronize(() => DeleteByNameAsync(recordSetName, eTagValue, CancellationToken.None));
        }

        public async Task DeleteByNameAsync(string recordSetName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            await parent.Manager.Inner.RecordSets.DeleteAsync(
                parent.ResourceGroupName,
                parent.Name,
                recordType,
                recordSetName,
                ifMatch: eTagValue,
                cancellationToken: cancellationToken);
        }

        public RecordSetT GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        public async Task<RecordSetT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await parent.Manager.Inner.RecordSets.GetAsync(
                parent.ResourceGroupName,
                parent.Name,
                recordType,
                ResourceUtils.NameFromResourceId(id),
                cancellationToken);
            return WrapModel(inner);
        }

        public RecordSetT GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name, CancellationToken.None));
        }

        public async Task<RecordSetT> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await parent.Manager.Inner.RecordSets.GetAsync(
                parent.ResourceGroupName,
                parent.Name,
                recordType,
                name,
                cancellationToken);
            return WrapModel(inner);
        }

        public IEnumerable<RecordSetT> List(string recordSetNameSuffix = default(string), int? pageSize = default(int?))
        {
            return Extensions.Synchronize(() => ListAsync(recordSetNameSuffix, pageSize, pageSize == null, CancellationToken.None));
        }

        public async Task<IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix = default(string), int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<RecordSetT, RecordSetInner>.LoadPage(
                async (cancellation) => await parent.Manager.Inner.RecordSets.ListByTypeAsync(
                    parent.ResourceGroupName,
                    parent.Name,
                    recordType,
                    top: pageSize,
                    recordsetnamesuffix: recordSetNameSuffix,
                    cancellationToken: cancellationToken),
                parent.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        IRecordSetsOperations IHasInner<IRecordSetsOperations>.Inner
        {
            get
            {
                return parent.Manager.Inner.RecordSets;
            }
        }
    }
}
