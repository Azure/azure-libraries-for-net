// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class AzureFileShareImpl 
    {
        AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>.WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            return this.WithKeyVaultSecretReference(keyVaultSecretReference) as AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>.WithAccountKey(string accountKey)
        {
            return this.WithAccountKey(accountKey) as AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithAzureFileUrl<BatchAICluster.Definition.IWithCreate>.WithAzureFileUrl(string azureFileUrl)
        {
            return this.WithAzureFileUrl(azureFileUrl) as AzureFileShare.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithFileMode<BatchAICluster.Definition.IWithCreate>.WithFileMode(string fileMode)
        {
            return this.WithFileMode(fileMode) as AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath) as AzureFileShare.Definition.IWithAzureStorageCredentials<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithDirectoryMode<BatchAICluster.Definition.IWithCreate>.WithDirectoryMode(string directoryMode)
        {
            return this.WithDirectoryMode(directoryMode) as AzureFileShare.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        AzureFileShare.Definition.IWithAzureFileUrl<BatchAICluster.Definition.IWithCreate> AzureFileShare.Definition.IWithStorageAccount<BatchAICluster.Definition.IWithCreate>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName) as AzureFileShare.Definition.IWithAzureFileUrl<BatchAICluster.Definition.IWithCreate>;
        }
    }
}