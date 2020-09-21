namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Domain
{
    public interface IServiceFabricClusters : 
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceFabric.Fluent.IServiceFabricManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IClustersOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ServiceFabricCluster.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceFabric.Fluent.IServiceFabricCluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ServiceFabric.Fluent.IServiceFabricCluster>
    {
    }
}
