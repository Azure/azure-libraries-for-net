// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition
{
    /// <summary>
    /// At this stage, any process count settings can be specified, or the custom MPI job settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachAndProcessCount<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition.IWithProcessCount<Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IWithAttach<ParentT>>
    {

    }

    /// <summary>
    /// The final stage of the custom MPI job settings definition.
    /// At this stage, any remaining optional settings can be specified, or the custom MPI job settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {

    }

    /// <summary>
    /// Definition of the settings for a custom MPI job.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IWithAttachAndProcessCount<ParentT>
    {

    }

    /// <summary>
    /// The first stage of the custom MPI job settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IWithCommandLine<ParentT>
    {

    }

    /// <summary>
    /// Specifies the program and program command line parameters to be executed by mpi runtime.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCommandLine<ParentT> 
    {

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IWithAttachAndProcessCount<ParentT> WithCommandLine(string commandLine);
    }
}