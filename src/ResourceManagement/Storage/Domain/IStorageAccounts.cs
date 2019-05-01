// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for storage accounts management API.
    /// </summary>
    public interface IStorageAccounts :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<StorageAccount.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.IStorageManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Storage.Fluent.IStorageAccountsOperations>
    {
        /// <summary>
        /// Checks that account name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>A representation of the deferred computation of this call, returning whether the name is available and other info if not.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.CheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Storage.Fluent.CheckNameAvailabilityResult CheckNameAvailability(string name);

        
        /// <summary>
        /// Creates an Sas token for the storage account asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">the name of the account's resource group</param>
        /// <param name="accountName">the account name to check</param>
        /// <param name="parameters">the parameters to list service SAS credentials of a specific resource</param>
        /// <returns>the created SAS token</returns>
        Task<string> createSasTokenAsync(string resourceGroupName, string accountName, ServiceSasParameters parameters);


        /// <summary>
        /// Creates an Sas token for the storage account.
        /// </summary>
        /// <param name="resourceGroupName">the name of the account's resource group</param>
        /// <param name="accountName">the account name to check</param>
        /// <param name="parameters">the parameters to list service SAS credentials of a specific resource</param>
        /// <returns>the created SAS token</returns>
        string createSasToken(string resourceGroupName, string accountName, ServiceSasParameters parameters);
    }
}