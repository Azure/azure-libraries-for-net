// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// The result of SQL server usages per SQL Database.
    /// </summary>
    public interface ISqlDatabaseUsageMetric  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseUsageInner>
    {
        /// <summary>
        /// Gets the unit of the metric.
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Gets a user-readable name of the metric.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the boundary value of the metric.
        /// </summary>
        double Limit { get; }

        /// <summary>
        /// Gets the next reset time for the usage metric (ISO8601 format).
        /// </summary>
        System.DateTime? NextResetTime { get; }

        /// <summary>
        /// Gets the name of the SQL Database resource.
        /// </summary>
        string ResourceName { get; }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double CurrentValue { get; }
    }
}