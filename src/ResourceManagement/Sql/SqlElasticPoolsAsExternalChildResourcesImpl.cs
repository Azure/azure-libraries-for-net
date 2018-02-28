// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a SQL Elastic Pool collection associated with an Azure SQL server.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbHNBc0V4dGVybmFsQ2hpbGRSZXNvdXJjZXNJbXBs
    internal partial class SqlElasticPoolsAsExternalChildResourcesImpl
//        ExternalChildResourcesNonCachedImpl<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolImpl,Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool,Models.ElasticPoolInner,Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>
    {
         ISqlManager sqlServerManager;
        ///GENMHASH:57CEDE581734041A0D95109A124A28F8:5C3F30ED1EEA48624A21C3CDEBABCFD3
        internal IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolImpl> GetChildren(PendingOperation pendingOperation)
        {
            //$ List<SqlElasticPoolImpl> results = new ArrayList<>();
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

        ///GENMHASH:8403FBD46A688780E63ABFFDF3693E74:791A008FBFE527BE86A1C2139AFC98C5
        internal SqlElasticPoolImpl DefineIndependentElasticPool(string name)
        {
            //$ // resource group, server name and location will be set by the next method in the Fluent flow
            //$ return prepareIndependentDefine(new SqlElasticPoolImpl(name, new ElasticPoolInner(), this.sqlServerManager));
            //$ }

            return null;
        }

        ///GENMHASH:EFAB55D1221916CE29D777E26C4BAE79:3B9E74B143BC83C18EF4D753F08650E4
        internal SqlElasticPoolImpl UpdateInlineElasticPool(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineUpdate(new SqlElasticPoolImpl(name, new ElasticPoolInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineUpdate(new SqlElasticPoolImpl(name, this.Parent(), new ElasticPoolInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:4D3B34876F5167B187553A0068660FCB:EDE28CCA87ED4905C2EC678CA47E7871
        internal void RemoveInlineElasticPool(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ prepareInlineRemove(new SqlElasticPoolImpl(name, new ElasticPoolInner(), this.sqlServerManager));
            //$ } else {
            //$ prepareInlineRemove(new SqlElasticPoolImpl(name, this.Parent(), new ElasticPoolInner(), this.Parent().Manager()));
            //$ }
            //$ }

        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="parent">The parent Azure resource.</param>
        /// <param name="childResourceName">The child resource name.</param>
        ///GENMHASH:550A197FA8DA6A176A7A4272351D7AC7:CF774D1E10D643258D0C2AF646820CDC
        protected  SqlElasticPoolsAsExternalChildResourcesImpl(SqlServerImpl parent, string childResourceName)
        {
            //$ super(parent, parent.TaskGroup(), childResourceName);
            //$ this.sqlServerManager = parent.Manager();
            //$ }

        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="sqlServerManager">The manager.</param>
        /// <param name="childResourceName">The child resource name (for logging).</param>
        ///GENMHASH:2031B7EB74FD551BB49DC2D556D3F8BF:2689C49C58AAF5A4B5E25DC42936E3E0
        protected  SqlElasticPoolsAsExternalChildResourcesImpl(ISqlManager sqlServerManager, string childResourceName)
        {
            //$ super(null, null, childResourceName);
            //$ this.sqlServerManager = sqlServerManager;
            //$ }

        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="parentTaskGroup">The parent task group.</param>
        /// <param name="sqlServerManager">The manager.</param>
        /// <param name="childResourceName">The child resource name (for logging).</param>
        ///GENMHASH:EA2BCC91C00F5183C1CD85D0709FFC9F:F3CFCA970639A6F2ADD5E656FF7E5CEA
        //protected  SqlElasticPoolsAsExternalChildResourcesImpl(TaskGroup parentTaskGroup, ISqlManager sqlServerManager, string childResourceName)
        //{
        //    //$ super(null, parentTaskGroup, childResourceName);
        //    //$ this.sqlServerManager = sqlServerManager;
        //    //$ }

        //}

        ///GENMHASH:422B91B2752609CD22DD67DDEF770169:A92D215117571F4F796EE82231C77CC2
        internal SqlElasticPoolImpl DefineInlineElasticPool(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineDefine(new SqlElasticPoolImpl(name, new ElasticPoolInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineDefine(new SqlElasticPoolImpl(name, this.Parent(), new ElasticPoolInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }
    }
}