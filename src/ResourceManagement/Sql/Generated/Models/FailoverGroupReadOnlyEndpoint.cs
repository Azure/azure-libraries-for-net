// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Read-only endpoint of the failover group instance.
    /// </summary>
    public partial class FailoverGroupReadOnlyEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the FailoverGroupReadOnlyEndpoint
        /// class.
        /// </summary>
        public FailoverGroupReadOnlyEndpoint()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FailoverGroupReadOnlyEndpoint
        /// class.
        /// </summary>
        /// <param name="failoverPolicy">Failover policy of the read-only
        /// endpoint for the failover group. Possible values include:
        /// 'Disabled', 'Enabled'</param>
        public FailoverGroupReadOnlyEndpoint(ReadOnlyEndpointFailoverPolicy failoverPolicy = default(ReadOnlyEndpointFailoverPolicy))
        {
            FailoverPolicy = failoverPolicy;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets failover policy of the read-only endpoint for the
        /// failover group. Possible values include: 'Disabled', 'Enabled'
        /// </summary>
        [JsonProperty(PropertyName = "failoverPolicy")]
        public ReadOnlyEndpointFailoverPolicy FailoverPolicy { get; set; }

    }
}
