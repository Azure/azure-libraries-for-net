// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// Definition of output directory settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IWithAttach<ParentT>
    {

    }

    /// <summary>
    /// Specifies the suffix path where the output directory will be created. E.g. models.
    /// You can find the full path to the output directory by combining
    /// pathPrefix, jobOutputDirectoryPathSegment (reported by get job) and
    /// pathSuffix.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPathSuffix<ParentT> 
    {

        /// <param name="pathSuffix">Path prefix.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IWithAttach<ParentT> WithPathSuffix(string pathSuffix);
    }

    /// <summary>
    /// Specifies the prefix path where the output directory will be created.
    /// NOTE: This is an absolute path to prefix. E.g.
    /// $AZ_BATCHAI_MOUNT_ROOT/MyNFS/MyLogs. You can find the full path to the
    /// output directory by combining pathPrefix, jobOutputDirectoryPathSegment
    /// (reported by get job) and pathSuffix.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPathPrefix<ParentT> 
    {

        /// <param name="pathPrefix">Path prefix.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IWithAttach<ParentT> WithPathPrefix(string pathPrefix);
    }

    /// <summary>
    /// The first stage of the output directory settings definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IWithPathPrefix<ParentT>
    {

    }

    /// <summary>
    /// The final stage of the output directory settings definition.
    /// At this stage, any remaining optional settings can be specified, or the output directory settings definition
    /// can be attached to the parent Batch AI job definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IWithPathSuffix<ParentT>
    {

    }
}