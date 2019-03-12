// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GalleryImpl 
    {
        /// <summary>
        /// Gets description for the gallery resource.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGallery.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the gallery resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Compute.Fluent.IGallery.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the unique name of the gallery resource.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGallery.UniqueName
        {
            get
            {
                return this.UniqueName();
            }
        }

        /// <summary>
        /// Retrieves information about an image in the gallery.
        /// </summary>
        /// <param name="imageName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The gallery image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImage Microsoft.Azure.Management.Compute.Fluent.IGallery.GetImage(string imageName)
        {
            return this.GetImage(imageName);
        }

        /// <summary>
        /// Retrieves information about an image in the gallery.
        /// </summary>
        /// <param name="imageName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> Microsoft.Azure.Management.Compute.Fluent.IGallery.GetImageAsync(string imageName, CancellationToken cancellationToken)
        {
            return await this.GetImageAsync(imageName, cancellationToken);
        }

        /// <summary>
        /// List images in the gallery.
        /// </summary>
        /// <return>The list of images in the gallery.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> Microsoft.Azure.Management.Compute.Fluent.IGallery.ListImages()
        {
            return this.ListImages();
        }

        /// <summary>
        /// List images in the gallery.
        /// </summary>
        /// <return>The observable for the request.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> Microsoft.Azure.Management.Compute.Fluent.IGallery.ListImagesAsync(CancellationToken cancellationToken)
        {
            return await this.ListImagesAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies description for the gallery.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next definition stage.</return>
        Gallery.Definition.IWithCreate Gallery.Definition.IWithDescription.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies description for the gallery.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next update stage.</return>
        Gallery.Update.IUpdate Gallery.Update.IWithDescription.WithDescription(string description)
        {
            return this.WithDescription(description);
        }
    }
}