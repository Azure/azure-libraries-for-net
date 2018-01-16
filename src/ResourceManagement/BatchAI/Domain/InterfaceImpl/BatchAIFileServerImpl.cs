// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class BatchAIFileServerImpl 
    {
        BatchAIFileServer.Definition.IWithUserCredentials BatchAIFileServer.Definition.IWithUserName.WithUserName(string userName)
        {
            return this.WithUserName(userName) as BatchAIFileServer.Definition.IWithUserCredentials;
        }

        BatchAIFileServer.Definition.IWithCreate BatchAIFileServer.Definition.IWithUserCredentials.WithPassword(string password)
        {
            return this.WithPassword(password) as BatchAIFileServer.Definition.IWithCreate;
        }

        BatchAIFileServer.Definition.IWithCreate BatchAIFileServer.Definition.IWithUserCredentials.WithSshPublicKey(string sshPublicKey)
        {
            return this.WithSshPublicKey(sshPublicKey) as BatchAIFileServer.Definition.IWithCreate;
        }

        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        BatchAIFileServer.Definition.IWithUserName BatchAIFileServer.Definition.IWithVMSize.WithVMSize(string vmSize)
        {
            return this.WithVMSize(vmSize) as BatchAIFileServer.Definition.IWithUserName;
        }

        BatchAIFileServer.Definition.IWithVMSize BatchAIFileServer.Definition.IWithDataDisks.WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType)
        {
            return this.WithDataDisks(diskSizeInGB, diskCount, storageAccountType) as BatchAIFileServer.Definition.IWithVMSize;
        }
    }
}