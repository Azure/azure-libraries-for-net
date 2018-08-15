// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Definition of the settings for a custom toolkit job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// The first stage of the custom toolkit job settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition.IWithCommandLine<ParentT>
    {

    }

    /// <summary>
    /// The final stage of the custom toolkit job settings definition.
    /// At this stage, any remaining optional settings can be specified, or the custom toolkit job settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {

    }

    /// <summary>
    /// Specifies the command line to execute the custom toolkit Job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCommandLine<ParentT> 
    {

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition.IWithAttach<ParentT> WithCommandLine(string commandLine);
    }
}