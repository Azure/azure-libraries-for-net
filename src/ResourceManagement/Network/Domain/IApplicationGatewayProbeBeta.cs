// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an application gateway probe.
    /// </summary>
    public interface IApplicationGatewayProbeBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the body contents of an HTTP response to a probe to check for to determine backend health, or null if none specified.
        /// </summary>
        string HealthyHttpResponseBodyContents { get; }

        /// <summary>
        /// Gets HTTP response code ranges in the format ###-### returned by the backend which the probe considers healthy.
        /// </summary>
        System.Collections.Generic.ISet<string> HealthyHttpResponseStatusCodeRanges { get; }
    }
}