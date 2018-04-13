// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Encryption Protector operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbmNyeXB0aW9uUHJvdGVjdG9yT3BlcmF0aW9uc0ltcGw=
    internal partial class SqlEncryptionProtectorOperationsImpl  :
        ISqlEncryptionProtectorOperations,
        ISqlEncryptionProtectorActionsDefinition
    {
        protected ISqlManager sqlServerManager;
        protected ISqlServer sqlServer;

        ///GENMHASH:C77D9E3188AA5D0B50DE65B6E7E8D267:4942F86A44370BE5F87D508314540978
        internal SqlEncryptionProtectorOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
        {
            this.sqlServer = parent;
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:3EA86E8FB8BFD12AB92EFF5CD5DBC7B8:B9438CBADF67F717E9124756C880E7E3
        internal SqlEncryptionProtectorOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:6FE2DFAB84F7C16D6194AEA009EEDFC4
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:1CBD9368DD3FBE52B82A6FEDA9014680
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:E942595049A9BFDD7C8D5993214CBEC4:E7F49048E7442F79B80DEFC4143DE2F2
        public ISqlEncryptionProtector GetBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:1F110B74A55656489F09C8A6B9915ABB:0D1B5248D74F38E1C97B48BB7E76AA66
        public ISqlEncryptionProtector GetBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:C6162D2226267562CCD55AC040EFD548
        public ISqlEncryptionProtector GetById(string id)
        {
            return Extensions.Synchronize(() => this.GetByIdAsync(id));
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:322C7F5994350DD787C93CBDCD3773CB
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> encryptionProtectors = new List<ISqlEncryptionProtector>();
            var encryptionProtectorInners = await this.sqlServerManager.Inner.EncryptionProtectors
                .ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (encryptionProtectorInners != null)
            {
                foreach (var encryptionProtectorInner in encryptionProtectorInners)
                {
                    encryptionProtectors.Add(new SqlEncryptionProtectorImpl(resourceGroupName, sqlServerName, encryptionProtectorInner, this.sqlServerManager));
                }
            }
            return encryptionProtectors.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:194FD06C0A433DA71B2E0D06F4181B3E
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> encryptionProtectors = new List<ISqlEncryptionProtector>();
            var encryptionProtectorInners = await this.sqlServerManager.Inner.EncryptionProtectors
                .ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (encryptionProtectorInners != null)
            {
                foreach (var encryptionProtectorInner in encryptionProtectorInners)
                {
                    encryptionProtectors.Add(new SqlEncryptionProtectorImpl((SqlServerImpl)sqlServer, encryptionProtectorInner, this.sqlServerManager));
                }
            }
            return encryptionProtectors.AsReadOnly();
        }

        ///GENMHASH:82B77715645DD0E35D331EE06F258E9B:0DD555A477C9258E91EFCC69F91EA201
        public ISqlEncryptionProtector Get()
        {
            if (this.sqlServer == null)
            {
                return null;
            }
            return this.GetBySqlServer(this.sqlServer);
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:95A2E581BA4B4B25DBD50342A44481E5
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetBySqlServerAsync(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(ResourceUtils.ParentRelativePathFromResourceId(id)),
                cancellationToken);
        }

        ///GENMHASH:0A2773EFDE2BC4099A3959934EFD0541:5E05241A2E930E0AE7A7240855A2FF84
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var encryptionProtectorInner = await this.sqlServerManager.Inner.EncryptionProtectors
                .GetAsync(resourceGroupName, sqlServerName, cancellationToken);
            return encryptionProtectorInner != null ? new SqlEncryptionProtectorImpl(resourceGroupName, sqlServerName, encryptionProtectorInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:4C46881FF90C11FF4242A32598B68C38:0AD0404D9FD658FD064263E89C3B722B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            var encryptionProtectorInner = await this.sqlServerManager.Inner.EncryptionProtectors
                .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            return encryptionProtectorInner != null ? new SqlEncryptionProtectorImpl((SqlServerImpl)sqlServer, encryptionProtectorInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:3B3E767159B438A33BFD1C9FA7AD8D17:730F82A1CF857EFE72709696DE67086B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlServer == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlServer);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:4640FD0E6A2FE534EAF965B21BFE4C06
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> List()
        {
            if (this.sqlServer == null){
                return new List<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>().AsReadOnly();
            }
            return this.ListBySqlServer(this.sqlServer);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:6683BC5C8829B22A02D479C82EEDBE01
        public async Task<IReadOnlyList<ISqlEncryptionProtector>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return new List<ISqlEncryptionProtector>().AsReadOnly();
            }
            return await this.ListBySqlServerAsync(this.sqlServer, cancellationToken);
        }
    }
}