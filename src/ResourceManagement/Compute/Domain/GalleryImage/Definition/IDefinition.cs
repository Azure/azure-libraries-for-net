// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the gallery image definition allowing to specify recommended
    /// configuration for the virtual machine.
    /// </summary>
    public interface IWithRecommendedVMConfiguration  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies recommended configuration for the virtual machine based on the image.
        /// </summary>
        /// <param name="recommendedConfig">The recommended configuration.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedConfigurationForVirtualMachine(RecommendedMachineConfiguration recommendedConfig);

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedCPUsCountForVirtualMachine(int minCount, int maxCount);

        /// <summary>
        /// Specifies the recommended maximum number of virtual CUPs for the virtual machine bases on this image.
        /// </summary>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedMaximumCPUsCountForVirtualMachine(int maxCount);

        /// <summary>
        /// Specifies the recommended maximum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedMaximumMemoryForVirtualMachine(int maxMB);

        /// <summary>
        /// Specifies the recommended memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedMemoryForVirtualMachine(int minMB, int maxMB);

        /// <summary>
        /// Specifies the recommended minimum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedMinimumCPUsCountForVirtualMachine(int minCount);

        /// <summary>
        /// Specifies the recommended minimum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithRecommendedMinimumMemoryForVirtualMachine(int minMB);
    }

    public interface IWithOsTypeAndState  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that image is a Linux image with OS state as generalized.
        /// </summary>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithGeneralizedLinux();

        /// <summary>
        /// Specifies that image is a Windows image with OS state as generalized.
        /// </summary>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithGeneralizedWindows();

        /// <summary>
        /// Specifies that image is a Linux image.
        /// </summary>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithLinux(OperatingSystemStateTypes osState);

        /// <summary>
        /// Specifies that image is a Windows image.
        /// </summary>
        /// <param name="osState">Operating system state.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithWindows(OperatingSystemStateTypes osState);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify tags.
    /// </summary>
    public interface IWithTags  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithTags(IDictionary<string,string> tags);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify location of the image.
    /// </summary>
    public interface IWithLocation  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithIdentifier WithLocation(string location);

        /// <summary>
        /// Specifies location.
        /// </summary>
        /// <param name="location">Resource location.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithIdentifier WithLocation(Region location);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify purchase plan.
    /// </summary>
    public interface IWithPurchasePlan  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies purchase plan for this image.
        /// </summary>
        /// <param name="name">Plan name.</param>
        /// <param name="publisher">Publisher name.</param>
        /// <param name="product">Product name.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithPurchasePlan(string name, string publisher, string product);

        /// <summary>
        /// Specifies purchase plan for this image.
        /// </summary>
        /// <param name="purchasePlan">The purchase plan.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithPurchasePlan(ImagePurchasePlan purchasePlan);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify parent gallery it belongs to.
    /// </summary>
    public interface IWithGallery  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the gallery in which this image resides.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="galleryName">The name of the gallery.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithLocation WithExistingGallery(string resourceGroupName, string galleryName);

        /// <summary>
        /// Specifies the gallery in which this image resides.
        /// </summary>
        /// <param name="gallery">The gallery.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithLocation WithExistingGallery(IGallery gallery);
    }

    /// <summary>
    /// The first stage of a gallery image definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithGallery
    {

    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify eula.
    /// </summary>
    public interface IWithEula  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies eula.
        /// </summary>
        /// <param name="eula">The Eula agreement for the gallery image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithEula(string eula);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify privacy statement uri.
    /// </summary>
    public interface IWithPrivacyStatementUri  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies image privacy statement uri.
        /// </summary>
        /// <param name="privacyStatementUri">The privacy statement uri.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithPrivacyStatementUri(string privacyStatementUri);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify description.
    /// </summary>
    public interface IWithDescription  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies description.
        /// </summary>
        /// <param name="description">The description of the gallery image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify settings disallowed
    /// for a virtual machine based on the image.
    /// </summary>
    public interface IWithDisallowed  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies disallowed settings.
        /// </summary>
        /// <param name="disallowed">The disallowed settings.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithDisallowed(Disallowed disallowed);

        /// <summary>
        /// Specifies the disk type not supported by the image.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithUnsupportedDiskType(DiskSkuTypes diskType);

        /// <summary>
        /// Specifies the disk types not supported by the image.
        /// </summary>
        /// <param name="diskTypes">The disk types.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithUnsupportedDiskTypes(IList<Microsoft.Azure.Management.Compute.Fluent.Models.DiskSkuTypes> diskTypes);
    }

    /// <summary>
    /// The entirety of the gallery image definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithGallery,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithLocation,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithIdentifier,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithOsTypeAndState,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify uri to release note.
    /// </summary>
    public interface IWithReleaseNoteUri  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies uri to release note.
        /// </summary>
        /// <param name="releaseNoteUri">The release note uri.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithReleaseNoteUri(string releaseNoteUri);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify end of life of the version.
    /// </summary>
    public interface IWithEndOfLifeDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies end of life date of the image.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of the gallery image.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithCreate WithEndOfLifeDate(DateTime endOfLifeDate);
    }

    /// <summary>
    /// The stage of the gallery image definition allowing to specify identifier that
    /// identifies publisher, offer and sku of the image.
    /// </summary>
    public interface IWithIdentifier  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies identifier (publisher, offer and sku) for the image.
        /// </summary>
        /// <param name="identifier">The identifier parameter value.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithOsTypeAndState WithIdentifier(GalleryImageIdentifier identifier);

        /// <summary>
        /// Specifies an identifier (publisher, offer and sku) for the image.
        /// </summary>
        /// <param name="publisher">Image publisher name.</param>
        /// <param name="offer">Image offer name.</param>
        /// <param name="sku">Image sku name.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithOsTypeAndState WithIdentifier(string publisher, string offer, string sku);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithDescription,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithDisallowed,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithEndOfLifeDate,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithEula,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithPrivacyStatementUri,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithPurchasePlan,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithRecommendedVMConfiguration,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithReleaseNoteUri,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition.IWithTags
    {

    }
}