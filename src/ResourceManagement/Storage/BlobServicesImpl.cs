// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobServicesImpl  :
        Wrapper<IBlobServicesOperations>,
        IBlobServices
    {
        private StorageManager manager;

                internal  BlobServicesImpl(StorageManager manager) : base(manager.Inner.BlobServices)
        {
            //$ super(manager.Inner().BlobServices());
            //$ this.manager = manager;
            //$ }

        }

                private BlobServicePropertiesImpl WrapModel(BlobServicePropertiesInner inner)
        {
            //$ return  new BlobServicePropertiesImpl(inner, manager());
            //$ }

            return null;
        }

                private BlobServicePropertiesImpl WrapModel(string name)
        {
            //$ return new BlobServicePropertiesImpl(name, this.manager());
            //$ }

            return null;
        }

                public BlobServicePropertiesImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> GetServicePropertiesAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobServicesInner client = this.Inner();
            //$ return client.GetServicePropertiesAsync(resourceGroupName, accountName)
            //$ .Map(new Func1<BlobServicePropertiesInner, BlobServiceProperties>() {
            //$ @Override
            //$ public BlobServiceProperties call(BlobServicePropertiesInner inner) {
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

        BlobServiceProperties.Definition.IBlank ISupportsCreating<BlobServiceProperties.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }
    }
}