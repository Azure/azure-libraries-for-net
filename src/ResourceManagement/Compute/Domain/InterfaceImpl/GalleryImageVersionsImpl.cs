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

    internal partial class GalleryImageVersionsImpl 
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
        GalleryImageVersion.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<GalleryImageVersion.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Delete a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.DeleteByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName)
        {
 
            this.DeleteByGalleryImage(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName);
        }

        /// <summary>
        /// Delete a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The completable for the request.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.DeleteByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken)
        {
 
            await this.DeleteByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image version resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.GetByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName)
        {
            return this.GetByGalleryImage(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName);
        }

        /// <summary>
        /// Retrieves information about a gallery image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <param name="galleryImageVersionName">The name of the gallery image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.GetByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken)
        {
            return await this.GetByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, cancellationToken);
        }

        /// <summary>
        /// List gallery image versions under a gallery image.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>List of gallery image versions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.ListByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName)
        {
            return this.ListByGalleryImage(resourceGroupName, galleryName, galleryImageName);
        }

        /// <summary>
        /// List gallery image versions under a gallery image.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersions.ListByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken)
        {
            return await this.ListByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, cancellationToken);
        }
    }
}