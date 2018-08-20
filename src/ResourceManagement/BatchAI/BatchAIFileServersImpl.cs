// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for BatchAIFileServers.
    /// </summary>
    public partial class BatchAIFileServersImpl :
        CreatableResources<IBatchAIFileServer,
        BatchAIFileServerImpl,
        FileServerInner>,
        IBatchAIFileServers
    {
        private BatchAIWorkspaceImpl workspace;
        internal BatchAIFileServersImpl(BatchAIWorkspaceImpl workspace)
            : base()
        {
            this.workspace = workspace;
        }

        public BatchAIFileServerImpl Define(string name)
        {
            return WrapModel(name);
        }

        public override void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        protected override BatchAIFileServerImpl WrapModel(string name)
        {
            FileServerInner inner = new FileServerInner();
            return new BatchAIFileServerImpl(name, this.workspace, inner);
        }

        protected override IBatchAIFileServer WrapModel(FileServerInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new BatchAIFileServerImpl(inner.Name, this.workspace, inner);
        }
        
        public IEnumerable<IBatchAIFileServer> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListByWorkspaceNextAsync(link))));
        }

        public async Task<IPagedCollection<IBatchAIFileServer>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = new CancellationToken())
        {
            return await PagedCollection<IBatchAIFileServer, FileServerInner>.LoadPage(
                async (cancellation) => await Inner.ListByWorkspaceAsync(workspace.ResourceGroupName, workspace.Name, cancellationToken: cancellation),
                Inner.ListByWorkspaceNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        public IBatchAIFileServer GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IBatchAIFileServer> GetByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public IBatchAIFileServer GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        Task<IBatchAIFileServer> ISupportsGettingByNameAsync<IBatchAIFileServer>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<IBatchAIFileServer> ISupportsGettingByName<IBatchAIFileServer>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByNameAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public IBatchAIManager Manager => workspace.Manager;
        public IFileServersOperations Inner => workspace.Manager.Inner.FileServers;
    }
}