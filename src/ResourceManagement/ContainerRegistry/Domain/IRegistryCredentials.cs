// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Response containing the login credentials for a container registry.
    /// </summary>
    public interface IRegistryCredentials :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets The admin user access key names and values which can be used to login into the container registry.
        /// </summary>
        /// <summary>
        /// Gets the admin user access keys.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.ContainerRegistry.Fluent.AccessKeyType, string> AccessKeys { get; }

        /// <summary>
        /// Gets the username value which can be used to login into the container registry.
        /// </summary>
        /// <summary>
        /// Gets the username value.
        /// </summary>
        string Username { get; }
    }
}