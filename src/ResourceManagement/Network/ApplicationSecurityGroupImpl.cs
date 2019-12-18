// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ApplicationSecurityGroup and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25TZWN1cml0eUdyb3VwSW1wbA==
    internal partial class ApplicationSecurityGroupImpl :
        GroupableResource<
            IApplicationSecurityGroup,
            ApplicationSecurityGroupInner,
            ApplicationSecurityGroupImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate
        >,
        IApplicationSecurityGroup,
        IDefinition,
        IUpdate
    {

        ///GENMHASH:CDC434186BC1559858E48D056A58CABA:3881994DCADCE14215F82F0CC81BDD88
        internal ApplicationSecurityGroupImpl(string name, ApplicationSecurityGroupInner innerModel, INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:C010DB7FEA34323E487DCCE9E51E2B5E
        protected override async Task<Models.ApplicationSecurityGroupInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ApplicationSecurityGroups.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:BDDD85C8E6A1C36157B6E800B5A47964
        public override async Task<Microsoft.Azure.Management.Network.Fluent.IApplicationSecurityGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await this.Manager.Inner.ApplicationSecurityGroups.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken));
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:DAB8B84E516B09FDD9E8DC791B6A53CF:F89E32D41886BEB25B27A5222FC7F025
        public string ResourceGuid()
        {
            return Inner.ResourceGuid;
        }
    }
}