// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SQL restorable dropped database interface.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxSZXN0b3JhYmxlRHJvcHBlZERhdGFiYXNlSW1wbA==
    internal partial class SqlRestorableDroppedDatabaseImpl  :
        Wrapper<Models.RestorableDroppedDatabaseInner>,
        ISqlRestorableDroppedDatabase
    {
        private string sqlServerName;
        private string resourceGroupName;
        private ISqlManager sqlServerManager;

        ///GENMHASH:AAECD20916C2D9BB8C8EC283BBA60768:1F024F79B04A8465908D0C62DB75970D
        public SqlRestorableDroppedDatabaseImpl(string resourceGroupName, string sqlServerName, RestorableDroppedDatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:1E25A0D6237AD5417B6C053B9EEE9DD8
        protected async Task<Models.RestorableDroppedDatabaseInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.RestorableDroppedDatabases
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Inner.Id);
        }

        public ISqlRestorableDroppedDatabase Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlRestorableDroppedDatabase> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            return this.Inner.ElasticPoolName;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:44F5F71CD9996FE437F3FF8F3E8E46F9
        public string DatabaseName()
        {
            return this.Inner.DatabaseName;
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public string Edition()
        {
            return this.Inner.Edition;
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime? CreationDate()
        {
            return this.Inner.CreationDate;
        }

        ///GENMHASH:411E9B7C553E0F8FE64EB33DF4872E6A:A0F10EC124D07E925E3BE6285203F7E0
        public string ServiceLevelObjective()
        {
            return this.Inner.ServiceLevelObjective;
        }

        ///GENMHASH:9A674D13E55AB85440A1EDD114D9C459:88EC8D94CE3C5E926469008336861A16
        public DateTime? DeletionDate()
        {
            return this.Inner.DeletionDate;
        }

        ///GENMHASH:A26C8D278B6519B28BA17D3966024017:73DAB7C56068D9C6816A9533D7313F6F
        public string MaxSizeBytes()
        {
            return this.Inner.MaxSizeBytes;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location);
        }

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime? EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate;
        }
    }
}