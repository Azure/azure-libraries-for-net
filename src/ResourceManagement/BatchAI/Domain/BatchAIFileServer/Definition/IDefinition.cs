// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of a Batch AI file server definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithDataDisks
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithSubnet
    {
    }

    public interface IWithUserCredentials 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithSshPublicKey(string sshPublicKey);

        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithPassword(string password);
    }

    /// <summary>
    /// The entirety of a Batch AI file server definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IBlank,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithVMSize,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserName,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of a Batch AI file server definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithDataDisks>
    {
    }

    public interface IWithVMSize 
    {
        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserName WithVMSize(string vmSize);
    }

    public interface IWithDataDisks 
    {
        /// <summary>
        /// Specifies settings for the data disks which would be created for the file server.
        /// </summary>
        /// <param name="diskSizeInGB">Initial disk size in GB for blank data disks.</param>
        /// <param name="diskCount">Number of data disks to be attached to the VM. RAID level 0 will be applied in the case of multiple disks.</param>
        /// <param name="storageAccountType">Type of storage account to be used on the disk.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithVMSize WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType);

        /// <summary>
        /// Specifies settings for the data disks which would be created for the file server.
        /// </summary>
        /// <param name="diskSizeInGB">Initial disk size in GB for blank data disks.</param>
        /// <param name="diskCount">Number of data disks to be attached to the VM. RAID level 0 will be applied in the case of multiple disks.</param>
        /// <param name="storageAccountType">Type of storage account to be used on the disk.</param>
        /// <param name="cachingType">Caching type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithVMSize WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType, CachingType cachingType);
    }

    /// <summary>
    /// Defines subnet for the file server.
    /// </summary>
    public interface IWithSubnet  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies subnet id.
        /// </summary>
        /// <param name="subnetId">Identifier of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithSubnet(string subnetId);

        /// <summary>
        /// Specifies network id and subnet name within this network.
        /// </summary>
        /// <param name="networkId">Identifier of the network.</param>
        /// <param name="subnetName">Subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithSubnet(string networkId, string subnetName);
    }

    public interface IWithUserName 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials WithUserName(string userName);
    }
}