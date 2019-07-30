// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure storage account.
    /// </summary>
    public interface IStorageAccount :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Storage.Fluent.IStorageManager, Models.StorageAccountInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<StorageAccount.Update.IUpdate>,
        Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta
    {
        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call, returning the access keys.</return>
        Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the status indicating whether the primary and secondary location of
        /// the storage account is available or unavailable. Possible values include:
        /// 'Available', 'Unavailable'.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.AccountStatuses AccountStatuses { get; }

        /// <summary>
        /// Gets access tier used for billing. Access tier cannot be changed more
        /// than once every 7 days (168 hours). Access tier cannot be set for
        /// StandardLRS, StandardGRS, StandardRAGRS, or PremiumLRS account types.
        /// Possible values include: 'Hot', 'Cool'.
        /// </summary>
        Models.AccessTier AccessTier { get; }

        /// <summary>
        /// Gets the encryption statuses indexed by storage service type.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.Storage.Fluent.StorageService, Microsoft.Azure.Management.Storage.Fluent.IStorageAccountEncryptionStatus> EncryptionStatuses { get; }

        /// <return>Gets the encryption settings on the account.</return>
        /// <summary>
        /// Deprecated use StorageAccount.EncryptionKeySource, StorageAccount.encryptionStatuses instead.
        /// </summary>
       [System.Obsolete("Encryption getter is deprecated use StorageAccount.EncryptionKeySource, StorageAccount.encryptionStatuses instead.")]
        Models.Encryption Encryption { get; }


        /// <summary>
        /// Regenerates the access keys for this storage account.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>The generated access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> RegenerateKey(string keyName);

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob,
        /// queue or table object. Note that StandardZRS and PremiumLRS accounts
        /// only return the blob endpoint.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.PublicEndpoints EndPoints { get; }

        /// <summary>
        /// Gets the kind of the storage account. Possible values are 'Storage',
        /// 'BlobStorage'.
        /// </summary>
        Models.Kind Kind { get; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the
        /// secondary location. Only the most recent timestamp is retained. This
        /// element is not returned if there has never been a failover instance.
        /// Only available if the accountType is StandardGRS or StandardRAGRS.
        /// </summary>
        System.DateTime LastGeoFailoverTime { get; }

        /// <summary>
        /// Gets the status of the storage account at the time the operation was
        /// called. Possible values include: 'Creating', 'ResolvingDNS',
        /// 'Succeeded'.
        /// </summary>
        Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account.
        /// </summary>
        /// <return>The access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> GetKeys();

        /// <summary>
        /// Gets the user assigned custom domain assigned to this storage account.
        /// </summary>
        Models.CustomDomain CustomDomain { get; }

        /// <summary>
        /// Regenerates the access keys for this storage account asynchronously.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>A representation of the deferred computation of this call, returning the regenerated access key.</return>
        Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> RegenerateKeyAsync(string keyName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the source of the key used for encryption.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountEncryptionKeySource EncryptionKeySource { get; }

        /// <summary>
        /// Gets whether Azure files AAD integration is enabled on the storage account.
        /// </summary>
        bool? AzureFilesAadIntegration { get; }

        /// <summary>
        /// Gets whether Hns is enabled on the storage account.
        /// </summary>
        bool? HnsEnabled { get; }
    }
}