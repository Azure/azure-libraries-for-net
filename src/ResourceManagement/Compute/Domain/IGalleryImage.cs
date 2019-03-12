// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure gallery image.
    /// A gallery image resource is a container for multiple versions of the same image.
    /// </summary>
    public interface IGalleryImage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.GalleryImageInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<GalleryImage.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>
    {

        /// <summary>
        /// Gets the description of the image.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets a description of features not supported by the image.
        /// </summary>
        Models.Disallowed Disallowed { get; }

        /// <summary>
        /// Gets the date indicating image's end of life.
        /// </summary>
        System.DateTime? EndOfLifeDate { get; }

        /// <summary>
        /// Gets the image eula.
        /// </summary>
        string Eula { get; }

        /// <summary>
        /// Gets the ARM id of the image.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets an identifier describing publisher, offer and sku of the image.
        /// </summary>
        Models.GalleryImageIdentifier Identifier { get; }

        /// <summary>
        /// Gets the location of the image.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the image name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the OS state of the image.
        /// </summary>
        Models.OperatingSystemStateTypes? OSState { get; }

        /// <summary>
        /// Gets the image OS type.
        /// </summary>
        Models.OperatingSystemTypes? OSType { get; }

        /// <summary>
        /// Gets the uri to image privacy statement.
        /// </summary>
        string PrivacyStatementUri { get; }

        /// <summary>
        /// Gets the provisioningState of image resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the purchasePlan of the image.
        /// </summary>
        Models.ImagePurchasePlan PurchasePlan { get; }

        /// <summary>
        /// Gets the value describing recommended configuration for a virtual machine
        /// based on this image.
        /// </summary>
        Models.RecommendedMachineConfiguration RecommendedVirtualMachineConfiguration { get; }

        /// <summary>
        /// Gets the uri to the image release note.
        /// </summary>
        string ReleaseNoteUri { get; }

        /// <summary>
        /// Gets the tags associated with the image.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Tags { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the disk types not supported by the image.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.DiskSkuTypes> UnsupportedDiskTypes { get; }

        /// <summary>
        /// Retrieves information about an image version.
        /// </summary>
        /// <param name="versionName">The name of the image version.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The image version.</return>
        Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion GetVersion(string versionName);

        /// <summary>
        /// Retrieves information about an image version.
        /// </summary>
        /// <param name="versionName">The name of the image.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetVersionAsync(string versionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List image versions.
        /// </summary>
        /// <return>The list of image versions.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> ListVersions();

        /// <summary>
        /// List image versions.
        /// </summary>
        /// <return>The observable for the request.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}