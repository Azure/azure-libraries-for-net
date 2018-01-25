// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an application gateway's redirect configuration.
    /// </summary>
    public interface IApplicationGatewayRedirectConfiguration :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayRedirectConfigurationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>
    {
        /// <summary>
        /// Gets the target listener on this application network traffic is redirected to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener TargetListener { get; }

        /// <summary>
        /// Gets true if the path is included in the redirected URL, otherwise false.
        /// </summary>
        bool IsPathIncluded { get; }

        /// <summary>
        /// Gets the type of redirection.
        /// </summary>
        Models.ApplicationGatewayRedirectType Type { get; }

        /// <summary>
        /// Gets true if the query string is included in the redirected URL, otherwise false.
        /// </summary>
        bool IsQueryStringIncluded { get; }

        /// <summary>
        /// Gets the target URL network traffic is redirected to.
        /// </summary>
        string TargetUrl { get; }

        /// <summary>
        /// Gets request routing rules on this application referencing this redirect configuration, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; }
    }
}