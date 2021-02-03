﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    public class StorageManager : Manager<IStorageManagementClient>, IStorageManager
    {
        #region ctrs

        private StorageManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, StorageManagementClient.NewInstance(restClient))
        {
            Inner.SubscriptionId = subscriptionId;
        }

        #endregion

        #region StorageManager builder

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new StorageManager(restClient, subscriptionId);
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
            IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of StorageManager that exposes storage management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <return>the interface exposing storage management API entry points that work in a subscription</returns>
            public IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new StorageManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IStorageManager implementation 

        private IStorageAccounts storageAccounts;
        private IUsages usages;
        private IStorageSkus storageSkus;
        private IBlobContainers blobContainers;
        private IBlobServices blobServices;
        private IManagementPolicies managementPolicies;

        public IStorageAccounts StorageAccounts
        {
            get
            {
                if (storageAccounts == null)
                {
                    storageAccounts = new StorageAccountsImpl(this);
                }
                return storageAccounts;
            }
        }

        public IUsages Usages {
            get
            {
                if (usages == null)
                {
                    usages = new UsagesImpl(this);
                }
                return usages;
            }
        }

        public IStorageSkus StorageSkus
        {
            get
            {
                if (storageSkus == null)
                {
                    storageSkus = new StorageSkusImpl(this);
                }
                return storageSkus;
            }
        }

        public IBlobContainers BlobContainers
        {
            get
            {
                if (blobContainers == null)
                {
                    blobContainers = new BlobContainersImpl(this);
                }
                return blobContainers;
            }
        }

        public IBlobServices BlobServices
        {
            get
            {
                if (blobServices == null)
                {
                    blobServices = new BlobServicesImpl(this);
                }
                return blobServices;
            }
        }

        public IManagementPolicies ManagementPolicies
        {
            get
            {
                if (managementPolicies == null)
                {
                    managementPolicies = new ManagementPoliciesImpl(this);
                }
                return managementPolicies;
            }
        }

        #endregion
    }

    /// <summary>
    /// Entry point to Azure storage resource management.
    /// </summary>
    public interface IStorageManager : IManager<IStorageManagementClient>
    {
        /// <summary>
        /// Gets the storage resource management API entry point.
        /// </summary>
        IStorageAccounts StorageAccounts { get; }

        /// <summary>
        /// Gets the storage resource usage management API entry point.
        /// </summary>
        IUsages Usages { get; }

        /// <summary>
        /// Gets the storage service SKU management API entry point
        /// </summary>
        IStorageSkus StorageSkus { get; }

        /// <summary>
        /// Gets the storage blob container management API entry point
        /// </summary>
        IBlobContainers BlobContainers { get; }

        /// <summary>
        /// Gets the storage blob service management API entry point
        /// </summary>
        IBlobServices BlobServices { get; }

        /// <summary>
        /// Gets the storage management policy management API entry point
        /// </summary>
        IManagementPolicies ManagementPolicies { get; }
    }
}
