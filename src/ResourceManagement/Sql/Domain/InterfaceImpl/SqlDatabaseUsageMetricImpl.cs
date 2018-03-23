// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SqlDatabaseUsageMetricImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets a user-readable name of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets the boundary value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the name of the SQL Database resource.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.ResourceName
        {
            get
            {
                return this.ResourceName();
            }
        }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <summary>
        /// Gets the unit of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the next reset time for the usage metric (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric.NextResetTime
        {
            get
            {
                return this.NextResetTime();
            }
        }
    }
}