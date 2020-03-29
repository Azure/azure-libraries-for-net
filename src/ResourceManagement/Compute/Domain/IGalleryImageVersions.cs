// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to gallery image versions management API in Azure.
    /// </summary>
    public interface IGalleryImageVersions  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<GalleryImageVersion.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IGalleryImageVersionsOperations>
    {

        /// <summary>
        /// Delete a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        void DeleteByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName);

        /// <summary>
        /// Delete a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The completable for the request.</return>
        Task DeleteByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image version resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion GetByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName);

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List gallery image versions under a gallery image.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>List of gallery image versions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> ListByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName);

        /// <summary>
        /// List gallery image versions under a gallery image.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> ListByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image version resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion GetByGalleryImageWithReplicationStatus(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName);

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetByGalleryImageWithReplicationStatusAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken));
    }
}