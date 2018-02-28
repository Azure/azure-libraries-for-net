// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Rest;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Replication link.
    /// </summary>
    public interface IReplicationLinkBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the replication mode of this replication link.
        /// </summary>
        string ReplicationMode { get; }

        /// <summary>
        /// Gets the legacy value indicating whether termination is allowed (currently always returns true).
        /// </summary>
        bool IsTerminationAllowed { get; }

        /// <summary>
        /// Gets the location of the server that contains this replication link.
        /// </summary>
        string Location { get; }
    }
}