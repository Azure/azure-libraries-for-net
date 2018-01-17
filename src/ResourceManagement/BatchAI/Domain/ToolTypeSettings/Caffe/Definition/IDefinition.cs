// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Definition of Caffe settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttachAndPythonInterpreter<ParentT>
    {
    }

    public interface IWithAttachAndPythonInterpreter<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The first stage of the Caffe settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithFileType<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the Caffe settings definition.
    /// At this stage, any remaining optional settings can be specified, or the Caffe settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// Specifies the path and file name of the python script to execute the job or the path of the config file.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFileType<ParentT> 
    {
        /// <param name="configFilePath">The path of the config file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttach<ParentT> WithConfigFile(string configFilePath);

        /// <param>PythonScriptFilePath.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition.IWithAttachAndPythonInterpreter<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }
}