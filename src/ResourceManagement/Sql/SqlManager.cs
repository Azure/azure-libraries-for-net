// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Sql.Fluent
{
    public class SqlManager : Manager<ISqlManagementClient>, ISqlManager
    {
        private ISqlServers sqlServers;
        private string tenantId;

        public SqlManager(RestClient restClient, string subscriptionId, string tenantId) :
            base(restClient, subscriptionId, new SqlManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            })
        {
            this.tenantId = tenantId;
        }

        #region SqlManager builder


        public static ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new SqlManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId, credentials.TenantId);
        }

        /// <summary>
        /// Creates an instance of SqlManager that exposes Sql management API entry points.
        /// </summary>
        /// <param name="restClient"> the RestClient to be used for API calls</param>
        /// <param name="subscriptionId"> the subscription</param>
        /// <return>The SqlManager</return>
        public static ISqlManager Authenticate(RestClient restClient, string subscriptionId)
        {

            var credentials = ((AzureCredentials)restClient.Credentials);
            var tenantId = credentials?.TenantId;
            return new SqlManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion SqlManager builder

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new SqlManager(BuildRestClient(credentials), subscriptionId, credentials.TenantId);
            }
        }

        #endregion IConfigurable and it's implementation

        public string TenantId
        {
            get
            {
                return tenantId;
            }
        }

        public ISqlServers SqlServers
        {
            get
            {
                if (sqlServers == null)
                {
                    sqlServers = new SqlServersImpl(this);
                }

                return sqlServers;
            }
        }
    }

    public interface ISqlManager : IManager<ISqlManagementClient>
    {
        ISqlServers SqlServers { get; }
        string TenantId { get; }
    }
}