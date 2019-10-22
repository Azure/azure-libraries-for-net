// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Response for the CheckPrivateLinkServiceVisibility API service call.
    /// </summary>
    public partial class PrivateLinkServiceVisibilityInner
    {
        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceVisibilityInner
        /// class.
        /// </summary>
        public PrivateLinkServiceVisibilityInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceVisibilityInner
        /// class.
        /// </summary>
        /// <param name="visible">Private Link Service Visibility
        /// (True/False).</param>
        public PrivateLinkServiceVisibilityInner(bool? visible = default(bool?))
        {
            Visible = visible;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets private Link Service Visibility (True/False).
        /// </summary>
        [JsonProperty(PropertyName = "visible")]
        public bool? Visible { get; set; }

    }
}
