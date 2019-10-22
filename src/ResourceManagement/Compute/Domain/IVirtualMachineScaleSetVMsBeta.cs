// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to virtual machine scale set instance management API.
    /// </summary>
    public interface IVirtualMachineScaleSetVMsBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        void DeleteInstances(params string[] instanceIds);

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteInstancesAsync(string[] instanceIds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the specified virtual machine instance from the scale set.
        /// </summary>
        /// <param name="instanceId">Instance ID of the virtual machine scale set instance to be fetched.</param>
        /// <returns>The virtual machine scale set instance.</returns>
        IVirtualMachineScaleSetVM GetInstance(string instanceId);

        /// <summary>
        /// Get the specified virtual machine instance from the scale set.
        /// </summary>
        /// <param name="instanceId">Instance ID of the virtual machine scale set instance to be fetched.</param>
        /// <returns>The virtual machine scale set instance.</returns>
        Task<IVirtualMachineScaleSetVM> GetInstanceAsync(string instanceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        void UpdateInstances(params string[] instanceIds);

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task UpdateInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task UpdateInstancesAsync(string[] instanceIds, CancellationToken cancellationToken = default(CancellationToken));
    }
}