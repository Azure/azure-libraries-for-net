// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Implementation for Azure SQL subscription usage.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTdWJzY3JpcHRpb25Vc2FnZU1ldHJpY0ltcGw=
    internal partial class SqlSubscriptionUsageMetricImpl  :
        Wrapper<Models.SubscriptionUsageInner>,
        ISqlSubscriptionUsageMetric
    {
        private ISqlManager sqlServerManager;
        private string location;

        ///GENMHASH:5E680F973A4649532BBCA1631DE5A501:0E5CCC43F2104C23F62D0FD7841B83AC
        public SqlSubscriptionUsageMetricImpl(string location, SubscriptionUsageInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.sqlServerManager = sqlServerManager;
            this.location = location;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:AE6A688E48A33F4836A5CFB695421894
        public string Unit()
        {
            return this.Inner.Unit;
        }

        ///GENMHASH:19FB5490B29F08AC39628CD5F893E975:D646459DD47DA53CB973DA0F86C056D7
        public string DisplayName()
        {
            return this.Inner.DisplayName;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:9D196E486CC1E35756FD0BEDAB3F3BE4:1A97C3177E4C3DBBD400096F05CC2999
        public double Limit()
        {
            return this.Inner.Limit.GetValueOrDefault(0.0d);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:B1A42862E2B7D4E1184D71807BD0AB98
        protected async Task<Models.SubscriptionUsageInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.SubscriptionUsages
                .GetAsync(this.location, this.Name(), cancellationToken);
        }

        ///GENMHASH:4CC577A7C618816C07F6CE452B96D1E6:EEAC8410C86035AD00339FF015F50F0D
        public double CurrentValue()
        {
            return this.Inner.CurrentValue.GetValueOrDefault(0.0d);
        }

        public ISqlSubscriptionUsageMetric Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlSubscriptionUsageMetric> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));

            return this;
        }
    }
}