// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Cosmos DB DatabaseAccountListConnectionStringsResult.
    /// </summary>
    public interface IDatabaseAccountListConnectionStringsResult  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseAccountListConnectionStringsResultInner>
    {
        /// <summary>
        /// Gets a list that contains the connection strings for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.DatabaseAccountConnectionString> ConnectionStrings { get; }
    }
}