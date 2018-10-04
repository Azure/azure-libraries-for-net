// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Msi.Fluent
{
    public class MsiManager : Manager<IManagedServiceIdentityClient>, IMsiManager
    {
        private IGraphRbacManager graphRbacManager;

        private MsiManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ManagedServiceIdentityClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
            this.graphRbacManager = Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager.Authenticate(restClient, restClient.Credentials.TenantId);
        }

        #region MsiManager builder

        /// <summary>
        /// Creates an instance of MsiManager that exposes Managed Service Identity (MSI) resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the MsiManager</returns>
        public static IMsiManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of MsiManager that exposes Managed Service Identity (MSI) resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IMsiManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new MsiManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Get a Configurable instance that can be used to create MsiManager with optional configuration.
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
            IMsiManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of MsiManager that exposes Managed Service Identity (MSI) management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <return>the interface exposing Managed Service Identity (MSI) management API entry points that work in a subscription</returns>
            public IMsiManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new MsiManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IMsiManager implementation 

        private IIdentities identities;

        public IIdentities Identities
        {
            get
            {
                if (identities == null)
                {
                    identities = new IdentitesImpl(this.Inner.UserAssignedIdentities, this);
                }
                return identities;
            }
        }

        public IGraphRbacManager GraphRbacManager => this.graphRbacManager;

        #endregion
    }

    /// <summary>
    /// Entry point to Azure Managed Service Identity (MSI) resource management.
    /// </summary>
    public interface IMsiManager : IManager<IManagedServiceIdentityClient>, IBeta
    {
        /// <summary>
        /// Gets the Managed Service Identity (MSI) management API entry point.
        /// </summary>
        IIdentities Identities { get; }

        /// <summary>
        /// The Graph RBAC manager.
        /// </summary>
        IGraphRbacManager GraphRbacManager { get; }
    }
}
