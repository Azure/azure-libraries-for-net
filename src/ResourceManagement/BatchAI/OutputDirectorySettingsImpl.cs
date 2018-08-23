// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoYWkuaW1wbGVtZW50YXRpb24uT3V0cHV0RGlyZWN0b3J5U2V0dGluZ3NJbXBs
    internal partial class OutputDirectorySettingsImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectory>,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        ///GENMHASH:707BC02F2A19144A8CCDF27A204F85CA:CA53B7BE62B1D1854755EDD010D28892
        public OutputDirectorySettingsImpl(OutputDirectory inner, BatchAIJobImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:6EC394625538AB9373BC9A5EEEC2B9AD
        public BatchAIJobImpl Attach()
        {
            this.parent.AttachOutputDirectory(this);
            return parent;            
        }

        ///GENMHASH:86FC3B42A429A9BBDDE9F2A8DAD28E06:2DA6D87E0865A43302F49608CCAFB9B8
        public OutputDirectorySettingsImpl WithPathPrefix(string pathPrefix)
        {
            Inner.PathPrefix = pathPrefix;
            return this;
        }

        ///GENMHASH:E797CF5A9AAA8BCD755FA2C22E9CC93E:9A8DC0E761EAC4B4849E4A95508111A9
        public OutputDirectorySettingsImpl WithPathSuffix(string pathSuffix)
        {
            Inner.PathSuffix = pathSuffix;
            return this;
        }
    }
}