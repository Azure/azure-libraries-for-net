// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class ChainerImpl 
    {
        ToolTypeSettings.Chainer.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Chainer.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath);
        }

        IWithAttach<IWithCreate> IWithCommandLineArgs<IWithAttach<IWithCreate>>.WithCommandLineArgs(string commandLineArgs)
        {
            return this.WithCommandLineArgs(commandLineArgs);
        }

        IWithAttach<IWithCreate> IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount);
        }

        IWithAttach<IWithCreate> IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }
    }
}