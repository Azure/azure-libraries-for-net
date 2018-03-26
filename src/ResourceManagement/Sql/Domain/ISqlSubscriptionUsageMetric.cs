// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The result of SQL server usages per current subscription.
    /// </summary>
    public interface ISqlSubscriptionUsageMetric  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SubscriptionUsageInner>
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
        /// Gets the resource type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double CurrentValue { get; }
    }
}