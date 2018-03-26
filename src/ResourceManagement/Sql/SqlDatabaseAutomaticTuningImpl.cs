// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for Azure SQL Database automatic tuning.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUF1dG9tYXRpY1R1bmluZ0ltcGw=
    internal partial class SqlDatabaseAutomaticTuningImpl  :
        Wrapper<Models.DatabaseAutomaticTuningInner>,
        ISqlDatabaseAutomaticTuning,
        IUpdate
    {
        protected string key;
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string sqlDatabaseName;
        private Dictionary<string,Models.AutomaticTuningOptions> automaticTuningOptionsMap;

        ///GENMHASH:0B123513DA66B23285D7B0CA6EE63B8D:7ADD22B33B14B9D9F2AB7F5856755122
        internal SqlDatabaseAutomaticTuningImpl(SqlDatabaseImpl database, DatabaseAutomaticTuningInner innerObject)
            : base(innerObject)
        {
            this.sqlServerManager = database.sqlServerManager;
            this.resourceGroupName = database.resourceGroupName;
            this.sqlServerName = database.sqlServerName;
            this.sqlDatabaseName = database.Name();
            this.key = Guid.NewGuid().ToString();
            this.automaticTuningOptionsMap = new Dictionary<string, AutomaticTuningOptions>();
        }

        ///GENMHASH:7DFD4E2C4BFE1C1A223F1E9652CEA12E:095451E62832B6CE321960A429995E7F
        internal SqlDatabaseAutomaticTuningImpl(string resourceGroupName, string sqlServerName, string sqlDatabaseName, DatabaseAutomaticTuningInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlDatabaseName = sqlDatabaseName;
            this.key = Guid.NewGuid().ToString();
            this.automaticTuningOptionsMap = new Dictionary<string, AutomaticTuningOptions>();
        }

        ///GENMHASH:17950B8F2EC46B114539E23F9F4D3EA2:EBF69F3A6BD7C5BE989345C27B59C5FE
        public AutomaticTuningMode DesiredState()
        {
            return this.Inner.DesiredState.GetValueOrDefault();
        }

        ///GENMHASH:93F5525F475C77754B229151C3005F4B:FE981C7CC77129BC45DD1FFCFCD2402F
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Inner.Options = this.automaticTuningOptionsMap.Count == 0 ? null : this.automaticTuningOptionsMap;
            var databaseAutomaticTuningInner = await this.sqlServerManager.Inner.DatabaseAutomaticTuning
                .UpdateAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Inner, cancellationToken);
            this.SetInner(databaseAutomaticTuningInner);
            this.automaticTuningOptionsMap = (databaseAutomaticTuningInner != null && databaseAutomaticTuningInner.Options != null) ? new Dictionary<string, AutomaticTuningOptions>(databaseAutomaticTuningInner.Options) : new Dictionary<string, AutomaticTuningOptions>();
            return this;
        }

        ///GENMHASH:7A26D184347EA91F532899FC93DA3E8B:4DCBBC7A68AC87C60BAB31C86F86FB9B
        public ISqlDatabaseAutomaticTuning Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        ///GENMHASH:7F33E339721729D377FAA2C158013B67:4786B5C8B0F593EA5A123F54777D6A26
        public SqlDatabaseAutomaticTuningImpl WithAutomaticTuningMode(AutomaticTuningMode desiredState)
        {
            this.Inner.DesiredState = desiredState;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:40A980295F5EA8FF8304DA8C06E899BF
        public SqlDatabaseAutomaticTuningImpl Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:46FCAAD720A5853AB2F1C89F7C97E965:E67C7E62D91ADAFD5268264E7A04F0F3
        public AutomaticTuningMode ActualState()
        {
            return this.Inner.ActualState.GetValueOrDefault();
        }

        ///GENMHASH:86AFBCBC33BD6FBDB22DED1DB6D3E547:ADFE9FCB8F4C9777490569C237BE3AF2
        public IReadOnlyDictionary<string,Models.AutomaticTuningOptions> TuningOptions()
        {
            return new Dictionary<string, Models.AutomaticTuningOptions>(this.Inner.Options);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:43F027909441F9AB58CFB6522AD56111
        protected async Task<Models.DatabaseAutomaticTuningInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.DatabaseAutomaticTuning
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, cancellationToken);
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:6653B80313D99B59B1A1B07C544D1CB7
        public string Key()
        {
            return this.key;
        }

        ///GENMHASH:83E91F2084686A41CC7FEC4FD3AABFFB:620CE1631318B71036774A9D6D922199
        public SqlDatabaseAutomaticTuningImpl WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState)
        {
            if (this.automaticTuningOptionsMap == null) {
                this.automaticTuningOptionsMap = new Dictionary<string, AutomaticTuningOptions>();
            }
            var item = new AutomaticTuningOptions();
            item.DesiredState = desiredState;
            this.automaticTuningOptionsMap[tuningOptionName] = item;
            return this;
        }

        ///GENMHASH:956E7E258ED13C6526B661525EF63263:D8912A8B3BCC1193AE7D0262B922E2BB
        public SqlDatabaseAutomaticTuningImpl WithAutomaticTuningOptions(IDictionary<string,Models.AutomaticTuningOptionModeDesired> tuningOptions)
        {
            this.automaticTuningOptionsMap = new Dictionary<string, AutomaticTuningOptions>();
            if (tuningOptions != null) {
                foreach (var optionItem in tuningOptions)
                {
                    var item = new AutomaticTuningOptions();
                    item.DesiredState = optionItem.Value;
                    this.automaticTuningOptionsMap[optionItem.Key] = item;
                }
            }
            return this;
        }

        public ISqlDatabaseAutomaticTuning Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlDatabaseAutomaticTuning> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            this.automaticTuningOptionsMap = (this.Inner != null && this.Inner.Options != null) ? new Dictionary<string, AutomaticTuningOptions>(this.Inner.Options) : new Dictionary<string, AutomaticTuningOptions>();
            return this;
        }
    }
}