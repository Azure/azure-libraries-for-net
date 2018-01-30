// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Keyvault.Fluent
{
    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
    internal partial class VaultsImpl  :
        TopLevelModifiableResources<IVault, VaultImpl, VaultInner, IVaultsOperations, IKeyVaultManager>,
        IVaults
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;

        ///GENMHASH:B150A08031FE64095583576847133217:8935634111618393DD8A78F9B6DBDFBA
        internal VaultsImpl(IKeyVaultManager keyVaultManager, IGraphRbacManager graphRbacManager, string tenantId)
            : base(keyVaultManager.Inner.Vaults, keyVaultManager)
        {
            this.graphRbacManager = graphRbacManager;
            this.tenantId = tenantId;
        }

        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:74D523E66AA62B2B4DECAB1282A54E4D
        public IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IVault> ListByResourceGroup(string groupName)
        {
            //$ return wrapList(this.Inner.ListByResourceGroup(groupName));

            return null;
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:136D659EB836ECA199ED5D69D4606314
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(resourceGroupName, name).ToCompletable();

            return null;
        }

        ///GENMHASH:9D38835F71DF2C39BF88CBB588420D30:FBFA0902403A234112A18515EE78DB0D
        public async Task DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(groupName, name).ToCompletable();

            return null;
        }

        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:2808331D68C2B87EED057725633BDDD5
        public async Task<Microsoft.Azure.Management.KeyVault.Fluent.IVault> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(this.Inner.ListByResourceGroupAsync(resourceGroupName));

            return null;
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:4593F1A2996AA2D0219FCEB42EA28D41
        protected async Task<Microsoft.Azure.Management.KeyVault.Fluent.Models.VaultInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.GetByResourceGroupAsync(resourceGroupName, name);

            return null;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:913702868132D01F4C836BBF3499B8CE
        public VaultImpl Define(string name)
        {
            return WrapModel(name)
                .WithSku(SkuName.Standard)
                .WithEmptyAccessPolicy();
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:15E2E01BC88FA6B06E6CBBCFC1371788
        protected override VaultImpl WrapModel(string name)
        {
            VaultInner inner = new VaultInner()
            {
                Properties = new VaultProperties()
                {
                    TenantId = Guid.Parse(tenantId)
                }
            };
            return new VaultImpl(
                name,
                inner,
                Manager,
                graphRbacManager);
        }

        ///GENMHASH:CA260E89048F01F05DD7D13D870D6A8F:E833FC60B5F2BCB0CBB9985629CBA229
        protected override IVault WrapModel(VaultInner vaultInner)
        {
            return new VaultImpl(
                vaultInner.Name,
                vaultInner,
                Manager,
                graphRbacManager);
        }
    }
}