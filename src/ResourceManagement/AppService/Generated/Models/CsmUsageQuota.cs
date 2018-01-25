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
    using System.Linq;

    /// <summary>
    /// Usage of the quota resource.
    /// </summary>
    public partial class CsmUsageQuota
    {
        /// <summary>
        /// Initializes a new instance of the CsmUsageQuota class.
        /// </summary>
        public CsmUsageQuota()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CsmUsageQuota class.
        /// </summary>
        /// <param name="unit">Units of measurement for the quota
        /// resourse.</param>
        /// <param name="nextResetTime">Next reset time for the resource
        /// counter.</param>
        /// <param name="currentValue">The current value of the resource
        /// counter.</param>
        /// <param name="limit">The resource limit.</param>
        /// <param name="name">Quota name.</param>
        public CsmUsageQuota(string unit = default(string), System.DateTime? nextResetTime = default(System.DateTime?), long? currentValue = default(long?), long? limit = default(long?), LocalizableString name = default(LocalizableString))
        {
            Unit = unit;
            NextResetTime = nextResetTime;
            CurrentValue = currentValue;
            Limit = limit;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets units of measurement for the quota resourse.
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets next reset time for the resource counter.
        /// </summary>
        [JsonProperty(PropertyName = "nextResetTime")]
        public System.DateTime? NextResetTime { get; set; }

        /// <summary>
        /// Gets or sets the current value of the resource counter.
        /// </summary>
        [JsonProperty(PropertyName = "currentValue")]
        public long? CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the resource limit.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// Gets or sets quota name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public LocalizableString Name { get; set; }

    }
}
