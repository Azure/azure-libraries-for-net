// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using FunctionDeploymentSlot.Definition;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System;


    /// <summary>
    /// The implementation for FunctionDeploymentSlots.
    /// </summary>
    internal partial class FunctionDeploymentSlotsImpl :
        IndependentChildResourcesImpl<
            IFunctionDeploymentSlot,
            FunctionDeploymentSlotImpl,
            SiteInner,
            IWebAppsOperations,
            IAppServiceManager,
            IFunctionApp>,
        IFunctionDeploymentSlots
    {
        private FunctionAppImpl parent;

        IFunctionApp IHasParent<IFunctionApp>.Parent => parent;

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public async override Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteSlotAsync(groupName, parentName, name, cancellationToken: cancellationToken);
        }

        public void DeleteByName(string name)
        {
            DeleteByParent(parent.ResourceGroupName, parent.Name, name);
        }

        internal FunctionDeploymentSlotsImpl(
            FunctionAppImpl parent,
            IAppServiceManager manager)
            : base(manager.Inner.WebApps, manager)
        {
            this.parent = parent;
        }

        public async override Task<IPagedCollection<IFunctionDeploymentSlot>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFunctionDeploymentSlot, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListSlotsAsync(resourceGroupName, parentName, cancellation),
                async (nextLink, cancellation) => await Inner.ListSlotsNextAsync(nextLink, cancellation),
                async (inner, cancellation) => await PopulateModelAsync(inner, parent, cancellation), true, cancellationToken);
        }

        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByParentAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
        }

        public IEnumerable<IFunctionDeploymentSlot> List()
        {
            return ListByParent(parent.ResourceGroupName, parent.Name);
        }

        protected override FunctionDeploymentSlotImpl WrapModel(string name)
        {
            var deploymentSlot = new FunctionDeploymentSlotImpl(name, new SiteInner(), null, null, parent, Manager);

            deploymentSlot.WithRegion(parent.RegionName);
            deploymentSlot.WithExistingResourceGroup(parent.ResourceGroupName);

            return deploymentSlot;
        }

        protected override IFunctionDeploymentSlot WrapModel(SiteInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new FunctionDeploymentSlotImpl(inner.Name, inner, null, null, parent, Manager);
        }

        private IFunctionDeploymentSlot WrapModel(SiteInner inner, SiteConfigResourceInner siteConfigInner, SiteLogsConfigInner logsConfigInner)
        {
            if (inner == null)
            {
                return null;
            }
            return new FunctionDeploymentSlotImpl(inner.Name, inner, siteConfigInner, logsConfigInner, parent, Manager);
        }

        public IFunctionDeploymentSlot GetByName(string name)
        {
            return GetByParent(parent.ResourceGroupName, parent.Name, name);
        }

        public async override Task<IFunctionDeploymentSlot> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            SiteInner siteInner = await Inner.GetSlotAsync(resourceGroup, parentName, name, cancellationToken);
            if (siteInner == null)
            {
                return null;
            }
            var siteConfig = await Inner.GetConfigurationSlotAsync(resourceGroup, parentName, name, cancellationToken);
            var logConfig = await Inner.GetDiagnosticLogsConfigurationSlotAsync(resourceGroup, parentName, name, cancellationToken);

            var result = WrapModel(siteInner, siteConfig, logConfig);

            return result;
        }

        public async Task<IFunctionDeploymentSlot> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByParentAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
        }

        private async Task<IFunctionDeploymentSlot> PopulateModelAsync(SiteInner inner, IFunctionApp parent, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (inner == null)
            {
                return null;
            }
            var siteConfig = await Inner.GetConfigurationSlotAsync(inner.ResourceGroup, parent.Name, Regex.Replace(inner.Name, ".*/", ""), cancellationToken);
            var logConfig = await Inner.GetDiagnosticLogsConfigurationSlotAsync(inner.ResourceGroup, parent.Name, Regex.Replace(inner.Name, ".*/", ""), cancellationToken);
            var slot = WrapModel(inner, siteConfig, logConfig);
            return slot;
        }

        public async Task<IPagedCollection<IFunctionDeploymentSlot>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByParentAsync(parent.ResourceGroupName, parent.Name, cancellationToken);
        }
    }
}
