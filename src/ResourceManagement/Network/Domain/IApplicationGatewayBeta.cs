// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for application gateway management API in Azure.
    /// </summary>
    public interface IApplicationGatewayBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Checks the backend health asynchronously.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth>> CheckBackendHealthAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks the backend health.
        /// </summary>
        /// <return>Backend healths indexed by backend name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth> CheckBackendHealth();

        /// <summary>
        /// Gets redirect configurations, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration> RedirectConfigurations { get; }

        /// <summary>
        /// Gets disabled SSL protocols.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.ApplicationGatewaySslProtocol> DisabledSslProtocols { get; }

        /// <summary>
        /// Gets authentication certificates.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get; }

        /// <summary>
        /// Gets The availability zones assigned to the application gateway.
        /// Note, this functionality is not enabled for most subscriptions and is subject to significant redesign
        /// and/or removal in the future.
        /// </summary>
        /// <summary>
        /// Gets the availability zones assigned to the application gateway.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones { get; }
    }
}