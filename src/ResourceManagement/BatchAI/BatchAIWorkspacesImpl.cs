// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Workspaces.
    /// </summary>
    public partial class BatchAIWorkspacesImpl  :
        TopLevelModifiableResources<
            IBatchAIWorkspace, BatchAIWorkspaceImpl, WorkspaceInner, IWorkspacesOperations, IBatchAIManager>,
        IBatchAIWorkspaces
    {

        internal  BatchAIWorkspacesImpl(BatchAIManager manager) : base(manager.Inner.Workspaces, manager)
        {
        }

        protected async Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override BatchAIWorkspaceImpl WrapModel(string name)
        {
            WorkspaceInner inner = new WorkspaceInner();
            return new BatchAIWorkspaceImpl(name, inner, Manager);
        }

        public BatchAIWorkspaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override async Task<IPage<WorkspaceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListAsync(cancellationToken : cancellationToken));
        }

        protected override async Task<IPage<WorkspaceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<WorkspaceInner>>(null);
        }

        protected override Task<IPage<WorkspaceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.Workspaces.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<WorkspaceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<WorkspaceInner>>(null);
        }

       protected override async Task<WorkspaceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
       {
           return await Inner.GetAsync(groupName, name, cancellationToken);
       }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.DeleteInnerAsync(groupName, name, cancellationToken);
        }

        protected override IBatchAIWorkspace WrapModel(WorkspaceInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new BatchAIWorkspaceImpl(inner.Name, inner, this.Manager);
        }
    }
}