// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for SnapshotStorageAccountTypes.
    /// </summary>
    public class SnapshotStorageAccountTypes : ExpandableStringEnum<SnapshotStorageAccountTypes>, IBeta
    {
        public static readonly SnapshotStorageAccountTypes StandardLRS = Parse("Standard_LRS");
        public static readonly SnapshotStorageAccountTypes PremiumLRS = Parse("Premium_LRS");
        public static readonly SnapshotStorageAccountTypes StandardZRS = Parse("Standard_ZRS");
    }
}
