// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation of application gateway backend server health information.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZFNlcnZlckhlYWx0aEltcGw=
    internal partial class ApplicationGatewayBackendServerHealthImpl : IApplicationGatewayBackendServerHealth
    {
        private ApplicationGatewayBackendHealthServer inner;
        private ApplicationGatewayBackendHttpConfigurationHealthImpl httpConfigHealth;

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:7BF0FDA9E597513E1D397C0177658E43
        public IApplicationGatewayBackendHttpConfigurationHealth Parent()
        {
            return httpConfigHealth;
        }

        ///GENMHASH:57716B11163C7F8F97CDD0C8F3021FAB:E873AF50CFB04E54D08864D0CFDFD5F0
        public INicIPConfiguration GetNetworkInterfaceIPConfiguration()
        {
            string nicIPConfigId = inner.IpConfiguration?.Id;
            if (nicIPConfigId == null)
            {
                return null;
            }

            string nicIPConfigName = ResourceUtils.NameFromResourceId(nicIPConfigId);
            string nicId = ResourceUtils.ParentResourcePathFromResourceId(nicIPConfigId);
            var nic = Parent().Parent.Parent.Manager.NetworkInterfaces.GetById(nicId);
            if (nic == null)
            {
                return null;
            }
            else
            {
                INicIPConfiguration config;
                return (nic.IPConfigurations.TryGetValue(nicIPConfigName, out config)) ? config : null;
            }
        }

        ///GENMHASH:EB9638E8F65D17F5F594E27D773A247D:C6D6CFA60E51E1AA23E2A22755F96B5B
        public string IPAddress()
        {
            return inner.Address;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public ApplicationGatewayBackendHealthServer Inner
        {
            get
            {
                return inner;
            }
        }

        ///GENMHASH:0111B1B788C0A6D6F89D0D62738FE9F1:17F95124EAAABC2941AA1F50645599B2
        internal ApplicationGatewayBackendServerHealthImpl(ApplicationGatewayBackendHealthServer inner, ApplicationGatewayBackendHttpConfigurationHealthImpl httpConfigHealth)
        {
            this.inner = inner;
            this.httpConfigHealth = httpConfigHealth;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:D9F25213BB9871647FE46647002273AB
        public ApplicationGatewayBackendHealthStatus Status()
        {
            return ApplicationGatewayBackendHealthStatus.Parse(inner.Health.ToString());
        }
    }
}