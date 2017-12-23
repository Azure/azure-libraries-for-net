// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a virtual machine scale set network profile's network
    /// configurations.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VirtualMachineScaleSetUpdateNetworkConfigurationInner : Microsoft.Azure.Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetUpdateNetworkConfigurationInner class.
        /// </summary>
        public VirtualMachineScaleSetUpdateNetworkConfigurationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetUpdateNetworkConfigurationInner class.
        /// </summary>
        /// <param name="name">The network configuration name.</param>
        /// <param name="primary">Whether this is a primary NIC on a virtual
        /// machine.</param>
        /// <param name="enableAcceleratedNetworking">Specifies whether the
        /// network interface is accelerated networking-enabled.</param>
        /// <param name="networkSecurityGroup">The network security
        /// group.</param>
        /// <param name="dnsSettings">The dns settings to be applied on the
        /// network interfaces.</param>
        /// <param name="ipConfigurations">The virtual machine scale set IP
        /// Configuration.</param>
        /// <param name="enableIPForwarding">Whether IP forwarding enabled on
        /// this NIC.</param>
        public VirtualMachineScaleSetUpdateNetworkConfigurationInner(string id = default(string), string name = default(string), bool? primary = default(bool?), bool? enableAcceleratedNetworking = default(bool?), Microsoft.Azure.Management.ResourceManager.Fluent.SubResource networkSecurityGroup = default(Microsoft.Azure.Management.ResourceManager.Fluent.SubResource), VirtualMachineScaleSetNetworkConfigurationDnsSettings dnsSettings = default(VirtualMachineScaleSetNetworkConfigurationDnsSettings), IList<VirtualMachineScaleSetUpdateIPConfigurationInner> ipConfigurations = default(IList<VirtualMachineScaleSetUpdateIPConfigurationInner>), bool? enableIPForwarding = default(bool?))
            : base(id)
        {
            Name = name;
            Primary = primary;
            EnableAcceleratedNetworking = enableAcceleratedNetworking;
            NetworkSecurityGroup = networkSecurityGroup;
            DnsSettings = dnsSettings;
            IpConfigurations = ipConfigurations;
            EnableIPForwarding = enableIPForwarding;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the network configuration name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether this is a primary NIC on a virtual machine.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primary")]
        public bool? Primary { get; set; }

        /// <summary>
        /// Gets or sets specifies whether the network interface is accelerated
        /// networking-enabled.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableAcceleratedNetworking")]
        public bool? EnableAcceleratedNetworking { get; set; }

        /// <summary>
        /// Gets or sets the network security group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkSecurityGroup")]
        public Microsoft.Azure.Management.ResourceManager.Fluent.SubResource NetworkSecurityGroup { get; set; }

        /// <summary>
        /// Gets or sets the dns settings to be applied on the network
        /// interfaces.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dnsSettings")]
        public VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine scale set IP Configuration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ipConfigurations")]
        public IList<VirtualMachineScaleSetUpdateIPConfigurationInner> IpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets whether IP forwarding enabled on this NIC.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableIPForwarding")]
        public bool? EnableIPForwarding { get; set; }

    }
}
