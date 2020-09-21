// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled virtual machine scale set
    /// allowing to set access for the identity.
    /// </summary>
    public interface IWithSystemAssignedIdentityBasedAccessOrApply :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {

        /// <summary>
        /// Specifies that virtual machine's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID.
        /// Applications running on the scale set VM instance will have the same permission (role)
        /// on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine scale set 's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.  Applications
        /// running on the scale set VM instance will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the given
        /// access (described by the role) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that virtual machine scale set's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that virtual machine resides. Applications
        /// running on the scale set VM instance will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the scale set local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update to set the billing related details of the low priority virtual machines in the scale set.
    /// </summary>
    public interface IWithBillingProfile
    {
        /// <summary>
        /// Specifies the billing related details of the low priority virtual machines in the scale set.
        /// </summary>
        /// <param name="maxPrice">The maxPrice value.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithMaxPrice(double? maxPrice);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension
    {

        /// <summary>
        /// Begins the definition of an extension reference to be attached to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for an extension.</param>
        /// <return>The first stage of the extension reference definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> DefineNewExtension(string name);

        /// <summary>
        /// Begins the description of an update of an existing extension assigned to the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The first stage of the extension reference update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Removes the extension with the specified name from the virtual machines in the scale set.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed/uninstalled.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutExtension(string name);
    }

    /// <summary>
    /// A stage of the virtual machine scale set update allowing to remove the associations between the primary network
    /// interface configuration and the specified inbound NAT pools of the load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerNatPool
    {

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of the internal load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified inbound NAT pools
        /// of an Internet-facing load balancer.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify an internal load balancer for
    /// the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancer :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {

        /// <summary>
        /// Specifies the load balancer to be used as the internal load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current internal load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backends and inbound NAT pools of the load balancer will be associated with the primary
        /// network interface of the virtual machines in the scale set unless subset of them is selected in the next stages.
        /// </p>.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to enable public ip
    /// for vm instances.
    /// </summary>
    public interface IWithVirtualMachinePublicIp :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithVirtualMachinePublicIp();

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="leafDomainLabel">The domain name label.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithVirtualMachinePublicIp(string leafDomainLabel);

        /// <summary>
        /// Specify that virtual machines in the scale set should have public ip address.
        /// </summary>
        /// <param name="ipConfig">The public ip address configuration.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithVirtualMachinePublicIp(VirtualMachineScaleSetPublicIPAddressConfiguration ipConfig);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the association between the primary network
    /// interface configuration and a backend of a load balancer.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancerBackend
    {

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specified backends
        /// of the internal load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames);

        /// <summary>
        /// Removes the associations between the primary network interface configuration and the specfied backends
        /// of the Internet-facing load balancer.
        /// </summary>
        /// <param name="backendNames">Existing backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure ip forwarding.
    /// </summary>
    public interface IWithIpForwarding :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that ip forwarding should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithIpForwarding();

        /// <summary>
        /// Specify that ip forwarding should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutIpForwarding();
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to
    /// set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine
    /// Scale Set.
    /// </summary>
    public interface IWithAdditionalCapabilities
    {
        /// <summary>
        /// Set specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine
        /// Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed
        /// data disks with UltraSSD_LRS storage account type.
        /// </summary>
        /// <param name="additionalCapabilities">the additionalCapabilities value to set</param>
        /// <returns>the next stage of the definition.</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithAdditionalCapabilities(AdditionalCapabilities additionalCapabilities);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to change the SKU for the virtual machines
    /// in the scale set.
    /// </summary>
    public interface IWithSku
    {

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithSku(VirtualMachineScaleSetSkuTypes skuType);

        /// <summary>
        /// Specifies the SKU for the virtual machines in the scale set.
        /// </summary>
        /// <param name="sku">A SKU from the list of available sizes for the virtual machines in this scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithSku(IVirtualMachineScaleSetSku sku);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure application security group.
    /// </summary>
    public interface IWithApplicationSecurityGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroup">The application security group.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingApplicationSecurityGroup(IApplicationSecurityGroup applicationSecurityGroup);

        /// <summary>
        /// Specifies that provided application security group should be associated with the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingApplicationSecurityGroupId(string applicationSecurityGroupId);

        /// <summary>
        /// Specifies that provided application security group should be removed from the virtual machine scale set.
        /// </summary>
        /// <param name="applicationSecurityGroupId">The application security group id.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutApplicationSecurityGroup(string applicationSecurityGroupId);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to remove the public and internal load balancer
    /// from the primary network interface configuration.
    /// </summary>
    public interface IWithoutPrimaryLoadBalancer
    {

        /// <summary>
        /// Removes the association between the internal load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternalLoadBalancer();

        /// <summary>
        /// Removes the association between the Internet-facing load balancer and the primary network interface configuration.
        /// This removes the association between primary network interface configuration and all the backends and
        /// inbound NAT pools in the load balancer.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutPrimaryInternetFacingLoadBalancer();
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure accelerated networking.
    /// </summary>
    public interface IWithAcceleratedNetworking :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that accelerated networking should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithAcceleratedNetworking();

        /// <summary>
        /// Specify that accelerated networking should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutAcceleratedNetworking();
    }

    /// <summary>
    /// The stage of a virtual machine scale set definition allowing to specify the number of
    /// virtual machines in the scale set.
    /// </summary>
    public interface IWithCapacity
    {

        /// <summary>
        /// Specifies the new number of virtual machines in the scale set.
        /// </summary>
        /// <param name="capacity">The virtual machine capacity of the scale set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithCapacity(int capacity);
    }

    public interface IWithVaultSecret
    {
        /// <summary>
        /// Specifies a vault secret to add to the vm.
        /// Each call to this method adds to the list of vault secrets.
        /// </summary>
        /// <param name="vaultId">The vault id.</param>
        /// <param name="certificateStore">The vm certificate store e.g. "My".</param>
        /// <param name="certificateUrl">The vault certificate URL.</param>
        /// <return>The stage representing creatable Windows VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithVaultSecret(string vaultId, string certificateUrl, string certificateStore);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify load balancers for the primary
    /// network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryLoadBalancer :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer
    {

        /// <summary>
        /// Specifies the load balancer to be used as the Internet-facing load balancer for the virtual machines in the
        /// scale set.
        /// This will replace the current Internet-facing load balancer associated with the virtual machines in the
        /// scale set (if any).
        /// By default all the backend and inbound NAT pool of the load balancer will be associated with the primary
        /// network interface of the virtual machines unless a subset of them is selected in the next stages.
        /// </summary>
        /// <param name="loadBalancer">The primary Internet-facing load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure single placement group.
    /// </summary>
    public interface IWithSinglePlacementGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that single placement group should be disabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutSinglePlacementGroup();

        /// <summary>
        /// Specify that single placement group should be enabled for the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithSinglePlacementGroup();
    }

    /// <summary>
    /// The stage of a virtual machine scale set update containing inputs for the resource to be updated.
    /// </summary>
    public interface IWithApply :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithManagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithUnmanagedDataDisk,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithAdditionalCapabilities,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithCapacity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithVaultSecret,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithExtension,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerBackend,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithoutPrimaryLoadBalancerNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithUserAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithBootDiagnostics,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithBillingProfile,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithAvailabilityZone,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithVirtualMachinePublicIp,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithAcceleratedNetworking,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithIpForwarding,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithNetworkSecurityGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSinglePlacementGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApplicationGateway,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApplicationSecurityGroup
    {

    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate backend pools and/or inbound NAT pools
    /// of the selected internal load balancer with the primary network interface of the scale set virtual machines.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerBackendOrNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool
    {

        /// <summary>
        /// Associates the specified internal load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The names of existing backends on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerNatPool WithPrimaryInternalLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate inbound NAT pools of the selected internal
    /// load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternalLoadBalancerNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply
    {

        /// <summary>
        /// Associates the specified internal load balancer inbound NAT pools with the the primary network interface of
        /// the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools in the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of the virtual machine update allowing to add or remove User Assigned (External)
    /// Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the virtual machine.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated
        /// with the virtual machine.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity);

        /// <summary>
        /// Specifies that an user assigned identity associated with the virtual machine should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutUserAssignedManagedServiceIdentity(string identityId);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate a backend pool and/or inbound NAT pool
    /// of the selected Internet-facing load balancer with the primary network interface of the virtual machines in
    /// the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool
    {

        /// <summary>
        /// Associates the specified Internet-facing load balancer backends with the primary network interface of the
        /// virtual machines in the scale set.
        /// </summary>
        /// <param name="backendNames">The backend names.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerNatPool WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames);
    }

    /// <summary>
    /// The entirety of the virtual machine scale set update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancerBackendOrNatPool
    {

    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure application gateway.
    /// </summary>
    public interface IWithApplicationGateway :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specify that an application gateway backend pool should be associated with virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingApplicationGatewayBackendPool(string backendPoolId);

        /// <summary>
        /// Specify an existing application gateway associated should be removed from the virtual machine scale set.
        /// </summary>
        /// <param name="backendPoolId">An existing backend pool id of the gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutApplicationGatewayBackendPool(string backendPoolId);
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to specify managed data disks.
    /// </summary>
    public interface IWithManagedDataDisk
    {

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given size.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType);

        /// <summary>
        /// Specifies that a managed disk needs to be created implicitly with the given settings.
        /// </summary>
        /// <param name="sizeInGB">The size of the managed disk.</param>
        /// <param name="lun">The disk LUN.</param>
        /// <param name="cachingType">The caching type.</param>
        /// <param name="storageAccountType">The storage account type.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType);

        /// <summary>
        /// Detaches managed data disk with the given LUN from the virtual machine scale set instances.
        /// </summary>
        /// <param name="lun">The disk LUN.</param>
        /// <return>The next stage of virtual machine scale set update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutDataDisk(int lun);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to specify availability zone.
    /// </summary>
    public interface IWithAvailabilityZone :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the availability zone for the virtual machine scale set.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithAvailabilityZone(AvailabilityZoneId zoneId);
    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to specify unmanaged data disk.
    /// </summary>
    public interface IWithUnmanagedDataDisk
    {

    }

    /// <summary>
    /// The stage of the virtual machine scale set definition allowing to enable boot diagnostics.
    /// </summary>
    public interface IWithBootDiagnostics :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate WithBootDiagnostics();

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="creatable">The storage account to be created and used for store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccount">An existing storage account to be uses to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate WithBootDiagnostics(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that boot diagnostics needs to be enabled in the virtual machine scale set.
        /// </summary>
        /// <param name="storageAccountBlobEndpointUri">A storage account blob endpoint to store the boot diagnostics.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate WithBootDiagnostics(string storageAccountBlobEndpointUri);

        /// <summary>
        /// Specifies that boot diagnostics needs to be disabled in the virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate WithoutBootDiagnostics();
    }

    /// <summary>
    /// The stage of a virtual machine scale set update allowing to associate an inbound NAT pool of the selected
    /// Internet-facing load balancer with the primary network interface of the virtual machines in the scale set.
    /// </summary>
    public interface IWithPrimaryInternetFacingLoadBalancerNatPool :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer
    {

        /// <summary>
        /// Associates inbound NAT pools of the selected Internet-facing load balancer with the primary network interface
        /// of the virtual machines in the scale set.
        /// </summary>
        /// <param name="natPoolNames">The names of existing inbound NAT pools on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithPrimaryInternalLoadBalancer WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames);
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to configure network security group.
    /// </summary>
    public interface IWithNetworkSecurityGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroup">The network security group to associate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup);

        /// <summary>
        /// Specifies the network security group for the virtual machine scale set.
        /// </summary>
        /// <param name="networkSecurityGroupId">The network security group to associate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithExistingNetworkSecurityGroupId(string networkSecurityGroupId);

        /// <summary>
        /// Specifies that network security group association should be removed if exists.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply WithoutNetworkSecurityGroup();
    }

    /// <summary>
    /// The stage of the virtual machine scale set update allowing to enable System Assigned (Local) Managed Service Identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be disabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithoutSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that System assigned (Local) Managed Service Identity needs to be enabled in the
        /// virtual machine scale set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithSystemAssignedIdentityBasedAccessOrApply WithSystemAssignedManagedServiceIdentity();
    }
}