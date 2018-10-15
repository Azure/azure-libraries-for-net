// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents Microsoft Cognitive Toolkit settings.
    /// </summary>
    public partial class CognitiveToolkitImpl :
        IndexableWrapper<CNTKsettings>,
        ICognitiveToolkit,
        IDefinition<IWithCreate>
    {
        private string _brainScript;
        private string _python;
        private BatchAIJobImpl parent;

        public CognitiveToolkitImpl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        public CognitiveToolkitImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }

        public CognitiveToolkitImpl WithBrainScript(string configFilePath)
        {
            Inner.LanguageType = _brainScript;
            Inner.ConfigFilePath = configFilePath;
            return this;
        }

        public IWithCreate Attach()
        {
            parent.AttachCntkSettings(this);
            return parent;
        }

        internal CognitiveToolkitImpl(CNTKsettings inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public CognitiveToolkitImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public CognitiveToolkitImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.LanguageType = _python;
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}