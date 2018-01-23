// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Client-side representation for AzureFileShareReference.
    /// </summary>
    public interface IAzureFileShare  :
        IBeta,
        IIndexable,
        IHasInner<AzureFileShareReference>
    {
    }
}