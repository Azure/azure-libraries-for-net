// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class MetricDefinitionsImpl
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <return>List of metric definitions.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitions.ListByResource(string resourceId, string metricnamespace = default(string))
        {
            return this.ListByResource(resourceId, metricnamespace);
        }

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <return>A representation of the deferred computation of Metric Definitions list call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition>> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitions.ListByResourceAsync(string resourceId, CancellationToken cancellationToken)
        {
            return await this.ListByResourceAsync(resourceId, cancellationToken);
        }

        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition>> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitions.ListByResourceAsync(string resourceId, string metricnamespace, CancellationToken cancellationToken)
        {
            return await this.ListByResourceAsync(resourceId, metricnamespace, cancellationToken);
        }
    }
}