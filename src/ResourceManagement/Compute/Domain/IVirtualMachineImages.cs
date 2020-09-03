// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to virtual machine image management API.
    /// </summary>
    public interface IVirtualMachineImages :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>,
        ISupportsGettingById<IVirtualMachineImage>
    {

        /// <summary>
        /// Gets entry point to virtual machine image publishers.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Publishers { get; }

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetImage(Region region, string publisherName, string offerName, string skuName, string version);

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetImage(string region, string publisherName, string offerName, string skuName, string version);

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>

        Task<IVirtualMachineImage> GetImageAsync(Region region, string publisherName, string offerName, string skuName, string version, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>

        Task<IVirtualMachineImage> GetImageAsync(string region, string publisherName, string offerName, string skuName, string version, CancellationToken cancellationToken = default(CancellationToken));
    }
}