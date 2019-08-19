// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Information on the configuration of flow log and traffic analytics
    /// (optional) .
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class FlowLogInformationInner
    {
        /// <summary>
        /// Initializes a new instance of the FlowLogInformationInner class.
        /// </summary>
        public FlowLogInformationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FlowLogInformationInner class.
        /// </summary>
        /// <param name="targetResourceId">The ID of the resource to configure
        /// for flow log and traffic analytics (optional) .</param>
        /// <param name="storageId">ID of the storage account which is used to
        /// store the flow log.</param>
        /// <param name="enabled">Flag to enable/disable flow logging.</param>
        /// <param name="retentionPolicy">Parameters that define the retention
        /// policy for flow log.</param>
        /// <param name="format">Parameters that define the flow log
        /// format.</param>
        /// <param name="flowAnalyticsConfiguration">Parameters that define the
        /// configuration of traffic analytics.</param>
        public FlowLogInformationInner(string targetResourceId, string storageId, bool enabled, RetentionPolicyParameters retentionPolicy = default(RetentionPolicyParameters), FlowLogFormatParameters format = default(FlowLogFormatParameters), TrafficAnalyticsProperties flowAnalyticsConfiguration = default(TrafficAnalyticsProperties))
        {
            TargetResourceId = targetResourceId;
            StorageId = storageId;
            Enabled = enabled;
            RetentionPolicy = retentionPolicy;
            Format = format;
            FlowAnalyticsConfiguration = flowAnalyticsConfiguration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of the resource to configure for flow log and
        /// traffic analytics (optional) .
        /// </summary>
        [JsonProperty(PropertyName = "targetResourceId")]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets ID of the storage account which is used to store the
        /// flow log.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageId")]
        public string StorageId { get; set; }

        /// <summary>
        /// Gets or sets flag to enable/disable flow logging.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets parameters that define the retention policy for flow
        /// log.
        /// </summary>
        [JsonProperty(PropertyName = "properties.retentionPolicy")]
        public RetentionPolicyParameters RetentionPolicy { get; set; }

        /// <summary>
        /// Gets or sets parameters that define the flow log format.
        /// </summary>
        [JsonProperty(PropertyName = "properties.format")]
        public FlowLogFormatParameters Format { get; set; }

        /// <summary>
        /// Gets or sets parameters that define the configuration of traffic
        /// analytics.
        /// </summary>
        [JsonProperty(PropertyName = "flowAnalyticsConfiguration")]
        public TrafficAnalyticsProperties FlowAnalyticsConfiguration { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (TargetResourceId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetResourceId");
            }
            if (StorageId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageId");
            }
            if (FlowAnalyticsConfiguration != null)
            {
                FlowAnalyticsConfiguration.Validate();
            }
        }
    }
}
