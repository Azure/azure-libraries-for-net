// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VirtualMachineScaleSetRollingUpgradesOperations.
    /// </summary>
    public static partial class VirtualMachineScaleSetRollingUpgradesOperationsExtensions
    {
            /// <summary>
            /// Cancels the current virtual machine scale set rolling upgrade.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CancelAsync(this IVirtualMachineScaleSetRollingUpgradesOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.CancelWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Starts a rolling upgrade to move all virtual machine scale set instances to
            /// the latest available Platform Image OS version. Instances which are already
            /// running the latest available OS version are not affected.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task StartOSUpgradeAsync(this IVirtualMachineScaleSetRollingUpgradesOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.StartOSUpgradeWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets the status of the latest virtual machine scale set rolling upgrade.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RollingUpgradeStatusInfoInner> GetLatestAsync(this IVirtualMachineScaleSetRollingUpgradesOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetLatestWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Cancels the current virtual machine scale set rolling upgrade.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginCancelAsync(this IVirtualMachineScaleSetRollingUpgradesOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginCancelWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Starts a rolling upgrade to move all virtual machine scale set instances to
            /// the latest available Platform Image OS version. Instances which are already
            /// running the latest available OS version are not affected.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginStartOSUpgradeAsync(this IVirtualMachineScaleSetRollingUpgradesOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginStartOSUpgradeWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
