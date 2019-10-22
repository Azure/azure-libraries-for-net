// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class RegistryCredentialsImpl
    {
        /// <summary>
        /// Gets The admin user access key names and values which can be used to login into the container registry.
        /// </summary>
        /// <summary>
        /// Gets the admin user access keys.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.ContainerRegistry.Fluent.AccessKeyType, string> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials.AccessKeys
        {
            get
            {
                return this.AccessKeys();
            }
        }

        /// <summary>
        /// Gets the username value which can be used to login into the container registry.
        /// </summary>
        /// <summary>
        /// Gets the username value.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials.Username
        {
            get
            {
                return this.Username();
            }
        }
    }
}