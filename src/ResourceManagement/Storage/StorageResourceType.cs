// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    /// <summary>
    /// Storage service resource types.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuU3RvcmFnZVJlc291cmNlVHlwZQ==
    public class StorageResourceType : ExpandableStringEnum<StorageResourceType>, IBeta
    {
        /// <summary>
        /// Static value storageAccounts for StorageResourceType.
        /// </summary>
        public static readonly StorageResourceType Storage_Accounts = Parse("storageAccounts");
    }
}
