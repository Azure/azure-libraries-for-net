// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Locks.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Locks.Fluent
{
    /// <summary>
    /// Entry point to managing Azure management locks.
    /// </summary>
    public class AuthorizationManager : Manager<IManagementLockClient>, IAuthorizationManager
    {
        #region Fluent private collections
        private IManagementLocks locks;
        #endregion


        public AuthorizationManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ManagementLockClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region AuthorizationManager builder

        public static IAuthorizationManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new AuthorizationManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static IAuthorizationManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new AuthorizationManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IAuthorizationManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IAuthorizationManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new AuthorizationManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IManagementLocks ManagementLocks
        {
            get
            {
                if (locks == null)
                {
                    locks = new ManagementLocksImpl(this);
                }
                return locks;
            }
        }
    }

    public interface IAuthorizationManager : IManager<IManagementLockClient>, IBeta
    {
        IManagementLocks ManagementLocks { get; }
    }
}

