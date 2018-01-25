// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of application gateway backend health information.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZEhlYWx0aEltcGw=
    internal partial class ApplicationGatewayBackendHealthImpl : IApplicationGatewayBackendHealth
    {
        private ApplicationGatewayBackendHealthPool inner;
        private ApplicationGatewayImpl appGateway;
        private Dictionary<string, IApplicationGatewayBackendHttpConfigurationHealth> httpConfigHealths = new Dictionary<string, IApplicationGatewayBackendHttpConfigurationHealth>();

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public ApplicationGatewayBackendHealthPool Inner
        {
            get
            {
                return inner;
            }
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:048E31A01E0FBE1D7A5B122B7E0CD0E3
        public IApplicationGateway Parent()
        {
            return appGateway;
        }

        ///GENMHASH:7938776B01DFB8731A036CFB2A1B92BE:163D3AC02982308DF2A2C5D660E44B91
        public IReadOnlyDictionary<string, IApplicationGatewayBackendHttpConfigurationHealth> HttpConfigurationHealths()
        {
            return httpConfigHealths;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:51E1792108A2176C731F595A57264F95
        public string Name()
        {
            if (inner.BackendAddressPool != null)
            {
                return ResourceUtils.NameFromResourceId(inner.BackendAddressPool.Id);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:5AC5C38B890C28F2C14CCD5CC0A89B49:19E0C2230777BB60068D0C341425EED3
        public IApplicationGatewayBackend Backend()
        {
            if (inner.BackendAddressPool == null)
            {
                return null;
            }

            string backendName = ResourceUtils.NameFromResourceId(inner.BackendAddressPool.Id);
            IApplicationGatewayBackend backend = null;
            return (appGateway.Backends().TryGetValue(backendName, out backend)) ? backend : null;
        }

        ///GENMHASH:290CE08B776437568FD90FB94CF15611:CD9EA116FB6AE617C92D782DF7463FA8
        internal ApplicationGatewayBackendHealthImpl(ApplicationGatewayBackendHealthPool inner, ApplicationGatewayImpl appGateway)
        {
            this.inner = inner;
            this.appGateway = appGateway;
            if (inner != null)
            {
                foreach (var httpConfigInner in Inner.BackendHttpSettingsCollection)
                {
                    ApplicationGatewayBackendHttpConfigurationHealthImpl httpConfigHealth = new ApplicationGatewayBackendHttpConfigurationHealthImpl(httpConfigInner, this);
                    httpConfigHealths[httpConfigHealth.Name()] = httpConfigHealth;
                }
            }
        }
    }
}