// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VirtualMachinesImpl
    {
        /// <summary>
        /// Gets available virtual machine sizes.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSizes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Sizes
        {
            get
            {
                return this.Sizes();
            }
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as a JSON
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>The template as JSON string.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return this.Capture(groupName, name, containerName, vhdPrefix, overwriteVhd);
        }

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.CaptureAsync(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd, CancellationToken cancellationToken)
        {
            return await this.CaptureAsync(groupName, name, containerName, vhdPrefix, overwriteVhd, cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Deallocate(string groupName, string name)
        {

            this.Deallocate(groupName, name);
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.DeallocateAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.DeallocateAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        VirtualMachine.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<VirtualMachine.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Generalizes the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Generalize(string groupName, string name)
        {

            this.Generalize(groupName, name);
        }

        /// <summary>
        /// Generalizes the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.GeneralizeAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.GeneralizeAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Migrates the virtual machine with unmanaged disks to use managed disks.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.MigrateToManaged(string groupName, string name)
        {

            this.MigrateToManaged(groupName, name);
        }

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.MigrateToManagedAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.MigrateToManagedAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Powers off (stops) a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.PowerOff(string groupName, string name)
        {

            this.PowerOff(groupName, name);
        }

        /// <summary>
        /// Powers off (stops) the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.PowerOffAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.PowerOffAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Redeploys a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Redeploy(string groupName, string name)
        {

            this.Redeploy(groupName, name);
        }

        /// <summary>
        /// Redeploys the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.RedeployAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.RedeployAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Restarts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Restart(string groupName, string name)
        {

            this.Restart(groupName, name);
        }

        /// <summary>
        /// Restarts the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.RestartAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.RestartAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Run commands in a virtual machine.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Result of execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunCommand(string groupName, string name, RunCommandInput inputCommand)
        {
            return this.RunCommand(groupName, name, inputCommand);
        }

        /// <summary>
        /// Run commands in a virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunCommandAsync(string groupName, string name, RunCommandInput inputCommand, CancellationToken cancellationToken)
        {
            return await this.RunCommandAsync(groupName, name, inputCommand, cancellationToken);
        }

        /// <summary>
        /// Run shell script in a virtual machine.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of PowerShell script execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunPowerShellScript(string groupName, string name, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters)
        {
            return this.RunPowerShellScript(groupName, name, scriptLines, scriptParameters);
        }

        /// <summary>
        /// Run shell script in a virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunPowerShellScriptAsync(string groupName, string name, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken)
        {
            return await this.RunPowerShellScriptAsync(groupName, name, scriptLines, scriptParameters, cancellationToken);
        }

        /// <summary>
        /// Run shell script in a virtual machine.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of shell script execution.</return>
        Models.RunCommandResultInner Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunShellScript(string groupName, string name, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters)
        {
            return this.RunShellScript(groupName, name, scriptLines, scriptParameters);
        }

        /// <summary>
        /// Run shell script in a virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        async Task<Models.RunCommandResultInner> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta.RunShellScriptAsync(string groupName, string name, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken)
        {
            return await this.RunShellScriptAsync(groupName, name, scriptLines, scriptParameters, cancellationToken);
        }

        /// <summary>
        /// Starts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Start(string groupName, string name)
        {

            this.Start(groupName, name);
        }

        /// <summary>
        /// Starts the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.StartAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.StartAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Reimages a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Reimage(string groupName, string name, bool? tempDisk)
        {

            this.Reimage(groupName, name, tempDisk);
        }

        /// <summary>
        /// Reimages the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.ReimageAsync(string groupName, string name, bool? tempDisk, CancellationToken cancellationToken)
        {

            await this.ReimageAsync(groupName, name, tempDisk, cancellationToken);
        }
    }
}