// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe2.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Caffe2 settings.
    /// </summary>
    public partial class Caffe2Impl :
        IndexableWrapper<Caffe2Settings>,
        ICaffe2,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        public Caffe2Impl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        public IWithCreate Attach()
        {
            parent.AttachCaffe2Settings(this);
            return parent;
        }

        internal Caffe2Impl(Caffe2Settings inner, BatchAIJobImpl parent)
           : base(inner)
        {
            this.parent = parent;
        }

        public Caffe2Impl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public Caffe2Impl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}