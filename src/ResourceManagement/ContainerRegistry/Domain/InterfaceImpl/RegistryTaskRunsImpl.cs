// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RegistryTaskRunsImpl 
    {
        /// <summary>
        /// Gets The function that begins the steps to schedule a run.
        /// </summary>
        /// <summary>
        /// Gets the next step in the execution of a run.
        /// </summary>
        RegistryTaskRun.Definition.IBlankFromRuns Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.ScheduleRun()
        {
            return this.ScheduleRun();
        }

        /// <summary>
        /// The function that cancels a task run.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        void Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.Cancel(string rgName, string acrName, string runId)
        {
 
            this.Cancel(rgName, acrName, runId);
        }

        /// <summary>
        /// The function that cancels a task run asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>Handle to the request.</return>
        async Task Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.CancelAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken)
        {
 
            await this.CancelAsync(rgName, acrName, runId, cancellationToken);
        }

        /// <summary>
        /// The function that returns the URI to the task run logs.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>The URI to the task run logs.</return>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.GetLogSasUrl(string rgName, string acrName, string runId)
        {
            return this.GetLogSasUrl(rgName, acrName, runId);
        }

        /// <summary>
        /// The function that returns the URI to the task run logs asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>The URI to the task run logs.</return>
        async Task<string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.GetLogSasUrlAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken)
        {
            return await this.GetLogSasUrlAsync(rgName, acrName, runId, cancellationToken);
        }

        /// <summary>
        /// The function that lists the RegistryTaskRun instances in a registry asynch.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <return>The list of RegistryTaskRun instances.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.ListByRegistry(string rgName, string acrName)
        {
            return this.ListByRegistry(rgName, acrName);
        }

        /// <summary>
        /// The function that lists the RegistryTaskRun instances in a registry asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <return>The list of RegistryTaskRun instances.</return>
        async Task<IPagedCollection<IRegistryTaskRun>> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRuns.ListByRegistryAsync(string rgName, string acrName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByRegistryAsync(rgName, acrName, loadAllPages, cancellationToken);
        }
    }
}