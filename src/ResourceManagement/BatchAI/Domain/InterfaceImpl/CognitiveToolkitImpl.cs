// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;

    public partial class CognitiveToolkitImpl 
    {
        /// <param name="pythonScriptFilePath">The path and file name of the python script to execute the job.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.CognitiveToolkit.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.CognitiveToolkit.Definition.IWithLanguageType<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath) as ToolTypeSettings.CognitiveToolkit.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate>;
        }

        /// <param name="configFilePath">Path of the config file.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.CognitiveToolkit.Definition.IWithLanguageType<BatchAIJob.Definition.IWithCreate>.WithBrainScript(string configFilePath)
        {
            return this.WithBrainScript(configFilePath) as ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }

        IWithAttach<IWithCreate> IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount) as ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }

        IWithAttach<IWithCreate> IWithCommandLineArgs<IWithAttach<IWithCreate>>.WithCommandLineArgs(string commandLineArgs)
        {
            return this.WithCommandLineArgs(commandLineArgs) as ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }

        IWithAttach<IWithCreate> IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path) as ToolTypeSettings.CognitiveToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }
    }
}