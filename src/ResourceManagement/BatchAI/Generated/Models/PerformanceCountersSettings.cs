// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Performance counters reporting settings.
    /// </summary>
    public partial class PerformanceCountersSettings
    {
        /// <summary>
        /// Initializes a new instance of the PerformanceCountersSettings
        /// class.
        /// </summary>
        public PerformanceCountersSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PerformanceCountersSettings
        /// class.
        /// </summary>
        /// <param name="appInsightsReference">Azure Application Insights
        /// reference.</param>
        public PerformanceCountersSettings(AppInsightsReference appInsightsReference)
        {
            AppInsightsReference = appInsightsReference;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets azure Application Insights reference.
        /// </summary>
        /// <remarks>
        /// Azure Application Insights information for performance counters
        /// reporting. If provided, Batch AI will upload node performance
        /// counters to the corresponding Azure Application Insights account.
        /// </remarks>
        [JsonProperty(PropertyName = "appInsightsReference")]
        public AppInsightsReference AppInsightsReference { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AppInsightsReference == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AppInsightsReference");
            }
            if (AppInsightsReference != null)
            {
                AppInsightsReference.Validate();
            }
        }
    }
}
