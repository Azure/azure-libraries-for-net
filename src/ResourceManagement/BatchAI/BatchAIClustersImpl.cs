// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for BatchAIClusters.
    /// </summary>
    public partial class BatchAIClustersImpl :
        CreatableResources<
            IBatchAICluster,
            BatchAIClusterImpl,
            ClusterInner>,
        IBatchAIClusters
    {
        private BatchAIWorkspaceImpl workspace;

        internal  BatchAIClustersImpl(BatchAIWorkspaceImpl workspace)
        {
            this.workspace = workspace;
        }

        public BatchAIClusterImpl Define(string name)
        {
            return WrapModel(name);
        }

        public override void DeleteById(string id)
        {
            ResourceId resourceId = ResourceId.FromString(id);
            Extensions.Synchronize(() => Inner.DeleteAsync(resourceId.ResourceGroupName, workspace.Name, resourceId.Name));
        }

        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            ResourceId resourceId = ResourceId.FromString(id);
            await Inner.DeleteAsync(resourceId.ResourceGroupName, workspace.Name, resourceId.Name, cancellationToken);
        }

        protected override BatchAIClusterImpl WrapModel(string name)
        {
            ClusterInner inner = new ClusterInner();
            return new BatchAIClusterImpl(name, workspace, inner);
        }

        protected override IBatchAICluster WrapModel(ClusterInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new BatchAIClusterImpl(inner.Name, workspace, inner);
        }
        
        public IClustersOperations Inner => workspace.Manager.Inner.Clusters;

        public IEnumerable<IBatchAICluster> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListByWorkspaceNextAsync(link))));
        }

        public async Task<IPagedCollection<IBatchAICluster>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = new CancellationToken())
        {
            return await PagedCollection<IBatchAICluster, ClusterInner>.LoadPage(
                async (cancellation) => await Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name, cancellationToken: cancellation),
                Inner.ListByWorkspaceNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IBatchAICluster GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public async Task<IBatchAICluster> GetByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            var resourceId = ResourceId.FromString(id);
            return WrapModel(await Inner.GetAsync(workspace.ResourceGroupName, workspace.Name, resourceId.Name, cancellationToken));
        }

        public IBatchAICluster GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(workspace.ResourceGroupName, workspace.Name, name, cancellationToken));
        }

        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));
        }

        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            await Inner.DeleteAsync(workspace.ResourceGroupName, workspace.Name, name, cancellationToken);
        }

        public IBatchAIManager Manager => workspace.Manager;
        public IBatchAIWorkspace Parent => workspace;
    }
}