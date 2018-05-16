// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Response containing the container exec command.
    /// </summary>
    public interface IContainerExecResponse  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ContainerExecResponseInner>
    {

        /// <summary>
        /// Gets the password value.
        /// </summary>
        /// <summary>
        /// Gets the password value.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Gets the webSocketUri value.
        /// </summary>
        /// <summary>
        /// Gets the webSocketUri value.
        /// </summary>
        string WebSocketUri { get; }
    }
}