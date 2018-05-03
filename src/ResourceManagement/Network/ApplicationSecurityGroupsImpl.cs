// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Implementation for ApplicationSecurityGroups.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25TZWN1cml0eUdyb3Vwc0ltcGw=
    internal partial class ApplicationSecurityGroupsImpl  :
        TopLevelModifiableResources<
            Microsoft.Azure.Management.Network.Fluent.IApplicationSecurityGroup,Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroupImpl,Models.ApplicationSecurityGroupInner,IApplicationSecurityGroupsOperations,Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IApplicationSecurityGroups
    {

        ///GENMHASH:9F537A68BE99EFD4DE44F24FAD6FB656:7400B6F704E689384CEA5D85E7B1A802
        internal  ApplicationSecurityGroupsImpl(INetworkManager networkManager) : base(networkManager.Inner.ApplicationSecurityGroups, networkManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:08FC3231824BA57A3E44F5D773847E43
        protected override ApplicationSecurityGroupImpl WrapModel(string name)
        {
            ApplicationSecurityGroupInner inner = new ApplicationSecurityGroupInner();
            return new ApplicationSecurityGroupImpl(name, inner, Manager);
        }

        ///GENMHASH:C763D3F4C598D587D9883E45010EC8F3:1B5293B50C0C92398119A1115D12FA39
        protected override IApplicationSecurityGroup WrapModel(ApplicationSecurityGroupInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new ApplicationSecurityGroupImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ApplicationSecurityGroupImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override async Task<ApplicationSecurityGroupInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override async Task<IPage<ApplicationSecurityGroupInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected override async Task<IPage<ApplicationSecurityGroupInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<ApplicationSecurityGroupInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<ApplicationSecurityGroupInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

    }
}