// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Management.EventHub.Fluent
{
    public partial class NestedResourceInner : Rest.Azure.IResource
    {
        /// <summary>
        /// Defines shared properties of an Azure NestedResourceInner.
        /// </summary>
        public NestedResourceInner() { }

        /// <summary>
        /// Initializes a new instance of the NestedResourceInner class.
        /// </summary>
        public NestedResourceInner(string id = default(string), string name = default(string), string type = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public virtual string Id { get; protected set; }

        /// <summary>
        /// Resource name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Resource type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }
    }
}
