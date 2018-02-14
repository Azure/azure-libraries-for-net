// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.Requests.CreateKeyRequest;
    using Microsoft.Azure.KeyVault.Requests.ImportKeyRequest;
    using Microsoft.Azure.KeyVault.Requests.UpdateKeyRequest;
    using Microsoft.Azure.KeyVault.Webkey;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLktleUltcGw=
    internal partial class KeyImpl  :
        CreatableUpdatableImpl<Microsoft.Azure.Management.KeyVault.Fluent.IKey,Microsoft.Azure.KeyVault.Models.KeyBundle,Microsoft.Azure.Management.KeyVault.Fluent.KeyImpl>,
        IKey,
        IDefinition,
        IUpdateWithCreate,
        IUpdateWithImport
    {
        private IVault vault;
        private Microsoft.Azure.KeyVault.Requests.CreateKeyRequest.Builder createKeyRequest;
        private Microsoft.Azure.KeyVault.Requests.UpdateKeyRequest.Builder updateKeyRequest;
        private Microsoft.Azure.KeyVault.Requests.ImportKeyRequest.Builder importKeyRequest;
        ///GENMHASH:AFCF54960F557DFD8C6A8457EFAA9FD7:4D14C122ABD17C920271DE798B9AE88A
        public KeyImpl WithAttributes(Attributes attributes)
        {
            //$ if (isInCreateMode()) {
            //$ if (createKeyRequest != null) {
            //$ createKeyRequest.WithAttributes(attributes);
            //$ } else {
            //$ importKeyRequest.WithAttributes(attributes);
            //$ }
            //$ } else {
            //$ updateKeyRequest.WithAttributes(attributes);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:50D97A839D6AF33BD55887CDB05585F6:18C149C1B3AD07942BE52459F3A85F17
        public byte Backup()
        {
            //$ return vault.Client().BackupKey(vault.VaultUri(), name()).Value();

            return 0;
        }

        ///GENMHASH:D4A7A02E673639C444C53A8D52EFA5E3:61064B2A2392BBDB85E525979D4D0BED
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ListCallbackObserver<KeyItem, KeyIdentifier>() {
            //$ 
            //$ @Override
            //$ protected void list(ListOperationCallback<KeyItem> callback) {
            //$ vault.Client().ListKeyVersionsAsync(vault.VaultUri(), name(), callback);
            //$ }
            //$ 
            //$ @Override
            //$ protected Observable<KeyIdentifier> typeConvertAsync(KeyItem o) {
            //$ return Observable.Just(o.Identifier());
            //$ }
            //$ }.ToObservable()
            //$ .FlatMap(new Func1<KeyIdentifier, Observable<Key>>() {
            //$ @Override
            //$ public Observable<Key> call( KeyIdentifier keyIdentifier) {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyBundle, Key>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyBundle> callAsync() {
            //$ return vault.Client().GetKeyAsync(keyIdentifier.Identifier(), null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Key wrapModel(KeyBundle keyBundle) {
            //$ return new KeyImpl(keyIdentifier.Name(), keyBundle, vault);
            //$ }
            //$ }.ToObservable();
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:A24DEA7416E3C63740F762CB203870B1:FC9FA12503FF387652EDECA6C4BCF3C7
        public async Task<byte> SignAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyOperationResult, byte[]>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyOperationResult> callAsync() {
            //$ return vault.Client().SignAsync(Inner.KeyIdentifier().Identifier(), algorithm, digest, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(KeyOperationResult keyOperationResult) {
            //$ return keyOperationResult.Result();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:3F48ED60CF387C84267B437D8556ADE8:F0ED3CD3D9620D6ECF99FF69A68F22A2
        public async Task<byte> WrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyOperationResult, byte[]>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyOperationResult> callAsync() {
            //$ return vault.Client().WrapKeyAsync(Inner.KeyIdentifier().Identifier(), algorithm, key, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(KeyOperationResult keyOperationResult) {
            //$ return keyOperationResult.Result();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:EC3E3FD471B61CC3A76CA417659849DB:F53D9841C2432144FB7FEDD4CDBFD5F9
        public async Task<byte> EncryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyOperationResult, byte[]>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyOperationResult> callAsync() {
            //$ return vault.Client().EncryptAsync(Inner.KeyIdentifier().Identifier(), algorithm, content, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(KeyOperationResult keyOperationResult) {
            //$ return keyOperationResult.Result();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:D3DFB0D2185AF1F41A37363CE2556419:50116362EC57A25887D53D2FE0E43FFF
        public byte Sign(JsonWebKeySignatureAlgorithm algorithm, params byte[] digest)
        {
            //$ return vault.Client().Sign(Inner.KeyIdentifier().Identifier(), algorithm, digest).Result();

            return 0;
        }

        ///GENMHASH:4E7230F406919F8A99848F96940D36B7:E623E8B0FB39A7ECCB38096BFEE3AF9E
        public async Task<byte> UnwrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyOperationResult, byte[]>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyOperationResult> callAsync() {
            //$ return vault.Client().UnwrapKeyAsync(Inner.KeyIdentifier().Identifier(), algorithm, key, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(KeyOperationResult keyOperationResult) {
            //$ return keyOperationResult.Result();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:BF064975B37538E2EBE27D3224A7A39B:719F78BC1EF0A764933A0DD78CB7245A
        public async Task<byte> BackupAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<BackupKeyResult, byte[]>() {
            //$ @Override
            //$ protected ServiceFuture<BackupKeyResult> callAsync() {
            //$ return vault.Client().BackupKeyAsync(vault.VaultUri(), name(), null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(BackupKeyResult backupKeyResult) {
            //$ return backupKeyResult.Value();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:F94155EAAB3BBA02F08ABD3831066F4B:60CD909C47A91EAFE71643C31F1B325C
        public async Task<byte> DecryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyOperationResult, byte[]>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyOperationResult> callAsync() {
            //$ return vault.Client().DecryptAsync(Inner.KeyIdentifier().Identifier(), algorithm, content, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected byte[] wrapModel(KeyOperationResult keyOperationResult) {
            //$ return keyOperationResult.Result();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:695605B4CA55F648453EEFC4352B1130
        protected async Task<Microsoft.Azure.KeyVault.Models.KeyBundle> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Observable.From(vault.Client().GetKeyAsync(id(), null));

            return null;
        }

        ///GENMHASH:37F76E5729DFBD562C6418F2290EBC6E:D1063FA725E63DC403D7BF310EE5DC43
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> ListVersions()
        {
            //$ return new PagedListConverter<KeyItem, Key>() {
            //$ 
            //$ @Override
            //$ public Observable<Key> typeConvertAsync( KeyItem keyItem) {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyBundle, Key>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyBundle> callAsync() {
            //$ return vault.Client().GetKeyAsync(keyItem.Identifier().Identifier(), null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Key wrapModel(KeyBundle keyBundle) {
            //$ return new KeyImpl(keyBundle.KeyIdentifier().Name(), keyBundle, vault);
            //$ }
            //$ }.ToObservable();
            //$ }
            //$ }.Convert(vault.Client().ListKeyVersions(vault.VaultUri(), name()));

            return null;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:962949D4060A8D0ABA177599EE60802D
        public KeyImpl WithTags(IDictionary<string,string> tags)
        {
            //$ if (isInCreateMode()) {
            //$ if (createKeyRequest != null) {
            //$ createKeyRequest.WithTags(tags);
            //$ } else {
            //$ importKeyRequest.WithTags(tags);
            //$ }
            //$ } else {
            //$ updateKeyRequest.WithTags(tags);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:2496E3A1CFF32BBA877292D9CB043164:1FA0DB9335D2EA92B76A8DC9AC7D00A8
        public KeyImpl WithKeySize(int size)
        {
            //$ createKeyRequest.WithKeySize(size);
            //$ return this;

            return this;
        }

        ///GENMHASH:102FF34ED866CF06776958C1FF6FD15B:85AD7F5C4AA6206BF6C989C0A5E03257
        public bool Managed()
        {
            //$ return Utils.ToPrimitiveBoolean(Inner.Managed());

            return false;
        }

        ///GENMHASH:952553F84008D803939E0FB7F6B133FA:E28336CDDF11604C7DE06289AFF883A6
        public byte Encrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            //$ return vault.Client().Encrypt(Inner.KeyIdentifier().Identifier(), algorithm, content).Result();

            return 0;
        }

        ///GENMHASH:941A212532B2484985C0C67B55878584:EEEF6B4C0E5650CF744C9BEDCB5F5483
        public bool Verify(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, params byte[] signature)
        {
            //$ return vault.Client().Verify(Inner.KeyIdentifier().Identifier(), algorithm, digest, signature).Value();

            return false;
        }

        ///GENMHASH:36F02393B4CD5B681247EB8843168873:F25F1A6C5841A6F39CB361877DC604BF
        public KeyImpl WithHsm(bool isHsm)
        {
            //$ importKeyRequest.WithHsm(isHsm);
            //$ return this;

            return this;
        }

        ///GENMHASH:3A4433EF829CAEE497A4F27E732D49F9:D149CDD00015F48C6E468E742B574FF0
        public JsonWebKey JsonWebKey()
        {
            //$ return Inner.Key();

            return null;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:EFE12610EA19B6BA5961AAC9B849F447
        public string Id()
        {
            //$ if (Inner.KeyIdentifier() == null) {
            //$ return null;
            //$ }
            //$ return Inner.KeyIdentifier().Identifier();

            return null;
        }

        ///GENMHASH:42ACA509E5FCC7BF9DCE9A7C902F9A09:2412331D2A339999368F53668E4D0D10
        public byte UnwrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            //$ return vault.Client().UnwrapKey(Inner.KeyIdentifier().Identifier(), algorithm, key).Result();

            return 0;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:5983BB56B6190FDBBCF28E6CF2A5422F
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<Key> set = Observable.Just((Key) this);
            //$ if (createKeyRequest != null || importKeyRequest != null) {
            //$ set = createResourceAsync();
            //$ }
            //$ return set.FlatMap(new Func1<Key, Observable<KeyBundle>>() {
            //$ @Override
            //$ public Observable<KeyBundle> call(Key secret) {
            //$ return Observable.From(vault.Client().UpdateKeyAsync(updateKeyRequest.Build(), null));
            //$ }
            //$ }).FlatMap(new Func1<KeyBundle, Observable<Key>>() {
            //$ @Override
            //$ public Observable<Key> call(KeyBundle secretBundle) {
            //$ return refreshAsync();
            //$ }
            //$ }).DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ createKeyRequest = null;
            //$ importKeyRequest = null;
            //$ updateKeyRequest = new UpdateKeyRequest.Builder(vault.VaultUri(), name());
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:2F65E1EAF1103D36E64A2275FFA6F81F
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Observable.Defer(new Func0<Observable<Key>>() {
            //$ @Override
            //$ public Observable<Key> call() {
            //$ if (createKeyRequest != null) {
            //$ return Observable.From(vault.Client().CreateKeyAsync(createKeyRequest.Build(), null))
            //$ .Map(innerToFluentMap(KeyImpl.This))
            //$ .DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ createKeyRequest = null;
            //$ updateKeyRequest = new UpdateKeyRequest.Builder(vault.VaultUri(), name());
            //$ }
            //$ });
            //$ } else {
            //$ return Observable.From(vault.Client().ImportKeyAsync(importKeyRequest.Build(), null))
            //$ .Map(innerToFluentMap(KeyImpl.This))
            //$ .DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ importKeyRequest = null;
            //$ updateKeyRequest = new UpdateKeyRequest.Builder(vault.VaultUri(), name());
            //$ }
            //$ });
            //$ }
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

        ///GENMHASH:98060D1B7FD52C7724F36876E3AA8CC9:C3E882EB9B8E9BD6C5F7A74CD50D69D0
        internal  KeyImpl(string name, KeyBundle innerObject, IVault vault)
        {
            //$ super(name, innerObject);
            //$ this.vault = vault;
            //$ this.updateKeyRequest = new UpdateKeyRequest.Builder(vault.VaultUri(), name);
            //$ }

        }

        ///GENMHASH:53615EE168ABC0D3B17DDF1E300061BE:E0088DEF3B6727A81BFDBF63F112FD97
        public byte WrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            //$ return vault.Client().WrapKey(Inner.KeyIdentifier().Identifier(), algorithm, key).Result();

            return 0;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:7AB4F0903C94E4BB1CF29874B5530F1C
        public IReadOnlyDictionary<string,string> Tags()
        {
            //$ return Inner.Tags();

            return null;
        }

        ///GENMHASH:3D1F4F9B31A1E4FAB317EE4E0C5C9528:5CADE1B284DC5DE1B854039B12712163
        public KeyImpl WithLocalKeyToImport(JsonWebKey key)
        {
            //$ importKeyRequest = new ImportKeyRequest.Builder(vault.VaultUri(), name(), key);
            //$ return this;

            return this;
        }

        ///GENMHASH:7224D401F0FF578F9440423240845D61:41A3C41764F15BC0C463D26AC61868CA
        public KeyImpl WithKeyTypeToCreate(JsonWebKeyType keyType)
        {
            //$ createKeyRequest = new CreateKeyRequest.Builder(vault.VaultUri(), name(), keyType);
            //$ return this;

            return this;
        }

        ///GENMHASH:F8981C320EC895546CAD8EF73E3DACB1:FA255B6DF9DFB304BFA5E3A3E7D37104
        public KeyImpl WithKeyOperations(IList<Microsoft.Azure.KeyVault.Webkey.JsonWebKeyOperation> keyOperations)
        {
            //$ if (isInCreateMode()) {
            //$ createKeyRequest.WithKeyOperations(keyOperations);
            //$ } else {
            //$ updateKeyRequest.WithKeyOperations(keyOperations);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:E8E1F2F9C703FE40776D6F7DF2DD1E68:D8742138DF32E8225B74BEBFD0186A34
        public KeyImpl WithKeyOperations(params JsonWebKeyOperation[] keyOperations)
        {
            //$ return withKeyOperations(Arrays.AsList(keyOperations));

            return this;
        }

        ///GENMHASH:9CC87213BAB687D1788EA9F4C2B726E8:33C4441D7A92CE4AEBE93672F3F8EBD8
        public KeyAttributes Attributes()
        {
            //$ return Inner.Attributes();

            return null;
        }

        ///GENMHASH:FEE492F5B9F2CCFE2EBA87182AF9BB3C:A60DF4005777D357B57ED714179A311F
        public async Task<bool> VerifyAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return new KeyVaultFutures.ServiceFutureConverter<KeyVerifyResult, Boolean>() {
            //$ 
            //$ @Override
            //$ protected ServiceFuture<KeyVerifyResult> callAsync() {
            //$ return vault.Client().VerifyAsync(Inner.KeyIdentifier().Identifier(), algorithm, digest, signature, null);
            //$ }
            //$ 
            //$ @Override
            //$ protected Boolean wrapModel(KeyVerifyResult keyOperationResult) {
            //$ return keyOperationResult.Value();
            //$ }
            //$ }.ToObservable();

            return null;
        }

        ///GENMHASH:68E43175FD1572C39912FBCB105BF169:0533E9B624D1DC48D9B75883F9A63688
        public byte Decrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            //$ return vault.Client().Decrypt(Inner.KeyIdentifier().Identifier(), algorithm, content).Result();

            return 0;
        }
    }
}