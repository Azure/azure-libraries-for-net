// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure gallery.
    /// </summary>
    public interface IGallery  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.GalleryInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager,Models.GalleryInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IGallery>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Gallery.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>
    {

        /// <summary>
        /// Gets description for the gallery resource.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the provisioning state of the gallery resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the unique name of the gallery resource.
        /// </summary>
        string UniqueName { get; }

        /// <summary>
        /// Retrieves information about an image in the gallery.
        /// </summary>
        /// <param name="imageName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImage GetImage(string imageName);

        /// <summary>
        /// Retrieves information about an image in the gallery.
        /// </summary>
        /// <param name="imageName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> GetImageAsync(string imageName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List images in the gallery.
        /// </summary>
        /// <return>The list of images in the gallery.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> ListImages();

        /// <summary>
        /// List images in the gallery.
        /// </summary>
        /// <return>The observable for the request.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> ListImagesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}