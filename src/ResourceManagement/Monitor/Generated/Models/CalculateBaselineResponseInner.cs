// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The response to a calcualte baseline call.
    /// </summary>
    public partial class CalculateBaselineResponseInner
    {
        /// <summary>
        /// Initializes a new instance of the CalculateBaselineResponseInner
        /// class.
        /// </summary>
        public CalculateBaselineResponseInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CalculateBaselineResponseInner
        /// class.
        /// </summary>
        /// <param name="type">the resource type of the baseline
        /// resource.</param>
        /// <param name="baseline">the baseline values for each
        /// sensitivity.</param>
        /// <param name="timestamps">the array of timestamps of the
        /// baselines.</param>
        public CalculateBaselineResponseInner(string type, IList<Baseline> baseline, IList<System.DateTime?> timestamps = default(IList<System.DateTime?>))
        {
            Type = type;
            Timestamps = timestamps;
            Baseline = baseline;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the resource type of the baseline resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the array of timestamps of the baselines.
        /// </summary>
        [JsonProperty(PropertyName = "timestamps")]
        public IList<System.DateTime?> Timestamps { get; set; }

        /// <summary>
        /// Gets or sets the baseline values for each sensitivity.
        /// </summary>
        [JsonProperty(PropertyName = "baseline")]
        public IList<Baseline> Baseline { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Type == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Type");
            }
            if (Baseline == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Baseline");
            }
            if (Baseline != null)
            {
                foreach (var element in Baseline)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
