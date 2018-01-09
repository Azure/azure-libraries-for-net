// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.Models
{
    /// <summary>
    /// The SKU of the storage account.
    /// </summary>
    [System.Obsolete("Sku model is deprecated use SkuType instead.")]
    public partial class Sku
    {
        /// <summary>
        /// Initializes a new instance of the Sku.
        /// </summary>
        public Sku()
        {
        }

        /// <summary>
        ///  Creates Sku.
        /// </summary>
        /// <param name="name">the sku ame</param>
        /// <param name="tier">the sku tier</param>
        public Sku(SkuName name, SkuTier? tier = default(SkuTier?))
        {
            Name = name;
            Tier = tier;
        }

        /// <summary>
        /// The SkuName.
        /// </summary>
        public SkuName Name { get; set; }

        /// <summary>
        /// The SkuTier
        /// </summary>
        public SkuTier? Tier { get; private set; }
    }
}
