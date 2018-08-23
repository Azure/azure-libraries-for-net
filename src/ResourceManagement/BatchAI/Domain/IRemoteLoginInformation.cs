// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of Batch AI remote login details to SSH/RDP to a compute node in cluster.
    /// </summary>
    public interface IRemoteLoginInformation  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.Models.RemoteLoginInformation>
    {

        /// <summary>
        /// Gets ip address.
        /// </summary>
        string IPAddress { get; }

        /// <summary>
        /// Gets Id of the compute node.
        /// </summary>
        string NodeId { get; }

        /// <summary>
        /// Gets port number.
        /// </summary>
        int Port { get; }
    }
}