// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DiskVolumeEncryptionStatus for Windows virtual machine.
    /// This implementation monitor status of encrypt-decrypt through new NoAAD encryption extension.
    /// </summary>
    public partial class WindowsVolumeNoAADEncryptionMonitorImpl :
        IDiskVolumeEncryptionMonitor
    {
        private IComputeManager computeManager;
        private string rgName;
        private VirtualMachineInner virtualMachine;
        private string vmName;

        internal WindowsVolumeNoAADEncryptionMonitorImpl(string virtualMachineId, IComputeManager computeManager)
        {
            this.rgName = ResourceUtils.GroupFromResourceId(virtualMachineId);
            this.vmName = ResourceUtils.NameFromResourceId(virtualMachineId);
            this.computeManager = computeManager;
        }

        /// <summary>
        /// Retrieve the virtual machine.
        /// If the virtual machine does not exists then an error observable will be returned.
        /// </summary>
        /// <return>The retrieved virtual machine.</return>
        private async Task<VirtualMachineInner> RetrieveVirtualMachineAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            virtualMachine = await this.computeManager.Inner.VirtualMachines.GetAsync(rgName, vmName, InstanceViewTypes.InstanceView, cancellationToken);

            if (virtualMachine == null)
            {
                throw new Exception($"VM with name '{vmName}' not found (resource group '{rgName}')");
            }
            return virtualMachine;
        }


        public EncryptionStatus DataDiskStatus()
        {
            if (virtualMachine.InstanceView == null || virtualMachine.InstanceView.Disks == null)
            {
                return EncryptionStatus.Unknown;
            }
            var encryptStatuses = new HashSet<EncryptionStatus>();
            foreach (DiskInstanceView diskInstanceView in virtualMachine.InstanceView.Disks)
            {
                // encryptionSettings will be null for data disks and non-null for os disk.
                if (diskInstanceView.EncryptionSettings != null)
                {
                    continue;
                }
                foreach (InstanceViewStatus status in diskInstanceView.Statuses)
                {
                    EncryptionStatus encryptionStatus = EncryptionExtensionIdentifier.GetEncryptionStatusFromCode(status.Code);
                    if (encryptionStatus != null)
                    {
                        encryptStatuses.Add(encryptionStatus);
                        break;
                    }
                }
            }
            // Derive an overall encryption status for all data disks.
            // --------------

            if (encryptStatuses.Count == 0)
            {
                // Zero disks or disks without encryption state status.
                return EncryptionStatus.Unknown;
            }
            else if (encryptStatuses.Count == 1)
            {
                // Single item indicate all disks are of the same encryption state.
                //
                return encryptStatuses.First();
            }
            //
            // More than one encryptStatuses indicates multiple disks with different encryption states.
            // The precedence is UNKNOWN > NOT_MOUNTED > ENCRYPTION_INPROGRESS > VM_RESTART_PENDING
            if (encryptStatuses.Contains(EncryptionStatus.Unknown))
            {
                return EncryptionStatus.Unknown;
            }
            else if (encryptStatuses.Contains(EncryptionStatus.NotMounted))
            {
                return EncryptionStatus.NotMounted;
            }
            else if (encryptStatuses.Contains(EncryptionStatus.EncryptionInProgress))
            {
                return EncryptionStatus.EncryptionInProgress;
            }
            else if (encryptStatuses.Contains(EncryptionStatus.VMRestartPending))
            {
                return EncryptionStatus.VMRestartPending;
            }
            else
            {
                return EncryptionStatus.Unknown;
            }

        }

        public IDictionary<string, InstanceViewStatus> DiskInstanceViewEncryptionStatuses()
        {
            if (virtualMachine.InstanceView == null || virtualMachine.InstanceView.Disks == null)
            {
                return new Dictionary<string, InstanceViewStatus>();
            }
            //
            var div = new Dictionary<string, InstanceViewStatus>();
            foreach (DiskInstanceView diskInstanceView in virtualMachine.InstanceView.Disks)
            {
                foreach (InstanceViewStatus status in diskInstanceView.Statuses)
                {
                    if (EncryptionExtensionIdentifier.GetEncryptionStatusFromCode(status.Code) != null)
                    {
                        div.Add(diskInstanceView.Name, status);
                        break;
                    }
                }
            }
            return div;
        }

        public EncryptionStatus OSDiskStatus()
        {
            if (virtualMachine.InstanceView == null || virtualMachine.InstanceView.Disks == null)
            {
                return EncryptionStatus.Unknown;
            }
            foreach (DiskInstanceView diskInstanceView in virtualMachine.InstanceView.Disks)
            {
                // encryptionSettings will be set only for OSDisk
                if (diskInstanceView.EncryptionSettings != null)
                {
                    foreach (InstanceViewStatus status in diskInstanceView.Statuses)
                    {
                        EncryptionStatus encryptionStatus = EncryptionExtensionIdentifier.GetEncryptionStatusFromCode(status.Code);
                        if (encryptionStatus != null)
                        {
                            return encryptionStatus;
                        }
                    }
                    break;
                }
            }
            return EncryptionStatus.Unknown;
        }

        public OperatingSystemTypes OSType()
        {
            return OperatingSystemTypes.Windows;
        }

        public string ProgressMessage()
        {
            return $"OSDisk: {OSDiskStatus()} DataDisk: {DataDiskStatus()}";
        }

        public IDiskVolumeEncryptionMonitor Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.virtualMachine = await RetrieveVirtualMachineAsync(cancellationToken);
            return this;
        }
    }
}