// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// The Azure  RedisPatchSchedule wrapper class implementation.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzUGF0Y2hTY2hlZHVsZUltcGw=
    internal partial class RedisPatchScheduleImpl  :
        ExternalChildResource<IRedisPatchSchedule, RedisPatchScheduleInner, IRedisCache, RedisCacheImpl>,
        IRedisPatchSchedule
    {
        string IExternalChildResource<IRedisPatchSchedule, IRedisCache>.Id => this.Id();

        ///GENMHASH:5A4320F5ADD7E398AF7B0806169E4698:95CDFB0CE611CB49B83B558A1D6C0C28
        internal  RedisPatchScheduleImpl(string name, RedisCacheImpl parent, RedisPatchScheduleInner innerObject)
            : base(GetChildName(name, parent.Name), parent, innerObject)
        {
        }

        ///GENMHASH:7B91F973B41CF71CC40E247891C84C41:EB1CA865901A76AF320202ED1FBA1CF0
        private static string GetChildName(string name, string parentName)
        {
            if (name != null && name.IndexOf("/") != -1)
            {
                // Patch Schedule name consist of "parent/child" name syntax but delete/update/get should be called only on child name
                return name.Substring(parentName.Length + 1);
            }
            return name;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:20B5B6DD037FF01C63C9EC8EDAC2737D
        protected async override Task<Models.RedisPatchScheduleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Parent.Manager.Inner.PatchSchedules.GetAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:9BE00DCA66796357D2F6DBC611B42A48
        public async Task<Models.IRedisPatchSchedule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Parent.Manager.Inner.PatchSchedules.CreateOrUpdateAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Inner.ScheduleEntries,
                cancellationToken);
            this.SetInner(inner);

            return this;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:D5C00606E3B93C13F119258FE7B03589
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Parent.Manager.Inner.PatchSchedules.DeleteAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                cancellationToken);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:20094867B1F32BCEE01B12E02A61C335:A4F94F790DA42D1924E66239449422B4
        public IReadOnlyList<Models.ScheduleEntry> ScheduleEntries()
        {
            return this.Inner.ScheduleEntries.Select(i => new ScheduleEntry(i)).ToList();
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Models.IRedisPatchSchedule> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        // Catch-up methods
        public async override Task<IRedisPatchSchedule> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        public async override Task<IRedisPatchSchedule> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }
    }
}