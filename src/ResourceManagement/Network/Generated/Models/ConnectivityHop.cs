// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Fluent;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Information about a hop between the source and the destination.
    /// </summary>
    public partial class ConnectivityHop
    {
        /// <summary>
        /// Initializes a new instance of the ConnectivityHop class.
        /// </summary>
        public ConnectivityHop()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ConnectivityHop class.
        /// </summary>
        /// <param name="type">The type of the hop.</param>
        /// <param name="id">The ID of the hop.</param>
        /// <param name="address">The IP address of the hop.</param>
        /// <param name="resourceId">The ID of the resource corresponding to
        /// this hop.</param>
        /// <param name="nextHopIds">List of next hop identifiers.</param>
        /// <param name="issues">List of issues.</param>
        public ConnectivityHop(string type = default(string), string id = default(string), string address = default(string), string resourceId = default(string), IList<string> nextHopIds = default(IList<string>), IList<ConnectivityIssue> issues = default(IList<ConnectivityIssue>))
        {
            Type = type;
            Id = id;
            Address = address;
            ResourceId = resourceId;
            NextHopIds = nextHopIds;
            Issues = issues;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the type of the hop.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the ID of the hop.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the IP address of the hop.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; private set; }

        /// <summary>
        /// Gets the ID of the resource corresponding to this hop.
        /// </summary>
        [JsonProperty(PropertyName = "resourceId")]
        public string ResourceId { get; private set; }

        /// <summary>
        /// Gets list of next hop identifiers.
        /// </summary>
        [JsonProperty(PropertyName = "nextHopIds")]
        public IList<string> NextHopIds { get; private set; }

        /// <summary>
        /// Gets list of issues.
        /// </summary>
        [JsonProperty(PropertyName = "issues")]
        public IList<ConnectivityIssue> Issues { get; private set; }

    }
}
