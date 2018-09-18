// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify location.
    /// </summary>
    public interface IWithLocation  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the default location for the image version.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithSource WithLocation(string location);

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithSource WithLocation(Region location);
    }

    /// <summary>
    /// The stage of image version definition allowing to specify the regions in which the image version
    /// has to be available.
    /// </summary>
    public interface IWithAvailableRegion  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies a region in which image version needs to be available.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="replicaCount">The replica count in the region.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithRegionAvailability(Region region, int replicaCount);

        /// <summary>
        /// Specifies list of regions in which image version needs to be available.
        /// </summary>
        /// <param name="regions">The target region list.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithRegionAvailability(IList<TargetRegion> regions);
    }

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify that the version
    /// should not be considered as a candidate version when VM is deployed with 'latest' as version
    /// of the image.
    /// </summary>
    public interface IWithExcludeFromLatest  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that this version is not a candidate to consider as latest.
        /// </summary>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithExcludedFromLatest();
    }

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify end of life of the version.
    /// </summary>
    public interface IWithEndOfLifeDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies end of life date of the image version.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life date.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithEndOfLifeDate(DateTime endOfLifeDate);
    }

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify Tags.
    /// </summary>
    public interface IWithTags  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">The resource tags.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithTags(IDictionary<string,string> tags);
    }

    /// <summary>
    /// The first stage of a gallery image version definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithImage
    {

    }

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify parent image.
    /// </summary>
    public interface IWithImage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the image container to hold this image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithLocation WithExistingImage(string resourceGroupName, string galleryName, string galleryImageName);
    }

    /// <summary>
    /// The entirety of the gallery image version definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithImage,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithLocation,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithSource,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithAvailableRegion,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithEndOfLifeDate,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithExcludeFromLatest,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithTags
    {

    }

    /// <summary>
    /// The stage of the image version definition allowing to specify the source.
    /// </summary>
    public interface IWithSource  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that the provided custom image needs to be used as source of the image version.
        /// </summary>
        /// <param name="customImageId">The ARM id of the custom image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithSourceCustomImage(string customImageId);

        /// <summary>
        /// Specifies that the provided custom image needs to be used as source of the image version.
        /// </summary>
        /// <param name="customImage">The custom image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition.IWithCreate WithSourceCustomImage(IVirtualMachineCustomImage customImage);
    }
}