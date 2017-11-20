// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update
{
    using Microsoft.Azure.Management.ContainerService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the container service update allowing to enable or disable diagnostics.
    /// </summary>
    public interface IWithDiagnostics 
    {
        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IUpdate WithDiagnostics();

        /// <summary>
        /// Disables diagnostics.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IUpdate WithoutDiagnostics();
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerService.Fluent.IContainerService>,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IWithUpdateAgentPoolCount,
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IWithDiagnostics
    {
    }

    /// <summary>
    /// The stage of the container service update allowing to specify the number of agents in the specified pool.
    /// </summary>
    public interface IWithUpdateAgentPoolCount 
    {
        /// <summary>
        /// Updates the agent pool virtual machine count.
        /// </summary>
        /// <param name="agentCount">The number of agents (virtual machines) to host docker containers.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update.IUpdate WithAgentVirtualMachineCount(int agentCount);
    }
}