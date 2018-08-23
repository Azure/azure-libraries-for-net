// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to virtual network gateways management API in Azure.
    /// </summary>
    public interface IBatchAIWorkspaces  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<BatchAIWorkspace.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IWorkspacesOperations>
    {

    }
}