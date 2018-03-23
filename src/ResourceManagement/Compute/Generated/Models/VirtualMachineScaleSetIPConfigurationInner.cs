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
    /// Describes a virtual machine scale set network profile's IP
    /// configuration.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VirtualMachineScaleSetIPConfigurationInner : Microsoft.Azure.Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetIPConfigurationInner class.
        /// </summary>
        public VirtualMachineScaleSetIPConfigurationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetIPConfigurationInner class.
        /// </summary>
        /// <param name="name">The IP configuration name.</param>
        /// <param name="subnet">Specifies the identifier of the
        /// subnet.</param>
        /// <param name="primary">Specifies the primary network interface in
        /// case the virtual machine has more than 1 network interface.</param>
        /// <param name="publicIPAddressConfiguration">The
        /// publicIPAddressConfiguration.</param>
        /// <param name="privateIPAddressVersion">Available from Api-Version
        /// 2017-03-30 onwards, it represents whether the specific
        /// ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        /// Possible values are: 'IPv4' and 'IPv6'. Possible values include:
        /// 'IPv4', 'IPv6'</param>
        /// <param name="applicationGatewayBackendAddressPools">Specifies an
        /// array of references to backend address pools of application
        /// gateways. A scale set can reference backend address pools of
        /// multiple application gateways. Multiple scale sets cannot use the
        /// same application gateway.</param>
        /// <param name="loadBalancerBackendAddressPools">Specifies an array of
        /// references to backend address pools of load balancers. A scale set
        /// can reference backend address pools of one public and one internal
        /// load balancer. Multiple scale sets cannot use the same load
        /// balancer.</param>
        /// <param name="loadBalancerInboundNatPools">Specifies an array of
        /// references to inbound Nat pools of the load balancers. A scale set
        /// can reference inbound nat pools of one public and one internal load
        /// balancer. Multiple scale sets cannot use the same load
        /// balancer</param>
        public VirtualMachineScaleSetIPConfigurationInner(string name, string id = default(string), ApiEntityReference subnet = default(ApiEntityReference), bool? primary = default(bool?), VirtualMachineScaleSetPublicIPAddressConfiguration publicIPAddressConfiguration = default(VirtualMachineScaleSetPublicIPAddressConfiguration), string privateIPAddressVersion = default(string), IList<Microsoft.Azure.Management.ResourceManager.Fluent.SubResource> applicationGatewayBackendAddressPools = default(IList<Microsoft.Azure.Management.ResourceManager.Fluent.SubResource>), IList<ResourceManager.Fluent.SubResource> loadBalancerBackendAddressPools = default(IList<ResourceManager.Fluent.SubResource>), IList<ResourceManager.Fluent.SubResource> loadBalancerInboundNatPools = default(IList<ResourceManager.Fluent.SubResource>))
            : base(id)
        {
            Name = name;
            Subnet = subnet;
            Primary = primary;
            PublicIPAddressConfiguration = publicIPAddressConfiguration;
            PrivateIPAddressVersion = privateIPAddressVersion;
            ApplicationGatewayBackendAddressPools = applicationGatewayBackendAddressPools;
            LoadBalancerBackendAddressPools = loadBalancerBackendAddressPools;
            LoadBalancerInboundNatPools = loadBalancerInboundNatPools;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the IP configuration name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets specifies the identifier of the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public ApiEntityReference Subnet { get; set; }

        /// <summary>
        /// Gets or sets specifies the primary network interface in case the
        /// virtual machine has more than 1 network interface.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primary")]
        public bool? Primary { get; set; }

        /// <summary>
        /// Gets or sets the publicIPAddressConfiguration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddressConfiguration")]
        public VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }

        /// <summary>
        /// Gets or sets available from Api-Version 2017-03-30 onwards, it
        /// represents whether the specific ipconfiguration is IPv4 or IPv6.
        /// Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
        /// Possible values include: 'IPv4', 'IPv6'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddressVersion")]
        public string PrivateIPAddressVersion { get; set; }

        /// <summary>
        /// Gets or sets specifies an array of references to backend address
        /// pools of application gateways. A scale set can reference backend
        /// address pools of multiple application gateways. Multiple scale sets
        /// cannot use the same application gateway.
        /// </summary>
        [JsonProperty(PropertyName = "properties.applicationGatewayBackendAddressPools")]
        public IList<Microsoft.Azure.Management.ResourceManager.Fluent.SubResource> ApplicationGatewayBackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets specifies an array of references to backend address
        /// pools of load balancers. A scale set can reference backend address
        /// pools of one public and one internal load balancer. Multiple scale
        /// sets cannot use the same load balancer.
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancerBackendAddressPools")]
        public IList<Microsoft.Azure.Management.ResourceManager.Fluent.SubResource> LoadBalancerBackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets specifies an array of references to inbound Nat pools
        /// of the load balancers. A scale set can reference inbound nat pools
        /// of one public and one internal load balancer. Multiple scale sets
        /// cannot use the same load balancer
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancerInboundNatPools")]
        public IList<ResourceManager.Fluent.SubResource> LoadBalancerInboundNatPools { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (PublicIPAddressConfiguration != null)
            {
                PublicIPAddressConfiguration.Validate();
            }
        }
    }
}
