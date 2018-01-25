// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// A client-side representation allowing user to get troubleshooting information for virtual network gateway or virtual network gateway connection.
    /// </summary>
    public interface ITroubleshooting :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.ITroubleshooting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {
        /// <summary>
        /// Gets the resource identifier of the target resource against which the action
        /// is to be performed.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string TargetResourceId { get; }

        /// <summary>
        /// Gets the result code of the troubleshooting.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets the path to the blob to save the troubleshoot result in.
        /// </summary>
        string StoragePath { get; }

        /// <summary>
        /// Gets The start time of the troubleshooting.
        /// </summary>
        DateTime? StartTime { get; }

        /// <summary>
        /// Gets the end time of the troubleshooting.
        /// </summary>
        DateTime? EndTime { get; }

        /// <summary>
        /// Gets information from troubleshooting.
        /// </summary>
        IReadOnlyList<TroubleshootingDetails> Results { get; }

        /// <summary>
        /// Gets id of the storage account where troubleshooting information was saved.
        /// </summary>
        string StorageId { get; }
    }
}