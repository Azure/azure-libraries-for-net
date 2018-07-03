// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    internal partial class TroubleshootingImpl
    {
        /// <summary>
        /// Set the storageAccounId value.
        /// </summary>
        /// <param name="storageAccountId">The ID for the storage account to save the troubleshoot result.</param>
        /// <return>The next stage of definition.</return>
        Troubleshooting.Definition.IWithStoragePath Troubleshooting.Definition.IWithStorageAccount.WithStorageAccount(string storageAccountId)
        {
            return this.WithStorageAccount(storageAccountId);
        }

        /// <summary>
        /// Gets the result code of the troubleshooting.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.Code
        {
            get
            {
                return this.Code();
            }
        }

        /// <summary>
        /// Gets The start time of the troubleshooting.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets information from troubleshooting.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.TroubleshootingDetails> Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.Results
        {
            get
            {
                return this.Results();
            }
        }

        /// <summary>
        /// Gets the end time of the troubleshooting.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <summary>
        /// Gets the resource identifier of the target resource against which the action
        /// is to be performed.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.TargetResourceId
        {
            get
            {
                return this.TargetResourceId();
            }
        }

        /// <summary>
        /// Gets the path to the blob to save the troubleshoot result in.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.StoragePath
        {
            get
            {
                return this.StoragePath();
            }
        }

        /// <summary>
        /// Gets id of the storage account where troubleshooting information was saved.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITroubleshooting.StorageId
        {
            get
            {
                return this.StorageId();
            }
        }

        Troubleshooting.Definition.IWithExecute Troubleshooting.Definition.IWithStoragePath.WithStoragePath(string storagePath)
        {
            return this.WithStoragePath(storagePath);
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Set the targetResourceId value (virtual network gateway or virtual network gateway connecyion id).
        /// </summary>
        /// <param name="targetResourceId">The targetResourceId value to set.</param>
        /// <return>The next stage of definition.</return>
        Troubleshooting.Definition.IWithStorageAccount Troubleshooting.Definition.IWithTargetResource.WithTargetResourceId(string targetResourceId)
        {
            return this.WithTargetResourceId(targetResourceId);
        }
    }
}