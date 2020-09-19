namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceFabric.Fluent.Domain;

    public class ServiceFabricManager : Manager<IServiceFabricManagementClient>, IServiceFabricManager
    {
        #region Fluent private collections
        private IServiceFabricClusters serviceFabricClusters;
        #endregion

        public ServiceFabricManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ServiceFabricManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        public static IServiceFabricManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new ServiceFabricManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static IServiceFabricManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new ServiceFabricManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IServiceFabricManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IServiceFabricManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new ServiceFabricManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IServiceFabricClusters ServiceFabricClusters
        {
            get
            {
                if (serviceFabricClusters == null)
                {
                    serviceFabricClusters = new ServiceFabricClustersImpl(this);
                }

                return serviceFabricClusters;
            }
        }
    }

    public interface IServiceFabricManager : IManager<IServiceFabricManagementClient>
    {
        IServiceFabricClusters ServiceFabricClusters { get; }
    }
}
