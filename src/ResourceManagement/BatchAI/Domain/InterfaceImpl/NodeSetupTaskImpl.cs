// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public partial class NodeSetupTaskImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <param name="commandLine">Command Line to start Setup process.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithStdOutErrPath<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithCommandLine<BatchAICluster.Definition.IWithCreate>.WithCommandLine(string commandLine)
        {
            return this.WithCommandLine(commandLine);
        }

        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of setup task.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithStdOutErrPath<BatchAICluster.Definition.IWithCreate>.WithStdOutErrPath(string stdOutErrPathPrefix)
        {
            return this.WithStdOutErrPath(stdOutErrPathPrefix);
        }

        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithEnvironmentVariable<BatchAICluster.Definition.IWithCreate>.WithEnvironmentVariable(string name, string value)
        {
            return this.WithEnvironmentVariable(name, value);
        }

        /// <summary>
                /// Sets the value of the environment variable. This value will never be reported
                /// back by Batch AI.
                /// </summary>
                /// <param name="name">Name of the variable to set.</param>
                /// <param name="value">Value of the variable to set.</param>
                /// <return>The next stage of the definition.</return>
                NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithEnvironmentVariableSecretValue<BatchAICluster.Definition.IWithCreate>.WithEnvironmentVariableSecretValue(string name, string value)
                {
                    return this.WithEnvironmentVariableSecretValue(name, value);
                }

                /// <summary>
                /// Specifies KeyVault Store and Secret which contains the value for the
                /// environment variable.
                /// </summary>
                /// <param name="name">Name of the variable to set.</param>
                /// <param name="keyVaultId">Fully qualified resource Id for the Key Vault.</param>
                /// <param name="secretUrl">The URL referencing a secret in a Key Vault.</param>
                /// <return>The next stage of the definition.</return>
                NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithEnvironmentVariableSecretValue<BatchAICluster.Definition.IWithCreate>.WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl)
                {
                    return this.WithEnvironmentVariableSecretValue(name, keyVaultId, secretUrl);
                }

    }
}