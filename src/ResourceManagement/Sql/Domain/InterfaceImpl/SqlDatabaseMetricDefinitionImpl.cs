// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    internal partial class SqlDatabaseMetricDefinitionImpl 
    {
        /// <summary>
        /// Gets the primary aggregation type.
        /// </summary>
        Models.PrimaryAggregationType Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition.PrimaryAggregationType
        {
            get
            {
                return this.PrimaryAggregationType();
            }
        }

        /// <summary>
        /// Gets the metric availabilities.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricAvailability> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition.MetricAvailabilities
        {
            get
            {
                return this.MetricAvailabilities();
            }
        }

        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the unit type.
        /// </summary>
        Models.UnitDefinitionType Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the resource URI.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition.ResourceUri
        {
            get
            {
                return this.ResourceUri();
            }
        }
    }
}