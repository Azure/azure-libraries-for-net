// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachineBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets the availability zones assigned to the virtual machine.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones { get; }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the virtual machine.
        /// </summary>
        bool IsManagedServiceIdentityEnabled { get; }

        /// <summary>
        /// Gets the type of Managed Service Identity used for the virtual machine.
        /// </summary>
        Models.ResourceIdentityType? ManagedServiceIdentityType { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the virtual machine.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID assigned
        /// to the virtual machine.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets the resource ids of User Assigned Managed Service Identities associated with the virtual machine.
        /// </summary>
        System.Collections.Generic.ISet<string> UserAssignedManagedServiceIdentityIds { get; }

        /// <summary>
        /// Gets the priority for the virtual machine.
        /// </summary>
        VirtualMachinePriorityTypes Priority { get; }

        /// <summary>
        /// Gets the eviction policy for the virtual machine.
        /// </summary>
        VirtualMachineEvictionPolicyTypes EvictionPolicy { get; }

        /// <summary>
        /// Gets the billing related details of a low priority virtual machine.
        /// </summary>
        BillingProfile BillingProfile { get; }

        /// <summary>
        /// Run commands in the virtual machine.
        /// </summary>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Result of execution.</return>
        Models.RunCommandResultInner RunCommand(RunCommandInput inputCommand);

        /// <summary>
        /// Run commands in the virtual machine asynchronously.
        /// </summary>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunCommandAsync(RunCommandInput inputCommand, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run shell script in a virtual machine.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of PowerShell script execution.</return>
        Models.RunCommandResultInner RunPowerShellScript(IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run shell script in the virtual machine asynchronously.
        /// </summary>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunPowerShellScriptAsync(IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run shell script in the virtual machine.
        /// </summary>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of shell script execution.</return>
        Models.RunCommandResultInner RunShellScript(IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run shell script in the virtual machine asynchronously.
        /// </summary>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunShellScriptAsync(IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}