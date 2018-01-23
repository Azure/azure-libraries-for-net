// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents TensorFlow settings.
    /// </summary>
    public partial class TensorFlowImpl :
        IndexableWrapper<TensorFlowSettings>,
        ITensorFlow,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;
        internal TensorFlowImpl(TensorFlowSettings inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public TensorFlowImpl WithWorkerCount(int workerCount)
        {
            Inner.WorkerCount = workerCount;
            return this;
        }

        public TensorFlowImpl WithMasterCommandLineArgs(string commandLineArgs)
        {
            Inner.MasterCommandLineArgs = commandLineArgs;
            return this;
        }

        public TensorFlowImpl WithWorkerCommandLineArgs(string commandLineArgs)
        {
            Inner.WorkerCommandLineArgs = commandLineArgs;
            return this;
        }

        public IWithCreate Attach()
        {
            parent.AttachTensorFlowSettings(this);
            return parent;
        }

        public TensorFlowImpl WithParameterServerCount(int parameterServerCount)
        {
            Inner.ParameterServerCount = parameterServerCount;
            return this;
        }

        public TensorFlowImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        public TensorFlowImpl WithParameterServerCommandLineArgs(string commandLineArgs)
        {
            Inner.ParameterServerCommandLineArgs = commandLineArgs;
            return this;
        }

        public TensorFlowImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}