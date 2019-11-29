// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public class PrivateDnsManager : Manager<IPrivateDnsManagementClient>, IPrivateDnsManager
    {
        #region Fluent private collections
        private IPrivateDnsZones privateDnsZones;
        #endregion

        public PrivateDnsManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new PrivateDnsManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region PrivateDnsManager builder
        
        public static IPrivateDnsManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new PrivateDnsManager(RestClient.Configure()
                .WithEnvironment(credentials.Environment)
                .WithCredentials(credentials)
                .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                .Build(), subscriptionId);
        }

        public static IPrivateDnsManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new PrivateDnsManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion

        #region IConfigurable and it's implementation
        
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IPrivateDnsManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IPrivateDnsManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new PrivateDnsManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IPrivateDnsZones PrivateDnsZones
        {
            get
            {
                if(privateDnsZones == null)
                {
                    privateDnsZones = new PrivateDnsZonesImpl(this);
                }
                return privateDnsZones;
            }
        }
    }

    public interface IPrivateDnsManager : IManager<IPrivateDnsManagementClient>
    {
        IPrivateDnsZones PrivateDnsZones { get; }
    }
}
