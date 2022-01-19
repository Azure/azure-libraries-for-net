// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PrivateLinkServiceImpl :
        GroupableResource<IPrivateLinkService,
            PrivateLinkServiceInner,
            PrivateLinkServiceImpl,
            INetworkManager,
            PrivateLinkService.Definition.IWithCreate,
            PrivateLinkService.Definition.IWithCreate, 
            PrivateLinkService.Definition.IWithCreate,
            PrivateLinkService.Update.IUpdate>,
        IPrivateLinkService,
        PrivateLinkService.Definition.IDefinition,
        PrivateLinkService.Update.IUpdateCombined
    {
        private IDictionary<string, PrivateLinkServiceIpConfigurationInner> ipConfigurations;
        private IDictionary<string, FrontendIPConfigurationInner> frontendIpConfigurations;
        private PrivateLinkServiceIpConfigurationInner ipConfigurationInstance;
        private FrontendIPConfigurationInner frontendIpConfigurationInstance;
        private string privateConnectionName;
        private PrivateEndpointInner privateEndpointInner;
        private PrivateLinkServiceConnectionState privateConnectionState;

        internal PrivateLinkServiceImpl(string name, PrivateLinkServiceInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
            InitIpConfigurationCollections(innerModel);
            ResetIpConfigurations();
        }

        public IReadOnlyList<ILoadBalancerFrontend> LoadBalancerFrontendIpConfigurations
        {
            get
            {
                List<ILoadBalancerFrontend> loadBalancerFrontends = new List<ILoadBalancerFrontend>();
                Dictionary<string, LoadBalancerInner> loadBalancers = new Dictionary<string, LoadBalancerInner>();
                if (Inner.LoadBalancerFrontendIpConfigurations != null)
                {
                    foreach (var lbFrontend in Inner.LoadBalancerFrontendIpConfigurations)
                    {
                        FrontendIPConfigurationInner lbFrontendInner = lbFrontend;

                        LoadBalancerInner loadBalancer;
                        string loadBalancerId = ResourceId.FromString(lbFrontend.Id).Parent.Id;
                        if (!loadBalancers.ContainsKey(loadBalancerId))
                        {
                            loadBalancer = Manager.LoadBalancers.GetById(loadBalancerId).Inner;
                            loadBalancers.Add(loadBalancerId, loadBalancer);

                            if (lbFrontend.Name == null)
                            {
                                // resposne of PrivateLinkServiceInner only have Id in item of LoadBalancerFrontendIpConfigurations
                                // so use the FrontendIPConfigurationInner from LoadBalancerInner instead
                                lbFrontendInner = loadBalancer.FrontendIPConfigurations.Where(f => f.Id == lbFrontend.Id).FirstOrDefault() ?? lbFrontend;
                            }
                        }
                        else
                        {
                            loadBalancer = loadBalancers[loadBalancerId];
                        }
                        loadBalancerFrontends.Add(new LoadBalancerFrontendImpl(lbFrontendInner, new LoadBalancerImpl(loadBalancer.Name, loadBalancer, Manager)));
                    }
                }
                return loadBalancerFrontends.AsReadOnly();
            }
        }

        public IReadOnlyList<IPrivateLinkServiceIPConfiguration> IpConfigurations
        {
            get
            {
                List<IPrivateLinkServiceIPConfiguration> privateLinkServiceIPConfigurations = new List<IPrivateLinkServiceIPConfiguration>();
                if (Inner.IpConfigurations != null)
                {
                    foreach (var ipConfig in Inner.IpConfigurations)
                    {
                        privateLinkServiceIPConfigurations.Add(new PrivateLinkServiceIPConfigurationImpl(ipConfig));
                    }
                }
                return privateLinkServiceIPConfigurations.AsReadOnly();
            }
        }

        public IReadOnlyList<INetworkInterface> NetworkInterfaces
        {
            get
            {
                List<INetworkInterface> networkInterfaces = new List<INetworkInterface>();
                if (Inner.NetworkInterfaces != null)
                {
                    foreach (var networkInterface in Inner.NetworkInterfaces)
                    {
                        networkInterfaces.Add(new NetworkInterfaceImpl(networkInterface.Name, networkInterface, Manager));
                    }
                    
                }
                return networkInterfaces.AsReadOnly();
            }
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public IReadOnlyList<IPrivateEndpointConnection> PrivateEndpointConnections
        {
            get
            {
                List<IPrivateEndpointConnection> privateEndpointConnections = new List<IPrivateEndpointConnection>();
                if (Inner.PrivateEndpointConnections != null)
                {
                    foreach (var privateEndpointConnection in Inner.PrivateEndpointConnections)
                    {
                        privateEndpointConnections.Add(new PrivateEndpointConnectionImpl(privateEndpointConnection, Manager));
                    }
                }
                return privateEndpointConnections.AsReadOnly();
            }
        }

        public IReadOnlyList<string> VisiblePrivateLinkServiceIds
        {
            get
            {
                List<string> visibleIds;
                if (Inner.Visibility != null && Inner.Visibility.Subscriptions != null)
                {
                    visibleIds = new List<string>(Inner.Visibility.Subscriptions);
                }
                else
                {
                    visibleIds = new List<string>();
                }
                return visibleIds.AsReadOnly();
            }
        }

        public IReadOnlyList<string> AutoApprovedPrivateLinkServiceIds
        {
            get
            {
                List<string> autoApprovedIds;
                if (Inner.AutoApproval != null && Inner.AutoApproval.Subscriptions != null)
                {
                    autoApprovedIds = new List<string>(Inner.AutoApproval.Subscriptions);
                }
                else
                {
                    autoApprovedIds = new List<string>();
                }
                return autoApprovedIds.AsReadOnly();
            }
        }

        public IReadOnlyList<string> Fqdns
        {
            get
            {
                List<string> fqdns;
                if (Inner.Fqdns != null)
                {
                    fqdns = new List<string>(Inner.Fqdns);
                }
                else
                {
                    fqdns = new List<string>();
                }
                return fqdns.AsReadOnly();
            }
        }

        public string Alias
        {
            get
            {
                return Inner.Alias;
            }
        }

        public bool IsProxyProtocolEnabled
        {
            get
            {
                return Inner.EnableProxyProtocol.HasValue && Inner.EnableProxyProtocol.Value == true;
            }
        }

        public string Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithAttach.Attach()
        {
            return Attach();
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithFrontendIpConfiguration.WithFrontendIpConfiguration(ILoadBalancerFrontend loadBalancerFrontend)
        {
            return WithFrontendIpConfiguration(loadBalancerFrontend);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithFrontendIpConfiguration.WithFrontendIpConfiguration(ILoadBalancerFrontend loadBalancerFrontend)
        {
            return WithFrontendIpConfiguration(loadBalancerFrontend);
        }

        public override async Task<IPrivateLinkService> CreateResourceAsync(CancellationToken cancellationToken)
        {
            UpdateInnerWithIpConfigurations();
            PrivateLinkServiceInner innerResource = await Manager.Inner.PrivateLinkServices.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                Inner,
                cancellationToken);
            SetInner(innerResource);
            return this;
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfiguration.DefinePrivateLinkServiceIpConfiguration(string name)
        {
            return DefinePrivateLinkServiceIpConfiguration(name);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithProxyProtocol.DisableProxyProtocol()
        {
            return DisableProxyProtocol();
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.SetAsNonPrimaryIpConfiguration()
        {
            return SetAsNonPrimaryIpConfiguration();
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.SetAsPrimaryIpConfiguration()
        {
            return SetAsPrimaryIpConfiguration();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfiguration.UpdatePrivateLinkServiceIpConfiguration(string name)
        {
            return UpdatePrivateLinkServiceIpConfiguration(name);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithAutoApproval.WithAutoApproval(string subscription)
        {
            return WithAutoApproval(subscription);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithAutoApproval.WithAutoApproval(IList<string> subscriptions)
        {
            return WithAutoApproval(subscriptions);
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithDynamicPrivateIpAllocation()
        {
            return WithDynamicPrivateIpAllocation();
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithFqdns.WithFullQualifiedDomainName(string domainName)
        {
            return WithFullQualifiedDomainName(domainName);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithFqdns.WithFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithFullQualifiedDomainNames(domainNames);
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithIpv4PrivateIpAddress()
        {
            return WithIpv4PrivateIpAddress();
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithIpv6PrivateIpAddress()
        {
            return WithIpv6PrivateIpAddress();
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithAutoApproval.WithoutAutoApproval(string subscription)
        {
            return WithoutAutoApproval(subscription);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithFrontendIpConfiguration.WithoutFrontendIpConfiguration(string name)
        {
            return WithoutFrontendIpConfiguration(name);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithFqdns.WithoutFullQualifiedDomainName(string domainName)
        {
            return WithoutFullQualifiedDomainName(domainName);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithPrivateLinkServiceIpConfiguration.WithoutPrivateLinkServiceIpConfiguration(string name)
        {
            return WithoutPrivateLinkServiceIpConfiguration(name);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithVisibility.WithoutVisibility(string subscription)
        {
            return WithoutVisibility(subscription);
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithPrivateIpAddress(string privateIpAddress)
        {
            return WithPrivateIpAddress(privateIpAddress);
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithStaticPrivateIpAllocation()
        {
            return WithStaticPrivateIpAllocation();
        }

        PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Definition.IWithPrivateLinkServiceIpConfigurationSettings.WithSubnet(string subnetId)
        {
            return WithSubnet(subnetId);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithVisibility.WithVisibility(string subscription)
        {
            return WithVisibility(subscription);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithVisibility.WithVisibility(IList<string> subscriptions)
        {
            return WithVisibility(subscriptions);
        }

        protected override async Task<PrivateLinkServiceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.PrivateLinkServices.GetAsync(
                ResourceGroupName,
                Name,
                cancellationToken: cancellationToken);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithAttach.Attach()
        {
            return Attach();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfiguration.DefinePrivateLinkServiceIpConfiguration(string name)
        {
            return DefinePrivateLinkServiceIpConfiguration(name);
        }

        PrivateLinkService.Definition.IWithCreate PrivateLinkService.Definition.IWithProxyProtocol.EnableProxyProtocol()
        {
            return EnableProxyProtocol();
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithProxyProtocol.EnableProxyProtocol()
        {
            return EnableProxyProtocol();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.SetAsNonPrimaryIpConfiguration()
        {
            return SetAsNonPrimaryIpConfiguration();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.SetAsPrimaryIpConfiguration()
        {
            return SetAsPrimaryIpConfiguration();
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithAutoApproval.WithAutoApproval(string subscription)
        {
            return WithAutoApproval(subscription);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithAutoApproval.WithAutoApproval(IList<string> subscriptions)
        {
            return WithAutoApproval(subscriptions);
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithDynamicPrivateIpAllocation()
        {
            return WithDynamicPrivateIpAllocation();
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithFqdns.WithFullQualifiedDomainName(string domainName)
        {
            return WithFullQualifiedDomainName(domainName);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithFqdns.WithFullQualifiedDomainNames(IList<string> domainNames)
        {
            return WithFullQualifiedDomainNames(domainNames);
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithIpv4PrivateIpAddress()
        {
            return WithIpv4PrivateIpAddress();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithIpv6PrivateIpAddress()
        {
            return WithIpv6PrivateIpAddress();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithPrivateIpAddress(string privateIpAddress)
        {
            return WithPrivateIpAddress(privateIpAddress);
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithStaticPrivateIpAllocation()
        {
            return WithStaticPrivateIpAllocation();
        }

        PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings PrivateLinkService.Update.IWithPrivateLinkServiceIpConfigurationSettings.WithSubnet(string subnetId)
        {
            return WithSubnet(subnetId);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithVisibility.WithVisibility(string subscription)
        {
            return WithVisibility(subscription);
        }

        PrivateLinkService.Update.IUpdate PrivateLinkService.Update.IWithVisibility.WithVisibility(IList<string> subscriptions)
        {
            return WithVisibility(subscriptions);
        }

        PrivateLinkService.Update.IWithPrivateEndpointConnectionSettings PrivateLinkService.Update.IWithPrivateEndpointConnection.UpdatePrivateEndpointConnection(string name)
        {
            privateConnectionName = name;
            return this;
        }

        PrivateLinkService.Update.IWithPrivateEndpointConnectionSettings PrivateLinkService.Update.IWithPrivateEndpointConnectionSettings.WithPrivateEndpoint(string privateEndpointId)
        {
            privateEndpointInner = new PrivateEndpointInner(id: privateEndpointId);
            return this;
        }

        PrivateLinkService.Update.IWithPrivateEndpointConnectionSettings PrivateLinkService.Update.IWithPrivateEndpointConnectionSettings.WithPrivateLinkServiceConnetionState(string status, string description, string actionRequired)
        {
            privateConnectionState = new PrivateLinkServiceConnectionState(
                status: status,
                description: description,
                actionsRequired: actionRequired);
            return this;
        }

        public IPrivateEndpointConnection Execute()
        {
            return Extensions.Synchronize(() => ExecuteAsync(CancellationToken.None));
        }

        public async Task<IPrivateEndpointConnection> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            PrivateEndpointConnectionInner parameter = GetPrivateEndpointConnectionParams();
            PrivateEndpointConnectionInner inner = await Manager.Inner.PrivateLinkServices.UpdatePrivateEndpointConnectionAsync(
                ResourceGroupName,
                Name,
                parameter.Name,
                parameter,
                cancellationToken);
            ResetPrivateEndpointConnectionParams();
            return inner == null ? null : new PrivateEndpointConnectionImpl(inner, Manager);
        }

        private void InitIpConfigurationCollections(PrivateLinkServiceInner inner)
        {
            frontendIpConfigurations = new Dictionary<string, FrontendIPConfigurationInner>();
            if (inner.LoadBalancerFrontendIpConfigurations != null)
            {
                foreach (var frontendIpConfig in inner.LoadBalancerFrontendIpConfigurations)
                {
                    string frontendIpConfigName = frontendIpConfig.Name ?? ResourceUtils.NameFromResourceId(frontendIpConfig.Id);
                    frontendIpConfigurations[frontendIpConfigName] = frontendIpConfig;
                }
            }

            ipConfigurations = new Dictionary<string, PrivateLinkServiceIpConfigurationInner>();
            if (inner.IpConfigurations != null)
            {
                foreach (var ipConfig in inner.IpConfigurations)
                {
                    ipConfigurations[ipConfig.Name] = ipConfig;
                }
            }
        }

        private void ResetIpConfigurations()
        {
            frontendIpConfigurationInstance = null;
            ipConfigurationInstance = null;
        }

        private void ResetPrivateEndpointConnectionParams()
        {
            privateConnectionName = null;
            privateEndpointInner = null;
            privateConnectionState = null;
        }

        private PrivateEndpointConnectionInner GetPrivateEndpointConnectionParams()
        {
            PrivateEndpointConnectionInner inner = new PrivateEndpointConnectionInner(
                name: privateConnectionName, 
                privateEndpoint: privateEndpointInner, 
                privateLinkServiceConnectionState: privateConnectionState);
            return inner;
        }

        private void UpdateInnerWithIpConfigurations()
        {
            if (frontendIpConfigurations.Values.Count > 0)
            {
                Inner.LoadBalancerFrontendIpConfigurations = new List<FrontendIPConfigurationInner>();
                foreach (var value in frontendIpConfigurations.Values)
                {
                    Inner.LoadBalancerFrontendIpConfigurations.Add(value);
                }
            }
            if (ipConfigurations.Values.Count > 0)
            {
                Inner.IpConfigurations = new List<PrivateLinkServiceIpConfigurationInner>();
                foreach (var value in ipConfigurations.Values)
                {
                    Inner.IpConfigurations.Add(value);
                }
            }
        }

        private PrivateLinkServiceImpl Attach()
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurations[frontendIpConfigurationInstance.Name] = frontendIpConfigurationInstance;
            }
            if (ipConfigurationInstance != null)
            {
                ipConfigurations[ipConfigurationInstance.Name] = ipConfigurationInstance;
            }
            ResetIpConfigurations();
            return this;
        }

        private PrivateLinkServiceImpl WithFrontendIpConfiguration(ILoadBalancerFrontend loadBalancerFrontend)
        {
            frontendIpConfigurations[loadBalancerFrontend.Name] = loadBalancerFrontend.Inner;
            return this;
        }

        private PrivateLinkServiceImpl DefinePrivateLinkServiceIpConfiguration(string name)
        {
            ipConfigurationInstance = new PrivateLinkServiceIpConfigurationInner
            {
                Name = name
            };
            return this;
        }

        private PrivateLinkServiceImpl DisableProxyProtocol()
        {
            Inner.EnableProxyProtocol = false;
            return this;
        }

        private PrivateLinkServiceImpl SetAsNonPrimaryIpConfiguration()
        {
            ipConfigurationInstance.Primary = false;
            return this;
        }

        private PrivateLinkServiceImpl SetAsPrimaryIpConfiguration()
        {
            ipConfigurationInstance.Primary = true;
            return this;
        }

        private PrivateLinkServiceImpl UpdatePrivateLinkServiceIpConfiguration(string name)
        {
            ipConfigurations.TryGetValue(name, out ipConfigurationInstance);
            return this;
        }

        private PrivateLinkServiceImpl WithAutoApproval(string subscription)
        {
            if (subscription == null || subscription.Length == 0)
            {
                return this;
            }
            if (Inner.AutoApproval == null)
            {
                Inner.AutoApproval = new PrivateLinkServicePropertiesAutoApproval(new List<string>());
            }
            if (!Inner.AutoApproval.Subscriptions.Contains(subscription))
            {
                Inner.AutoApproval.Subscriptions.Add(subscription);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithAutoApproval(IList<string> subscriptions)
        {
            if (subscriptions == null || subscriptions.Count == 0)
            {
                return this;
            }
            if (Inner.AutoApproval == null)
            {
                Inner.AutoApproval = new PrivateLinkServicePropertiesAutoApproval(subscriptions);
            } else
            {
                foreach (var subs in subscriptions)
                {
                    if (!Inner.AutoApproval.Subscriptions.Contains(subs))
                    {
                        Inner.AutoApproval.Subscriptions.Add(subs);
                    }
                }
            }
            return this;
        }

        private PrivateLinkServiceImpl WithDynamicPrivateIpAllocation()
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            } 
            else if(ipConfigurationInstance != null)
            {
                ipConfigurationInstance.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            }
            return this;
        }

        private PrivateLinkServiceImpl WithFullQualifiedDomainName(string domainName)
        {
            if (domainName == null || domainName.Length == 0)
            {
                return this;
            }
            if (Inner.Fqdns == null)
            {
                Inner.Fqdns = new List<string>();
            }
            if (!Inner.Fqdns.Contains(domainName))
            {
                Inner.Fqdns.Add(domainName);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithFullQualifiedDomainNames(IList<string> domainNames)
        {
            if (domainNames == null || domainNames.Count == 0)
            {
                return this;
            }
            if (Inner.Fqdns == null)
            {
                Inner.Fqdns = domainNames;
            }
            else
            {
                foreach (var domain in domainNames)
                {
                    if (!Inner.Fqdns.Contains(domain))
                    {
                        Inner.Fqdns.Add(domain);
                    }
                }
            }
            return this;
        }

        private PrivateLinkServiceImpl WithIpv4PrivateIpAddress()
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PrivateIPAddressVersion = IPVersion.IPv4;
            }
            else if (ipConfigurationInstance != null)
            {
                ipConfigurationInstance.PrivateIPAddressVersion = IPVersion.IPv4;
            }
            return this;
        }

        private PrivateLinkServiceImpl WithIpv6PrivateIpAddress()
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PrivateIPAddressVersion = IPVersion.IPv6;
            }
            else if (ipConfigurationInstance != null)
            {
                ipConfigurationInstance.PrivateIPAddressVersion = IPVersion.IPv6;
            }
            return this;
        }

        private PrivateLinkServiceImpl WithoutAutoApproval(string subscription)
        {
            if (Inner.AutoApproval != null && Inner.AutoApproval.Subscriptions != null)
            {
                Inner.AutoApproval.Subscriptions.Remove(subscription);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithoutFrontendIpConfiguration(string name)
        {
            frontendIpConfigurations.Remove(name);
            return this;
        }

        private PrivateLinkServiceImpl WithoutFullQualifiedDomainName(string domainName)
        {
            if (Inner.Fqdns != null)
            {
                Inner.Fqdns.Remove(domainName);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithoutPrivateLinkServiceIpConfiguration(string name)
        {
            ipConfigurations.Remove(name);
            return this;
        }

        private PrivateLinkServiceImpl WithoutVisibility(string subscription)
        {
            if (Inner.Visibility != null && Inner.Visibility.Subscriptions != null)
            {
                Inner.Visibility.Subscriptions.Remove(subscription);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithPrivateIpAddress(string privateIpAddress)
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PrivateIPAddress = privateIpAddress;
            }
            else if (ipConfigurationInstance != null)
            {
                ipConfigurationInstance.PrivateIPAddress = privateIpAddress;
            }
            return this;
        }

        private PrivateLinkServiceImpl WithPublicIpAddress(string publicIpAddressId)
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PublicIPAddress = new SubResource(publicIpAddressId);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithPublicIpPrefix(string publicIpPrefixId)
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PublicIPPrefix = new SubResource(publicIpPrefixId);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithStaticPrivateIpAllocation()
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            }
            else if (ipConfigurationInstance != null)
            {
                ipConfigurationInstance.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            }
            return this;
        }

        private PrivateLinkServiceImpl WithSubnet(string subnetId)
        {
            if (frontendIpConfigurationInstance != null)
            {
                frontendIpConfigurationInstance.Subnet = new SubResource(subnetId);
            }
            else if (ipConfigurationInstance != null)
            {
                ipConfigurationInstance.Subnet = new SubResource(subnetId);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithVisibility(string subscription)
        {
            if (subscription == null || subscription.Length == 0)
            {
                return this;
            }
            if (Inner.Visibility == null)
            {
                Inner.Visibility = new PrivateLinkServicePropertiesVisibility(new List<string>());
            }
            if (!Inner.Visibility.Subscriptions.Contains(subscription))
            {
                Inner.Visibility.Subscriptions.Add(subscription);
            }
            return this;
        }

        private PrivateLinkServiceImpl WithVisibility(IList<string> subscriptions)
        {
            if (subscriptions == null || subscriptions.Count == 0)
            {
                return this;
            }
            if (Inner.Visibility == null)
            {
                Inner.Visibility = new PrivateLinkServicePropertiesVisibility(subscriptions);
            }
            else
            {
                foreach (var subs in subscriptions)
                {
                    if (!Inner.Visibility.Subscriptions.Contains(subs))
                    {
                        Inner.Visibility.Subscriptions.Add(subs);
                    }
                }
            }
            return this;
        }

        private PrivateLinkServiceImpl WithZone(string zone)
        {
            if (zone == null || zone.Length == 0)
            {
                return this;
            }
            if (frontendIpConfigurationInstance != null)
            {
                if (frontendIpConfigurationInstance.Zones == null)
                {
                    frontendIpConfigurationInstance.Zones = new List<string>();
                }
                if (!frontendIpConfigurationInstance.Zones.Contains(zone))
                {
                    frontendIpConfigurationInstance.Zones.Add(zone);
                }
            }
            return this;
        }

        private PrivateLinkServiceImpl WithZones(IList<string> zones)
        {
            if (zones == null || zones.Count == 0)
            {
                return this;
            }
            if (frontendIpConfigurationInstance != null)
            {
                if (frontendIpConfigurationInstance.Zones == null)
                {
                    frontendIpConfigurationInstance.Zones = zones;
                }
                else
                {
                    foreach (var zone in zones)
                    {
                        if (!frontendIpConfigurationInstance.Zones.Contains(zone))
                        {
                            frontendIpConfigurationInstance.Zones.Add(zone);
                        }
                    }
                }
            }
            return this;
        }

        private PrivateLinkServiceImpl EnableProxyProtocol()
        {
            Inner.EnableProxyProtocol = true;
            return this;
        }
    }
}
