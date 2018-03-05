// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Response containing the Azure SQL Database metric availability.
    /// </summary>
    public interface ISqlDatabaseMetricAvailability  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.MetricAvailability>
    {
        /// <summary>
        /// Gets the granularity of the database metric.
        /// </summary>
        string TimeGrain { get; }

        /// <summary>
        /// Gets the length of retention for the database metric.
        /// </summary>
        string Retention { get; }
    }
}