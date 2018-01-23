// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class AzureBlobFileSystemImpl 
    {
        AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>.WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            return this.WithKeyVaultSecretReference(keyVaultSecretReference) as AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>.WithAccountKey(string accountKey)
        {
            return this.WithAccountKey(accountKey) as AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithMountOptions<BatchAICluster.Definition.IWithCreate>.WithMountOptions(string mountOptions)
        {
            return this.WithMountOptions(mountOptions) as AzureBlobFileSystem.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath) as AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>;
        }

        AzureBlobFileSystem.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithStorageContainerName<BatchAICluster.Definition.IWithCreate>.WithContainerName(string containerName)
        {
            return this.WithContainerName(containerName) as AzureBlobFileSystem.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate>;
        }

        AzureBlobFileSystem.Definition.IWithStorageContainerName<BatchAICluster.Definition.IWithCreate> AzureBlobFileSystem.Definition.IWithStorageAccount<BatchAICluster.Definition.IWithCreate>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName) as AzureBlobFileSystem.Definition.IWithStorageContainerName<BatchAICluster.Definition.IWithCreate>;
        }
    }
}