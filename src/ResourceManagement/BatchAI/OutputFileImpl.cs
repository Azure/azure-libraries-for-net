// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Implementation for  OutputFile.
    /// </summary>
    public sealed partial class OutputFileImpl :
        IndexableWrapper<File>,
        IOutputFile
    {
        public string DownloadUrl()
        {
            return Inner.DownloadUrl;
        }


        public string Name => Inner.Name;

        public long ContentLength()
        {
            return Inner.ContentLength.GetValueOrDefault();
        }
        public FileType FileType()
        {
            return Inner.FileType;
        }
        public DateTime LastModified()
        {
            return Inner.LastModified.GetValueOrDefault();
        }

        internal OutputFileImpl(File innerModel)
            : base(innerModel)
        {
        }
    }
}