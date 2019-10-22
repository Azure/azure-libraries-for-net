// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Type representing BlobServiceProperties.
    /// </summary>
    public interface IBlobServiceProperties  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<BlobServicePropertiesInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<BlobServiceProperties.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.StorageManager>
    {

        /// <summary>
        /// Gets the cors value.
        /// </summary>
        CorsRules Cors { get; }

        /// <summary>
        /// Gets the defaultServiceVersion value.
        /// </summary>
        string DefaultServiceVersion { get; }

        /// <summary>
        /// Gets the deleteRetentionPolicy value.
        /// </summary>
        DeleteRetentionPolicy DeleteRetentionPolicy { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }
    }
}