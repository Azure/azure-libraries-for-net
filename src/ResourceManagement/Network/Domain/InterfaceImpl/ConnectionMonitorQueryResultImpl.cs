// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ConnectionMonitorQueryResultImpl 
    {
        /// <summary>
        /// Gets status of connection monitor source.
        /// </summary>
        Models.ConnectionMonitorSourceStatus Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult.SourceStatus
        {
            get
            {
                return this.SourceStatus();
            }
        }

        /// <summary>
        /// Gets information about connection states.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ConnectionStateSnapshot> Microsoft.Azure.Management.Network.Fluent.IConnectionMonitorQueryResult.States
        {
            get
            {
                return this.States();
            }
        }
    }
}