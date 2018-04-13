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
    /// Implementation for  ActionGroups.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWN0aW9uR3JvdXBzSW1wbA==
    internal partial class ActionGroupsImpl :
        TopLevelModifiableResources<
            IActionGroup,
            ActionGroupImpl,
            ActionGroupResourceInner,
            IActionGroupsOperations,
            IMonitorManager>,
        IActionGroups
    {

        ///GENMHASH:0A0BCD111DEA66539B6E8D7C420C41C5:D8C40A24E33635587319873D8080BF45
        internal ActionGroupsImpl(IMonitorManager monitorManager)
            : base(monitorManager.Inner.ActionGroups, monitorManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:6F375CB3EB9FFE30B8047DA294A2BDC0
        protected override ActionGroupImpl WrapModel(string name)
        {
            return new ActionGroupImpl(name, new ActionGroupResourceInner(), this.Manager);
        }

        ///GENMHASH:9E619B51D5E165AEF3A23C6514BC77EE:AECBC18A38FFDE66B453DB48997167D3
        protected override IActionGroup WrapModel(ActionGroupResourceInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new ActionGroupImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ActionGroupImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:B323F93116878CA97F61306A2FC3D171:A7908CAF5BBA5A97DDCC2B78E8B1A703
        public void EnableReceiver(string resourceGroupName, string actionGroupName, string receiverName)
        {
            Extensions.Synchronize(() => this.Inner.EnableReceiverAsync(resourceGroupName, actionGroupName, receiverName));
        }

        ///GENMHASH:CB554CC24FB9CF66DABE36788DED9CB9:86898D8D316B96A6989C3B212C7AB3D8
        public async Task EnableReceiverAsync(string resourceGroupName, string actionGroupName, string receiverName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.EnableReceiverAsync(resourceGroupName, actionGroupName, receiverName, cancellationToken);
        }

        // missing abstract method implementation from the base class
        protected override async Task<IPage<ActionGroupResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return new ActionGroupInnerPage(await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken));
        }

        protected override async Task<IPage<ActionGroupResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ActionGroupResourceInner>>(null);
        }

        protected override async Task<ActionGroupResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<ActionGroupResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ActionGroupResourceInner>>(null);
        }

        protected override async Task<IPage<ActionGroupResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return new ActionGroupInnerPage(await Inner.ListBySubscriptionIdAsync(cancellationToken));
        }
    }
}