// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of application gateway backend HTTP configuration health information.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZEh0dHBDb25maWd1cmF0aW9uSGVhbHRoSW1wbA==
    internal partial class ApplicationGatewayBackendHttpConfigurationHealthImpl : IApplicationGatewayBackendHttpConfigurationHealth
    {
        private ApplicationGatewayBackendHealthHttpSettings inner;
        private ApplicationGatewayBackendHealthImpl backendHealth;
        private Dictionary<string, IApplicationGatewayBackendServerHealth> serverHealths = new Dictionary<string, IApplicationGatewayBackendServerHealth>();

        ///GENMHASH:10749BB44908864C6A1D744957772062:CD7A6BCA2F3DB5AD98B22F463C776ECA
        internal ApplicationGatewayBackendHttpConfigurationHealthImpl(ApplicationGatewayBackendHealthHttpSettings inner, ApplicationGatewayBackendHealthImpl backendHealth)
        {
            this.inner = inner;
            this.backendHealth = backendHealth;

            if (inner.Servers != null)
            {
                foreach (var serverHealthInner in inner.Servers)
                {
                    IApplicationGatewayBackendServerHealth serverHealth = new ApplicationGatewayBackendServerHealthImpl(serverHealthInner, this);
                    serverHealths[serverHealth.IPAddress] = serverHealth;
                }
            }
        }

        ///GENMHASH:B2F4F96855247681287878DA2BF26C8E:7394CA27E8B7ED3BD64B800DC6839B0A
        public IApplicationGatewayBackendHttpConfiguration BackendHttpConfiguration()
        {
            if (inner.BackendHttpSettings == null)
            {
                return null;
            }

            string name = ResourceUtils.NameFromResourceId(inner.BackendHttpSettings.Id);
            IApplicationGatewayBackendHttpConfiguration config;
            return Parent().Parent.BackendHttpConfigurations.TryGetValue(name, out config) ? config : null;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:3075BEB50F5A8EDD75866F87DEFB5D94
        public IApplicationGatewayBackendHealth Parent()
        {
            return backendHealth;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:15D6307B0265B8B69214D2626437AC42
        public string Name()
        {
            return (inner.BackendHttpSettings != null) ? ResourceUtils.NameFromResourceId(inner.BackendHttpSettings.Id) : null;
        }

        ///GENMHASH:A6A88AB77DAFA8771AB0893A7B5A643A:7D3ACC9A318AEF5DD9232186F88F3685
        public IReadOnlyDictionary<string, IApplicationGatewayBackendServerHealth> ServerHealths()
        {
            return serverHealths;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public ApplicationGatewayBackendHealthHttpSettings Inner
        {
            get
            {
                return inner;
            }
        }
    }
}