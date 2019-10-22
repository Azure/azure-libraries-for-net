// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for DiagnosticSettings.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uRGlhZ25vc3RpY1NldHRpbmdzSW1wbA==
    internal partial class DiagnosticSettingsImpl :
        CreatableResources<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting, Models.DiagnosticSettingImpl, Models.DiagnosticSettingsResourceInner>,
        IDiagnosticSettings
    {
        private MonitorManager manager;

        ///GENMHASH:8F42FF45F211D665F09616A4BB923622:D544D70B59C64F2C67EC02DE16CBAEF6
        internal DiagnosticSettingsImpl(MonitorManager manager)
        {
            this.manager = manager;
        }

        ///GENMHASH:134130346F52F3BA13BAB0E9B3142F5D:9B462FF8D333ADC7CC79D4259C51E612
        private string GetNameFromSettingsId(string diagnosticSettingId)
        {
            var resourceId = GetResourceIdFromSettingsId(diagnosticSettingId);
            return diagnosticSettingId.Substring(resourceId.Length + DiagnosticSettingImpl.DiagnosticSettingsUri.Length);
        }

        ///GENMHASH:CABF94FF0395BF95E01F344ECEA8DD19:5A4C5ADEF80F3A357A8C80716593389F
        private string GetResourceIdFromSettingsId(string diagnosticSettingId)
        {
            if (diagnosticSettingId == null)
            {
                throw new ArgumentNullException("diagnosticSettingId");
            }
            int dsIdx = diagnosticSettingId.LastIndexOf(DiagnosticSettingImpl.DiagnosticSettingsUri);
            if (dsIdx == -1)
            {
                throw new ArgumentOutOfRangeException("resourceId", "Parameter 'resourceId' does not represent a valid Diagnostic Settings resource Id [" + diagnosticSettingId + "].");
            }

            return diagnosticSettingId.Substring(0, dsIdx);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:163EFE5675FB6F84E8D6F02C768400C9
        protected override DiagnosticSettingImpl WrapModel(string name)
        {
            return new DiagnosticSettingImpl(name, new DiagnosticSettingsResourceInner(), this.Manager());
        }

        ///GENMHASH:FB1CD4839ED8771804FBC3DDC7F8E7B9:69B30B9652C01411572AC4641D07BA72
        protected override IDiagnosticSetting WrapModel(DiagnosticSettingsResourceInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new DiagnosticSettingImpl(inner.Name, inner, this.Manager());
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public DiagnosticSettingImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:E9A558087633C282010BFC4764EF5FAF:85E4C75E024BA79BE0EA3617BB27408A
        public void Delete(string resourceId, string name)
        {
            Extensions.Synchronize(() => this.Manager().Inner.DiagnosticSettings.DeleteAsync(resourceId, name));
        }

        ///GENMHASH:3F66CB38737E789E83D4F94D3B9FA876:281C875F64AD7313076045BE36EC88DF
        public async Task DeleteAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager().Inner.DiagnosticSettings.DeleteAsync(resourceId, name);
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:B06DA739470DA7DF075EBF332FC1EE74
        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager().Inner.DiagnosticSettings.DeleteAsync(GetResourceIdFromSettingsId(id), GetNameFromSettingsId(id));
        }

        ///GENMHASH:8B5750E68FCC626D3009EA1EAACB3C16:2EADE9AFF847FC5E71953552E0B422B2
        public void DeleteByIds(IList<string> ids)
        {
            if (ids != null && ids.Any())
            {
                Extensions.Synchronize(() => this.DeleteByIdsAsync(ids));
            }
        }

        ///GENMHASH:F65FF3868FDEB2B4896429AE1A0F14F4:3B420C74B8FAF3ADE60DFAA3E8131270
        public void DeleteByIds(params string[] ids)
        {
            this.DeleteByIds(ids.ToList());
        }

        ///GENMHASH:782853D3A86D961975AF25BD353144CE:7E1E26967EA21D2292AE7CA3FDE80667
        public async Task<System.Collections.Generic.IEnumerable<string>> DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ids == null || ids.Count == 0)
            {
                return new List<string>();
            }

            List<string> ids1 = new List<string>();
            var tasks = new List<Task>();

            foreach (var id in ids)
            {
                tasks.Add(Task.Run(async () =>
                                {
                                    try
                                    {
                                        await this.DeleteByIdAsync(id, cancellationToken);
                                    }
                                    catch (CloudException)
                                    { }
                                    ids1.Add(id);
                                }));
            }

            await Task.WhenAll(tasks);
            return ids1;
        }

        ///GENMHASH:6761F083A3838E34703AD0305B873679:E05AE73A1CA90E964ED86C07093D463F
        public async Task<System.Collections.Generic.IEnumerable<string>> DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DeleteByIdsAsync(ids.ToList(), cancellationToken);
        }

        ///GENMHASH:0028F8F0A2E5244EB0F23F801D9E3794:0EE1437441A0EC3E7D6B062243FD53FE
        public IDiagnosticSetting Get(string resourceId, string name)
        {
            return WrapModel(Extensions.Synchronize(() => this.Manager().Inner.DiagnosticSettings.GetAsync(resourceId, name)));
        }

        ///GENMHASH:E98B9684E8556B649D62C9DCD0FCEF08:06ACC1EA4F80E83C8F995EC4B0D10B1C
        public async Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> GetAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager().Inner.DiagnosticSettings.GetAsync(resourceId, name, cancellationToken);
            return WrapModel(inner);
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:B11BFD808B0E3CE9D5770816A8C065F9
        public IDiagnosticSetting GetById(string id)
        {
            return WrapModel(Extensions.Synchronize(() => this.Inner.GetAsync(GetResourceIdFromSettingsId(id), GetNameFromSettingsId(id))));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:DE173379F3DE37FAB9956D7654F0028E
        public async Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Inner.GetAsync(GetResourceIdFromSettingsId(id), GetNameFromSettingsId(id));
            return WrapModel(inner);
        }

        ///GENMHASH:65C6D9D14B657B62E2B6100438DFBE29:B7D020751FD1E165FF7654847ECD866D
        public IDiagnosticSettingsCategory GetCategory(string resourceId, string name)
        {
            return Extensions.Synchronize(() => this.GetCategoryAsync(resourceId, name));
        }

        ///GENMHASH:1C9F6DD6EA7B8E8FFE1106EB8229527D:C62C8864A8770A8F91F0CE273414FDEA
        public async Task<Models.IDiagnosticSettingsCategory> GetCategoryAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager().Inner.DiagnosticSettingsCategory.GetAsync(resourceId, name, cancellationToken);
            return new DiagnosticSettingsCategoryImpl(inner);
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:633429B480838B3F157B368C5C709780
        public IDiagnosticSettingsOperations Inner
        {
            get
            {
                return this.manager.Inner.DiagnosticSettings;
            }
        }

        ///GENMHASH:ADB7D3AA7EC183D335762850C5DBCB9F:A34944C131D431AA80ECE0F365C709D4
        public IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> ListByResource(string resourceId)
        {
            return Extensions.Synchronize(() => this.ListByResourceAsync(resourceId));
        }

        ///GENMHASH:8BB42E8B013293EB00FF395576B1B45A:F0C7D7EDD420F2A8AAFF0CA0FAE8B675
        public async Task<IEnumerable<IDiagnosticSetting>> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager().Inner.DiagnosticSettings.ListAsync(resourceId);
            if (result == null)
            {
                return null;
            }
            return WrapList(result.Value);
        }

        ///GENMHASH:6773694457EB5AB923F1D7F4AA07EFC6:F85185486C067ACB5E3790B679F38FF3
        public IReadOnlyList<Models.IDiagnosticSettingsCategory> ListCategoriesByResource(string resourceId)
        {
            return Extensions.Synchronize(() => this.ListCategoriesByResourceAsync(resourceId));
        }

        ///GENMHASH:B6C36883DA8E46E8851B5D3250C20FBF:76FC29565C375D90E1409742BE02D05E
        public async Task<IReadOnlyList<Models.IDiagnosticSettingsCategory>> ListCategoriesByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager().Inner.DiagnosticSettingsCategory.ListAsync(resourceId, cancellationToken);
            return result.Value.Select(i => new DiagnosticSettingsCategoryImpl(i)).ToList();
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public MonitorManager Manager()
        {
            return this.manager;
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }
    }
}