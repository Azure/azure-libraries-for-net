// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class PyTorchImpl 
    {
        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAIJob.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<BatchAIJob.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        IWithAttach<IWithCreate> ToolTypeSettings.HasCommandLineArgs.Definition.IWithCommandLineArgs<IWithAttach<IWithCreate>>.WithCommandLineArgs(string commandLineArgs)
        {
            return this.WithCommandLineArgs(commandLineArgs);
        }

        IWithAttach<IWithCreate> ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount);
        }

        /// <param name="communicationBackend">
        /// Type of the communication backend for distributed jobs.
        /// Valid values are 'TCP', 'Gloo' or 'MPI'. Not required for non-distributed jobs.
        /// This property is optional for single machine training.
        /// </param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.PyTorch.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.PyTorch.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>.WithCommunicationBackend(string communicationBackend)
        {
            return this.WithCommunicationBackend(communicationBackend);
        }

        ToolTypeSettings.PyTorch.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.HasPythonInterpreter.Definition.IWithPythonInterpreter<IWithAttach<IWithCreate>>.WithPythonInterpreterPath(string path)
        {
            return this.WithPythonInterpreterPath(path);
        }

        ToolTypeSettings.PyTorch.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.PyTorch.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath);
        }
    }
}