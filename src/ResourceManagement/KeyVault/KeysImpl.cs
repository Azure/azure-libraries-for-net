// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Keyvault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Keyvault;
    using Microsoft.Azure.Keyvault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Rx.Functions;

    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLktleXNJbXBs
    internal partial class KeysImpl  :
        CreatableWrappersImpl<Microsoft.Azure.Management.KeyVault.Fluent.IKey,Microsoft.Azure.Management.Keyvault.Fluent.KeyImpl,Microsoft.Azure.Keyvault.Models.KeyBundle>,
        IKeys
    {
        private KeyVaultClient inner;
        private IVault vault;
        private IFunc1<Microsoft.Azure.Keyvault.Models.KeyItem,Rx.Observable<Microsoft.Azure.Management.KeyVault.Fluent.IKey>> converter;
        private <Microsoft.Azure.Keyvault.Models.KeyItem,Microsoft.Azure.Management.KeyVault.Fluent.IKey> listConverter;
        ///GENMHASH:8526360550C053825B6A643F96D512AD:D063ACAEFB27FCE2CA0B805B84D52A40
        public IKey Restore(params byte[] backup)
        {
            //$ return wrapModel(vault.Client().RestoreKey(vault.VaultUri(), backup));

            return null;
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:2C012F0622D372B72FB5DB57D479C088
        public IKey GetById(string id)
        {
            //$ return wrapModel(inner.GetKey(id));

            return null;
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:B752E4EC59041E9F1775EA7156FC1A6B
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Observable.From(getByIdAsync(id, null));

            return null;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public KeyImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:24F6E5076A7165DE19B48E32B2D2E90C
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ KeyIdentifier identifier = new KeyIdentifier(id);
            //$ return Completable.FromFuture(inner.DeleteKeyAsync(identifier.Vault(), identifier.Name(), null));

            return null;
        }

        ///GENMHASH:D00A188D7DFFF4A60B4043C987E8B889:8EFCE07990CA95E6F5AE1F22DEDC0454
        internal  KeysImpl(KeyVaultClient client, IVault vault)
        {
            //$ this.inner = client;
            //$ this.vault = vault;
            //$ }

        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:CA8FE045C0290832B80A02A867393E3F
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> List()
        {
            //$ return listConverter.Convert(inner.ListKeys(vault.VaultUri()));

            return null;
        }

        ///GENMHASH:7C81464E40ADCA071872CB5DCF157084:BDBB6D6F874E1D4DC0801D93DBF6DE29
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> RestoreAsync(byte[] backup, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyBundle, Key>() {
            //$ @Override
            //$ protected ServiceFuture<KeyBundle> callAsync() {
            //$ return vault.Client().RestoreKeyAsync(vault.VaultUri(), backup, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Key wrapModel(KeyBundle keyBundle) {
            //$ return KeysImpl.This.WrapModel(keyBundle);
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:9F0C4A17AF76F97938CE0C165A9A049A
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IKey>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ListCallbackObserver<KeyItem, Key>() {
            //$ @Override
            //$ protected void list(ListOperationCallback<KeyItem> callback) {
            //$ inner.ListKeysAsync(vault.VaultUri(), callback);
            //$ }
            //$ 
            //$ @Override
            //$ protected Observable<Key> typeConvertAsync(KeyItem keyItem) {
            //$ return converter.Call(keyItem);
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:46AC6DB759C53DE8C1458C6856916CD2
        protected KeyImpl WrapModel(string name)
        {
            //$ return new KeyImpl(name, new KeyBundle(), vault);

            return null;
        }

        ///GENMHASH:B08F92F88A1902E4EFF561293A34D861:4B80635BF2F0EEE24008330881A9BD10
        protected KeyImpl WrapModel(KeyBundle inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new KeyImpl(inner.KeyIdentifier().Name(), inner, vault);

            return null;
        }
    }
}