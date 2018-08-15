// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    public sealed partial class OutputFileImpl 
    {
        /// <summary>
        /// Gets the file size.
        /// </summary>
        long Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile.ContentLength
        {
            get
            {
                return this.ContentLength();
            }
        }

        /// <summary>
        /// Gets the time at which the file was last modified.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile.LastModified
        {
            get
            {
                return this.LastModified();
            }
        }

        /// <summary>
        /// Gets file downloand url, example:
        /// https://mystg.blob.core.windows.net/mycontainer/myModel_1.dnn.
        /// This will be returned only if the model has been archived. During job
        /// run, this won't be returned and customers can use SSH tunneling to
        /// download. Users can use Get Remote Login Information API to get the IP
        /// address and port information of all the compute nodes running the job.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile.DownloadUrl
        {
            get
            {
                return this.DownloadUrl();
            }
        }
        /// <summary>
        /// Gets information about file type.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.FileType Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile.FileType
        {
            get
            {
                return this.FileType();
            }
        }
    }
}