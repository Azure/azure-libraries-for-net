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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Response for ServiceAssociationLinks_List operation.
    /// </summary>
    public partial class ServiceAssociationLinksListResultInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ServiceAssociationLinksListResultInner class.
        /// </summary>
        public ServiceAssociationLinksListResultInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ServiceAssociationLinksListResultInner class.
        /// </summary>
        /// <param name="value">The service association links in a
        /// subnet.</param>
        /// <param name="nextLink">The URL to get the next set of
        /// results.</param>
        public ServiceAssociationLinksListResultInner(IList<ServiceAssociationLinkInner> value = default(IList<ServiceAssociationLinkInner>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the service association links in a subnet.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<ServiceAssociationLinkInner> Value { get; set; }

        /// <summary>
        /// Gets the URL to get the next set of results.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; private set; }

    }
}
