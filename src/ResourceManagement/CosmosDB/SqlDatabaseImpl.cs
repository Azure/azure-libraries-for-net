// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class SqlDatabaseImpl :
        Wrapper<Models.SqlDatabaseGetResultsInner>,
        ISqlDatabase
    {
        internal SqlDatabaseImpl(Models.SqlDatabaseGetResultsInner innerObject)
            : base(innerObject)
        {
        }

        public string SqlDatabaseId()
        {
            return this.Inner.Resource.Id;
        }

        public string _rid()
        {
            return this.Inner.Resource._rid;
        }

        public object _ts()
        {
            return this.Inner.Resource._ts;
        }

        public string _etag()
        {
            return this.Inner.Resource._etag;
        }

        public string _colls()
        {
            return this.Inner.Resource._colls;
        }

        public string _users()
        {
            return this.Inner.Resource._users;
        }
    }
}
