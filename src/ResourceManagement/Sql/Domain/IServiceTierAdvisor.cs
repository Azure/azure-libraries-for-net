// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Service tier advisor.
    /// </summary>
    public interface IServiceTierAdvisor  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServiceTierAdvisorInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <summary>
        /// Gets the current service level Objective for the service tier advisor.
        /// </summary>
        string CurrentServiceLevelObjective { get; }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the database size based recommendation service level objective for the service tier advisor.
        /// </summary>
        string DatabaseSizeBasedRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets the overall recommendation service level objective for the service tier advisor.
        /// </summary>
        string OverallRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets the average DTU for the service tier advisor.
        /// </summary>
        double AvgDtu { get; }

        /// <summary>
        /// Gets the confidence for service tier advisor.
        /// </summary>
        double Confidence { get; }

        /// <summary>
        /// Gets the overall recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? OverallRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets or sets minDtu for the service tier advisor.
        /// </summary>
        double MinDtu { get; }

        /// <summary>
        /// Gets the usage based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? UsageBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets the disaster plan based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? DisasterPlanBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets the maximum DTU for the service tier advisor.
        /// </summary>
        double MaxDtu { get; }

        /// <summary>
        /// Gets the service level objective usage metrics for the service tier advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> ServiceLevelObjectiveUsageMetrics { get; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime? ObservationPeriodEnd { get; }

        /// <summary>
        /// Gets the activeTimeRatio for the service tier advisor.
        /// </summary>
        double ActiveTimeRatio { get; }

        /// <summary>
        /// Gets the database size based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? DatabaseSizeBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets the current service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? CurrentServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime? ObservationPeriodStart { get; }

        /// <summary>
        /// Gets the disaster plan based recommendation service level objective for the service tier advisor.
        /// </summary>
        string DisasterPlanBasedRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets the service level objective usage metric for the service tier
        /// advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceLevelObjectiveUsageMetric> ServiceLevelObjectiveUsageMetric { get; }

        /// <summary>
        /// Gets the maximum size in GB for the service tier advisor.
        /// </summary>
        double MaxSizeInGB { get; }

        /// <summary>
        /// Gets the usage based recommendation service level objective for the service tier advisor.
        /// </summary>
        string UsageBasedRecommendationServiceLevelObjective { get; }
    }
}