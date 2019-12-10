// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GalleryImageVersionImpl
    {
        /// <summary>
        /// Gets the date indicating image version's end of life.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.EndOfLifeDate
        {
            get
            {
                return this.EndOfLifeDate();
            }
        }

        /// <summary>
        /// Gets true if the image version is excluded from considering as a
        /// candidate when VM is created with 'latest' image version, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.IsExcludedFromLatest
        {
            get
            {
                return this.IsExcludedFromLatest();
            }
        }

        /// <summary>
        /// Gets the default location of the image version.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.Location
        {
            get
            {
                return this.Location();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IComputeManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }


        /// <summary>
        /// Gets the provisioningState of image version resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the publishingProfile configuration of the image version.
        /// </summary>
        Models.GalleryImageVersionPublishingProfile Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.PublishingProfile
        {
            get
            {
                return this.PublishingProfile();
            }
        }

        /// <summary>
        /// Gets the replicationStatus of image version in published regions.
        /// </summary>
        Models.ReplicationStatus Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.ReplicationStatus
        {
            get
            {
                return this.ReplicationStatus();
            }
        }

        /// <summary>
        /// Gets the image version storageProfile describing OS and data disks.
        /// </summary>
        Models.GalleryImageVersionStorageProfile Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.StorageProfile
        {
            get
            {
                return this.StorageProfile();
            }
        }

        /// <summary>
        /// Gets the tags associated with the image version.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies a region in which image version needs to be available.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="replicaCount">The replica count in the region.</param>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithAvailableRegion.WithRegionAvailability(Region region, int replicaCount)
        {
            return this.WithRegionAvailability(region, replicaCount);
        }

        /// <summary>
        /// Specifies a region in which image version needs to be available.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="replicaCount">The replica count in the region.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithAvailableRegion.WithRegionAvailability(Region region, int replicaCount)
        {
            return this.WithRegionAvailability(region, replicaCount);
        }

        /// <summary>
        /// Specifies list of regions in which image version needs to be available.
        /// </summary>
        /// <param name="regions">The target region list.</param>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithAvailableRegion.WithRegionAvailability(IList<TargetRegion> regions)
        {
            return this.WithRegionAvailability(regions);
        }

        /// <summary>
        /// Specifies list of regions in which image version needs to be available.
        /// </summary>
        /// <param name="regions">The target region list.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithAvailableRegion.WithRegionAvailability(IList<TargetRegion> regions)
        {
            return this.WithRegionAvailability(regions);
        }

        /// <summary>
        /// Specifies end of life date of the image version.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of this gallery image.</param>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithEndOfLifeDate.WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            return this.WithEndOfLifeDate(endOfLifeDate);
        }

        /// <summary>
        /// Specifies end of life date of the image version.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life date.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithEndOfLifeDate.WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            return this.WithEndOfLifeDate(endOfLifeDate);
        }

        /// <summary>
        /// Specifies that this version is not a candidate to consider as latest.
        /// </summary>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithExcludeFromLatest.WithExcludedFromLatest()
        {
            return this.WithExcludedFromLatest();
        }

        /// <summary>
        /// Specifies that this version is not a candidate to consider as latest.
        /// </summary>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithExcludeFromLatest.WithExcludedFromLatest()
        {
            return this.WithExcludedFromLatest();
        }

        /// <summary>
        /// Specifies the image container to hold this image version.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <param name="galleryImageName">The name of the gallery image.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithLocation GalleryImageVersion.Definition.IWithImage.WithExistingImage(string resourceGroupName, string galleryName, string galleryImageName)
        {
            return this.WithExistingImage(resourceGroupName, galleryName, galleryImageName);
        }

        /// <summary>
        /// Specifies the default location for the image version.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithSource GalleryImageVersion.Definition.IWithLocation.WithLocation(string location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithSource GalleryImageVersion.Definition.IWithLocation.WithLocation(Region location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// Specifies that an image version should be removed from an existing region serving it.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithAvailableRegion.WithoutRegionAvailability(Region region)
        {
            return this.WithoutRegionAvailability(region);
        }

        /// <summary>
        /// Specifies that this version is a candidate to consider as latest.
        /// </summary>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithExcludeFromLatest.WithoutExcludedFromLatest()
        {
            return this.WithoutExcludedFromLatest();
        }

        /// <summary>
        /// Specifies that the provided custom image needs to be used as source of the image version.
        /// </summary>
        /// <param name="customImageId">The ARM id of the custom image.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithSource.WithSourceCustomImage(string customImageId)
        {
            return this.WithSourceCustomImage(customImageId);
        }

        /// <summary>
        /// Specifies that the provided custom image needs to be used as source of the image version.
        /// </summary>
        /// <param name="customImage">The custom image.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithSource.WithSourceCustomImage(IVirtualMachineCustomImage customImage)
        {
            return this.WithSourceCustomImage(customImage);
        }

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next update stage.</return>
        GalleryImageVersion.Update.IUpdate GalleryImageVersion.Update.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">The resource tags.</param>
        /// <return>The next definition stage.</return>
        GalleryImageVersion.Definition.IWithCreate GalleryImageVersion.Definition.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }
    }
}