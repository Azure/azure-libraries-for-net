// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Update;
using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BatchAIWorkspaceImpl  :
        GroupableResource<IBatchAIWorkspace,
            WorkspaceInner,
            BatchAIWorkspaceImpl,
            BatchAIManager,
            BatchAIWorkspace.Definition.IBlank,
            BatchAIWorkspace.Definition.IWithCreate,
            BatchAIWorkspace.Definition.IWithCreate,
            BatchAIWorkspace.Update.IUpdate>,
        IBatchAIWorkspace,
        IDefinition,
        IUpdate
    {
        private IBatchAIClusters clusters;
        private IBatchAIExperiments experiments;
        private IBatchAIFileServers fileServers;

        internal BatchAIWorkspaceImpl(string name, WorkspaceInner innerObject, BatchAIManager manager) : base(name, innerObject, manager)
        {
        }

        protected override async Task<Microsoft.Azure.Management.BatchAI.Fluent.Models.WorkspaceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Workspaces.GetAsync(this.ResourceGroupName, this.Name);
        }

        public IBatchAIClusters Clusters()
        {
            if (clusters == null) {
                clusters = new BatchAIClustersImpl(this);
            }
            return clusters;
        }

         public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            WorkspaceCreateParameters createParameters = new WorkspaceCreateParameters();
            createParameters.Location = this.RegionName;
            createParameters.Tags = this.Inner.Tags;
            SetInner(await this.Manager.Inner.Workspaces.CreateAsync(ResourceGroupName, Name, createParameters));
            
            return this;
        }

        public DateTime CreationTime()
        {
            return Inner.CreationTime.GetValueOrDefault();
        }

        public IBatchAIExperiments Experiments()
        {
            if (experiments == null) {
                experiments = new BatchAIExperimentsImpl(this);
            }
            return experiments;
        }

        public IBatchAIFileServers FileServers()
        {
            if (fileServers == null) {
                fileServers = new BatchAIFileServersImpl(this);
            }
            return fileServers;
        }

        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        public DateTime ProvisioningStateTransitionTime()
        {
            return Inner.ProvisioningStateTransitionTime.GetValueOrDefault();
        }

        public async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await this.Manager.Inner.Workspaces.UpdateAsync(ResourceGroupName, Name, this.Inner.Tags, cancellationToken));

            return this;
        }

        public IBatchAIManager Manager { get; }
        public IWithGroup WithRegion(string regionName)
        {
            throw new NotImplementedException();
        }

        public IWithGroup WithRegion(Region region)
        {
            throw new NotImplementedException();
        }
    }
}