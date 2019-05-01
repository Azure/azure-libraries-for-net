// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Storage.Fluent
{

    /// <summary>
    /// Defines values for JavaVersion.
    /// </summary>
    public class BlobTypes : ExpandableStringEnum<BlobTypes>
    {
        public static readonly BlobTypes BlockBlob = Parse("blockBlob");
        public static readonly BlobTypes Snapshot = Parse("snapshot");
    }
}
