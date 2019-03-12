// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class GalleryImageImpl 
    {
        /// <summary>
        /// Gets the description of the image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets a description of features not supported by the image.
        /// </summary>
        Models.Disallowed Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Disallowed
        {
            get
            {
                return this.Disallowed();
            }
        }

        /// <summary>
        /// Gets the date indicating image's end of life.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.EndOfLifeDate
        {
            get
            {
                return this.EndOfLifeDate();
            }
        }

        /// <summary>
        /// Gets the image eula.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Eula
        {
            get
            {
                return this.Eula();
            }
        }

        /// <summary>
        /// Gets the ARM id of the image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets an identifier describing publisher, offer and sku of the image.
        /// </summary>
        Models.GalleryImageIdentifier Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Identifier
        {
            get
            {
                return this.Identifier();
            }
        }

        /// <summary>
        /// Gets the location of the image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Location
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
        /// Gets the image name.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the OS state of the image.
        /// </summary>
        Models.OperatingSystemStateTypes? Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.OSState
        {
            get
            {
                return this.OSState();
            }
        }

        /// <summary>
        /// Gets the image OS type.
        /// </summary>
        Models.OperatingSystemTypes? Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the uri to image privacy statement.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.PrivacyStatementUri
        {
            get
            {
                return this.PrivacyStatementUri();
            }
        }

        /// <summary>
        /// Gets the provisioningState of image resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the purchasePlan of the image.
        /// </summary>
        Models.ImagePurchasePlan Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.PurchasePlan
        {
            get
            {
                return this.PurchasePlan();
            }
        }

        /// <summary>
        /// Gets the value describing recommended configuration for a virtual machine
        /// based on this image.
        /// </summary>
        Models.RecommendedMachineConfiguration Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.RecommendedVirtualMachineConfiguration
        {
            get
            {
                return this.RecommendedVirtualMachineConfiguration();
            }
        }

        /// <summary>
        /// Gets the uri to the image release note.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.ReleaseNoteUri
        {
            get
            {
                return this.ReleaseNoteUri();
            }
        }

        /// <summary>
        /// Gets the tags associated with the image.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets the disk types not supported by the image.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.DiskSkuTypes> Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.UnsupportedDiskTypes
        {
            get
            {
                return this.UnsupportedDiskTypes();
            }
        }

        /// <summary>
        /// Retrieves information about an image version.
        /// </summary>
        /// <param name="versionName">The name of the image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The image version.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.GetVersion(string versionName)
        {
            return this.GetVersion(versionName);
        }

        /// <summary>
        /// Retrieves information about an image version.
        /// </summary>
        /// <param name="versionName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.GetVersionAsync(string versionName, CancellationToken cancellationToken)
        {
            return await this.GetVersionAsync(versionName, cancellationToken);
        }

        /// <summary>
        /// List image versions.
        /// </summary>
        /// <return>The list of image versions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.ListVersions()
        {
            return this.ListVersions();
        }

        /// <summary>
        /// List image versions.
        /// </summary>
        /// <return>The observable for the request.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> Microsoft.Azure.Management.Compute.Fluent.IGalleryImage.ListVersionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListVersionsAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies description of the gallery image resource.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithDescription.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies description.
        /// </summary>
        /// <param name="description">The description of the gallery image.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithDescription.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies disallowed settings.
        /// </summary>
        /// <param name="disallowed">The disallowed settings.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithDisallowed.WithDisallowed(Disallowed disallowed)
        {
            return this.WithDisallowed(disallowed);
        }

        /// <summary>
        /// Specifies disallowed settings.
        /// </summary>
        /// <param name="disallowed">The disallowed settings.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithDisallowed.WithDisallowed(Disallowed disallowed)
        {
            return this.WithDisallowed(disallowed);
        }

        /// <summary>
        /// Specifies end of life date of the image.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of the gallery image.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithEndOfLifeDate.WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            return this.WithEndOfLifeDate(endOfLifeDate);
        }

        /// <summary>
        /// Specifies end of life date of the image.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of the gallery image.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithEndOfLifeDate.WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            return this.WithEndOfLifeDate(endOfLifeDate);
        }

        /// <summary>
        /// Specifies eula.
        /// </summary>
        /// <param name="eula">The Eula agreement for the gallery image.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithEula.WithEula(string eula)
        {
            return this.WithEula(eula);
        }

        /// <summary>
        /// Specifies eula.
        /// </summary>
        /// <param name="eula">The Eula agreement for the gallery image.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithEula.WithEula(string eula)
        {
            return this.WithEula(eula);
        }

        /// <summary>
        /// Specifies the gallery in which this image resides.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithLocation GalleryImage.Definition.IWithGallery.WithExistingGallery(string resourceGroupName, string galleryName)
        {
            return this.WithExistingGallery(resourceGroupName, galleryName);
        }

        /// <summary>
        /// Specifies the gallery in which this image resides.
        /// </summary>
        /// <param name="gallery">The gallery.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithLocation GalleryImage.Definition.IWithGallery.WithExistingGallery(IGallery gallery)
        {
            return this.WithExistingGallery(gallery);
        }

        /// <summary>
        /// Specifies that image is a Linux image with OS state as generalized.
        /// </summary>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithOsTypeAndState.WithGeneralizedLinux()
        {
            return this.WithGeneralizedLinux();
        }

        /// <summary>
        /// Specifies that image is a Windows image with OS state as generalized.
        /// </summary>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithOsTypeAndState.WithGeneralizedWindows()
        {
            return this.WithGeneralizedWindows();
        }

        /// <summary>
        /// Specifies identifier (publisher, offer and sku) for the image.
        /// </summary>
        /// <param name="identifier">The identifier parameter value.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithOsTypeAndState GalleryImage.Definition.IWithIdentifier.WithIdentifier(GalleryImageIdentifier identifier)
        {
            return this.WithIdentifier(identifier);
        }

        /// <summary>
        /// Specifies an identifier (publisher, offer and sku) for the image.
        /// </summary>
        /// <param name="publisher">Image publisher name.</param>
        /// <param name="offer">Image offer name.</param>
        /// <param name="sku">Image sku name.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithOsTypeAndState GalleryImage.Definition.IWithIdentifier.WithIdentifier(string publisher, string offer, string sku)
        {
            return this.WithIdentifier(publisher, offer, sku);
        }

        /// <summary>
        /// Specifies that image is a Linux image.
        /// </summary>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithOsTypeAndState.WithLinux(OperatingSystemStateTypes osState)
        {
            return this.WithLinux(osState);
        }

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithIdentifier GalleryImage.Definition.IWithLocation.WithLocation(string location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithIdentifier GalleryImage.Definition.IWithLocation.WithLocation(Region location)
        {
            return this.WithLocation(location);
        }

        /// <summary>
        /// Specifies osState.
        /// </summary>
        /// <param name="osState">The OS State.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithOsState.WithOsState(OperatingSystemStateTypes osState)
        {
            return this.WithOsState(osState);
        }

        /// <summary>
        /// Specifies the disk type should be removed from the unsupported disk type.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithDisallowed.WithoutUnsupportedDiskType(DiskSkuTypes diskType)
        {
            return this.WithoutUnsupportedDiskType(diskType);
        }

        /// <summary>
        /// Specifies image privacy statement uri.
        /// </summary>
        /// <param name="privacyStatementUri">The privacy statement uri.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithPrivacyStatementUri.WithPrivacyStatementUri(string privacyStatementUri)
        {
            return this.WithPrivacyStatementUri(privacyStatementUri);
        }

        /// <summary>
        /// Specifies image privacy statement uri.
        /// </summary>
        /// <param name="privacyStatementUri">The privacy statement uri.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithPrivacyStatementUri.WithPrivacyStatementUri(string privacyStatementUri)
        {
            return this.WithPrivacyStatementUri(privacyStatementUri);
        }

        /// <summary>
        /// Specifies purchase plan for this image.
        /// </summary>
        /// <param name="name">Plan name.</param>
        /// <param name="publisher">Publisher name.</param>
        /// <param name="product">Product name.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithPurchasePlan.WithPurchasePlan(string name, string publisher, string product)
        {
            return this.WithPurchasePlan(name, publisher, product);
        }

        /// <summary>
        /// Specifies purchase plan for this image.
        /// </summary>
        /// <param name="purchasePlan">The purchase plan.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithPurchasePlan.WithPurchasePlan(ImagePurchasePlan purchasePlan)
        {
            return this.WithPurchasePlan(purchasePlan);
        }

        /// <summary>
        /// Specifies recommended configuration for the virtual machine based on the image.
        /// </summary>
        /// <param name="recommendedConfig">The recommended configuration.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedConfigurationForVirtualMachine(RecommendedMachineConfiguration recommendedConfig)
        {
            return this.WithRecommendedConfigurationForVirtualMachine(recommendedConfig);
        }

        /// <summary>
        /// Specifies recommended configuration for the virtual machine based on the image.
        /// </summary>
        /// <param name="recommendedConfig">The recommended configuration.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedConfigurationForVirtualMachine(RecommendedMachineConfiguration recommendedConfig)
        {
            return this.WithRecommendedConfigurationForVirtualMachine(recommendedConfig);
        }

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedCPUsCountForVirtualMachine(int minCount, int maxCount)
        {
            return this.WithRecommendedCPUsCountForVirtualMachine(minCount, maxCount);
        }

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedCPUsCountForVirtualMachine(int minCount, int maxCount)
        {
            return this.WithRecommendedCPUsCountForVirtualMachine(minCount, maxCount);
        }

        /// <summary>
        /// Specifies the recommended maximum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedMaximumCPUsCountForVirtualMachine(int maxCount)
        {
            return this.WithRecommendedMaximumCPUsCountForVirtualMachine(maxCount);
        }

        /// <summary>
        /// Specifies the recommended maximum number of virtual CUPs for the virtual machine bases on this image.
        /// </summary>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedMaximumCPUsCountForVirtualMachine(int maxCount)
        {
            return this.WithRecommendedMaximumCPUsCountForVirtualMachine(maxCount);
        }

        /// <summary>
        /// Specifies the recommended maximum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedMaximumMemoryForVirtualMachine(int maxMB)
        {
            return this.WithRecommendedMaximumMemoryForVirtualMachine(maxMB);
        }

        /// <summary>
        /// Specifies the recommended maximum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedMaximumMemoryForVirtualMachine(int maxMB)
        {
            return this.WithRecommendedMaximumMemoryForVirtualMachine(maxMB);
        }

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedMemoryForVirtualMachine(int minMB, int maxMB)
        {
            return this.WithRecommendedMemoryForVirtualMachine(minMB, maxMB);
        }

        /// <summary>
        /// Specifies the recommended memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedMemoryForVirtualMachine(int minMB, int maxMB)
        {
            return this.WithRecommendedMemoryForVirtualMachine(minMB, maxMB);
        }

        /// <summary>
        /// Specifies the recommended minimum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedMinimumCPUsCountForVirtualMachine(int minCount)
        {
            return this.WithRecommendedMinimumCPUsCountForVirtualMachine(minCount);
        }

        /// <summary>
        /// Specifies the recommended minimum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedMinimumCPUsCountForVirtualMachine(int minCount)
        {
            return this.WithRecommendedMinimumCPUsCountForVirtualMachine(minCount);
        }

        /// <summary>
        /// Specifies the recommended minimum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithRecommendedVMConfiguration.WithRecommendedMinimumMemoryForVirtualMachine(int minMB)
        {
            return this.WithRecommendedMinimumMemoryForVirtualMachine(minMB);
        }

        /// <summary>
        /// Specifies the recommended minimum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithRecommendedVMConfiguration.WithRecommendedMinimumMemoryForVirtualMachine(int minMB)
        {
            return this.WithRecommendedMinimumMemoryForVirtualMachine(minMB);
        }

        /// <summary>
        /// Specifies release note uri.
        /// </summary>
        /// <param name="releaseNoteUri">The release note uri.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithReleaseNoteUri.WithReleaseNoteUri(string releaseNoteUri)
        {
            return this.WithReleaseNoteUri(releaseNoteUri);
        }

        /// <summary>
        /// Specifies uri to release note.
        /// </summary>
        /// <param name="releaseNoteUri">The release note uri.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithReleaseNoteUri.WithReleaseNoteUri(string releaseNoteUri)
        {
            return this.WithReleaseNoteUri(releaseNoteUri);
        }

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithTags.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithTags.WithTags(IDictionary<string,string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies the disk type not supported by the image.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithDisallowed.WithUnsupportedDiskType(DiskSkuTypes diskType)
        {
            return this.WithUnsupportedDiskType(diskType);
        }

        /// <summary>
        /// Specifies the disk type not supported by the image.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithDisallowed.WithUnsupportedDiskType(DiskSkuTypes diskType)
        {
            return this.WithUnsupportedDiskType(diskType);
        }

        /// <summary>
        /// Specifies the disk types not supported by the image.
        /// </summary>
        /// <param name="diskTypes">The disk types.</param>
        /// <return>The next update stage.</return>
        GalleryImage.Update.IUpdate GalleryImage.Update.IWithDisallowed.WithUnsupportedDiskTypes(IList<Models.DiskSkuTypes> diskTypes)
        {
            return this.WithUnsupportedDiskTypes(diskTypes);
        }

        /// <summary>
        /// Specifies the disk types not supported by the image.
        /// </summary>
        /// <param name="diskTypes">The disk types.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithDisallowed.WithUnsupportedDiskTypes(IList<Models.DiskSkuTypes> diskTypes)
        {
            return this.WithUnsupportedDiskTypes(diskTypes);
        }

        /// <summary>
        /// Specifies that image is a Windows image.
        /// </summary>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next definition stage.</return>
        GalleryImage.Definition.IWithCreate GalleryImage.Definition.IWithOsTypeAndState.WithWindows(OperatingSystemStateTypes osState)
        {
            return this.WithWindows(osState);
        }
    }
}