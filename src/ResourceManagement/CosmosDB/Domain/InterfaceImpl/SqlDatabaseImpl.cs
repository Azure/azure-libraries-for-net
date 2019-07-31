// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    internal partial class SqlDatabaseImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database
        /// </summary>
        string ISqlDatabase.SqlDatabaseId
        {
            get
            {
                return this.SqlDatabaseId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string ISqlDatabase._rid
        {
            get
            {
                return this._rid();
            }
        }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object ISqlDatabase._ts
        {
            get
            {
                return this._ts();
            }
        }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string ISqlDatabase._etag
        {
            get
            {
                return this._etag();
            }
        }

        /// <summary>
        /// Gets a system generated property that specified the
        /// addressable path of the collections resource.
        /// </summary>
        string ISqlDatabase._colls
        {
            get
            {
                return this._colls();
            }
        }

        /// <summary>
        /// Gets a system generated property that specifies the
        /// addressable path of the users resource.
        /// </summary>
        string ISqlDatabase._users
        {
            get
            {
                return this._users();
            }
        }
    }
}
