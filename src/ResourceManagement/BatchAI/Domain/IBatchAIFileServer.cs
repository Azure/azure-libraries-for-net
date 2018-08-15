// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Entry point for Batch AI file server management API in Azure.
    /// </summary>
    public interface IBatchAIFileServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.Models.FileServerInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer>
    {
        /// <summary>
        /// Gets Specifies the identifier of the subnet.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Subnet { get; }

        /// <summary>
        /// Gets Time when the FileServer was created.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Gets Details of the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.MountSettings MountSettings { get; }

        /// <summary>
        /// Gets Time when the status was changed.
        /// </summary>
        System.DateTime ProvisioningStateTransitionTime { get; }

        /// <summary>
        /// Gets Settings for the data disk which would be created for the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.DataDisks DataDisks { get; }

        /// <summary>
        /// Gets The size of the virtual machine of the File Server.
        /// For information about available VM sizes for File Server from the
        /// Virtual Machines Marketplace, see Sizes for Virtual Machines (Linux).
        /// </summary>
        string VMSize { get; }

        /// <summary>
        /// Gets Specifies the provisioning state of the File Server.
        /// Possible values: creating - The File Server is getting created. updating
        /// - The File Server creation has been accepted and it is getting updated.
        /// deleting - The user has requested that the File Server be deleted, and
        /// it is in the process of being deleted. failed - The File Server creation
        /// has failed with the specified errorCode. Details about the error code
        /// are specified in the message field. succeeded - The File Server creation
        /// has succeeded. Possible values include: 'creating', 'updating',
        /// 'deleting', 'succeeded', 'failed'.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.FileServerProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets SSH settings for the File Server.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.SshConfiguration SshConfiguration { get; }
    }
}