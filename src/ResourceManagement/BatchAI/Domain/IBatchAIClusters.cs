// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to Batch AI cluster management API in Azure.
    /// </summary>
    public interface IBatchAIClusters  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<BatchAICluster.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.IClustersOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>
    {
    }
}