// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Represents a SQL Firewall rules collection associated with an Azure SQL server.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGaXJld2FsbFJ1bGVzQXNFeHRlcm5hbENoaWxkUmVzb3VyY2VzSW1wbA==
    internal partial class SqlFirewallRulesAsExternalChildResourcesImpl 
        //ExternalChildResourcesNonCached<
        //    Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleImpl,
        //    Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule,
        //    Microsoft.Azure.Management.Sql.Fluent.ISqlServer,
        //    Models.FirewallRuleInner,Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl>
    {
         ISqlManager sqlServerManager;
        ///GENMHASH:518F7642AE4D538C71F91882E33728D8:69C56851D22BC12B8EBEA2C378BAAF5C
        internal SqlFirewallRuleImpl DefineInlineFirewallRule(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineDefine(new SqlFirewallRuleImpl(name, new FirewallRuleInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineDefine(new SqlFirewallRuleImpl(name, this.Parent(), new FirewallRuleInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:858D9D5CE6C058FE1B7C191098429D8F:DEE9FFE79F89FEB8B1EFCAD50C2FD6E1
        internal SqlFirewallRuleImpl DefineIndependentFirewallRule(string name)
        {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareIndependentDefine(new SqlFirewallRuleImpl(name, new FirewallRuleInner(), this.sqlServerManager));
            //$ }

            return null;
        }

        /// <summary>
        /// Creates a new ExternalNonInlineChildResourcesImpl.
        /// </summary>
        /// <param name="parent">The parent Azure resource.</param>
        /// <param name="childResourceName">The child resource name.</param>
        ///GENMHASH:FF7E2661884A4B982EA72EDF36BE4ECF:CF774D1E10D643258D0C2AF646820CDC
        internal SqlFirewallRulesAsExternalChildResourcesImpl(SqlServerImpl parent, string childResourceName)
 //           : base(parent, childResourceName)
        {
            this.sqlServerManager = parent.Manager;
        }

        /// <summary>
        /// Creates a new ExternalChildResourcesNonCachedImpl.
        /// </summary>
        /// <param name="sqlServerManager">The manager.</param>
        /// <param name="childResourceName">The child resource name (for logging).</param>
        ///GENMHASH:4B5A4F5C075204E0902C9C9833D1BFB1:2689C49C58AAF5A4B5E25DC42936E3E0
        internal SqlFirewallRulesAsExternalChildResourcesImpl(ISqlManager sqlServerManager, string childResourceName)
//            : base(null, childResourceName)
        {
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:40C4820016A0121BB3B9B1BB36486C50:7027088E6B6C059485866FD9813F7C65
        internal SqlFirewallRuleImpl UpdateInlineFirewallRule(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ return prepareInlineUpdate(new SqlFirewallRuleImpl(name, new FirewallRuleInner(), this.sqlServerManager));
            //$ } else {
            //$ return prepareInlineUpdate(new SqlFirewallRuleImpl(name, this.Parent(), new FirewallRuleInner(), this.Parent().Manager()));
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:B925661C270726CC447297AD5B7DC228:9F65CD8DD068F5250802C78F55A09702
        internal void RemoveInlineFirewallRule(string name)
        {
            //$ if (this.Parent() == null) {
            //$ // resource group and server name will be set by the next method in the Fluent flow
            //$ prepareInlineRemove(new SqlFirewallRuleImpl(name, new FirewallRuleInner(), this.sqlServerManager));
            //$ } else {
            //$ prepareInlineRemove(new SqlFirewallRuleImpl(name, this.Parent(), new FirewallRuleInner(), this.Parent().Manager()));
            //$ }
            //$ }

        }
    }
}