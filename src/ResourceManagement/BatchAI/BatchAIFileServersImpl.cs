// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
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
    public partial class BatchAIFileServersImpl  :
        TopLevelModifiableResources<
            IBatchAIFileServer,
            BatchAIFileServerImpl,
            FileServerInner,
            IFileServersOperations,
            IBatchAIManager>,
        IBatchAIFileServers
    {
        internal  BatchAIFileServersImpl(IBatchAIManager batchAIManager)
            : base(batchAIManager.Inner.FileServers, batchAIManager)
        {
        }

        public BatchAIFileServerImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override BatchAIFileServerImpl WrapModel(string name)
        {
            FileServerInner inner = new FileServerInner();
            return new BatchAIFileServerImpl(name, inner, Manager);
        }

        protected override  IBatchAIFileServer WrapModel(FileServerInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new BatchAIFileServerImpl(inner.Name, inner, this.Manager);
        }

        protected override async Task<IPage<FileServerInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken:cancellationToken);
        }

        protected override async Task<IPage<FileServerInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<FileServerInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken:cancellationToken);
        }

        protected override async Task<IPage<FileServerInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<FileServerInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }
    }
}