// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VirtualMachineScaleSetVMsImpl
    {
        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.DeleteInstances(params string[] instanceIds)
        {

            this.DeleteInstances(instanceIds);
        }

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.DeleteInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken)
        {

            await this.DeleteInstancesAsync(instanceIds, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.DeleteInstancesAsync(string[] instanceIds, CancellationToken cancellationToken)
        {

            await this.DeleteInstancesAsync(instanceIds, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IVirtualMachineScaleSetVM>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.UpdateInstances(params string[] instanceIds)
        {

            this.UpdateInstances(instanceIds);
        }

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.UpdateInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken)
        {

            await this.UpdateInstancesAsync(instanceIds, cancellationToken);
        }

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMsBeta.UpdateInstancesAsync(string[] instanceIds, CancellationToken cancellationToken)
        {

            await this.UpdateInstancesAsync(instanceIds, cancellationToken);
        }
    }
}