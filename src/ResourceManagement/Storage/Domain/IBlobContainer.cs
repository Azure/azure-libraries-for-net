// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Type representing BlobContainer.
    /// </summary>
    public interface IBlobContainer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<BlobContainerInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<BlobContainer.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.StorageManager>
    {

        /// <summary>
        /// Gets the etag value.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets the hasImmutabilityPolicy value.
        /// </summary>
        bool? HasImmutabilityPolicy { get; }

        /// <summary>
        /// Gets the hasLegalHold value.
        /// </summary>
        bool? HasLegalHold { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the immutabilityPolicy value.
        /// </summary>
        ImmutabilityPolicyProperties ImmutabilityPolicy { get; }

        /// <summary>
        /// Gets the lastModifiedTime value.
        /// </summary>
        System.DateTime? LastModifiedTime { get; }

        /// <summary>
        /// Gets the leaseDuration value.
        /// </summary>
        LeaseDuration LeaseDuration { get; }

        /// <summary>
        /// Gets the leaseState value.
        /// </summary>
        LeaseState LeaseState { get; }

        /// <summary>
        /// Gets the leaseStatus value.
        /// </summary>
        LeaseStatus LeaseStatus { get; }

        /// <summary>
        /// Gets the legalHold value.
        /// </summary>
        LegalHoldProperties LegalHold { get; }

        /// <summary>
        /// Gets the metadata value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Metadata { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the publicAccess value.
        /// </summary>
        PublicAccess? PublicAccess { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }
    }
}