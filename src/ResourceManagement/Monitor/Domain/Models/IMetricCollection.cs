// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The MetricCollection representing wrapper over ResponseInner type.
    /// </summary>
    public interface IMetricCollection  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.Models.ResponseInner>
    {
        /// <summary>
        /// Gets the interval value.
        /// </summary>
        /// <summary>
        /// Gets the interval value.
        /// </summary>
        System.TimeSpan? Interval { get; }

        /// <summary>
        /// Gets the timespan value.
        /// </summary>
        /// <summary>
        /// Gets the timespan value.
        /// </summary>
        string Timespan { get; }

        /// <summary>
        /// Gets the metric collection value.
        /// </summary>
        /// <summary>
        /// Gets the metric collection value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.Metric> Metrics { get; }

        /// <summary>
        /// Gets the cost value.
        /// </summary>
        /// <summary>
        /// Gets the cost value.
        /// </summary>
        double? Cost { get; }
    }
}