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

    /// <summary>
    /// Implementation for Azure SQL Database's service tier advisor.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlVGllckFkdmlzb3JJbXBs
    internal partial class ServiceTierAdvisorImpl  :
        Wrapper<Models.ServiceTierAdvisorInner>,
        IServiceTierAdvisor
    {
        private string sqlServerName;
        private string resourceGroupName;
        private ISqlManager sqlServerManager;
        private ResourceId resourceId;
        private List<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> sloUsageMetrics;
        private List<Microsoft.Azure.Management.Sql.Fluent.IServiceLevelObjectiveUsageMetric> serviceLevelObjectiveUsageMetrics;

        ///GENMHASH:AE5E279A623EC95DE2C1FF13EE964ABF:2195512CD9515F346E018CD0415C3ECF
        public ServiceTierAdvisorImpl(string resourceGroupName, string sqlServerName, ServiceTierAdvisorInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerManager = sqlServerManager;
            this.resourceId = ResourceId.FromString(this.Inner.Id);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:FE87C81287218E52EB858DF49B82ED45
        protected async Task<Models.ServiceTierAdvisorInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.sloUsageMetrics = null;
            this.serviceLevelObjectiveUsageMetrics = null;

            return await this.sqlServerManager.Inner.ServiceTierAdvisors.GetAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), this.Name());
        }

        public IServiceTierAdvisor Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<IServiceTierAdvisor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync());
            return this;
        }

        ///GENMHASH:0150BB5F92ED226BF84D3AC5255EFE3F:F8EEA9E1BE10E299F96C7CA9D025C464
        public string CurrentServiceLevelObjective()
        {
            return this.Inner.CurrentServiceLevelObjective;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:E469BC0EB728512D322663135CC847D6
        public string DatabaseName()
        {
            return this.resourceId.Parent.Name;
        }

        ///GENMHASH:65C1F2B4C0DC45A99F79FBA42145F773:8E1D9C140BE367F6B48088368DB3CAC2
        public double AvgDtu()
        {
            return this.Inner.AvgDtu.GetValueOrDefault();
        }

        ///GENMHASH:AA4563C382DF54B43A0F4309F62888BA:6A738B7F6FF6375CC7B92AF08D7B44FA
        public Guid? OverallRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.OverallRecommendationServiceLevelObjectiveId;
        }

        ///GENMHASH:DF4FB4A6806E7C331047A89BA1F0238A:2CD23C3554E161BCD1FB54EEC384AEF4
        public double MinDtu()
        {
            return this.Inner.MinDtu.GetValueOrDefault();
        }

        ///GENMHASH:773AEB91BBDF38D9C541399D2AC0907F:996C7874F5F74B384347C1A4C88C89CA
        public Guid? DisasterPlanBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.DisasterPlanBasedRecommendationServiceLevelObjectiveId;
        }

        ///GENMHASH:7FD5A8D2A26E9E6B12E7585A7DBE1CE3:27A38D67D25A9EA0E7B11D0D435A7522
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> ServiceLevelObjectiveUsageMetrics()
        {
            if (this.sloUsageMetrics == null)
            {
                this.sloUsageMetrics = new List<ISloUsageMetricInterface>();
                if (this.Inner.ServiceLevelObjectiveUsageMetrics != null)
                {
                    foreach (var sloUsageMetricInner in this.Inner.ServiceLevelObjectiveUsageMetrics)
                    {
                        this.sloUsageMetrics.Add(new SloUsageMetricImpl(sloUsageMetricInner));
                    }
                }
            }

            return this.sloUsageMetrics.AsReadOnly();
        }

        ///GENMHASH:E436DE603F6C7FB0C98E5ECEA3B20FAB:3D51FB843FA93F602F4DEF956AC6F706
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceLevelObjectiveUsageMetric> ServiceLevelObjectiveUsageMetric()
        {
            if (this.serviceLevelObjectiveUsageMetrics == null)
            {
                this.serviceLevelObjectiveUsageMetrics = new List<IServiceLevelObjectiveUsageMetric>();
                foreach (var sloUsageMetricInner in this.Inner.ServiceLevelObjectiveUsageMetrics)
                {
                    this.serviceLevelObjectiveUsageMetrics.Add(new ServiceLevelObjectiveUsageMetricImpl(sloUsageMetricInner));
                }
            }
            return this.serviceLevelObjectiveUsageMetrics.AsReadOnly();
        }

        ///GENMHASH:E1D13665116B8ECA351FF7B3C332BAF4:132F6DAA63B96E3D5A5059C74C281394
        public DateTime? ObservationPeriodStart()
        {
            return this.Inner.ObservationPeriodStart;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }
        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:F06969F30E65390822448213EEDFB046:5F1256734C53E9CBF330B552A20213C0
        public string DatabaseSizeBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.DatabaseSizeBasedRecommendationServiceLevelObjective;
        }

        ///GENMHASH:595D9B167631FF51CC7B52AA73AD4F18:E2335FCB8EB0CCBB0FE160BCE40C1FE9
        public string OverallRecommendationServiceLevelObjective()
        {
            return this.Inner.OverallRecommendationServiceLevelObjective;
        }

        ///GENMHASH:EB92BB6EDC4B4487F80DD9429DEA5509:4DB04EC4CBC470E141A1F395C7CA1D8E
        public double Confidence()
        {
            return this.Inner.Confidence;
        }

        ///GENMHASH:784C4BB3169D35BF6AAE0AF9F79505C7:115090F0342C88D04EA4B5C6E7311E9C
        public Guid? UsageBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.CurrentServiceLevelObjectiveId;
        }

        ///GENMHASH:6A4CBDC24D036E91928ED09FA5C78F2E:6A7C8ED51763D88CD779061561661698
        public double MaxDtu()
        {
            return this.Inner.MaxDtu.GetValueOrDefault();
        }

        ///GENMHASH:C4B4BF3321B70686AA3906F2295146C1:C8E7AAD6A3E0CD79087919190171E915
        public DateTime? ObservationPeriodEnd()
        {
            return this.Inner.ObservationPeriodEnd;
        }

        ///GENMHASH:2C118AADB9C4EED010A789927B901D6A:BF060DDEC8011AFD01DB638A2174B219
        public double ActiveTimeRatio()
        {
            return this.Inner.ActiveTimeRatio.GetValueOrDefault();
        }

        ///GENMHASH:DABDD303A33B139D98DC627CFC8471F1:859B6E99FC481ED0ECC4624CD2301BC5
        public Guid? DatabaseSizeBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.DatabaseSizeBasedRecommendationServiceLevelObjectiveId;
        }

        ///GENMHASH:E8CFF2549263DFEF1D66E7C5A23E0B8B:115090F0342C88D04EA4B5C6E7311E9C
        public Guid? CurrentServiceLevelObjectiveId()
        {
            return this.Inner.CurrentServiceLevelObjectiveId;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:347C4A0DC579EE33AF5B9736F98AB6D3:BA5EA9151C53BD7F9DC1EF0ADC2C99DD
        public string DisasterPlanBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.DisasterPlanBasedRecommendationServiceLevelObjective;
        }

        ///GENMHASH:8F2C0FD9ED92422E1653CD9B168DE74D:1022F2613B690C3B6549E375732B361D
        public double MaxSizeInGB()
        {
            return this.Inner.MaxSizeInGB.GetValueOrDefault();
        }

        ///GENMHASH:FEAD40466D37AC29DF1AA732E22DFE2A:4AC68885628AFFBD6798B2CAB843E711
        public string UsageBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.UsageBasedRecommendationServiceLevelObjective;
        }
    }
}