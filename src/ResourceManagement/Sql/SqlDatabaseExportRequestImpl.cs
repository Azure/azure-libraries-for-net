// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.SqlDatabaseExportRequestDefinition;
    using Microsoft.WindowsAzure.Storage;

    /// <summary>
    /// Implementation for SqlDatabaseExportRequest.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUV4cG9ydFJlcXVlc3RJbXBs
    internal partial class SqlDatabaseExportRequestImpl :
        IndexableWrapper<ExportRequest>,
        IExecutable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse>,
        ISqlDatabaseExportRequest,
        ISqlDatabaseExportRequestDefinition
    {
        private SqlDatabaseImpl sqlDatabase;
        private ISqlManager sqlServerManager;
        private ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable = null;
        private Microsoft.Azure.Management.Storage.Fluent.IStorageAccount storageAccount = null;
        private string containerName = "";
        private string fileName = "";

        ///GENMHASH:4C56A88569DD86D7F8E3FD98F7FACA96:D9D508B5166E6117F73E0D66BB8CCC59
        public SqlDatabaseExportRequestImpl(SqlDatabaseImpl sqlDatabase, ISqlManager sqlServerManager)
            : base(new ExportRequest())
        {
            this.sqlDatabase = sqlDatabase;
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:FE111B80F10F1D62FBC7A570DF172CC4
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse> ExecuteWorkAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.storageAccountCreatable != null)
            {
                this.storageAccount = await storageAccountCreatable.CreateAsync(cancellationToken) ?? throw new Exception("Failed to create Storage Account");
            }
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
                
                // Create the storage account container if one does not exist
                var sas = $"DefaultEndpointsProtocol=https;AccountName={storageAccount.Name};AccountKey={storageAccountKey};EndpointSuffix=core.Windows.Net";
                var cloudBlobClient = CloudStorageAccount.Parse(sas).CreateCloudBlobClient();
                await cloudBlobClient.GetContainerReference(containerName).CreateIfNotExistsAsync();
            }

            var importExportResponseInner = await this.sqlServerManager.Inner.Databases
                .ExportAsync(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), this.Inner, cancellationToken);
            return new SqlDatabaseImportExportResponseImpl(importExportResponseInner);
        }

        public ISqlDatabaseImportExportResponse Execute()
        {
            return Extensions.Synchronize(() => this.ExecuteAsync());
        }

        public async Task<ISqlDatabaseImportExportResponse> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await ExecuteWorkAsync(cancellationToken);
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:3897FDE8C1294DAC7AA89FCDD3A70F76
        public ISqlDatabase Parent()
        {
            return this.sqlDatabase;
        }

        ///GENMHASH:B132DF15A736F615C9C36B19E938DF9E:004F7A7338276BA489053412C4D892AF
        public SqlDatabaseExportRequestImpl WithStorageAccessKey(string storageAccessKey)
        {
            this.Inner.StorageKeyType = StorageKeyType.StorageAccessKey;
            this.Inner.StorageKey = storageAccessKey;
            return this;
        }

        ///GENMHASH:9B05554B05BC3D952D622EA7FB153F86:BADF5BF7BFF2AF37591D54901015DFBB
        internal SqlDatabaseExportRequestImpl WithStorageKeyType(StorageKeyType storageKeyType)
        {
            this.Inner.StorageKeyType = storageKeyType;
            return this;
        }

        ///GENMHASH:01EF824273EFC3A9C1E7DDD9882ACE09:D8D296FF97CB0F22AD39B4CF121EDAEE
        internal SqlDatabaseExportRequestImpl WithStorageKey(string storageKey)
        {
            this.Inner.StorageKey = storageKey;
            return this;
        }

        ///GENMHASH:FCE70A9CD34B8C168EB1F63E6F207D42:726635D670117CC0D040C28A613AE28F
        public SqlDatabaseExportRequestImpl WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AuthenticationType = AuthenticationType.ADPassword;
            return this.WithLoginAndPassword(administratorLogin, administratorPassword);
        }

        ///GENMHASH:653DFCECD1726D45C960AFE1BF555853:3DE854B28B881C61E82F0AF94357DD96
        internal SqlDatabaseExportRequestImpl WithLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AdministratorLogin = administratorLogin;
            this.Inner.AdministratorLoginPassword = administratorPassword;
            return this;
        }

        ///GENMHASH:B6B74D1492AFB9A8D0803D948AD0FC48:2A375FDD38EF6E541E26DEC82002843A
        internal SqlDatabaseExportRequestImpl WithAuthenticationType(AuthenticationType authenticationType)
        {
            this.Inner.AuthenticationType = authenticationType;
            return this;
        }

        ///GENMHASH:7E720FDC940A2922809B9D27EFCACBCD:7BB0FC51A283D3782A1A79D2457C3D7D
        public SqlDatabaseExportRequestImpl WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            this.Inner.AuthenticationType = AuthenticationType.SQL;
            return this.WithLoginAndPassword(administratorLogin, administratorPassword);
        }

        ///GENMHASH:212A2F2F92E2D462C22479742BC730A3:6CC092D2C179D47718C31F026A97C89D
        public SqlDatabaseExportRequestImpl ExportTo(string storageUri)
        {
            this.Inner.StorageUri = storageUri ?? throw new System.ArgumentNullException("storageUri");
            return this;
        }

        ///GENMHASH:86E7BAA14B4627C99B23DD5E99D3E137:79BB277F3A0CD6DC74187A66D3400BD1
        public SqlDatabaseExportRequestImpl ExportTo(Microsoft.Azure.Management.Storage.Fluent.IStorageAccount storageAccount, string containerName, string fileName)
        {
            this.storageAccount = storageAccount ?? throw new System.ArgumentNullException("storageAccount");
            this.containerName = containerName ?? throw new System.ArgumentNullException("containerName");
            this.fileName = fileName ?? throw new System.ArgumentNullException("fileName");
            this.storageAccountCreatable = null;
            return this;
        }

        ///GENMHASH:1F5324043331585B2120A5C89F84F5DB:0CFB327CCEC02962E7DF01BD3571BC6E
        public SqlDatabaseExportRequestImpl ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName)
        {
            this.storageAccountCreatable = storageAccountCreatable ?? throw new System.ArgumentNullException("storageAccountCreatable");
            this.containerName = containerName ?? throw new System.ArgumentNullException("containerName");
            this.fileName = fileName ?? throw new System.ArgumentNullException("fileName");
            this.storageAccount = null;
            return this;
        }

        ///GENMHASH:498D3951D3EB5A31E765F1E9A24A877E:EC10E45384DDEE353B45A8A0AF1AF89C
        public SqlDatabaseExportRequestImpl WithSharedAccessKey(string sharedAccessKey)
        {
            this.Inner.StorageKeyType = StorageKeyType.SharedAccessKey;
            this.Inner.StorageKey = sharedAccessKey;

            return this;
        }
    }
}