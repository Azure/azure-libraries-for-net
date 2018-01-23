// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Compute resource sku tier.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuQ29tcHV0ZVNrdVRpZXI=
    public partial class ComputeSkuTier : ExpandableStringEnum<Microsoft.Azure.Management.Compute.Fluent.ComputeSkuTier>, IBeta
    {
        /// <summary>
        /// Static value Basic for ComputeSkuTier.
        /// </summary>
        public static readonly ComputeSkuTier Basic = Parse("Basic");

        /// <summary>
        /// Static value Standard for ComputeSkuTier.
        /// </summary>
        public static readonly ComputeSkuTier Standard = Parse("Standard");

        /// <summary>
        /// Static value Premium for ComputeSkuTier.
        /// </summary>
        public static readonly ComputeSkuTier Premium = Parse("Premium");
    }
}