// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Horovod settings.
    /// </summary>
    public partial class HorovodImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.HorovodSettings>,
        IHorovod,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        internal  HorovodImpl(HorovodSettings inner, BatchAIJobImpl parent) : base(inner)
        {
            this.parent = parent;
        }

        public IWithCreate Attach()
        {
            this.parent.AttachHorovodSettings(this);
            return parent;
        }

        public IBatchAIJob Parent()
        {
            return parent;
        }

        public HorovodImpl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        public HorovodImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }

        public HorovodImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public HorovodImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}