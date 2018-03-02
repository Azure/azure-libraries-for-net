// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.EventHub.Fluent.Models
{
    /// <summary>
    /// Defines values for SkuTier.
    /// </summary>
    public class SkuTier : ExpandableStringEnum<SkuTier>
    {
        public static readonly SkuTier Basic = Parse("Basic");
        public static readonly SkuTier Standard = Parse("Standard");
    }
}
