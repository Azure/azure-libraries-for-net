// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition
{
    /// <summary>
    /// The final stage of the PyTorch Toolkit settings definition.
    /// At this stage, any remaining optional settings can be specified, or the PyTorch Toolkit settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT>>
    {

        /// <param name="communicationBackend">
        /// Type of the communication backend for distributed jobs.
        /// Valid values are 'TCP', 'Gloo' or 'MPI'. Not required for non-distributed jobs.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT> WithCommunicationBackend(string communicationBackend);
    }

    /// <summary>
    /// The first stage of the PyTorch settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithPython<ParentT>
    {

    }

    /// <summary>
    /// Specifies python script file path to execute the job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPython<ParentT> 
    {

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }

    /// <summary>
    /// Definition of PyTorch toolkit settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition.IWithAttach<ParentT>
    {

    }
}