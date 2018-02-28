// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Response containing the Azure SQL Database metric.
    /// </summary>
    public interface ISqlDatabaseMetric  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.Metric>
    {
        /// <summary>
        /// Gets the time grain.
        /// </summary>
        string TimeGrain { get; }

        /// <summary>
        /// Gets the metric's unit type.
        /// </summary>
        Models.UnitType Unit { get; }

        /// <summary>
        /// Gets the metric name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        System.DateTime? StartTime { get; }

        /// <summary>
        /// Gets the end time.
        /// </summary>
        System.DateTime? EndTime { get; }

        /// <summary>
        /// Gets the metric values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue> MetricValues { get; }
    }
}