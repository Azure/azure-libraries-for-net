// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class WindowsVolumeLegacyEncryptionMonitorImpl
    {
        /// <summary>
        /// Gets data disks encryption status.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.EncryptionStatus Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.DataDiskStatus
        {
            get
            {
                return this.DataDiskStatus();
            }
        }

        /// <summary>
        /// Gets operating system disk encryption status.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.EncryptionStatus Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.OSDiskStatus
        {
            get
            {
                return this.OSDiskStatus();
            }
        }

        /// <summary>
        /// Gets operating system type of the virtual machine.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the encryption progress message.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.ProgressMessage
        {
            get
            {
                return this.ProgressMessage();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor>.Refresh()
        {
            return this.Refresh();
        }

        /// <return>A representation of the deferred computation of this call returning the encryption status once the refresh is done.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }
    }
}