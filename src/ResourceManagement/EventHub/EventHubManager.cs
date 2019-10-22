// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;

namespace Microsoft.Azure.Management.EventHub.Fluent
{
    public class EventHubManager : Manager<IEventHubManagementClient>, IEventHubManager, IBeta
    {
        private readonly IStorageManager storageManager;

        #region Fluent private collections
        private IEventHubNamespaces namespaces;
        private IEventHubs eventHubs;
        private IEventHubConsumerGroups consumerGroups;
        private IEventHubDisasterRecoveryPairings eventHubDisasterRecoveryPairings;
        private IEventHubAuthorizationRules eventHubAuthorizationRules;
        public IEventHubNamespaceAuthorizationRules namespaceAuthorizationRules;
        private IDisasterRecoveryPairingAuthorizationRules disasterRecoveryPairingAuthorizationRules;
        #endregion

        #region ctrs
        private EventHubManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new EventHubManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
        }

        #endregion
        #region EventHubManager builder
        /// <summary>
        /// Creates an instance of EventHubManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the EventHubManager</returns>
        public static IEventHubManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
        return Authenticate(RestClient.Configure()
                .WithEnvironment(credentials.Environment)
                .WithCredentials(credentials)
                .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                .Build(), subscriptionId);
        }
        /// <summary>
        /// Creates an instance of EventHubManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the EventHubManager</returns>
        public static IEventHubManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new EventHubManager(restClient, subscriptionId);
        }
        /// <summary>
        /// Get a Configurable instance that can be used to create StorageManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }
        #endregion
        #region IConfigurable and it's implementation
        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IEventHubManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }
        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of EventHubManager that exposes EventHub management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>the interface exposing EventHub management API entry points that work in a subscription</returns>
            public IEventHubManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new EventHubManager(BuildRestClient(credentials), subscriptionId);
            }
        }
        #endregion

        #region
        public IEventHubNamespaces Namespaces
        {
            get
            {
                if (this.namespaces == null)
                {
                    this.namespaces = new EventHubNamespacesImpl(this);
                }
                return this.namespaces;
            }
        }

        public IEventHubs EventHubs
        {
            get
            {
                if (this.eventHubs == null)
                {
                    this.eventHubs = new EventHubsImpl(this, this.storageManager);
                }
                return this.eventHubs;
            }
        }

        public IEventHubConsumerGroups ConsumerGroups
        {
            get
            {
                if (this.consumerGroups == null)
                {
                    this.consumerGroups = new EventHubConsumerGroupsImpl(this);
                }
                return this.consumerGroups;
            }
        }

        public IEventHubDisasterRecoveryPairings EventHubDisasterRecoveryPairings
        {
            get
            {
                if (this.eventHubDisasterRecoveryPairings == null)
                {
                    this.eventHubDisasterRecoveryPairings = new EventHubDisasterRecoveryPairingsImpl(this);
                }
                return this.eventHubDisasterRecoveryPairings;
            }
        }

        public IEventHubAuthorizationRules EventHubAuthorizationRules
        {
            get
            {
                if (this.eventHubAuthorizationRules  == null)
                {
                    this.eventHubAuthorizationRules = new EventHubAuthorizationRulesImpl(this);
                }
                return this.eventHubAuthorizationRules;
            }
        }

        public IEventHubNamespaceAuthorizationRules NamespaceAuthorizationRules
        {
            get
            {
                if (this.namespaceAuthorizationRules == null)
                {
                    this.namespaceAuthorizationRules = new EventHubNamespaceAuthorizationRulesImpl(this);
                }
                return this.namespaceAuthorizationRules;
            }
        }

        public IDisasterRecoveryPairingAuthorizationRules DisasterRecoveryPairingAuthorizationRules
        {
            get
            {
                if (this.disasterRecoveryPairingAuthorizationRules == null)
                {
                    this.disasterRecoveryPairingAuthorizationRules = new DisasterRecoveryPairingAuthorizationRulesImpl(this);
                }
                return this.disasterRecoveryPairingAuthorizationRules;
            }
        }

        #endregion
    }
    /// <summary>
    /// Entry point to Azure EventHub resource management.
    /// </summary>
    public interface IEventHubManager : IManager<IEventHubManagementClient>, IBeta
    {
        /// <summary>
        /// Entry point to manage EventHub namespaces
        /// </summary>
        IEventHubNamespaces Namespaces { get; }

        /// <summary>
        /// Entry point to manage event hubs
        /// </summary>
        IEventHubs EventHubs { get; }

        /// <summary>
        /// Entry point to manage event hub consumer groups
        /// </summary>
        IEventHubConsumerGroups ConsumerGroups { get; }

        /// <summary>
        /// Entry point to manage disaster recovery pairing of event hub namespaces
        /// </summary>
        IEventHubDisasterRecoveryPairings EventHubDisasterRecoveryPairings { get; }

        /// <summary>
        /// Entry point to manage event hub authorization rule
        /// </summary>
        IEventHubAuthorizationRules EventHubAuthorizationRules { get; }

        /// <summary>
        /// Entry point to manage event hub namespace authorization rules
        /// </summary>
        IEventHubNamespaceAuthorizationRules NamespaceAuthorizationRules { get; }

        /// <summary>
        /// Entry point to manage disaster recovery pairing authorization rules
        /// </summary>
        IDisasterRecoveryPairingAuthorizationRules DisasterRecoveryPairingAuthorizationRules { get; }
    }
}
