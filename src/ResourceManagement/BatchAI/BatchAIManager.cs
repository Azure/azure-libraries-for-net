// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    public class BatchAIManager : Manager<IBatchAIManagementClient>, IBatchAIManager
    {
        #region Fluent private collections
        private IBatchAIWorkspaces batchAIWorkspaces;
        private IBatchAIUsages batchAIUsages;
        #endregion

        #region ctrs
        private BatchAIManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new BatchAIManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
        }
        #endregion
        #region BatchAIManager builder
        /// <summary>
        /// Creates an instance of BatchAIManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the BatchAIManager</returns>
        public static IBatchAIManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
        return Authenticate(RestClient.Configure()
                .WithEnvironment(credentials.Environment)
                .WithCredentials(credentials)
                .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                .Build(), subscriptionId);
        }
        /// <summary>
        /// Creates an instance of BatchAIManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the BatchAIManager</returns>
        public static IBatchAIManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new BatchAIManager(restClient, subscriptionId);
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
            IBatchAIManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }
        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of BatchAIManager that exposes BatchAI management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>the interface exposing BatchAI management API entry points that work in a subscription</returns>
            public IBatchAIManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new BatchAIManager(BuildRestClient(credentials), subscriptionId);
            }
        }
        #endregion

        public IBatchAIUsages BatchAIUsages
        {
            get
            {
                if (batchAIUsages == null)
                {
                    batchAIUsages = new BatchAIUsagesImpl(this);
                }
                return batchAIUsages;
            }
        }

        public IBatchAIWorkspaces BatchAIWorkspaces
        {
            get
            {
                if (batchAIWorkspaces == null)
                {
                    batchAIWorkspaces = new BatchAIWorkspacesImpl(this);
                }
                return batchAIWorkspaces;
            }
        }
    }
    /// <summary>
    /// Entry point to Azure BatchAI resource management.
    /// </summary>
    public interface IBatchAIManager : IManager<IBatchAIManagementClient>
    {
        IBatchAIWorkspaces BatchAIWorkspaces { get; }
        IBatchAIUsages BatchAIUsages { get; }
    }
}
