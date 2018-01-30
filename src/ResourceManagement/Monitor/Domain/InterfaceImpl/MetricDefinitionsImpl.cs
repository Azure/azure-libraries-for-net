// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class MetricDefinitionsImpl 
    {
        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <return>List of metric definitions.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitions.ListByResource(string resourceId)
        {
            return this.ListByResource(resourceId) as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition>;
        }

        /// <summary>
        /// Lists Metric Definitions for a given resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <return>A representation of the deferred computation of Metric Definitions list call.</return>
        async Task<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinitions.ListByResourceAsync(string resourceId, CancellationToken cancellationToken)
        {
            return await this.ListByResourceAsync(resourceId, cancellationToken) as Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager() as MonitorManager;
            }
        }
    }
}