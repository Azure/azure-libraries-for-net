// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Tenant.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRG9tYWluTGVnYWxBZ3JlZW1lbnRJbXBs
    internal partial class VirtualMachineInstanceViewImpl
    {
        int IVirtualMachineInstanceView.PlatformUpdateDomain
        {
            get {
                return this.PlatformUpdateDomain().HasValue ? this.PlatformUpdateDomain().Value : 0;
            }
        }

        int IVirtualMachineInstanceView.PlatformFaultDomain
        {
            get
            {
                return this.PlatformFaultDomain().HasValue ? this.PlatformFaultDomain().Value : 0;
            }
        }

        string IVirtualMachineInstanceView.ComputerName
        {
            get
            {
                return this.ComputerName();
            }
        }

        string IVirtualMachineInstanceView.OsName
        {
            get
            {
                return this.OsName();
            }
        }

        string IVirtualMachineInstanceView.OsVersion
        {
            get
            {
                return this.OsVersion();
            }
        }

        string IVirtualMachineInstanceView.RdpThumbPrint
        {
            get
            {
                return this.RdpThumbPrint();
            }
        }

        VirtualMachineAgentInstanceView IVirtualMachineInstanceView.VmAgent
        {
            get
            {
                return this.VmAgent();
            }
        }

        MaintenanceRedeployStatus IVirtualMachineInstanceView.MaintenanceRedeployStatus
        {
            get
            {
                return this.MaintenanceRedeployStatus();
            }
        }

        IList<DiskInstanceView> IVirtualMachineInstanceView.Disks
        {
            get
            {
                return this.Disks();
            }
        }

        IList<VirtualMachineExtensionInstanceView> IVirtualMachineInstanceView.Extensions
        {
            get
            {
                return this.Extensions();
            }
        }

        BootDiagnosticsInstanceView IVirtualMachineInstanceView.BootDiagnostics
        {
            get
            {
                return this.BootDiagnostics();
            }
        }

        IList<InstanceViewStatus> IVirtualMachineInstanceView.Statuses
        {
            get
            {
                return this.Statuses();
            }
        }
    }
}