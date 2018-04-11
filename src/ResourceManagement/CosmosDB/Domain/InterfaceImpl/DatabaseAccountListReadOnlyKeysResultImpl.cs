// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class DatabaseAccountListReadOnlyKeysResultImpl 
    {
        /// <summary>
        /// Gets Base 64 encoded value of the secondary read-only key.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult.SecondaryReadonlyMasterKey
        {
            get
            {
                return this.SecondaryReadonlyMasterKey();
            }
        }

        /// <summary>
        /// Gets Base 64 encoded value of the primary read-only key.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult.PrimaryReadonlyMasterKey
        {
            get
            {
                return this.PrimaryReadonlyMasterKey();
            }
        }
    }
}