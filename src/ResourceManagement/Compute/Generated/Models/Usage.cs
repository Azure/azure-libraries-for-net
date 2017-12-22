// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes Compute Resource Usage.
    /// </summary>
    public partial class Usage
    {
        /// <summary>
        /// Initializes a new instance of the Usage class.
        /// </summary>
        public Usage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Usage class.
        /// </summary>
        /// <param name="currentValue">The current usage of the
        /// resource.</param>
        /// <param name="limit">The maximum permitted usage of the
        /// resource.</param>
        /// <param name="name">The name of the type of usage.</param>
        public Usage(int currentValue, long limit, UsageName name)
        {
            CurrentValue = currentValue;
            Limit = limit;
            Name = name;
            CustomInit();
        }
        /// <summary>
        /// Static constructor for Usage class.
        /// </summary>
        static Usage()
        {
            Unit = "Count";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the current usage of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "currentValue")]
        public int CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum permitted usage of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public long Limit { get; set; }

        /// <summary>
        /// Gets or sets the name of the type of usage.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public UsageName Name { get; set; }

        /// <summary>
        /// An enum describing the unit of usage measurement.
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public static string Unit { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
        }
    }
}
