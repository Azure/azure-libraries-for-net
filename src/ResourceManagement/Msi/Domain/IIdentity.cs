// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent
{
    using Microsoft.Azure.Management.Msi.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure Managed Service Identity (MSI) Identity resource.
    /// </summary>
    public interface IIdentity  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Msi.Fluent.IMsiManager, IdentityInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Msi.Fluent.IIdentity>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Identity.Update.IUpdate>
    {
        /// <summary>
        /// Gets id of the Azure Active Directory application associated with the identity.
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Gets id of the Azure Active Directory tenant to which the identity belongs to.
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets id of the Azure Active Directory service principal object associated with the identity.
        /// </summary>
        string PrincipalId { get; }

        /// <summary>
        /// Gets the url that can be queried to obtain the identity credentials.
        /// </summary>
        string ClientSecretUrl { get; }
    }
}