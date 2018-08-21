// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Represents Azure blob file system reference.
    /// </summary>
    public partial class AzureBlobFileSystemImpl<ParentT>  :
        IndexableWrapper<AzureBlobFileSystemReference>,
        IAzureBlobFileSystem,
        AzureBlobFileSystem.Definition.IDefinition<ParentT>
    {
        private IHasMountVolumes parent;
        internal  AzureBlobFileSystemImpl(AzureBlobFileSystemReference inner, ParentT parent)
            : base(inner)
        {
            this.parent = (IHasMountVolumes) parent;
        }

        private AzureStorageCredentialsInfo EnsureCredentials()
        {
            if (Inner.Credentials == null) {
                Inner.Credentials = new AzureStorageCredentialsInfo();
            }
            return Inner.Credentials;
        }

        AzureBlobFileSystemImpl<ParentT> WithStorageAccountName(string storageAccountName)
        {
            Inner.AccountName = storageAccountName;
            return this;
        }

        AzureBlobFileSystemImpl<ParentT> WithContainerName(string containerName)
        {
            Inner.ContainerName = containerName;
            return this;
        }

        AzureBlobFileSystemImpl<ParentT> WithRelativeMountPath(string mountPath)
        {
            Inner.RelativeMountPath = mountPath;
            return this;
        }

        AzureBlobFileSystemImpl<ParentT> WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference)
        {
            EnsureCredentials().AccountKeySecretReference = keyVaultSecretReference;
            return this;
        }

        AzureBlobFileSystemImpl<ParentT> WithAccountKey(string accountKey)
        {
            EnsureCredentials().AccountKey = accountKey;
            return this;
        }

        ParentT IInDefinition<ParentT>.Attach()
        {
            parent.AttachAzureBlobFileSystem(this);
            return (ParentT)parent;
        }

        AzureBlobFileSystemImpl<ParentT> WithMountOptions(string mountOptions)
        {
            Inner.MountOptions = mountOptions;
            return this;
        }
    }
}