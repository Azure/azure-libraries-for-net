// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition
{
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;

    /// <summary>
    /// The stage of the managementpolicy definition allowing to specify StorageAccount.
    /// </summary>
    public interface IWithStorageAccount 
    {

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithRule WithExistingStorageAccount(string resourceGroupName, string accountName);
    }

    /// <summary>
    /// The stage of the management policy definition allowing to specify a rule to add to the management policy.
    /// </summary>
    public interface IWithRule 
    {

        /// <summary>
        /// The function that defines a rule to attach to this policy.
        /// </summary>
        /// <param name="name">The name of the rule we are going to define.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IBlank DefineRule(string name);
    }

    /// <summary>
    /// The first stage of a ManagementPolicy definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithStorageAccount
    {

    }

    /// <summary>
    /// The entirety of the ManagementPolicy definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithRule,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy>,
        Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithRule
    {

    }
}