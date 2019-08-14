// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.SqlElasticPoolDefinition;
    using System;

    /// <summary>
    /// Implementation for SqlElasticPool as inline definition inside a SqlDatabase definition.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbEZvckRhdGFiYXNlSW1wbA==
    internal partial class SqlElasticPoolForDatabaseImpl  :
        ISqlElasticPoolDefinition<SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool>
    {
        private SqlElasticPoolImpl sqlElasticPool;
        private SqlDatabaseImpl sqlDatabase;

        ///GENMHASH:99B56B1A2FDEAC4D03C59DAC1D782ED1:E4E38E8B6802746236C5E7DCE3C6C88C
        internal SqlElasticPoolForDatabaseImpl(SqlDatabaseImpl sqlDatabase, SqlElasticPoolImpl sqlElasticPool)
        {
            this.sqlDatabase = sqlDatabase ?? throw new ArgumentNullException("sqlDatabase");
            this.sqlElasticPool = sqlElasticPool ?? throw new ArgumentNullException("sqlElasticPool");
        }

        ///GENMHASH:97CD39A6DC806326650B01A4E0BE675A:31976AF6A40625481B27FC7645C84B43
        public SqlElasticPoolForDatabaseImpl WithBasicPool()
        {
            this.sqlElasticPool.WithBasicPool();
            return this;
        }

        ///GENMHASH:F69F9A86EEB56FF0B2A2B78C4CF114C2:24F85645A6F20895E50110549FF36A3F
        public SqlElasticPoolForDatabaseImpl WithStandardPool()
        {
            this.sqlElasticPool.WithStandardPool();
            return this;
        }

        ///GENMHASH:CE6E5E981686AB8CE8A830CF9AB6387F:77BD6CF7DC386B312A0C3A51EDE36A6B
        public SqlElasticPoolForDatabaseImpl WithEdition(ElasticPoolEdition edition)
        {
            this.sqlElasticPool.WithEdition(edition);
            return this;
        }

        ///GENMHASH:58F0F991960D193A83633DD3EFF3BBA9:6D79CB402B4C6DB9E80B65824C73DC46
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMin(eDTU);
            return this;
        }

        ///GENMHASH:238D14C741300C8F3F85D3693AF9E389:6D79CB402B4C6DB9E80B65824C73DC46
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMin(eDTU);
            return this;
        }

        ///GENMHASH:CD960E929365F3472B6056B6E4728E44:6D79CB402B4C6DB9E80B65824C73DC46
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMin(eDTU);
            return this;
        }

        ///GENMHASH:52F9B4107BF3F85A991B429161CF5EB8:60C2CA6442C7ED25A1FF20E14B88656A
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMin(int databaseDtuMin)
        {
            this.sqlElasticPool.WithDatabaseDtuMin(databaseDtuMin);
            return this;
        }

        ///GENMHASH:016100CEB0E9F110178E8596490E49A8:F8030E58EF06AF5471A10FBD8F1BE0A4
        public SqlElasticPoolForDatabaseImpl WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            this.sqlElasticPool.WithReservedDtu(eDTU);
            return this;
        }

        ///GENMHASH:287E5247F6F2638E06FDC66A496B867D:F8030E58EF06AF5471A10FBD8F1BE0A4
        public SqlElasticPoolForDatabaseImpl WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            this.sqlElasticPool.WithReservedDtu(eDTU);
            return this;
        }

        ///GENMHASH:A7AFFC0C08A06739A4DEF4B29E68ED36:F8030E58EF06AF5471A10FBD8F1BE0A4
        public SqlElasticPoolForDatabaseImpl WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            this.sqlElasticPool.WithReservedDtu(eDTU);
            return this;
        }

        ///GENMHASH:AB6797A1C273AA0DDF55180EC1D670F8:183A770B0C470375AB1D001B20F7E714
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMax(eDTU);
            return this;
        }

        ///GENMHASH:53CB11FAC9F1E9F1BF7F513315192637:183A770B0C470375AB1D001B20F7E714
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMax(eDTU);
            return this;
        }

        ///GENMHASH:873CBDCF636F4F9AE569C54D834964DD:183A770B0C470375AB1D001B20F7E714
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            this.sqlElasticPool.WithDatabaseDtuMax(eDTU);
            return this;
        }

        ///GENMHASH:BE89876FF9AA93145223609370F06FD8:51E7EDB7167B3BE36AA3C4825825057E
        public SqlElasticPoolForDatabaseImpl WithDatabaseDtuMax(int databaseDtuMax)
        {
            this.sqlElasticPool.WithDatabaseDtuMax(databaseDtuMax);
            return this;
        }

        ///GENMHASH:29AF482561F540D08CF2A859C007C920:946AD2EDB7DE53555EA334F49E3B6878
        public SqlElasticPoolForDatabaseImpl WithPremiumPool()
        {
            this.sqlElasticPool.WithPremiumPool();
            return this;
        }

        ///GENMHASH:D7704568C142F68F7A15BF85145157D7:35DD13CDC2048067F8F2D1FE4E130923
        public SqlElasticPoolForDatabaseImpl WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            this.sqlElasticPool.WithStorageCapacity(storageCapacity);
            return this;
        }

        ///GENMHASH:CB542E2EF61540C0531F6875AE9754E0:35DD13CDC2048067F8F2D1FE4E130923
        public SqlElasticPoolForDatabaseImpl WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            this.sqlElasticPool.WithStorageCapacity(storageCapacity);
            return this;
        }

        ///GENMHASH:5219D4DB320BF9F9DA49E9B44C0088EE:A8590C58E23AF43B2A26AC86B2E519F9
        public SqlElasticPoolForDatabaseImpl WithStorageCapacity(int storageMB)
        {
            this.sqlElasticPool.WithStorageCapacity(storageMB);
            return this;
        }

        ///GENMHASH:E293D352B4C8ABEA82BF928E8B1ADC36:8022A90498B1C5C0A6C5D104A83C230F
        public SqlElasticPoolForDatabaseImpl WithDtu(int dtu)
        {
            this.sqlElasticPool.WithDtu(dtu);
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:30C0011CBDCA9BC2141BD6CFEA069B06
        public SqlDatabaseImpl Attach()
        {
            // Future reference when enabling the proper framework which will track dependencies 
            // this.sqlDatabase.AddParentDependency(this.sqlElasticPool);
            return this.sqlDatabase;
        }
    }
}