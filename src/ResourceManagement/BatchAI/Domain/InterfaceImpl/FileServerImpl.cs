// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class FileServerImpl<ParentT> 
    {
        FileServer.Definition.IWithRelativeMountPath<ParentT> FileServer.Definition.IWithFileServer<ParentT>.WithFileServerId(string fileServerId)
        {
            return this.WithFileServerId(fileServerId);
        }

        FileServer.Definition.IWithAttach<ParentT> FileServer.Definition.IWithMountOptions<ParentT>.WithMountOptions(string mountOptions)
        {
            return this.WithMountOptions(mountOptions);
        }

        FileServer.Definition.IWithAttach<ParentT> FileServer.Definition.IWithRelativeMountPath<ParentT>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath);
        }

        FileServer.Definition.IWithAttach<ParentT> FileServer.Definition.IWithSourceDirectory<ParentT>.WithSourceDirectory(string sourceDirectory)
        {
            return this.WithSourceDirectory(sourceDirectory);
        }
    }
}