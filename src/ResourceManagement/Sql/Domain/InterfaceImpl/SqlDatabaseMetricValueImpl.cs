// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SqlDatabaseMetricValueImpl 
    {
        /// <summary>
        /// Gets the average value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Average
        {
            get
            {
                return this.Average();
            }
        }

        /// <summary>
        /// Gets the total value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Total
        {
            get
            {
                return this.Total();
            }
        }

        /// <summary>
        /// Gets the number of values for the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Count
        {
            get
            {
                return this.Count();
            }
        }

        /// <summary>
        /// Gets the min value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Minimum
        {
            get
            {
                return this.Minimum();
            }
        }

        /// <summary>
        /// Gets the metric timestamp (ISO-8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Timestamp
        {
            get
            {
                return this.Timestamp();
            }
        }

        /// <summary>
        /// Gets the max value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue.Maximum
        {
            get
            {
                return this.Maximum();
            }
        }
    }
}