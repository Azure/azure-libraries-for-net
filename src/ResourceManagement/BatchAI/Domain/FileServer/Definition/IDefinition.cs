// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    public interface IWithRelativeMountPath<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithAttach<ParentT> WithRelativeMountPath(string mountPath);
    }

    /// <summary>
    /// Definition of file server reference.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithRelativeMountPath<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithAttach<ParentT>
    {
    }

    public interface IWithMountOptions<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithAttach<ParentT> WithMountOptions(string mountOptions);
    }

    public interface IWithFileServer<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithRelativeMountPath<ParentT> WithFileServerId(string fileServerId);
    }

    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithSourceDirectory<ParentT>,
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithMountOptions<ParentT>
    {
    }

    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithFileServer<ParentT>
    {
    }

    public interface IWithSourceDirectory<ParentT> 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IWithAttach<ParentT> WithSourceDirectory(string sourceDirectory);
    }
}