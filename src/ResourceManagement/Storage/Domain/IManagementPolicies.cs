// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Type representing ManagementPolicies.
    /// </summary>
    public interface IManagementPolicies  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ManagementPolicy.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IManagementPoliciesOperations>
    {

        /// <summary>
        /// Deletes the managementpolicy associated with the specified storage account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task DeleteAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the managementpolicy associated with the specified storage account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> GetAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));
    }
}