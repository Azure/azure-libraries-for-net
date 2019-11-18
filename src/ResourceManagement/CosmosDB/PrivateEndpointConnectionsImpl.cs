// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a private endpoint connection collection.
    /// </summary>
    public partial class PrivateEndpointConnectionsImpl :
        ExternalChildResourcesCached<
            PrivateEndpointConnectionImpl,
            IPrivateEndpointConnection,
            PrivateEndpointConnectionInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private IPrivateEndpointConnectionsOperations Client { get; set; }
        internal PrivateEndpointConnectionsImpl(IPrivateEndpointConnectionsOperations client, CosmosDBAccountImpl parent)
            : base(parent, "PrivateEndpointConnection")
        {
            this.Client = client;
            this.CacheCollection();
        }

        protected override IList<PrivateEndpointConnectionImpl> ListChildResources()
        {
            return new List<PrivateEndpointConnectionImpl>();
        }

        protected override PrivateEndpointConnectionImpl NewChildResource(string name)
        {
            return new PrivateEndpointConnectionImpl(name, Parent, new PrivateEndpointConnectionInner(null, name), Client);

        }

        public IDictionary<string, IPrivateEndpointConnection> AsMap()
        {
            return Extensions.Synchronize(() => this.AsMapAsync());
        }

        public async Task<IDictionary<string, IPrivateEndpointConnection>> AsMapAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var privateEndpointConnectionInners = await ListInnerAsync(cancellationToken);

            var result = new Dictionary<string, IPrivateEndpointConnection>();
            foreach (var privateEndpointConnectionInner in privateEndpointConnectionInners)
            {
                result.Add(privateEndpointConnectionInner.Name,
                    new PrivateEndpointConnectionImpl(privateEndpointConnectionInner.Name, Parent, privateEndpointConnectionInner, Client));
            }

            return result;
        }

        public async Task<PrivateEndpointConnectionImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetAsync(Parent.ResourceGroupName, Parent.Name, name, cancellationToken);
            return new PrivateEndpointConnectionImpl(name, Parent, inner, Client);
        }

        public PrivateEndpointConnectionImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IList<PrivateEndpointConnectionImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var privateEndpointConnectionInners = await ListInnerAsync(cancellationToken);

            var result = new List<PrivateEndpointConnectionImpl>();
            foreach (var privateEndpointConnectionInner in privateEndpointConnectionInners)
            {
                result.Add(new PrivateEndpointConnectionImpl(privateEndpointConnectionInner.Name, Parent, privateEndpointConnectionInner, Client));
            }

            return result;
        }

        private async Task<IEnumerable<PrivateEndpointConnectionInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListByDatabaseAccountAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                cancellationToken
                );
        }

        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }

        public PrivateEndpointConnectionImpl Update(string name)
        {
            return this.PrepareUpdate(name);
        }
    }
}