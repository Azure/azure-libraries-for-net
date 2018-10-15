// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    using Microsoft.Rest;
    using System.Net.Http;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public abstract class FluentServiceClientBase<TClient> : ServiceClient<TClient> 
        where TClient : ServiceClient<TClient>
    {
        protected RestClient _restClient;

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        public ServiceClientCredentials Credentials { get; private set; }

        protected FluentServiceClientBase(RestClient restClient)
            : this(restClient.BaseUri, restClient)
        {
        }

        protected FluentServiceClientBase(string baseUri, RestClient restClient)
            : base(restClient.RootHttpHandler, restClient.Handlers.ToArray())
        {
            Initialize();
            this._restClient = restClient;
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (restClient.Credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            BaseUri = new Uri(baseUri);
            Credentials = restClient.Credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }

            // Set RetryPolicy
            RetryDelegatingHandler delegatingHandler = this.HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();
            if (delegatingHandler != null && this._restClient.RetryPolicy != null &&
                delegatingHandler.RetryPolicy != this._restClient.RetryPolicy)
            {
                delegatingHandler.RetryPolicy = this._restClient.RetryPolicy;
            }
        }

        protected abstract void Initialize();

        protected override DelegatingHandler CreateHttpHandlerPipeline(HttpClientHandler httpClientHandler, params DelegatingHandler[] handlers)
        {
            // if the hanlders are already chained do not chain them up again. 
            // This is a workaround of exisitng buggy functionality in ClientRuntime.
            if(handlers.First().InnerHandler != null)
            {
                return handlers.First();
            }
            return base.CreateHttpHandlerPipeline(httpClientHandler, handlers);
        }
    }
}
