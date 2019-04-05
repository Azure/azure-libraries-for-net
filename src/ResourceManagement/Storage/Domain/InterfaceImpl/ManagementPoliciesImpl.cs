// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ManagementPoliciesImpl 
    {
        /// <summary>
        /// Deletes the managementpolicy associated with the specified storage account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task Microsoft.Azure.Management.Storage.Fluent.IManagementPolicies.DeleteAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(resourceGroupName, accountName, cancellationToken);
        }

        /// <summary>
        /// Gets the managementpolicy associated with the specified storage account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> Microsoft.Azure.Management.Storage.Fluent.IManagementPolicies.GetAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken)
        {
            return await this.GetAsync(resourceGroupName, accountName, cancellationToken);
        }
    }
}