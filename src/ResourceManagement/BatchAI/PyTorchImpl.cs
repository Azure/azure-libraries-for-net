// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.PyTorch.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition;

    /// <summary>
    /// Represents PyTorch settings.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoYWkuaW1wbGVtZW50YXRpb24uUHlUb3JjaEltcGw=
    internal partial class PyTorchImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.PyTorchSettings>,
        IPyTorch,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        ///GENMHASH:3BA6C1C7707D6F2E7C086129ABAC4795:CA53B7BE62B1D1854755EDD010D28892
        internal  PyTorchImpl(PyTorchSettings inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:80F5B190D5698752948457262640429B
        public IWithCreate Attach()
        {
            this.parent.AttachPyTorchSettings(this);
            return parent;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IBatchAIJob Parent()
        {
            return parent;
        }

        ///GENMHASH:16C1AEF32E66D113A6FD903FA663BA61:B1529E5EF5F8D7DA907A9E0B436BE6FA
        public PyTorchImpl WithCommandLineArgs(string commandLineArgs)
        {
            Inner.CommandLineArgs = commandLineArgs;
            return this;
        }

        ///GENMHASH:7779C59D9E62984EA7AF1DB9F6EC8B5A:E2B0299880B2E2DEA4AA9BD6FBA3A70D
        public PyTorchImpl WithCommunicationBackend(string communicationBackend)
        {
            Inner.CommunicationBackend = communicationBackend;
            return this;
        }

        ///GENMHASH:A56ECC255F2B87B34DB47619D46F3357:6FEA1DF475DB9E9230755E91B99BD1E4
        public PyTorchImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }

        ///GENMHASH:FE51DEF0B6A13FC6F00ADB7ED5F64D44:2F1B95B353781FABCF08F7CF22E4256C
        public PyTorchImpl WithPythonInterpreterPath(string path)
        {
            Inner.PythonInterpreterPath = path;
            return this;
        }

        ///GENMHASH:D44D2CDF7F2A6BCBA441417A161347D8:6C05FDEAC8B1F27F2A74413EC351AF4D
        public PyTorchImpl WithPythonScriptFile(string pythonScriptFilePath)
        {
            Inner.PythonScriptFilePath = pythonScriptFilePath;
            return this;
        }
    }
}