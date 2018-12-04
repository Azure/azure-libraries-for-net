// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure RegistryDockerTaskRunRequest registry task run request.
    /// </summary>
    public interface IRegistryTaskRun  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RunInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun>
    {

        /// <summary>
        /// Gets the numbers of cpu.
        /// </summary>
        int Cpu { get; }

        /// <summary>
        /// Gets the time when the run request was created.
        /// </summary>
        System.DateTime? CreateTime { get; }

        /// <summary>
        /// Gets whether archiving is enabled for the run request.
        /// </summary>
        bool IsArchiveEnabled { get; }

        /// <summary>
        /// Gets the last time the run request was updated.
        /// </summary>
        System.DateTime? LastUpdatedTime { get; }

        /// <summary>
        /// Gets the platform properties of the run request.
        /// </summary>
        Models.PlatformProperties Platform { get; }

        /// <summary>
        /// Gets the provisioning state of the run request.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the registry name of this task run request.
        /// </summary>
        string RegistryName { get; }

        /// <summary>
        /// Gets the name of the resource group for this task run request.
        /// </summary>
        string ResourceGroupName { get; }

        /// <summary>
        /// Gets the id of the run.
        /// </summary>
        string RunId { get; }

        /// <summary>
        /// Gets the run type of the run request.
        /// </summary>
        Models.RunType RunType { get; }

        /// <summary>
        /// Gets the status of the run request.
        /// </summary>
        Models.RunStatus Status { get; }

        /// <summary>
        /// Gets the name of the task in the case of a TaskRunRequest (or null if task is still queued), null in other cases.
        /// </summary>
        string TaskName { get; }
    }
}