// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure registry task.
    /// </summary>
    public interface IRegistryTask  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.TaskInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<RegistryTask.Update.IUpdate>
    {

        /// <summary>
        /// Gets the CPU count.
        /// </summary>
        int CpuCount { get; }

        /// <summary>
        /// Gets the creation date of build task.
        /// </summary>
        System.DateTime? CreationDate { get; }

        /// <summary>
        /// Gets the parent ID of this resource.
        /// </summary>
        string ParentRegistryId { get; }

        /// <summary>
        /// Gets the build timeout settings in seconds.
        /// </summary>
        Models.PlatformProperties Platform { get; }

        /// <summary>
        /// Gets the provisioning state of the build task.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the RegistryTaskStep of the current task.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskStep RegistryTaskStep { get; }

        /// <summary>
        /// Gets the name of the resource's resource group.
        /// </summary>
        string ResourceGroupName { get; }

        /// <summary>
        /// Gets the source triggers of the task.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger> SourceTriggers { get; }

        /// <summary>
        /// Gets the current status of build task.
        /// </summary>
        Models.TaskStatus Status { get; }

        /// <summary>
        /// Gets the build timeout settings in seconds.
        /// </summary>
        int Timeout { get; }

        /// <summary>
        /// Gets the trigger of the task.
        /// </summary>
        Models.TriggerProperties Trigger { get; }
    }
}