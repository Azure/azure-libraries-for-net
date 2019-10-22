// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Virtual Machine Instance View.
    /// </summary>
    public interface IVirtualMachineInstanceView :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineInstanceView>
    {
        /// <summary>
        /// Gets or sets specifies the update domain of the virtual machine.
        /// </summary>
        int PlatformUpdateDomain { get; }

        /// <summary>
        /// Gets or sets specifies the fault domain of the virtual machine.
        /// </summary>
        int PlatformFaultDomain { get; }

        /// <summary>
        /// Gets or sets the computer name assigned to the virtual machine.
        /// </summary>
        string ComputerName { get; }

        /// <summary>
        /// Gets or sets the Operating System running on the virtual machine.
        /// </summary>
        string OsName { get; }

        /// <summary>
        /// Gets or sets the version of Operating System running on the virtual
        /// machine.
        /// </summary>
        string OsVersion { get; }

        /// <summary>
        /// Gets or sets the Remote desktop certificate thumbprint.
        /// </summary>
        string RdpThumbPrint { get; }

        /// <summary>
        /// Gets or sets the VM Agent running on the virtual machine.
        /// </summary>
        VirtualMachineAgentInstanceView VmAgent { get; }

        /// <summary>
        /// Gets or sets the Maintenance Operation status on the virtual
        /// machine.
        /// </summary>
        MaintenanceRedeployStatus MaintenanceRedeployStatus { get; }

        /// <summary>
        /// Gets or sets the virtual machine disk information.
        /// </summary>
        IList<DiskInstanceView> Disks { get; }

        /// <summary>
        /// Gets or sets the extensions information.
        /// </summary>
        IList<VirtualMachineExtensionInstanceView> Extensions { get; }

        /// <summary>
        /// Gets or sets boot Diagnostics is a debugging feature which allows
        /// you to view Console Output and Screenshot to diagnose VM status.
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; You can easily view the output
        /// of your console log. &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; Azure
        /// also enables you to see a screenshot of the VM from the hypervisor.
        /// </summary>
        BootDiagnosticsInstanceView BootDiagnostics { get; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        IList<InstanceViewStatus> Statuses { get; }
    }
}