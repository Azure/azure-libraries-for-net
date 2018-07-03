// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    internal partial class SqlDatabaseMetricImpl 
    {
        /// <summary>
        /// Gets the end time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <summary>
        /// Gets the metric name.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets the metric's unit type.
        /// </summary>
        Models.UnitType Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the time grain.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.TimeGrain
        {
            get
            {
                return this.TimeGrain();
            }
        }

        /// <summary>
        /// Gets the metric values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric.MetricValues
        {
            get
            {
                return this.MetricValues();
            }
        }
    }
}