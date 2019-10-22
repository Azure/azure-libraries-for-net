// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.SqlDatabaseImportRequestDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;

    /// <summary>
    /// Implementation for SqlDatabaseImportRequest.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUltcG9ydFJlcXVlc3RJbXBs
    internal partial class SqlDatabaseImportRequestImpl :
        IndexableWrapper<ImportExtensionRequest>,
        IExecutable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse>,
        ISqlDatabaseImportRequest,
        ISqlDatabaseImportRequestDefinition
    {
        private SqlDatabaseImpl sqlDatabase;
        private ISqlManager sqlServerManager;
        private Microsoft.Azure.Management.Storage.Fluent.IStorageAccount storageAccount = null;
        private string containerName = "";
        private string fileName = "";

        ///GENMHASH:81DF4EF59DD03729DDA4493E19748A04:9FF1B194E9F212F1CE07036F74C545E4
        internal SqlDatabaseImportRequestImpl(SqlDatabaseImpl sqlDatabase, ISqlManager sqlServerManager)
            : base(new ImportExtensionRequest())
        {
            this.sqlDatabase = sqlDatabase;
            this.sqlServerManager = sqlServerManager;
        }

        public ISqlDatabaseImportExportResponse Execute()
        {
            return Extensions.Synchronize(() => this.ExecuteAsync());
        }

        public async Task<ISqlDatabaseImportExportResponse> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await ExecuteWorkAsync(cancellationToken);
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:CF47C17A015B0CAC221FFD519EB508DD
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse> ExecuteWorkAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.storageAccount != null)
            {
                var storageKeys = (await storageAccount.GetKeysAsync(cancellationToken));
                if (storageKeys == null || storageKeys.Count == 0)
                {
                    throw new Exception("Failed to retrieve Storage Account Keys");
                }
                var storageAccountKey = storageKeys[0].Value;
                this.Inner.StorageUri = $"{this.storageAccount.EndPoints.Primary.Blob}{this.containerName}/{this.fileName}";
                this.Inner.StorageKeyType = StorageKeyType.StorageAccessKey;
                this.Inner.StorageKey = storageAccountKey;
            }

            var importExportResponseInner = await this.sqlServerManager.Inner.Databases
                .CreateImportOperationAsync(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), this.Inner, cancellationToken);
            return new SqlDatabaseImportExportResponseImpl(importExportResponseInner);
        }

        ///GENMHASH:1A8677F2439B3D7CABE292785BD60427:1AFE4E70953BC0B4E162CBBF340F42AB
        public SqlDatabaseImportRequestImpl ImportFrom(string storageUri)
        {
            this.Inner.StorageUri = storageUri ?? throw new System.ArgumentNullException("storageUri");
            return this;
        }

        ///GENMHASH:7373E32C16A40BA46FE99D3C43267A6D:E3742E789D6A72F5DCDB8684A8617DB4
        public SqlDatabaseImportRequestImpl ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            this.storageAccount = storageAccount ?? throw new System.ArgumentNullException("storageAccount");
            this.containerName = containerName ?? throw new System.ArgumentNullException("containerName");
            this.fileName = fileName ?? throw new System.ArgumentNullException("fileName");
            return this;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:9790D012FA64E47343F12DB13F0AA212
        public ISqlDatabase Parent()
        {
            return this.sqlDatabase;
        }

        ///GENMHASH:B132DF15A736F615C9C36B19E938DF9E:004F7A7338276BA489053412C4D892AF
        public SqlDatabaseImportRequestImpl WithStorageAccessKey(string storageAccessKey)
        {
            this.Inner.StorageKeyType = StorageKeyType.StorageAccessKey;
            this.Inner.StorageKey = storageAccessKey;
            return this;
        }

        ///GENMHASH:FCE70A9CD34B8C168EB1F63E6F207D42:726635D670117CC0D040C28A613AE28F
        public SqlDatabaseImportRequestImpl WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AuthenticationType = AuthenticationType.ADPassword;
            return this.WithLoginAndPassword(administratorLogin, administratorPassword);
        }

        ///GENMHASH:653DFCECD1726D45C960AFE1BF555853:3DE854B28B881C61E82F0AF94357DD96
        internal SqlDatabaseImportRequestImpl WithLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AdministratorLogin = administratorLogin;
            this.Inner.AdministratorLoginPassword = administratorPassword;
            return this;
        }

        ///GENMHASH:7E720FDC940A2922809B9D27EFCACBCD:7BB0FC51A283D3782A1A79D2457C3D7D
        public SqlDatabaseImportRequestImpl WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AuthenticationType = AuthenticationType.SQL;
            return this.WithLoginAndPassword(administratorLogin, administratorPassword);
        }

        ///GENMHASH:498D3951D3EB5A31E765F1E9A24A877E:EC10E45384DDEE353B45A8A0AF1AF89C
        public SqlDatabaseImportRequestImpl WithSharedAccessKey(string sharedAccessKey)
        {
            this.Inner.StorageKeyType = StorageKeyType.SharedAccessKey;
            this.Inner.StorageKey = sharedAccessKey;
            return this;
        }
    }
}