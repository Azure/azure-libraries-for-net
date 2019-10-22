// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Type representing LegalHold.
    /// </summary>
    public interface ILegalHold  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<LegalHoldInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.StorageManager>
    {

        /// <summary>
        /// Gets the hasLegalHold value.
        /// </summary>
        bool? HasLegalHold { get; }

        /// <summary>
        /// Gets the tags value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Tags { get; }
    }
}