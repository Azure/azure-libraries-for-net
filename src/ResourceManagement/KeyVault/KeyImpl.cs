// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.KeyVault;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLktleUltcGw=
    internal partial class KeyImpl :
        CreatableUpdatable<IKey, KeyBundle, KeyImpl, IHasId, IUpdate>,
        IKey,
        IDefinition,
        IUpdateWithCreate,
        IUpdateWithImport
    {
        private IVault vault;
        private CreateKeyRequest createKeyRequest;
        private UpdateKeyRequest updateKeyRequest;
        private ImportKeyRequest importKeyRequest;

        ///GENMHASH:AFCF54960F557DFD8C6A8457EFAA9FD7:4D14C122ABD17C920271DE798B9AE88A
        public KeyImpl WithAttributes(Attributes attributes)
        {
            if (IsInCreateMode())
            {
                if (createKeyRequest != null)
                {
                    createKeyRequest.KeyAttributes = (KeyAttributes)attributes;
                }
                else
                {
                    importKeyRequest.KeyAttributes = (KeyAttributes)attributes;
                }
            }
            else
            {
                updateKeyRequest.KeyAttributes = (KeyAttributes)attributes;
            }
            return this;
        }

        ///GENMHASH:50D97A839D6AF33BD55887CDB05585F6:18C149C1B3AD07942BE52459F3A85F17
        public byte[] Backup()
        {
            return Extensions.Synchronize(() => BackupAsync());
        }

        ///GENMHASH:D4A7A02E673639C444C53A8D52EFA5E3:61064B2A2392BBDB85E525979D4D0BED
        public async Task<IPagedCollection<Microsoft.Azure.Management.KeyVault.Fluent.IKey>> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IKey, KeyItem>.LoadPageWithWrapModelAsync(
                c => vault.Client.GetKeyVersionsAsync(vault.VaultUri, Name, null, c),
                vault.Client.GetKeyVersionsNextAsync,
                async (item, c) =>
                {
                    var bundle = await vault.Client.GetKeyAsync(item.Identifier.Identifier, c);
                    return new KeyImpl(bundle.KeyIdentifier.Name, bundle, vault);
                }, true, cancellationToken);
        }

        ///GENMHASH:A24DEA7416E3C63740F762CB203870B1:FC9FA12503FF387652EDECA6C4BCF3C7
        public async Task<byte[]> SignAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.SignAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, digest, cancellationToken);
            return result.Result;
        }

        ///GENMHASH:3F48ED60CF387C84267B437D8556ADE8:F0ED3CD3D9620D6ECF99FF69A68F22A2
        public async Task<byte[]> WrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.WrapKeyAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, key, cancellationToken);
            return result.Result;
        }

        ///GENMHASH:EC3E3FD471B61CC3A76CA417659849DB:F53D9841C2432144FB7FEDD4CDBFD5F9
        public async Task<byte[]> EncryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.EncryptAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, content, cancellationToken);
            return result.Result;
        }

        ///GENMHASH:D3DFB0D2185AF1F41A37363CE2556419:50116362EC57A25887D53D2FE0E43FFF
        public byte[] Sign(JsonWebKeySignatureAlgorithm algorithm, params byte[] digest)
        {
            return Extensions.Synchronize(() => SignAsync(algorithm, digest));
        }

        ///GENMHASH:4E7230F406919F8A99848F96940D36B7:E623E8B0FB39A7ECCB38096BFEE3AF9E
        public async Task<byte[]> UnwrapKeyAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.UnwrapKeyAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, key, cancellationToken);
            return result.Result;
        }

        ///GENMHASH:BF064975B37538E2EBE27D3224A7A39B:719F78BC1EF0A764933A0DD78CB7245A
        public async Task<byte[]> BackupAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.BackupKeyAsync(vault.VaultUri, Name, cancellationToken);
            return result.Value;
        }

        ///GENMHASH:F94155EAAB3BBA02F08ABD3831066F4B:60CD909C47A91EAFE71643C31F1B325C
        public async Task<byte[]> DecryptAsync(JsonWebKeyEncryptionAlgorithm algorithm, byte[] content, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await vault.Client.DecryptAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, content, cancellationToken);
            return result.Result;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:695605B4CA55F648453EEFC4352B1130
        protected async override Task<Microsoft.Azure.KeyVault.Models.KeyBundle> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await vault.Client.GetKeyAsync(Inner.KeyIdentifier.Identifier, cancellationToken);
        }

        ///GENMHASH:37F76E5729DFBD562C6418F2290EBC6E:D1063FA725E63DC403D7BF310EE5DC43
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> ListVersions()
        {
            return Extensions.Synchronize(() => vault.Client.GetKeyVersionsAsync(vault.VaultUri, Name))
                    .AsContinuousCollection(link => Extensions.Synchronize(() => vault.Client.GetKeyVersionsNextAsync(link)))
                    .Select(item => Extensions.Synchronize(() => vault.Client.GetKeyAsync(item.Identifier.Identifier)))
                    .Select(bundle => new KeyImpl(bundle.KeyIdentifier.Name, bundle, vault));
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:962949D4060A8D0ABA177599EE60802D
        public KeyImpl WithTags(IDictionary<string, string> tags)
        {
            if (IsInCreateMode())
            {
                if (createKeyRequest != null)
                {
                    createKeyRequest.Tags = (Dictionary<string, string>)tags;
                }
                else
                {
                    importKeyRequest.Tags = (Dictionary<string, string>)tags;
                }
            }
            else
            {
                updateKeyRequest.Tags = (Dictionary<string, string>)tags;
            }
            return this;
        }

        ///GENMHASH:2496E3A1CFF32BBA877292D9CB043164:1FA0DB9335D2EA92B76A8DC9AC7D00A8
        public KeyImpl WithKeySize(int size)
        {
            createKeyRequest.KeySize = size;
            return this;
        }

        ///GENMHASH:102FF34ED866CF06776958C1FF6FD15B:85AD7F5C4AA6206BF6C989C0A5E03257
        public bool Managed()
        {
            return Inner.Managed ?? false;
        }

        ///GENMHASH:952553F84008D803939E0FB7F6B133FA:E28336CDDF11604C7DE06289AFF883A6
        public byte[] Encrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            return Extensions.Synchronize(() => EncryptAsync(algorithm, content));
        }

        ///GENMHASH:941A212532B2484985C0C67B55878584:EEEF6B4C0E5650CF744C9BEDCB5F5483
        public bool Verify(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, params byte[] signature)
        {
            return Extensions.Synchronize(() => VerifyAsync(algorithm, digest, signature));
        }

        ///GENMHASH:36F02393B4CD5B681247EB8843168873:F25F1A6C5841A6F39CB361877DC604BF
        public KeyImpl WithHsm(bool isHsm)
        {
            importKeyRequest.IsHsm = isHsm;
            return this;
        }

        ///GENMHASH:3A4433EF829CAEE497A4F27E732D49F9:D149CDD00015F48C6E468E742B574FF0
        public Microsoft.Azure.KeyVault.WebKey.JsonWebKey JsonWebKey()
        {
            return Inner.Key;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:EFE12610EA19B6BA5961AAC9B849F447
        public string Id()
        {
            if (Inner.KeyIdentifier == null)
            {
                return null;
            }
            return Inner.KeyIdentifier.Identifier;
        }

        ///GENMHASH:42ACA509E5FCC7BF9DCE9A7C902F9A09:2412331D2A339999368F53668E4D0D10
        public byte[] UnwrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            return Extensions.Synchronize(() => UnwrapKeyAsync(algorithm, key));
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:5983BB56B6190FDBBCF28E6CF2A5422F
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IKey key = this;
            if (createKeyRequest != null || importKeyRequest != null)
            {
                key = await CreateRawAsync(cancellationToken);
            }
            if (updateKeyRequest != null)
            {
                await vault.Client.UpdateKeyAsync(
                    Inner.KeyIdentifier.Identifier,
                    updateKeyRequest.KeyOperations.Select(ops => ops.Value).ToArray(),
                    updateKeyRequest.KeyAttributes,
                    updateKeyRequest.Tags,
                    cancellationToken);
            }
            await RefreshAsync(cancellationToken);
            createKeyRequest = null;
            importKeyRequest = null;
            updateKeyRequest = new UpdateKeyRequest
            {
                VaultBaseUrl = vault.VaultUri,
                KeyName = Name
            };
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:2F65E1EAF1103D36E64A2275FFA6F81F
        public async override Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode())
            {
                return await CreateRawAsync(cancellationToken);
            }
            else
            {
                return await UpdateResourceAsync(cancellationToken);
            }
        }

        private async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> CreateRawAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (createKeyRequest != null)
            {
                SetInner(await vault.Client.CreateKeyAsync(
                    createKeyRequest.VaultBaseUrl,
                    createKeyRequest.KeyName,
                    createKeyRequest.KeyType.Value,
                    createKeyRequest.KeySize,
                    createKeyRequest.KeyOperations.Select(ops => ops.Value).ToList(),
                    createKeyRequest.KeyAttributes,
                    createKeyRequest.Tags,
                    curve: null,
                    cancellationToken: cancellationToken));

                createKeyRequest = null;
                updateKeyRequest = new UpdateKeyRequest
                {
                    VaultBaseUrl = vault.VaultUri,
                    KeyName = Name
                };
            }
            else
            {
                SetInner(await vault.Client.ImportKeyAsync(
                    importKeyRequest.VaultBaseUrl,
                    importKeyRequest.KeyName,
                    importKeyRequest.Key,
                    importKeyRequest.IsHsm,
                    importKeyRequest.KeyAttributes,
                    importKeyRequest.Tags,
                    cancellationToken));
                importKeyRequest = null;
                updateKeyRequest = new UpdateKeyRequest
                {
                    VaultBaseUrl = vault.VaultUri,
                    KeyName = Name
                };
            }
            return this;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:5BDEAAEC54B8618E2AD31C058EFEDFDD
        public bool IsInCreateMode()
        {
            return Id() == null;
        }

        ///GENMHASH:98060D1B7FD52C7724F36876E3AA8CC9:C3E882EB9B8E9BD6C5F7A74CD50D69D0
        internal KeyImpl(string name, KeyBundle innerObject, IVault vault)
            : base(name, innerObject)
        {
            this.vault = vault;
            updateKeyRequest = new UpdateKeyRequest
            {
                VaultBaseUrl = vault.VaultUri,
                KeyName = Name
            };
        }

        ///GENMHASH:53615EE168ABC0D3B17DDF1E300061BE:E0088DEF3B6727A81BFDBF63F112FD97
        public byte[] WrapKey(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] key)
        {
            return Extensions.Synchronize(() => WrapKeyAsync(algorithm, key));
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:7AB4F0903C94E4BB1CF29874B5530F1C
        public IReadOnlyDictionary<string, string> Tags()
        {
            return new ReadOnlyDictionary<string, string>(Inner.Tags);
        }

        ///GENMHASH:3D1F4F9B31A1E4FAB317EE4E0C5C9528:5CADE1B284DC5DE1B854039B12712163
        public KeyImpl WithLocalKeyToImport(Microsoft.Azure.KeyVault.WebKey.JsonWebKey key)
        {
            importKeyRequest = new ImportKeyRequest
            {
                VaultBaseUrl = vault.VaultUri,
                KeyName = Name,
                Key = key
            };
            return this;
        }

        ///GENMHASH:7224D401F0FF578F9440423240845D61:41A3C41764F15BC0C463D26AC61868CA
        public KeyImpl WithKeyTypeToCreate(JsonWebKeyType keyType)
        {
            createKeyRequest = new CreateKeyRequest
            {
                VaultBaseUrl = vault.VaultUri,
                KeyName = Name,
                KeyType = keyType
            };
            return this;
        }

        ///GENMHASH:F8981C320EC895546CAD8EF73E3DACB1:FA255B6DF9DFB304BFA5E3A3E7D37104
        public KeyImpl WithKeyOperations(IList<JsonWebKeyOperation> keyOperations)
        {
            if (IsInCreateMode())
            {
                createKeyRequest.KeyOperations = (List<JsonWebKeyOperation>)keyOperations;
            }
            else
            {
                updateKeyRequest.KeyOperations = (List<JsonWebKeyOperation>)keyOperations;
            }
            return this;
        }

        ///GENMHASH:E8E1F2F9C703FE40776D6F7DF2DD1E68:D8742138DF32E8225B74BEBFD0186A34
        public KeyImpl WithKeyOperations(params JsonWebKeyOperation[] keyOperations)
        {
            return WithKeyOperations(new List<JsonWebKeyOperation>(keyOperations));
        }

        ///GENMHASH:9CC87213BAB687D1788EA9F4C2B726E8:33C4441D7A92CE4AEBE93672F3F8EBD8
        public KeyAttributes Attributes()
        {
            return Inner.Attributes;
        }

        ///GENMHASH:FEE492F5B9F2CCFE2EBA87182AF9BB3C:A60DF4005777D357B57ED714179A311F
        public async Task<bool> VerifyAsync(JsonWebKeySignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await vault.Client.VerifyAsync(Inner.KeyIdentifier.Identifier, algorithm.Value, digest, signature, cancellationToken);
        }

        ///GENMHASH:68E43175FD1572C39912FBCB105BF169:0533E9B624D1DC48D9B75883F9A63688
        public byte[] Decrypt(JsonWebKeyEncryptionAlgorithm algorithm, params byte[] content)
        {
            return Extensions.Synchronize(() => DecryptAsync(algorithm, content));
        }
    }
}