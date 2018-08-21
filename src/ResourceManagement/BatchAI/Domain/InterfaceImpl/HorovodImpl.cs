// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class HorovodImpl 
    {
        ToolTypeSettings.Horovod.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Horovod.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath) as ToolTypeSettings.Horovod.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }

        IWithAttach<IWithCreate> IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount);
        }

        IWithAttach<IWithCreate> IWithCommandLineArgs<IWithAttach<IWithCreate>>.WithCommandLineArgs(string commandLineArgs)
        {
            return this.WithCommandLineArgs(commandLineArgs);
        }

        IWithAttach<IWithCreate> IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }
    }
}