// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class ManagedServiceIdentityOperations
    {
        [Fact]
        public void CanSetMSIOnNewOrExistingVMWithoutRoleAssignment()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var region = Region.USSouthCentral;
                var vmName = "javavm";

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    // Create a virtual machine with just MSI enabled without role and scope.
                    //
                    IVirtualMachine virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithSystemAssignedManagedServiceIdentity()
                            .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();

                    // Ensure NO role assigned for resource group
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");

                    virtualMachine = virtualMachine.Update()
                        .WithSystemAssignedManagedServiceIdentity()
                        .Apply();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);
                    
                    rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");
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
        public void CanSetMSIOnNewVMWithRoleAssignedToCurrentResourceGroup()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var region = Region.USSouthCentral;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    IVirtualMachine virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);


                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // TODO: Renable the below code snippet: https://github.com/Azure/azure-libraries-for-net/issues/739
                    // 
                    //  Comment out since the below code need external tennat.
                    // 
                    ////
                    //IServicePrincipal servicePrincipal = authenticatedClient
                    //        .ServicePrincipals
                    //        .GetById(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);

                    //Assert.NotNull(servicePrincipal);
                    //Assert.NotNull(servicePrincipal.Inner);

                    // Ensure role assigned
                    //
                    IResourceGroup resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var roleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    bool found = false;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");
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
        public void CanSetMSIOnNewVMWithMultipleRoleAssignments()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var storageAccountName = TestUtilities.GenerateName("ja");
                var region = Region.USEast2;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    

                    IStorageAccount storageAccount = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .Create();

                    var resourceGroup = azure.ResourceGroups.GetByName(storageAccount.ResourceGroupName);

                    IVirtualMachine virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithSystemAssignedIdentityBasedAccessTo(resourceGroup.Id, BuiltInRole.Contributor)
                            .WithSystemAssignedIdentityBasedAccessTo(storageAccount.Id, BuiltInRole.Contributor)
                            .Create();

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // TODO: Renable the below code snippet: https://github.com/Azure/azure-libraries-for-net/issues/739
                    // 
                    //  Comment out since the below code need external tennat.
                    // 
                    ////
                    //IServicePrincipal servicePrincipal = authenticatedClient
                    //        .ServicePrincipals
                    //        .GetById(virtualMachineScaleSet.SystemAssignedManagedServiceIdentityPrincipalId);

                    //Assert.NotNull(servicePrincipal);
                    //Assert.NotNull(servicePrincipal.Inner);

                    // Ensure role assigned for resource group
                    //

                    var rgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");

                    // Ensure role assigned for storage account
                    //
                    var stgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(storageAccount.Id);
                    Assert.NotNull(stgRoleAssignments);
                    found = false;
                    foreach (var roleAssignment in stgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Storage account should have a role assignment with virtual machine MSI principal");
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
        public void CanSetMSIOnExistingVMWithRoleAssignments()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var storageAccountName = TestUtilities.GenerateName("ja");
                var region = Region.USEast2;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IVirtualMachine virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithSystemAssignedManagedServiceIdentity()
                        .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // Ensure NO role assigned for resource group
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");

                    virtualMachine.Update()
                            .WithSystemAssignedManagedServiceIdentity()
                            .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                            .Apply();

                    // Ensure role assigned for resource group
                    //
                    var roleAssignments2 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(roleAssignments2);
                    foreach (var roleAssignment in roleAssignments2)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");

                    // Try adding the same role again, implementation should handle 'RoleAlreadyExists' error code and resume
                    //
                    virtualMachine.Update()
                        .WithSystemAssignedManagedServiceIdentity()
                        .WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .Apply();
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

        private static int? ObjectToInteger(object obj)
        {
            int? result = null;
            if (obj != null)
            {
                if (obj is Int16)
                {
                    result = (int)((Int16)obj);
                }
                else if (obj is Int32)
                {
                    result = (int)obj;
                }
                else if (obj is Int64)
                {
                    result = (int)((Int64)obj);
                }
                else
                {
                    result = int.Parse((string)obj);
                }
            }
            return result;
        }
    }
}
