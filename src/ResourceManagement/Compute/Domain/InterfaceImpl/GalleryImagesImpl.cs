// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GalleryImagesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        GalleryImage.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<GalleryImage.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Delete an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.DeleteByGallery(string resourceGroupName, string galleryName, string galleryImageName)
        {
 
            this.DeleteByGallery(resourceGroupName, galleryName, galleryImageName);
        }

        /// <summary>
        /// Delete a gallery image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The completable for the request.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.DeleteByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken)
        {
 
            await this.DeleteByGalleryAsync(resourceGroupName, galleryName, galleryImageName, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImage Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.GetByGallery(string resourceGroupName, string galleryName, string galleryImageName)
        {
            return this.GetByGallery(resourceGroupName, galleryName, galleryImageName);
        }

        /// <summary>
        /// Retrieves information about an image in a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.GetByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken)
        {
            return await this.GetByGalleryAsync(resourceGroupName, galleryName, galleryImageName, cancellationToken);
        }

        /// <summary>
        /// List images under a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The list of images in the gallery.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.ListByGallery(string resourceGroupName, string galleryName)
        {
            return this.ListByGallery(resourceGroupName, galleryName);
        }

        /// <summary>
        /// List images under a gallery.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> Microsoft.Azure.Management.Compute.Fluent.IGalleryImages.ListByGalleryAsync(string resourceGroupName, string galleryName, CancellationToken cancellationToken)
        {
            return await this.ListByGalleryAsync(resourceGroupName, galleryName, cancellationToken);
        }
    }
}