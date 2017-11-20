// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for ContainerServices.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uQ29udGFpbmVyU2VydmljZXNJbXBs
    internal partial class ContainerServicesImpl  :
        TopLevelModifiableResources<
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerService,
            Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceImpl,
            Models.ContainerServiceInner,
            IContainerServicesOperations,
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager>,
        IContainerServices
    {
        ///GENMHASH:2096D69FFE4705FC1B56A705A72E5775:5E0ADC686DDAB249E3ABAB5E538E38B4
        internal  ContainerServicesImpl(IContainerServiceManager containerServiceManager) : base(containerServiceManager.Inner.ContainerServices, containerServiceManager)
        {
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:53C2A804406FAB9E9486CAE63AF3F610
        protected override ContainerServiceImpl WrapModel(string name)
        {
            return new ContainerServiceImpl(name, new ContainerServiceInner(), this.Manager);
        }

        ///GENMHASH:DDDB514B633C81DA001018E6BDB5324B:FF06CA13839DEBFC58C1758FC1E83015
        protected override IContainerService WrapModel(ContainerServiceInner containerServiceInner)
        {
            if (containerServiceInner == null)
            {
                return null;
            }

            return new ContainerServiceImpl(containerServiceInner.Name, containerServiceInner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ContainerServiceImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:4593F1A2996AA2D0219FCEB42EA28D41
        protected Task<Models.ContainerServiceInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetInnerByGroupAsync(resourceGroupName, name, cancellationToken);
        }

        protected override async Task<ContainerServiceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await this.Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:FBFA0902403A234112A18515EE78DB0D
        protected async Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteInnerByGroupAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:43AAFBEC0EE373C2EA719BAD99B42FE2
        public override async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IContainerService>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellationToken);

            return await PagedCollection<IContainerService, ContainerServiceInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var containerService = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListInnerByGroupAsync(rg.Name, cancellation)));
                return containerService.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:DB7B2F880E3FD15243E864B1A40D9273
        public override IEnumerable<Microsoft.Azure.Management.ContainerService.Fluent.IContainerService> List()
        {
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        protected override async Task<IPage<ContainerServiceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await this.Inner.ListAsync(cancellationToken);
        }

        protected override async Task<IPage<ContainerServiceInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<ContainerServiceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken);
        }

        protected override async Task<IPage<ContainerServiceInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}