// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Definition of TensorFlow job settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithMasterCommandLineArgs<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the TensorFlow settings definition.
    /// At this stage, any remaining optional settings can be specified, or the TensorFlow settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT>>
    {
        /// <param name="workerCount">
        /// The number of worker tasks.
        /// If specified, the value must be less than or equal to (nodeCount
        /// numberOfGPUs per VM). If not specified, the default value is equal to
        /// nodeCount. This property can be specified only for distributed
        /// TensorFlow training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT> WithWorkerCount(int workerCount);

        /// <param name="commandLineArgs">
        /// Specifies the command line arguments for the worker task.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT> WithWorkerCommandLineArgs(string commandLineArgs);

        /// <param name="parameterServerCount">
        /// The number of parameter server tasks.
        /// If specified, the value must be less than or equal to nodeCount. If not
        /// specified, the default value is equal to 1 for distributed TensorFlow
        /// training (This property is not applicable for single machine training).
        /// This property can be specified only for distributed TensorFlow training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT> WithParameterServerCount(int parameterServerCount);

        /// <param name="commandLineArgs">
        /// Specifies the command line arguments for the parameter server task.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT> WithParameterServerCommandLineArgs(string commandLineArgs);
    }

    /// <summary>
    /// Specifies python script file path.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPython<ParentT> 
    {
        /// <param name="pythonScriptFilePath">The path and file name of the python script to execute the job.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithMasterCommandLineArgs<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }

    /// <summary>
    /// The first stage of the TensorFlow settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithPython<ParentT>
    {
    }

    public interface IWithMasterCommandLineArgs<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition.IWithAttach<ParentT> WithMasterCommandLineArgs(string commandLineArgs);
    }
}