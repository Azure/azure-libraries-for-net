// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for Architecture.
    /// </summary>
    public partial class Architecture : ExpandableStringEnum<Architecture>, IBeta
    {
        /// <summary>
        /// Static value Amd64 for Architecture.
        /// </summary>
        public static readonly Architecture Amd64 = Parse("amd64");

        /// <summary>
        /// Static value X86 for Architecture.
        /// </summary>
        public static readonly Architecture X86 = Parse("x86");

        /// <summary>
        /// Static value Arm for Architecture.
        /// </summary>
        public static readonly Architecture Arm = Parse("arm");
    }
}
