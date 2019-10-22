// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  AutoscaleSettings.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQXV0b3NjYWxlU2V0dGluZ3NJbXBs
    internal partial class AutoscaleSettingsImpl  :
        TopLevelModifiableResources<
            IAutoscaleSetting,
            AutoscaleSettingImpl,
            AutoscaleSettingResourceInner,
            IAutoscaleSettingsOperations, 
            IMonitorManager>,
        IAutoscaleSettings
    {

        ///GENMHASH:9E73792A700554F0943D97D1E9A3FBF2:C89D66A891E547BF27DF27FA8CF1CD94
        internal AutoscaleSettingsImpl(IMonitorManager monitorManager)
            : base(monitorManager.Inner.AutoscaleSettings, monitorManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:822BE5001E1943377B392709FE38A50F
        protected override AutoscaleSettingImpl WrapModel(string name)
        {
            return new AutoscaleSettingImpl(name, new AutoscaleSettingResourceInner(), this.Manager);
        }

        ///GENMHASH:B6F70E7C7FDB68726D5E9B6DE7801BCD:2B3A96B6226082F1C9047803C3F529F0
        protected override IAutoscaleSetting WrapModel(AutoscaleSettingResourceInner inner)
        {
            if (inner ==  null)
            {
                return null;
            }
            return new AutoscaleSettingImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AutoscaleSettingImpl Define(string name)
        {
            return WrapModel(name);
        }

        // missing abstract method implementation from the base class
        protected override async Task<IPage<AutoscaleSettingResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return new AutoscaleSettingInnerPage(await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken));
        }

        protected override async Task<IPage<AutoscaleSettingResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<AutoscaleSettingResourceInner>>(null);
        }

        protected override async Task<AutoscaleSettingResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<AutoscaleSettingResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<AutoscaleSettingResourceInner>>(null);
        }

        protected override async Task<IPage<AutoscaleSettingResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return new AutoscaleSettingInnerPage(await Inner.ListBySubscriptionAsync(cancellationToken));
        }
    }
}