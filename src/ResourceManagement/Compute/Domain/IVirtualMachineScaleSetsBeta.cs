// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to virtual machine scale set management API.
    /// </summary>
    public interface IVirtualMachineScaleSetsBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Result of execution.</return>
        Models.RunCommandResultInner RunCommandInVMInstance(string groupName, string scaleSetName, string vmId, RunCommandInput inputCommand);

        /// <summary>
        /// Run commands in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="inputCommand">Command input.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunCommandVMInstanceAsync(string groupName, string scaleSetName, string vmId, RunCommandInput inputCommand, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run PowerShell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of PowerShell script execution.</return>
        Models.RunCommandResultInner RunPowerShellScriptInVMInstance(string groupName, string scaleSetName, string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run PowerShell in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">PowerShell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunPowerShellScriptInVMInstanceAsync(string groupName, string scaleSetName, string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Result of shell script execution.</return>
        Models.RunCommandResultInner RunShellScriptInVMInstance(string groupName, string scaleSetName, string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters);

        /// <summary>
        /// Run shell script in a virtual machine instance in a scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="scaleSetName">The virtual machine scale set name.</param>
        /// <param name="vmId">The virtual machine instance id.</param>
        /// <param name="scriptLines">Shell script lines.</param>
        /// <param name="scriptParameters">Script parameters.</param>
        /// <return>Handle to the asynchronous execution.</return>
        Task<Models.RunCommandResultInner> RunShellScriptInVMInstanceAsync(string groupName, string scaleSetName, string vmId, IList<string> scriptLines, IList<Models.RunCommandInputParameter> scriptParameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}