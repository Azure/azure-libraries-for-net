// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent;

    public interface IWithAzureFileUrl<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithRelativeMountPath<ParentT> WithAzureFileUrl(string azureFileUrl);
    }

    public interface IWithDirectoryMode<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAttach<ParentT> WithDirectoryMode(string directoryMode);
    }

    /// <summary>
    /// Definition of azure file share reference.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAzureFileUrl<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithRelativeMountPath<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAzureStorageCredentials<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAttach<ParentT>
    {
    }

    public interface IWithFileMode<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAttach<ParentT> WithFileMode(string fileMode);
    }

    public interface IWithStorageAccount<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAzureFileUrl<ParentT> WithStorageAccountName(string storageAccountName);
    }

    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithFileMode<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithDirectoryMode<ParentT>
    {
    }

    public interface IWithRelativeMountPath<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAzureStorageCredentials<ParentT> WithRelativeMountPath(string mountPath);
    }

    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithStorageAccount<ParentT>
    {
    }

    public interface IWithAzureStorageCredentials<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAttach<ParentT> WithKeyVaultSecretReference(KeyVaultSecretReference keyVaultSecretReference);

        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IWithAttach<ParentT> WithAccountKey(string accountKey);
    }
}