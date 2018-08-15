// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class AzureFileShareImpl<ParentT> 
    {
        AzureFileShare.Definition.IWithAttach<ParentT> AzureFileShare.Definition.IWithAzureStorageCredentials<ParentT>.WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            return this.WithKeyVaultSecretReference(keyVaultSecretReference);
        }

        AzureFileShare.Definition.IWithAttach<ParentT> AzureFileShare.Definition.IWithAzureStorageCredentials<ParentT>.WithAccountKey(string accountKey)
        {
            return this.WithAccountKey(accountKey);
        }

        AzureFileShare.Definition.IWithRelativeMountPath<ParentT> AzureFileShare.Definition.IWithAzureFileUrl<ParentT>.WithAzureFileUrl(string azureFileUrl)
        {
            return this.WithAzureFileUrl(azureFileUrl);
        }

        AzureFileShare.Definition.IWithAttach<ParentT> AzureFileShare.Definition.IWithFileMode<ParentT>.WithFileMode(string fileMode)
        {
            return this.WithFileMode(fileMode);
        }

        AzureFileShare.Definition.IWithAzureStorageCredentials<ParentT> AzureFileShare.Definition.IWithRelativeMountPath<ParentT>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath);
        }

        AzureFileShare.Definition.IWithAttach<ParentT> AzureFileShare.Definition.IWithDirectoryMode<ParentT>.WithDirectoryMode(string directoryMode)
        {
            return this.WithDirectoryMode(directoryMode);
        }

        AzureFileShare.Definition.IWithAzureFileUrl<ParentT> AzureFileShare.Definition.IWithStorageAccount<ParentT>.WithStorageAccountName(string storageAccountName)
        {
            return this.WithStorageAccountName(storageAccountName);
        }
    }
}