// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    /// <summary>
    /// Implementation for Azure SQL server automatic tuning.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJBdXRvbWF0aWNUdW5pbmdJbXBs
    internal partial class SqlServerAutomaticTuningImpl  :
        Wrapper<Models.ServerAutomaticTuningInner>,
        ISqlServerAutomaticTuning,
        IUpdate
    {
        protected string key;
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;

        ///GENMHASH:BE1AB1D88A6A19EC0BF0334CC3B6BCC1:63EB623539C702D5D92F22479190251D
        internal SqlServerAutomaticTuningImpl(SqlServerImpl server, ServerAutomaticTuningInner innerObject)
            : base(innerObject)
        {
            this.sqlServerManager = server.Manager;
            this.resourceGroupName = server.ResourceGroupName;
            this.sqlServerName = server.Name;
            this.key = Guid.NewGuid().ToString();
        }

        ///GENMHASH:670A73E4D654BF4BE6FB621CD7937552:54BF8FD63F8AB586307D57ACE1B3D26B
        internal SqlServerAutomaticTuningImpl(string resourceGroupName, string sqlServerName, ServerAutomaticTuningInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.key = Guid.NewGuid().ToString();
        }


        ///GENMHASH:17950B8F2EC46B114539E23F9F4D3EA2:EBF69F3A6BD7C5BE989345C27B59C5FE
        public Microsoft.Azure.Management.Sql.Fluent.Models.AutomaticTuningServerMode DesiredState()
        {
            return Inner.DesiredState.GetValueOrDefault();
        }

        ///GENMHASH:93F5525F475C77754B229151C3005F4B:F84ED1C7DC13C78E0925116541403988
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverAutomaticTuningInner = await this.sqlServerManager.Inner.ServerAutomaticTuning
                .UpdateAsync(this.resourceGroupName, this.sqlServerName, this.Inner, cancellationToken);
            this.SetInner(serverAutomaticTuningInner);
            return this;
        }

        ///GENMHASH:7A26D184347EA91F532899FC93DA3E8B:4DCBBC7A68AC87C60BAB31C86F86FB9B
        public ISqlServerAutomaticTuning Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        ///GENMHASH:7ADEC35D0E44D657A6605A352994666D:4786B5C8B0F593EA5A123F54777D6A26
        public SqlServerAutomaticTuningImpl WithAutomaticTuningMode(Models.AutomaticTuningServerMode desiredState)
        {
            this.Inner.DesiredState = desiredState;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:40A980295F5EA8FF8304DA8C06E899BF
        public IUpdate Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:46FCAAD720A5853AB2F1C89F7C97E965:E67C7E62D91ADAFD5268264E7A04F0F3
        public AutomaticTuningServerMode ActualState()
        {
            return Inner.ActualState.GetValueOrDefault();
        }

        ///GENMHASH:86AFBCBC33BD6FBDB22DED1DB6D3E547:148B6255C8A72414E287E21584076723
        public IReadOnlyDictionary<string,Models.AutomaticTuningServerOptions> TuningOptions()
        {
            Dictionary<string, Models.AutomaticTuningServerOptions> tuningOptions = this.Inner.Options != null ? new Dictionary<string, AutomaticTuningServerOptions>(this.Inner.Options) : new Dictionary<string, AutomaticTuningServerOptions>();
            return tuningOptions;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:9790D012FA64E47343F12DB13F0AA212
        protected async Task<Models.ServerAutomaticTuningInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.ServerAutomaticTuning
                .GetAsync(this.resourceGroupName, this.sqlServerName, cancellationToken);
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:6653B80313D99B59B1A1B07C544D1CB7
        public string Key()
        {
            return this.key;
        }

        ///GENMHASH:83E91F2084686A41CC7FEC4FD3AABFFB:7CD5D685622F1E16B5C558CB56626C01
        public SqlServerAutomaticTuningImpl WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState)
        {
            if (this.Inner.Options == null) {
                this.Inner.Options = new Dictionary<string, AutomaticTuningServerOptions>();
            }
            AutomaticTuningServerOptions item = this.Inner.Options[tuningOptionName];
            if (item == null)
            {
                item = new AutomaticTuningServerOptions();
            }
            item.DesiredState = desiredState;
            this.Inner.Options[tuningOptionName] = item;
            return this;
        }

        ///GENMHASH:956E7E258ED13C6526B661525EF63263:D8912A8B3BCC1193AE7D0262B922E2BB
        public SqlServerAutomaticTuningImpl WithAutomaticTuningOptions(IDictionary<string,Models.AutomaticTuningOptionModeDesired> tuningOptions)
        {
            if (tuningOptions != null)
            {
                this.Inner.Options = new Dictionary<string, AutomaticTuningServerOptions>();
                foreach(var optionItem in tuningOptions)
                {
                    var item = new AutomaticTuningServerOptions();
                    item.DesiredState = optionItem.Value;
                    this.Inner.Options[optionItem.Key] = item;
                }
            }
            else
            {
                this.Inner.Options = null;
            }
            return this;
        }

        public ISqlServerAutomaticTuning Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlServerAutomaticTuning> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }
    }
}