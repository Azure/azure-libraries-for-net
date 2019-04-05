// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ManagementPoliciesImpl  :
        Wrapper<IManagementPoliciesOperations>,
        IManagementPolicies
    {
        private StorageManager manager;

                internal  ManagementPoliciesImpl(StorageManager manager) : base(manager.Inner.ManagementPolicies)
        {
            //$ super(manager.Inner().ManagementPolicies());
            //$ this.manager = manager;
            //$ }

        }

                private ManagementPolicyImpl WrapModel(ManagementPoliciesOperations inner)
        {
            //$ return  new ManagementPolicyImpl(inner, manager());
            //$ }

            return null;
        }

                private ManagementPolicyImpl WrapModel(string name)
        {
            //$ return new ManagementPolicyImpl(name, this.manager());
            //$ }

            return null;
        }

                public ManagementPolicyImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

                public async Task DeleteAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ManagementPoliciesInner client = this.Inner();
            //$ return client.DeleteAsync(resourceGroupName, accountName).ToCompletable();
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> GetAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ManagementPoliciesInner client = this.Inner();
            //$ return client.GetAsync(resourceGroupName, accountName)
            //$ .Map(new Func1<ManagementPolicyInner, ManagementPolicy>() {
            //$ @Override
            //$ public ManagementPolicy call(ManagementPolicyInner inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ });

            return null;
        }

                public StorageManager Manager()
        {
            //$ return this.manager;
            //$ }

            return null;
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return this.Define(name);
        }
    }
}