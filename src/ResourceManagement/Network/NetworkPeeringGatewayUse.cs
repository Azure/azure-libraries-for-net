// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Possible gateway use scenarios.
    /// </summary>
    public enum NetworkPeeringGatewayUse
    {
        /// <summary>
        /// The remote network is allowed to use this network's gateway (but not necessarily using it currently).
        /// </summary>
        ByRemoteNetwork,

        /// <summary>
        /// This network is configured to use the remote network's gateway.
        /// </summary>
        OnRemoteNetwork,

        /// <summary>
        /// No gateway use is configured.
        /// </summary>
        None
    }
}
