// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Network.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Network.Update;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.Update;
    using Microsoft.Azure.Management.Network.Fluent.Subnet.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NetworkImpl
    {
        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown after the update is applied.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithAddressSpace.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr);
        }

        /// <summary>
        /// Removes the specified address space from the virtual network, assuming it's not in use bu any of the subnets.
        /// </summary>
        /// <param name="cidr">The address space to remove, in CIDR format, matching exactly one of the CIDRs associated with this network.</param>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithAddressSpaceBeta.WithoutAddressSpace(string cidr)
        {
            return this.WithoutAddressSpace(cidr);
        }

        /// <summary>
        /// Gets the DDoS protection plan id associated with the virtual network.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetwork.DdosProtectionPlanId
        {
            get
            {
                return this.DdosProtectionPlanId();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetwork> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetwork>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Gets whether DDoS protection is enabled for all the protected resources
        /// in the virtual network. It requires a DDoS protection plan associated with the resource.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetwork.IsDdosProtectionEnabled
        {
            get
            {
                return this.IsDdosProtectionEnabled();
            }
        }

        /// <summary>
        /// Gets whether VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetwork.IsVmProtectionEnabled
        {
            get
            {
                return this.IsVmProtectionEnabled();
            }
        }

        /// <summary>
        /// Begins the description of an update of an existing subnet of this network.
        /// </summary>
        /// <param name="name">The name of an existing subnet.</param>
        /// <return>The first stage of the subnet update description.</return>
        Subnet.Update.IUpdate Network.Update.IWithSubnet.UpdateSubnet(string name)
        {
            return this.UpdateSubnet(name);
        }

        /// <summary>
        /// Begins the definition of a new subnet to be added to this virtual network.
        /// </summary>
        /// <param name="name">The name of the new subnet.</param>
        /// <return>The first stage of the new subnet definition.</return>
        Subnet.UpdateDefinition.IBlank<Network.Update.IUpdate> Network.Update.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name);
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        /// <return>The next stage of the virtual network update.</return>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr);
        }

        /// <summary>
        /// Explicitly defines all the subnets in the virtual network based on the provided map.
        /// This replaces any previously existing subnets.
        /// </summary>
        /// <param name="nameCidrPairs">A  Map of CIDR addresses for the subnets, indexed by the name of each subnet to be added.</param>
        /// <return>The next stage of the virtual network update.</return>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs);
        }

        /// <summary>
        /// Removes a subnet from the virtual network.
        /// </summary>
        /// <param name="name">Name of the subnet to remove.</param>
        /// <return>The next stage of the virtual network update.</return>
        Network.Update.IUpdate Network.Update.IWithSubnet.WithoutSubnet(string name)
        {
            return this.WithoutSubnet(name);
        }

        /// <summary>
        /// Begins the definition of a new subnet to add to the virtual network.
        /// The definition must be completed with a call to  Subnet.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the subnet.</param>
        /// <return>The first stage of the new subnet definition.</return>
        Subnet.Definition.IBlank<Network.Definition.IWithCreateAndSubnet> Network.Definition.IWithSubnet.DefineSubnet(string name)
        {
            return this.DefineSubnet(name);
        }

        /// <summary>
        /// Explicitly adds a subnet to the virtual network.
        /// If no subnets are explicitly specified, a default subnet called "subnet1" covering the
        /// entire first address space will be created.
        /// Note this method's effect is additive, i.e. each time it is used, a new subnet is added to the network.
        /// </summary>
        /// <param name="name">The name to assign to the subnet.</param>
        /// <param name="cidr">The address space of the subnet, within the address space of the network, using the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithSubnet.WithSubnet(string name, string cidr)
        {
            return this.WithSubnet(name, cidr);
        }

        /// <summary>
        /// Explicitly defines subnets in the virtual network based on the provided map.
        /// </summary>
        /// <param name="nameCidrPairs">A  Map of CIDR addresses for the subnets, indexed by the name of each subnet to be defined.</param>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithSubnet.WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            return this.WithSubnets(nameCidrPairs);
        }

        /// <summary>
        /// Specifies the IP address of the DNS server to associate with the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new DNS server is
        /// added to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the virtual network update.</return>
        Network.Update.IUpdate Network.Update.IWithDnsServer.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress);
        }

        /// <summary>
        /// Gets list of DNS server IP addresses associated with this virtual network.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetwork.DnsServerIPs
        {
            get
            {
                return this.DnsServerIPs();
            }
        }

        /// <summary>
        /// Checks if the specified private IP address is within this network's address space.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>True if the specified IP address is within this network's address space, otherwise false.</return>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkBeta.IsPrivateIPAddressInNetwork(string ipAddress)
        {
            return this.IsPrivateIPAddressInNetwork(ipAddress);
        }

        /// <summary>
        /// Gets entry point to managing virtual network peerings for this network.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkPeerings Microsoft.Azure.Management.Network.Fluent.INetworkBeta.Peerings
        {
            get
            {
                return this.Peerings();
            }
        }

        /// <summary>
        /// Gets subnets of this virtual network as a map indexed by subnet name
        /// Note that when a virtual network is created with no subnets explicitly defined, a default subnet is
        /// automatically created with the name "subnet1".
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ISubnet> Microsoft.Azure.Management.Network.Fluent.INetwork.Subnets
        {
            get
            {
                return this.Subnets();
            }
        }

        /// <summary>
        /// Gets list of address spaces associated with this virtual network, in the CIDR notation.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetwork.AddressSpaces
        {
            get
            {
                return this.AddressSpaces();
            }
        }

        /// <summary>
        /// Checks if the specified private IP address is available in this network.
        /// </summary>
        /// <param name="ipAddress">An IP address from this network's address space.</param>
        /// <return>True if the address is within this network's address space and is available.</return>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkBeta.IsPrivateIPAddressAvailable(string ipAddress)
        {
            return this.IsPrivateIPAddressAvailable(ipAddress);
        }

        /// <summary>
        /// Explicitly adds an address space to the virtual network.
        /// If no address spaces are explicitly specified, a default address space with the CIDR "10.0.0.0/16" will be
        /// assigned to the virtual network.
        /// Note that this method's effect is additive, i.e. each time it is used, a new address space is added to the network.
        /// This method does not check for conflicts or overlaps with other address spaces. If there is a conflict,
        /// a cloud exception may be thrown at the time the network is created.
        /// </summary>
        /// <param name="cidr">The CIDR representation of the address space.</param>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithCreate.WithAddressSpace(string cidr)
        {
            return this.WithAddressSpace(cidr);
        }

        /// <summary>
        /// Associates existing DDoS protection plan with the virtual network.
        /// </summary>
        /// <param name="planId">DDoS protection plan resource id.</param>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithDdosProtectionPlan.WithExistingDdosProtectionPlan(string planId)
        {
            return this.WithExistingDdosProtectionPlan(planId);
        }

        /// <summary>
        /// Associates existing DDoS protection plan with the virtual network.
        /// </summary>
        /// <param name="planId">DDoS protection plan resource id.</param>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithDdosProtectionPlan.WithExistingDdosProtectionPlan(string planId)
        {
            return this.WithExistingDdosProtectionPlan(planId);
        }

        /// <summary>
        /// Creates a new DDoS protection plan in the same region and group as the virtual network and associates it with the resource.
        /// The internal name the DDoS protection plan will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithDdosProtectionPlan.WithNewDdosProtectionPlan()
        {
            return this.WithNewDdosProtectionPlan();
        }

        /// <summary>
        /// Specifies the IP address of an existing DNS server to associate with the virtual network.
        /// Note this method's effect is additive, i.e. each time it is used, a new dns server is added
        /// to the network.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreate Network.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress);
        }

        /// <summary>
        /// Creates a new DDoS protection plan in the same region and group as the virtual network and associates it with the resource.
        /// The internal name the DDoS protection plan will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithDdosProtectionPlan.WithNewDdosProtectionPlan()
        {
            return this.WithNewDdosProtectionPlan();
        }

        /// <summary>
        /// Disassociates DDoS protection plan and disables Standard DDoS protection for this virtual network. Note: Plan resource is not deleted from Azure.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithDdosProtectionPlan.WithoutDdosProtectionPlan()
        {
            return this.WithoutDdosProtectionPlan();
        }

        /// <summary>
        /// Disable VM protection for all the subnets in the virtual network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithVmProtection.WithoutVmProtection()
        {
            return this.WithoutVmProtection();
        }

        /// <summary>
        /// Enable VM protection for all the subnets in the virtual network.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Network.Update.IUpdate Network.Update.IWithVmProtection.WithVmProtection()
        {
            return this.WithVmProtection();
        }

        /// <summary>
        /// Enable VM protection for all the subnets in the virtual network.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Network.Definition.IWithCreateAndSubnet Network.Definition.IWithVmProtection.WithVmProtection()
        {
            return this.WithVmProtection();
        }
    }
}