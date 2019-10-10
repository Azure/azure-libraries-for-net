// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for Monitor Metric Definitions API.
    /// </summary>
    public interface IMetricDefinitions :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitionsOperations>
    {

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="metricnamespace">Metric namespace to query metric definitions for.</param>
        /// <return>List of metric definitions.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> ListByResource(string resourceId, string metricnamespace = default(string));

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <return>A representation of the deferred computation of Metric Definitions list call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition>> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="metricnamespace">Metric namespace to query metric definitions for.</param>
        /// <return>A representation of the deferred computation of Metric Definitions list call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition>> ListByResourceAsync(string resourceId, string metricnamespace, CancellationToken cancellationToken = default(CancellationToken));
    }
}