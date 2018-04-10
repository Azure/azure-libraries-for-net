// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGatewayIPConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// Implementation for VirtualNetworkGatewayIPConfiguration.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE5ldHdvcmtHYXRld2F5SVBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class VirtualNetworkGatewayIPConfigurationImpl :
        ChildResource<VirtualNetworkGatewayIPConfigurationInner,
            VirtualNetworkGatewayImpl,
            IVirtualNetworkGateway>,
        IVirtualNetworkGatewayIPConfiguration,
        IDefinition<IWithCreate>,
        IUpdateDefinition<VirtualNetworkGateway.Update.IUpdate>,
        VirtualNetworkGatewayIPConfiguration.Update.IUpdate
    {
        VirtualNetworkGateway.Update.IUpdate ISettable<VirtualNetworkGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        ///GENMHASH:777AE9B7CB4EA1B471FA1957A07DF81F:447635D831A0A80A464ADA6413BED58F
        public ISubnet GetSubnet()
        {
            return Parent.Manager.GetAssociatedSubnet(Inner.Subnet);
        }

        ///GENMHASH:FCB784E90DCC27EAC6AD4B4C988E2752:AD76D34D3002AB3E39DB6F1AF087B2A7
        public IPAllocationMethod PrivateIPAllocationMethod()
        {
            return Inner.PrivateIPAllocationMethod;
        }

        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:E2FB3C470570EB032EC48D6BFD6A7AFF
        public string PublicIPAddressId()
        {
            if (Inner.PublicIPAddress != null)
            {
                return Inner.PublicIPAddress.Id;
            }
            return null;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:096D95C5168036459198B2B1F15EC515
        public VirtualNetworkGatewayIPConfigurationImpl WithExistingPublicIPAddress(IPublicIPAddress pip)
        {
            return this.WithExistingPublicIPAddress(pip.Id);
        }

        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:6DC78F2FD590C56E6AA5064DDBA6DD44
        public VirtualNetworkGatewayIPConfigurationImpl WithExistingPublicIPAddress(string resourceId)
        {
            SubResource pipRef = new SubResource()
            {
                Id = resourceId
            };
            Inner.PublicIPAddress = pipRef;
            return this;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:7C10C7860B6E28E6D17CB999015864B9
        public string NetworkId()
        {
            SubResource subnetRef = this.Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
            }
            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:4174C1298FBF6ABE50F5AB6DA4F03B10
        public VirtualNetworkGatewayImpl Attach()
        {
            return Parent.WithConfig(this);
        }

        ///GENMHASH:94AC8838A3A2280C2029702434306F7D:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal VirtualNetworkGatewayIPConfigurationImpl(VirtualNetworkGatewayIPConfigurationInner inner, VirtualNetworkGatewayImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AF6B5F15AE40A0AA08ADA331F3C75492
        public string SubnetName()
        {
            SubResource subnetRef = this.Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.NameFromResourceId(subnetRef.Id);
            }
            return null;
        }

        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:B9B4B506ED0B45772F0E2468D5E88107
        public VirtualNetworkGatewayIPConfigurationImpl WithExistingSubnet(string networkId, string subnetName)
        {
            SubResource subnetRef = new SubResource()
            {
                Id = networkId + "/subnets/" + subnetName
            };
            Inner.Subnet = subnetRef;
            return this;
        }

        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:7289832C1662E22EA7E068290C483F1B
        public VirtualNetworkGatewayIPConfigurationImpl WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet.Parent.Id, subnet.Name);
        }

        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:F08EFDCC8A8286B3C9226D19B2EA7889
        public VirtualNetworkGatewayIPConfigurationImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network.Id, subnetName);
        }
    }
}