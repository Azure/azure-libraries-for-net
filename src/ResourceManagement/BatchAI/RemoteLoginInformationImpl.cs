// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for  RemoteLoginInformation.
    /// </summary>
    public sealed partial class RemoteLoginInformationImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.RemoteLoginInformation>,
        IRemoteLoginInformation
    {
        internal  RemoteLoginInformationImpl(RemoteLoginInformation innerModel) : base(innerModel)
        {
        }

        public string IPAddress()
        {
            return Inner.IpAddress;
        }

        public string NodeId()
        {
            return Inner.NodeId;
        }

        public int Port()
        {
            if (Inner.Port == null) {
                return 0;
            }
            return Convert.ToInt32(Inner.Port);
        }
    }
}