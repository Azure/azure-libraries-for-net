// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal partial class MetricCollectionImpl
    {
        /// <summary>
        /// Gets the cost value.
        /// </summary>
        /// <summary>
        /// Gets the cost value.
        /// </summary>
        double? Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.Cost
        {
            get
            {
                return this.Cost();
            }
        }

        /// <summary>
        /// Gets the interval value.
        /// </summary>
        /// <summary>
        /// Gets the interval value.
        /// </summary>
        System.TimeSpan? Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.Interval
        {
            get
            {
                return this.Interval();
            }
        }

        /// <summary>
        /// Gets the metric collection value.
        /// </summary>
        /// <summary>
        /// Gets the metric collection value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.IMetric> Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.Metrics
        {
            get
            {
                return this.Metrics();
            }
        }

        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        /// <summary>
        /// Gets the namespace value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.Namespace
        {
            get
            {
                return this.Namespace();
            }
        }

        /// <summary>
        /// Gets the resource region value.
        /// </summary>
        /// <summary>
        /// Gets the resource region value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.ResourceRegion
        {
            get
            {
                return this.ResourceRegion();
            }
        }

        /// <summary>
        /// Gets the timespan value.
        /// </summary>
        /// <summary>
        /// Gets the timespan value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IMetricCollection.Timespan
        {
            get
            {
                return this.Timespan();
            }
        }
    }
}