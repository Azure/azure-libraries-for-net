// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class VolumeImpl 
    {
        /// <summary>
        /// Specifies the storage account name to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountKey<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName) as ContainerGroup.Definition.IWithStorageAccountKey<ContainerGroup.Definition.IWithVolume>;
        }

        /// <summary>
        /// Specifies the storage account key to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountKey">The storage account key.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithVolumeAttach<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithStorageAccountKey<ContainerGroup.Definition.IWithVolume>.WithStorageAccountKey(string storageAccountKey)
        {
            return this.WithStorageAccountKey(storageAccountKey) as ContainerGroup.Definition.IWithVolumeAttach<ContainerGroup.Definition.IWithVolume>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerGroup.Definition.IWithVolume Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerGroup.Definition.IWithVolume>.Attach()
        {
            return this.Attach() as ContainerGroup.Definition.IWithVolume;
        }

        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithAzureFileShare<ContainerGroup.Definition.IWithVolume>.WithExistingReadWriteAzureFileShare(string shareName)
        {
            return this.WithExistingReadWriteAzureFileShare(shareName) as ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume>;
        }

        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithAzureFileShare<ContainerGroup.Definition.IWithVolume>.WithExistingReadOnlyAzureFileShare(string shareName)
        {
            return this.WithExistingReadOnlyAzureFileShare(shareName) as ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume>;
        }
    }
}