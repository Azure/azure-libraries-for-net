// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5VGFza3NJbXBs
    internal partial class RegistryTasksImpl  :
        IRegistryTasks
    {
        private IRegistryManager registryManager;

        ITasksOperations IHasInner<ITasksOperations>.Inner => this.registryManager.Inner.Tasks;

        ///GENMHASH:55CFCB3010FEBF201BD6417703D73A1C:6BB7F98668B697E6F973980EB0493963
        internal  RegistryTasksImpl(IRegistryManager registryManager)
        {
            this.registryManager = registryManager;
        }

        ///GENMHASH:00D82E9EC1D043ED9B513753E72EA388:2F0F4F704959B133C76195C10B3C6B80
        private RegistryTaskImpl WrapModel(TaskInner innerModel)
        {
            return new RegistryTaskImpl(this.registryManager, innerModel);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:C33C70993273C136CECF719A5DD752CB
        public IBlank Define(string name)
        {
            return new RegistryTaskImpl(this.registryManager, name);
        }

        ///GENMHASH:4017E1219609AE25F8E9913EFE6096F2:69D388C914E7B2130495EAA3644F33F2
        public void DeleteByRegistry(string resourceGroupName, string registryName, string taskName)
        {
            Extensions.Synchronize(() => this.DeleteByRegistryAsync(resourceGroupName, registryName, taskName));
        }

        ///GENMHASH:68E495D54023EB54130D04D2032AE76B:D7F269B1513B0F4868F2696BAF9238A4
        public async Task DeleteByRegistryAsync(string resourceGroupName, string registryName, string taskName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.registryManager.Inner.Tasks.DeleteAsync(resourceGroupName, registryName, taskName, cancellationToken);
        }

        ///GENMHASH:8B0B99EBB49C92C2D96F2F2BA941334B:63578892ACD224279FD935D164649E8E
        public IRegistryTask GetByRegistry(string resourceGroupName, string registryName, string taskName, bool includeSecrets)
        {
            return Extensions.Synchronize(() => this.GetByRegistryAsync(resourceGroupName, registryName, taskName, includeSecrets));
        }

        ///GENMHASH:80F7470CDF0EC9C47B32C4EFEE171B76:1BDB669FC17E41672BF2628A2DAED928
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> GetByRegistryAsync(string resourceGroupName, string registryName, string taskName, bool includeSecrets, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (includeSecrets) {
                TaskInner taskInner = await this.registryManager.Inner.Tasks.GetDetailsAsync(resourceGroupName, registryName, taskName, cancellationToken);
                return new RegistryTaskImpl(registryManager, taskInner);
            }
            else
            {
                TaskInner taskInner = await this.registryManager.Inner.Tasks.GetAsync(resourceGroupName, registryName, taskName, cancellationToken);
                return new RegistryTaskImpl(registryManager, taskInner);
            }
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:DEF4B99089B496AA57E21BC4EF529DB2
        public ITasksOperations Inner()
        {
            return this.registryManager.Inner.Tasks;
        }

        ///GENMHASH:FCBF9C2437A6D098F5E7317EDABA98B2:66730FB4B8E1FA3F3B3118655385C723
        public IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> ListByRegistry(string resourceGroupName, string registryName)
        {
            return Extensions.Synchronize(() => ListByRegistryAsync(resourceGroupName, registryName));
        }

        ///GENMHASH:41B994B3002BFC0F257FFEC7D6C8CE3C:7CCB4DAAC06DFC5CFB679A827A0D5EFA
        public async Task<IPagedCollection<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask>> ListByRegistryAsync(string resourceGroupName, string registryName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IRegistryTask, TaskInner>.LoadPage(
                async (cancellation) => await this.registryManager.Inner.Tasks.ListAsync(resourceGroupName, registryName, cancellation),
                this.registryManager.Inner.Tasks.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }
    }
}