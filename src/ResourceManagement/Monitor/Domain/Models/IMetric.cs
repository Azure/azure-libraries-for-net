// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The Azure metric entries are of type Metric.
    /// </summary>
    public interface IMetric :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricInner>
    {

        /// <summary>
        /// Gets the metric Id.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the name and the display name of the metric, i.e. it is localizable string.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Name { get; }

        /// <summary>
        /// Gets the time series returned when a data query is performed.
        /// </summary>
        /// <summary>
        /// Gets the timeseries value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.TimeSeriesElement> Timeseries { get; }

        /// <summary>
        /// Gets the resource type of the metric resource.
        /// </summary>
        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the unit of the metric. Possible values include: 'Count', 'Bytes', 'Seconds', 'CountPerSecond', 'BytesPerSecond', 'Percent', 'MilliSeconds', 'ByteSeconds', 'Unspecified'.
        /// </summary>
        /// <summary>
        /// Gets the unit value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.Unit Unit { get; }
    }
}