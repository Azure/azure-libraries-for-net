// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class ContainerImageSettingsImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAIJob.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<BatchAIJob.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies password for container registry.
        /// </summary>
        /// <param name="password">Password to login.</param>
        /// <return>The next stage of the definition.</return>
        ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ContainerImageSettings.Definition.IWithRegistryCredentials<BatchAIJob.Definition.IWithCreate>.WithRegistryPassword(string password)
        {
            return this.WithRegistryPassword(password);
        }

        /// <summary>
        /// Specifies the location of the password, which is a Key Vault Secret.
        /// Users can store their secrets in Azure KeyVault and pass it to the Batch
        /// AI Service to integrate with KeyVault.
        /// </summary>
        ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ContainerImageSettings.Definition.IWithRegistryCredentials<BatchAIJob.Definition.IWithCreate>.WithRegistrySecretReference(string keyVaultId, string secretUrl)
        {
            return this.WithRegistrySecretReference(keyVaultId, secretUrl);
        }

        /// <summary>
        /// Specifies url for container registry.
        /// </summary>
        /// <param name="serverUrl">URL for image repository.</param>
        /// <return>The next stage of the definition.</return>
        ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithRegistryUrl(string serverUrl)
        {
            return this.WithRegistryUrl(serverUrl);
        }

        /// <summary>
        /// Specifies username to login to container registry.
        /// </summary>
        /// <param name="username">User name to login.</param>
        /// <return>The next stage of the definition.</return>
        ContainerImageSettings.Definition.IWithRegistryCredentials<BatchAIJob.Definition.IWithCreate> ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithRegistryUsername(string username)
        {
            return this.WithRegistryUsername(username);
        }

        /// <summary>
        /// Specifies size of /dev/shm.
        /// </summary>
        /// <param name="shmSize">Size of /dev/shm.</param>
        /// <return>The next stage of the definition.</return>
        ContainerImageSettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ContainerImageSettings.Definition.IWithShmSize<BatchAIJob.Definition.IWithCreate>.WithShmSize(string shmSize)
        {
            return this.WithShmSize(shmSize);
        }
    }
}