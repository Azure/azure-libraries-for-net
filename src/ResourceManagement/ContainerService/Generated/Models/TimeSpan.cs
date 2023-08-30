// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The time span with start and end properties.
    /// </summary>
    public partial class TimeSpan
    {
        /// <summary>
        /// Initializes a new instance of the TimeSpan class.
        /// </summary>
        public TimeSpan()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TimeSpan class.
        /// </summary>
        /// <param name="start">The start of a time span</param>
        /// <param name="end">The end of a time span</param>
        public TimeSpan(System.DateTime? start = default(System.DateTime?), System.DateTime? end = default(System.DateTime?))
        {
            Start = start;
            End = end;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the start of a time span
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public System.DateTime? Start { get; set; }

        /// <summary>
        /// Gets or sets the end of a time span
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public System.DateTime? End { get; set; }

    }
}
