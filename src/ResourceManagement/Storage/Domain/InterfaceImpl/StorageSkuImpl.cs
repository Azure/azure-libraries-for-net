// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    internal partial class StorageSkuImpl 
    {
        /// <summary>
        /// Gets the storage account sku type if the sku describes a storage account resource.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountSkuType Microsoft.Azure.Management.Storage.Fluent.IStorageSku.StorageAccountSku
        {
            get
            {
                return this.StorageAccountSku();
            }
        }

        /// <summary>
        /// Gets the sku name.
        /// </summary>
        Models.SkuName Microsoft.Azure.Management.Storage.Fluent.IStorageSku.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the capability information in the specified sku.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SKUCapability> Microsoft.Azure.Management.Storage.Fluent.IStorageSku.Capabilities
        {
            get
            {
                return this.Capabilities();
            }
        }

        /// <summary>
        /// Gets the storage resource type that the sku describes.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageResourceType Microsoft.Azure.Management.Storage.Fluent.IStorageSku.ResourceType
        {
            get
            {
                return this.ResourceType();
            }
        }

        /// <summary>
        /// Gets restrictions because of which sku cannot be used.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.Restriction> Microsoft.Azure.Management.Storage.Fluent.IStorageSku.Restrictions
        {
            get
            {
                return this.Restrictions();
            }
        }

        /// <summary>
        /// Gets the regions that the sku is available.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Microsoft.Azure.Management.Storage.Fluent.IStorageSku.Regions
        {
            get
            {
                return this.Regions();
            }
        }

        /// <summary>
        /// Gets the sku tier.
        /// </summary>
        Models.SkuTier? Microsoft.Azure.Management.Storage.Fluent.IStorageSku.Tier
        {
            get
            {
                return this.Tier();
            }
        }

        /// <summary>
        /// Gets the storage account kind if the sku describes a storage account resource.
        /// </summary>
        Models.Kind? Microsoft.Azure.Management.Storage.Fluent.IStorageSku.StorageAccountKind
        {
            get
            {
                return this.StorageAccountKind();
            }
        }
    }
}