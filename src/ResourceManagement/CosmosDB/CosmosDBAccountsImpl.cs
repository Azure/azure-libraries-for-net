// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;
    using Rest.Azure;
    using System;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    /// <summary>
    /// Implementation for Registries.
    /// </summary>
    public partial class CosmosDBAccountsImpl :
        TopLevelModifiableResources<ICosmosDBAccount,
            CosmosDBAccountImpl,
            Models.DatabaseAccountGetResultsInner,
            IDatabaseAccountsOperations,
            ICosmosDBManager>,
        ICosmosDBAccounts
    {
        internal CosmosDBAccountsImpl(ICosmosDBManager manager) :
            base(manager.Inner.DatabaseAccounts, manager)
        {
        }

        public CosmosDBAccountImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override ICosmosDBAccount WrapModel(Models.DatabaseAccountGetResultsInner inner)
        {
            return new CosmosDBAccountImpl(inner.Name, inner, Manager);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>

        protected override CosmosDBAccountImpl WrapModel(string name)
        {
            return new CosmosDBAccountImpl(name, new Models.DatabaseAccountGetResultsInner(), Manager);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        public override IEnumerable<ICosmosDBAccount> List()
        {
            return Extensions.Synchronize(() => this.ListAsync());
        }

        public override async Task<IPagedCollection<ICosmosDBAccount>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ICosmosDBAccount, Models.DatabaseAccountGetResultsInner>.LoadPage(async (cancellation) =>
                await this.Manager.Inner.DatabaseAccounts.ListAsync(cancellationToken), WrapModel, cancellationToken);
        }

        public override IEnumerable<ICosmosDBAccount> ListByResourceGroup(string resourceGroupName)
        {
            return Extensions.Synchronize(() => this.ListByResourceGroupAsync(resourceGroupName));
        }

        public override async Task<IPagedCollection<ICosmosDBAccount>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ICosmosDBAccount, Models.DatabaseAccountGetResultsInner>.LoadPage(async (cancellation) =>
                await this.Manager.Inner.DatabaseAccounts.ListByResourceGroupAsync(resourceGroupName, cancellationToken), WrapModel, cancellationToken);
        }

        protected override Task<IPage<Models.DatabaseAccountGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.DatabaseAccountGetResultsInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.DatabaseAccountGetResultsInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected async override Task<IPage<Models.DatabaseAccountGetResultsInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<Models.DatabaseAccountGetResultsInner>>(null);
        }

        protected async override Task<Models.DatabaseAccountGetResultsInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        public async Task FailoverPriorityChangeAsync(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverLocations, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Models.FailoverPolicy> policyInners = new List<Models.FailoverPolicy>();
            for (int i = 0; i < failoverLocations.Count(); i++)
            {
                Models.Location location = failoverLocations[i];
                Models.FailoverPolicy policyInner = new Models.FailoverPolicy();
                policyInner.LocationName = location.LocationName;
                policyInner.FailoverPriority = i;
                policyInners.Add(policyInner);
            }

            await this.Manager.Inner.DatabaseAccounts.FailoverPriorityChangeAsync(groupName, accountName, policyInners);
        }

        public IDatabaseAccountListConnectionStringsResult ListConnectionStrings(string groupName, string accountName)
        {
            return Extensions.Synchronize(() => this.ListConnectionStringsAsync(groupName, accountName));
        }

        public IDatabaseAccountListKeysResult ListKeys(string groupName, string accountName)
        {
            return Extensions.Synchronize(() => this.ListKeysAsync(groupName, accountName));
        }

        public async Task<IDatabaseAccountListKeysResult> ListKeysAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Inner.ListKeysAsync(groupName, accountName, cancellationToken);
            return result != null ? new DatabaseAccountListKeysResultImpl(result) : null;
        }

        public void FailoverPriorityChange(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverLocations)
        {
            Extensions.Synchronize(() => this.FailoverPriorityChangeAsync(groupName, accountName, failoverLocations));
        }

        public async Task RegenerateKeyAsync(string groupName, string accountName, string keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.RegenerateKeyAsync(groupName, accountName, KeyKind.Parse(keyKind));
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> ListConnectionStringsAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts.ListConnectionStringsAsync(groupName, accountName);
            return result != null ? new DatabaseAccountListConnectionStringsResultImpl(result) : null;
        }

        public void RegenerateKey(string groupName, string accountName, string keyKind)
        {
            Extensions.Synchronize(() => this.RegenerateKeyAsync(groupName, accountName, keyKind));
        }

        ///GENMHASH:199BC8B250DE6FDC60059ADB2A4D8A17:0D023FA55B68AD0828AD9BF823383A9A
        public IDatabaseAccountListReadOnlyKeysResult ListReadOnlyKeys(string groupName, string accountName)
        {
            return Extensions.Synchronize(() => this.ListReadOnlyKeysAsync(groupName, accountName));
        }

        ///GENMHASH:53B98D29180D0703E1A1842F17ACDE80:FC86BA20A774722CAD5A76DA690B6B40
        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> ListReadOnlyKeysAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts
                .ListReadOnlyKeysAsync(groupName, accountName);
            return result != null ? new DatabaseAccountListReadOnlyKeysResultImpl(result) : null;
        }
    }
}