// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManagePolicyAssignment
{
    public class Program
    {
        /**
        * Azure PolicyAssignment sample for managing policy assignments -
        * - Create a policy assignment
        * - Create another policy assignment
        * - List policy assignments
        * - Delete policy assignments.
        */
        public static void RunSample(IAzure azure)
        {
            var resourceGroupName = SdkContext.RandomResourceName("rgRSMPA", 24);
            var policyDefinitionName = SdkContext.RandomResourceName("pdn", 24);
            var policyAssignmentName1 = SdkContext.RandomResourceName("pan1", 24);
            var policyAssignmentName2 = SdkContext.RandomResourceName("pan2", 24);
            var policyRuleJson = "{\"if\":{\"not\":{\"field\":\"location\",\"in\":[\"northeurope\",\"westeurope\"]}},\"then\":{\"effect\":\"deny\"}}";
            try
            {
                //=============================================================
                // Create resource group.

                Utilities.Log("Creating a resource group with name: " + resourceGroupName);

                var resourceGroup = azure.ResourceGroups.Define(resourceGroupName)
                    .WithRegion(Region.USWest)
                    .Create().Refresh();

                Utilities.Log("Resource group created: " + resourceGroup.Id);

                //=============================================================
                // Create policy definition.

                Utilities.Log("Creating a policy definition with name: " + policyDefinitionName);

                var policyDefinition = azure.PolicyDefinitions.Define(policyDefinitionName)
                    .WithPolicyRuleJson(policyRuleJson)
                    .WithCustomPolicyType()
                    .Create().Refresh();

                Utilities.Log("Policy definition created: " + policyDefinition.Id);

                //=============================================================
                // Create policy assignment.

                Utilities.Log("Creating a policy assignment with name: " + policyAssignmentName1);

                var policyAssignment = azure.PolicyAssignments.Define(policyAssignmentName1)
                    .ForResourceGroup(resourceGroup)
                    .WithPolicyDefinition(policyDefinition)
                    .WithDefaultMode()
                    .Create().Refresh();

                Utilities.Log("Policy assignment created: " + policyAssignment.Id);

                //=============================================================
                // Create another policy assignment.

                Utilities.Log("Creating a policy assignment with name: " + policyAssignmentName2);

                var policyAssignment2 = azure.PolicyAssignments.Define(policyAssignmentName2)
                    .ForResourceGroup(resourceGroup)
                    .WithPolicyDefinition(policyDefinition)
                    .WithDoNotEnforceMode()
                    .Create().Refresh();

                Utilities.Log("Policy assignment created: " + policyAssignment2.Id);

                //=============================================================
                // List policy assignments.

                Utilities.Log("Listing all policy assignments: ");

                foreach (var pAssignment in azure.PolicyAssignments.List())
                {
                    Utilities.Log("Policy assignment: " + pAssignment.Name);
                }

                //=============================================================
                // Delete policy assignments.

                Utilities.Log("Deleting policy assignment: " + policyAssignmentName1);

                azure.PolicyAssignments.DeleteById(policyAssignment.Id);

                Utilities.Log("Deleted policy assignment: " + policyAssignmentName1);

                Utilities.Log("Deleting policy assignment: " + policyAssignmentName2);

                azure.PolicyAssignments.DeleteById(policyAssignment2.Id);

                Utilities.Log("Deleted policy assignment: " + policyAssignmentName2);

                //=============================================================
                // Delete policy definition.

                Utilities.Log("Deleting policy definition: " + policyDefinitionName);

                azure.PolicyDefinitions.DeleteByName(policyDefinitionName);

                Utilities.Log("Deleted policy definition: " + policyDefinitionName);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + resourceGroupName);

                    azure.ResourceGroups.DeleteByName(resourceGroupName);

                    Utilities.Log("Deleted Resource Group: " + resourceGroupName);
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }
            
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
