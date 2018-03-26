// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for DiskCreateOption.
    /// </summary>
    public class DiskCreateOption : ExpandableStringEnum<DiskCreateOption>
    {
        public static readonly DiskCreateOption Empty = Parse("Empty");
        public static readonly DiskCreateOption Attach = Parse("Attach");
        public static readonly DiskCreateOption FromImage = Parse("FromImage");
        public static readonly DiskCreateOption Import = Parse("Import");
        public static readonly DiskCreateOption Copy = Parse("Copy");
        public static readonly DiskCreateOption Restore = Parse("Restore");
    }
}
