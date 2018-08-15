// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

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
        CreatableResources<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob,Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJobImpl,Microsoft.Azure.Management.BatchAI.Fluent.Models.JobInner>,
        IBatchAIJobs
    {
        private BatchAIExperimentImpl experiment;
        private IBatchAIWorkspace workspace;
        internal BatchAIJobsImpl(BatchAIExperimentImpl experiment)
        {
            this.workspace = experiment.Workspace();
            this.experiment = experiment;
        }

        public BatchAIJobImpl Define(string name)
        {
            return WrapModel(name);
        }

        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob> List()
        {
            return Extensions.Synchronize(() => ListAsync());
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IBatchAIJob>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerJobs = await Inner.ListByExperimentAsync(workspace.ResourceGroupName, workspace.Name, experiment.Name, cancellationToken: cancellationToken);
            var result = innerJobs.Select((innerJob) => WrapModel(innerJob));
            return PagedCollection<IBatchAIJob, JobInner>.CreateFromEnumerable(result);
        }

        protected async Task<JobInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Inner.GetAsync(workspace.ResourceGroupName, workspace.Name, experiment.Name, name, cancellationToken);
        }

        public override void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            var name = ResourceUtils.NameFromResourceId(id);
            await Inner.DeleteAsync(workspace.ResourceGroupName, workspace.Name, experiment.Name, name,
                cancellationToken);
        }

        protected override BatchAIJobImpl WrapModel(string name)
        {
            return new BatchAIJobImpl(name, experiment, new JobInner(name: name));
        }

        protected override IBatchAIJob WrapModel(JobInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new BatchAIJobImpl(inner.Name, experiment, inner);
        }
        

        public BatchAIExperimentImpl Parent()
        {
            return experiment;
        }

        public IBatchAIJob GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        Task<IBatchAIJob> ISupportsGettingByNameAsync<IBatchAIJob>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IBatchAIJob> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return WrapModel(await Inner.GetAsync(workspace.ResourceGroupName, workspace.Name, experiment.Name, name, cancellationToken));
        }

        public IBatchAIJob GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IBatchAIJob> GetByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
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

        public IJobsOperations Inner { get; }
        public BatchAIManager Manager { get; }

        IBatchAIExperiment IHasParent<IBatchAIExperiment>.Parent
        {
            get { throw new System.NotImplementedException(); }
        }

        public IEnumerable<IBatchAIJob> List(int maxResults)
        {
            throw new System.NotImplementedException();
        }
    }
}