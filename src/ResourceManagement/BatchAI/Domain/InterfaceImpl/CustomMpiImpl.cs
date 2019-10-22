// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class CustomMpiImpl 
    {
        ToolTypeSettings.CustomMpi.Definition.IWithAttachAndProcessCount<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.CustomMpi.Definition.IWithCommandLine<BatchAIJob.Definition.IWithCreate>.WithCommandLine(string commandLine)
        {
            return this.WithCommandLine(commandLine) as ToolTypeSettings.CustomMpi.Definition.IWithAttachAndProcessCount<BatchAIJob.Definition.IWithCreate>;
        }

        IWithAttach<IWithCreate> IWithProcessCount<IWithAttach<IWithCreate>>.WithProcessCount(int processCount)
        {
            return this.WithProcessCount(processCount);
        }
    }
}