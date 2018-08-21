// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.BatchAI.Fluent.Models.HasMountVolumes.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
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
    public partial class BatchAIClusterImpl :
        CreatableUpdatable<IBatchAICluster,
            ClusterInner,
            BatchAIClusterImpl,
            IHasId,
            BatchAICluster.Update.IUpdate>,
        IBatchAICluster,
        IDefinition,
        IUpdate,
        IHasMountVolumes
    {
        private BatchAIWorkspaceImpl workspace; 

        private ClusterCreateParameters createParameters = new ClusterCreateParameters();
        private ScaleSettings scaleSettings = new ScaleSettings();

        public Models.ResourceId Subnet()
        {
            return Inner.Subnet;
        }

        public ScaleSettings ScaleSettings()
        {
            return Inner.ScaleSettings;
        }

        public void AttachAzureFileShare(IAzureFileShare azureFileShare)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureFileShares == null)
            {
                mountVolumes.AzureFileShares = new List<AzureFileShareReference>();
            }
            mountVolumes.AzureFileShares.Add(azureFileShare.Inner);
        }
        
        ///GENMHASH:79E7B5F57E7A55B8022A9F81FB2832E4:7C1531DE4EE7AADF3A9DE8D5322ED09E
        private VirtualMachineConfiguration EnsureVirtualMachineConfiguration()
        {
            if (createParameters.VirtualMachineConfiguration == null) {
                createParameters.VirtualMachineConfiguration = new VirtualMachineConfiguration();
            }
            return createParameters.VirtualMachineConfiguration;
        }

        public string AdminUserName()
        {
            return Inner.UserAccountSettings.AdminUserName;
        }

        public AzureFileShareImpl<BatchAICluster.Definition.IWithCreate> DefineAzureFileShare()
        {
            return new AzureFileShareImpl<BatchAICluster.Definition.IWithCreate>(new AzureFileShareReference(), this);
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
            if (IsInCreateMode())
            {
                EnsureScaleSettings().Manual = manualScaleSettings;
            }
            else
            {
                scaleSettings = new ScaleSettings
                {
                    Manual = manualScaleSettings
                };
            }
            return this;
        }

        private bool IsInCreateMode()
        {
            return Inner.Id == null;
        }

        ///GENMHASH:8ECD7B3C8DA59F0FC5E941AF96916A64:F82EF884290F848890E0C2FC1B043762
        public BatchAIClusterImpl WithAppInsightsComponentId(string resoureId)
        {
            if (EnsureNodeSetup().PerformanceCountersSettings == null) {
                createParameters.NodeSetup.PerformanceCountersSettings = new PerformanceCountersSettings();
            }
            createParameters.NodeSetup.PerformanceCountersSettings.AppInsightsReference = new AppInsightsReference(new Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId(resoureId));
            return this;
        }

        public BatchAIClusterImpl WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
        {
            ManualScaleSettings manualScaleSettings = new ManualScaleSettings()
            {
                TargetNodeCount = targetNodeCount,
                NodeDeallocationOption = deallocationOption
            };
            if (IsInCreateMode())
            {
                EnsureScaleSettings().Manual = manualScaleSettings;
            }
            else
            {
                scaleSettings = new ScaleSettings
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
            if (createParameters.UserAccountSettings == null)
            {
                createParameters.UserAccountSettings = new UserAccountSettings();
            }
            return createParameters.UserAccountSettings;
        }

        private MountVolumes EnsureMountVolumes()
        {
            if (EnsureNodeSetup().MountVolumes == null)
            {
                createParameters.NodeSetup.MountVolumes = new MountVolumes();
            }
            return createParameters.NodeSetup.MountVolumes;
        }

        protected override async Task<Microsoft.Azure.Management.BatchAI.Fluent.Models.ClusterInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await workspace.Manager.Inner.Clusters.GetAsync(workspace.ResourceGroupName, workspace.Name, Name, cancellationToken);
        }

        public NodeSetup NodeSetup()
        {
            return Inner.NodeSetup;
        }

        internal BatchAIClusterImpl(string name, BatchAIWorkspaceImpl workspace, ClusterInner innerObject)
            : base(name, innerObject)
        {
            this.workspace = workspace;
        }

        public BatchAIClusterImpl WithSshPublicKey(string sshPublicKey)
        {
            EnsureUserAccountSettings().AdminUserSshPublicKey = sshPublicKey;
            return this;
        }

        ///GENMHASH:83F0E69474676B2E7534F18D11A21891:A1C24922FD14BD9574624199DCC78B5A
        public BatchAIClusterImpl WithInstrumentationKey(string instrumentationKey)
        {
            createParameters.NodeSetup.PerformanceCountersSettings.AppInsightsReference.InstrumentationKey = instrumentationKey;
            return this;
        }

        ///GENMHASH:1E540FB781C7D754D9A77BF3CEB2BB62:B3B08191E1FBBF1EE9EAF5570BA0E690
        public BatchAIClusterImpl WithInstrumentationKeySecretReference(string keyVaultId, string secretUrl)
        {
            createParameters.NodeSetup.PerformanceCountersSettings.AppInsightsReference.InstrumentationKeySecretReference = 
                new KeyVaultSecretReference(new Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId(keyVaultId), secretUrl);
            return this;
        }

        public void AttachFileServer(IFileServer fileServer)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.FileServers == null)
            {
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
            SetInner(await Manager.Inner.Clusters.UpdateAsync(workspace.ResourceGroupName, workspace.Name, Name, scaleSettings, cancellationToken));
            return this;
        }

        public BatchAIClusterImpl WithLowPriority()
        {
            createParameters.VmPriority = VmPriority.Lowpriority;
            return this;
        }

        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:8E1100FECC94D8D02A007E94A2829ADE
        public BatchAIClusterImpl WithSubnet(string subnetId)
        {
            createParameters.Subnet = new Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId(subnetId);
            return this;
        }

        ///GENMHASH:9047F7688B1B60794F60BC930616198C:611CA1FC53B66F8126B3A71A8F7A964F
        public BatchAIClusterImpl WithSubnet(string networkId, string subnetName)
        {
            createParameters.Subnet = new Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId(networkId + "/subnets/" + subnetName);
            return this;
        }
        
        public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster> CreateResourceAsync(CancellationToken cancellationToken)
        {
            if (IsInCreateMode())
            {
                SetInner(await Manager.Inner.Clusters.CreateAsync(workspace.ResourceGroupName, workspace.Name, Name, createParameters, cancellationToken));
            }
            else
            {
                await UpdateResourceAsync(cancellationToken);
            }
            return this;
        }

        public AzureBlobFileSystemImpl<BatchAICluster.Definition.IWithCreate> DefineAzureBlobFileSystem()
        {
            return new AzureBlobFileSystemImpl<BatchAICluster.Definition.IWithCreate>(new AzureBlobFileSystemReference(), this);
        }

        public FileServerImpl<BatchAICluster.Definition.IWithCreate> DefineFileServer()
        {
            return new FileServerImpl<BatchAICluster.Definition.IWithCreate>(new FileServerReference(), this);
        }

        public AllocationState AllocationState()
        {
            return Inner.AllocationState;
        }

        private ScaleSettings EnsureScaleSettings()
        {
            if (createParameters.ScaleSettings == null)
            {
                createParameters.ScaleSettings = new ScaleSettings();
            }
            return createParameters.ScaleSettings;
        }

        public BatchAIClusterImpl WithUnmanagedFileSystem(string mountCommand, string relativeMountPath)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.UnmanagedFileSystems == null)
            {
                mountVolumes.UnmanagedFileSystems = new List<UnmanagedFileSystemReference>();
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

        public void AttachAzureBlobFileSystem(IAzureBlobFileSystem azureBlobFileSystem)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureBlobFileSystems == null)
            {
                mountVolumes.AzureBlobFileSystems = new List<AzureBlobFileSystemReference>();
            }
            mountVolumes.AzureBlobFileSystems.Add(azureBlobFileSystem.Inner);
        }

        ///GENMHASH:8FD3D042874B91534262149F9B16CC76:7707C8D2DF092BD275DF1CCA4461871C
        public BatchAIClusterImpl WithVirtualMachineImage(string publisher, string offer, string sku, string version)
        {
            EnsureVirtualMachineConfiguration().ImageReference = new ImageReference(publisher, offer, sku, version: version);
            return this;
        }


        ///GENMHASH:B166B7BCC6015427AA49700F74E26B41:DDEF7A7581AF3154679A44E30F9482F0
        public BatchAIClusterImpl WithVirtualMachineImage(string publisher, string offer, string sku)
        {
            EnsureVirtualMachineConfiguration().ImageReference = new ImageReference(publisher, offer, sku);
            return this;
        }

        ///GENMHASH:330BEF56BC4BAABD4D60D9E7BBB003BD:F677D454D78B6BC6CECA1BCA3E282E27
        public BatchAIClusterImpl WithVirtualMachineImageId(string virtualMachineImageId, string publisher, string offer, string sku)
        {
            EnsureVirtualMachineConfiguration().ImageReference =
                new ImageReference(publisher, offer, sku, virtualMachineImageId: virtualMachineImageId);
            return this;
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
            if (IsInCreateMode())
            {
                EnsureScaleSettings().AutoScale = autoScaleSettings;
            }
            else
            {
                scaleSettings = new ScaleSettings()
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
            if (IsInCreateMode())
            {
                EnsureScaleSettings().AutoScale = autoScaleSettings;
            }
            else
            {
                scaleSettings = new ScaleSettings()
                {
                    AutoScale = autoScaleSettings
                };
            }
            return this;
        }

        private NodeSetup EnsureNodeSetup()
        {
            if (createParameters.NodeSetup == null)
            {
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

        string IHasId.Id => Inner.Id;

        public IBatchAIManager Manager => workspace.Manager;
    }
}