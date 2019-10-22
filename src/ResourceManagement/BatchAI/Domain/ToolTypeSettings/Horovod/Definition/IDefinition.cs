// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition
{

    /// <summary>
    /// The final stage of the Horovod job settings definition.
    /// At this stage, any remaining optional settings can be specified, or the Horovod job settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithAttach<ParentT>>
    {

    }

    /// <summary>
    /// Specifies python script file path to execute the job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPython<ParentT> 
    {

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithAttach<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }

    /// <summary>
    /// Definition of the settings for Horovod job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The first stage of the Horovode job settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IWithPython<ParentT>
    {

    }
}