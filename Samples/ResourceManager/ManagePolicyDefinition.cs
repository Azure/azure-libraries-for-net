// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManagePolicyDefinition
{
    public class Program
    {
        /**
        * Azure PolicyDefinition sample for managing policy definitions -
        * - Create a policy definition
        * - Update a policy definition
        * - Create another policy definition
        * - List policy definitions
        * - Delete policy definitions.
        */
        public static void RunSample(IAzure azure)
        {
            var policyDefinitionName1 = SdkContext.RandomResourceName("pd1", 24);
            var policyDefinitionName2 = SdkContext.RandomResourceName("pd2", 24);
            var allMode = "All";
            var indexedMode = "Indexed";
            var policyRuleJson = "{\"if\":{\"not\":{\"field\":\"location\",\"in\":[\"northeurope\",\"westeurope\"]}},\"then\":{\"effect\":\"deny\"}}";
            try
            {
                //=============================================================
                // Create policy definition.

                Utilities.Log("Creating a policy definition with name: " + policyDefinitionName1);

                var policyDefinition = azure.PolicyDefinitions.Define(policyDefinitionName1)
                    .WithPolicyRuleJson(policyRuleJson)
                    .WithCustomPolicyType()
                    .Create().Refresh();

                Utilities.Log("Policy definition created: " + policyDefinition.Id);

                //=============================================================
                // Update - set the sku name

                Utilities.Log("Update the policy definition with name: " + policyDefinitionName1);

                policyDefinition.Update()
                    .WithMode(allMode)
                    .Apply().Refresh();

                Utilities.Log("Updated the policy definition with name: " + policyDefinitionName1);

                //=============================================================
                // Create another policy definition.

                Utilities.Log("Creating another policy definition with name: " + policyDefinitionName2);

                var policyDefinition2 = azure.PolicyDefinitions.Define(policyDefinitionName2)
                    .WithPolicyRuleJson(policyRuleJson)
                    .WithCustomPolicyType()
                    .WithMode(indexedMode)
                    .Create().Refresh();

                Utilities.Log("Policy definition created: " + policyDefinition2.Id);

                //=============================================================
                // List policy definitions.

                Utilities.Log("Listing all policy definitions: ");

                foreach (var pDefinition in azure.PolicyDefinitions.List())
                {
                    Utilities.Log("Policy definition: " + pDefinition.Name);
                }

                //=============================================================
                // Delete policy definitions.

                Utilities.Log("Deleting policy definition: " + policyDefinitionName1);

                azure.PolicyDefinitions.DeleteByName(policyDefinition.Id);

                Utilities.Log("Deleted policy definition: " + policyDefinitionName1);

                Utilities.Log("Deleting policy definition: " + policyDefinitionName2);

                azure.PolicyDefinitions.DeleteByName(policyDefinitionName2);

                Utilities.Log("Deleted policy definition: " + policyDefinitionName2);

            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
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
