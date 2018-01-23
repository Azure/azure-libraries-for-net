// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Azure file share reference.
    /// </summary>
    public partial class AzureFileShareImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.AzureFileShareReference>,
        IAzureFileShare,
        IDefinition<BatchAICluster.Definition.IWithCreate>
    {
        private BatchAIClusterImpl parent;
        public IWithAttach<BatchAICluster.Definition.IWithCreate> WithFileMode(string fileMode)
        {
            Inner.FileMode = fileMode;
            return this;
        }

        internal  AzureFileShareImpl(AzureFileShareReference inner, BatchAIClusterImpl parent)
            :base(inner)
        {
            this.parent = parent;
        }

        public IWithAttach<BatchAICluster.Definition.IWithCreate> WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            EnsureCredentials().AccountKeySecretReference = keyVaultSecretReference;
            return this;
        }

        public IWithAttach<BatchAICluster.Definition.IWithCreate> WithAccountKey(string accountKey)
        {
            EnsureCredentials().AccountKey = accountKey;
            return this;
        }

        public IDefinition<BatchAICluster.Definition.IWithCreate> WithStorageAccountName(string storageAccountName)
        {
            Inner.AccountName = storageAccountName;
            return this;
        }

        public IDefinition<BatchAICluster.Definition.IWithCreate> WithAzureFileUrl(string azureFileUrl)
        {
            Inner.AzureFileUrl = azureFileUrl;
            return this;
        }

        public IWithCreate Attach()
        {
            parent.AttachAzureFileShare(this);
            return parent;
        }

        public IDefinition<BatchAICluster.Definition.IWithCreate> WithRelativeMountPath(string mountPath)
        {
            Inner.RelativeMountPath = mountPath;
            return this;
        }

        private AzureStorageCredentialsInfo EnsureCredentials()
        {
            if (Inner.Credentials == null) {
                Inner.Credentials = new AzureStorageCredentialsInfo();
            }
            return Inner.Credentials;
        }

        public IWithAttach<BatchAICluster.Definition.IWithCreate> WithDirectoryMode(string directoryMode)
        {
            Inner.DirectoryMode = directoryMode;
            return this;
        }
    }
}