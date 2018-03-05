// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Response containing the Azure SQL Database metric definition.
    /// </summary>
    public interface ISqlDatabaseMetricDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MetricDefinition>
    {
        /// <summary>
        /// Gets the primary aggregation type.
        /// </summary>
        Models.PrimaryAggregationType PrimaryAggregationType { get; }

        /// <summary>
        /// Gets the unit type.
        /// </summary>
        Models.UnitDefinitionType Unit { get; }

        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the resource URI.
        /// </summary>
        string ResourceUri { get; }

        /// <summary>
        /// Gets the metric availabilities.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricAvailability> MetricAvailabilities { get; }
    }
}