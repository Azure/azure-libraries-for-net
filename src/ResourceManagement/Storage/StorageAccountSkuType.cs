// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    public class StorageAccountSkuType : IBeta
    {
        /// <summary>
        /// Static value Standard_LRS for StorageAccountSkuType.
        /// </summary>
        public static readonly StorageAccountSkuType Standard_LRS = new StorageAccountSkuType(SkuName.StandardLRS);
        /// <summary>
        /// Static value Standard_GRS for StorageAccountSkuType.
        /// </summary>
        public static readonly StorageAccountSkuType Standard_GRS = new StorageAccountSkuType(SkuName.StandardGRS);
        /// <summary>
        /// Static value Standard_RAGRS for StorageAccountSkuType.
        /// </summary>
        public static readonly StorageAccountSkuType Standard_RAGRS = new StorageAccountSkuType(SkuName.StandardRAGRS);
        /// <summary>
        /// Static value Standard_ZRS for StorageAccountSkuType.
        /// </summary>
        public static readonly StorageAccountSkuType Standard_ZRS = new StorageAccountSkuType(SkuName.StandardZRS);
        /// <summary>
        /// Static value Premium_LRS for StorageAccountSkuType.
        /// </summary>
        public static readonly StorageAccountSkuType Premium_LRS = new StorageAccountSkuType(SkuName.PremiumLRS);

        private SkuName name;

        /// <summary>
        /// The storage account sku name.
        /// </summary>
        public SkuName Name
        {
            get
            {
                return this.name;
            }
        }


        /// <summary>
        /// Creates StorageAccountSkuType from sku name.
        /// </summary>
        /// <param name="name">the sku name</param>
        /// <returns>StorageAccountSkuType</returns>
        public static StorageAccountSkuType FromSkuName(SkuName name)
        {
            return new StorageAccountSkuType(name);
        }

        /// <summary>
        /// Creates StorageAccountSkuType.
        /// </summary>
        /// <param name="name">the sku name</param>
        private StorageAccountSkuType(SkuName name)
        {
            this.name = name;
        }
    }
}
