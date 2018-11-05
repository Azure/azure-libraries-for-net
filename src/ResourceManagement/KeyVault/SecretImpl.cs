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
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.KeyVault;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for Vault and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLlNlY3JldEltcGw=
    internal partial class SecretImpl :
        CreatableUpdatable<ISecret, SecretBundle, SecretImpl, IHasId, IUpdate>,
        ISecret,
        IDefinition,
        IUpdate
    {
        private IVault vault;
        private SetSecretRequest setSecretRequest;
        private UpdateSecretRequest updateSecretRequest;
        ///GENMHASH:AFCF54960F557DFD8C6A8457EFAA9FD7:0C9DCA023B95F799C3FD4D6189ABC2DC
        public SecretImpl WithAttributes(Attributes attributes)
        {
            setSecretRequest.SecretAttributes = (SecretAttributes)attributes;
            updateSecretRequest.SecretAttributes = (SecretAttributes)attributes;
            return this;
        }

        ///GENMHASH:D4A7A02E673639C444C53A8D52EFA5E3:B22477C398F2CBD1F600FB646FB9D257
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ISecret, SecretItem>.LoadPageWithWrapModelAsync(
                c => vault.Client.GetSecretVersionsAsync(vault.VaultUri, Name, null, c),
                vault.Client.GetSecretVersionsNextAsync,
                async (item, c) =>
                {
                    var bundle = await vault.Client.GetSecretAsync(item.Identifier.Identifier, c);
                    return new SecretImpl(bundle.SecretIdentifier.Name, bundle, vault);
                }, true, cancellationToken);
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:5BDEAAEC54B8618E2AD31C058EFEDFDD
        public bool IsInCreateMode()
        {
            return Id() == null;
        }

        ///GENMHASH:928A0E988013007B8FF0C01FEA6EC729:A078B007BAB437E799A89A7EFFC1B30F
        public string Kid()
        {
            return Inner.Kid;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:7BB7EB283B512F150F5E50263808D3D3
        public SecretImpl WithVersion(string version)
        {
            updateSecretRequest.SecretVersion = version;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:74DB1877CF76B1176F40C6A6991EF568
        protected async override Task<Microsoft.Azure.KeyVault.Models.SecretBundle> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await vault.Client.GetSecretAsync(Id(), cancellationToken);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:7AB4F0903C94E4BB1CF29874B5530F1C
        public IReadOnlyDictionary<string, string> Tags()
        {
            return new ReadOnlyDictionary<string, string>(Inner.Tags);
        }

        ///GENMHASH:37F76E5729DFBD562C6418F2290EBC6E:153684EF1C070D6A9683BA9C173DC927
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> ListVersions()
        {
            return Extensions.Synchronize(() => vault.Client.GetSecretVersionsAsync(vault.VaultUri, Name))
                    .AsContinuousCollection(link => Extensions.Synchronize(() => vault.Client.GetSecretVersionsNextAsync(link)))
                    .Select(item => Extensions.Synchronize(() => vault.Client.GetSecretAsync(item.Identifier.Identifier)))
                    .Select(bundle => new SecretImpl(bundle.SecretIdentifier.Name, bundle, vault));
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:EB0F52C4D98BB007BEF4118B51D50750
        public SecretImpl WithTags(IDictionary<string, string> tags)
        {
            setSecretRequest.Tags = (Dictionary<string, string>)tags;
            updateSecretRequest.Tags = (Dictionary<string, string>)tags;
            return this;
        }

        ///GENMHASH:743674BDED1D329950DDBCB5D7E876E0:D0DF29AB717FE4F5696B6850352CF76F
        public SecretImpl WithValue(string value)
        {
            setSecretRequest = new SetSecretRequest
            {
                VaultBaseUrl = vault.VaultUri,
                SecretName = Name,
                Value = value
            };
            return this;
        }

        ///GENMHASH:2A836929F85CF9F0E4B71283C422B775:182D2D7996886C82E674FB6B6D129493
        public SecretImpl WithContentType(string contentType)
        {
            setSecretRequest.ContentType = contentType;
            updateSecretRequest.ContentType = contentType;
            return this;
        }

        ///GENMHASH:102FF34ED866CF06776958C1FF6FD15B:85AD7F5C4AA6206BF6C989C0A5E03257
        public bool Managed()
        {
            return Inner.Managed ?? false;
        }

        ///GENMHASH:D4F352220A93EA5AA29C8B5E4597D85A:C23C77328A8E0D7CC1FB12BB56B5BE22
        internal SecretImpl(string name, SecretBundle innerObject, IVault vault)
            : base(name, innerObject)
        {
            this.vault = vault;
            this.updateSecretRequest = new UpdateSecretRequest
            {
                VaultBaseUrl = vault.VaultUri,
                SecretName = name
            };
        }

        ///GENMHASH:9CC87213BAB687D1788EA9F4C2B726E8:33C4441D7A92CE4AEBE93672F3F8EBD8
        public SecretAttributes Attributes()
        {
            return Inner.Attributes;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:A779AD9340BD624EF5C1E0B1A3B5F2AF
        private async Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ISecret secret = this;
            if (setSecretRequest != null)
            {
                secret = await CreateRawAsync(cancellationToken);
            }
            if (updateSecretRequest != null)
            {
                await vault.Client.UpdateSecretAsync(
                    secret.Inner.SecretIdentifier.Identifier,
                    updateSecretRequest.ContentType,
                    updateSecretRequest.SecretAttributes,
                    updateSecretRequest.Tags,
                    cancellationToken);
            }
            await RefreshAsync(cancellationToken);
            setSecretRequest = null;
            updateSecretRequest = new UpdateSecretRequest
            {
                VaultBaseUrl = vault.VaultUri,
                SecretName = Name
            };
            return this;
        }

        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:8C13F3C8A63442B189D1C7B0529DB891
        public string Value()
        {
            return Inner.Value;
        }

        ///GENMHASH:F86207AEECF64645DBEF0C002CC9BB6C:007D049863090989FCAF4C782FDD499C
        public string ContentType()
        {
            return Inner.ContentType;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F12FC594E9C15DBC3FFFACD9CF4D07E0
        public async override Task<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
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

        private async Task<ISecret> CreateRawAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await vault.Client.SetSecretAsync(
                setSecretRequest.VaultBaseUrl,
                setSecretRequest.SecretName,
                setSecretRequest.Value,
                setSecretRequest.Tags,
                setSecretRequest.ContentType,
                setSecretRequest.SecretAttributes,
                cancellationToken));
            setSecretRequest = null;
            updateSecretRequest = new UpdateSecretRequest
            {
                VaultBaseUrl = vault.VaultUri,
                SecretName = Name
            };
            return this;
        }
    }
}