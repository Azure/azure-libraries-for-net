// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLlNlY3JldHNJbXBs
    internal partial class SecretsImpl :
        CreatableResources<Microsoft.Azure.Management.KeyVault.Fluent.ISecret, Microsoft.Azure.Management.KeyVault.Fluent.SecretImpl, Microsoft.Azure.KeyVault.Models.SecretBundle>,
        ISecrets
    {
        private IKeyVaultClient inner;
        private IVault vault;
        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:814F98840711B8895AC26CE249A73A62
        public ISecret GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public ISecret GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public ISecret GetByNameAndVersion(string name, string version)
        {
            return Extensions.Synchronize(() => GetByNameAndVersionAsync(name, version));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:B752E4EC59041E9F1775EA7156FC1A6B
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await inner.GetSecretAsync(id, cancellationToken));
        }

        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await inner.GetSecretAsync(vault.VaultUri, name, cancellationToken));
        }

        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> GetByNameAndVersionAsync(string name, string version, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await inner.GetSecretAsync(vault.VaultUri, name, version, cancellationToken));
        }

        ///GENMHASH:C63853404036C3EA72DA3E0D94417F3B:8EFCE07990CA95E6F5AE1F22DEDC0454
        internal SecretsImpl(IKeyVaultClient client, IVault vault)
        {
            this.inner = client;
            this.vault = vault;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public SecretImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:C93F0B75434DD302173E0DC1D7D38D38
        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            SecretIdentifier identifier = new SecretIdentifier(id);
            await inner.DeleteSecretAsync(identifier.Vault, identifier.Name, cancellationToken);
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:78CDE324BDF4562C4434C84B3646BE66
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> List()
        {
            return Extensions.Synchronize(() => inner.GetSecretsAsync(vault.VaultUri))
                        .AsContinuousCollection(link => Extensions.Synchronize(() => inner.GetSecretsNextAsync(link)))
                        .Select(WrapModel);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:E2A759DF4967EC9040B5D1B63FCC33D5
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ISecret>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ISecret, SecretItem>.LoadPage(c => inner.GetSecretsAsync(vault.VaultUri, null, c),
                inner.GetSecretsNextAsync, WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:58334205B705AB8BE13E5163112B10FF
        protected override SecretImpl WrapModel(string name)
        {
            return new SecretImpl(name, new SecretBundle(), vault);
        }

        ///GENMHASH:240AD57CAD61A2F56B15619868469481:8FF57977BA80B41E76517084BD992D13
        protected override ISecret WrapModel(SecretBundle inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new SecretImpl(inner.SecretIdentifier.Name, inner, vault);
        }

        ///GENMHASH:D2EF373C3F52CF849FAB0427BA0BEC94:0236CC4148BAFE5FDA58A7525428A25F
        private ISecret WrapModel(SecretItem inner)
        {
            if (inner == null)
            {
                return null;
            }
            string serialized = Rest.Serialization.SafeJsonConvert.SerializeObject(inner, vault.Manager.Inner.SerializationSettings);
            return WrapModel(Rest.Serialization.SafeJsonConvert.DeserializeObject<SecretBundle>(serialized, vault.Manager.Inner.SerializationSettings));
        }
    }
}