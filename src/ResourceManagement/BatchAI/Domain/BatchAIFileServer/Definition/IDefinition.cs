// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of a Batch AI file server definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials
    {
    }

    public interface IWithUserCredentials 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithSshPublicKey(string sshPublicKey);

        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate WithPassword(string password);
    }

    /// <summary>
    /// The entirety of a Batch AI file server definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IBlank,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithGroup,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithDataDisks,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithVMSize,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserName,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of a Batch AI file server definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithDataDisks>
    {
    }

    public interface IWithVMSize 
    {
        /// <param name="vmSize">Virtual machine size.</param>
        /// <return>Next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserName WithVMSize(string vmSize);
    }

    public interface IWithDataDisks 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithVMSize WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType);
    }

    public interface IWithUserName 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition.IWithUserCredentials WithUserName(string userName);
    }
}