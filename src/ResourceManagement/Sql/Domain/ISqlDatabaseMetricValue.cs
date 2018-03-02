// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Response containing the Azure SQL Database metric value.
    /// </summary>
    public interface ISqlDatabaseMetricValue  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MetricValue>
    {
        /// <summary>
        /// Gets the average value of the metric.
        /// </summary>
        double Average { get; }

        /// <summary>
        /// Gets the total value of the metric.
        /// </summary>
        double Total { get; }

        /// <summary>
        /// Gets the number of values for the metric.
        /// </summary>
        double Count { get; }

        /// <summary>
        /// Gets the max value of the metric.
        /// </summary>
        double Maximum { get; }

        /// <summary>
        /// Gets the min value of the metric.
        /// </summary>
        double Minimum { get; }

        /// <summary>
        /// Gets the metric timestamp (ISO-8601 format).
        /// </summary>
        System.DateTime? Timestamp { get; }
    }
}