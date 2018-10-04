// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    public class ContainerServiceManager : Manager<IContainerServiceManagementClient>, IContainerServiceManager
    {
        #region Fluent private collections
        private IContainerServices containerServices;
        private IKubernetesClusters kubernetesClusters;
        #endregion

        public ContainerServiceManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ContainerServiceManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        public static IContainerServiceManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new ContainerServiceManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static IContainerServiceManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new ContainerServiceManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IContainerServiceManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IContainerServiceManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new ContainerServiceManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IContainerServices ContainerServices
        {
            get
            {
                if (containerServices == null)
                {
                    containerServices = new ContainerServicesImpl(this);
                }
                return containerServices;
            }
        }

        public IKubernetesClusters KubernetesClusters
        {
            get
            {
                if (kubernetesClusters == null)
                {
                    kubernetesClusters = new KubernetesClustersImpl(this);
                }
                return kubernetesClusters;
            }
        }
    }

    public interface IContainerServiceManager : IManager<IContainerServiceManagementClient>
    {
        IContainerServices ContainerServices { get; }
        IKubernetesClusters KubernetesClusters { get; }
    }

}
