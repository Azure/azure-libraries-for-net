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

        /// <summary>
        /// Gets Details of the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.MountSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.MountSettings
        {
            get
            {
                return this.MountSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.MountSettings;
            }
        }

        /// <summary>
        /// Gets Specifies the provisioning state of the File Server.
        /// Possible values: creating - The File Server is getting created. updating
        /// - The File Server creation has been accepted and it is getting updated.
        /// deleting - The user has requested that the File Server be deleted, and
        /// it is in the process of being deleted. failed - The File Server creation
        /// has failed with the specified errorCode. Details about the error code
        /// are specified in the message field. succeeded - The File Server creation
        /// has succeeded. Possible values include: 'creating', 'updating',
        /// 'deleting', 'succeeded', 'failed'.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.FileServerProvisioningState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets Time when the FileServer was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <summary>
        /// Gets Settings for the data disk which would be created for the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.DataDisks Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.DataDisks
        {
            get
            {
                return this.DataDisks() as Microsoft.Azure.Management.BatchAI.Fluent.Models.DataDisks;
            }
        }

        /// <summary>
        /// Gets The size of the virtual machine of the File Server.
        /// For information about available VM sizes for File Server from the
        /// Virtual Machines Marketplace, see Sizes for Virtual Machines (Linux).
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.VMSize
        {
            get
            {
                return this.VMSize();
            }
        }

        /// <summary>
        /// Gets Time when the status was changed.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.ProvisioningStateTransitionTime
        {
            get
            {
                return this.ProvisioningStateTransitionTime();
            }
        }

        /// <summary>
        /// Gets Specifies the identifier of the subnet.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.Subnet
        {
            get
            {
                return this.Subnet() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId;
            }
        }

        /// <summary>
        /// Gets SSH settings for the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.SshConfiguration Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer.SshConfiguration
        {
            get
            {
                return this.SshConfiguration() as Microsoft.Azure.Management.BatchAI.Fluent.Models.SshConfiguration;
            }
        }

        BatchAIFileServer.Definition.IWithVMSize BatchAIFileServer.Definition.IWithDataDisks.WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType)
        {
            return this.WithDataDisks(diskSizeInGB, diskCount, storageAccountType) as BatchAIFileServer.Definition.IWithVMSize;
        }
    }
}