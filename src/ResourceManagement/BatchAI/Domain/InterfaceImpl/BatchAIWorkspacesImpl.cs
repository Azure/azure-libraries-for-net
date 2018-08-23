// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BatchAIWorkspacesImpl 
    {
        BatchAIWorkspace.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<BatchAIWorkspace.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken);
        }
    }
}