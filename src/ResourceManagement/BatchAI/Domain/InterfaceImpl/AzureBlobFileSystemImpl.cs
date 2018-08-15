// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class AzureBlobFileSystemImpl<ParentT> 
    {
        AzureBlobFileSystem.Definition.IWithAttach<ParentT> AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<ParentT>.WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            return this.WithKeyVaultSecretReference(keyVaultSecretReference);
        }

        AzureBlobFileSystem.Definition.IWithAttach<ParentT> AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<ParentT>.WithAccountKey(string accountKey)
        {
            return this.WithAccountKey(accountKey);
        }

        AzureBlobFileSystem.Definition.IWithAttach<ParentT> AzureBlobFileSystem.Definition.IWithMountOptions<ParentT>.WithMountOptions(string mountOptions)
        {
            return this.WithMountOptions(mountOptions);
        }

        AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<ParentT> AzureBlobFileSystem.Definition.IWithRelativeMountPath<ParentT>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath);
        }

        AzureBlobFileSystem.Definition.IWithRelativeMountPath<ParentT> AzureBlobFileSystem.Definition.IWithStorageContainerName<ParentT>.WithContainerName(string containerName)
        {
            return this.WithContainerName(containerName);
        }

        AzureBlobFileSystem.Definition.IWithStorageContainerName<ParentT> AzureBlobFileSystem.Definition.IWithStorageAccount<ParentT>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName);
        }
    }
}