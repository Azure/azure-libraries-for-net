// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Tag information.
    /// </summary>
    public partial class TagValueInner
    {
        /// <summary>
        /// Initializes a new instance of the TagValueInner class.
        /// </summary>
        public TagValueInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TagValueInner class.
        /// </summary>
        /// <param name="id">The tag value ID.</param>
        /// <param name="tagValueProperty">The tag value.</param>
        /// <param name="count">The tag value count.</param>
        public TagValueInner(string id = default(string), string tagValueProperty = default(string), TagCount count = default(TagCount))
        {
            Id = id;
            TagValueProperty = tagValueProperty;
            Count = count;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the tag value ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the tag value.
        /// </summary>
        [JsonProperty(PropertyName = "tagValue")]
        public string TagValueProperty { get; set; }

        /// <summary>
        /// Gets or sets the tag value count.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public TagCount Count { get; set; }

    }
}
