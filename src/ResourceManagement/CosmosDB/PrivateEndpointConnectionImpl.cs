// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent.PrivateEndpointConnection.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A private endpoint connection.
    /// </summary>
    internal partial class PrivateEndpointConnectionImpl :
        ExternalChildResource<IPrivateEndpointConnection,
            PrivateEndpointConnectionInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>,
        IPrivateEndpointConnection,
        IDefinition<CosmosDBAccount.Definition.IWithCreate>,
        IUpdateDefinition<CosmosDBAccount.Update.IWithOptionals>,
        PrivateEndpointConnection.Update.IUpdate
    {
        private IPrivateEndpointConnectionsOperations Client { get { return Parent.Manager.Inner.PrivateEndpointConnections; } }

        internal PrivateEndpointConnectionImpl(string name, CosmosDBAccountImpl parent, PrivateEndpointConnectionInner inner)
            : base(name, parent, inner)
        {
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        protected override async Task<PrivateEndpointConnectionInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.GetAsync(Parent.ResourceGroupName, Parent.Name, Name(), cancellationToken);
        }

        public CosmosDBAccountImpl Attach()
        {
            return Parent.WithPrivateEndpointConnection(this);
        }

        public override async Task<IPrivateEndpointConnection> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var privateEndpointConnection = await Client.CreateOrUpdateAsync(Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                Inner,
                cancellationToken);

            SetInner(privateEndpointConnection);
            return this;
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Client.DeleteAsync(Parent.ResourceGroupName, Parent.Name, Name(), cancellationToken);
        }

        public PrivateEndpointProperty PrivateEndpoint()
        {
            return Inner.PrivateEndpoint;
        }

        public PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState()
        {
            return Inner.PrivateLinkServiceConnectionState;
        }

        public override async Task<IPrivateEndpointConnection> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateAsync(cancellationToken);
        }

        public PrivateEndpointConnectionImpl WithDescription(string description)
        {
            if (Inner.PrivateLinkServiceConnectionState == null)
            {
                Inner.PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionStateProperty();
            }

            Inner.PrivateLinkServiceConnectionState.Description = description;
            return this;
        }

        public PrivateEndpointConnectionImpl WithStateProperty(PrivateLinkServiceConnectionStateProperty property)
        {
            Inner.PrivateLinkServiceConnectionState = property;
            return this;
        }

        public PrivateEndpointConnectionImpl WithStatus(string status)
        {
            if (Inner.PrivateLinkServiceConnectionState == null)
            {
                Inner.PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionStateProperty();
            }

            Inner.PrivateLinkServiceConnectionState.Status = status;
            return this;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        CosmosDBAccount.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        CosmosDBAccount.Update.IWithOptionals Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<CosmosDBAccount.Update.IWithOptionals>.Attach()
        {
            return this.Attach();
        }


        CosmosDBAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<CosmosDBAccount.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }
    }
}