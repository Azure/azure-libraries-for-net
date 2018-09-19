// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the gallery image update allowing to specify OsState.
    /// </summary>
    public interface IWithOsState  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies osState.
        /// </summary>
        /// <param name="osState">The OS State.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithOsState(OperatingSystemStateTypes osState);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify description.
    /// </summary>
    public interface IWithDescription  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies description of the gallery image resource.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify Eula.
    /// </summary>
    public interface IWithEula  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies eula.
        /// </summary>
        /// <param name="eula">The Eula agreement for the gallery image.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithEula(string eula);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify EndOfLifeDate.
    /// </summary>
    public interface IWithEndOfLifeDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies end of life date of the image.
        /// </summary>
        /// <param name="endOfLifeDate">The end of life of the gallery image.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithEndOfLifeDate(DateTime endOfLifeDate);
    }

    /// <summary>
    /// The template for a gallery image update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithDescription,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithDisallowed,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithEndOfLifeDate,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithEula,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithOsState,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithPrivacyStatementUri,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithRecommendedVMConfiguration,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithReleaseNoteUri,
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IWithTags
    {

    }

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
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedConfigurationForVirtualMachine(RecommendedMachineConfiguration recommendedConfig);

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedCPUsCountForVirtualMachine(int minCount, int maxCount);

        /// <summary>
        /// Specifies the recommended maximum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxCount">The maximum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedMaximumCPUsCountForVirtualMachine(int maxCount);

        /// <summary>
        /// Specifies the recommended maximum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedMaximumMemoryForVirtualMachine(int maxMB);

        /// <summary>
        /// Specifies the recommended virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <param name="maxMB">The maximum memory in MB.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedMemoryForVirtualMachine(int minMB, int maxMB);

        /// <summary>
        /// Specifies the recommended minimum number of virtual CUPs for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minCount">The minimum number of virtual CPUs.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedMinimumCPUsCountForVirtualMachine(int minCount);

        /// <summary>
        /// Specifies the recommended minimum memory for the virtual machine bases on the image.
        /// </summary>
        /// <param name="minMB">The minimum memory in MB.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithRecommendedMinimumMemoryForVirtualMachine(int minMB);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify settings disallowed
    /// for a virtual machine based on the image.
    /// </summary>
    public interface IWithDisallowed  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies disallowed settings.
        /// </summary>
        /// <param name="disallowed">The disallowed settings.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithDisallowed(Disallowed disallowed);

        /// <summary>
        /// Specifies the disk type should be removed from the unsupported disk type.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithoutUnsupportedDiskType(DiskSkuTypes diskType);

        /// <summary>
        /// Specifies the disk type not supported by the image.
        /// </summary>
        /// <param name="diskType">The disk type.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithUnsupportedDiskType(DiskSkuTypes diskType);

        /// <summary>
        /// Specifies the disk types not supported by the image.
        /// </summary>
        /// <param name="diskTypes">The disk types.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithUnsupportedDiskTypes(IList<Microsoft.Azure.Management.Compute.Fluent.Models.DiskSkuTypes> diskTypes);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify uri to release note.
    /// </summary>
    public interface IWithReleaseNoteUri  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies release note uri.
        /// </summary>
        /// <param name="releaseNoteUri">The release note uri.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithReleaseNoteUri(string releaseNoteUri);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify privacy statement uri.
    /// </summary>
    public interface IWithPrivacyStatementUri  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies image privacy statement uri.
        /// </summary>
        /// <param name="privacyStatementUri">The privacy statement uri.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithPrivacyStatementUri(string privacyStatementUri);
    }

    /// <summary>
    /// The stage of the gallery image update allowing to specify Tags.
    /// </summary>
    public interface IWithTags  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies tags.
        /// </summary>
        /// <param name="tags">Resource tags.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update.IUpdate WithTags(IDictionary<string,string> tags);
    }
}