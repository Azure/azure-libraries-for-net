// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayBackendHttpConfiguration.Definition;
    using ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;
    using System;
    using System.IO;

    /// <summary>
    /// Implementation for ApplicationGatewayBackendHttpConfiguration.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZEh0dHBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class ApplicationGatewayBackendHttpConfigurationImpl :
        ChildResource<ApplicationGatewayBackendHttpSettingsInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayBackendHttpConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate
    {

        ///GENMHASH:B42BC3A9C7262D63AB700D3AA7560DE4:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayBackendHttpConfigurationImpl(ApplicationGatewayBackendHttpSettingsInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Accessors

        ///GENMHASH:CBD5619B88DD95DAF0A3CF8BC5B3D92C:6147E08E9DB4B50DF4FFDC2AF2A42B50
        public string AffinityCookieName()
        {
            return Inner.AffinityCookieName;
        }

        ///GENMHASH:4F2B8A33E08B4F75B92FC8A20F850BEB:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostHeader()
        {
            return Inner.HostName;
        }

        ///GENMHASH:8DD7957DF346525387CB5260FCB137FA:9E96D894B08BF26B7839105F76681D56
        public string Path()
        {
            return Inner.Path;
        }

        ///GENMHASH:24C641FB2387A4861E66C83590D3EF98:648638ADACA38C989546F4596185DB78
        public bool IsHostHeaderFromBackend()
        {
            return (Inner.PickHostNameFromBackendAddress != null) ? Inner.PickHostNameFromBackendAddress.Value : false;
        }

        ///GENMHASH:14DD7EA1DCC055491882C09E4FEE4822:17D6F5197FC1375A5E7F5E5812582FC0
        public bool IsProbeEnabled()
        {
            return (Inner.ProbeEnabled != null) ? Inner.ProbeEnabled.Value : false;
        }

        ///GENMHASH:2E2AC3A99EA3D6CABD90960D25C18DFF:6F2EDC3E1B0D68839C887FBB475C9FC5
        public int ConnectionDrainingTimeoutInSeconds()
        {
            if (Inner.ConnectionDraining == null)
            {
                return 0;
            }
            else if (!Inner.ConnectionDraining.Enabled)
            {
                return 0;
            }
            else
            {
                return Inner.ConnectionDraining.DrainTimeoutInSec;
            }
        }

        ///GENMHASH:7C8DB8F49BE9ADE0ACDDE918992D9275:9905DA010A33007637D8302DD76D0464
        internal IApplicationGatewayProbe Probe()
        {
            if (Parent.Probes() != null && Inner.Probe != null)
            {
                IApplicationGatewayProbe probe;
                if (Parent.Probes().TryGetValue(ResourceUtils.NameFromResourceId(Inner.Probe.Id), out probe))
                {
                    return probe;
                }
            }
            return null;
        }


        ///GENMHASH:D319F463FBCA0E7C5434F8E5BDE378E5:71EB18EE608CA38D9128AA7F38378AC1
        public int RequestTimeout()
        {
            if (Inner.RequestTimeout != null)
            {
                return Inner.RequestTimeout.Value;
            }
            else
            {
                return 0;
            }
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }


        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public ApplicationGatewayProtocol Protocol()
        {
            return Inner.Protocol;
        }


        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:F0090A6ECB1B91C3BCFD966232A4C1D4
        public int Port()
        {
            return Inner.Port != null ? Inner.Port.Value : 0;
        }


        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }


        ///GENMHASH:0BBB3340617BD27DD6A3E851FD10BEE1:D4B1DE858DBE0FCA40F8B11A09E4AE8E
        public bool CookieBasedAffinity()
        {
            if (Inner.CookieBasedAffinity != null)
            {
                return Inner.CookieBasedAffinity.Equals(ApplicationGatewayCookieBasedAffinity.Enabled);
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Withers

        ///GENMHASH:E0DC5F5C03382BBF3A0349BC91DDC14F:2B335F3E25E8B33FD878F86BDFC8E03F
        internal ApplicationGatewayBackendHttpConfigurationImpl WithProbe(string name)
        {
            if (name == null)
            {
                return WithoutProbe();
            }
            else
            {
                SubResource probeRef = new SubResource()
                {
                    Id = Parent.FutureResourceId() + "/probes/" + name
                };
                Inner.Probe = probeRef;
                return this;
            }
        }

        ///GENMHASH:A3D4AA91AD97459B1911D4F17C8B14E9:B88CC0ACCC1BD8E7A581B4D508B7DA4A
        internal ApplicationGatewayBackendHttpConfigurationImpl WithoutProbe()
        {
            Inner.Probe = null;
            return this;
        }


        ///GENMHASH:1B3DD32E4CACEF2636F8CF7212EEF52E:FC8C0EA002F6B85E131BB2C555A8F3D8
        internal ApplicationGatewayBackendHttpConfigurationImpl WithRequestTimeout(int seconds)
        {
            Inner.RequestTimeout = seconds;
            return this;
        }


        ///GENMHASH:A473E8C551A81C93BD8EA73FE99E314B:D6F3848D67AE407B04179F01B8D24165
        public ApplicationGatewayBackendHttpConfigurationImpl WithProtocol(ApplicationGatewayProtocol protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }


        ///GENMHASH:7884DB3A8071CC7B3FBB06615EBA996B:0FD6C5C4BA833CCFCF251D843F409A11
        public ApplicationGatewayBackendHttpConfigurationImpl WithPort(int port)
        {
            Inner.Port = port;
            return this;
        }


        ///GENMHASH:1AB1FD137FCAFECBC19E784B21600422:10A96FEB729903AF130DD82C103101D1
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutCookieBasedAffinity()
        {
            Inner.CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled;
            return this;
        }


        ///GENMHASH:389A52ADE2A3CD0EC1D4345823ED3438:13D32358E52B5009580D8507FF729FC8
        public ApplicationGatewayBackendHttpConfigurationImpl WithCookieBasedAffinity()
        {
            Inner.CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled;
            return this;
        }

        ///GENMHASH:97A942481994526903BE02DCABFA02E2:B1BA994A46F6263EEC90776D84249F0C
        public ApplicationGatewayBackendHttpConfigurationImpl WithHostHeaderFromBackend()
        {
            Inner.PickHostNameFromBackendAddress = true;
            Inner.HostName = null;
            return this;
        }

        ///GENMHASH:4E3EB4A448A6ABDF242218CB75923DB2:F5CDA6E82BA0EE1BD4A4BB934B982AA2
        public ApplicationGatewayBackendHttpConfigurationImpl WithConnectionDrainingTimeoutInSeconds(int seconds)
        {
            if (Inner.ConnectionDraining == null)
            {
                Inner.ConnectionDraining = new ApplicationGatewayConnectionDraining();
            }
            if (seconds > 0)
            {
                Inner.ConnectionDraining.DrainTimeoutInSec = seconds;
                Inner.ConnectionDraining.Enabled = true;
            }
            return this;
        }

        ///GENMHASH:5BE0305CB1C892A00BF8A1FB3C691F4E:0AA60007DE591D0F54FD4031B9E47EA0
        public ApplicationGatewayBackendHttpConfigurationImpl WithAuthenticationCertificate(string name)
        {
            if (name == null)
            {
                return this;
            }

            SubResource certRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/authenticationCertificates/" + name
            };

            var refs = Inner.AuthenticationCertificates;
            if (refs == null)
            {
                refs = new List<SubResource>();
                Inner.AuthenticationCertificates = refs;
            }

            foreach (var c in refs)
            {
                if (c.Id.Equals(certRef.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return this;
                }
            }

            refs.Add(certRef);
            return this.WithHttps();
        }

        ///GENMHASH:D89763E755D0DB99E48A9AB1BBD41135:6ABD4E87D5E0D91B7919E753C404F770
        public ApplicationGatewayBackendHttpConfigurationImpl WithAffinityCookieName(string name)
        {
            Inner.AffinityCookieName = name;
            return this;
        }

        ///GENMHASH:5A41F1C04C87A2000891EE6DED384815:920A1F7E5C1D312680456892F7B1DB27
        public IReadOnlyDictionary<string, IApplicationGatewayAuthenticationCertificate> AuthenticationCertificates()
        {
            Dictionary<string, IApplicationGatewayAuthenticationCertificate> certs = new Dictionary<string, IApplicationGatewayAuthenticationCertificate>();
            if (Inner.AuthenticationCertificates == null)
            {
                return certs;
            }
            else
            {
                foreach (var c in Inner.AuthenticationCertificates)
                {
                    IApplicationGatewayAuthenticationCertificate cert = null;
                    if (Parent.AuthenticationCertificates().TryGetValue(ResourceUtils.NameFromResourceId(c.Id), out cert))
                    {
                        certs[cert.Name] = cert;
                    }
                }
            }
            return certs;
        }

        ///GENMHASH:A76FBD3FA61158B96AEAFA3D2B668A0F:1E230EF97513FA87FAFC6056A4AC29F5
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutConnectionDraining()
        {
            Inner.ConnectionDraining = null;
            return this;
        }

        ///GENMHASH:EEDF992F7513A5EDB4C6ABA705C4BE66:D5512189ABC55838FF332B0C38684252
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutAuthenticationCertificate(string name)
        {
            if (name == null)
            {
                return this;
            }

            foreach (var c in Inner.AuthenticationCertificates)
            {
                if (ResourceUtils.NameFromResourceId(c.Id).Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Inner.AuthenticationCertificates.Remove(c);
                    break;
                }
            }
            return this;
        }

        ///GENMHASH:94AEAD3A6B85DEA04678F7DA691082B1:AE2E7F836BF1B71A27832FB07777BC05
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutAuthenticationCertificates()
        {
            Inner.AuthenticationCertificates = null;
            return this;
        }

        ///GENMHASH:FA888A1E446DDA9E368D1EF43B428BAC:E284CF01C0CAA27F5A90C3ABCFAC1A76
        public ApplicationGatewayBackendHttpConfigurationImpl WithHttps()
        {
            return WithProtocol(ApplicationGatewayProtocol.Https);
        }

        ///GENMHASH:B84DDC1D7117A27DB5A5DFF71CFF86D0:9374E5D21B3799EDAF1823933B92B277
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutHostHeader()
        {
            Inner.HostName = null;
            Inner.PickHostNameFromBackendAddress = false;
            return this;
        }

        ///GENMHASH:5319363BA516693C02815523816AB844:402DF6E230AE7E19F224B7B81E3EB890
        public ApplicationGatewayBackendHttpConfigurationImpl WithPath(string path)
        {
            if (path != null)
            {
                if (!path.StartsWith("/"))
                {
                    path = "/" + path;
                }
                if (!path.EndsWith("/"))
                {
                    path += "/";
                }
            }
            Inner.Path = path;
            return this;
        }

        ///GENMHASH:6F62B34CB3A912AA692DBF18C6F448CB:CEF72EC0F209FFC140240A2F69632039
        public ApplicationGatewayBackendHttpConfigurationImpl WithHostHeader(string hostHeader)
        {
            Inner.HostName = hostHeader;
            Inner.PickHostNameFromBackendAddress = false;
            return this;
        }

        ///GENMHASH:93249EB17DAE215D40AC4D267DB3C6BD:A4F6024C710BD15A9E8D6A6ACA5D23BC
        public ApplicationGatewayBackendHttpConfigurationImpl WithAuthenticationCertificateFromBase64(string base64Data)
        {
            if (base64Data == null)
            {
                return this;
            }

            string certName = null;
            foreach (var cert in Parent.AuthenticationCertificates().Values)
            {
                if (cert.Data.Equals(base64Data))
                {
                    certName = cert.Name;
                    break;
                }
            }

            // If matching cert reference not found, create a new one
            if (certName == null)
            {
                certName = SdkContext.RandomResourceName("cert", 20);
                Parent.DefineAuthenticationCertificate(certName)
                    .FromBase64(base64Data)
                    .Attach();
            }

            return WithAuthenticationCertificate(certName).WithHttps();
        }

        ///GENMHASH:E1FA92658F1B92C66F2FDD601E75E424:960E9F85159C8B553E68FFD0B6E32452
        public ApplicationGatewayBackendHttpConfigurationImpl WithAuthenticationCertificateFromFile(FileInfo certificateFile)
        {
            if (certificateFile == null)
            {
                return this;
            }
            else
            {
                byte[] content = File.ReadAllBytes(certificateFile.FullName);
                return WithAuthenticationCertificateFromBytes(content);
            }
        }

        ///GENMHASH:56C13893A2D98E37AE84BCEA0910F728:F96F659A9562AA4331E2A4A484A93C17
        public ApplicationGatewayBackendHttpConfigurationImpl WithAuthenticationCertificateFromBytes(params byte[] derData)
        {
            if (derData == null)
            {
                return this;
            }

            string encoded = Convert.ToBase64String(derData);
            return WithAuthenticationCertificateFromBase64(encoded);
        }

        ///GENMHASH:604F12B361C77B3E3AD5768A73BA6DCF:8AB2D8CE074B69C5402393587D90152D
        public ApplicationGatewayBackendHttpConfigurationImpl WithHttp()
        {
            return WithoutAuthenticationCertificates()
                .WithProtocol(ApplicationGatewayProtocol.Http);
        }

        #endregion

        #region Actions


        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:C4B2E1F47C2D40EFC60B0A131C0D8A67
        public ApplicationGatewayImpl Attach()
        {
            Parent.WithBackendHttpConfiguration(this);
            return Parent;
        }

        #endregion
    }
}
