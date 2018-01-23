// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Caffe settings.
    /// </summary>
    public partial class CaffeImpl :
        IndexableWrapper<CaffeSettings>,
        ICaffe,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;
        internal CaffeImpl(CaffeSettings inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public CaffeImpl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        public CaffeImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }

        public IWithCreate Attach()
        {
            this.parent.AttachCaffeSettings(this);
            return parent;
        }

        public CaffeImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public CaffeImpl WithConfigFile(string configFilePath)
        {
            Inner.ConfigFilePath = configFilePath;
            return this;
        }

        public CaffeImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}