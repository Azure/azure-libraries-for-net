// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    public interface IWithAttachAndPythonInterpreter<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<ParentT>,
        HasPythonInterpreter.Definition.IWithPythonInterpreter<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// Definition of azure cognitive toolkit settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttachAndPythonInterpreter<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the Microsoft Cognitive Toolkit settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithLanguageType<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the Microsoft Cognitive Toolkit settings definition.
    /// At this stage, any remaining optional settings can be specified, or the Microsoft Cognitive Toolkit settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<ParentT>>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// Specifies the language type and script/config file path to use for Microsoft Cognitive Toolkit job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithLanguageType<ParentT> 
    {
        /// <param name="configFilePath">Path of the config file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<ParentT> WithBrainScript(string configFilePath);

        /// <param name="pythonScriptFilePath">The path and file name of the python script to execute the job.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition.IWithAttachAndPythonInterpreter<ParentT> WithPythonScriptFile(string pythonScriptFilePath);
    }
}