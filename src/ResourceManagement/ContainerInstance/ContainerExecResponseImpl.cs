// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for RegistryCredentials.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcmluc3RhbmNlLmltcGxlbWVudGF0aW9uLkNvbnRhaW5lckV4ZWNSZXNwb25zZUltcGw=
    internal partial class ContainerExecResponseImpl  :
        Wrapper<Models.ContainerExecResponseInner>,
        IContainerExecResponse
    {

        ///GENMHASH:1DBF01A73FA5C5A9FA039B205770C4A0:C0C35E00AF4E17F141675A2C05C7067B
        internal  ContainerExecResponseImpl(ContainerExecResponseInner innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:A369C4EBDDE4CC27126D90BC7903E73F:722F5B70786E3D93E74F38DF6106CC48
        public string Password()
        {
            return this.Inner.Password;

        }

        ///GENMHASH:E4DE44FBE48F7B7E2F537FF2C0289006:B4973EEB53D15115A4B24777F1D4CB23
        public string WebSocketUri()
        {
            return this.Inner.WebSocketUri;
        }
    }
}