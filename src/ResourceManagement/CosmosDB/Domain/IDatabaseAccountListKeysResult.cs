// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure Cosmos DB DatabaseAccountListKeysResult.
    /// </summary>
    public interface IDatabaseAccountListKeysResult  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseAccountListKeysResultInner>
    {
        /// <summary>
        /// Gets Base 64 encoded value of the primary read-write key.
        /// </summary>
        string PrimaryMasterKey { get; }

        /// <summary>
        /// Gets Base 64 encoded value of the secondary read-write key.
        /// </summary>
        string SecondaryMasterKey { get; }

        /// <summary>
        /// Gets Base 64 encoded value of the secondary read-only key.
        /// </summary>
        string SecondaryReadonlyMasterKey { get; }

        /// <summary>
        /// Gets Base 64 encoded value of the primary read-only key.
        /// </summary>
        string PrimaryReadonlyMasterKey { get; }
    }
}