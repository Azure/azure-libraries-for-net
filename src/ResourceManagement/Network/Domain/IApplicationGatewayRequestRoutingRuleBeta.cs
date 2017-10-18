// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an application gateway request routing rule.
    /// </summary>
    public interface IApplicationGatewayRequestRoutingRuleBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the redirect configuration associated with this request routing rule, if any.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration RedirectConfiguration { get; }
    }
}