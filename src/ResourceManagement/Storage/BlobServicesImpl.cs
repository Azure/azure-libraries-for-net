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
            this.manager = manager;
        }

        private BlobServicePropertiesImpl WrapModel(BlobServicePropertiesInner inner)
        {
            return new BlobServicePropertiesImpl(inner, this.manager);
        }

        private BlobServicePropertiesImpl WrapModel(string name)
        {
            return new BlobServicePropertiesImpl(name, this.manager);
        }

        public BlobServicePropertiesImpl Define(string name)
        {
            return WrapModel(name);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> GetServicePropertiesAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobServicesOperations client = this.Inner;
            BlobServicePropertiesInner blobServicePropertiesInner = await client.GetServicePropertiesAsync(resourceGroupName, accountName);
            return WrapModel(blobServicePropertiesInner);
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        BlobServiceProperties.Definition.IBlank ISupportsCreating<BlobServiceProperties.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }
    }
}