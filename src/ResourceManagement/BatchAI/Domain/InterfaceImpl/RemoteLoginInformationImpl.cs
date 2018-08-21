// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public sealed partial class RemoteLoginInformationImpl 
    {
        /// <summary>
        /// Gets ip address.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation.IPAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        /// <summary>
        /// Gets Id of the compute node.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation.NodeId
        {
            get
            {
                return this.NodeId();
            }
        }

        /// <summary>
        /// Gets port number.
        /// </summary>
        int Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation.Port
        {
            get
            {
                return this.Port();
            }
        }
    }
}