// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    /// <summary>
    /// The Azure metric definition entries are of type MetricDefinition.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljRGVmaW5pdGlvbkltcGw=
    internal partial class MetricDefinitionImpl :
        Wrapper<Models.MetricDefinition>,
        IMetricDefinition,
        IMetricsQueryDefinition
    {
        private MonitorManager myManager;
        private MetricDefinition inner;
        private ILocalizableString name;
        private DateTime queryStartTime;
        private DateTime queryEndTime;
        private string aggreagation;
        private TimeSpan? interval;
        private string odataFilter;
        private ResultType? resultType;
        private int? top;
        private string orderBy;
        ///GENMHASH:8E798D06F036643A781434270F4F347E:6ED95D1C0D7030224A0A5556D72F0018
        public MetricDefinitionImpl EndsBefore(DateTime endTime)
        {
            this.queryEndTime = endTime;
            return this;
        }

        ///GENMHASH:6E40675090A7C5A5E2DC401C96A422D5:887E87D6089467ED74835057139438F0
        public IMetricCollection Execute()
        {
            return Extensions.Synchronize(() => this.ExecuteAsync());
        }

        ///GENMHASH:532A125F6308BA5B895A3303D68F428F:35FD1AE22645CD7DE5424859B658C564
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricAvailability> MetricAvailabilities()
        {
            return this.inner.MetricAvailabilities.ToList();
        }

        ///GENMHASH:F886A4914B553C095A7AE17389D27E77:FA5F578A5F3D9A0CDDD31A0A42192F9F
        internal MetricDefinitionImpl(MetricDefinition innerModel, MonitorManager monitorManager)
            : base(innerModel)
        {
            this.myManager = monitorManager;
            this.inner = innerModel;
            this.name = (inner.Name == null) ? null : new LocalizableStringImpl(inner.Name);
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:363E4D62FCA795A36F9CB60513C86AFA
        public MonitorManager Manager()
        {
            return this.myManager;
        }

        ///GENMHASH:F630198BE6DA9C0B5B56EF7592ABEBD6:70CA6DA265907F8297D881094E4FA057
        public MetricDefinitionImpl OrderBy(string orderBy)
        {
            this.orderBy = orderBy;
            return this;
        }

        ///GENMHASH:914F5848297276F1D8C78263F5BE935D:0A9FBB52D71FD812653CFC7FB6D8E4FE
        public MetricDefinitionImpl DefineQuery()
        {
            this.aggreagation = null;
            this.interval = null;
            this.resultType = null;
            this.top = null;
            this.orderBy = null;
            return this;
        }

        ///GENMHASH:8C7AFB2687E015E5BA88FC209626353F:BADFBF4A4B9A078A0E61C032E86F3F54
        public MetricDefinitionImpl WithInterval(TimeSpan interval)
        {
            this.interval = interval;
            return this;
        }

        ///GENMHASH:75A38F9E6FBA8C676A2F326679329965:910A51D04DA74674472E2E6CDF8345AE
        public MetricDefinitionImpl SelectTop(int top)
        {
            this.top = top;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:9FCCB4B796E8FFF1419FB39498ED40F5
        public string Id()
        {
            return this.inner.Id;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:75D0179020FBF5E8CFE92E1F66EDBAF7
        public Unit Unit()
        {
            return (this.inner.Unit.HasValue) ? this.inner.Unit.Value : Models.Unit.Unspecified;
        }

        ///GENMHASH:FE2BD4F5F53442BA2A87A646EE3AE424:3853D164417C81C32FF41FDBF3091A69
        public string ResourceId()
        {
            return this.inner.ResourceId;
        }

        ///GENMHASH:A6A688C16DF4F6EC07E3F90BB7035E9B:2D82016634720F57D754570B0ADB36FA
        public MetricDefinitionImpl WithOdataFilter(string odataFilter)
        {
            this.odataFilter = odataFilter;
            return this;
        }

        ///GENMHASH:466C9D6BF16AFC7E5643C50D8BF6E937:38A64203651F9C55FF10205837F6BF41
        public MetricDefinitionImpl StartingFrom(DateTime startTime)
        {
            this.queryStartTime = startTime;
            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:06048B7DED44D8A0B076B777AD66C830
        public ILocalizableString Name()
        {
            return this.name;
        }

        ///GENMHASH:28267C95BE469468FC3C62D4CF4CCA7C:A9F06CDED41BB042AAC8A6EE0459669E
        public async Task<IMetricCollection> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new MetricCollectionImpl(await this.Manager().Inner.Metrics.ListAsync(
                this.inner.ResourceId,
                string.Format("{0}/{1}",
                    this.queryStartTime.ToString("o"),
                    this.queryEndTime.ToString("o")),
                this.interval,
                this.inner.Name?.Value,
                this.aggreagation,
                this.top,
                this.orderBy,
                this.odataFilter,
                this.resultType,
                cancellationToken));
        }

        ///GENMHASH:109D11A77FA743E7E386E405BD1BAAAF:ADA232E274A9B225A8972BEF1F18FEB5
        public AggregationType PrimaryAggregationType()
        {
            return (this.Inner.PrimaryAggregationType.HasValue) ? this.Inner.PrimaryAggregationType.Value : AggregationType.None;
        }

        ///GENMHASH:F95F49048D7CA429F65F73921425F878:B874986DD69C44A52E663CD4459B7D0E
        public MetricDefinitionImpl WithResultType(ResultType resultType)
        {
            this.resultType = resultType;
            return this;
        }

        ///GENMHASH:75D81809C4B6D3B6D4093D0120B8C6E2:147385CD62A0A87E80618B5C7EAD3723
        public MetricDefinitionImpl WithAggregation(string aggregation)
        {
            this.aggreagation = aggregation;
            return this;
        }
    }
}