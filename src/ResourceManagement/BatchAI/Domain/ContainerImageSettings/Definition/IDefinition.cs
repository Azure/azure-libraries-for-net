// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition
{
/// <summary>
    /// Specifies size of /dev/shm. Please refer to docker documentation for supported argument formats.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithShmSize<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies size of /dev/shm.
        /// </summary>
        /// <param name="shmSize">Size of /dev/shm.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT> WithShmSize(string shmSize);
    }

    /// <summary>
    /// The final stage of the output directory settings definition.
    /// At this stage, any remaining optional settings can be specified, or the output directory settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithShmSize<ParentT>
    {

        /// <summary>
        /// Specifies url for container registry.
        /// </summary>
        /// <param name="serverUrl">URL for image repository.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT> WithRegistryUrl(string serverUrl);

        /// <summary>
        /// Specifies username to login to container registry.
        /// </summary>
        /// <param name="username">User name to login.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithRegistryCredentials<ParentT> WithRegistryUsername(string username);
    }

    /// <summary>
    /// Definition of ContainerImage settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithRegistryCredentials<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The first stage of the output directory settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// Specifies container registry credentials.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRegistryCredentials<ParentT> 
    {
        /// <summary>
        /// Specifies password for container registry.
        /// </summary>
        /// <param name="password">Password to login.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT> WithRegistryPassword(string password);

        /// <summary>
        /// Specifies the location of the password, which is a Key Vault Secret.
        /// Users can store their secrets in Azure KeyVault and pass it to the Batch
        /// AI Service to integrate with KeyVault.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition.IWithAttach<ParentT> WithRegistrySecretReference(string keyVaultId, string secretUrl);
    }
}