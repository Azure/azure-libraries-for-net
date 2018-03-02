// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlDatabaseMetricAvailabilityImpl 
    {
        /// <summary>
        /// Gets the length of retention for the database metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricAvailability.Retention
        {
            get
            {
                return this.Retention();
            }
        }

        /// <summary>
        /// Gets the granularity of the database metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricAvailability.TimeGrain
        {
            get
            {
                return this.TimeGrain();
            }
        }
    }
}