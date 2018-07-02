// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class FileServerImpl 
    {
        FileServer.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate> FileServer.Definition.IWithFileServer<BatchAICluster.Definition.IWithCreate>.WithFileServerId(string fileServerId)
        {
            return this.WithFileServerId(fileServerId);
        }

        FileServer.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> FileServer.Definition.IWithMountOptions<BatchAICluster.Definition.IWithCreate>.WithMountOptions(string mountOptions)
        {
            return this.WithMountOptions(mountOptions);
        }

        FileServer.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> FileServer.Definition.IWithRelativeMountPath<BatchAICluster.Definition.IWithCreate>.WithRelativeMountPath(string mountPath)
        {
            return this.WithRelativeMountPath(mountPath);
        }

        FileServer.Definition.IWithAttach<BatchAICluster.Definition.IWithCreate> FileServer.Definition.IWithSourceDirectory<BatchAICluster.Definition.IWithCreate>.WithSourceDirectory(string sourceDirectory)
        {
            return this.WithSourceDirectory(sourceDirectory);
        }
    }
}