// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Server children operations.
    /// </summary>
    /// <typeparam name="FluentModelT">The fluent model type of the child resource.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxDaGlsZHJlbk9wZXJhdGlvbnNJbXBs
    internal abstract partial class SqlChildrenOperationsImpl<FluentModelT>  :
        ISqlChildrenOperations<FluentModelT>,
        ISqlChildrenActionsDefinition<FluentModelT>
    {
        protected ISqlManager sqlServerManager;
        protected ISqlServer sqlServer;

        ///GENMHASH:38F25BF3BAF6CC66FCF20A982BCC9D49:D2D2D6E5CB31EA693A417EE1C7AA57DF
        internal SqlChildrenOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
        {
            this.sqlServer = parent;
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:DFB9811D4C0F33590C78A6AF9E912994
        public FluentModelT GetById(string id)
        {
            return this.GetBySqlServer(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(ResourceUtils.ParentRelativePathFromResourceId(id)),
                ResourceUtils.NameFromResourceId(id));
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:98A40305CB5222ADE48FAC15EF20A8E7
        public FluentModelT Get(string name)
        {
            if (this.sqlServer == null)
            {
                return default(FluentModelT);
            }
            return this.GetBySqlServer(this.sqlServer, name);
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:487BF38141DB6ADDAB135D4A077E5776
        public async Task<FluentModelT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetBySqlServerAsync(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(ResourceUtils.ParentRelativePathFromResourceId(id)),
                ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:DCEEEF4375DAE606E6DAD8A9FDADD8F9
        public void DeleteById(string id)
        {
            this.DeleteBySqlServer(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(ResourceUtils.ParentRelativePathFromResourceId(id)),
                ResourceUtils.NameFromResourceId(id));

        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:5C3E0E7E1CF165D67A5D6B44C259B469
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteBySqlServerAsync(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.NameFromResourceId(ResourceUtils.ParentRelativePathFromResourceId(id)),
                ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:B209E1E0E54E3F8E692FC2C81F448D0A
        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlServer == null) {
                return;
            }
            await this.DeleteBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name, cancellationToken);
        }

        ///GENMHASH:AF8385463FD062B3C56A3F22F51DFEE4:99973FBFF821702A2BB96E3D93713E2C
        public async Task<FluentModelT> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlServer == null)
            {
                return default(FluentModelT);
            }
            return await this.GetBySqlServerAsync(this.sqlServer, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:4640FD0E6A2FE534EAF965B21BFE4C06
        public IReadOnlyList<FluentModelT> List()
        {
            if (this.sqlServer == null)
            {
                return null;
            }
            return this.ListBySqlServer(this.sqlServer);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:FD375E281FD7434033D4B4DA836A420D
        public void Delete(string name)
        {
            if (this.sqlServer != null)
            {
                this.DeleteBySqlServer(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name);
            }
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:6683BC5C8829B22A02D479C82EEDBE01
        public async Task<IReadOnlyList<FluentModelT>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return null;
            }
            return await this.ListBySqlServerAsync(this.sqlServer, cancellationToken);
        }

        public abstract IReadOnlyList<FluentModelT> ListBySqlServer(string resourceGroupName, string sqlServerName);
        public abstract IReadOnlyList<FluentModelT> ListBySqlServer(ISqlServer sqlServer);
        public abstract FluentModelT GetBySqlServer(string resourceGroupName, string sqlServerName, string name);
        public abstract FluentModelT GetBySqlServer(ISqlServer sqlServer, string name);
        public abstract Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<IReadOnlyList<FluentModelT>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<IReadOnlyList<FluentModelT>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<FluentModelT> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<FluentModelT> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name);
    }
}