// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Entry point for Batch AI file server management API in Azure.
    /// </summary>
    public interface IBatchAIFileServer  :
        IBeta,
        IGroupableResource<IBatchAIManager,FileServerInner>,
        IRefreshable<IBatchAIFileServer>
    {
    }
}