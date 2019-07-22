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
    internal sealed partial class VirtualMachineInstanceViewImpl :
        Wrapper<VirtualMachineInstanceView>,
        IVirtualMachineInstanceView
    {
        internal VirtualMachineInstanceViewImpl(VirtualMachineInstanceView inner)
            : base(inner)
        {
        }

        public int? PlatformUpdateDomain()
        {
            return Inner.PlatformUpdateDomain;
        }

        public int? PlatformFaultDomain()
        {
            return Inner.PlatformFaultDomain;
        }

        public string ComputerName()
        {
            return Inner.ComputerName;
        }

        public string OsName()
        {
            return Inner.OsName;
        }

        public string OsVersion()
        {
            return Inner.OsVersion;
        }

        public string RdpThumbPrint()
        {
            return Inner.RdpThumbPrint;
        }

        public VirtualMachineAgentInstanceView VmAgent()
        {
            return Inner.VmAgent;
        }

        public MaintenanceRedeployStatus MaintenanceRedeployStatus()
        {
            return Inner.MaintenanceRedeployStatus;
        }

        public IList<DiskInstanceView> Disks()
        {
            return Inner.Disks;
        }

        public IList<VirtualMachineExtensionInstanceView> Extensions()
        {
            return Inner.Extensions;
        }

        public BootDiagnosticsInstanceView BootDiagnostics()
        {
            return Inner.BootDiagnostics;
        }

        public IList<InstanceViewStatus> Statuses()
        {
            return Inner.Statuses;
        }
    }
}