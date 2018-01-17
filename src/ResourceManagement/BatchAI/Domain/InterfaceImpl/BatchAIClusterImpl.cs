// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    using System.Collections.Generic;
    using System;

    public partial class BatchAIClusterImpl 
    {
        /// <summary>
        /// Gets Begins the definition of setup task.
        /// </summary>
        /// <summary>
        /// Gets the first stage of the setup task definition.
        /// </summary>
        NodeSetupTask.Definition.IBlank<BatchAICluster.Definition.IWithCreate> BatchAICluster.Definition.IWithSetupTask.DefineSetupTask()
        {
            return this.DefineSetupTask() as NodeSetupTask.Definition.IBlank<BatchAICluster.Definition.IWithCreate>;
        }

        /// <param name="password">Admin user password (linux only).</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithScaleSettings BatchAICluster.Definition.IWithUserCredentials.WithPassword(string password)
        {
            return this.WithPassword(password) as BatchAICluster.Definition.IWithScaleSettings;
        }

        /// <param name="sshPublicKey">SSH public keys used to authenticate with linux based VMs.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithScaleSettings BatchAICluster.Definition.IWithUserCredentials.WithSshPublicKey(string sshPublicKey)
        {
            return this.WithSshPublicKey(sshPublicKey) as BatchAICluster.Definition.IWithScaleSettings;
        }

        /// <param name="userName">The name of the administrator account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithUserCredentials BatchAICluster.Definition.IWithUserName.WithUserName(string userName)
        {
            return this.WithUserName(userName) as BatchAICluster.Definition.IWithUserCredentials;
        }

        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        BatchAICluster.Definition.IWithUserName BatchAICluster.Definition.IWithVMSize.WithVMSize(string vmSize)
        {
            return this.WithVMSize(vmSize) as BatchAICluster.Definition.IWithUserName;
        }

        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithAutoScale(int minimumNodeCount, int maximumNodeCount)
        {
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount) as BatchAICluster.Update.IUpdate;
        }

        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <param name="initialNodeCount">
        /// The number of compute nodes to allocate on cluster creation.
        /// Note that this value is used only during cluster creation.
        /// </param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithAutoScale(int minimumNodeCount, int maximumNodeCount, int initialNodeCount)
        {
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount, initialNodeCount) as BatchAICluster.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithManualScale(int targetNodeCount)
        {
            return this.WithManualScale(targetNodeCount) as BatchAICluster.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
        {
            return this.WithManualScale(targetNodeCount, deallocationOption) as BatchAICluster.Update.IUpdate;
        }

        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithAutoScale(int minimumNodeCount, int maximumNodeCount)
        {
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount) as BatchAICluster.Definition.IWithCreate;
        }

        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <param name="initialNodeCount">
        /// The number of compute nodes to allocate on cluster creation.
        /// Note that this value is used only during cluster creation.
        /// </param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithAutoScale(int minimumNodeCount, int maximumNodeCount, int initialNodeCount)
        {
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount, initialNodeCount) as BatchAICluster.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithManualScale(int targetNodeCount)
        {
            return this.WithManualScale(targetNodeCount) as BatchAICluster.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
        {
            return this.WithManualScale(targetNodeCount, deallocationOption) as BatchAICluster.Definition.IWithCreate;
        }

        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithVMPriority.WithLowPriority()
        {
            return this.WithLowPriority() as BatchAICluster.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets Begins the definition of Azure blob file system reference to be mounted on each cluster node.
        /// </summary>
        /// <summary>
        /// Gets the first stage of Azure blob file system reference definition.
        /// </summary>
        AzureBlobFileSystem.Definition.IBlank<BatchAICluster.Definition.IWithCreate> BatchAICluster.Definition.IWithMountVolumes.DefineAzureBlobFileSystem()
        {
            return this.DefineAzureBlobFileSystem() as AzureBlobFileSystem.Definition.IBlank<BatchAICluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the details of the file system to mount on the compute cluster nodes.
        /// </summary>
        /// <param name="mountCommand">Command used to mount the unmanaged file system.</param>
        /// <param name="relativeMountPath">The relative path on the compute cluster node where the file system will be mounted.</param>
        /// <return>The next stage of Batch AI cluster definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithMountVolumes.WithUnmanagedFileSystem(string mountCommand, string relativeMountPath)
        {
            return this.WithUnmanagedFileSystem(mountCommand, relativeMountPath) as BatchAICluster.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets Begins the definition of Azure file server reference.
        /// </summary>
        /// <summary>
        /// Gets the first stage of file server reference definition.
        /// </summary>
        FileServer.Definition.IBlank<BatchAICluster.Definition.IWithCreate> BatchAICluster.Definition.IWithMountVolumes.DefineFileServer()
        {
            return this.DefineFileServer() as FileServer.Definition.IBlank<BatchAICluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets Begins the definition of Azure file share reference to be mounted on each cluster node.
        /// </summary>
        /// <summary>
        /// Gets the first stage of file share reference definition.
        /// </summary>
        AzureFileShare.Definition.IBlank<BatchAICluster.Definition.IWithCreate> BatchAICluster.Definition.IWithMountVolumes.DefineAzureFileShare()
        {
            return this.DefineAzureFileShare() as AzureFileShare.Definition.IBlank<BatchAICluster.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets settings for OS image and mounted data volumes.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.VirtualMachineConfiguration Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.VirtualMachineConfiguration
        {
            get
            {
                return this.VirtualMachineConfiguration() as Microsoft.Azure.Management.BatchAI.Fluent.Models.VirtualMachineConfiguration;
            }
        }

        /// <summary>
        /// Gets the provisioning state transition time of the cluster.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.ProvisioningStateTransitionTime
        {
            get
            {
                return this.ProvisioningStateTransitionTime();
            }
        }

        /// <summary>
        /// Gets All virtual machines in a cluster are the same size. For information
        /// about available VM sizes for clusters using images from the Virtual
        /// Machines Marketplace (see Sizes for Virtual Machines (Linux) or Sizes
        /// for Virtual Machines (Windows). Batch AI service supports all Azure VM
        /// sizes except STANDARD_A0 and those with premium storage (STANDARD_GS,
        /// STANDARD_DS, and STANDARD_DSV2 series).
        /// </summary>
        /// <summary>
        /// Gets the size of the virtual machines in the cluster.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.VMSize
        {
            get
            {
                return this.VMSize();
            }
        }

        /// <summary>
        /// Gets the number of compute nodes currently assigned to the cluster.
        /// </summary>
        int Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.CurrentNodeCount
        {
            get
            {
                return this.CurrentNodeCount();
            }
        }

        /// <summary>
        /// Gets counts of various node states on the cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeStateCounts Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.NodeStateCounts
        {
            get
            {
                return this.NodeStateCounts() as Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeStateCounts;
            }
        }

        /// <summary>
        /// Gets administrator account name for compute nodes.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.AdminUserName
        {
            get
            {
                return this.AdminUserName();
            }
        }

        /// <summary>
        /// Gets the time at which the cluster entered its current allocation state.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.AllocationStateTransitionTime
        {
            get
            {
                return this.AllocationStateTransitionTime();
            }
        }

        /// <summary>
        /// Gets desired scale for the Cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ScaleSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.ScaleSettings
        {
            get
            {
                return this.ScaleSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ScaleSettings;
            }
        }

        /// <summary>
        /// Gets Indicates whether the cluster is resizing.
        /// </summary>
        /// <summary>
        /// Gets cluster allocation state.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.AllocationState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.AllocationState
        {
            get
            {
                return this.AllocationState();
            }
        }

        /// <summary>
        /// Gets all the errors encountered by various compute nodes during node setup.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.BatchAIError> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.Errors
        {
            get
            {
                return this.Errors() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.BatchAIError>;
            }
        }

        /// <summary>
        /// Gets the entry point to Batch AI jobs management API for this cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.Jobs
        {
            get
            {
                return this.Jobs() as Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs;
            }
        }

        /// <summary>
        /// Gets the provisioning state of the cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the creation time of the cluster.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <summary>
        /// Gets the identifier of the subnet.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.Subnet
        {
            get
            {
                return this.Subnet() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId;
            }
        }

        /// <summary>
        /// Gets The default value is dedicated. The node can get preempted while the
        /// task is running if lowpriority is choosen. This is best suited if the
        /// workload is checkpointing and can be restarted.
        /// </summary>
        /// <summary>
        /// Gets virtual machine priority status.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.VmPriority Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.VMPriority
        {
            get
            {
                return this.VMPriority();
            }
        }

        /// <summary>
        /// Gets setup to be done on all compute nodes in the Cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeSetup Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.NodeSetup
        {
            get
            {
                return this.NodeSetup() as Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeSetup;
            }
        }
    }
}