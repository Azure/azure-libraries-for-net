// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ManagementPoliciesImpl  :
        Wrapper<IManagementPoliciesOperations>,
        IManagementPolicies
    {
        private StorageManager manager;

        internal  ManagementPoliciesImpl(StorageManager manager) : base(manager.Inner.ManagementPolicies)
        {
            this.manager = manager;

        }

        private ManagementPolicyImpl WrapModel(ManagementPolicyInner inner)
        {
            return new ManagementPolicyImpl(inner, this.manager);
        }

        private ManagementPolicyImpl WrapModel(string name)
        {
            return new ManagementPolicyImpl(name, this.manager);
        }

        public ManagementPolicyImpl Define(string name)
        {
            return WrapModel(name);
        }

        public async Task DeleteAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IManagementPoliciesOperations client = this.Inner;
            await client.DeleteAsync(resourceGroupName, accountName);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> GetAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IManagementPoliciesOperations client = this.Inner;
            ManagementPolicyInner managementPolicyInner = await client.GetAsync(resourceGroupName, accountName);
            return WrapModel(managementPolicyInner);
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return this.Define(name);
        }
    }
}