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
            return this.Attach() as Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition.IWithCreate;
        }
        /// <summary>
        /// Specifies that the setup task should run in elevated mode.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithElevatedMode<BatchAICluster.Definition.IWithCreate>.WithRunElevated()
        {
            return this.WithRunElevated() as NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        /// <param name="commandLine">Command Line to start Setup process.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithStdOutErrPath<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithCommandLine<BatchAICluster.Definition.IWithCreate>.WithCommandLine(string commandLine)
        {
            return this.WithCommandLine(commandLine) as NodeSetupTask.Definition.IWithStdOutErrPath<BatchAICluster.Definition.IWithCreate>;
        }

        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of setup task.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithStdOutErrPath<BatchAICluster.Definition.IWithCreate>.WithStdOutErrPath(string stdOutErrPathPrefix)
        {
            return this.WithStdOutErrPath(stdOutErrPathPrefix) as NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }

        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> NodeSetupTask.Definition.IWithEnvironmentVariable<BatchAICluster.Definition.IWithCreate>.WithEnvironmentVariable(string name, string value)
        {
            return this.WithEnvironmentVariable(name, value) as NodeSetupTask.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate>;
        }
    }
}