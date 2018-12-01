// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of collection of Azure registry task runs.
    /// </summary>
    public interface IRegistryTaskRuns  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets The function that begins the steps to schedule a run.
        /// </summary>
        /// <summary>
        /// Gets the next step in the execution of a run.
        /// </summary>
        RegistryTaskRun.Definition.IBlankFromRuns ScheduleRun();

        /// <summary>
        /// The function that cancels a task run.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        void Cancel(string rgName, string acrName, string runId);

        /// <summary>
        /// The function that cancels a task run asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>Handle to the request.</return>
        Task CancelAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The function that returns the URI to the task run logs.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>The URI to the task run logs.</return>
        string GetLogSasUrl(string rgName, string acrName, string runId);

        /// <summary>
        /// The function that returns the URI to the task run logs asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="runId">The id of the task run.</param>
        /// <return>The URI to the task run logs.</return>
        Task<string> GetLogSasUrlAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The function that lists the RegistryTaskRun instances in a registry asynch.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <return>The list of RegistryTaskRun instances.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> ListByRegistry(string rgName, string acrName);

        /// <summary>
        /// The function that lists the RegistryTaskRun instances in a registry asynchronously.
        /// </summary>
        /// <param name="rgName">The resource group of the parent registry.</param>
        /// <param name="acrName">The name of the parent registry.</param>
        /// <param name="loadAllPages">whether to load all pages or not</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns></returns>
        Task<IPagedCollection<IRegistryTaskRun>> ListByRegistryAsync(string rgName, string acrName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}