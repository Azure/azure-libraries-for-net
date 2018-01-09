// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure storage account.
    /// </summary>
    public interface IStorageAccountBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory tenant ID assigned to the
        /// storage account.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets Checks storage account can be accessed from applications running on azure.
        /// </summary>
        /// <summary>
        /// Gets true if storage can be accessed from application running on azure, false otherwise.
        /// </summary>
        bool CanAccessFromAzureServices { get; }

        /// <summary>
        /// Gets Checks storage metrics can be read from any network.
        /// </summary>
        /// <summary>
        /// Gets true if storage metrics can be read from any network, false otherwise.
        /// </summary>
        bool CanReadMetricsFromAnyNetwork { get; }

        /// <summary>
        /// Gets the list of resource id of virtual network subnet having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> NetworkSubnetsWithAccess { get; }

        /// <summary>
        /// Gets the list of ip address ranges having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> IPAddressRangesWithAccess { get; }

        /// <summary>
        /// Gets the sku of this storage account.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountSkuType SkuType { get; }

        /// <summary>
        /// Gets true if authenticated application from any network is allowed to access the
        /// storage account, false if only application from whitelisted network (subnet, ip address,
        /// ip address range) can access the storage account.
        /// </summary>
        bool IsAccessAllowedFromAllNetworks { get; }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory service principal ID assigned
        /// to the storage account.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets Checks storage log entries can be read from any network.
        /// </summary>
        /// <summary>
        /// Gets true if storage log entries can be read from any network, false otherwise.
        /// </summary>
        bool CanReadLogEntriesFromAnyNetwork { get; }

        /// <summary>
        /// Gets the list of ip addresses having access to the storage account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> IPAddressesWithAccess { get; }
    }
}