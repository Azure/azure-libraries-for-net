// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to Azure firewalls management API in Azure.
    /// </summary>
    public interface IAzureFirewalls :
        ISupportsCreating<AzureFirewall.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsGettingById<IAzureFirewall>,
        ISupportsGettingByResourceGroup<IAzureFirewall>,
        ISupportsListing<IAzureFirewall>,
        ISupportsListingByResourceGroup<IAzureFirewall>,
        IHasManager<INetworkManager>,
        IHasInner<IAzureFirewallsOperations>
    {
    }
}
