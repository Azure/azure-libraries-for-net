// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using ResourceManager.Fluent;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Implementation of the ApplicationGateway interface.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5SW1wbA==
    internal partial class ApplicationGatewayImpl :
        GroupableParentResourceWithTags<IApplicationGateway,
            ApplicationGatewayInner,
            ApplicationGatewayImpl,
            INetworkManager,
            IWithGroup,
            ApplicationGateway.Definition.IWithRequestRoutingRule,
            IWithCreate,
            IUpdate>,
        IApplicationGateway,
        IDefinition,
        IUpdate
    {
        private Dictionary<string, IApplicationGatewayIPConfiguration> ipConfigs;
        private Dictionary<string, IApplicationGatewayFrontend> frontends;
        private Dictionary<string, IApplicationGatewayBackend> backends;
        private Dictionary<string, IApplicationGatewayBackendHttpConfiguration> backendConfigs;
        private Dictionary<string, IApplicationGatewayListener> listeners;
        private Dictionary<string, IApplicationGatewayRequestRoutingRule> rules;
        private Dictionary<string, IApplicationGatewaySslCertificate> sslCerts;
        private Dictionary<string, IApplicationGatewayAuthenticationCertificate> authCertificates;
        private Dictionary<string, IApplicationGatewayProbe> probes;
        private Dictionary<string, IApplicationGatewayRedirectConfiguration> redirectConfigs;

        private static string DEFAULT = "default";
        private ApplicationGatewayFrontendImpl defaultPrivateFrontend;
        private ApplicationGatewayFrontendImpl defaultPublicFrontend;
        private Dictionary<string, string> creatablePipsByFrontend;
        private ICreatable<INetwork> creatableNetwork;
        private ICreatable<IPublicIPAddress> creatablePip;


        ///GENMHASH:6090DFFE659BCFBD5663DEF58249A2FA:3881994DCADCE14215F82F0CC81BDD88
        internal ApplicationGatewayImpl(
            string name,
            ApplicationGatewayInner innerModel,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        #region Withers

        #region WithAuthenticationCertificate

        ///GENMHASH:C80055062680530C27C6A7309EC4E4EE:A9428DB5D5BDD0D865DBE57182C61C5D
        internal ApplicationGatewayImpl WithAuthenticationCertificate(ApplicationGatewayAuthenticationCertificateImpl authCert)
        {
            if (authCert != null)
            {
                authCertificates[authCert.Name()] = authCert;
            }
            return this;
        }

        ///GENMHASH:319B56E32DFF50F7280D216606AC9963:CBC3FCF6C7A5B7E7A6ABF24450B15A79
        public ApplicationGatewayAuthenticationCertificateImpl DefineAuthenticationCertificate(string name)
        {
            IApplicationGatewayAuthenticationCertificate cert = null;
            if (!authCertificates.TryGetValue(name, out cert))
            {
                var inner = new ApplicationGatewayAuthenticationCertificateInner()
                {
                    Name = name
                };
                return new ApplicationGatewayAuthenticationCertificateImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayAuthenticationCertificateImpl)cert;
            }
        }

        ///GENMHASH:EEDF992F7513A5EDB4C6ABA705C4BE66:92B80212451C3CFF7D85FC0AA09E89CD
        public ApplicationGatewayImpl WithoutAuthenticationCertificate(string name)
        {
            authCertificates.Remove(name);
            return this;
        }

        #endregion

        #region WithBackend

        ///GENMHASH:52092E76C641F5B4C13B8CD22D11A1C5:249224B1D62137072D4A55E6C56A9A20
        public ApplicationGatewayImpl WithoutBackendFqdn(string fqdn)
        {
            foreach (var backend in backends.Values)
            {
                ((ApplicationGatewayBackendImpl)backend).WithoutFqdn(fqdn);
            }
            return this;
        }

        ///GENMHASH:C000D62B14DEB58BED734D8C97CBA337:4F027AEBFAC53ECDC5ED96364FD97831
        internal ApplicationGatewayImpl WithBackend(ApplicationGatewayBackendImpl backend)
        {
            if (backend != null)
            {
                backends[backend.Name()] = backend;
            }
            return this;
        }

        ///GENMHASH:F3A9F14B7416101E2871A396C7EB4A09:F0DE170B68E0547CCC6FAB27860283C2
        public ApplicationGatewayImpl WithoutBackendIPAddress(string ipAddress)
        {
            foreach (var backend in backends.Values)
            {
                ApplicationGatewayBackendImpl backendImpl = (ApplicationGatewayBackendImpl)backend;
                backendImpl.WithoutIPAddress(ipAddress);
            }
            return this;
        }


        ///GENMHASH:B63ECBF93DAE93F829555FDE7D92623F:42006D4B61D56FE465F7DF0F31BA69B1
        public ApplicationGatewayImpl WithoutBackend(string backendName)
        {
            backends.Remove(backendName);
            return this;
        }

        ///GENMHASH:A21060E42B1DFECB63D4D27A101A8941:5B99013747311ACBEED53F35BF26AD98
        public ApplicationGatewayBackendImpl DefineBackend(string name)
        {
            IApplicationGatewayBackend backend = null;
            if (!backends.TryGetValue(name, out backend))
            {
                var inner = new ApplicationGatewayBackendAddressPoolInner()
                {
                    Name = name
                };
                return new ApplicationGatewayBackendImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayBackendImpl)backend;
            }
        }


        ///GENMHASH:77C9DAC5FABBCE9000402FF2D27EA990:6BF21BB8CB142597A825567301634266
        public ApplicationGatewayBackendImpl UpdateBackend(string name)
        {
            IApplicationGatewayBackend backend = null;
            backends.TryGetValue(name, out backend);
            return (ApplicationGatewayBackendImpl)backend;
        }

        #endregion

        #region WithBackendHttpConfiguration

        ///GENMHASH:639D88327F2B6C934F976C743B318B50:372A4D825BDD1E794625E287A013486D
        public ApplicationGatewayImpl WithoutBackendHttpConfiguration(string name)
        {
            backendConfigs.Remove(name);
            return this;
        }

        ///GENMHASH:43D0A80DA689D640320A61D90075ADE8:5823DDD49C561EBE02B1165C9B987DFB
        internal ApplicationGatewayImpl WithBackendHttpConfiguration(ApplicationGatewayBackendHttpConfigurationImpl httpConfig)
        {
            if (httpConfig != null)
            {
                backendConfigs[httpConfig.Name()] = httpConfig;
            }
            return this;
        }

        ///GENMHASH:6409DA3F27E7CD8F90997F2AD668CE00:C32CC71324FAB50A4231A640A10D9D09
        public ApplicationGatewayBackendHttpConfigurationImpl DefineBackendHttpConfiguration(string name)
        {
            IApplicationGatewayBackendHttpConfiguration httpConfig = null;
            if (!backendConfigs.TryGetValue(name, out httpConfig))
            {
                var inner = new ApplicationGatewayBackendHttpSettingsInner()
                {
                    Name = name,
                    Port = 80 // Default port
                };

                return new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayBackendHttpConfigurationImpl)httpConfig;
            }
        }


        ///GENMHASH:18F12733B6D16771FA686008216DE902:F9F1071D1FB81E8C5E28576BA52F854C
        public ApplicationGatewayBackendHttpConfigurationImpl UpdateBackendHttpConfiguration(string name)
        {
            IApplicationGatewayBackendHttpConfiguration config = null;
            backendConfigs.TryGetValue(name, out config);
            return (ApplicationGatewayBackendHttpConfigurationImpl)config;
        }

        #endregion

        #region WithDisabledSslProtocols
        ///GENMHASH:3547E395B16C0613B6C78E0F02A003FD:0544C5DC2BB2DB5B21CB16D311FDA5AA
        internal ApplicationGatewayImpl WithDisabledSslProtocol(ApplicationGatewaySslProtocol protocol)
        {
            if (protocol != null)
            {
                var policy = ensureSslPolicy();
                if (!policy.DisabledSslProtocols.Contains(protocol))
                {
                    policy.DisabledSslProtocols.Add(protocol);
                }
            }
            return this;
        }

        ///GENMHASH:A0E97F4F6171E3C3023C1808184B5652:19F0801265AEBD0F833017BA79BA6999
        internal ApplicationGatewayImpl WithDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols)
        {
            if (protocols != null)
            {
                foreach (ApplicationGatewaySslProtocol protocol in protocols)
                {
                    WithDisabledSslProtocol(protocol);
                }
            }
            return this;
        }

        ///GENMHASH:9A103128290DD63853EE8C3D72EBF334:AFB3B8BC3CD905F23D1FE053EA7855CB
        internal ApplicationGatewayImpl WithoutDisabledSslProtocol(ApplicationGatewaySslProtocol protocol)
        {
            if (Inner.SslPolicy != null && Inner.SslPolicy.DisabledSslProtocols != null)
            {
                Inner.SslPolicy.DisabledSslProtocols.Remove(protocol);
                if (Inner.SslPolicy.DisabledSslProtocols.Count == 0)
                {
                    WithoutAnyDisabledSslProtocols();
                }
            }
            return this;
        }

        ///GENMHASH:F5D90CF18844760935BAF29C9F1F1CF7:4744E21A6B17E1A77C3F256E767EF044
        internal ApplicationGatewayImpl WithoutDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols)
        {
            if (protocols != null)
            {
                foreach (ApplicationGatewaySslProtocol protocol in protocols)
                {
                    WithoutDisabledSslProtocol(protocol);
                }
            }
            return this;
        }

        ///GENMHASH:368945ADEF3F3861DAF2B698CA88FEBB:C54EACF1BBC0F3B0B5C1E6E35D19C74B
        internal ApplicationGatewayImpl WithoutAnyDisabledSslProtocols()
        {
            Inner.SslPolicy = null;
            return this;
        }

        ///GENMHASH:8F49F543D085993E041924E3F9DFA71B:16CBF6CC934BBE99B20ACB7F9E7B81AA
        private ApplicationGatewaySslPolicy ensureSslPolicy()
        {
            ApplicationGatewaySslPolicy policy = Inner.SslPolicy;
            if (policy == null)
            {
                policy = new ApplicationGatewaySslPolicy();
                Inner.SslPolicy = policy;
            }

            var protocols = policy.DisabledSslProtocols;
            if (protocols == null)
            {
                protocols = new List<ApplicationGatewaySslProtocol>();
                policy.DisabledSslProtocols = protocols;
            }
            return policy;
        }


        ///GENMHASH:02B97B13EEC42018235E7901B50E5098:68EE1CA895C62A3316E1324CDC89B878
        internal IReadOnlyCollection<ApplicationGatewaySslProtocol> DisabledSslProtocols()
        {
            List<ApplicationGatewaySslProtocol> protocols = new List<ApplicationGatewaySslProtocol>();
            if (Inner.SslPolicy == null || Inner.SslPolicy.DisabledSslProtocols == null)
            {
                return protocols;
            }
            else
            {
                foreach (ApplicationGatewaySslProtocol protocol in Inner.SslPolicy.DisabledSslProtocols)
                {
                    protocols.Add(protocol);
                }
                return protocols;
            }
        }
        #endregion

        #region WithFrontend

        ///GENMHASH:9407377DFC5566D93476B1B7D2246504:B92120874A64FEDF5BAA29C6F88C6CAD
        public ApplicationGatewayFrontendImpl UpdateFrontend(string frontendName)
        {
            IApplicationGatewayFrontend frontend = null;
            frontends.TryGetValue(frontendName, out frontend);
            return (ApplicationGatewayFrontendImpl)frontend;
        }


        ///GENMHASH:7B8AA96C3162D1728416030E94CB731F:833B17009FF35743D36834ABBB879D14
        internal ApplicationGatewayImpl WithFrontend(ApplicationGatewayFrontendImpl frontend)
        {
            if (frontend != null)
            {
                frontends[frontend.Name()] = frontend;
            }
            return this;
        }


        ///GENMHASH:2CAA0883E5A09AD81DE423447D34059F:5D6EB88CFD9F858A269954D227220035
        private ApplicationGatewayFrontendImpl DefineFrontend(string name)
        {
            IApplicationGatewayFrontend frontend = null;
            if (!frontends.TryGetValue(name, out frontend))
            {
                var inner = new ApplicationGatewayFrontendIPConfigurationInner()
                {
                    Name = name
                };
                return new ApplicationGatewayFrontendImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayFrontendImpl)frontend;
            }
        }


        ///GENMHASH:65F75FDFA4544CBB0088928EC664A699:2CC325C7E7DA0C579A9F5409C52333F5
        public ApplicationGatewayImpl WithoutFrontend(string frontendName)
        {
            frontends.Remove(frontendName);
            return this;
        }


        ///GENMHASH:C4684C8A47F80967DA864E1AB75147B5:8B6E82EE2C6ECB762256E74C48B124D1
        public IUpdate WithoutPublicIPAddress()
        {
            return WithoutPublicFrontend();
        }

        ///GENMHASH:0263B1F6C1D2EA8755C6E28644653147:C2A348673547AB17A3E43B0CDED4C1ED
        protected override async Task<Models.ApplicationGatewayInner> ApplyTagsToInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ApplicationGateways.UpdateTagsAsync(ResourceGroupName, Name, Inner.Tags, cancellationToken);
        }
        ///GENMHASH:52541ED0C8AE1806DF3F2DF0DE092357:D02F16FB7F9F848339457F517542934A
        public ApplicationGatewayImpl WithNewPublicIPAddress(ICreatable<IPublicIPAddress> creatable)
        {
            string name = EnsureDefaultPublicFrontend().Name();
            creatablePipsByFrontend[name] = creatable.Key;
            AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }


        ///GENMHASH:1C505DCDEFCB5F029B7A60E2375286BF:4ACB26EDB3DFCE615E1000808D779EBD
        public ApplicationGatewayImpl WithNewPublicIPAddress()
        {
            EnsureDefaultPublicFrontend();
            return this;
        }


        ///GENMHASH:BAA3D51CA88C44942207E1ACEC857C51:83FF9E6570D6D323728B8D648A3FAFF9
        public ApplicationGatewayFrontendImpl DefinePublicFrontend()
        {
            return EnsureDefaultPublicFrontend();
        }


        ///GENMHASH:90B03712BB750F79C07AC1E18C347CD2:C2BD141C1F4FD24259AF9553C95455F4
        public ApplicationGatewayFrontendImpl UpdatePublicFrontend()
        {
            return (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
        }


        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:3B28CD0A1ED51A813EBC05C91D467272
        public ApplicationGatewayImpl WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            EnsureDefaultPublicFrontend().WithExistingPublicIPAddress(publicIPAddress);
            return this;
        }


        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:E3714D16AB2AB1730E4F363BBC22FB43
        public ApplicationGatewayImpl WithExistingPublicIPAddress(string resourceId)
        {
            EnsureDefaultPublicFrontend().WithExistingPublicIPAddress(resourceId);
            return this;
        }


        ///GENMHASH:A81618A68C4004FA1972411DF3C316A8:B36F33458166A92EBED50A27DEDA9AF1
        public ApplicationGatewayImpl WithoutPublicFrontend()
        {
            // Delete all public frontends
            List<string> toDelete = new List<string>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPublic)
                {
                    toDelete.Add(frontend.Name);
                }
            }

            foreach (string frontendName in toDelete)
            {
                frontends.Remove(frontendName);
            }

            defaultPublicFrontend = null;
            return this;
        }


        ///GENMHASH:854F62AEEE32605D0082690205B49C3B:68548DB0EF9B6E0869FDD4F8A24E25F9
        public ApplicationGatewayFrontendImpl DefinePrivateFrontend()
        {
            return EnsureDefaultPrivateFrontend();
        }


        ///GENMHASH:237C0D1ED9460213CBE7249D1C6CA8F9:83004C1879D69DCF59B0E3CC399F87C9
        public ApplicationGatewayImpl WithoutPrivateFrontend()
        {
            // Delete all private frontends
            List<string> toDelete = new List<string>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    toDelete.Add(frontend.Name);
                }
            }

            foreach (string frontendName in toDelete)
            {
                frontends.Remove(frontendName);
            }

            defaultPrivateFrontend = null;
            return this;
        }


        ///GENMHASH:26224359DA104EABE1EDF7F491D110F7:1A26AEF9E78D0E896C4C7A3847B74268
        public ApplicationGatewayImpl WithPrivateIPAddressDynamic()
        {
            EnsureDefaultPrivateFrontend().WithPrivateIPAddressDynamic();
            return this;
        }


        ///GENMHASH:7C5A670BDA8BF576E8AFC752CD10A797:A955581589FA3AB5F9E850A8EC96F11A
        public ApplicationGatewayImpl WithPrivateFrontend()
        {
            /* NOTE: This logic is a workaround for the unusual Azure API logic:
                - although app gateway API definition allows multiple IP configs, only one is allowed by the service currently;
                - although app gateway frontend API definition allows for multiple frontends, only one is allowed by the service today;
                - and although app gateway API definition allows different subnets to be specified between the IP configs and frontends, the service
                  requires the frontend and the containing subnet to be one and the same currently.

                So the logic here attempts to figure out from the API what that containing subnet for the app gateway is so that the user wouldn't
                have to re-enter it redundantly when enabling a private frontend, since only that one subnet is supported anyway.
                * TODO: When the underlying Azure API is reworked to make more sense, or the app gateway service starts supporting the functionality
                * that the underlying API implies is supported, this model and implementation should be revisited.
             */
            EnsureDefaultPrivateFrontend();
            return this;
        }


        ///GENMHASH:9946B3475EBD5468D4462F188EEE86C2:E21199EA433813AEB048FDC0E3D30ED5
        public ApplicationGatewayImpl WithPrivateIPAddressStatic(string ipAddress)
        {
            EnsureDefaultPrivateFrontend().WithPrivateIPAddressStatic(ipAddress);
            return this;
        }

        #endregion

        #region WithFrontendPort

        ///GENMHASH:328B229A953520EB99975ECA4DEB46B7:12A06AD1A54B91D9CD098E723EB86C93
        public ApplicationGatewayImpl WithFrontendPort(int portNumber, string name)
        {
            // Ensure inner ports list initialized
            var frontendPorts = Inner.FrontendPorts;
            if (frontendPorts == null)
            {
                frontendPorts = new List<ApplicationGatewayFrontendPortInner>();
                Inner.FrontendPorts = frontendPorts;
            }

            // Attempt to find inner port by name if provided, or port number otherwise
            ApplicationGatewayFrontendPortInner frontendPortByName = null;
            ApplicationGatewayFrontendPortInner frontendPortByNumber = null;
            foreach (var inner in Inner.FrontendPorts)
            {
                if (name != null && name.ToLower().Equals(inner.Name.ToLower()))
                {
                    frontendPortByName = inner;
                }

                if (inner.Port == portNumber)
                {
                    frontendPortByNumber = inner;
                }
            }

            bool? needToCreate = NeedToCreate(frontendPortByName, frontendPortByNumber, name);
            if (needToCreate != null && needToCreate.Value)
            {
                // If no conflict, create a new port
                if (name == null)
                {
                    // No name specified, so auto-name it
                    name = SdkContext.RandomResourceName("port", 9);
                }

                frontendPortByName = new ApplicationGatewayFrontendPortInner()
                {
                    Name = name,
                    Port = portNumber
                };

                frontendPorts.Add(frontendPortByName);
                return this;
            }
            else if (needToCreate != null && !needToCreate.Value)
            {
                // If found matching port, then nothing needs to happen
                return this;
            }
            else
            {
                // If name conflict for the same port number, then fail
                return null;
            }
        }

        ///GENMHASH:99A00736DF753F6060C6104537FAB411:D9EF6ECF075F0671DA3E7309852CB983
        public ApplicationGatewayImpl WithoutFrontendPort(string name)
        {
            if (Inner.FrontendPorts == null)
            {
                return this;
            }

            for (int i = 0; i < Inner.FrontendPorts.Count; i++)
            {
                var inner = Inner.FrontendPorts[i];
                if (inner.Name.ToLower().Equals(name.ToLower()))
                {
                    Inner.FrontendPorts.RemoveAt(i);
                    break;
                }
            }

            return this;
        }


        ///GENMHASH:668234534FB4FFFD8523AC34BA26B3DC:81C6EB67B9E5A0F963383F80948256A2
        public ApplicationGatewayImpl WithoutFrontendPort(int portNumber)
        {
            for (int i = 0; i < Inner.FrontendPorts.Count; i++)
            {
                var inner = Inner.FrontendPorts[i];
                if (inner.Port.Equals(portNumber))
                {
                    Inner.FrontendPorts.RemoveAt(i);
                    break;
                }
            }
            return this;
        }


        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:0BE350F61261249195A1647DAD43D2AB
        public ApplicationGatewayImpl WithFrontendPort(int portNumber)
        {
            return WithFrontendPort(portNumber, null);
        }

        #endregion

        #region WithIPConfiguration

        ///GENMHASH:A812694157D05E722A2E58EC7E4ED12E:130D5B3A30C34F066046287000EF7300
        internal ApplicationGatewayImpl WithConfig(ApplicationGatewayIPConfigurationImpl config)
        {
            if (config != null)
            {
                ipConfigs[config.Name()] = config;
            }
            return this;
        }

        ///GENMHASH:39AD92613CCA4FF337581BE8C7C4D2E5:36624456F5D55C0784D1480A536AC8CC
        public ApplicationGatewayIPConfigurationImpl DefineDefaultIPConfiguration()
        {
            return EnsureDefaultIPConfig();
        }


        ///GENMHASH:A575CF497D369A49B15095D3A59FC3F0:666CC44455B513012A45BEA1994108DE
        public ApplicationGatewayIPConfigurationImpl UpdateIPConfiguration(string ipConfigurationName)
        {
            IApplicationGatewayIPConfiguration config = null;
            ipConfigs.TryGetValue(ipConfigurationName, out config);
            return (ApplicationGatewayIPConfigurationImpl)config;
        }

        ///GENMHASH:4D03AF90CE6DD6A408BCDC3645E6F09F:B64B79419B32672E33E7CD69467AEA31
        public ApplicationGatewayIPConfigurationImpl UpdateDefaultIPConfiguration()
        {
            return (ApplicationGatewayIPConfigurationImpl)DefaultIPConfiguration();
        }


        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:2755FE1072E136415F232CA52EF0EFDB
        public ApplicationGatewayImpl WithExistingSubnet(ISubnet subnet)
        {
            EnsureDefaultIPConfig().WithExistingSubnet(subnet);
            return this;
        }


        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:59D063762F2CAF367C322074B9B41CB7
        public ApplicationGatewayImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            EnsureDefaultIPConfig().WithExistingSubnet(network, subnetName);
            return this;
        }


        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:AB95FC468847EDDF30E4F71338BFA913
        public ApplicationGatewayImpl WithExistingSubnet(string networkResourceId, string subnetName)
        {
            EnsureDefaultIPConfig().WithExistingSubnet(networkResourceId, subnetName);
            return this;
        }


        ///GENMHASH:A50981B34B33B00C33160ECE2AE8F250:BD69766F11ADAEF849FDED69B29B91BC
        private ApplicationGatewayIPConfigurationImpl DefineIPConfiguration(string name)
        {
            IApplicationGatewayIPConfiguration config = null;
            if (!ipConfigs.TryGetValue(name, out config))
            {
                var inner = new ApplicationGatewayIPConfigurationInner()
                {
                    Name = name
                };
                return new ApplicationGatewayIPConfigurationImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayIPConfigurationImpl)config;
            }
        }


        ///GENMHASH:B6F8BA13322FBCE7F33110D4DF0063A0:D755BC44A5AE232FE3D5AB7294B7260E
        public ApplicationGatewayImpl WithoutIPConfiguration(string ipConfigurationName)
        {
            ipConfigs.Remove(ipConfigurationName);
            return this;
        }

        #endregion

        #region WithListener

        ///GENMHASH:335DEBA2C3ED42B7D6D726224668713C:5F7D61C72418DAEB7F935725E2A62AFF
        public ApplicationGatewayListenerImpl DefineListener(string name)
        {
            IApplicationGatewayListener httpListener = null;
            if (!listeners.TryGetValue(name, out httpListener))
            {
                var inner = new ApplicationGatewayHttpListenerInner()
                {
                    Name = name
                };
                return new ApplicationGatewayListenerImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayListenerImpl)httpListener;
            }
        }


        ///GENMHASH:FD3BFA79E44BF0C0FD92A0CE7B31B143:0C32B144C358DA51784C501FAE5651A1
        internal ApplicationGatewayImpl WithHttpListener(ApplicationGatewayListenerImpl httpListener)
        {
            if (httpListener != null)
            {
                listeners[httpListener.Name()] = httpListener;
            }
            return this;
        }


        ///GENMHASH:6A7BE130A21D7CF301EAC3B7AFC03BC7:89DB414F8973677B8ED5DBFA5338F186
        public ApplicationGatewayListenerImpl UpdateListener(string name)
        {
            IApplicationGatewayListener listener = null;
            listeners.TryGetValue(name, out listener);
            return (ApplicationGatewayListenerImpl)listener;
        }


        ///GENMHASH:A0174786468BD0401BEEB279F03A9F28:8E183AA7B177F20F15999B009DA993FE
        public ApplicationGatewayImpl WithoutListener(string name)
        {
            listeners.Remove(name);
            return this;
        }

        #endregion

        #region WithProbe

        ///GENMHASH:20DB0965DE030D3C81FE00023D376A69:5594A0B4265A52032059CAA4CF474FD6
        public ApplicationGatewayProbeImpl DefineProbe(string name)
        {
            IApplicationGatewayProbe probe = null;
            if (!probes.TryGetValue(name, out probe))
            {
                var inner = new ApplicationGatewayProbeInner()
                {
                    Name = name
                };
                return new ApplicationGatewayProbeImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayProbeImpl)probe;
            }
        }

        ///GENMHASH:38BFE2F7B09C012CA0D64DCC81623E9E:65B23C9A03D9CBC10B0BBC9CAA4677A8
        public ApplicationGatewayProbeImpl UpdateProbe(string name)
        {
            IApplicationGatewayProbe probe = null;
            probes.TryGetValue(name, out probe);
            return (ApplicationGatewayProbeImpl)probe;
        }

        ///GENMHASH:6E017CB98B56255A0D3E4F37EC8ACD35:539639DE8874C6D95CF8297AE9557E4A
        internal ApplicationGatewayImpl WithProbe(ApplicationGatewayProbeImpl probe)
        {
            if (probe != null)
            {
                probes[probe.Name()] = probe;
            }
            return this;
        }

        ///GENMHASH:5ECDCD52F7D8B026EB0204682B6DBC78:CC42EDBDDB628F9C1D1D1D93BAA3EA03
        public ApplicationGatewayImpl WithoutProbe(string name)
        {
            probes.Remove(name);
            return this;
        }

        #endregion

        #region WithRedirectConfigurations

        ///GENMHASH:FA1A66DA89F1FF32B05B54567E0E110B:4C83DA464BB4DC1943DDF260EE2F42AF
        internal ApplicationGatewayRedirectConfigurationImpl UpdateRedirectConfiguration(string name)
        {
            IApplicationGatewayRedirectConfiguration config = null;
            return (redirectConfigs.TryGetValue(name, out config)) ? (ApplicationGatewayRedirectConfigurationImpl)config : null;
        }

        ///GENMHASH:88171D034C80D9B75F6A05061ED592D9:4CADEC4DC87C0451FBF6FDA2BCD7474E
        internal ApplicationGatewayImpl WithRedirectConfiguration(ApplicationGatewayRedirectConfigurationImpl redirectConfig)
        {
            if (redirectConfig != null)
            {
                redirectConfigs[redirectConfig.Name()] = redirectConfig;
            }
            return this;
        }

        ///GENMHASH:45D2681FD5C2A7DB043B28ED74D1FE95:FE5739EE590051F682AECDD328BF45C1
        internal ApplicationGatewayImpl WithoutRedirectConfiguration(string name)
        {
            redirectConfigs.Remove(name);
            return this;
        }

        ///GENMHASH:DAF3D3DE8749E9C2C29FA8F381D58815:1550080E0805099F7C91268FE30C0BDD
        internal ApplicationGatewayRedirectConfigurationImpl DefineRedirectConfiguration(string name)
        {
            IApplicationGatewayRedirectConfiguration redirectConfig = null;
            if (!redirectConfigs.TryGetValue(name, out redirectConfig))
            {
                var inner = new ApplicationGatewayRedirectConfigurationInner()
                {
                    Name = name
                };
                return new ApplicationGatewayRedirectConfigurationImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayRedirectConfigurationImpl)redirectConfig;
            }
        }

        #endregion

        #region WithRequestRoutingRule

        ///GENMHASH:9EE982E7421C1A20C7BB22556011B5DC:345F6A97C61E955CCFAB88208C749162
        internal ApplicationGatewayImpl WithRequestRoutingRule(ApplicationGatewayRequestRoutingRuleImpl rule)
        {
            if (rule != null)
            {
                rules[rule.Name()] = rule;
            }
            return this;
        }


        ///GENMHASH:3DBBB35580E0023332C1FB4E78C36EC4:8BC4FF2E70BFA1D6AB1B2664C2AB7FA1
        public ApplicationGatewayRequestRoutingRuleImpl DefineRequestRoutingRule(string name)
        {
            IApplicationGatewayRequestRoutingRule rule = null;
            if (!rules.TryGetValue(name, out rule))
            {
                var inner = new ApplicationGatewayRequestRoutingRuleInner()
                {
                    Name = name
                };
                return new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayRequestRoutingRuleImpl)rule;
            }
        }


        ///GENMHASH:3D14082AEAA37FD69BCA1BF0129B05FF:A0722D26BD371E7333E649E461013B02
        public ApplicationGatewayRequestRoutingRuleImpl UpdateRequestRoutingRule(string name)
        {
            IApplicationGatewayRequestRoutingRule rule = null;
            rules.TryGetValue(name, out rule);
            return (ApplicationGatewayRequestRoutingRuleImpl)rule;
        }


        ///GENMHASH:3AEE65B42CA330A187F9ED489D04EF17:BB6B3B198CEC808EF295F8AE72D11548
        public ApplicationGatewayImpl WithoutRequestRoutingRule(string name)
        {
            rules.Remove(name);
            return this;
        }

        #endregion

        #region WithSslCertificate

        ///GENMHASH:AA53287F5186B0525C5149BB8A3CC41C:F8A2D339B71D17A2BF48559C2304DA5D
        internal ApplicationGatewayImpl WithSslCertificate(ApplicationGatewaySslCertificateImpl cert)
        {
            if (cert != null)
            {
                sslCerts[cert.Name()] = cert;
            }
            return this;
        }

        ///GENMHASH:AEECF1FD9CF2F7E0FFAE9F2627E6B3FC:5EF4F345F37B15B88D7920245D112B33
        public ApplicationGatewaySslCertificateImpl DefineSslCertificate(string name)
        {
            IApplicationGatewaySslCertificate cert = null;
            if (!sslCerts.TryGetValue(name, out cert))
            {
                var inner = new ApplicationGatewaySslCertificateInner()
                {
                    Name = name
                };
                return new ApplicationGatewaySslCertificateImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewaySslCertificateImpl)cert;
            }
        }

        ///GENMHASH:4DB70C23295D0F053459FB0473314A93:6527E68319C59BC40C04CE7A016DF701
        public ApplicationGatewayImpl WithoutCertificate(string name)
        {
            return WithoutSslCertificate(name);
        }

        ///GENMHASH:C0DB58EE4EC60D927E9297D00E834CFC:7A5B03571727B37E62AC3357D157E863
        public ApplicationGatewayImpl WithoutSslCertificate(string name)
        {
            sslCerts.Remove(name);
            return this;
        }

        #endregion

        #region WithAvailabilityZone

        ///GENMHASH:5D8D71845C83EB59F52EB2C4B1C05618:0AA367931507CEA23E4115AE01B4EE41
        public ApplicationGatewayImpl WithAvailabilityZone(AvailabilityZoneId zoneId)
        {
            if (this.Inner.Zones == null)
            {
                this.Inner.Zones = new List<string>();
            }
            if (!this.Inner.Zones.Contains(zoneId.ToString()))
            {
                this.Inner.Zones.Add(zoneId.ToString());
            }
            return this;
        }

        #endregion


        public ApplicationGatewayImpl WithTier(ApplicationGatewayTier skuTier)
        {
            if (this.Inner.Sku == null)
            {
                this.Inner.Sku = new ApplicationGatewaySku { Capacity = 1 };
            }
            this.Inner.Sku.Tier = skuTier;
            return this;
        }

        ///GENMHASH:0A25F8D30AF64565545B20B215964E6B:7FF7C66C33A802B8668BFAC46B248EE8
        public ApplicationGatewayImpl WithSize(ApplicationGatewaySkuName skuName)
        {
            if (this.Inner.Sku == null)
            {
                this.Inner.Sku = new ApplicationGatewaySku { Capacity = 1 };
            }
            this.Inner.Sku.Name = skuName;
            if (this.Inner.Sku.Tier == null)
            {

                if (skuName == ApplicationGatewaySkuName.WAFLarge || skuName == ApplicationGatewaySkuName.WAFMedium)
                {
                    this.Inner.Sku.Tier = ApplicationGatewayTier.WAF;
                }
                else
                {
                    this.Inner.Sku.Tier = ApplicationGatewayTier.Standard;
                }
            }
            return this;
        }


        ///GENMHASH:94ACA3B358939F31F4F3966CDB1B73A4:7D7FC963A56E00888DE266506161CB7C
        public ApplicationGatewayImpl WithInstanceCount(int capacity)
        {
            if (Inner.Sku == null)
            {
                WithSize(ApplicationGatewaySkuName.StandardSmall);
            }

            Inner.Sku.Capacity = capacity;
            return this;
        }



        ///GENMHASH:94ACA3B358939F31F4F3966CDB1B73A4:7D7FC963A56E00888DE266506161CB7C
        public ApplicationGatewayImpl WithAutoscale(int minCapacity, int maxCapacity)
        {
            Inner.Sku.Capacity = null;
            Inner.AutoscaleConfiguration = new ApplicationGatewayAutoscaleConfiguration()
            {
                MinCapacity = minCapacity, 
                MaxCapacity = maxCapacity
            };
            return this;
        }

        public ApplicationGatewayImpl WithWebApplicationFirewall(bool enabled, ApplicationGatewayFirewallMode mode)
        {
            this.Inner.WebApplicationFirewallConfiguration = new ApplicationGatewayWebApplicationFirewallConfiguration()
            {
                Enabled = enabled,
                FirewallMode = mode,
                RuleSetType = "OWASP",
                RuleSetVersion = "3.0"
            };
            return this;
        }

        public ApplicationGatewayImpl WithWebApplicationFirewall(ApplicationGatewayWebApplicationFirewallConfiguration config)
        {
            this.Inner.WebApplicationFirewallConfiguration = config;
            return this;
        }

        
        public ApplicationGatewayImpl WithIdentity(ManagedServiceIdentity identity)
        {
            this.Inner.Identity = identity;
            return this;
        }

        public ApplicationGatewayImpl WithEnableHttp2()
        {
            Inner.EnableHttp2 = true;
            return this;
        }

        #endregion

        #region Withouters
        public ApplicationGatewayImpl WithoutEnableHttp2()
        {
            Inner.EnableHttp2 = false;
            return this;
        }
        #endregion

        #region Accessors

        ///GENMHASH:CD498C02D42C73AD0C1FF12493E2A9B8:CD5E24B4D8E0D679C5291E15ABECB279
        public int InstanceCount()
        {
            if (Sku() != null && Sku().Capacity != null)
            {
                return Sku().Capacity.Value;
            }
            else
            {
                return 1;
            }
        }

        public ApplicationGatewayAutoscaleConfiguration AutoscaleConfiguration
        {
            get
            {
                return this.Inner.AutoscaleConfiguration;
            }
        }

        public ApplicationGatewayWebApplicationFirewallConfiguration WebApplicationFirewallConfiguration
        {
            get
            {
                return this.Inner.WebApplicationFirewallConfiguration;
            }
        }



        ///GENMHASH:77914F0D4FB485205682C4181EFAACC8:875B0523271DDA40BF052DD20E89DCA7
        public IReadOnlyDictionary<string, IApplicationGatewayListener> Listeners()
        {
            return listeners;
        }


        ///GENMHASH:B8F4D6119066B28FD6E6D77185F2C4C5:6E7F6F4E57E7226C275225C0B15F9215
        public IReadOnlyDictionary<string, IApplicationGatewayProbe> Probes()
        {
            return probes;
        }


        ///GENMHASH:37B3BFB70B7A5569F82FB660A259D248:E92DB289B022D8EE6CEDBF8D99A476BC
        public IApplicationGatewayFrontend DefaultPublicFrontend()
        {
            // Default means the only public one or the one tracked as default, if more than one public present
            var publicFrontends = PublicFrontends();
            if (publicFrontends.Count == 1)
            {
                defaultPublicFrontend = (ApplicationGatewayFrontendImpl)firstValueFromDictionary(publicFrontends);
            }
            else if (frontends.Count == 0)
            {
                defaultPublicFrontend = null;
            }

            return defaultPublicFrontend;
        }


        ///GENMHASH:56D5F87F4F5A3E1857D2D243C076EE30:59E2C0788337FAEAF9283E6BBEF1463E
        public ApplicationGatewayOperationalState OperationalState()
        {
            return Inner.OperationalState;
        }


        ///GENMHASH:A45CE73D7318CE351EAF634272B1CA21:AAFEA7A6CB469B72F235861703236767
        public IReadOnlyDictionary<string, IApplicationGatewayBackend> Backends()
        {
            return backends;
        }

        public IReadOnlyDictionary<string, int> FrontendPorts()
        {
            Dictionary<string, int> ports = new Dictionary<string, int>();
            if (Inner.FrontendPorts != null)
            {
                foreach (var portInner in Inner.FrontendPorts)
                {
                    if (portInner.Port != null)
                    {
                        ports.Add(portInner.Name, portInner.Port.Value);
                    }
                }
            }
            return ports;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:FEE32912F8CE067CB20B5A239BD484D3
        public ApplicationGatewaySkuName Size()
        {
            if (Sku() != null && Sku().Name != null)
            {
                return Sku().Name;
            }
            else
            {
                return ApplicationGatewaySkuName.StandardSmall;
            }
        }


        ///GENMHASH:F4EEE08685E447AE7D2A8F7252EC223A:AD6D522610CE6FE4E910DD88E42152F7
        public string PrivateIPAddress()
        {
            var frontend = DefaultPrivateFrontend();
            return (frontend != null) ? frontend.PrivateIPAddress : null;
        }


        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:9AE479D53BC930F7515CB230EE4EB7EF
        public string NetworkId()
        {
            var subnetRef = DefaultSubnetRef();
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }

        public ApplicationGatewaySku Sku()
        {
            return Inner.Sku;
        }


        ///GENMHASH:8535B0E23E6704558262509B5A55B45D:B0B422F1B1E66AA120E54D492AF6FDE5
        public IReadOnlyDictionary<string, IApplicationGatewayIPConfiguration> IPConfigurations()
        {
            return ipConfigs;
        }


        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> Frontends()
        {
            return frontends;
        }


        ///GENMHASH:691BBD1A543FA3E8C9A27D451AEF177E:FC8B3AE517369B64F33F8DC475426F01
        public IReadOnlyDictionary<string, IApplicationGatewayRequestRoutingRule> RequestRoutingRules()
        {
            return rules;
        }


        ///GENMHASH:E1FFDF5A7DA768AA3F4DBC943784DF12:60FA949AF41551509BEDF0FF5451A6CB
        public IReadOnlyDictionary<string, IApplicationGatewaySslCertificate> SslCertificates()
        {
            return sslCerts;
        }

        ///GENMHASH:5A41F1C04C87A2000891EE6DED384815:B14F04F0277AB38305E3F39FE27CEEA4
        public IReadOnlyDictionary<string, IApplicationGatewayAuthenticationCertificate> AuthenticationCertificates()
        {
            return authCertificates;
        }

        ///GENMHASH:6A7F875381DF37D9F784810F1A3E35BE:EFFE7386E0D8E0FFBD6399B90A1C3CF3
        public bool IsPrivate()
        {
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    return true;
                }
            }
            return false;
        }

        ///GENMHASH:E0590AC9AA5A0F99D441691F4D3A2D32:D7D2198FDD89429DD0FDD00CD2E1A8D3
        public IReadOnlyDictionary<string, IApplicationGatewayRedirectConfiguration> RedirectConfigurations()
        {
            return redirectConfigs;
        }

        ///GENMHASH:B9C8411DAA4D113FE18FEEEF1BE8CDB6:EBBE4DB86B4401A7F0C2E50102BABB4B
        internal string FutureResourceId()
        {
            return new StringBuilder()
                .Append(ResourceIdBase)
                .Append("/providers/Microsoft.Network/applicationGateways/")
                .Append(Name).ToString();
        }

        ///GENMHASH:327A257714E97E0CC9195D07369866F6:AC0B304DE3854395AFFCFBF726105B2C
        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> PublicFrontends()
        {
            Dictionary<string, IApplicationGatewayFrontend> publicFrontends = new Dictionary<string, IApplicationGatewayFrontend>();
            //GENMHASH:3BF87DE2E0C9BBAA60FEF8B345571B0D:78DEDBCE9849DD9B71BA61C7FBEA3261
            foreach (var frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    publicFrontends.Add(frontend.Name, frontend);
                }
            }

            return publicFrontends;
        }

        ///GENMHASH:336A01EC3CBEC3D567B7528698CA0183:B699ABF72548606674C97317B2B20760
        public IApplicationGatewayIPConfiguration DefaultIPConfiguration()
        {
            // Default means the only one
            if (ipConfigs.Count == 1)
            {
                return firstValueFromDictionary(ipConfigs);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:F819A402FF29D3234FF975971868AD05
        public ApplicationGatewayTier Tier()
        {
            //GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
            if (Sku() != null && Sku().Tier != null)
            {
                return Sku().Tier;
            }
            else
            {
                return ApplicationGatewayTier.Standard;
            }
        }


        ///GENMHASH:2911D7234EA1C2B2AC65B607D78B6E4A:1BA96F7ED47F4A48A42FC00578BB3810
        public bool IsPublic()
        {
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }


        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AD561DB8BFA1E730BA1B2810E86A05D2
        public string SubnetName()
        {
            var subnetRef = DefaultSubnetRef();
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }


        ///GENMHASH:2B1D79EF0701484A69266710AE199343:62BC79EC46523CAA9DA5DC9A5E4C242A
        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> PrivateFrontends()
        {
            Dictionary<string, IApplicationGatewayFrontend> privateFrontends = new Dictionary<string, IApplicationGatewayFrontend>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    privateFrontends.Add(frontend.Name, frontend);
                }
            }

            return privateFrontends;
        }


        ///GENMHASH:FCB784E90DCC27EAC6AD4B4C988E2752:580C47A60679C42D4A735BCB01B8EBAA
        public IPAllocationMethod PrivateIPAllocationMethod()
        {
            var frontend = DefaultPrivateFrontend();
            return (frontend != null) ? frontend.PrivateIPAllocationMethod : null;
        }


        ///GENMHASH:57B5349245E8E0AED639AD6C90041662:063BD48E0E23D6B9799E99CF466E9F2C
        public IReadOnlyDictionary<string, IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations()
        {
            return backendConfigs;
        }

        ///GENMHASH:F856C02184EB290DC74E5823D4280D7C:2E646A9F2FBAA3AFBE73DA6741052E7B
        public ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones()
        {
            var zones = new HashSet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId>();
            if (this.Inner.Zones != null)
            {
                foreach (var zone in this.Inner.Zones)
                {
                    zones.Add(AvailabilityZoneId.Parse(zone));
                }
            }
            return zones;
        }

        #endregion

        #region Actions

        #region InitializeChildren

        ///GENMHASH:14670FFEE8D86F167A4246AFE76F91E6:8F8A962E6738F94558583D11555C6B53
        private void InitializeRequestRoutingRulesFromInner()
        {
            rules = new Dictionary<string, IApplicationGatewayRequestRoutingRule>();
            var inners = Inner.RequestRoutingRules;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var rule = new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
                    rules[inner.Name] = rule;
                }
            }
        }


        ///GENMHASH:38719597698E42AABAD5A9917188C155:5FA623156A2242C0CC7212EF7D654C87
        private void InitializeFrontendsFromInner()
        {
            frontends = new Dictionary<string, IApplicationGatewayFrontend>();
            var inners = Inner.FrontendIPConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var frontend = new ApplicationGatewayFrontendImpl(inner, this);
                    frontends[inner.Name] = frontend;
                }
            }
        }


        ///GENMHASH:38BB8357245354CED812C58E4EC79068:D0C7FA8A585A667919422AC63F659988
        private void InitializeBackendsFromInner()
        {
            backends = new Dictionary<string, IApplicationGatewayBackend>();
            var inners = Inner.BackendAddressPools;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var backend = new ApplicationGatewayBackendImpl(inner, this);
                    backends[inner.Name] = backend;
                }
            }
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:8DDCE22AE3039E0E9218CEB83BFABE39
        protected override void InitializeChildrenFromInner()
        {
            InitializeConfigsFromInner();
            InitializeFrontendsFromInner();
            InitializeBackendsFromInner();
            InitializeProbesFromInner();
            InitializeBackendHttpConfigsFromInner();
            InitializeHttpListenersFromInner();
            InitializeRedirectConfigurationsFromInner();
            InitializeRequestRoutingRulesFromInner();
            InitializeSslCertificatesFromInner();
            InitializeAuthCertificatesFromInner();
            defaultPrivateFrontend = null;
            defaultPublicFrontend = null;
            creatablePipsByFrontend = new Dictionary<string, string>();
        }

        ///GENMHASH:3EB46226E14C9B9CCFF912B0282CE5C1:FFD3678F3F55BD30BC31D6891E52BB26
        private void InitializeBackendHttpConfigsFromInner()
        {
            backendConfigs = new Dictionary<string, IApplicationGatewayBackendHttpConfiguration>();
            var inners = Inner.BackendHttpSettingsCollection;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var httpConfig = new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
                    backendConfigs[inner.Name] = httpConfig;
                }
            }
        }

        ///GENMHASH:1F12F15BC25B4A670CBA526BA2A27CC0:CC90A63D0E46102BDCA3DC06F4351E69
        private void InitializeSslCertificatesFromInner()
        {
            sslCerts = new Dictionary<string, IApplicationGatewaySslCertificate>();
            var inners = Inner.SslCertificates;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var cert = new ApplicationGatewaySslCertificateImpl(inner, this);
                    sslCerts[inner.Name] = cert;
                }
            }
        }

        ///GENMHASH:5D11BCCC7B313AC8365DDCD02B3D3C0E:6BD3E4DB92C68B56AEEF7A6698BF4F36
        private void InitializeAuthCertificatesFromInner()
        {
            authCertificates = new Dictionary<string, IApplicationGatewayAuthenticationCertificate>();
            var inners = Inner.AuthenticationCertificates;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var cert = new ApplicationGatewayAuthenticationCertificateImpl(inner, this);
                    authCertificates[inner.Name] = cert;
                }
            }
        }


        ///GENMHASH:D10DEC59828FEAE61D059EA56D310BFE:737D6276B1E5196C60857543D991183B
        private void InitializeConfigsFromInner()
        {
            ipConfigs = new Dictionary<string, IApplicationGatewayIPConfiguration>();
            var inners = Inner.GatewayIPConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var config = new ApplicationGatewayIPConfigurationImpl(inner, this);
                    ipConfigs[inner.Name] = config;
                }
            }
        }

        ///GENMHASH:1BF0F12490FA45AD10A769BD3E1DBCE0:F21EB5FEC19603A14FB7AB39DAAB819C
        private void InitializeRedirectConfigurationsFromInner()
        {
            this.redirectConfigs = new Dictionary<string, IApplicationGatewayRedirectConfiguration>();
            var inners = Inner.RedirectConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var redirectConfig = new ApplicationGatewayRedirectConfigurationImpl(inner, this);
                    redirectConfigs[inner.Name] = redirectConfig;
                }
            }
        }

        ///GENMHASH:12C04D490C1E5A715E97451A0D94F9ED:D101CE8411B06DE3265B59453968C2B5
        private void InitializeProbesFromInner()
        {
            probes = new Dictionary<string, IApplicationGatewayProbe>();
            var inners = Inner.Probes;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var probe = new ApplicationGatewayProbeImpl(inner, this);
                    probes[inner.Name] = probe;
                }
            }
        }


        ///GENMHASH:709E56A3C42D339048D2196CAAA5ED3F:D1F930D6EF465080D5C775FDA7AD0C5D
        private void InitializeHttpListenersFromInner()
        {
            listeners = new Dictionary<string, IApplicationGatewayListener>();
            var inners = Inner.HttpListeners;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var httpListener = new ApplicationGatewayListenerImpl(inner, this);
                    listeners[inner.Name] = httpListener;
                }
            }
        }

        #endregion

        #region EnsureDefaults

        ///GENMHASH:4AC8CF7D9CB1EC685C6E9B19CE307C6F:4FF8A20C7B73976BBB52E3B303B0071A
        private SubResource DefaultSubnetRef()
        {
            var ipConfig = DefaultIPConfiguration();
            return (ipConfig != null) ? ipConfig.Inner.Subnet : null;
        }


        ///GENMHASH:284892F1C09754FA6CF4266448D10168:6A6B9DA04BA6ED95CE65132FD1333E49
        public IApplicationGatewayFrontend DefaultPrivateFrontend()
        {
            // Default means the only private one or the one tracked as default, if more than one private present
            var privateFrontends = PrivateFrontends();
            if (privateFrontends.Count == 1)
            {
                defaultPrivateFrontend = (ApplicationGatewayFrontendImpl)firstValueFromDictionary(privateFrontends);
            }
            else if (frontends.Count == 0)
            {
                defaultPrivateFrontend = null;
            }
            return defaultPrivateFrontend;
        }

        private ICreatable<IPublicIPAddress> EnsureDefaultPipDefinition()
        {
            if (creatablePip == null)
            {
                string pipName = SdkContext.RandomResourceName("pip", 9);
                creatablePip = Manager.PublicIPAddresses.Define(pipName)
                    .WithRegion(RegionName)
                    .WithExistingResourceGroup(ResourceGroupName);
            }

            return creatablePip;
        }

        ///GENMHASH:DA0903CF2B09DA8DCF45A148EE669133:D97F93B7ABEAE3431739078545E09C40
        internal ApplicationGatewayFrontendImpl EnsureDefaultPublicFrontend()
        {
            var frontend = (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
            if (frontend != null)
            {
                return frontend;
            }
            else
            {
                string name = SdkContext.RandomResourceName("frontend", 14);
                frontend = DefineFrontend(name);
                frontend.Attach();
                defaultPublicFrontend = frontend;
                return frontend;
            }
        }

        ///GENMHASH:0F667C94F2289EF36EC5F8C809B0D66D:F1B5F3BA63562C878DFF9E5423468A20
        internal ApplicationGatewayFrontendImpl EnsureDefaultPrivateFrontend()
        {
            var frontend = (ApplicationGatewayFrontendImpl)DefaultPrivateFrontend();
            if (frontend != null)
            {
                return frontend;
            }
            else
            {
                string name = SdkContext.RandomResourceName("frontend", 14);
                frontend = DefineFrontend(name);
                frontend.Attach();
                defaultPrivateFrontend = frontend;
                return frontend;
            }
        }

        ///GENMHASH:6EBB2EF319A59A13633F5A0954A40EF9:B44639C1A659C86BD5BC13258E72B463
        private ApplicationGatewayIPConfigurationImpl EnsureDefaultIPConfig()
        {
            ApplicationGatewayIPConfigurationImpl ipConfig = (ApplicationGatewayIPConfigurationImpl)DefaultIPConfiguration();
            if (ipConfig == null)
            {
                string name = SdkContext.RandomResourceName("ipcfg", 11);
                ipConfig = DefineIPConfiguration(name);
                ipConfig.Attach();
            }

            return ipConfig;
        }

        private ICreatable<INetwork> EnsureDefaultNetworkDefinition()
        {
            if (creatableNetwork == null)
            {
                string vnetName = SdkContext.RandomResourceName("vnet", 10);
                creatableNetwork = Manager.Networks.Define(vnetName)
                    .WithRegion(Region)
                    .WithExistingResourceGroup(ResourceGroupName)
                    .WithAddressSpace("10.0.0.0/24")
                    .WithSubnet(DEFAULT, "10.0.0.0/25")
                    .WithSubnet("apps", "10.0.0.128/25");
            }

            return creatableNetwork;
        }

        #endregion

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:0EFE916900B9CDEBA2BCE71471195243
        public override async Task<IApplicationGateway> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            InitializeChildrenFromInner();
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:1559E5218F079E5EF7779F023F4EF358
        protected override async Task<ApplicationGatewayInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.ApplicationGateways.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:27E486AB74A10242FF421C0798DDC450
        protected override void AfterCreating()
        {
        }

        private V firstValueFromDictionary<K, V>(IReadOnlyDictionary<K, V> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return default(V);
            }

            var enumerator = dictionary.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:5CAB3E21FBC755ECC242114444212594
        protected async override Task<ApplicationGatewayInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();

            // Determine if a default public frontend PIP should be created
            ApplicationGatewayFrontendImpl defaultPublicFrontend = (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
            if (defaultPublicFrontend != null && defaultPublicFrontend.PublicIPAddressId() == null)
            {
                // If default public frontend requested but no PIP specified, create one
                //GENMHASH:D232B3BB0D86D13CC0B242F4000DBF07:28278DE68BEBBF206C58F1B8AC9DEA79
                Task pipTask = Task.Run(async () =>
               {
                   var publicIP = await EnsureDefaultPipDefinition().CreateAsync(cancellationToken);
                   // Attach the created PIP when available
                   defaultPublicFrontend.WithExistingPublicIPAddress(publicIP);
               });
                tasks.Add(pipTask);
            }

            // Determine if default VNet should be created
            var defaultIPConfig = EnsureDefaultIPConfig();
            var defaultPrivateFrontend = (ApplicationGatewayFrontendImpl)DefaultPrivateFrontend();
            if (defaultIPConfig.SubnetName() != null)
            {
                // If default IP config already has a subnet assigned to it...
                if (defaultPrivateFrontend != null)
                {
                    // ...And a private frontend is requested, then use the same vnet for the private frontend
                    UseSubnetFromIPConfigForFrontend(defaultIPConfig, defaultPrivateFrontend);
                }

                // ...And no need to create a default VNet
            }
            else
            {
                // But if default IP config does not have a subnet specified, then create a default VNet
                //GENMHASH:378C5280A44231F5593B789FF6A1BF16:91307BB6F8D393A842145FECCE969E10
                Task networkTask = Task.Run(async () =>
               {
                   var network = await EnsureDefaultNetworkDefinition().CreateAsync(cancellationToken);
                   //... and assign the created VNet to the default IP config
                   defaultIPConfig.WithExistingSubnet(network, DEFAULT);
                   if (defaultPrivateFrontend != null)
                   {
                       // If a private frontend is also requested, then use the same VNet for the private frontend as for the IP config
                       /* TODO: Not sure if the assumption of the same subnet for the frontend and the IP config will hold in
                        * the future, but the existing ARM template for App Gateway for some reason uses the same subnet for the
                        * IP config and the private frontend. Also, trying to use different subnets results in server error today saying they
                        * have to be the same. This may need to be revisited in the future however, as this is somewhat inconsistent
                        * with what the documentation says.
                        */
                       UseSubnetFromIPConfigForFrontend(defaultIPConfig, defaultPrivateFrontend);
                   }
               });
                tasks.Add(networkTask);
            }

            await Task.WhenAll(tasks.ToArray());
            return await Manager.Inner.ApplicationGateways.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }

        ///GENMHASH:644A3298215000D78F5173C9BC6F440E:9BEBC7254CB4CA864A9951088E837542
        internal bool? NeedToCreate<T>(T byName, T byPort, string name)
        {
            if (byName != null && byPort != null)
            {
                // If objects with this name and/or port already exist...
                if (byName.Equals(byPort))
                {
                    // ...And it is the same object, then do nothing
                    return false;
                }
                else
                {
                    // ...But if they are inconsistent, then fail fast
                    return null;
                }
            }
            else if (byPort != null)
            {
                // If no object with the requested name, but the port number is found...
                if (name == null)
                {
                    // ...And no name is requested, then do nothing, because the object already exists
                    return false;
                }
                else
                {
                    // ...But if a clashing name is requested, then fail fast
                    return null;
                }
            }
            else
            {
                // Ok to create the object
                return true;
            }
        }


        ///GENMHASH:14F7DD0CCDC186C5D168ACB6CB854BB8:868D5AF8DC9DF55FFB81A661D259F2BC
        private static ApplicationGatewayFrontendImpl UseSubnetFromIPConfigForFrontend(
            ApplicationGatewayIPConfigurationImpl ipConfig,
            ApplicationGatewayFrontendImpl frontend)
        {
            if (frontend != null)
            {
                frontend.WithExistingSubnet(ipConfig.NetworkId(), ipConfig.SubnetName());
                if (frontend.PrivateIPAddress() == null)
                {
                    frontend.WithPrivateIPAddressDynamic();
                }
                else if (frontend.PrivateIPAllocationMethod() == null)
                {
                    frontend.WithPrivateIPAddressDynamic();
                }
            }

            return frontend;
        }


        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:9CD80B909C32FDD24B948AE9C4F66098
        protected override void BeforeCreating()
        {
            // Process created PIPs
            foreach (var frontendPipPair in creatablePipsByFrontend)
            {
                var createdPip = CreatedResource(frontendPipPair.Value);
                UpdateFrontend(frontendPipPair.Key).WithExistingPublicIPAddress(createdPip.Id);
            }
            creatablePipsByFrontend.Clear();

            // Reset and update IP configs
            EnsureDefaultIPConfig();
            Inner.GatewayIPConfigurations = InnersFromWrappers<ApplicationGatewayIPConfigurationInner, IApplicationGatewayIPConfiguration>(ipConfigs.Values);

            // Reset and update frontends
            Inner.FrontendIPConfigurations = InnersFromWrappers<ApplicationGatewayFrontendIPConfigurationInner, IApplicationGatewayFrontend>(frontends.Values);

            // Reset and update probes
            Inner.Probes = InnersFromWrappers<ApplicationGatewayProbeInner, IApplicationGatewayProbe>(probes.Values);

            // Reset and update auth certs
            Inner.AuthenticationCertificates = InnersFromWrappers<ApplicationGatewayAuthenticationCertificateInner, IApplicationGatewayAuthenticationCertificate>(authCertificates.Values);

            // Reset and update backends
            Inner.BackendAddressPools = InnersFromWrappers<ApplicationGatewayBackendAddressPoolInner, IApplicationGatewayBackend>(backends.Values);

            // Reset and update SSL certs
            Inner.SslCertificates = InnersFromWrappers<ApplicationGatewaySslCertificateInner, IApplicationGatewaySslCertificate>(sslCerts.Values);

            // Reset and update backend HTTP settings configs
            Inner.BackendHttpSettingsCollection = InnersFromWrappers<ApplicationGatewayBackendHttpSettingsInner, IApplicationGatewayBackendHttpConfiguration>(backendConfigs.Values);
            foreach (var config in backendConfigs.Values)
            {
                // Clear deleted probe references  
                SubResource configRef;
                configRef = config.Inner.Probe;
                if (configRef != null && !Probes().ContainsKey(ResourceUtils.NameFromResourceId(configRef.Id)))
                {
                    config.Inner.Probe = null;
                }

                // Clear deleted auth cert references
                var certRefs = config.Inner.AuthenticationCertificates;
                if (certRefs != null)
                {
                    // Make a copy of the cert refs, because we will be deleting in place
                    certRefs = new List<SubResource>(certRefs);
                    foreach (var certRef in certRefs)
                    {
                        if (certRef != null && !this.authCertificates.ContainsKey(ResourceUtils.NameFromResourceId(certRef.Id)))
                        {
                            config.Inner.AuthenticationCertificates.Remove(certRef);
                        }
                    }
                }
            }

            // Reset and update redirect configurations
            Inner.RedirectConfigurations = InnersFromWrappers<ApplicationGatewayRedirectConfigurationInner, IApplicationGatewayRedirectConfiguration>(redirectConfigs.Values);
            foreach (var redirect in redirectConfigs.Values)
            {
                SubResource subRef;

                // Clear deleted listener references
                subRef = redirect.Inner.TargetListener;
                if (subRef != null && !listeners.ContainsKey(ResourceUtils.NameFromResourceId(subRef.Id)))
                {
                    redirect.Inner.TargetListener = null;
                }
            }

            // Reset and update HTTP listeners
            Inner.HttpListeners = InnersFromWrappers<ApplicationGatewayHttpListenerInner, IApplicationGatewayListener>(listeners.Values);
            foreach (var listener in listeners.Values)
            {
                SubResource r;

                // Clear deleted frontend references
                r = listener.Inner.FrontendIPConfiguration;
                if (r != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.FrontendIPConfiguration = null;
                }

                // Clear deleted frontend port references
                r = listener.Inner.FrontendPort;
                if (r != null && !FrontendPorts().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.FrontendPort = null;
                }

                // Clear deleted SSL certificate references
                r = listener.Inner.SslCertificate;
                if (r != null && !SslCertificates().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.SslCertificate = null;
                }
            }

            // Reset and update request routing rules
            Inner.RequestRoutingRules = InnersFromWrappers<ApplicationGatewayRequestRoutingRuleInner, IApplicationGatewayRequestRoutingRule>(rules.Values);
            foreach (var rule in rules.Values)
            {
                SubResource r;

                // Clear deleted redirect configs
                r = rule.Inner.RedirectConfiguration;
                if (r != null && !redirectConfigs.ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.RedirectConfiguration = null;
                }

                // Clear deleted backends
                r = rule.Inner.BackendAddressPool;
                if (r != null && !this.Backends().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.BackendAddressPool = null;
                }

                // Clear deleted backend HTTP configs
                r = rule.Inner.BackendHttpSettings;
                if (r != null && !BackendHttpConfigurations().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.BackendHttpSettings = null;
                }

                // Clear deleted frontend HTTP listeners
                r = rule.Inner.HttpListener;
                if (r != null && !Listeners().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.HttpListener = null;
                }
            }
        }

        ///GENMHASH:2572DE01031DBF4160442C8972FF5A5E:82DF98F81461A048AF4598C642544BE3
        public string FrontendPortNameFromNumber(int portNumber)
        {
            string portName = null;
            //GENMHASH:F0126379A1F65359204BD22C7CF55E7C:BE15CAD584433DEAF8B46C62642E8728
            foreach (var portEntry in FrontendPorts())
            {
                if (portNumber == portEntry.Value)
                {
                    portName = portEntry.Key;
                    break;
                }
            }

            return portName;
        }


        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:8E7C5AF309A720AEBD981CD714D58952
        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.ApplicationGateways.Inner.StartAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }


        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:E0F8963F5DAB9A54987EBE382946F816
        public void Start()
        {
            Extensions.Synchronize(() => StartAsync());
        }


        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:5A2F4445DA73DB06DF8066E5B2B6EF28
        public void Stop()
        {
            Extensions.Synchronize(() => StopAsync());
        }


        ///GENMHASH:D6FBED7FC7CBF34940541851FF5C3CC1:9E4F1BE9C6626B590BF7E05F4AD83D73
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.ApplicationGateways.Inner.StopAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:DF33B11AB8B490CB0B236CD72B44740F:806736DF09AB90BDDD8E032352FC75F7
        public IApplicationGatewayListener ListenerByPortNumber(int portNumber)
        {
            IApplicationGatewayListener listener = null;
            foreach (var l in listeners.Values)
            {
                if (l.FrontendPortNumber == portNumber)
                {
                    listener = l;
                    break;
                }
            }

            return listener;
        }

        #endregion

        ///GENMHASH:5961EF29B91233084DDE586640FCAF86:C8D820DCD1845E2AEC8FDB7B815F4CBB
        public IReadOnlyDictionary<string, IApplicationGatewayBackendHealth> CheckBackendHealth()
        {
            return Extensions.Synchronize(() => CheckBackendHealthAsync());
        }

        ///GENMHASH:B8731D2E2E62238DEBE0CE572737E938:90C43EE6AF0C4E511DAD7DE9A61CF5D5
        public async Task<IReadOnlyDictionary<string, IApplicationGatewayBackendHealth>> CheckBackendHealthAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, IApplicationGatewayBackendHealth> backendHealths = new Dictionary<string, IApplicationGatewayBackendHealth>();
            var inner = await Manager.Inner.ApplicationGateways.BackendHealthAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
            if (inner != null)
            {
                foreach (var healthInner in inner.BackendAddressPools)
                {
                    var backendHealth = new ApplicationGatewayBackendHealthImpl(healthInner, this);
                    backendHealths[backendHealth.Name()] = backendHealth;
                }
            }

            return backendHealths;
        }

        ///GENMHASH:A344A4F9D7CDC949D6AF4D6C2484309C:DCEBF1B4C62EB4BB703EA8539BED4C30
        internal SubResource EnsureBackendRef(string name)
        {
            // Ensure existence of backend, creating one if needed
            ApplicationGatewayBackendImpl backend;
            if (name == null)
            {
                backend = EnsureUniqueBackend();
            }
            else
            {
                backend = DefineBackend(name);
                backend.Attach();
            }

            // Return backend reference
            return new SubResource()
            {
                Id = FutureResourceId() + "/backendAddressPools/" + backend.Name()
            };
        }

        ///GENMHASH:51714851388882936938461B23BE6E15:71A6B15DE25017ECD45BBD4F3635B393
        internal ApplicationGatewayBackendImpl EnsureUniqueBackend()
        {
            string name = SdkContext.RandomResourceName("backend", 20);
            var backend = DefineBackend(name);
            backend.Attach();
            return backend;
        }
    }
}
