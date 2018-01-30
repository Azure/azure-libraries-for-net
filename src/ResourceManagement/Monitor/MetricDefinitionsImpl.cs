// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for  MetricDefinitions.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljRGVmaW5pdGlvbnNJbXBs
    internal partial class MetricDefinitionsImpl :
        IMetricDefinitions
    {
        private MonitorManager myManager;
        ///GENMHASH:ADB7D3AA7EC183D335762850C5DBCB9F:0B84363EF9B71179CB4DC40DD87498C0
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> ListByResource(string resourceId)
        {
            //$ return Lists.Transform(this.Inner.List(resourceId), new Function<MetricDefinitionInner, MetricDefinition>() {
            //$ @Override
            //$ public MetricDefinition apply(MetricDefinitionInner metricDefinitionInner) {
            //$ return  new MetricDefinitionImpl(metricDefinitionInner, myManager);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:363E4D62FCA795A36F9CB60513C86AFA
        public MonitorManager Manager()
        {
            //$ return this.myManager;

            return null;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:9D314272FE346A3A373ECC355DCFD751
        public IMetricDefinitionsOperations Inner
        {
            get
            {
                //$ return this.myManager.Inner.MetricDefinitions();

                return null;
            }
        }

        ///GENMHASH:8BB42E8B013293EB00FF395576B1B45A:4738909A0D005F4EAE1440649772A2CF
        public async Task<Microsoft.Azure.Management.Monitor.Fluent.IMetricDefinition> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.ListAsync(resourceId)
            //$ .FlatMapIterable(new Func1<List<MetricDefinitionInner>, Iterable<MetricDefinitionInner>>() {
            //$ @Override
            //$ public Iterable<MetricDefinitionInner> call(List<MetricDefinitionInner> items) {
            //$ return items;
            //$ }
            //$ }).Map(new Func1<MetricDefinitionInner, MetricDefinition>() {
            //$ @Override
            //$ public MetricDefinition call(MetricDefinitionInner metricDefinitionInner) {
            //$ return new MetricDefinitionImpl(metricDefinitionInner, myManager);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:AA538995551EE6491ECDDBBF4B2BE752:6D4AC7AF5CE4C05E9300E78AC24A228B
        internal MetricDefinitionsImpl(MonitorManager monitorManager)
        {
            //$ this.myManager = monitorManager;
            //$ }

        }
    }
}