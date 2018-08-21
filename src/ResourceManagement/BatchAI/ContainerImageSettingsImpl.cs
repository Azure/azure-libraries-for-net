// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ContainerImageSettings.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoYWkuaW1wbGVtZW50YXRpb24uQ29udGFpbmVySW1hZ2VTZXR0aW5nc0ltcGw=
    internal partial class ContainerImageSettingsImpl  :
        IndexableWrapper<Microsoft.Azure.Management.BatchAI.Fluent.Models.ContainerSettings>,
        IDefinition<BatchAIJob.Definition.IWithCreate>
    {
        private BatchAIJobImpl parent;

        ///GENMHASH:E69EAFBE5FEE03FDD5408C54C9FE8D17:CA53B7BE62B1D1854755EDD010D28892
        internal ContainerImageSettingsImpl(ContainerSettings inner, BatchAIJobImpl parent) : base(inner)
        {
            this.parent = parent;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:7EF63673EC66A608A59744FDA0DA741A
        public IWithCreate Attach()
        {
            this.parent.AttachImageSourceRegistry(this);
            return parent;
        }

        ///GENMHASH:8323B797B402AFEFC48941D936C673E7:468E9153F074340EA4E29EE69B25A863
        public ContainerImageSettingsImpl WithRegistryPassword(string password)
        {
            EnsureImageSourceRegistry().Credentials.Password = password;
            return this;
        }

        ///GENMHASH:E7CC7281AE6CC5F72A469E556DBA3F33:1362DDE1558B42E73AA2B98EB9E48651
        public ContainerImageSettingsImpl WithRegistrySecretReference(string keyVaultId, string secretUrl)
        {
            EnsureImageSourceRegistry().Credentials.PasswordSecretReference = new KeyVaultSecretReference(new Models.ResourceId(keyVaultId), secretUrl);
            return this;
        }

        ///GENMHASH:39C3DE00546A8028DDD7BF5E1F16DC0E:952645BC3F8834DC7FD47D744C9A7516
        public ContainerImageSettingsImpl WithRegistryUrl(string serverUrl)
        {
            EnsureImageSourceRegistry().ServerUrl = serverUrl;
            return this;
        }

        ///GENMHASH:DA39F8D061095C603F6A5359EAD6BEF9:854C20A074E81A8280EFC41DCDF2BBFC
        public ContainerImageSettingsImpl WithRegistryUsername(string username)
        {
            EnsureImageSourceRegistry().Credentials = new PrivateRegistryCredentials(username);
            return this;
        }

        public ContainerImageSettingsImpl WithShmSize(string shmSize)
        {
            Inner.ShmSize = shmSize;
            return this;
        }

        private ImageSourceRegistry EnsureImageSourceRegistry()
        {
            if (Inner.ImageSourceRegistry == null)
            {
                Inner.ImageSourceRegistry = new ImageSourceRegistry();
            }
            return Inner.ImageSourceRegistry;
        }
    }
}