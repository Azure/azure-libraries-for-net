// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Specifies python script file path to execute the job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPython<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttachAndPythonInterpreter<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }

    /// <summary>
    /// The first stage of the Chainer settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithPython<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the Chainer settings definition.
    /// At this stage, any remaining optional settings can be specified, or the Chainer settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// Definition of Chainer settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttachAndPythonInterpreter<ParentT>
    {
    }

    public interface IWithAttachAndPythonInterpreter<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition.IWithAttach<ParentT>>
    {
    }
}