// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for DiskCreateOptionTypes.
    /// </summary>
    public class DiskCreateOptionTypes : ExpandableStringEnum<DiskCreateOptionTypes>
    {
        public static readonly DiskCreateOptionTypes Empty = Parse("Empty");
        public static readonly DiskCreateOptionTypes Attach = Parse("Attach");
        public static readonly DiskCreateOptionTypes FromImage = Parse("FromImage");
        public static readonly DiskCreateOptionTypes Import = Parse("Import");
        public static readonly DiskCreateOptionTypes Copy = Parse("Copy");
        public static readonly DiskCreateOptionTypes Restore = Parse("Restore");
    }
}
