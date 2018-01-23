// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to Batch AI file servers management API in Azure.
    /// </summary>
    public interface IBatchAIFileServers  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        ISupportsCreating<BatchAIFileServer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        ISupportsBatchDeletion,
        IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.IFileServersOperations>
    {
    }
}