// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a SQL Database collection associated with an Azure SQL server.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZXNBc0V4dGVybmFsQ2hpbGRSZXNvdXJjZXNJbXBs
    internal partial class SqlDatabasesAsExternalChildResourcesImpl  
//        ExternalChildResourcesNonCachedImpl<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImpl,Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase,Models.DatabaseInner,Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>
    {
         ISqlManager sqlServerManager;
        ///GENMHASH:57CEDE581734041A0D95109A124A28F8:77FFC12151BA4757D17267B4BAA402A5
        internal IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImpl> GetChildren(PendingOperation pendingOperation)
        {
            //$ List<SqlDatabaseImpl> results = new ArrayList<>();
            //$ foreach(var child in this.ChildCollection.Values()) {
            //$ if (child.PendingOperation() == pendingOperation) {
            //$ results.Add(child);
            //$ }
            //$ }
            //$ 
            //$ return results;
            //$ }

            return null;
        }

        ///GENMHASH:C585B295576485AEE7C738FCE077A531:CA646817E1F2F6D3F18ECB90907B089F
        internal SqlDatabaseImpl DefineInlineDatabase(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineDefine(new SqlDatabaseImpl(null, null, null, name, new DatabaseInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineDefine(new SqlDatabaseImpl(name, this.Parent(), new DatabaseInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:D103B25596DDCD2049CC24CCC27F0773:64A8FEB316DD2139307025F5BEE38B56
        internal SqlDatabaseImpl DefineIndependentDatabase(string name)
        {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareIndependentDefine(new SqlDatabaseImpl(null, null, null, name, new DatabaseInner(), this.sqlServerManager));
            //$ }

            return null;
        }

        ///GENMHASH:91B6F4C2E49EB510D81E9D149C54E2C2:EC83B2BBE61752B338A8F1F345F535E0
        internal SqlDatabaseImpl UpdateInlineDatabase(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineUpdate(new SqlDatabaseImpl(null, null, null, name, new DatabaseInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineUpdate(new SqlDatabaseImpl(name, this.Parent(), new DatabaseInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="parent">The parent Azure resource.</param>
        /// <param name="childResourceName">The child resource name.</param>
        ///GENMHASH:8D45AE1AD6D1A9664BA1D27A88B0CB08:81DAFEBAA76CA1F0C97B24C82A83726B
        protected  SqlDatabasesAsExternalChildResourcesImpl(SqlServerImpl parent, string childResourceName)
        {
            //$ super(parent, parent.TaskGroup(), childResourceName);
            //$ 
            //$ this.sqlServerManager = parent.Manager();
            //$ }

        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="sqlServerManager">The manager.</param>
        /// <param name="childResourceName">The child resource name (for logging).</param>
        ///GENMHASH:52242E75523C40F34E42063317FF8316:6CCEE2B321517F187909D38DBF6631C9
        protected  SqlDatabasesAsExternalChildResourcesImpl(ISqlManager sqlServerManager, string childResourceName)
        {
            //$ super(null, null, childResourceName);
            //$ 
            //$ Objects.RequireNonNull(sqlServerManager);
            //$ this.sqlServerManager = sqlServerManager;
            //$ }

        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="parentTaskGroup">The parent task group.</param>
        /// <param name="sqlServerManager">The manager.</param>
        /// <param name="childResourceName">The child resource name (for logging).</param>
        ///GENMHASH:AEFF72B30602B4610ADCDAD6C785E0E7:9A724F0B41536261C490C1CA99C55D16
        //protected  SqlDatabasesAsExternalChildResourcesImpl(TaskGroup parentTaskGroup, ISqlManager sqlServerManager, string childResourceName)
        //{
        //    //$ super(null, parentTaskGroup, childResourceName);
        //    //$ 
        //    //$ Objects.RequireNonNull(sqlServerManager);
        //    //$ this.sqlServerManager = sqlServerManager;
        //    //$ }

        //}

        ///GENMHASH:BD533FE99C1DE45AC95DF855B10DFD7D:9E79E9E669C52E09365B1454FA66BCD7
        internal SqlDatabaseImpl PatchUpdateDatabase(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineUpdate(new SqlDatabaseImpl(null, null, null, name, new DatabaseInner(), this.sqlServerManager))
            //$ .WithPatchUpdate();
            //$ } else {
            //$ return prepareInlineUpdate(new SqlDatabaseImpl(name, this.Parent(), new DatabaseInner(), this.Parent().Manager()))
            //$ .WithPatchUpdate();
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:AD266EA69B7B3A9B449144856C8B73E7:C4DF358718BBC9336E72E988FC3C0D18
        internal void RemoveInlineDatabase(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ prepareInlineRemove(new SqlDatabaseImpl(null, null, null, name, new DatabaseInner(), this.sqlServerManager));
            //$ } else {
            //$ prepareInlineRemove(new SqlDatabaseImpl(name, this.Parent(), new DatabaseInner(), this.Parent().Manager()));
            //$ }
            //$ }

        }
    }
}