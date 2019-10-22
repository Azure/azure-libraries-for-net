// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;

    internal partial class VolumeImpl 
    {
        /// <summary>
        /// Specifies the storage account name to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountKey<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName);
        }

        /// <summary>
        /// Specifies the Git target directory name for the new volume.
        /// Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the
        /// git repository.  Otherwise, if specified, the volume will contain the git repository in the
        /// subdirectory with the given name.
        /// </summary>
        /// <param name="gitDirectoryName">The Git target directory name for the new volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithGitRevision<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithGitDirectoryNameBeta<ContainerGroup.Definition.IWithVolume>.WithGitDirectoryName(string gitDirectoryName)
        {
            return this.WithGitDirectoryName(gitDirectoryName);
        }

        /// <summary>
        /// Specifies the secrets map.
        /// The secret value must be specified in Base64 encoding.
        /// </summary>
        /// <param name="secrets">The new volume secrets map; value must be in Base64 encoding.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithVolumeAttach<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithSecretsMapBeta<ContainerGroup.Definition.IWithVolume>.WithSecrets(IDictionary<string,string> secrets)
        {
            return this.WithSecrets(secrets);
        }

        /// <summary>
        /// Specifies the storage account key to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountKey">The storage account key.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithVolumeAttach<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithStorageAccountKey<ContainerGroup.Definition.IWithVolume>.WithStorageAccountKey(string storageAccountKey)
        {
            return this.WithStorageAccountKey(storageAccountKey);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerGroup.Definition.IWithVolume Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerGroup.Definition.IWithVolume>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithAzureFileShare<ContainerGroup.Definition.IWithVolume>.WithExistingReadOnlyAzureFileShare(string shareName)
        {
            return this.WithExistingReadOnlyAzureFileShare(shareName);
        }

        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithStorageAccountName<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithAzureFileShare<ContainerGroup.Definition.IWithVolume>.WithExistingReadWriteAzureFileShare(string shareName)
        {
            return this.WithExistingReadWriteAzureFileShare(shareName);
        }

        /// <summary>
        /// Specifies the Git URL for the new volume.
        /// </summary>
        /// <param name="gitUrl">The Git URL for the new volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithGitDirectoryName<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithGitUrlBeta<ContainerGroup.Definition.IWithVolume>.WithGitUrl(string gitUrl)
        {
            return this.WithGitUrl(gitUrl);
        }

        /// <summary>
        /// Specifies the Git revision for the new volume.
        /// </summary>
        /// <param name="gitRevision">The Git revision for the new volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithVolumeAttach<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithGitRevisionBeta<ContainerGroup.Definition.IWithVolume>.WithGitRevision(string gitRevision)
        {
            return this.WithGitRevision(gitRevision);
        }
    }
}