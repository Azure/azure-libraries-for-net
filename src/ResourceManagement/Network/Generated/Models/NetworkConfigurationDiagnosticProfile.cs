// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Parameters to compare with network configuration.
    /// </summary>
    public partial class NetworkConfigurationDiagnosticProfile
    {
        /// <summary>
        /// Initializes a new instance of the
        /// NetworkConfigurationDiagnosticProfile class.
        /// </summary>
        public NetworkConfigurationDiagnosticProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// NetworkConfigurationDiagnosticProfile class.
        /// </summary>
        /// <param name="direction">The direction of the traffic. Possible
        /// values include: 'Inbound', 'Outbound'</param>
        /// <param name="protocol">Protocol to be verified on. Accepted values
        /// are '*', TCP, UDP.</param>
        /// <param name="source">Traffic source. Accepted values are '*', IP
        /// Address/CIDR, Service Tag.</param>
        /// <param name="destination">Traffic destination. Accepted values are:
        /// '*', IP Address/CIDR, Service Tag.</param>
        /// <param name="destinationPort">Traffic destination port. Accepted
        /// values are '*', port (for example, 3389) and port range (for
        /// example, 80-100).</param>
        public NetworkConfigurationDiagnosticProfile(Direction direction, string protocol, string source, string destination, string destinationPort)
        {
            Direction = direction;
            Protocol = protocol;
            Source = source;
            Destination = destination;
            DestinationPort = destinationPort;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the direction of the traffic. Possible values include:
        /// 'Inbound', 'Outbound'
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public Direction Direction { get; set; }

        /// <summary>
        /// Gets or sets protocol to be verified on. Accepted values are '*',
        /// TCP, UDP.
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets traffic source. Accepted values are '*', IP
        /// Address/CIDR, Service Tag.
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets traffic destination. Accepted values are: '*', IP
        /// Address/CIDR, Service Tag.
        /// </summary>
        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets traffic destination port. Accepted values are '*',
        /// port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        [JsonProperty(PropertyName = "destinationPort")]
        public string DestinationPort { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Direction == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Direction");
            }
            if (Protocol == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Protocol");
            }
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
            if (Destination == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Destination");
            }
            if (DestinationPort == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DestinationPort");
            }
        }
    }
}
