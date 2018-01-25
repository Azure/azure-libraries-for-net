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
    /// An Activity Log alert condition that is met when all its member
    /// conditions are met.
    /// </summary>
    public partial class ActivityLogAlertAllOfCondition
    {
        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertAllOfCondition
        /// class.
        /// </summary>
        public ActivityLogAlertAllOfCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertAllOfCondition
        /// class.
        /// </summary>
        /// <param name="allOf">The list of activity log alert
        /// conditions.</param>
        public ActivityLogAlertAllOfCondition(IList<ActivityLogAlertLeafCondition> allOf)
        {
            AllOf = allOf;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the list of activity log alert conditions.
        /// </summary>
        [JsonProperty(PropertyName = "allOf")]
        public IList<ActivityLogAlertLeafCondition> AllOf { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AllOf == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AllOf");
            }
            if (AllOf != null)
            {
                foreach (var element in AllOf)
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
