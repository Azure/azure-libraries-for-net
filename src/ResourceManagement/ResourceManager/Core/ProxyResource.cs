// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;

    public partial class ProxyResource : Rest.Azure.IResource
    {
        /// <summary>
        /// Defines shared properties of an Azure resource.
        /// </summary>
        public ProxyResource() { }

        /// <summary>
        /// Initializes a new instance of the Resource class.
        /// </summary>
        public ProxyResource(string id = default(string), string name = default(string), string type = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Resource Id. Setter is protected because Id needs to be set in Network resources.
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
