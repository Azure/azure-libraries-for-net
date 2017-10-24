// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Constraints associated with the Job.
    /// </summary>
    public partial class JobBasePropertiesConstraints
    {
        /// <summary>
        /// Initializes a new instance of the JobBasePropertiesConstraints
        /// class.
        /// </summary>
        public JobBasePropertiesConstraints()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobBasePropertiesConstraints
        /// class.
        /// </summary>
        /// <param name="maxWallClockTime">Max time the job can run.</param>
        public JobBasePropertiesConstraints(System.TimeSpan? maxWallClockTime = default(System.TimeSpan?))
        {
            MaxWallClockTime = maxWallClockTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets max time the job can run.
        /// </summary>
        /// <remarks>
        /// Default Value = 1 week.
        /// </remarks>
        [JsonProperty(PropertyName = "maxWallClockTime")]
        public System.TimeSpan? MaxWallClockTime { get; set; }

    }
}
