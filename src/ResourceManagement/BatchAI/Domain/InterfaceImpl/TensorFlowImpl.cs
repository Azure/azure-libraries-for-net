// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class TensorFlowImpl 
    {
        /// <param name="commandLineArgs">
        /// Specifies the command line arguments for the worker task.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithWorkerCommandLineArgs(string commandLineArgs)
        {
            return this.WithWorkerCommandLineArgs(commandLineArgs);
        }

        /// <param name="commandLineArgs">
        /// Specifies the command line arguments for the parameter server task.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithParameterServerCommandLineArgs(string commandLineArgs)
        {
            return this.WithParameterServerCommandLineArgs(commandLineArgs);
        }

        /// <param name="workerCount">
        /// The number of worker tasks.
        /// If specified, the value must be less than or equal to (nodeCount
        /// numberOfGPUs per VM). If not specified, the default value is equal to
        /// nodeCount. This property can be specified only for distributed
        /// TensorFlow training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithWorkerCount(int workerCount)
        {
            return this.WithWorkerCount(workerCount);
        }

        /// <param name="parameterServerCount">
        /// The number of parameter server tasks.
        /// If specified, the value must be less than or equal to nodeCount. If not
        /// specified, the default value is equal to 1 for distributed TensorFlow
        /// training (This property is not applicable for single machine training).
        /// This property can be specified only for distributed TensorFlow training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithParameterServerCount(int parameterServerCount)
        {
            return this.WithParameterServerCount(parameterServerCount);
        }

        ToolTypeSettings.TensorFlow.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithMasterCommandLineArgs<BatchAIJob.Definition.IWithCreate>.WithMasterCommandLineArgs(string commandLineArgs)
        {
            return this.WithMasterCommandLineArgs(commandLineArgs);
        }

        /// <param name="pythonScriptFilePath">The path and file name of the python script to execute the job.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.TensorFlow.Definition.IWithMasterCommandLineArgs<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.TensorFlow.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath);
        }

        IWithAttach<IWithCreate> IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }
    }
}