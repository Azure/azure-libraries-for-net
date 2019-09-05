// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure managed snapshot.
    /// </summary>
    public interface ISnapshot :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager, Models.SnapshotInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Snapshot.Update.IUpdate>
    {

        /// <summary>
        /// Gets the snapshot creation method.
        /// </summary>
        Models.DiskCreateOption CreationMethod { get; }

        /// <summary>
        /// Gets the type of operating system in the snapshot.
        /// </summary>
        Models.OperatingSystemTypes? OSType { get; }

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int SizeInGB { get; }

        /// <return>Gets the snapshot SKU type.</return>
        /// <summary>
        /// Gets use  Snapshot.skuType() instead.
        /// </summary>
        Models.DiskSkuTypes Sku { get; }

        /// <summary>
        /// Gets or sets whether a snapshot is incremental. Incremental
        /// snapshots on the same disk occupy less space than full snapshots
        /// and can be diffed.
        /// </summary>
        bool? Incremental { get; }

        /// <summary>
        /// Gets the snapshot SKU type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.SnapshotSkuType SkuType { get; }

        /// <summary>
        /// Gets the details of the source from which snapshot is created.
        /// </summary>
        Models.CreationSource Source { get; }

        /// <summary>
        /// Grants access to the snapshot.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The read-only SAS URI to the snapshot.</return>
        string GrantAccess(int accessDurationInSeconds);

        /// <summary>
        /// Grants access to the snapshot asynchronously.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>A representation of the deferred computation of this call returning a read-only SAS URI to the disk.</return>
        Task<string> GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revoke access granted to the snapshot.
        /// </summary>
        void RevokeAccess();

        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RevokeAccessAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}