// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Azure blob file system reference.
    /// </summary>
    public partial class AzureBlobFileSystemImpl  :
        IndexableWrapper<AzureBlobFileSystemReference>,
        IAzureBlobFileSystem,
        IDefinition<BatchAICluster.Definition.IWithCreate>
    {
        private BatchAIClusterImpl parent;
        internal  AzureBlobFileSystemImpl(AzureBlobFileSystemReference inner, BatchAIClusterImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public AzureBlobFileSystemImpl WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            EnsureCredentials().AccountKeySecretReference = keyVaultSecretReference;
            return this;
        }

        public AzureBlobFileSystemImpl WithAccountKey(string accountKey)
        {
            EnsureCredentials().AccountKey = accountKey;
            return this;
        }

        public AzureBlobFileSystemImpl WithMountOptions(string mountOptions)
        {
            Inner.MountOptions = mountOptions;
            return this;
        }

        public IDefinition<BatchAICluster.Definition.IWithCreate> WithStorageAccountName(string storageAccountName)
        {
            Inner.AccountName = storageAccountName;
            return this;
        }

        public IWithCreate Attach()
        {
            parent.AttachAzureBlobFileSystem(this);
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

        public AzureBlobFileSystemImpl WithContainerName(string containerName)
        {
            Inner.ContainerName = containerName;
            return this;
        }
    }
}