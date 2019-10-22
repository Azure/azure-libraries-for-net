// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of Batch AI output file.
    /// </summary>
    public interface IOutputFile  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<File>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName
    {
        /// <summary>
        /// Gets file downloand url, example:
        /// https://mystg.blob.core.windows.net/mycontainer/myModel_1.dnn.
        /// This will be returned only if the model has been archived. During job
        /// run, this won't be returned and customers can use SSH tunneling to
        /// download. Users can use Get Remote Login Information API to get the IP
        /// address and port information of all the compute nodes running the job.
        /// </summary>
        string DownloadUrl { get; }

        /// <summary>
        /// Gets the file size.
        /// </summary>
        long ContentLength { get; }
        /// <summary>
        /// Gets information about file type.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.FileType FileType { get; }
        /// <summary>
        /// Gets the time at which the file was last modified.
        /// </summary>
        System.DateTime LastModified { get; }
    }
}