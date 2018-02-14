// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.Requests.SetSecretRequest;
    using Microsoft.Azure.KeyVault.Requests.UpdateSecretRequest;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLlNlY3JldEltcGw=
    internal partial class SecretImpl  :
        CreatableUpdatableImpl<Microsoft.Azure.Management.KeyVault.Fluent.ISecret,Microsoft.Azure.KeyVault.Models.SecretBundle,Microsoft.Azure.Management.KeyVault.Fluent.SecretImpl>,
        ISecret,
        IDefinition,
        IUpdate
    {
        private IVault vault;
        private Microsoft.Azure.KeyVault.Requests.SetSecretRequest.Builder setSecretRequest;
        private Microsoft.Azure.KeyVault.Requests.UpdateSecretRequest.Builder updateSecretRequest;
        ///GENMHASH:AFCF54960F557DFD8C6A8457EFAA9FD7:0C9DCA023B95F799C3FD4D6189ABC2DC
        public SecretImpl WithAttributes(Attributes attributes)
        {
            //$ setSecretRequest.WithAttributes(attributes);
            //$ updateSecretRequest.WithAttributes(attributes);
            //$ return this;

            return this;
        }

        ///GENMHASH:D4A7A02E673639C444C53A8D52EFA5E3:B22477C398F2CBD1F600FB646FB9D257
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ListCallbackObserver<SecretItem, SecretIdentifier>() {
            //$ 
            //$ @Override
            //$ protected void list(ListOperationCallback<SecretItem> callback) {
            //$ vault.Client().ListSecretVersionsAsync(vault.VaultUri(), name(), callback);
            //$ }
            //$ 
            //$ @Override
            //$ protected Observable<SecretIdentifier> typeConvertAsync(SecretItem o) {
            //$ return Observable.Just(o.Identifier());
            //$ }
            //$ }.ToObservable()
            //$ .FlatMap(new Func1<SecretIdentifier, Observable<Secret>>() {
            //$ @Override
            //$ public Observable<Secret> call( SecretIdentifier secretIdentifier) {
            //$ return new KeyVaultFutures.ServiceFutureConverter<SecretBundle, Secret>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<SecretBundle> callAsync() {
            //$ return vault.Client().GetSecretAsync(secretIdentifier.Identifier(), null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Secret wrapModel(SecretBundle secretBundle) {
            //$ return new SecretImpl(secretIdentifier.Name(), secretBundle, vault);
            //$ }
            //$ }.ToObservable();
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:5BDEAAEC54B8618E2AD31C058EFEDFDD
        public bool IsInCreateMode()
        {
            //$ return id() == null;

            return false;
        }

        ///GENMHASH:928A0E988013007B8FF0C01FEA6EC729:A078B007BAB437E799A89A7EFFC1B30F
        public string Kid()
        {
            //$ return Inner.Kid();

            return null;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:7BB7EB283B512F150F5E50263808D3D3
        public SecretImpl WithVersion(string version)
        {
            //$ updateSecretRequest.WithVersion(version);
            //$ return this;

            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:74DB1877CF76B1176F40C6A6991EF568
        protected async Task<Microsoft.Azure.KeyVault.Models.SecretBundle> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Observable.From(vault.Client().GetSecretAsync(id(), null));

            return null;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:7AB4F0903C94E4BB1CF29874B5530F1C
        public IReadOnlyDictionary<string,string> Tags()
        {
            //$ return Inner.Tags();

            return null;
        }

        ///GENMHASH:37F76E5729DFBD562C6418F2290EBC6E:153684EF1C070D6A9683BA9C173DC927
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> ListVersions()
        {
            //$ return new PagedListConverter<SecretItem, Secret>() {
            //$ 
            //$ @Override
            //$ public Observable<Secret> typeConvertAsync( SecretItem secretItem) {
            //$ return new KeyVaultFutures.ServiceFutureConverter<SecretBundle, Secret>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<SecretBundle> callAsync() {
            //$ return vault.Client().GetSecretAsync(secretItem.Identifier().Identifier(), null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Secret wrapModel(SecretBundle secretBundle) {
            //$ return new SecretImpl(secretBundle.SecretIdentifier().Name(), secretBundle, vault);
            //$ }
            //$ }.ToObservable();
            //$ }
            //$ }.Convert(vault.Client().ListSecretVersions(vault.VaultUri(), name()));

            return null;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:EB0F52C4D98BB007BEF4118B51D50750
        public SecretImpl WithTags(IDictionary<string,string> tags)
        {
            //$ setSecretRequest.WithTags(tags);
            //$ updateSecretRequest.WithTags(tags);
            //$ return this;

            return this;
        }

        ///GENMHASH:743674BDED1D329950DDBCB5D7E876E0:D0DF29AB717FE4F5696B6850352CF76F
        public SecretImpl WithValue(string value)
        {
            //$ setSecretRequest = new SetSecretRequest.Builder(vault.VaultUri(), name(), value);
            //$ return this;

            return this;
        }

        ///GENMHASH:2A836929F85CF9F0E4B71283C422B775:182D2D7996886C82E674FB6B6D129493
        public SecretImpl WithContentType(string contentType)
        {
            //$ setSecretRequest.WithContentType(contentType);
            //$ updateSecretRequest.WithContentType(contentType);
            //$ return this;

            return this;
        }

        ///GENMHASH:102FF34ED866CF06776958C1FF6FD15B:85AD7F5C4AA6206BF6C989C0A5E03257
        public bool Managed()
        {
            //$ return Utils.ToPrimitiveBoolean(Inner.Managed());

            return false;
        }

        ///GENMHASH:D4F352220A93EA5AA29C8B5E4597D85A:C23C77328A8E0D7CC1FB12BB56B5BE22
        internal  SecretImpl(string name, SecretBundle innerObject, IVault vault)
        {
            //$ super(name, innerObject);
            //$ this.vault = vault;
            //$ this.updateSecretRequest = new UpdateSecretRequest.Builder(vault.VaultUri(), name);
            //$ }

        }

        ///GENMHASH:9CC87213BAB687D1788EA9F4C2B726E8:33C4441D7A92CE4AEBE93672F3F8EBD8
        public SecretAttributes Attributes()
        {
            //$ return Inner.Attributes();

            return null;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            //$ return Inner.Id();

            return null;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:A779AD9340BD624EF5C1E0B1A3B5F2AF
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<Secret> set = Observable.Just((Secret) this);
            //$ if (setSecretRequest != null) {
            //$ set = createResourceAsync();
            //$ }
            //$ return set.FlatMap(new Func1<Secret, Observable<SecretBundle>>() {
            //$ @Override
            //$ public Observable<SecretBundle> call(Secret secret) {
            //$ return Observable.From(vault.Client().UpdateSecretAsync(updateSecretRequest.Build(), null));
            //$ }
            //$ }).FlatMap(new Func1<SecretBundle, Observable<Secret>>() {
            //$ @Override
            //$ public Observable<Secret> call(SecretBundle secretBundle) {
            //$ return refreshAsync();
            //$ }
            //$ }).DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ setSecretRequest = null;
            //$ updateSecretRequest = new UpdateSecretRequest.Builder(vault.VaultUri(), name());
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:8C13F3C8A63442B189D1C7B0529DB891
        public string Value()
        {
            //$ return Inner.Value();

            return null;
        }

        ///GENMHASH:F86207AEECF64645DBEF0C002CC9BB6C:007D049863090989FCAF4C782FDD499C
        public string ContentType()
        {
            //$ return Inner.ContentType();

            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F12FC594E9C15DBC3FFFACD9CF4D07E0
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Observable.From(vault.Client().SetSecretAsync(setSecretRequest.Build(), null))
            //$ .Map(innerToFluentMap(this))
            //$ .DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ setSecretRequest = null;
            //$ updateSecretRequest = new UpdateSecretRequest.Builder(vault.VaultUri(), name());
            //$ }
            //$ });

            return null;
        }
    }
}