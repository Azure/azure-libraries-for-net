// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update
{

    /// <summary>
    /// The stage of the management policy update allowing to update a rule.
    /// </summary>
    public interface IRule 
    {

        /// <summary>
        /// The function that updates a rule whose name is the inputted parameter name.
        /// </summary>
        /// <param name="name">The name of the rule to be updated.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate UpdateRule(string name);

        /// <summary>
        /// The function that removes a rule whose name is the inputted parameter name.
        /// </summary>
        /// <param name="name">The name of the rule to be removed.</param>
        /// <return>The next stage of the management policy update.</return>
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IUpdate WithoutRule(string name);
    }

    /// <summary>
    /// The template for a ManagementPolicy update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy>,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IWithPolicy,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IRule
    {

    }

    /// <summary>
    /// The stage of the management policy update allowing to specify Policy.
    /// </summary>
    public interface IWithPolicy 
    {

        /// <summary>
        /// Specifies policy.
        /// </summary>
        /// <param name="policy">The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IUpdate WithPolicy(ManagementPolicySchema policy);
    }
}