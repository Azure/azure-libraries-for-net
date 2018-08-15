// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class CaffeImpl 
    {
        /// <param>PythonScriptFilePath.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.Caffe.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Caffe.Definition.IWithFileType<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath);
        }

        /// <param name="configFilePath">The path of the config file.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.Caffe.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Caffe.Definition.IWithFileType<BatchAIJob.Definition.IWithCreate>.WithConfigFile(string configFilePath)
        {
            return this.WithConfigFile(configFilePath);
        }

        public IWithAttach<IWithCreate> withPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }

        IWithAttach<IWithCreate> ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<IWithAttach<IWithCreate>>.WithCommandLineArgs(string commandLineArgs)
        {
            return this.WithCommandLineArgs(commandLineArgs);
        }

        IWithAttach<IWithCreate> ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount);
        }

        IWithAttach<IWithCreate> IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }
    }
}