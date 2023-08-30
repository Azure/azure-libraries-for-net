// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using ResourceIdentityType = Microsoft.Azure.Management.Compute.Fluent.Models.ResourceIdentityType;

namespace Fluent.Tests.Compute.VirtualMachineScaleSet
{
    public class EMSILMSIOperations
    {
        [Fact]
        public void CanCreateWithEMSI()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USSouthCentral;
                var vmssName = "javavm";
                var groupName = TestUtilities.GenerateName("rgmsi");
                String identityName1 = TestUtilities.GenerateName("msi-id");
                String identityName2 = TestUtilities.GenerateName("msi-id");
                String networkName = TestUtilities.GenerateName("nw");

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    // Prepare a definition for yet-to-be-created resource group
                    //
                    var resourceGroup = azure.ResourceGroups
                            .Define(groupName)
                            .WithRegion(region)
                            .Create();

                    // Create a virtual network residing in the above RG
                    //
                    var network = azure.Networks
                            .Define(networkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .Create();

                    // Create an "User Assigned (External) MSI" residing in the above RG and assign reader access to the virtual network
                    //
                    var createdIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAccessTo(network, BuiltInRole.Reader)
                            .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName2)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Create a virtual network for VMSS
                    //
                    var vmssNetwork = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    // Create a Load balancer for VMSS
                    //
                    var vmssInternalLoadBalancer = CreateInternalLoadBalancer(azure,
                            resourceGroup,
                            vmssNetwork,
                            "1",
                            region);

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(vmssNetwork, "subnet1")
                        .WithoutPrimaryInternetFacingLoadBalancer()
                        .WithExistingPrimaryInternalLoadBalancer(vmssInternalLoadBalancer)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
                        .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.NotNull(virtualMachineScaleSet.Inner);
                    Assert.True(virtualMachineScaleSet.IsManagedServiceIdentityEnabled);
                    Assert.Null(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId); // No Local MSI enabled
                    Assert.Null(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);    // No Local MSI enabled

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the VMSS
                    //
                    var emsiIds = virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(2, emsiIds.Count);

                    // Ensure the "User Assigned (External) MSI"s matches with the those provided as part of VMSS create
                    //
                    IIdentity implicitlyCreatedIdentity = null;
                    foreach (var emsiId in emsiIds)
                    {
                        var identity = azure.Identities.GetById(emsiId);
                        Assert.NotNull(identity);
                        Assert.True(identity.Name.Equals(identityName1, StringComparison.OrdinalIgnoreCase)
                                || identity.Name.Equals(identityName2, StringComparison.OrdinalIgnoreCase));
                        Assert.NotNull(identity.PrincipalId);

                        if (identity.Name.Equals(identityName2, StringComparison.OrdinalIgnoreCase))
                        {
                            implicitlyCreatedIdentity = identity;
                        }
                    }
                    Assert.NotNull(implicitlyCreatedIdentity);

                    // Ensure expected role assignment exists for explicitly created EMSI
                    //
                    var roleAssignmentsForNetwork = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(network.Id);
                    bool found = roleAssignmentsForNetwork.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(createdIdentity.PrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the virtual network for identity {createdIdentity.Name}");

                    var assignment = LookupRoleAssignmentUsingScopeAndRole(network.Id, BuiltInRole.Reader, createdIdentity.PrincipalId, azure);
                    Assert.False(assignment == null, "Expected role assignment with ROLE not found for the virtual network for identity");

                    // Ensure expected role assignment exists for explicitly created EMSI
                    //

                    var roleAssignmentsForResourceGroup = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(resourceGroup.Id);
                    found = roleAssignmentsForResourceGroup.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(implicitlyCreatedIdentity.PrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the resource group for identity{implicitlyCreatedIdentity.Name}");

                    assignment = LookupRoleAssignmentUsingScopeAndRole(resourceGroup.Id, BuiltInRole.Contributor, implicitlyCreatedIdentity.PrincipalId, azure);
                    Assert.False(assignment == null, "Expected role assignment with ROLE not found for the resource group for identity");

                    emsiIds = virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds;

                    // Remove both (all) identities
                    virtualMachineScaleSet.Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(0))
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(1))
                            .Apply();

                    //
                    Assert.Equal(0, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    if (virtualMachineScaleSet.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    // fetch vm again and validate
                    virtualMachineScaleSet.Refresh();
                    //
                    Assert.Equal(0, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    if (virtualMachineScaleSet.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    //
                    //
                    var identity1 = azure.Identities.GetById(emsiIds.ElementAt(0));
                    var identity2 = azure.Identities.GetById(emsiIds.ElementAt(1));
                    //
                    // Update VM by enabling System-MSI and add two identities
                    virtualMachineScaleSet.Update()
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithExistingUserAssignedManagedServiceIdentity(identity1)
                            .WithExistingUserAssignedManagedServiceIdentity(identity2)
                            .Apply();
                    Assert.NotNull(virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachineScaleSet.ManagedServiceIdentityType);
                    Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    //
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                    //
                    virtualMachineScaleSet.Refresh();
                    Assert.NotNull(virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachineScaleSet.ManagedServiceIdentityType);
                    Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    //
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                    //
                    // Remove identities one by one (first one)
                    virtualMachineScaleSet.Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(0))
                            .Apply();
                    //
                    Assert.NotNull(virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(1, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachineScaleSet.ManagedServiceIdentityType);
                    Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                    // Remove identities one by one (second one)
                    virtualMachineScaleSet
                            .Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(1))
                            .Apply();
                    //
                    Assert.Equal(0, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachineScaleSet.ManagedServiceIdentityType);
                    Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssigned));
                    //
                    virtualMachineScaleSet
                            .Update()
                            .WithoutSystemAssignedManagedServiceIdentity()
                            .Apply();

                    Assert.Equal(0, virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds.Count);
                    if (virtualMachineScaleSet.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachineScaleSet.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    Assert.Null(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.Null(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithLMSIAndEMSI()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USSouthCentral;
                var vmssName = "javavm";
                var groupName = TestUtilities.GenerateName("rgmsi");
                String identityName1 = TestUtilities.GenerateName("msi-id");
                String networkName = TestUtilities.GenerateName("nw");

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    // Prepare a definition for yet-to-be-created resource group
                    //
                    var resourceGroup = azure.ResourceGroups
                            .Define(groupName)
                            .WithRegion(region)
                            .Create();

                    // Create a virtual network residing in the above RG
                    //
                    var network = azure.Networks
                            .Define(networkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Create a virtual network for VMSS
                    //
                    var vmssNetwork = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    // Create a Load balancer for VMSS
                    //
                    var vmssInternalLoadBalancer = CreateInternalLoadBalancer(azure,
                            resourceGroup,
                            vmssNetwork,
                            "1",
                            region);

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(vmssNetwork, "subnet1")
                        .WithoutPrimaryInternetFacingLoadBalancer()
                        .WithExistingPrimaryInternalLoadBalancer(vmssInternalLoadBalancer)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessTo(network.Id, BuiltInRole.Contributor)
                        .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                        .Create();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.NotNull(virtualMachineScaleSet.Inner);
                    Assert.True(virtualMachineScaleSet.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                    
                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    ISet<string> emsiIds = virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(1, emsiIds.Count);

                    var identity = azure.Identities.GetById(emsiIds.First());
                    Assert.NotNull(identity);
                    Assert.Equal(identity.Name, identityName1, ignoreCase: true);

                    // Ensure expected role assignment exists for LMSI
                    //
                    var roleAssignmentsForNetwork = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(network.Id);
                    bool found = roleAssignmentsForNetwork.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the virtual network for local identity {virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId}");

                    var assignment = LookupRoleAssignmentUsingScopeAndRole(network.Id, BuiltInRole.Contributor, virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId, azure);
                    Assert.False(assignment == null, $"Expected role assignment with ROLE {BuiltInRole.Contributor} not found for the virtual network for identity");

                    var roleAssignmentsForResourceGroup = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(resourceGroup.Id);
                    found = roleAssignmentsForResourceGroup.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the resource group for identity {identity.Name}");

                    assignment = LookupRoleAssignmentUsingScopeAndRole(resourceGroup.Id, BuiltInRole.Contributor, identity.PrincipalId, azure);
                    Assert.False(assignment == null, $"Expected role assignment with ROLE {BuiltInRole.Contributor}  not found for the resource group for system assigned identity");
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanUpdateEMSIAndLMSI()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USSouthCentral;
                var vmssName = "javavm";
                var groupName = TestUtilities.GenerateName("rgmsi");
                String identityName1 = TestUtilities.GenerateName("msi-id");
                String identityName2 = TestUtilities.GenerateName("msi-id");

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    // Prepare a definition for yet-to-be-created resource group
                    //
                    var resourceGroup = azure.ResourceGroups
                            .Define(groupName)
                            .WithRegion(region)
                            .Create();

                    // Create a virtual network for VMSS
                    //
                    var vmssNetwork = azure
                            .Networks
                            .Define("vmssvnet")
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28")
                            .WithSubnet("subnet1", "10.0.0.0/28")
                            .Create();

                    // Create a Load balancer for VMSS
                    //
                    var vmssInternalLoadBalancer = CreateInternalLoadBalancer(azure,
                            resourceGroup,
                            vmssNetwork,
                            "1",
                            region);

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardA0)
                        .WithExistingPrimaryNetworkSubnet(vmssNetwork, "subnet1")
                        .WithoutPrimaryInternetFacingLoadBalancer()
                        .WithExistingPrimaryInternalLoadBalancer(vmssInternalLoadBalancer)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("jvuser")
                        .WithRootPassword(TestUtilities.GenerateName("Pa5$"))
                        .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(virtualMachineScaleSet.ResourceGroupName)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Update virtual machine so that it depends on the EMSI
                    //
                    virtualMachineScaleSet = virtualMachineScaleSet.Update()
                            .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                            .Apply();

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    ISet<string> emsiIds = virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(1, emsiIds.Count);

                    var identity = azure.Identities.GetById(emsiIds.First());
                    Assert.NotNull(identity);
                    Assert.Equal(identity.Name, identityName1, ignoreCase: true);

                    var createdIdentity = azure.Identities
                            .Define(identityName2)
                            .WithRegion(region)
                            .WithExistingResourceGroup(virtualMachineScaleSet.ResourceGroupName)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                            .Create();

                    // Update the virtual machine by removing the an EMSI and adding existing EMSI
                    //
                    virtualMachineScaleSet = virtualMachineScaleSet.Update()
                            .WithoutUserAssignedManagedServiceIdentity(identity.Id)
                            .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
                            .Apply();

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    emsiIds = virtualMachineScaleSet.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Single(emsiIds);

                    identity = azure.Identities.GetById(emsiIds.First());
                    Assert.NotNull(identity);
                    Assert.Equal(identity.Name, identityName2, ignoreCase: true);


                    // Update the virtual machine by enabling "LMSI"
                    virtualMachineScaleSet
                            .Update()
                            .WithSystemAssignedManagedServiceIdentity()
                            .Apply();

                    Assert.NotNull(virtualMachineScaleSet);
                    Assert.NotNull(virtualMachineScaleSet.Inner);
                    Assert.True(virtualMachineScaleSet.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityTenantId);
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        private IRoleAssignment LookupRoleAssignmentUsingScopeAndRole(string scope, BuiltInRole role, string principalId, IAzure azure)
        {

            var roleDefinition = azure.AccessManagement.RoleDefinitions
                .GetByScopeAndRoleName(scope, role.Value);

            var roleAssignments = azure.AccessManagement.RoleAssignments
                .ListByScope(scope);

            if (roleDefinition != null)
            {
                return roleAssignments.FirstOrDefault(a =>
                a.RoleDefinitionId.Equals(roleDefinition.Id, StringComparison.OrdinalIgnoreCase)
                    && a.PrincipalId.Equals(principalId, StringComparison.OrdinalIgnoreCase));
            }
            return null;
        }

        public static ILoadBalancer CreateInternalLoadBalancer(
            IAzure azure,
            IResourceGroup resourceGroup,
            INetwork network,
            string id,
            Region location)
        {
            string loadBalancerName = TestUtilities.GenerateName("InternalLb" + id);
            string privateFrontEndName = loadBalancerName + "-FE1";
            string backendPoolName1 = loadBalancerName + "-BAP1";
            string backendPoolName2 = loadBalancerName + "-BAP2";
            string natPoolName1 = loadBalancerName + "-INP1";
            string natPoolName2 = loadBalancerName + "-INP2";
            string subnetName = "subnet1";

            ILoadBalancer loadBalancer = azure.LoadBalancers.Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1000)
                    .ToBackend(backendPoolName1)
                    .WithProbe("httpProbe")
                    .Attach()
                .DefineLoadBalancingRule("httpsRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPort(1001)
                    .ToBackend(backendPoolName2)
                    .WithProbe("httpsProbe")
                    .Attach()
                // Add two nat pools to enable direct VM connectivity to port 44 and 45
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(8000, 8099)
                    .ToBackendPort(44)
                    .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .FromFrontend(privateFrontEndName)
                    .FromFrontendPortRange(9000, 9099)
                    .ToBackendPort(45)
                    .Attach()

                // Explicitly define the frontend
                .DefinePrivateFrontend(privateFrontEndName)
                    .WithExistingSubnet(network, subnetName)
                    .Attach()

                // Add two probes one per rule
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                    .Attach()
                .DefineHttpProbe("httpsProbe")
                    .WithRequestPath("/")
                    .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByResourceGroup(resourceGroup.Name, loadBalancerName);

            Assert.Empty(loadBalancer.PublicIPAddressIds);
            Assert.Equal(2, loadBalancer.Backends.Count());
            ILoadBalancerBackend backend1 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName1, out backend1));
            ILoadBalancerBackend backend2 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName2, out backend2));
            ILoadBalancerHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            ILoadBalancerHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Single(httpProbe.LoadBalancingRules);
            Assert.Equal(2, loadBalancer.InboundNatPools.Count());
            return loadBalancer;
        }
    }
}
