// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to attach mount volumes.
    /// </summary>
    public interface IHasMountVolumes 
    {

        /// <param name="azureBlobFileSystem">Azure blob filesystem to be attached.</param>
        void AttachAzureBlobFileSystem(IAzureBlobFileSystem azureBlobFileSystem);

        /// <param name="azureFileShare">Azure fileshare to be attached.</param>
        void AttachAzureFileShare(IAzureFileShare azureFileShare);

        /// <param name="fileServer">File server to be attached.</param>
        void AttachFileServer(IFileServer fileServer);
    }
}