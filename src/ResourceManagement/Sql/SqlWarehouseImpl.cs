// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for SqlWarehouse and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxXYXJlaG91c2VJbXBs
    internal partial class SqlWarehouseImpl  :
        SqlDatabaseImpl,
        ISqlWarehouse
    {
        ///GENMHASH:01F4015FD664AFA09FE455D9F817F348:C99C685A9D673A92118B74962283411C
        public SqlWarehouseImpl(string name, SqlServerImpl parent, DatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(name, parent, innerObject, sqlServerManager)
        {
        }

        ///GENMHASH:5E107B23DE34DEBD4ED372100F2024F8:0AF0D08DA20B3ABFC0CC6C3AE431D719
        public SqlWarehouseImpl(string resourceGroupName, string sqlServerName, string sqlServerLocation, string name, DatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(resourceGroupName, sqlServerName, sqlServerLocation, name, innerObject, sqlServerManager)
        {
        }

        ///GENMHASH:9049C1BFF1DAE3DE7A8FCE7AF39E0A96:E38FE7F373150C35079ED487720DEC77
        public async Task PauseDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.Databases
                .PauseAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name());
        }

        ///GENMHASH:638E920B34EB7CDD894A8A261D1A3364:6F67F317CAFAD597F0D9D6CAB11125C7
        public void ResumeDataWarehouse()
        {
            Extensions.Synchronize(() => this.ResumeDataWarehouseAsync());
        }

        ///GENMHASH:CC45B434E5AD72F7D764B575FE4DBBB0:1B65D1021F1AAECFB9DA5EB69D014CF5
        public void PauseDataWarehouse()
        {
            Extensions.Synchronize(() => this.PauseDataWarehouseAsync());
        }

        ///GENMHASH:D67B352DD87A53FBB89CC12AEDBE047E:AD8496BEA3D8F952081EB2FBF29EF39D
        public async Task ResumeDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.Databases
                .ResumeAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name(), cancellationToken);
        }
    }
}