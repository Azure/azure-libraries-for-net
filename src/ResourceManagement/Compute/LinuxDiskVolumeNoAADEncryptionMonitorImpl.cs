// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DiskVolumeEncryptionStatus for Linux virtual machine.
    /// This implementation monitor status of encrypt-decrypt through new NoAAD encryption extension.
    /// </summary>
    internal partial class LinuxDiskVolumeNoAADEncryptionMonitorImpl :
        IDiskVolumeEncryptionMonitor
    {
        private IComputeManager computeManager;
        private VirtualMachineExtensionInstanceView extensionInstanceView;
        private string rgName;
        private VirtualMachineInner virtualMachine;
        private string vmName;

        /// <summary>
        /// Creates LinuxDiskVolumeNoAADEncryptionMonitorImpl.
        /// </summary>
        /// <param name="virtualMachineId">Resource id of Linux virtual machine to retrieve encryption status from.</param>
        /// <param name="computeManager">Compute manager.</param>
        internal LinuxDiskVolumeNoAADEncryptionMonitorImpl(string virtualMachineId, IComputeManager computeManager)
        {
            this.rgName = ResourceUtils.GroupFromResourceId(virtualMachineId);
            this.vmName = ResourceUtils.NameFromResourceId(virtualMachineId);
            this.computeManager = computeManager;
        }

        private bool HasEncryptionExtensionInstanceView()
        {
            return this.extensionInstanceView != null;
        }

        /// <summary>
        /// Retrieve the virtual machine.
        /// If the virtual machine does not exists then an error observable will be returned.
        /// </summary>
        /// <return>The retrieved virtual machine.</return>
        private async Task<VirtualMachineInner> RetrieveVirtualMachineAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var virtualMachine = await this.computeManager.Inner.VirtualMachines.GetAsync(rgName, vmName, InstanceViewTypes.InstanceView, cancellationToken);

            if (virtualMachine == null)
            {
                throw new Exception($"VM with name '{vmName}' not found (resource group '{rgName}')");
            }
            return virtualMachine;
        }

        public EncryptionStatus DataDiskStatus()
        {
            if (!HasEncryptionExtensionInstanceView())
            {
                return EncryptionStatus.NotEncrypted;
            }
            return LinuxEncryptionExtensionUtil.DataDiskStatus(this.extensionInstanceView);
        }

        public EncryptionStatus OSDiskStatus()
        {
            if (!HasEncryptionExtensionInstanceView())
            {
                return EncryptionStatus.NotEncrypted;
            }
            return LinuxEncryptionExtensionUtil.OSDiskStatus(this.extensionInstanceView);
        }

        public OperatingSystemTypes OSType()
        {
            return OperatingSystemTypes.Linux;
        }

        public string ProgressMessage()
        {
            if (!HasEncryptionExtensionInstanceView())
            {
                return null;
            }
            return LinuxEncryptionExtensionUtil.ProgressMessage(this.extensionInstanceView);
        }

        public IDiskVolumeEncryptionMonitor Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.virtualMachine = await RetrieveVirtualMachineAsync(cancellationToken);

            if (virtualMachine.InstanceView != null && virtualMachine.InstanceView.Extensions != null)
            {
                foreach (var extension in virtualMachine.InstanceView.Extensions)
                {
                    if (extension.Type != null && extension.Type.ToLower().StartsWith(EncryptionExtensionIdentifier.GetPublisherName().ToLower())
                        && extension.Name != null && EncryptionExtensionIdentifier.IsEncryptionTypeName(extension.Name, this.OSType()))
                    {
                        this.extensionInstanceView = extension;
                        break;
                    }
                }
            }
            return this;
        }
    }
}