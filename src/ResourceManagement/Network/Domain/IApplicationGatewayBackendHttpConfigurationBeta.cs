// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an application gateway's backend HTTP configuration.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfigurationBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets authentication certificates associated with this backend HTTPS configuration.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get; }

        /// <summary>
        /// Gets host header to be sent to the backend servers.
        /// </summary>
        string HostHeader { get; }

        /// <summary>
        /// Gets name used for the affinity cookie.
        /// </summary>
        string AffinityCookieName { get; }

        /// <summary>
        /// Gets the path, if any, used as a prefix for all HTTP requests.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets if 0 then connection draining is not enabled, otherwise if between 1 and 3600, then the number of seconds when connection draining is active.
        /// </summary>
        int ConnectionDrainingTimeoutInSeconds { get; }

        /// <summary>
        /// Gets true if the probe is enabled.
        /// </summary>
        bool IsProbeEnabled { get; }

        /// <summary>
        /// Gets whether the host header should come from the host name of the backend server.
        /// </summary>
        bool IsHostHeaderFromBackend { get; }
    }
}