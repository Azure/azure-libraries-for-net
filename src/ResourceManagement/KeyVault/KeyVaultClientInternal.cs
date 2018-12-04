// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.KeyVault;
using System.Net.Http;
using Microsoft.Rest;

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    internal class KeyVaultClientInternal : KeyVaultClient
    {

        public KeyVaultClientInternal(ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(credentials, rootHandler, handlers)
        {
        }

        protected override DelegatingHandler CreateHttpHandlerPipeline(HttpClientHandler httpClientHandler, params DelegatingHandler[] handlers)
        {
            // if the hanlders are already chained do not chain them up again. 
            // This is a workaround of exisitng buggy functionality in ClientRuntime.
            if (handlers.First().InnerHandler != null)
            {
                return handlers.First();
            }
            return base.CreateHttpHandlerPipeline(httpClientHandler, handlers);
        }
    }
}
