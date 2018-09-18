// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of image version update allowing to specify the regions in which the image version
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
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithRegionAvailability(Region region, int replicaCount);

        /// <summary>
        /// Specifies list of regions in which image version needs to be available.
        /// </summary>
        /// <param name="regions">The target region list.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithRegionAvailability(IList<TargetRegion> regions);

        /// <summary>
        /// Specifies that an image version should be removed from an existing region serving it.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithoutRegionAvailability(Region region);
    }

    /// <summary>
    /// The stage of the gallery image version update allowing to specify Tags.
    /// </summary>
    public interface IWithTags  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithTags(IDictionary<string,string> tags);
    }

    /// <summary>
    /// The stage of the gallery image version update allowing to specify end of life of the version.
    /// </summary>
    public interface IWithEndOfLifeDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies end of life date of the image version.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of this gallery image.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithEndOfLifeDate(DateTime endOfLifeDate);
    }

    /// <summary>
    /// The stage of the gallery image version definition allowing to specify whether this
    /// version should be a candidate version to be considered when VM is deployed with 'latest'
    /// as version of the image.
    /// </summary>
    public interface IWithExcludeFromLatest  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that this version is not a candidate to consider as latest.
        /// </summary>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithExcludedFromLatest();

        /// <summary>
        /// Specifies that this version is a candidate to consider as latest.
        /// </summary>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IUpdate WithoutExcludedFromLatest();
    }

    /// <summary>
    /// The template for a gallery image version update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IWithAvailableRegion,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IWithEndOfLifeDate,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IWithExcludeFromLatest,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update.IWithTags
    {

    }
}