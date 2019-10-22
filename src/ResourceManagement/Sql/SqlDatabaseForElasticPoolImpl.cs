// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;

    /// <summary>
    /// Implementation for SqlDatabase as inline definition inside a SqlElasticPool definition.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUZvckVsYXN0aWNQb29sSW1wbA==
    internal partial class SqlDatabaseForElasticPoolImpl  :
        IWithExistingDatabaseAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>,
        IWithStorageKeyAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>,
        IWithAuthenticationAfterElasticPool<SqlElasticPoolOperations.Definition.IWithCreate>,
        IWithCreateMode<SqlElasticPoolOperations.Definition.IWithCreate>,
        IWithAttachAfterElasticPoolOptions<SqlElasticPoolOperations.Definition.IWithCreate>
    {
        private SqlDatabaseImpl sqlDatabase;
        private SqlElasticPoolImpl sqlElasticPool;

        ///GENMHASH:94B2A7575EE3CF64212EB088C1EFC127:589F854B24F8D93EDC08EE794DA63869
        internal SqlDatabaseForElasticPoolImpl(SqlElasticPoolImpl sqlElasticPool, SqlDatabaseImpl sqlDatabase)
        {
            this.sqlDatabase = sqlDatabase ?? throw new ArgumentNullException("sqlDatabase");
            this.sqlElasticPool = sqlElasticPool ?? throw new ArgumentNullException("sqlElasticPool");
            if (sqlDatabase.Inner == null)
            {
                throw new ArgumentNullException("sqlDatabase.Inner");
            }
            this.sqlDatabase.Inner.Location = this.sqlElasticPool.RegionName();
            this.sqlDatabase.Inner.ElasticPoolName = this.sqlElasticPool.Name();
            this.sqlDatabase.Inner.Edition = null;
            this.sqlDatabase.Inner.RequestedServiceObjectiveId = null;
            this.sqlDatabase.Inner.RequestedServiceObjectiveName = null;
        }

        ///GENMHASH:A521981B274EF2B3D621C0705EFAA811:F997282671508A55A64229130D4ED37B
        public SqlDatabaseForElasticPoolImpl WithMode(CreateMode createMode)
        {
            this.sqlDatabase.WithMode(createMode);
            return this;
        }

        ///GENMHASH:36003534781597C965476F5DF65AFAE0:C8055CA0EBF2D0AE0E184E82CE615E51
        public SqlDatabaseForElasticPoolImpl WithCollation(string collation)
        {
            this.sqlDatabase.WithCollation(collation);
            return this;
        }

        ///GENMHASH:E181EA037CDEB6D9DCE12CA92D1526C7:EB79EBAE731A72F314AF4FA5FF21E806
        public SqlDatabaseForElasticPoolImpl FromSample(SampleName sampleName)
        {
            this.sqlDatabase.FromSample(sampleName);
            return this;
        }

        ///GENMHASH:B132DF15A736F615C9C36B19E938DF9E:DF1BEB7ECF932C22BE460FE89D6D1002
        public SqlDatabaseForElasticPoolImpl WithStorageAccessKey(string storageAccessKey)
        {
            this.sqlDatabase.WithStorageAccessKey(storageAccessKey);
            return this;
        }

        ///GENMHASH:1A8677F2439B3D7CABE292785BD60427:D759480BEDCA49D8CB568F43A3D4F9CC
        public SqlDatabaseForElasticPoolImpl ImportFrom(string storageUri)
        {
            this.sqlDatabase.ImportFrom(storageUri);
            return this;
        }

        ///GENMHASH:7373E32C16A40BA46FE99D3C43267A6D:89D1ACFDE7236FA34D043222B3E5BF20
        public SqlDatabaseForElasticPoolImpl ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            this.sqlDatabase.ImportFrom(storageAccount, containerName, fileName);
            return this;
        }

        ///GENMHASH:F6C12109AEE137840B60E059E6708A02:4444F56500F53E36521235B479D80B41
        public SqlDatabaseForElasticPoolImpl FromRestorePoint(IRestorePoint restorePoint)
        {
            this.sqlDatabase.FromRestorePoint(restorePoint);
            return this;
        }

        ///GENMHASH:65DFD5CF3EED2BB07512CC188E7D8F8A:AFBA1099FDE55B08EE2A943E817A4A4B
        public SqlDatabaseForElasticPoolImpl FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            this.sqlDatabase.FromRestorePoint(restorePoint, restorePointDateTime);
            return this;
        }

        ///GENMHASH:B23645FC2F779DBC6F44B880C488B561:208D36D798E4BCCB374607A6BF5CA205
        public SqlDatabaseForElasticPoolImpl WithMaxSizeBytes(long maxSizeBytes)
        {
            this.sqlDatabase.WithMaxSizeBytes(maxSizeBytes);
            return this;
        }

        ///GENMHASH:FCE70A9CD34B8C168EB1F63E6F207D42:64E4E4C8DACD8B281D2C126C0D0999D6
        public SqlDatabaseForElasticPoolImpl WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.sqlDatabase.WithActiveDirectoryLoginAndPassword(administratorLogin, administratorPassword);
            return this;
        }

        ///GENMHASH:7E720FDC940A2922809B9D27EFCACBCD:8F98FC76ACFCED59AC37B7D05A7A5FF7
        public SqlDatabaseForElasticPoolImpl WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.sqlDatabase.WithSqlAdministratorLoginAndPassword(administratorLogin, administratorPassword);
            return this;
        }

        ///GENMHASH:498D3951D3EB5A31E765F1E9A24A877E:092F87DE91A75488ACA4B3A1DF242B43
        public SqlDatabaseForElasticPoolImpl WithSharedAccessKey(string sharedAccessKey)
        {
            this.sqlDatabase.WithSharedAccessKey(sharedAccessKey);
            return this;
        }

        ///GENMHASH:F8954D151717AC497C4A3B76321952A6:561AC1675488721B63D202BE7F4731A6
        public SqlDatabaseForElasticPoolImpl WithSourceDatabase(string sourceDatabaseId)
        {
            this.sqlDatabase.WithSourceDatabase(sourceDatabaseId);
            return this;
        }

        ///GENMHASH:642F972C91F9E70B14E53881C1FCA8F9:BF0818ACF7A49D86849050500C2255C6
        public SqlDatabaseForElasticPoolImpl WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            this.sqlDatabase.WithSourceDatabase(sourceDatabase.DatabaseId);
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:8C759FE8EBA306AE974D0A58B24683DD
        public SqlElasticPoolImpl Attach()
        {
            // Future reference when enabling the proper framework which will track dependencies 
            //$ this.sqlDatabase.AddParentDependency(this.sqlElasticPool);
            return this.sqlElasticPool;
        }
    }
}