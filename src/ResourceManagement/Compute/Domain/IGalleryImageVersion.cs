// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure gallery image version.
    /// </summary>
    public interface IGalleryImageVersion  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.GalleryImageVersionInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<GalleryImageVersion.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>
    {
        /// <summary>
        /// Gets the date indicating image version's end of life.
        /// </summary>
        System.DateTime? EndOfLifeDate { get; }

        /// <summary>
        /// Gets true if the image version is excluded from considering as a
        /// candidate when VM is created with 'latest' image version, false otherwise.
        /// </summary>
        bool IsExcludedFromLatest { get; }

        /// <summary>
        /// Gets the default location of the image version.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the image version name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the provisioningState of image version resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the publishingProfile configuration of the image version.
        /// </summary>
        Models.GalleryImageVersionPublishingProfile PublishingProfile { get; }

        /// <summary>
        /// Gets the replicationStatus of image version in published regions.
        /// </summary>
        Models.ReplicationStatus ReplicationStatus { get; }

        /// <summary>
        /// Gets the image version storageProfile describing OS and data disks.
        /// </summary>
        Models.GalleryImageVersionStorageProfile StorageProfile { get; }

        /// <summary>
        /// Gets the tags associated with the image version.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Tags { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        string Type { get; }
    }
}