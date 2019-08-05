// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Type representing ImmutabilityPolicy.
    /// </summary>
    public interface IImmutabilityPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ImmutabilityPolicyInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ImmutabilityPolicy.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.StorageManager>
    {

        /// <summary>
        /// Gets the etag value.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the immutabilityPeriodSinceCreationInDays value.
        /// </summary>
        int ImmutabilityPeriodSinceCreationInDays { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the state value.
        /// </summary>
        ImmutabilityPolicyState State { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }
    }
}