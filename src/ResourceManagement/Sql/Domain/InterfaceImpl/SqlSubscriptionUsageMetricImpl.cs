// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlSubscriptionUsageMetricImpl 
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
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the boundary value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets a user-readable name of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets the unit of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }
    }
}