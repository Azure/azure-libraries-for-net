using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Domain;
using Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;


namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    /// <summary>
    /// The implementation for ServiceFabricClusters.
    /// </summary>
    internal partial class ServiceFabricClustersImpl :
        GroupableResources<
            IServiceFabricCluster,
            ServiceFabricClusterImpl,
            ServiceResourceInner,
            IClustersOperations,
            IServiceFabricManager>,
        IServiceFabricClusters
    {

        internal ServiceFabricClustersImpl(IServiceFabricManager serviceFabricManager) 
            : base(serviceFabricManager.Inner.Clusters, serviceFabricManager)
        {
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>
        protected override ServiceFabricClusterImpl WrapModel(string name)
        {
            return new ServiceFabricClusterImpl(name, new ServiceResourceInner(), this.Manager);
        }

        protected override IServiceFabricCluster WrapModel(ServiceResourceInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new ServiceFabricClusterImpl(inner.Name, inner, this.Manager);
        }

        public IEnumerable<IServiceFabricCluster> List()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IPagedCollection<IServiceFabricCluster>> ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return this.WrapModel(name);
        }

        IEnumerable<IServiceFabricCluster> ISupportsListing<IServiceFabricCluster>.List()
        {
            throw new System.NotImplementedException();
        }

        Task<IPagedCollection<IServiceFabricCluster>> ISupportsListing<IServiceFabricCluster>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<IServiceFabricCluster> ISupportsListingByResourceGroup<IServiceFabricCluster>.ListByResourceGroup(string resourceGroupName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IPagedCollection<IServiceFabricCluster>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<ServiceResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}