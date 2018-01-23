// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Represents Chainer settings.
    /// </summary>
    public partial class ChainerImpl :
        IndexableWrapper<ChainerSettings>,
        IChainer,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;
        public IBatchAIJob Parent()
        {
            return parent;
        }

        public ChainerImpl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        public ChainerImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }

        internal ChainerImpl(ChainerSettings inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public IWithCreate Attach()
        {
            parent.AttachChainerSettings(this);
            return parent;
        }

        public ChainerImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public ChainerImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }

        IWithCreate IInDefinition<IWithCreate>.Attach()
        {
            this.parent.AttachChainerSettings(this);
            return parent;
        }
    }
}