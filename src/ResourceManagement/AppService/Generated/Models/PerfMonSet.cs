// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.AppService;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Metric information.
    /// </summary>
    public partial class PerfMonSet
    {
        /// <summary>
        /// Initializes a new instance of the PerfMonSet class.
        /// </summary>
        public PerfMonSet()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PerfMonSet class.
        /// </summary>
        /// <param name="name">Unique key name of the counter.</param>
        /// <param name="startTime">Start time of the period.</param>
        /// <param name="endTime">End time of the period.</param>
        /// <param name="timeGrain">Presented time grain.</param>
        /// <param name="values">Collection of workers that are active during
        /// this time.</param>
        public PerfMonSet(string name = default(string), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), string timeGrain = default(string), IList<PerfMonSample> values = default(IList<PerfMonSample>))
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            TimeGrain = timeGrain;
            Values = values;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unique key name of the counter.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets start time of the period.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets end time of the period.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets presented time grain.
        /// </summary>
        [JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets collection of workers that are active during this
        /// time.
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IList<PerfMonSample> Values { get; set; }

    }
}
