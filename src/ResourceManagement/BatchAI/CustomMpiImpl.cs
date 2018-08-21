// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents the settings for a custom MPI job.
    /// </summary>
    public partial class CustomMpiImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.CustomMpiSettings>,
        ICustomMpi,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        internal  CustomMpiImpl(CustomMpiSettings inner, BatchAIJobImpl parent) : base(inner)
        {
            this.parent = parent;
        }

        public IWithCreate Attach()
        {
            this.parent.AttachCustomMpiSettings(this);
            return parent;;
        }

        public IBatchAIJob Parent()
        {
            return parent;
        }

        public CustomMpiImpl WithCommandLine(string commandLine)
        {
            Inner.CommandLine = commandLine;
            return this;
        }

        public CustomMpiImpl WithProcessCount(int processCount)
        {
            Inner.ProcessCount = processCount;
            return this;
        }
    }
}