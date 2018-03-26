// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models.HasMountVolumes.Definition
{
    /// <summary>
    /// Defines the volumes to mount on the cluster.
    /// </summary>
    public interface IWithMountVolumes<ReturnT> 
    {

        /// <summary>
        /// Begins the definition of Azure blob file system reference to be mounted on each cluster node.
        /// </summary>
        /// <return>The first stage of Azure blob file system reference definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.AzureBlobFileSystem.Definition.IBlank<ReturnT> DefineAzureBlobFileSystem();

        /// <summary>
        /// Begins the definition of Azure file share reference to be mounted on each cluster node.
        /// </summary>
        /// <return>The first stage of file share reference definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.AzureFileShare.Definition.IBlank<ReturnT> DefineAzureFileShare();

        /// <summary>
        /// Begins the definition of Azure file server reference.
        /// </summary>
        /// <return>The first stage of file server reference definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition.IBlank<ReturnT> DefineFileServer();

        /// <summary>
        /// Specifies the details of the file system to mount on the compute cluster nodes.
        /// </summary>
        /// <param name="mountCommand">Command used to mount the unmanaged file system.</param>
        /// <param name="relativeMountPath">The relative path on the compute cluster node where the file system will be mounted.</param>
        /// <return>The next stage of Batch AI cluster definition.</return>
        ReturnT WithUnmanagedFileSystem(string mountCommand, string relativeMountPath);
    }
}