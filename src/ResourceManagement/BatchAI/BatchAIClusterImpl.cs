// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update;
    using Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for Cluster and its create and update interfaces.
    /// </summary>
    public partial class BatchAIClusterImpl  :
        GroupableResource<
            IBatchAICluster,
            ClusterInner,
            BatchAIClusterImpl,
            IBatchAIManager,
            IWithGroup,
            IWithVMSize,
            IWithCreate,
            IUpdate
            >,
        IBatchAICluster,
        IDefinition,
        IUpdate
    {
        private ClusterCreateParametersInner createParameters;
        private ClusterUpdateParametersInner updateParameters;
        private BatchAIJobsImpl jobs;
        public Models.ResourceId Subnet()
        {
            return Inner.Subnet;
        }

        public ScaleSettings ScaleSettings()
        {
            return Inner.ScaleSettings;
        }

        internal void AttachAzureFileShare(AzureFileShareImpl azureFileShare)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureFileShares == null) {
                mountVolumes.AzureFileShares = new List<AzureFileShareReference>();
            }
            mountVolumes.AzureFileShares.Add(azureFileShare.Inner);
        }

        public string AdminUserName()
        {
            return Inner.UserAccountSettings.AdminUserName;
        }

        public AzureFileShareImpl DefineAzureFileShare()
        {
            return new AzureFileShareImpl(new AzureFileShareReference(), this);
        }

        public DateTime CreationTime()
        {
            return Inner.CreationTime.GetValueOrDefault();
        }

        public NodeStateCounts NodeStateCounts()
        {
            return Inner.NodeStateCounts;
        }

        public BatchAIClusterImpl WithManualScale(int targetNodeCount)
        {
            ManualScaleSettings manualScaleSettings = new ManualScaleSettings()
            {
                TargetNodeCount = targetNodeCount
            };
            if (IsInCreateMode) {
                EnsureScaleSettings().Manual = manualScaleSettings;
            } else {
                updateParameters.ScaleSettings = new ScaleSettings
                {
                    Manual = manualScaleSettings
                };
            }
            return this;
        }

         public BatchAIClusterImpl WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
         {
             ManualScaleSettings manualScaleSettings = new ManualScaleSettings()
             {
                 TargetNodeCount = targetNodeCount,
                 NodeDeallocationOption = deallocationOption
             };
            if (IsInCreateMode) {
                EnsureScaleSettings().Manual = manualScaleSettings;
            } else {
                updateParameters.ScaleSettings = new ScaleSettings
                {
                    Manual = manualScaleSettings
                };
            }
            return this;
        }

        public DateTime ProvisioningStateTransitionTime()
        {
            return Inner.ProvisioningStateTransitionTime.GetValueOrDefault();
        }

        private UserAccountSettings EnsureUserAccountSettings()
        {
            if (createParameters.UserAccountSettings == null) {
                createParameters.UserAccountSettings = new UserAccountSettings();
            }
            return createParameters.UserAccountSettings;
        }

        private MountVolumes EnsureMountVolumes()
        {
            if (EnsureNodeSetup().MountVolumes == null) {
                createParameters.NodeSetup.MountVolumes = new MountVolumes();
            }
            return createParameters.NodeSetup.MountVolumes;
        }

        protected override async Task<Microsoft.Azure.Management.BatchAI.Fluent.Models.ClusterInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.Clusters.GetAsync(ResourceGroupName, Name, cancellationToken);
        }

        public NodeSetup NodeSetup()
        {
            return Inner.NodeSetup;
        }

        internal  BatchAIClusterImpl(string name, ClusterInner innerObject, IBatchAIManager manager)
            : base(name,innerObject, manager)
        {
        }

        public BatchAIClusterImpl WithSshPublicKey(string sshPublicKey)
        {
            EnsureUserAccountSettings().AdminUserSshPublicKey = sshPublicKey;
            return this;
        }

        internal void AttachFileServer(IFileServer fileServer)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.FileServers == null) {
                mountVolumes.FileServers = new List<FileServerReference>();
            }
            mountVolumes.FileServers.Add(fileServer.Inner);
        }

        public BatchAIClusterImpl WithPassword(string password)
        {
            EnsureUserAccountSettings().AdminUserPassword = password;
            return this;
        }

        public string VMSize()
        {
            return Inner.VmSize;
        }

        public VmPriority VMPriority()
        {
            return Inner.VmPriority.GetValueOrDefault();
        }

        public async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            updateParameters.Tags = Inner.Tags;
            SetInner(await Manager.Inner.Clusters.UpdateAsync(ResourceGroupName, Name, updateParameters));
            return this;
        }

        public BatchAIClusterImpl WithLowPriority()
        {
            createParameters.VmPriority = VmPriority.Lowpriority;
            return this;
        }

         public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            createParameters.Location = RegionName;
            createParameters.Tags = Inner.Tags;
            SetInner(await Manager.Inner.Clusters.CreateAsync(ResourceGroupName, Name, createParameters));
            return this;
        }

        public AzureBlobFileSystemImpl DefineAzureBlobFileSystem()
        {
            return new AzureBlobFileSystemImpl(new AzureBlobFileSystemReference(), this);
        }

        public FileServerImpl DefineFileServer()
        {
            return new FileServerImpl(new FileServerReference(), this);
        }

        public AllocationState AllocationState()
        {
            return Inner.AllocationState.GetValueOrDefault();
        }

        public IBatchAIJobs Jobs()
        {
            if (jobs == null) {
                jobs = new BatchAIJobsImpl(this);
            }
            return jobs;
        }

        private ScaleSettings EnsureScaleSettings()
        {
            if (createParameters.ScaleSettings == null) {
                createParameters.ScaleSettings = new ScaleSettings();
            }
            return createParameters.ScaleSettings;
        }

        public BatchAIClusterImpl WithUnmanagedFileSystem(string mountCommand, string relativeMountPath)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.UnmanagedFileSystems == null) {
                mountVolumes.UnmanagedFileSystems= new List<UnmanagedFileSystemReference>();
            }
            mountVolumes.UnmanagedFileSystems.Add(new UnmanagedFileSystemReference()
            {
                MountCommand = mountCommand,
                RelativeMountPath = relativeMountPath
            });
            return this;
        }

        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        public int CurrentNodeCount()
        {
            return Inner.CurrentNodeCount.GetValueOrDefault();
        }

        internal BatchAIClusterImpl WithSetupTask(NodeSetupTaskImpl setupTask)
        {
            EnsureNodeSetup().SetupTask = setupTask.Inner;
            return this;
        }

        internal void AttachAzureBlobFileSystem(IAzureBlobFileSystem azureBlobFileSystem)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureBlobFileSystems == null) {
                mountVolumes.AzureBlobFileSystems = new List<AzureBlobFileSystemReference>();
            }
            mountVolumes.AzureBlobFileSystems.Add(azureBlobFileSystem.Inner);
        }

        public BatchAIClusterImpl WithVMSize(string vmSize)
        {
            createParameters.VmSize = vmSize;
            return this;
        }

        public VirtualMachineConfiguration VirtualMachineConfiguration()
        {
            return Inner.VirtualMachineConfiguration;
        }

        public BatchAIClusterImpl WithUserName(string userName)
        {
            EnsureUserAccountSettings().AdminUserName = userName;
            return this;
        }

        public BatchAIClusterImpl WithAutoScale(int minimumNodeCount, int maximumNodeCount)
        {
            AutoScaleSettings autoScaleSettings = new AutoScaleSettings()
            {
                MinimumNodeCount = minimumNodeCount,
                MaximumNodeCount = maximumNodeCount
            };
            if (IsInCreateMode) {
                EnsureScaleSettings().AutoScale = autoScaleSettings;
            } else {
                updateParameters.ScaleSettings = new ScaleSettings()
                {
                    AutoScale = autoScaleSettings
                };
            }
            return this;
        }

        public BatchAIClusterImpl WithAutoScale(int minimumNodeCount, int maximumNodeCount, int initialNodeCount)
        {
            AutoScaleSettings autoScaleSettings = new AutoScaleSettings()
            {
                MinimumNodeCount = minimumNodeCount,
                MaximumNodeCount = maximumNodeCount,
                InitialNodeCount = initialNodeCount
            };
            if (IsInCreateMode) {
                EnsureScaleSettings().AutoScale = autoScaleSettings;
            } else {
                updateParameters.ScaleSettings = new ScaleSettings()
                {
                    AutoScale = autoScaleSettings
                };
            }
            return this;
        }

        private NodeSetup EnsureNodeSetup()
        {
            if (createParameters.NodeSetup == null) {
                createParameters.NodeSetup = new NodeSetup();
            }
            return createParameters.NodeSetup;
        }

        public DateTime AllocationStateTransitionTime()
        {
            return Inner.AllocationStateTransitionTime.GetValueOrDefault();
        }

        public IReadOnlyList<BatchAIError> Errors()
        {
            return Inner.Errors.ToList();
        }

        public NodeSetupTask.Definition.IBlank<BatchAICluster.Definition.IWithCreate> DefineSetupTask()
        {
            return new NodeSetupTaskImpl(new SetupTask(), this);
        }
    }
}