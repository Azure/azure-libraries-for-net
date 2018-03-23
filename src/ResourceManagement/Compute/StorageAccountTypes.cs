// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    public class StorageAccountTypes : ExpandableStringEnum<StorageAccountTypes>
    {
        public static readonly StorageAccountTypes StandardLRS = Parse("Standard_LRS");
        public static readonly StorageAccountTypes PremiumLRS = Parse("Premium_LRS");
    }
}
