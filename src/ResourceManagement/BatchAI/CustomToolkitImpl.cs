// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents the settings for a custom toolkit job settings.
    /// </summary>
    public partial class CustomToolkitImpl  :
        IndexableWrapper<CustomToolkitSettings>,
        ICustomToolkit,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        internal  CustomToolkitImpl(CustomToolkitSettings inner, BatchAIJobImpl parent) : base(inner)
        {
            this.parent = parent;
        }

        public IWithCreate Attach()
        {
            this.parent.AttachCustomToolkitSettings(this);
            return parent;
        }

        public IBatchAIJob Parent()
        {
            return parent;
        }

        public CustomToolkitImpl WithCommandLine(string commandLine)
        {
            Inner.CommandLine = commandLine;
            return this;
        }
    }
}