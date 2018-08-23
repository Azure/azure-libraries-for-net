// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of the setup task definition allowing to specify where Batch AI will upload stdout and stderr of the setup task.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStdOutErrPath<ParentT> 
    {
        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of setup task.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithAttach<ParentT> WithStdOutErrPath(string stdOutErrPathPrefix);
    }

    /// <summary>
    /// The stage of the setup task definition allowing to specify environment variables.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEnvironmentVariable<ParentT> 
    {
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithAttach<ParentT> WithEnvironmentVariable(string name, string value);
    }

    /// <summary>
        /// The stage of the setup task definition allowing to specify environment variables with secrets.
        /// </summary>
        /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
        public interface IWithEnvironmentVariableSecretValue<ParentT>
        {

            /// <summary>
            /// Sets the value of the environment variable. This value will never be reported
            /// back by Batch AI.
            /// </summary>
            /// <param name="name">Name of the variable to set.</param>
            /// <param name="value">Value of the variable to set.</param>
            /// <return>The next stage of the definition.</return>
            Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithAttach<ParentT> WithEnvironmentVariableSecretValue(string name, string value);

            /// <summary>
            /// Specifies KeyVault Store and Secret which contains the value for the
            /// environment variable.
            /// </summary>
            /// <param name="name">Name of the variable to set.</param>
            /// <param name="keyVaultId">Fully qualified resource Id for the Key Vault.</param>
            /// <param name="secretUrl">The URL referencing a secret in a Key Vault.</param>
            /// <return>The next stage of the definition.</return>
            Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithAttach<ParentT> WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl);
        }

    /// <summary>
    /// The entirety of a setup task definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithStdOutErrPath<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithEnvironmentVariable<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the setup task definition.
    /// At this stage, any remaining optional settings can be specified, or the setup task definition
    /// can be attached to the parent cluster definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithEnvironmentVariable<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithEnvironmentVariableSecretValue<ParentT>
    {
    }

    /// <summary>
    /// The stage of the setup task definition allowing to specify the command line instructions.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCommandLine<ParentT> 
    {
        /// <param name="commandLine">Command Line to start Setup process.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithStdOutErrPath<ParentT> WithCommandLine(string commandLine);
    }

    /// <summary>
    /// The first stage of the node setup definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition.IWithCommandLine<ParentT>
    {
    }
}