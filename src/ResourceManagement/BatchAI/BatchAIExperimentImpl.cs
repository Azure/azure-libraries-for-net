// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BatchAIExperimentImpl  :
        Creatable<IBatchAIExperiment,
            ExperimentInner,
            BatchAIExperimentImpl,
            IHasId>,
        IBatchAIExperiment,
        BatchAIExperiment.Definition.IDefinition
    {
        private IBatchAIJobs jobs;
        private BatchAIWorkspaceImpl workspace;

        internal  BatchAIExperimentImpl(string name, BatchAIWorkspaceImpl workspace, ExperimentInner innerObject) : base(name, innerObject)
        {
            this.workspace = workspace;
            jobs = new BatchAIJobsImpl(this);
        }

        protected override async Task<Microsoft.Azure.Management.BatchAI.Fluent.Models.ExperimentInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await workspace.Manager.Inner.Experiments.GetAsync(workspace.ResourceGroupName, workspace.Name, this.Name, cancellationToken);
        }

        public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await workspace.Manager.Inner.Experiments.CreateAsync(workspace.ResourceGroupName, workspace.Name, Name, cancellationToken));
            return this;
        }

        public DateTime CreationTime()
        {
            return Inner.CreationTime.GetValueOrDefault();
        }

        public string Id()
        {
            return Inner.Id;
        }

        public bool IsInCreateMode()
        {
            return Inner.Id == null;
        }

        public IBatchAIJobs Jobs()
        {
            return jobs;
        }

        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        public DateTime ProvisioningStateTransitionTime()
        {
            return Inner.ProvisioningStateTransitionTime.GetValueOrDefault();
        }

        public IBatchAIWorkspace Workspace()
        {
            return workspace;
        }

        string IHasId.Id => Inner.Id;
        IBatchAIManager IHasManager<IBatchAIManager>.Manager => workspace.Manager;
    }
}