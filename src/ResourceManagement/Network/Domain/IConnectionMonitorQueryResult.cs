// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// List of connection states snaphots.
    /// </summary>
    public interface IConnectionMonitorQueryResult  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ConnectionMonitorQueryResultInner>
    {

        /// <summary>
        /// Gets status of connection monitor source.
        /// </summary>
        Models.ConnectionMonitorSourceStatus SourceStatus { get; }

        /// <summary>
        /// Gets information about connection states.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ConnectionStateSnapshot> States { get; }
    }
}