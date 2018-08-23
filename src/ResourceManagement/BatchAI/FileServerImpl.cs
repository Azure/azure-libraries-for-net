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
    public partial class FileServerImpl<ParentT> :
        IndexableWrapper<FileServerReference>,
        IFileServer,
        IDefinition<ParentT>
    {
        private IHasMountVolumes parent;
        public FileServerImpl<ParentT> WithFileServerId(string fileServerId)
        {
            Inner.FileServer = new Models.ResourceId(fileServerId);
            return this;
        }

        public IWithAttach<ParentT> WithSourceDirectory(string sourceDirectory)
        {
            Inner.SourceDirectory = sourceDirectory;
            return this;
        }

        public FileServerImpl<ParentT> WithMountOptions(string mountOptions)
        {
            Inner.MountOptions = mountOptions;
            return this;
        }

        internal FileServerImpl(FileServerReference inner, ParentT parent)
            : base(inner)
        {
            this.parent = (IHasMountVolumes) parent;
        }

        public ParentT Attach()
        {
            parent.AttachFileServer(this);
            return (ParentT) parent;
        }

        public FileServerImpl<ParentT> WithRelativeMountPath(string mountPath)
        {
            Inner.RelativeMountPath = mountPath;
            return this;
        }
    }
}