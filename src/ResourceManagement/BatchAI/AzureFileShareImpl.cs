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
    public partial class AzureFileShareImpl<ParentT>  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.AzureFileShareReference>,
        IAzureFileShare,
        IDefinition<ParentT>
    {
        private IHasMountVolumes parent;
        public AzureFileShareImpl<ParentT> WithFileMode(string fileMode)
        {
            Inner.FileMode = fileMode;
            return this;
        }

        internal  AzureFileShareImpl(AzureFileShareReference inner, ParentT parent)
            :base(inner)
        {
            this.parent = (IHasMountVolumes)parent;
        }

        public AzureFileShareImpl<ParentT> WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            EnsureCredentials().AccountKeySecretReference = keyVaultSecretReference;
            return this;
        }

        public AzureFileShareImpl<ParentT> WithAccountKey(string accountKey)
        {
            EnsureCredentials().AccountKey = accountKey;
            return this;
        }

        public AzureFileShareImpl<ParentT> WithStorageAccountName(string storageAccountName)
        {
            Inner.AccountName = storageAccountName;
            return this;
        }

        public AzureFileShareImpl<ParentT> WithAzureFileUrl(string azureFileUrl)
        {
            Inner.AzureFileUrl = azureFileUrl;
            return this;
        }

        public ParentT Attach()
        {
            parent.AttachAzureFileShare(this);
            return (ParentT) parent;
        }

        public AzureFileShareImpl<ParentT> WithRelativeMountPath(string mountPath)
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

        public AzureFileShareImpl<ParentT> WithDirectoryMode(string directoryMode)
        {
            Inner.DirectoryMode = directoryMode;
            return this;
        }
    }
}