// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.FileServer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents file server reference.
    /// </summary>
    public partial class FileServerImpl  :
        IndexableWrapper<FileServerReference>,
        IFileServer,
        IDefinition<BatchAICluster.Definition.IWithCreate>
    {
        private BatchAIClusterImpl parent;
        public FileServerImpl WithFileServerId(string fileServerId)
        {
            Inner.FileServer = new Models.ResourceId(fileServerId);
            return this;
        }

        public IWithAttach<BatchAICluster.Definition.IWithCreate> WithSourceDirectory(string sourceDirectory)
        {
            Inner.SourceDirectory = sourceDirectory;
            return this;
        }
        
        public FileServerImpl WithMountOptions(string mountOptions)
        {
            Inner.MountOptions = mountOptions;
            return this;
        }

        internal  FileServerImpl(FileServerReference inner, BatchAIClusterImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public IWithCreate Attach()
        {
            parent.AttachFileServer(this);
            return parent;
        }

        public FileServerImpl WithRelativeMountPath(string mountPath)
        {
            Inner.RelativeMountPath = mountPath;
            return this;
        }
    }
}