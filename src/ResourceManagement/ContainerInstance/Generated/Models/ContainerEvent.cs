// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.ContainerInstance;
    using Microsoft.Azure.Management.ContainerInstance.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A container event.
    /// </summary>
    public partial class ContainerEvent
    {
        /// <summary>
        /// Initializes a new instance of the ContainerEvent class.
        /// </summary>
        public ContainerEvent()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ContainerEvent class.
        /// </summary>
        /// <param name="count">The count of the event.</param>
        /// <param name="firstTimestamp">Date/time of the first event.</param>
        /// <param name="lastTimestamp">Date/time of the last event.</param>
        /// <param name="message">The event message</param>
        /// <param name="type">The event type.</param>
        public ContainerEvent(int? count = default(int?), System.DateTime? firstTimestamp = default(System.DateTime?), System.DateTime? lastTimestamp = default(System.DateTime?), string message = default(string), string type = default(string))
        {
            Count = count;
            FirstTimestamp = firstTimestamp;
            LastTimestamp = lastTimestamp;
            Message = message;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the count of the event.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets date/time of the first event.
        /// </summary>
        [JsonProperty(PropertyName = "firstTimestamp")]
        public System.DateTime? FirstTimestamp { get; set; }

        /// <summary>
        /// Gets or sets date/time of the last event.
        /// </summary>
        [JsonProperty(PropertyName = "lastTimestamp")]
        public System.DateTime? LastTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the event message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
