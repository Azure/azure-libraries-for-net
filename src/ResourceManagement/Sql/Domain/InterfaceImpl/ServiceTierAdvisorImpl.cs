// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    internal partial class ServiceTierAdvisorImpl 
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
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the service level objective usage metric for the service tier
        /// advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceLevelObjectiveUsageMetric> Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ServiceLevelObjectiveUsageMetric
        {
            get
            {
                return this.ServiceLevelObjectiveUsageMetric();
            }
        }

        /// <summary>
        /// Gets or sets minDtu for the service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MinDtu
        {
            get
            {
                return this.MinDtu();
            }
        }

        /// <summary>
        /// Gets the usage based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets the confidence for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.Confidence
        {
            get
            {
                return this.Confidence();
            }
        }

        /// <summary>
        /// Gets the database size based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets the current service level Objective for the service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjective
        {
            get
            {
                return this.CurrentServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodStart
        {
            get
            {
                return this.ObservationPeriodStart();
            }
        }

        /// <summary>
        /// Gets the average DTU for the service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.AvgDtu
        {
            get
            {
                return this.AvgDtu();
            }
        }

        /// <summary>
        /// Gets the activeTimeRatio for the service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ActiveTimeRatio
        {
            get
            {
                return this.ActiveTimeRatio();
            }
        }

        /// <summary>
        /// Gets the maximum DTU for the service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxDtu
        {
            get
            {
                return this.MaxDtu();
            }
        }

        /// <summary>
        /// Gets the overall recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets the overall recommendation service level objective for the service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjective
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the service level objective usage metrics for the service tier advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ServiceLevelObjectiveUsageMetrics
        {
            get
            {
                return this.ServiceLevelObjectiveUsageMetrics();
            }
        }

        /// <summary>
        /// Gets the disaster plan based recommendation service level objective for the service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the current service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjectiveId
        {
            get
            {
                return this.CurrentServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets the disaster plan based recommendation service level objective ID for the service tier advisor.
        /// </summary>
        System.Guid? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the maximum size in GB for the service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxSizeInGB
        {
            get
            {
                return this.MaxSizeInGB();
            }
        }

        /// <summary>
        /// Gets the usage based recommendation service level objective for the service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the database size based recommendation service level objective for the service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodEnd
        {
            get
            {
                return this.ObservationPeriodEnd();
            }
        }
    }
}