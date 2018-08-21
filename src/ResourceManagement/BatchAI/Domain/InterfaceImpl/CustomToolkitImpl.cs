// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class CustomToolkitImpl 
    {
        ToolTypeSettings.CustomToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.CustomToolkit.Definition.IWithCommandLine<BatchAIJob.Definition.IWithCreate>.WithCommandLine(string commandLine)
        {
            return this.WithCommandLine(commandLine) as ToolTypeSettings.CustomToolkit.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }
    }
}