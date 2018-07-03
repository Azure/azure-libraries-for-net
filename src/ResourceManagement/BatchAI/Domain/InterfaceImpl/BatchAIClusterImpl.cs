// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.BatchAI.Fluent.Models.HasMountVolumes.Definition;

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
            return this.DefineSetupTask();
        }

        /// <param name="password">Admin user password (linux only).</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithScaleSettings BatchAICluster.Definition.IWithUserCredentials.WithPassword(string password)
        {
            return this.WithPassword(password);
        }

        /// <param name="sshPublicKey">SSH public keys used to authenticate with linux based VMs.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithScaleSettings BatchAICluster.Definition.IWithUserCredentials.WithSshPublicKey(string sshPublicKey)
        {
            return this.WithSshPublicKey(sshPublicKey);
        }

        /// <param name="userName">The name of the administrator account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithUserCredentials BatchAICluster.Definition.IWithUserName.WithUserName(string userName)
        {
            return this.WithUserName(userName);
        }

        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        BatchAICluster.Definition.IWithUserName BatchAICluster.Definition.IWithVMSize.WithVMSize(string vmSize)
        {
            return this.WithVMSize(vmSize);
        }

        /// <param name="resoureId">Azure Application Insights component resource id.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithAppInsightsKey BatchAICluster.Definition.IWithAppInsightsResourceId.WithAppInsightsComponentId(string resoureId)
        {
            return this.WithAppInsightsComponentId(resoureId);
        }

        /// <param name="instrumentationKey">Value of the Azure Application Insights instrumentation key.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithAppInsightsKey.WithInstrumentationKey(string instrumentationKey)
        {
            return this.WithInstrumentationKey(instrumentationKey);
        }

        /// <summary>
        /// Specifies KeyVault Store and Secret which contains the value for the instrumentation key.
        /// </summary>
        /// <param name="keyVaultId">Fully qualified resource Id for the Key Vault.</param>
        /// <param name="secretUrl">The URL referencing a secret in a Key Vault.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithAppInsightsKey.WithInstrumentationKeySecretReference(string keyVaultId, string secretUrl)
        {
            return this.WithInstrumentationKeySecretReference(keyVaultId, secretUrl);
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
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount);
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
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount, initialNodeCount);
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithManualScale(int targetNodeCount)
        {
            return this.WithManualScale(targetNodeCount);
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the update.</return>
        BatchAICluster.Update.IUpdate BatchAICluster.Update.IWithScaleSettings.WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
        {
            return this.WithManualScale(targetNodeCount, deallocationOption);
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
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount);
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
            return this.WithAutoScale(minimumNodeCount, maximumNodeCount, initialNodeCount);
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithManualScale(int targetNodeCount)
        {
            return this.WithManualScale(targetNodeCount);
        }

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithScaleSettings.WithManualScale(int targetNodeCount, DeallocationOption deallocationOption)
        {
            return this.WithManualScale(targetNodeCount, deallocationOption);
        }

        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithVMPriority.WithLowPriority()
        {
            return this.WithLowPriority();
        }

        /// <summary>
        /// Gets Begins the definition of Azure blob file system reference to be mounted on each cluster node.
        /// </summary>
        /// <summary>
        /// Gets the first stage of Azure blob file system reference definition.
        /// </summary>
        AzureBlobFileSystem.Definition.IBlank<BatchAICluster.Definition.IWithCreate> IWithMountVolumes<IWithCreate>.DefineAzureBlobFileSystem()
        {
            return this.DefineAzureBlobFileSystem();
        }

        /// <summary>
        /// Specifies the details of the file system to mount on the compute cluster nodes.
        /// </summary>
        /// <param name="mountCommand">Command used to mount the unmanaged file system.</param>
        /// <param name="relativeMountPath">The relative path on the compute cluster node where the file system will be mounted.</param>
        /// <return>The next stage of Batch AI cluster definition.</return>
        BatchAICluster.Definition.IWithCreate IWithMountVolumes<IWithCreate>.WithUnmanagedFileSystem(string mountCommand, string relativeMountPath)
        {
            return this.WithUnmanagedFileSystem(mountCommand, relativeMountPath);
        }

        /// <summary>
        /// Gets Begins the definition of Azure file server reference.
        /// </summary>
        /// <summary>
        /// Gets the first stage of file server reference definition.
        /// </summary>
        FileServer.Definition.IBlank<BatchAICluster.Definition.IWithCreate> IWithMountVolumes<IWithCreate>.DefineFileServer()
        {
            return this.DefineFileServer();
        }

        /// <param name="subnetId">Identifier of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithSubnet.WithSubnet(string subnetId)
        {
            return this.WithSubnet(subnetId);
        }

        /// <param name="networkId">Identifier of the network.</param>
        /// <param name="subnetName">Subnet name.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithSubnet.WithSubnet(string networkId, string subnetName)
        {
            return this.WithSubnet(networkId, subnetName);
        }


        /// <summary>
        /// Gets Begins the definition of Azure file share reference to be mounted on each cluster node.
        /// </summary>
        /// <summary>
        /// Gets the first stage of file share reference definition.
        /// </summary>
        AzureFileShare.Definition.IBlank<BatchAICluster.Definition.IWithCreate> IWithMountVolumes<BatchAICluster.Definition.IWithCreate>.DefineAzureFileShare()
        {
            return this.DefineAzureFileShare();
        }
        
        /// <summary>
        /// Specifies virtual machine image.
        /// </summary>
        /// <param name="publisher">Publisher of the image.</param>
        /// <param name="offer">Offer of the image.</param>
        /// <param name="sku">Sku of the image.</param>
        /// <param name="version">Version of the image.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithVirtualMachineImage.
            WithVirtualMachineImage(string publisher, string offer, string sku, string version)
        {
            return this.WithVirtualMachineImage(publisher, offer, sku,
                version);
        }

        /// <summary>
        /// Specifies virtual machine image.
        /// </summary>
        /// <param name="publisher">Publisher of the image.</param>
        /// <param name="offer">Offer of the image.</param>
        /// <param name="sku">Sku of the image.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithVirtualMachineImage.
            WithVirtualMachineImage(string publisher, string offer, string sku)
        {
            return this.WithVirtualMachineImage(publisher, offer, sku);
        }

        /// <summary>
        /// Computes nodes of the cluster will be created using this custom image. This is of the form
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/images/{imageName}.
        /// The virtual machine image must be in the same region and subscription as
        /// the cluster. For information about the firewall settings for the Batch
        /// node agent to communicate with the Batch service see
        /// https://docs.microsoft.com/en-us/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration.
        /// Note, you need to provide publisher, offer and sku of the base OS image
        /// of which the custom image has been derived from.
        /// </summary>
        /// <param name="virtualMachineImageId">The ARM resource identifier of the virtual machine image.</param>
        /// <param name="publisher">Publisher of the image.</param>
        /// <param name="offer">Offer of the image.</param>
        /// <param name="sku">Sku of the image.</param>
        /// <return>The next stage of the definition.</return>
        BatchAICluster.Definition.IWithCreate BatchAICluster.Definition.IWithVirtualMachineImage.WithVirtualMachineImageId(string virtualMachineImageId, string publisher, string offer, string sku)
        {
            return this.WithVirtualMachineImageId(virtualMachineImageId, publisher, offer, sku);
        }

        /// <summary>
        /// Gets settings for OS image and mounted data volumes.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.VirtualMachineConfiguration Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster.VirtualMachineConfiguration
        {
            get
            {
                return this.VirtualMachineConfiguration();
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
                return this.NodeStateCounts();
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
                return this.ScaleSettings();
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
                return this.Errors();
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
                return this.Subnet();
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
                return this.NodeSetup();
            }
        }
    }
}