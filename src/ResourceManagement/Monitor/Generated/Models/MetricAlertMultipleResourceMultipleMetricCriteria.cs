// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies the metric alert criteria for multiple resource that has
    /// multiple metric criteria.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria")]
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : MetricAlertCriteria
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MetricAlertMultipleResourceMultipleMetricCriteria class.
        /// </summary>
        public MetricAlertMultipleResourceMultipleMetricCriteria()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MetricAlertMultipleResourceMultipleMetricCriteria class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="allOf">the list of multiple metric criteria for this
        /// 'all of' operation. </param>
        public MetricAlertMultipleResourceMultipleMetricCriteria(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), IList<MultiMetricCriteria> allOf = default(IList<MultiMetricCriteria>))
            : base(additionalProperties)
        {
            AllOf = allOf;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the list of multiple metric criteria for this 'all of'
        /// operation.
        /// </summary>
        [JsonProperty(PropertyName = "allOf")]
        public IList<MultiMetricCriteria> AllOf { get; set; }

    }
}
