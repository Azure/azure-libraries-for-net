// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class ContainerExecResponseImpl 
    {
        /// <summary>
        /// Gets the password value.
        /// </summary>
        /// <summary>
        /// Gets the password value.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse.Password
        {
            get
            {
                return this.Password();
            }
        }

        /// <summary>
        /// Gets the webSocketUri value.
        /// </summary>
        /// <summary>
        /// Gets the webSocketUri value.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse.WebSocketUri
        {
            get
            {
                return this.WebSocketUri();
            }
        }
    }
}