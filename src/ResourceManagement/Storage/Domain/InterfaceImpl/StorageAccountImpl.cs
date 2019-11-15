// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class StorageAccountImpl
    {
        /// <summary>
        /// Gets the status indicating whether the primary and secondary location of
        /// the storage account is available or unavailable. Possible values include:
        /// 'Available', 'Unavailable'.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.AccountStatuses Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.AccountStatuses
        {
            get
            {
                return this.AccountStatuses();
            }
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account.
        /// </summary>
        /// <return>The access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.GetKeys()
        {
            return this.GetKeys();
        }

        /// <summary>
        /// Gets the user assigned custom domain assigned to this storage account.
        /// </summary>
        Models.CustomDomain Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.CustomDomain
        {
            get
            {
                return this.CustomDomain();
            }
        }

        /// <summary>
        /// Gets the source of the key used for encryption.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountEncryptionKeySource Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.EncryptionKeySource
        {
            get
            {
                return this.EncryptionKeySource();
            }
        }

        /// <summary>
        /// Gets the kind of the storage account. Possible values are 'Storage',
        /// 'BlobStorage'.
        /// </summary>
        Models.Kind Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Regenerates the access keys for this storage account.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>The generated access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.RegenerateKey(string keyName)
        {
            return this.RegenerateKey(keyName);
        }

        /// <summary>
        /// Gets the status of the storage account at the time the operation was
        /// called. Possible values include: 'Creating', 'ResolvingDNS',
        /// 'Succeeded'.
        /// </summary>
        Models.ProvisioningState Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <return>Gets the encryption settings on the account.</return>
        /// <summary>
        /// Use  StorageAccount.encryptionKeySource(),  StorageAccount.encryptionStatuses() instead.
        /// </summary>
        Models.Encryption Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.Encryption
        {
            get
            {
                return this.Encryption();
            }
        }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob,
        /// queue or table object. Note that StandardZRS and PremiumLRS accounts
        /// only return the blob endpoint.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.PublicEndpoints Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.EndPoints
        {
            get
            {
                return this.EndPoints();
            }
        }

        /// <summary>
        /// Gets the encryption statuses indexed by storage service type.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.Storage.Fluent.StorageService, Microsoft.Azure.Management.Storage.Fluent.IStorageAccountEncryptionStatus> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.EncryptionStatuses
        {
            get
            {
                return this.EncryptionStatuses();
            }
        }

        /// <summary>
        /// Gets access tier used for billing. Access tier cannot be changed more
        /// than once every 7 days (168 hours). Access tier cannot be set for
        /// StandardLRS, StandardGRS, StandardRAGRS, or PremiumLRS account types.
        /// Possible values include: 'Hot', 'Cool'.
        /// </summary>
        Models.AccessTier Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.AccessTier
        {
            get
            {
                return this.AccessTier();
            }
        }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the
        /// secondary location. Only the most recent timestamp is retained. This
        /// element is not returned if there has never been a failover instance.
        /// Only available if the accountType is StandardGRS or StandardRAGRS.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.LastGeoFailoverTime
        {
            get
            {
                return this.LastGeoFailoverTime();
            }
        }

        /// <summary>
        /// Regenerates the access keys for this storage account asynchronously.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>A representation of the deferred computation of this call, returning the regenerated access key.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.RegenerateKeyAsync(string keyName, CancellationToken cancellationToken)
        {
            return await this.RegenerateKeyAsync(keyName, cancellationToken);
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call, returning the access keys.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeysAsync(cancellationToken);
        }

        /// <summary>
        /// Enables encryption for blob service.
        /// </summary>
        /// <deprecated>Use  WithEncryption.WithBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryption.WithEncryption()
        {
            return this.WithEncryption();
        }

        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <deprecated>Use  WithEncryption.withoutBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryption.WithoutEncryption()
        {
            return this.WithoutEncryption();
        }

        /// <summary>
        /// Specifies that encryption needs be enabled for blob service.
        /// </summary>
        /// <deprecated>Use  WithEncryption.withBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryption.WithEncryption()
        {
            return this.WithEncryption();
        }

        /// <summary>
        /// Specifies the storage account kind to be "BlobStorage". The access
        /// tier is defaulted to be "Hot".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreateAndAccessTier StorageAccount.Definition.IWithBlobStorageAccountKind.WithBlobStorageAccountKind()
        {
            return this.WithBlobStorageAccountKind();
        }

        /// <summary>
        /// Specifies the storage account kind to be "FileStorage".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithFileStorageAccountKind.WithFileStorageAccountKind()
        {
            return this.WithFileStorageAccountKind();
        }

        /// <summary>
        /// Specifies the storage account kind to be "BlockBlobStorage".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithBlockBlobStorageAccountKind.WithBlockBlobStorageAccountKind()
        {
            return this.WithBlockBlobStorageAccountKind();
        }

        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return this.WithAccessTier(accessTier);
        }

        /// <summary>
        /// Specifies the storage account kind to be "Storage", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithGeneralPurposeAccountKind.WithGeneralPurposeAccountKind()
        {
            return this.WithGeneralPurposeAccountKind();
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        StorageAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<StorageAccount.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <deprecated>Use  WithSku.withSku(StorageAccountSkuType) instead.</deprecated>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName);
        }

        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithSkuBeta.WithSku(StorageAccountSkuType sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <deprecated>Use  WithSku.withSku(StorageAccountSkuType) instead.</deprecated>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName);
        }




        /// <summary>
        /// Gets Checks storage account can be accessed from applications running on azure.
        /// </summary>
        /// <summary>
        /// Gets true if storage can be accessed from application running on azure, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.CanAccessFromAzureServices
        {
            get
            {
                return this.CanAccessFromAzureServices();
            }
        }

        /// <summary>
        /// Gets the sku of this storage account.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountSkuType Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.SkuType
        {
            get
            {
                return this.SkuType();
            }
        }

        /// <summary>
        /// Gets the list of ip address ranges having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.IPAddressRangesWithAccess
        {
            get
            {
                return this.IPAddressRangesWithAccess();
            }
        }


        /// <summary>
        /// Gets Checks storage metrics can be read from any network.
        /// </summary>
        /// <summary>
        /// Gets true if storage metrics can be read from any network, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.CanReadMetricsFromAnyNetwork
        {
            get
            {
                return this.CanReadMetricsFromAnyNetwork();
            }
        }

        /// <summary>
        /// Gets the list of ip addresses having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.IPAddressesWithAccess
        {
            get
            {
                return this.IPAddressesWithAccess();
            }
        }

        /// <summary>
        /// Gets true if authenticated application from any network is allowed to access the
        /// storage account, false if only application from whitelisted network (subnet, ip address,
        /// ip address range) can access the storage account.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.IsAccessAllowedFromAllNetworks
        {
            get
            {
                return this.IsAccessAllowedFromAllNetworks();
            }
        }

        /// <summary>
        /// Gets Checks storage log entries can be read from any network.
        /// </summary>
        /// <summary>
        /// Gets true if storage log entries can be read from any network, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.CanReadLogEntriesFromAnyNetwork
        {
            get
            {
                return this.CanReadLogEntriesFromAnyNetwork();
            }
        }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory service principal ID assigned
        /// to the storage account.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.SystemAssignedManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityPrincipalId();
            }
        }

        /// <summary>
        /// Gets the list of resource id of virtual network subnet having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.NetworkSubnetsWithAccess
        {
            get
            {
                return this.NetworkSubnetsWithAccess();
            }
        }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory tenant ID assigned to the
        /// storage account.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.SystemAssignedManagedServiceIdentityTenantId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// Specifies that previously allowed access from specific ip address should be removed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutIpAddressAccess(string ipAddress)
        {
            return this.WithoutIpAddressAccess(ipAddress);
        }

        /// <summary>
        /// Specifies that previously added read access exception to the storage metrics from any network
        /// should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutReadAccessToMetricsFromAnyNetwork()
        {
            return this.WithoutReadAccessToMetricsFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that access to the storage account from a specific ip range should be allowed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromIpAddressRange(string ipAddressCidr)
        {
            return this.WithAccessFromIpAddressRange(ipAddressCidr);
        }

        /// <summary>
        /// Specifies that by default access to storage account should be denied from
        /// all networks except from those networks specified via
        /// WithNetworkAccess.withAccessFromNetworkSubnet(String),
        /// WithNetworkAccess.withAccessFromIpAddress(String) and
        /// WithNetworkAccess.withAccessFromIpAddressRange(String).
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromSelectedNetworks()
        {
            return this.WithAccessFromSelectedNetworks();
        }

        /// <summary>
        /// Specifies that previously added read access exception to the storage logging from any network
        /// should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutReadAccessToLoggingFromAnyNetwork()
        {
            return this.WithoutReadAccessToLoggingFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that read access to the storage metrics should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithReadAccessToMetricsFromAnyNetwork()
        {
            return this.WithReadAccessToMetricsFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that access to the storage account from a specific ip address should be allowed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromIpAddress(string ipAddress)
        {
            return this.WithAccessFromIpAddress(ipAddress);
        }

        /// <summary>
        /// Specifies that access to the storage account should be allowed from applications running on
        /// Microsoft Azure services.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromAzureServices()
        {
            return this.WithAccessFromAzureServices();
        }

        /// <summary>
        /// Specifies that previously allowed access from specific virtual network subnet should be removed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutNetworkSubnetAccess(string subnetId)
        {
            return this.WithoutNetworkSubnetAccess(subnetId);
        }

        /// <summary>
        /// Specifies that previously allowed access from specific ip range should be removed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutIpAddressRangeAccess(string ipAddressCidr)
        {
            return this.WithoutIpAddressRangeAccess(ipAddressCidr);
        }

        /// <summary>
        /// Specifies that read access to the storage logging should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithReadAccessToLogEntriesFromAnyNetwork()
        {
            return this.WithReadAccessToLogEntriesFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that access to the storage account from a specific virtual network
        /// subnet should be allowed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromNetworkSubnet(string subnetId)
        {
            return this.WithAccessFromNetworkSubnet(subnetId);
        }

        /// <summary>
        /// Specifies that previously added access exception to the storage account from application
        /// running on azure should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithoutAccessFromAzureServices()
        {
            return this.WithoutAccessFromAzureServices();
        }

        /// <summary>
        /// Specifies that by default access to storage account should be allowed from
        /// all networks.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithNetworkAccess.WithAccessFromAllNetworks()
        {
            return this.WithAccessFromAllNetworks();
        }

        /// <summary>
        /// Specifies that access to the storage account from the specific ip range should be allowed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromIpAddressRange(string ipAddressCidr)
        {
            return this.WithAccessFromIpAddressRange(ipAddressCidr);
        }

        /// <summary>
        /// Specifies that by default access to storage account should be denied from
        /// all networks except from those networks specified via
        /// WithNetworkAccess.withAccessFromNetworkSubnet(String)
        /// WithNetworkAccess.withAccessFromIpAddress(String) and
        /// WithNetworkAccess.withAccessFromIpAddressRange(String).
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromSelectedNetworks()
        {
            return this.WithAccessFromSelectedNetworks();
        }

        /// <summary>
        /// Specifies that read access to the storage metrics should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithReadAccessToMetricsFromAnyNetwork()
        {
            return this.WithReadAccessToMetricsFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that access to the storage account from the specific ip address should be allowed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromIpAddress(string ipAddress)
        {
            return this.WithAccessFromIpAddress(ipAddress);
        }

        /// <summary>
        /// Specifies that access to the storage account should be allowed from applications running
        /// on Microsoft Azure services.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromAzureServices()
        {
            return this.WithAccessFromAzureServices();
        }

        /// <summary>
        /// Specifies that read access to the storage logging should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithReadAccessToLogEntriesFromAnyNetwork()
        {
            return this.WithReadAccessToLogEntriesFromAnyNetwork();
        }

        /// <summary>
        /// Specifies that access to the storage account from the specific virtual network subnet should be allowed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromNetworkSubnet(string subnetId)
        {
            return this.WithAccessFromNetworkSubnet(subnetId);
        }

        /// <summary>
        /// Specifies that by default access to storage account should be allowed from all networks.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithNetworkAccess.WithAccessFromAllNetworks()
        {
            return this.WithAccessFromAllNetworks();
        }

        /// <summary>
        /// Specifies whether Hns is enabled for this storage account.
        /// </summary>
        /// <param name="enabled">Whether Hns will be enabled or not</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithHns.WithHnsEnabled(bool enabled)
        {
            return this.WithHnsEnabled(enabled);
        }

        /// <summary>
        /// Specifies whether Azure files aad integration is enabled for this storage account.
        /// </summary>
        /// <param name="enabled">Whether Azure files aad integration will be enabled or not</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithAzureFilesAadIntegration.WithAzureFilesAadIntegrationEnabled(bool enabled)
        {
            return this.WithAzureFilesAadIntegrationEnabled(enabled);
        }

        /// <summary>
        /// Gets Specifies that the storage account should be upgraded to V2 kind.
        /// </summary>
        /// <summary>
        /// Gets the next stage of storage account update.
        /// </summary>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithUpgrade.UpgradeToGeneralPurposeAccountKindV2()
        {
            return this.UpgradeToGeneralPurposeAccountKindV2();
        }

        
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAzureFilesAadIntegration.WithAzureFilesAadIntegrationEnabled(bool enabled)
        {
            return this.WithAzureFilesAadIntegrationEnabled(enabled);
        }

        /// <summary>
        /// Enables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithFileEncryption()
        {
            return this.WithFileEncryption();
        }

        /// <summary>
        /// Disables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithoutFileEncryption()
        {
            return this.WithoutFileEncryption();
        }

        /// <summary>
        /// Enables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithBlobEncryption()
        {
            return this.WithBlobEncryption();
        }

        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithoutBlobEncryption()
        {
            return this.WithoutBlobEncryption();
        }

        /// <summary>
        /// Specifies the KeyVault key to be used as key for encryption.
        /// </summary>
        /// <param name="keyVaultUri">The uri to KeyVault.</param>
        /// <param name="keyName">The KeyVault key name.</param>
        /// <param name="keyVersion">The KeyVault key version.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithEncryptionKeyFromKeyVault(string keyVaultUri, string keyName, string keyVersion)
        {
            return this.WithEncryptionKeyFromKeyVault(keyVaultUri, keyName, keyVersion);
        }

        /// <summary>
        /// Specifies that encryption needs be enabled for file service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithFileEncryption()
        {
            return this.WithFileEncryption();
        }

        /// <summary>
        /// Disables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithoutFileEncryption()
        {
            return this.WithoutFileEncryption();
        }

        /// <summary>
        /// Specifies that encryption needs be enabled for blob service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithBlobEncryption()
        {
            return this.WithBlobEncryption();
        }

        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithoutBlobEncryption()
        {
            return this.WithoutBlobEncryption();
        }

        /// <summary>
        /// Specifies the KeyVault key to be used as encryption key.
        /// </summary>
        /// <param name="keyVaultUri">The uri to KeyVault.</param>
        /// <param name="keyName">The KeyVault key name.</param>
        /// <param name="keyVersion">The KeyVault key version.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithEncryptionKeyFromKeyVault(string keyVaultUri, string keyName, string keyVersion)
        {
            return this.WithEncryptionKeyFromKeyVault(keyVaultUri, keyName, keyVersion);
        }

        /// <summary>
        /// Specifies the storage account kind to be "StorageV2", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithGeneralPurposeAccountKind.WithGeneralPurposeAccountKindV2()
        {
            return this.WithGeneralPurposeAccountKindV2();
        }

        /// <summary>
        /// Specifies that implicit managed service identity (MSI) needs to be enabled.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithManagedServiceIdentityBeta.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that implicit managed service identity (MSI) needs to be enabled.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithManagedServiceIdentityBeta.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that both http and https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTraffic.WithHttpAndHttpsTraffic()
        {
            return this.WithHttpAndHttpsTraffic();
        }

        /// <summary>
        /// Specifies that only https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTraffic.WithOnlyHttpsTraffic()
        {
            return this.WithOnlyHttpsTraffic();
        }

        /// <summary>
        /// Specifies that only https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithAccessTraffic.WithOnlyHttpsTraffic()
        {
            return this.WithOnlyHttpsTraffic();
        }

        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithSkuBeta.WithSku(StorageAccountSkuType sku)
        {
            return this.WithSku(sku);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return this.WithCustomDomain(customDomain);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name)
        {
            return this.WithCustomDomain(name);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return this.WithCustomDomain(name, useSubDomain);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return this.WithCustomDomain(customDomain);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name)
        {
            return this.WithCustomDomain(name);
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return this.WithCustomDomain(name, useSubDomain);
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCreateAndAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return this.WithAccessTier(accessTier);
        }
    }
}