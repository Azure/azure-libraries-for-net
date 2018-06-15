// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// The implementation of Jobs.
    /// </summary>
    public partial class BatchAIJobsImpl :
        GroupableResources<
            IBatchAIJob,
            BatchAIJobImpl,
            JobInner,
            IJobsOperations,
            IBatchAIManager>,
        IBatchAIJobs
    {
        internal BatchAIJobsImpl(IBatchAIManager batchAIManager)
            : base(batchAIManager.Inner.Jobs, batchAIManager)
        {
        }

        public BatchAIJobImpl Define(string name)
        {
            return WrapModel(name);
        }


        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(resourceGroupName, name);
        }

        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob> List()
        {
            return Extensions.Synchronize(() => ListAsync());
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IBatchAIJob>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerJobs = await Inner.ListAsync(cancellationToken: cancellationToken);
            var result = innerJobs.Select((innerJob) => WrapModel(innerJob));
            return PagedCollection<IBatchAIJob, JobInner>.CreateFromEnumerable(result);
        }

        protected async Task<JobInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.GetAsync(resourceGroupName, name);
        }

        protected override BatchAIJobImpl WrapModel(string name)
        {
            return new BatchAIJobImpl(name, new JobInner(name: name), this.Manager);
        }

        protected override IBatchAIJob WrapModel(JobInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new BatchAIJobImpl(inner.Name, inner, this.Manager);
        }

       protected override async Task<JobInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }
    }
}