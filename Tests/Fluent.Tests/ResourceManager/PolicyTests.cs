// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class Policy
    {
        [Fact]
        public void CanCRUDPolicyDefinition()
        {
            using(var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string id = null;
                var policyDefinitionName = TestUtilities.GenerateName("pol-def-");
                var policyDefinitionDisplayName = TestUtilities.GenerateName("pol-dis-");
                var description = "policy definition description";
                var policyRuleJson = "{\"if\":{\"not\":{\"field\":\"location\",\"in\":[\"northeurope\",\"westeurope\"]}},\"then\":{\"effect\":\"deny\"}}";
                IResourceManager resourceManager = TestHelper.CreateResourceManager();

                try
                { 
                    //create policy definition
                    resourceManager.PolicyDefinitions.Define(policyDefinitionName)
                        .WithPolicyRuleJson(policyRuleJson)
                        .WithDisplayName(policyDefinitionDisplayName)
                        .WithCustomPolicyType()
                        .WithMode("All")
                        .WithDescription(description)
                        .Create();
                    //find the one created
                    var policyDefinitions = resourceManager.PolicyDefinitions.List();
                    var found = from definition in policyDefinitions
                                where definition.Name.Equals(policyDefinitionName, StringComparison.OrdinalIgnoreCase)
                                select definition;

                    Assert.NotNull(found);
                    //get policy definition by name
                    var policyDefinition = resourceManager.PolicyDefinitions.GetByName(policyDefinitionName);
                    id = policyDefinition.Id;

                    Assert.NotNull(policyDefinition);
                    Assert.Equal(PolicyType.Custom, policyDefinition.PolicyType);
                    Assert.Equal(description, policyDefinition.Description);
                    //update 
                    policyDefinition.Update()
                        .WithMode("Indexed")
                        .Apply();

                    policyDefinition.Refresh();
                    Assert.Equal("Indexed", policyDefinition.Mode);                    
                }
                finally
                {
                    try
                    {
                        resourceManager.PolicyDefinitions.DeleteByName(policyDefinitionName);
                        Assert.Null(resourceManager.PolicyDefinitions.GetByName(policyDefinitionName));
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCRUDPolicyAssignment()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string policyDefinitionId = null;
                string policyAssignmentId = null;
                var policyDefinitionName = TestUtilities.GenerateName("pol-def-");
                var policyDefinitionDisplayName = TestUtilities.GenerateName("pol-defdis-");
                var rgName = TestUtilities.GenerateName("rg-");
                var policyAssignmentName = TestUtilities.GenerateName("pol-ass-");
                var policyAssignmentDisplayName = TestUtilities.GenerateName("pol-assdis-");
                var description = "policy definition description";
                var policyRuleJson = "{\"if\":{\"not\":{\"field\":\"location\",\"in\":[\"northeurope\",\"westeurope\"]}},\"then\":{\"effect\":\"deny\"}}";
                IResourceManager resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    //create policy definition
                    var policyDefinition = resourceManager.PolicyDefinitions.Define(policyDefinitionName)
                        .WithPolicyRuleJson(policyRuleJson)
                        .WithDisplayName(policyDefinitionDisplayName)
                        .WithCustomPolicyType()
                        .WithMode("All")
                        .WithDescription(description)
                        .Create();
                    policyDefinition.Refresh();
                    policyDefinitionId = policyDefinition.Id;
                    //create resource group
                    var resourceGroup = resourceManager.ResourceGroups.Define(rgName)
                        .WithRegion(Region.AsiaSouthEast)
                        .Create();
                    resourceGroup.Refresh();
                    //create policy assignment
                    var policyAssignment = resourceManager.PolicyAssignments.Define(policyAssignmentName)
                        .ForResourceGroup(resourceGroup)
                        .WithPolicyDefinition(policyDefinition)
                        .WithDisplayName(policyAssignmentDisplayName)
                        .WithDefaultMode()
                        .Create();
                    policyAssignmentId = policyAssignment.Id;

                    Assert.NotNull(policyAssignment);
                    Assert.Equal(EnforcementMode.Default, policyAssignment.EnforcementMode);
                    Assert.Equal(policyAssignmentDisplayName, policyAssignment.DisplayName);
                }
                finally
                {
                    try
                    {
                        resourceManager.PolicyDefinitions.DeleteByName(policyDefinitionName);
                        resourceManager.PolicyAssignments.DeleteById(policyAssignmentId);
                    }
                    catch { }
                }
            }
        }
    }
}
