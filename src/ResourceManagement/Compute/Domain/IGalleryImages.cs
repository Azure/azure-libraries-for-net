// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to gallery images management API in Azure.
    /// </summary>
    public interface IGalleryImages  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<GalleryImage.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IGalleryImagesOperations>
    {

        /// <summary>
        /// Delete an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        void DeleteByGallery(string resourceGroupName, string galleryName, string galleryImageName);

        /// <summary>
        /// Delete a gallery image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The completable for the request.</return>
        Task DeleteByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves information about an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImage GetByGallery(string resourceGroupName, string galleryName, string galleryImageName);

        /// <summary>
        /// Retrieves information about an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> GetByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List images under a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The list of images in the gallery.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> ListByGallery(string resourceGroupName, string galleryName);

        /// <summary>
        /// List images under a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <throws>ValidationException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> ListByGalleryAsync(string resourceGroupName, string galleryName, CancellationToken cancellationToken = default(CancellationToken));
    }
}