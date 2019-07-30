// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Type representing sku for an Azure storage resource.
    /// </summary>
    public interface IStorageSku  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SkuInner>
    {
        /// <summary>
        /// Gets the regions that the sku is available.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Regions { get; }

        /// <summary>
        /// Gets the capability information in the specified sku.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SKUCapability> Capabilities { get; }

        /// <summary>
        /// Gets the sku tier.
        /// </summary>
        Models.SkuTier? Tier { get; }

        /// <summary>
        /// Gets the storage account kind if the sku describes a storage account resource.
        /// </summary>
        Models.Kind? StorageAccountKind { get; }

        /// <summary>
        /// Gets the sku name.
        /// </summary>
        Models.SkuName Name { get; }

        /// <summary>
        /// Gets restrictions because of which sku cannot be used.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Restriction> Restrictions { get; }

        /// <summary>
        /// Gets the storage account sku type if the sku describes a storage account resource.
        /// </summary>
        StorageAccountSkuType StorageAccountSku { get; }

        /// <summary>
        /// Gets the storage resource type that the sku describes.
        /// </summary>
        StorageResourceType ResourceType { get; }
    }
}