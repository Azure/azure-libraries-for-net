// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent;

    public interface IWithRelativeMountPath<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<ParentT> WithRelativeMountPath(string mountPath);
    }

    public interface IWithStorageAccount<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithStorageContainerName<ParentT> WithStorageAccountName(string storageAccountName);
    }

    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithMountOptions<ParentT>
    {
    }

    public interface IWithAzureStorageCredentials<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAttach<ParentT> WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference);

        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAttach<ParentT> WithAccountKey(string accountKey);
    }

    /// <summary>
    /// Definition of azure blob file system reference.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithStorageContainerName<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithRelativeMountPath<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAzureStorageCredentials<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAttach<ParentT>
    {
    }

    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithStorageAccount<ParentT>
    {
    }

    public interface IWithStorageContainerName<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithRelativeMountPath<ParentT> WithContainerName(string containerName);
    }

    public interface IWithMountOptions<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IWithAttach<ParentT> WithMountOptions(string mountOptions);
    }
}