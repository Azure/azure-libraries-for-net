// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to Batch AI experiments management API in Azure.
    /// </summary>
    public interface IBatchAIExperiments  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IExperimentsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>
    {

    }
}