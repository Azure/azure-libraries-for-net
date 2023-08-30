// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A list of private link resources
    /// </summary>
    public partial class PrivateLinkResourceListResultInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PrivateLinkResourceListResultInner class.
        /// </summary>
        public PrivateLinkResourceListResultInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PrivateLinkResourceListResultInner class.
        /// </summary>
        /// <param name="value">Array of private link resources</param>
        public PrivateLinkResourceListResultInner(IList<PrivateLinkResource> value = default(IList<PrivateLinkResource>))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets array of private link resources
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<PrivateLinkResource> Value { get; set; }

    }
}
