// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The stage of the storage account update allowing to associate custom domain.
    /// </summary>
    public interface IWithCustomDomain
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(string name, bool useSubDomain);
    }

    public interface IWithUpgrade :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets Specifies that the storage account should be upgraded to V2 kind.
        /// </summary>
        /// <summary>
        /// Gets the next stage of storage account update.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate UpgradeToGeneralPurposeAccountKindV2();
    }

    /// <summary>
    /// The stage of the storage account update allowing to set whether Azure files aad integration is enabled.
    /// </summary>
    public interface IWithAzureFilesAadIntegration:
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies whether Azure files Aad integration will be enabled or not.
        /// </summary>
        /// <param name="enabled">Whether Azure files aad integration is enabled or not</param>
        /// <returns>The next stage of the storage account update.</returns>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAzureFilesAadIntegrationEnabled(bool enabled);
    }

    /// <summary>
    /// The template for a storage account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithSku,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithCustomDomain,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithEncryption,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithAccessTier,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithManagedServiceIdentity,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithAccessTraffic,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithNetworkAccess,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithUpgrade,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithAzureFilesAadIntegration,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of storage account update allowing to configure network access.
    /// </summary>
    public interface IWithNetworkAccess :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that read access to the storage logging should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithReadAccessToLogEntriesFromAnyNetwork();

        /// <summary>
        /// Specifies that previously added read access exception to the storage metrics from any network
        /// should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutReadAccessToMetricsFromAnyNetwork();

        /// <summary>
        /// Specifies that read access to the storage metrics should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithReadAccessToMetricsFromAnyNetwork();

        /// <summary>
        /// Specifies that by default access to storage account should be denied from
        /// all networks except from those networks specified via
        /// WithNetworkAccess.withAccessFromNetworkSubnet(String),
        /// WithNetworkAccess.withAccessFromIpAddress(String) and
        /// WithNetworkAccess.withAccessFromIpAddressRange(String).
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromSelectedNetworks();

        /// <summary>
        /// Specifies that previously allowed access from specific virtual network subnet should be removed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutNetworkSubnetAccess(string subnetId);

        /// <summary>
        /// Specifies that by default access to storage account should be allowed from
        /// all networks.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromAllNetworks();

        /// <summary>
        /// Specifies that previously added read access exception to the storage logging from any network
        /// should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutReadAccessToLoggingFromAnyNetwork();

        /// <summary>
        /// Specifies that access to the storage account from a specific virtual network
        /// subnet should be allowed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromNetworkSubnet(string subnetId);

        /// <summary>
        /// Specifies that access to the storage account should be allowed from applications running on
        /// Microsoft Azure services.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromAzureServices();

        /// <summary>
        /// Specifies that access to the storage account from a specific ip address should be allowed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromIpAddress(string ipAddress);

        /// <summary>
        /// Specifies that access to the storage account from a specific ip range should be allowed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessFromIpAddressRange(string ipAddressCidr);

        /// <summary>
        /// Specifies that previously allowed access from specific ip range should be removed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutIpAddressRangeAccess(string ipAddressCidr);

        /// <summary>
        /// Specifies that previously added access exception to the storage account from application
        /// running on azure should be removed.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutAccessFromAzureServices();

        /// <summary>
        /// Specifies that previously allowed access from specific ip address should be removed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutIpAddressAccess(string ipAddress);
    }

    /// <summary>
    /// The stage of the storage account update allowing to configure encryption settings.
    /// </summary>
    public interface IWithEncryption :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithEncryptionBeta
    {
        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <deprecated>Use IWithEncryption.WithoutBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutEncryption();

        /// <summary>
        /// Enables encryption for blob service.
        /// </summary>
        /// <deprecated>Use  WithEncryption.withBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithEncryption();
    }

    /// <summary>
    /// The stage of the storage account update allowing to specify the protocol to be used to access account.
    /// </summary>
    public interface IWithAccessTraffic :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that only https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithOnlyHttpsTraffic();

        /// <summary>
        /// Specifies that both http and https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithHttpAndHttpsTraffic();
    }

    /// <summary>
    /// The stage of the storage account update allowing to change the sku.
    /// </summary>
    public interface IWithSku :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithSkuBeta
    {
        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <deprecated>Use  WithSku.withSku(StorageAccountSkuType) instead.</deprecated>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithSku(SkuName skuName);

    }

    /// <summary>
    /// The stage of the storage account update allowing to enable managed service identity (MSI).
    /// </summary>
    public interface IWithManagedServiceIdentity :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithManagedServiceIdentityBeta
    {
    }

    /// <summary>
    /// A blob storage account update stage allowing access tier to be specified.
    /// </summary>
    public interface IWithAccessTier
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessTier(AccessTier accessTier);
    }

    /// <summary>
    /// The stage of the storage account update allowing to configure encryption settings.
    /// </summary>
    public interface IWithEncryptionBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the KeyVault key to be used as key for encryption.
        /// </summary>
        /// <param name="keyVaultUri">The uri to KeyVault.</param>
        /// <param name="keyName">The KeyVault key name.</param>
        /// <param name="keyVersion">The KeyVault key version.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithEncryptionKeyFromKeyVault(string keyVaultUri, string keyName, string keyVersion);

        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutBlobEncryption();

        /// <summary>
        /// Enables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithFileEncryption();

        /// <summary>
        /// Enables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithBlobEncryption();

        /// <summary>
        /// Disables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutFileEncryption();
    }

    /// <summary>
    /// The stage of the storage account update allowing to change the sku.
    /// </summary>
    public interface IWithSkuBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithSku(StorageAccountSkuType sku);
    }

    /// <summary>
    /// The stage of the storage account update allowing to enable managed service identity (MSI).
    /// </summary>
    public interface IWithManagedServiceIdentityBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that implicit managed service identity (MSI) needs to be enabled.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithSystemAssignedManagedServiceIdentity();
    }
}