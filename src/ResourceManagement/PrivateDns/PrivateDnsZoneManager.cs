// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public class PrivateDnsZoneManager : Manager<IPrivateDnsManagementClient>, IPrivateDnsZoneManager
    {
        #region Fluent private collections
        private IPrivateDnsZones privateDnsZones;
        #endregion

        public PrivateDnsZoneManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, PrivateDnsManagementClient.NewInstance(restClient))
        {
            Inner.SubscriptionId = subscriptionId;
        }

        #region PrivateDnsZoneManager builder
        
        public static IPrivateDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new PrivateDnsZoneManager(RestClient.Configure()
                .WithEnvironment(credentials.Environment)
                .WithCredentials(credentials)
                .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                .Build(), subscriptionId);
        }

        public static IPrivateDnsZoneManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new PrivateDnsZoneManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion

        #region IConfigurable and it's implementation
        
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IPrivateDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IPrivateDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new PrivateDnsZoneManager(BuildRestClient(credentials), subscriptionId);
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

    public interface IPrivateDnsZoneManager : IManager<IPrivateDnsManagementClient>
    {
        IPrivateDnsZones PrivateDnsZones { get; }
    }
}
