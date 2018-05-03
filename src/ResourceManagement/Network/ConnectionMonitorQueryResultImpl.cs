// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for  com.microsoft.azure.management.network.ConnectionMonitorQueryResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQ29ubmVjdGlvbk1vbml0b3JRdWVyeVJlc3VsdEltcGw=
    internal partial class ConnectionMonitorQueryResultImpl  :
        Wrapper<Models.ConnectionMonitorQueryResultInner>,
        IConnectionMonitorQueryResult
    {

        ///GENMHASH:FD54A2B29ECEE1DA96AE3CE42664355A:C0C35E00AF4E17F141675A2C05C7067B
        internal  ConnectionMonitorQueryResultImpl(ConnectionMonitorQueryResultInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:802DC4018203AC698750EC649E9CBA0A:C5FCD01CBC4E6659F54A8FE3551CFEF1
        public ConnectionMonitorSourceStatus SourceStatus()
        {
            return Inner.SourceStatus;
        }

        ///GENMHASH:BE1EA957D0BFB4FE19638B8E97D6071D:3AE0E4C8B5F32B836364999BCF8BD994
        public IReadOnlyList<Models.ConnectionStateSnapshot> States()
        {
            return Inner.States.ToList();
        }
    }
}