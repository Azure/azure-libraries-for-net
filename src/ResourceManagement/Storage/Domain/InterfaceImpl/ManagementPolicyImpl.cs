// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ManagementPolicyImpl 
    {
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the lastModifiedTime value.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the policy value.
        /// </summary>
        ManagementPolicySchema Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.Policy
        {
            get
            {
                return this.Policy();
            }
        }

        /// <summary>
        /// Gets the list of rules for this policy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.IPolicyRule> Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.Rules
        {
            get
            {
                return this.Rules();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// The function that defines a rule to attach to this policy.
        /// </summary>
        /// <param name="name">The name of the rule we are going to define.</param>
        /// <return>The next definition stage.</return>
        PolicyRule.Definition.IBlank ManagementPolicy.Definition.IWithRule.DefineRule(string name)
        {
            return this.DefineRule(name);
        }

        /// <summary>
        /// The function that updates a rule whose name is the inputted parameter name.
        /// </summary>
        /// <param name="name">The name of the rule to be updated.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate ManagementPolicy.Update.IRule.UpdateRule(string name)
        {
            return this.UpdateRule(name);
        }

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        ManagementPolicy.Definition.IWithRule ManagementPolicy.Definition.IWithStorageAccount.WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            return this.WithExistingStorageAccount(resourceGroupName, accountName);
        }

        /// <summary>
        /// The function that removes a rule whose name is the inputted parameter name.
        /// </summary>
        /// <param name="name">The name of the rule to be removed.</param>
        /// <return>The next stage of the management policy update.</return>
        ManagementPolicy.Update.IUpdate ManagementPolicy.Update.IRule.WithoutRule(string name)
        {
            return this.WithoutRule(name);
        }

        /// <summary>
        /// Specifies policy.
        /// </summary>
        /// <param name="policy">The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.</param>
        /// <return>The next update stage.</return>
        ManagementPolicy.Update.IUpdate ManagementPolicy.Update.IWithPolicy.WithPolicy(ManagementPolicySchema policy)
        {
            return this.WithPolicy(policy);
        }
    }
}