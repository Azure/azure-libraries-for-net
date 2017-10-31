// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Entry point to virtual machine scale set instance management API.
    /// </summary>
    public interface IVirtualMachineScaleSetVMsBeta
    {
        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task UpdateInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        void DeleteInstances(IList<string> instanceIds);

        /// <summary>
        /// Deletes the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be deleted.</param>
        void DeleteInstances(params string[] instanceIds);

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        void UpdateInstances(IList<string> instanceIds);

        /// <summary>
        /// Updates the specified virtual machine instances from the scale set.
        /// </summary>
        /// <param name="instanceIds">Instance IDs of the virtual machine scale set instances to be updated.</param>
        void UpdateInstances(params string[] instanceIds);
    }
}
