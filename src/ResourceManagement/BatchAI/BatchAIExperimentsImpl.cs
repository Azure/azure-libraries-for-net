// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Experiments.
    /// </summary>
    public partial class BatchAIExperimentsImpl  :
        CreatableResources<IBatchAIExperiment,
            BatchAIExperimentImpl, ExperimentInner>,
        IBatchAIExperiments
    {
        private BatchAIWorkspaceImpl workspace;

        internal  BatchAIExperimentsImpl(BatchAIWorkspaceImpl workspace)
        {
            this.workspace = workspace;
        }

        protected override BatchAIExperimentImpl WrapModel(string name)
        {
            ExperimentInner inner = new ExperimentInner();
            return new BatchAIExperimentImpl(name, workspace, inner);
        }

        protected override IBatchAIExperiment WrapModel(ExperimentInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new BatchAIExperimentImpl(inner.Name, workspace, inner);
        }

        public override void DeleteById(string id)
        {
            ResourceId resourceId = ResourceId.FromString(id);
            Extensions.Synchronize(() => workspace.Manager.Inner.Experiments.DeleteAsync(resourceId.ResourceGroupName, workspace.Name, resourceId.Name));
        }

        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);
            await Inner.DeleteAsync(resourceId.ResourceGroupName, workspace.Name, resourceId.Name, cancellationToken);
        }

        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));

        }

        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(workspace.ResourceGroupName, workspace.Name, name, cancellationToken);
        }

        public IBatchAIExperiment GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);
            return WrapModel(await Inner.GetAsync(resourceId.ResourceGroupName, workspace.Name, resourceId.Name, cancellationToken));
        }

        public IBatchAIExperiment GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(workspace.ResourceGroupName, workspace.Name, name, cancellationToken));
        }

        public IExperimentsOperations Inner
        {
            get
            {
                return workspace.Manager.Inner.Experiments;
            }
        }

        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListByWorkspaceNextAsync(link))));
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IBatchAIExperiment>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IBatchAIExperiment, ExperimentInner>.LoadPage(
                async (cancellation) => await Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name, cancellationToken: cancellation),
                Inner.ListByWorkspaceNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IBatchAIWorkspace Parent()
        {
            return workspace;
        }

        public IBatchAIManager Manager => workspace.Manager;

        IBatchAIWorkspace IHasParent<IBatchAIWorkspace>.Parent => workspace;
    }
}