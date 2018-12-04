// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for Variant.
    /// </summary>
    public partial class Variant : ExpandableStringEnum<Variant>, IBeta
    {
        /// <summary>
        /// Static value v6 for Variant.
        /// </summary>
        public static readonly Variant V6 = Parse("v6");

        /// <summary>
        /// Static value v7 for Variant.
        /// </summary>
        public static readonly Variant V7 = Parse("v7");

        /// <summary>
        /// Static value v8 for Variant.
        /// </summary>
        public static readonly Variant V8 = Parse("v8");
    }
}
