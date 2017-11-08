// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for RegistryCredentials.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5Q3JlZGVudGlhbHNJbXBs
    internal partial class RegistryCredentialsImpl :
        Wrapper<Models.RegistryListCredentialsResultInner>,
        IRegistryCredentials
    {
        private Dictionary<Microsoft.Azure.Management.ContainerRegistry.Fluent.AccessKeyType, string> accessKeys;
        ///GENMHASH:F6689097E1B9BC16B53ACA7675E327BD:603A3E60C8411D55FF2F69556CAD694C
        public IReadOnlyDictionary<Microsoft.Azure.Management.ContainerRegistry.Fluent.AccessKeyType, string> AccessKeys()
        {
            return this.accessKeys;
        }

        ///GENMHASH:92F5A5EE6C4D8896EA14FE49CA9BA251:D810B84D415397DEAF3F6B313CB4639A
        internal RegistryCredentialsImpl(RegistryListCredentialsResultInner innerObject) : base(innerObject)
        {
            this.accessKeys = new Dictionary<AccessKeyType, string>();

            if (this.Inner.Passwords != null)
            {
                foreach (var registryPassword in this.Inner.Passwords)
                {
                    switch (registryPassword.Name)
                    {
                        case PasswordName.Password:
                            this.accessKeys.Add(AccessKeyType.Primary, registryPassword.Value);
                            break;
                        case PasswordName.Password2:
                            this.accessKeys.Add(AccessKeyType.Secondary, registryPassword.Value);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        ///GENMHASH:8C3117ECA23241768AF6EA0D1CE87916:41EE61824B7B686DAA5EC64A29D2AB17
        public string Username()
        {
            return this.Inner.Username;
        }
    }
}