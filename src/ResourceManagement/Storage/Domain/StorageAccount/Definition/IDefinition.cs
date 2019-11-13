// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// The stage of a storage account definition allowing to specify sku.
    /// </summary>
    public interface IWithSku :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithSkuBeta
    {
        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <deprecated>Use  IWithSku.WithSku(StorageAccountSkuType) instead.</deprecated>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
       [System.Obsolete("IIWithSku.WithSku(SkuName) is deprecated, use IWithSku.WithSku(StorageAccountSkuType) instead.")]
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithSku(SkuName skuName);
    }

    /// <summary>
    /// The stage of storage account definition allowing to set access tier.
    /// </summary>
    public interface IWithCreateAndAccessTier :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessTier(AccessTier accessTier);
    }

    /// <summary>
    /// The stage of a storage account definition allowing to enable implicit managed service identity (MSI).
    /// </summary>
    public interface IWithManagedServiceIdentity :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithManagedServiceIdentityBeta
    {
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify encryption settings.
    /// </summary>
    public interface IWithEncryption :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithEncryptionBeta
    {
        /// <summary>
        /// Specifies that encryption needs be enabled for blob service.
        /// </summary>
        /// <deprecated>Use  WithEncryption.WithBlobEncryption() instead.</deprecated>
        /// <return>The next stage of storage account definition.</return>
        [System.Obsolete("IWithEncryption.WithEncryption() is deprecated, use IWithEncryption.withBlobEncryption() instead.")]
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithEncryption();
    }

    /// <summary>
    /// The stage of storage account definition allowing to restrict access protocol.
    /// </summary>
    public interface IWithAccessTraffic :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that only https traffic should be allowed to storage account.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithOnlyHttpsTraffic();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify account kind as general purpose.
    /// </summary>
    public interface IWithGeneralPurposeAccountKind
    {
        /// <summary>
        /// Specifies the storage account kind to be "StorageV2", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithGeneralPurposeAccountKindV2();

        /// <summary>
        /// Specifies the storage account kind to be "Storage", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithGeneralPurposeAccountKind();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to associate custom domain with the account.
    /// </summary>
    public interface IWithCustomDomain
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(string name, bool useSubDomain);
    }

    /// <summary>
    /// The stage of storage account definition allowing to configure network access settings.
    /// </summary>
    public interface IWithNetworkAccess :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that access to the storage account from the specific virtual network subnet should be allowed.
        /// </summary>
        /// <param name="subnetId">The virtual network subnet id.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromNetworkSubnet(string subnetId);

        /// <summary>
        /// Specifies that access to the storage account should be allowed from applications running
        /// on Microsoft Azure services.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromAzureServices();

        /// <summary>
        /// Specifies that access to the storage account from the specific ip address should be allowed.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromIpAddress(string ipAddress);

        /// <summary>
        /// Specifies that access to the storage account from the specific ip range should be allowed.
        /// </summary>
        /// <param name="ipAddressCidr">The ip address range expressed in cidr format.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromIpAddressRange(string ipAddressCidr);

        /// <summary>
        /// Specifies that read access to the storage logging should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithReadAccessToLogEntriesFromAnyNetwork();

        /// <summary>
        /// Specifies that read access to the storage metrics should be allowed from any network.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithReadAccessToMetricsFromAnyNetwork();

        /// <summary>
        /// Specifies that by default access to storage account should be denied from
        /// all networks except from those networks specified via
        /// WithNetworkAccess.withAccessFromNetworkSubnet(String)
        /// WithNetworkAccess.withAccessFromIpAddress(String) and
        /// WithNetworkAccess.withAccessFromIpAddressRange(String).
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromSelectedNetworks();

        /// <summary>
        /// Specifies that by default access to storage account should be allowed from all networks.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessFromAllNetworks();
    }

    /// <summary>
    /// The stage of storage account definition allowing to configure whether Hns is enabled or not.
    /// </summary>
    public interface IWithHns :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        
        /// <summary>
        /// Specifies whether Hns is enabled or not.
        /// </summary>
        /// <param name="enabled">whether Hns is enabled for the storage account or not</param>
        /// <returns>The next stage of the storage account definition.</returns>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithHnsEnabled(bool enabled);

    }

    /// <summary>
    /// The stage of storage account definition allowing to configure network access settings.
    /// </summary>
    public interface IWithAzureFilesAadIntegration :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies whether Azure files aad integration is enabled or not.
        /// </summary>
        /// <param name="enabled">whether Hns is enabled for the storage account or not</param>
        /// <returns>The next stage of the storage account definition.</returns>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAzureFilesAadIntegrationEnabled(bool enabled);

    }



    /// <summary>
    /// The first stage of the storage account definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A storage account definition with sufficient inputs to create a new
    /// storage account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithSku,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithBlobStorageAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGeneralPurposeAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithFileStorageAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithBlockBlobStorageAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithEncryption,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCustomDomain,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithManagedServiceIdentity,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithAccessTraffic,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithNetworkAccess,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithHns,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithAzureFilesAadIntegration,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGroup,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreateAndAccessTier
    {
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify account kind as blob storage.
    /// </summary>
    public interface IWithBlobStorageAccountKind
    {
        /// <summary>
        /// Specifies the storage account kind to be "BlobStorage". The access
        /// tier is defaulted to be "Hot".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreateAndAccessTier WithBlobStorageAccountKind();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify account kind as block blob storage.
    /// </summary>
    public interface IWithBlockBlobStorageAccountKind
    {
        /// <summary>
        /// Specifies the storage account kind to be "BlockBlobStorage". 
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithBlockBlobStorageAccountKind();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify account kind as file storage.
    /// </summary>
    public interface IWithFileStorageAccountKind
    {
        /// <summary>
        /// Specifies the storage account kind to be "FileStorage". 
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithFileStorageAccountKind();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify sku.
    /// </summary>
    public interface IWithSkuBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the sku of the storage account.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithSku(StorageAccountSkuType sku);
    }

    /// <summary>
    /// The stage of a storage account definition allowing to enable implicit managed service identity (MSI).
    /// </summary>
    public interface IWithManagedServiceIdentityBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that implicit managed service identity (MSI) needs to be enabled.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of a storage account definition allowing to specify encryption settings.
    /// </summary>
    public interface IWithEncryptionBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the KeyVault key to be used as encryption key.
        /// </summary>
        /// <param name="keyVaultUri">The uri to KeyVault.</param>
        /// <param name="keyName">The KeyVault key name.</param>
        /// <param name="keyVersion">The KeyVault key version.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithEncryptionKeyFromKeyVault(string keyVaultUri, string keyName, string keyVersion);

        /// <summary>
        /// Disables encryption for blob service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithoutBlobEncryption();

        /// <summary>
        /// Specifies that encryption needs be enabled for file service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithFileEncryption();

        /// <summary>
        /// Specifies that encryption needs be enabled for blob service.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithBlobEncryption();

        /// <summary>
        /// Disables encryption for file service.
        /// </summary>
        /// <return>He next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithoutFileEncryption();
    }
}