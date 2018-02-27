// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHubNamespaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViTmFtZXNwYWNlc0ltcGw=
    internal partial class EventHubNamespacesImpl  :
        TopLevelModifiableResources<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace,
            Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceImpl,
            EHNamespaceInner,
            INamespacesOperations,
            IEventHubManager>,
        IEventHubNamespaces
    {
        ///GENMHASH:58450A945E80C901D43CECE47608FEED:7062C994ACCC3143EB9A1DBD466807A4
        public EventHubNamespacesImpl(EventHubManager manager) : base(manager.Inner.Namespaces, manager)
        {
        }

        ///GENMHASH:7865EEFF863932A045F3956B3210D7F0:46139596353CDBF2CC949E09C54F4B4C
        public IEventHubs EventHubs()
        {
            return this.Manager.EventHubs;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public EventHubNamespaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:5FF0A632C48DF8AAD8871443465E8097
        public IEventHubNamespaceAuthorizationRules AuthorizationRules()
        {
            return this.Manager.NamespaceAuthorizationRules;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:DF0B7C695160540B201E2A712A9A90C4
        protected override EventHubNamespaceImpl WrapModel(string name)
        {
            return new EventHubNamespaceImpl(name, new EHNamespaceInner(), this.Manager);
        }

        ///GENMHASH:FA056CDBB26155628798FD5AD6BF2B87:1BB0D0E11AD557BCB7710B1D15B5871B
        protected override IEventHubNamespace WrapModel(EHNamespaceInner inner)
        {
            return new EventHubNamespaceImpl(inner.Name, inner, this.Manager);
        }

        protected override async Task<IPage<EHNamespaceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await this.Inner.ListAsync(cancellationToken);
        }

        protected override async Task<IPage<EHNamespaceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await this.Inner.ListNextAsync(link, cancellationToken);
        }

        protected override async Task<IPage<EHNamespaceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken);
        }

        protected override async Task<IPage<EHNamespaceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupNextAsync(link, cancellationToken);
        }

        protected override async Task<EHNamespaceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await this.Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }
    }
}