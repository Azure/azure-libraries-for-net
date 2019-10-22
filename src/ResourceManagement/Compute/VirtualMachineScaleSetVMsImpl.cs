// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for VirtualMachineScaleSetVMs.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFZNc0ltcGw=
    internal partial class VirtualMachineScaleSetVMsImpl :
        ReadableWrappers<IVirtualMachineScaleSetVM,
            VirtualMachineScaleSetVMImpl,
            VirtualMachineScaleSetVMInner>,
        IVirtualMachineScaleSetVMs
    {
        private VirtualMachineScaleSetImpl scaleSet;

        public IComputeManager Manager
        {
            get; private set;
        }

        public IVirtualMachineScaleSetVMsOperations Inner
        {
            get
            {
                return Manager.Inner.VirtualMachineScaleSetVMs;
            }
        }

        ///GENMHASH:2F547EF235083E7C24F2AAD75FCE9FFC:C140D4869BF21B82D034CCD0BC161B59
        internal VirtualMachineScaleSetVMsImpl(VirtualMachineScaleSetImpl scaleSet, IComputeManager computeManager)
        {
            this.scaleSet = scaleSet;
            Manager = computeManager;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1AA7BDC7AB6868AA92F095AC7974525B
        public IEnumerable<IVirtualMachineScaleSetVM> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(scaleSet.ResourceGroupName, this.scaleSet.Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListNextAsync(link))));
        }

        ///GENMHASH:3231F2649B87EC1E21076533D17E37D1:3FD352500A8609B35E39BD6C990FFB4D
        protected override IVirtualMachineScaleSetVM WrapModel(VirtualMachineScaleSetVMInner inner)
        {
            return new VirtualMachineScaleSetVMImpl(inner, this.scaleSet);
        }

        public async Task<IPagedCollection<IVirtualMachineScaleSetVM>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineScaleSetVM, VirtualMachineScaleSetVMInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(scaleSet.ResourceGroupName, this.scaleSet.Name, cancellationToken: cancellation),
                Inner.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:A32993171DE4825D6197C78D815A8070:59E051D5E822932B078C7F0F184254DB
        public async Task DeleteInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (instanceIds == null || instanceIds.Count == 0)
            {
                return;
            }
            var scaleSetInnerManager = this.scaleSet.Manager.VirtualMachineScaleSets.Inner;
            await scaleSetInnerManager.DeleteInstancesAsync(this.scaleSet.ResourceGroupName, this.scaleSet.Name, instanceIds, cancellationToken);
        }

        /// <summary>
        /// Get the specified virtual machine instance from the scale set.
        /// </summary>
        /// <param name="instanceId">Instance ID of the virtual machine scale set instance to be fetched.</param>
        /// <returns>The virtual machine scale set instance.</returns>
        public async Task<IVirtualMachineScaleSetVM> GetInstanceAsync(string instanceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.WrapModel(await this.Inner.GetAsync(this.scaleSet.ResourceGroupName, this.scaleSet.Name, instanceId, InstanceViewTypes.InstanceView, cancellationToken));
        }

        ///GENMHASH:8614677E9F33F649DA97FEA11832F507:F1FA4FC3202537ADF1E8F7F846D49B62
        public async Task UpdateInstancesAsync(IList<string> instanceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (instanceIds == null || instanceIds.Count == 0)
            {
                return;
            }
            var scaleSetInnerManager = this.scaleSet.Manager.VirtualMachineScaleSets.Inner;
            await scaleSetInnerManager.UpdateInstancesAsync(this.scaleSet.ResourceGroupName, this.scaleSet.Name, instanceIds, cancellationToken);
        }

        ///GENMHASH:BF0243215BA9143B56ED25983393E69B:E85071D55AA027B278E4E85CA4BC6B0D
        public void DeleteInstances(IList<string> instanceIds)
        {
            Extensions.Synchronize(() => this.DeleteInstancesAsync(instanceIds));
        }

        ///GENMHASH:BF0243215BA9143B56ED25983393E69B:E85071D55AA027B278E4E85CA4BC6B0D
        public void DeleteInstances(params string[] instanceIds)
        {
            Extensions.Synchronize(() => this.DeleteInstancesAsync(instanceIds));
        }

        /// <summary>
        /// Get the specified virtual machine instance from the scale set.
        /// </summary>
        /// <param name="instanceId">Instance ID of the virtual machine scale set instance to be fetched.</param>
        /// <returns>The virtual machine scale set instance.</returns>
        public IVirtualMachineScaleSetVM GetInstance(string instanceId)
        {
            return Extensions.Synchronize(() => this.GetInstanceAsync(instanceId));
        }

        ///GENMHASH:192081DA3B0538D0043A32038FB0F341:EAFA9C00FF9BD97500B291BEA8F839D5
        public void UpdateInstances(params string[] instanceIds)
        {
            Extensions.Synchronize(() => this.UpdateInstancesAsync(instanceIds));
        }

        ///GENMHASH:192081DA3B0538D0043A32038FB0F341:EAFA9C00FF9BD97500B291BEA8F839D5
        public void UpdateInstances(IList<string> instanceIds)
        {
            Extensions.Synchronize(() => this.UpdateInstancesAsync(instanceIds));
        }
    }
}
