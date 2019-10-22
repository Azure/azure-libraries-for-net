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
    using Microsoft.Rest.Azure;
    using System.Linq;

    /// <summary>
    /// Implementation for RecommendedElasticPool and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZWNvbW1lbmRlZEVsYXN0aWNQb29sSW1wbA==
    internal partial class RecommendedElasticPoolImpl  :
        Wrapper<Models.RecommendedElasticPoolInner>,
        IRecommendedElasticPool
    {
        private SqlServerImpl sqlServer;
        private List<ISqlDatabase> databases;

        ///GENMHASH:02ED968F148B39A9E0BC7F3E427EC0AA:7EA48F168814C86A7C06DEF2A48D1466
        public RecommendedElasticPoolImpl(RecommendedElasticPoolInner innerObject, SqlServerImpl sqlServer) : base(innerObject)
        {
            this.sqlServer = sqlServer;
        }

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:58F5D293EFF1B12DD86B185427748416
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Databases()
        {
            if (this.databases == null)
            {
                this.databases = new List<ISqlDatabase>();
                if (this.Inner.Databases != null)
                {
                    foreach (var databaseInner in this.Inner.Databases)
                    {
                        databases.Add(new SqlDatabaseImpl(databaseInner.Name, this.sqlServer, databaseInner, this.Manager()));
                    }
                }
            }

            return this.databases.AsReadOnly();
        }

        ///GENMHASH:F018FD6E531156DFCBAA9FAE7F4D8519:F548C4892951BC9F8563B941B288836A
        public double DatabaseDtuMax()
        {
            return this.Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:519395817AF6BD69D3CFD68045AED5AE
        public string ResourceGroupName()
        {
            return this.sqlServer.ResourceGroupName;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:9C8124948ED1843486307941877C40F4
        public ISqlManager Manager()
        {
            return this.sqlServer.Manager;
        }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:945958DE33096D51BB9DD38A7F3CDAD0
        public double Dtu()
        {
            return this.Inner.Dtu ?? 0.0d;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:3520E9B0814A37469465F84246F9FB4C
        public string SqlServerName()
        {
            return this.sqlServer.Name;
        }

        ///GENMHASH:8F7792CF2DCF26479B67E8050646FE84:7C6E87BC11D3AC90258D9ACB04506338
        public double MaxObservedDtu()
        {
            return this.Inner.MaxObservedDtu.GetValueOrDefault();
        }

        ///GENMHASH:CD775E31F43CBA6304D6EEA9E01682A1:1CA7A1C3B108B52C1585A38D9F1E946B
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases()
        {
            return Extensions.Synchronize(() => this.ListDatabasesAsync());
        }

        ///GENMHASH:0A59E82904CE8BB24F650E93009FF62F:554D1CBF22D4FFEB3B544B44B1374357
        public double MaxObservedStorageMB()
        {
            return this.Inner.MaxObservedStorageMB.GetValueOrDefault();
        }

        ///GENMHASH:70FFECB4FEA7D59DD4971789709E0B1F:6E834E8599DBDC4A3B884BDCE4188944
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> GetDatabaseAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var innerDatabase = await this.Manager().Inner.Databases.GetByRecommendedElasticPoolAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name(), databaseName, cancellationToken);
                return innerDatabase != null ? new SqlDatabaseImpl(innerDatabase.Name, this.sqlServer, innerDatabase, this.Manager()) : null;
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex)
            {
                if(ex.InnerExceptions != null)
                {
                    var cloudEx = (CloudException) ex.InnerExceptions.FirstOrDefault(e => e is CloudException);
                    if(cloudEx != null &&
                       cloudEx.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }

                throw ex;
            }
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:6B05A1FE3956A89247E0497F730E7CBB
        protected async Task<Models.RecommendedElasticPoolInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager().Inner.RecommendedElasticPools.GetAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name(), cancellationToken);
        }

        ///GENMHASH:17E6AB9D56173E1A13C2EABA7B6A670A:F89FC7AEC255C2D69206A3A246882AB3
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlDatabase> databases = new List<ISqlDatabase>();
            var innerDatabases = await this.Manager().Inner.Databases.ListByRecommendedElasticPoolAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name(),  cancellationToken);
            if (innerDatabases != null)
            {
                foreach (var innerDatabase in innerDatabases)
                {
                    databases.Add(new SqlDatabaseImpl(innerDatabase.Name, this.sqlServer, innerDatabase, this.Manager()));
                }
            }

            return databases.AsReadOnly();
        }

        ///GENMHASH:C4B4BF3321B70686AA3906F2295146C1:C8E7AAD6A3E0CD79087919190171E915
        public DateTime? ObservationPeriodEnd()
        {
            return this.Inner.ObservationPeriodEnd;
        }

        ///GENMHASH:65131A7039722B315DD5137C9DE38A3F:7157334C1BFA649E27CA8B6E9688E986
        public ElasticPoolEdition DatabaseEdition()
        {
            return this.Inner.DatabaseEdition;
        }

        ///GENMHASH:5AD4BED8CF2346B6D40F11D14D91854E:DF850590D9C93BFBF3C7222561137EEB
        public double DatabaseDtuMin()
        {
            return this.Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:1C25D7B8D9084176A24655682A78634D:6D26D55E537AFC21CD6BC42B202BA64B
        public ISqlDatabase GetDatabase(string databaseName)
        {
            return Extensions.Synchronize(() => this.GetDatabaseAsync(databaseName));
        }

        ///GENMHASH:77909FCEE2BCE7A1585A5D65D695B384:ED4365075C9015DF63B931624C17C949
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric> ListMetrics()
        {
            List<IRecommendedElasticPoolMetric> metrics = new List<IRecommendedElasticPoolMetric>();
            var innerMetrics = Extensions.Synchronize(() => this.Manager().Inner.RecommendedElasticPools.ListMetricsAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name()));
            if (innerMetrics != null)
            {
                foreach (var innerMetric in innerMetrics)
                {
                    metrics.Add(new RecommendedElasticPoolMetricImpl(innerMetric));
                }
            }

            return metrics.AsReadOnly();
        }

        ///GENMHASH:E1D13665116B8ECA351FF7B3C332BAF4:132F6DAA63B96E3D5A5059C74C281394
        public DateTime? ObservationPeriodStart()
        {
            return this.Inner.ObservationPeriodStart;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:FB97B6A01BB44DE1679EAB5070CAB853:22EC24984E8319C6ED4EE03CBB19BAE4
        public double StorageMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        public IRecommendedElasticPool Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<IRecommendedElasticPool> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));

            return this;
        }
    }
}