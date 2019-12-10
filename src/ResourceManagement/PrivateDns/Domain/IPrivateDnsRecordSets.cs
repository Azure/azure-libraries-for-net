// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base interface for all record sets.
    /// </summary>
    /// <typeparam name="RecordSetT">The record set type.</typeparam>
    public interface IPrivateDnsRecordSets<RecordSetT> :
        ISupportsGettingById<RecordSetT>,
        ISupportsGettingByName<RecordSetT>,
        IHasParent<IPrivateDnsZone>,
        IHasInner<IRecordSetsOperations>
    {
        /// <summary>
        /// Deletes a record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteById(string id, string eTagValue = default(string));

        /// <summary>
        /// Asynchronously delete the record set from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByIdAsync(string id, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a record set from Azure, identifying it by its name.
        /// </summary>
        /// <param name="recordSetName">The name of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteByName(string recordSetName, string eTagValue = default(string));

        /// <summary>
        /// Asynchronously delete the record set from Azure, identifying it by its name.
        /// </summary>
        /// <param name="recordSetName">The name of the record set to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByNameAsync(string recordSetName, string eTagValue = default(string), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        IEnumerable<RecordSetT> List(string recordSetNameSuffix = default(string), int? pageSize = default(int?));

        /// <summary>
        /// Asynchronously lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        Task<IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix = default(string), int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
