// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update
{
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAICluster>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update.IWithScaleSettings
    {
    }

    public interface IWithScaleSettings 
    {
        /// <summary>
        /// If autoScale settings are specified, the system automatically scales the cluster up and down (within
        /// the supplied limits) based on the pending jobs on the cluster.
        /// </summary>
        /// <param name="minimumNodeCount">The minimum number of compute nodes the cluster can have.</param>
        /// <param name="maximumNodeCount">The maximum number of compute nodes the cluster can have.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update.IUpdate WithAutoScale(int minimumNodeCount, int maximumNodeCount);

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
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update.IUpdate WithAutoScale(int minimumNodeCount, int maximumNodeCount, int initialNodeCount);

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update.IUpdate WithManualScale(int targetNodeCount);

        /// <summary>
        /// Specifies that cluster should be scaled by manual settings.
        /// </summary>
        /// <param name="targetNodeCount">The desired number of compute nodes in the Cluster.</param>
        /// <param name="deallocationOption">Determines what to do with the job(s) running on compute node if the cluster size is decreasing. The default value is requeue.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Update.IUpdate WithManualScale(int targetNodeCount, DeallocationOption deallocationOption);
    }
}