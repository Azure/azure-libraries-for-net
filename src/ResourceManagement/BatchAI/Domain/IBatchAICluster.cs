// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Entry point for Batch AI cluster management API in Azure.
    /// </summary>
    public interface IBatchAICluster  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager,Microsoft.Azure.Management.BatchAI.Fluent.Models.ClusterInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<BatchAICluster.Update.IUpdate>
    {
        /// <summary>
        /// Gets the identifier of the subnet.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Subnet { get; }

        /// <summary>
        /// Gets desired scale for the Cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ScaleSettings ScaleSettings { get; }

        /// <summary>
        /// Gets administrator account name for compute nodes.
        /// </summary>
        string AdminUserName { get; }

        /// <summary>
        /// Gets the creation time of the cluster.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Gets Indicates whether the cluster is resizing.
        /// </summary>
        /// <summary>
        /// Gets cluster allocation state.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.AllocationState AllocationState { get; }

        /// <summary>
        /// Gets counts of various node states on the cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeStateCounts NodeStateCounts { get; }

        /// <summary>
        /// Gets the entry point to Batch AI jobs management API for this cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs Jobs { get; }

        /// <summary>
        /// Gets the provisioning state transition time of the cluster.
        /// </summary>
        System.DateTime ProvisioningStateTransitionTime { get; }

        /// <summary>
        /// Gets the provisioning state of the cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the number of compute nodes currently assigned to the cluster.
        /// </summary>
        int CurrentNodeCount { get; }

        /// <summary>
        /// Gets setup to be done on all compute nodes in the Cluster.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.NodeSetup NodeSetup { get; }

        /// <summary>
        /// Gets settings for OS image and mounted data volumes.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get; }

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
        string VMSize { get; }

        /// <summary>
        /// Gets The default value is dedicated. The node can get preempted while the
        /// task is running if lowpriority is choosen. This is best suited if the
        /// workload is checkpointing and can be restarted.
        /// </summary>
        /// <summary>
        /// Gets virtual machine priority status.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.VmPriority VMPriority { get; }

        /// <summary>
        /// Gets the time at which the cluster entered its current allocation state.
        /// </summary>
        System.DateTime AllocationStateTransitionTime { get; }

        /// <summary>
        /// Gets all the errors encountered by various compute nodes during node setup.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.BatchAIError> Errors { get; }
    }
}