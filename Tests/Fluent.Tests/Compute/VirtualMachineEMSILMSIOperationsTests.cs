// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class EMSILMSIOperations
    {
        [Fact]
        public void CanCreateWithEMSI()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USSouthCentral;
                var vmName = "javavm";
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
                    var creatableRG = azure.ResourceGroups
                            .Define(groupName)
                            .WithRegion(region);

                    // Create a virtual network residing in the above RG
                    //
                    var network = azure.Networks
                            .Define(networkName)
                            .WithRegion(region)
                            .WithNewResourceGroup(creatableRG)
                            .Create();

                    // Create an "User Assigned (External) MSI" residing in the above RG and assign reader access to the virtual network
                    //
                    var createdIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(region)
                            .WithNewResourceGroup(creatableRG)
                            .WithAccessTo(network, BuiltInRole.Reader)
                            .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName2)
                            .WithRegion(region)
                            .WithNewResourceGroup(creatableRG)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Create a virtual machine and associate it with existing and yet-t-be-created identities
                    //
                    var virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
                            .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                            .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId); // No Local MSI enabled
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);    // No Local MSI enabled
                    
                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    var emsiIds = virtualMachine.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(2, emsiIds.Count);

                    // Ensure the "User Assigned (External) MSI"s matches with the those provided as part of VM create
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
                    var resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    Assert.NotNull(resourceGroup);

                    var roleAssignmentsForResourceGroup = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(resourceGroup.Id);
                    found = roleAssignmentsForResourceGroup.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(implicitlyCreatedIdentity.PrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the resource group for identity{implicitlyCreatedIdentity.Name}");

                    assignment = LookupRoleAssignmentUsingScopeAndRole(resourceGroup.Id, BuiltInRole.Contributor, implicitlyCreatedIdentity.PrincipalId, azure);
                    Assert.False(assignment == null, "Expected role assignment with ROLE not found for the resource group for identity");


                    emsiIds = virtualMachine.UserAssignedManagedServiceIdentityIds;
                    // Remove both (all) identities
                    virtualMachine.Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(0))
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(1))
                            .Apply();
                    //
                    Assert.Equal(0, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);

                    if (virtualMachine.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    // fetch vm again and validate
                    virtualMachine.Refresh();
                    //
                    Assert.Equal(0, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    if (virtualMachine.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    //
                    var identity1 = azure.Identities.GetById(emsiIds.ElementAt(0));
                    var identity2 = azure.Identities.GetById(emsiIds.ElementAt(1));
                    //
                    // Update VM by enabling System-MSI and add two identities
                    virtualMachine.Update()
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithExistingUserAssignedManagedServiceIdentity(identity1)
                            .WithExistingUserAssignedManagedServiceIdentity(identity2)
                            .Apply();

                    Assert.NotNull(virtualMachine.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    //
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    //
                    virtualMachine.Refresh();
                    Assert.NotNull(virtualMachine.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(2, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    //
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    //

                    // Remove identities one by one (first one)
                    virtualMachine.Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(0))
                            .Apply();
                    //
                    Assert.NotNull(virtualMachine.UserAssignedManagedServiceIdentityIds);
                    Assert.Equal(1, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    // Remove identities one by one (second one)
                    virtualMachine.Update()
                            .WithoutUserAssignedManagedServiceIdentity(emsiIds.ElementAt(1))
                            .Apply();
                    //
                    Assert.Equal(0, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssigned));
                    //
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
                var vmName = "javavm";
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

                    // Create a virtual machine and associate it with existing and yet-t-be-created identities
                    //
                    var virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithSystemAssignedIdentityBasedAccessTo(network.Id, BuiltInRole.Contributor)
                            .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                            .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    ISet<string> emsiIds = virtualMachine.UserAssignedManagedServiceIdentityIds;
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

                    bool found = roleAssignmentsForNetwork.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the virtual network for local identity {virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId}");

                    var assignment = LookupRoleAssignmentUsingScopeAndRole(network.Id, BuiltInRole.Contributor, virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, azure);
                    Assert.False(assignment == null, $"Expected role assignment with ROLE {BuiltInRole.Contributor} not found for the virtual network for identity");

                    // Ensure expected role assignment exists for explicitly created EMSI
                    //
                    resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    Assert.NotNull(resourceGroup);

                    var roleAssignmentsForResourceGroup = azure
                            .AccessManagement
                            .RoleAssignments
                            .ListByScope(resourceGroup.Id);
                    found = roleAssignmentsForResourceGroup.Any(r => r.PrincipalId != null && r.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found, $"Expected role assignment not found for the resource group for identity {identity.Name}");

                    assignment = LookupRoleAssignmentUsingScopeAndRole(resourceGroup.Id, BuiltInRole.Contributor, identity.PrincipalId, azure);
                    Assert.False(assignment == null, $"Expected role assignment with ROLE{BuiltInRole.Contributor}  not found for the resource group for system assigned identity");
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
                var vmName = "javavm";
                var groupName = TestUtilities.GenerateName("rgmsi");
                String identityName1 = TestUtilities.GenerateName("msi-id");
                String identityName2 = TestUtilities.GenerateName("msi-id");

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    // Create a virtual machine with no EMSI & LMSI
                    //
                    var virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .Create();

                    // Prepare a definition for yet-to-be-created "User Assigned (External) MSI" with contributor access to the resource group
                    // it resides
                    //
                    var creatableIdentity = azure.Identities
                            .Define(identityName1)
                            .WithRegion(region)
                            .WithExistingResourceGroup(virtualMachine.ResourceGroupName)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor);

                    // Update virtual machine so that it depends on the EMSI
                    //
                    virtualMachine = virtualMachine.Update()
                            .WithNewUserAssignedManagedServiceIdentity(creatableIdentity)
                            .Apply();

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    ISet<string> emsiIds = virtualMachine.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Equal(1, emsiIds.Count);

                    var identity = azure.Identities.GetById(emsiIds.First());
                    Assert.NotNull(identity);
                    Assert.Equal(identity.Name, identityName1, ignoreCase: true);

                    var createdIdentity = azure.Identities
                            .Define(identityName2)
                            .WithRegion(region)
                            .WithExistingResourceGroup(virtualMachine.ResourceGroupName)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                            .Create();

                    // Update the virtual machine by removing the an EMSI and adding existing EMSI
                    //
                    virtualMachine = virtualMachine.Update()
                            .WithoutUserAssignedManagedServiceIdentity(identity.Id)
                            .WithExistingUserAssignedManagedServiceIdentity(createdIdentity)
                            .Apply();

                    // Ensure the "User Assigned (External) MSI" id can be retrieved from the virtual machine
                    //
                    emsiIds = virtualMachine.UserAssignedManagedServiceIdentityIds;
                    Assert.NotNull(emsiIds);
                    Assert.Single(emsiIds);

                    identity = azure.Identities.GetById(emsiIds.First());
                    Assert.NotNull(identity);
                    Assert.Equal(identity.Name, identityName2, ignoreCase: true);


                    // Update the virtual machine by enabling "LMSI"
                    virtualMachine
                            .Update()
                            .WithSystemAssignedManagedServiceIdentity()
                            .Apply();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned));
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);

                    //
                    virtualMachine
                            .Update()
                            .WithoutSystemAssignedManagedServiceIdentity()
                            .Apply();

                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityType);
                    Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.UserAssigned));
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    Assert.Equal(1, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
                    //
                    virtualMachine
                            .Update()
                            .WithoutUserAssignedManagedServiceIdentity(identity.Id)
                            .Apply();

                    Assert.False(virtualMachine.IsManagedServiceIdentityEnabled);

                    if (virtualMachine.ManagedServiceIdentityType != null)
                    {
                        Assert.True(virtualMachine.ManagedServiceIdentityType.Equals(ResourceIdentityType.None));
                    }
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.Null(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    Assert.Equal(0, virtualMachine.UserAssignedManagedServiceIdentityIds.Count);
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
    }
}
