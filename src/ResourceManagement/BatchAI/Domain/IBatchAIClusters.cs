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
        IBeta,
        ISupportsCreating<BatchAICluster.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        ISupportsBatchDeletion,
        IHasManager<IBatchAIManager>,
        IHasInner<IClustersOperations>
    {
    }
}