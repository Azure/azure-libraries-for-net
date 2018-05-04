// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class DatabaseAccountListConnectionStringsResultImpl 
    {
        /// <summary>
        /// Gets a list that contains the connection strings for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.DatabaseAccountConnectionString> Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult.ConnectionStrings
        {
            get
            {
                return this.ConnectionStrings();
            }
        }
    }
}