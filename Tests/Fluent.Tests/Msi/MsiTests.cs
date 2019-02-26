// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Msi
{
    public class Msi
    {
        private static Region region = Region.USWestCentral;

        [Fact]
        public void CanCreateGetListDelete()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgmsi");
                var identityName = TestUtilities.GenerateName("msitest");
                try
                {
                    var azure = TestHelper.CreateRollupClient();

                    var creatableRG = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var identity = azure.Identities
                        .Define(identityName)
                        .WithRegion(region)
                        .WithNewResourceGroup(creatableRG)
                        .Create();

                    Assert.NotNull(identity);
                    Assert.NotNull(identity.Inner);
                    Assert.True(identityName.Equals(identity.Name, StringComparison.OrdinalIgnoreCase), $"{identityName} == {identity.Name}");
                    Assert.True(identity.ResourceGroupName.Equals(rgName, StringComparison.OrdinalIgnoreCase), $"{rgName} == {identity.ResourceGroupName}");
                    Assert.NotNull(identity.ClientId);
                    Assert.NotNull(identity.PrincipalId);
                    Assert.NotNull(identity.TenantId);
                    //Assert.NotNull(identity.ClientSecretUrl);

                    identity = azure.Identities.GetById(identity.Id);

                    Assert.NotNull(identity);
                    Assert.NotNull(identity.Inner);

                    var identities = azure.Identities.ListByResourceGroup(rgName);
                    Assert.NotNull(identities);

                    var found = false;
                    foreach (var id in identities)
                    {
                        Assert.NotNull(id);
                        Assert.NotNull(id.Inner);
                        if (id.Name.Equals(identityName, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                        }
                        Assert.NotNull(identity.ClientId);
                        Assert.NotNull(identity.PrincipalId);
                        Assert.NotNull(identity.TenantId);
                        //Assert.NotNull(identity.ClientSecretUrl);
                    }

                    Assert.True(found);

                    azure.Identities
                            .DeleteById(identity.Id);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanAssignCurrentResourceGroupAccessRole()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgmsi");
                var identityName = TestUtilities.GenerateName("msitest");
                try
                {
                    var azure = TestHelper.CreateRollupClient();

                    var creatableRG = azure.ResourceGroups
                            .Define(rgName)
                            .WithRegion(region);

                    var identity = azure.Identities
                            .Define(identityName)
                            .WithRegion(region)
                            .WithNewResourceGroup(creatableRG)
                            .WithAccessToCurrentResourceGroup(BuiltInRole.Reader)
                            .Create();

                    // Ensure role assigned
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(identity.ResourceGroupName);
                    var roleAssignments = azure.Identities.Manager.GraphRbacManager
                        .RoleAssignments
                        .ListByScope(resourceGroup.Id);
                    var found = false;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Expected role assignment not found for the resource group that identity belongs to");

                    identity.Update()
                            .WithoutAccessTo(resourceGroup.Id, BuiltInRole.Reader)
                            .Apply();

                    SdkContext.DelayProvider.Delay(30 * 1000);

                    // Ensure role assignment removed
                    //
                    roleAssignments = azure.Identities.Manager.GraphRbacManager
                        .RoleAssignments
                        .ListByScope(resourceGroup.Id);
                    bool notFound = true;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            notFound = false;
                            break;
                        }
                    }
                    Assert.True(notFound, "Role assignment to access resource group is not removed");

                    azure.Identities.DeleteById(identity.Id);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }


        [Fact]
        public void CanAssignRoles()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgmsi");
                var identityName = TestUtilities.GenerateName("msitest");
                var anotherRgName = TestUtilities.GenerateName("rg");
                try
                {
                    var azure = TestHelper.CreateRollupClient();

                    var anotherResourceGroup = azure.ResourceGroups
                        .Define(anotherRgName)
                        .WithRegion(region)
                        .Create();

                    var creatableRG = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var identity = azure.Identities
                        .Define(identityName)
                        .WithRegion(region)
                        .WithNewResourceGroup(creatableRG)
                        .WithAccessToCurrentResourceGroup(BuiltInRole.Reader)
                        .WithAccessTo(anotherResourceGroup, BuiltInRole.Contributor)
                        .Create();

                    Assert.NotNull(identity);
                    Assert.NotNull(identity.Inner);

                    // Ensure roles are assigned
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(identity.ResourceGroupName);
                    var roleAssignments = azure.Identities.Manager.GraphRbacManager.RoleAssignments.ListByScope(resourceGroup.Id);
                    bool found = false;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Expected role assignment not found for the resource group that identity belongs to");

                    roleAssignments = azure.Identities.Manager.GraphRbacManager.RoleAssignments.ListByScope(anotherResourceGroup.Id);
                    found = false;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(identity.PrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Expected role assignment not found for the resource group resource");

                    identity = identity
                            .Update()
                            .WithTag("a", "bb")
                            .Apply();

                    Assert.NotNull(identity.Tags);
                    Assert.True(identity.Tags.ContainsKey("a"));
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
