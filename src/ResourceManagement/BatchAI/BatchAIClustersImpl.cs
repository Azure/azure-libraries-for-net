// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for BatchAIClusters.
    /// </summary>
    public partial class BatchAIClustersImpl  :
        TopLevelModifiableResources<
            IBatchAICluster,
            BatchAIClusterImpl,
            ClusterInner,
            IClustersOperations,
            IBatchAIManager>,
        IBatchAIClusters
    {
        internal  BatchAIClustersImpl(BatchAIManager batchAIManager)
            : base(batchAIManager.Inner.Clusters, batchAIManager)
        {
        }

        public BatchAIClusterImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override BatchAIClusterImpl WrapModel(string name)
        {
            ClusterInner inner = new ClusterInner();
            return new BatchAIClusterImpl(name, inner, Manager);
        }

        protected override IBatchAICluster WrapModel(ClusterInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new BatchAIClusterImpl(inner.Name, inner, Manager);
        }

        protected override async Task<ClusterInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override async Task<IPage<ClusterInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken:cancellationToken);
        }

        protected override async Task<IPage<ClusterInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<ClusterInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken:cancellationToken);
        }

        protected override async Task<IPage<ClusterInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}