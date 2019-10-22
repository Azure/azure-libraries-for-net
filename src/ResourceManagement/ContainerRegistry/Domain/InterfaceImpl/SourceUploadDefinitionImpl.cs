// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    internal partial class SourceUploadDefinitionImpl 
    {
        /// <summary>
        /// Gets the the relative path to the source; this is used to submit the subsequent queue build request.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition.RelativePath
        {
            get
            {
                return this.RelativePath;
            }
        }

        /// <summary>
        /// Gets the URL where the client can upload the source.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition.UploadUrl
        {
            get
            {
                return this.UploadUrl;
            }
        }
    }
}