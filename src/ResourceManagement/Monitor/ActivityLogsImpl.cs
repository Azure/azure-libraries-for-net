// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  ActivityLogs.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWN0aXZpdHlMb2dzSW1wbA==
    internal partial class ActivityLogsImpl :
        IActivityLogs,
        IActivityLogsQueryDefinition
    {
        private bool filterForTenant;
        private string filterString;
        private MonitorManager myManager;
        private DateTime queryEndTime;
        private DateTime queryStartTime;
        private HashSet<string> responsePropertySelector;

        ///GENMHASH:657DEC775ABB08A370F0E7B424DF2C55:2F1B9317851B2A1DD48CC2ED2AA07143
        internal ActivityLogsImpl(MonitorManager monitorManager)
        {
            this.myManager = monitorManager;
            this.responsePropertySelector = new HashSet<string>();
            this.filterString = "";
            this.filterForTenant = false;
        }

        ///GENMHASH:024411138CED6DE639DA12D726BD0621:834C35BC52D5E712B2EE3999934B62E5
        private string CreatePropertyFilter()
        {
            var propertyFilter = string.Join(",", this.responsePropertySelector.OrderBy(o => o));
            if (string.IsNullOrWhiteSpace(propertyFilter))
            {
                propertyFilter = null;
            }
            return propertyFilter;
        }

        ///GENMHASH:6F01E78E35D7E5AB58994AE36EDFAB4A:B883F859C5ECB2870CD846D5172095F9
        private string GetOdataFilterString()
        {
            // 2019/11/08 monitor service only accepts UTC time.
            // https://github.com/Azure/azure-libraries-for-net/issues/511
            return string.Format("eventTimestamp ge '{0}' and eventTimestamp le '{1}'",
                this.queryStartTime.ToUniversalTime().ToString("o"),
                this.queryEndTime.ToUniversalTime().ToString("o"));
        }

        ///GENMHASH:66A358446BB2F4C0D4EA5FC8537BD415:7FDA4951E189B2016B3D2310EE5F3420
        private IEnumerable<IEventData> ListEventData(string filter)
        {
            return Extensions.Synchronize(() => this.Inner.ListAsync(filter, CreatePropertyFilter()))
                         .AsContinuousCollection(link => Extensions.Synchronize(() => this.Inner.ListNextAsync(link)))
                         .Select(inner => new EventDataImpl(inner));
        }

        ///GENMHASH:917C4A9B611CD52A7033C2682FC82B65:822E0FD9095BE313AADE1B493098C7C0
        private async Task<IPagedCollection<IEventData>> ListEventDataAsync(string filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IEventData, EventData>.LoadPage(
                async (cancellation) => await Inner.ListAsync(filter, CreatePropertyFilter(), cancellation),
                async (nextLink, cancellation) => await Inner.ListNextAsync(nextLink, cancellation),
                (inner) => new EventDataImpl(inner),
                true,
                cancellationToken);
        }

        ///GENMHASH:EA6A4C027BF47CC52B95F02B557B4A40:DC8B9F137B1D502452AF2DD36012BA63
        private IEnumerable<IEventData> ListEventDataForTenant(string filter)
        {
            return Extensions.Synchronize(() => this.Manager().Inner.TenantActivityLogs.ListAsync(filter, CreatePropertyFilter()))
             .AsContinuousCollection(link => Extensions.Synchronize(() => this.Manager().Inner.TenantActivityLogs.ListNextAsync(link)))
             .Select(inner => new EventDataImpl(inner));
        }

        ///GENMHASH:8FC9B471C1A78BF1D3EBC410128DE0FA:A581C3311414879F15C3BB031BF1F5A5
        private async Task<IPagedCollection<IEventData>> ListEventDataForTenantAsync(string filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IEventData, EventData>.LoadPage(
                async (cancellation) => await this.Manager().Inner.TenantActivityLogs.ListAsync(filter, CreatePropertyFilter(), cancellationToken),
                async (nextLink, cancellation) => await this.Manager().Inner.TenantActivityLogs.ListNextAsync(nextLink, cancellation),
                (inner) => new EventDataImpl(inner),
                true,
                cancellationToken);
        }

        ///GENMHASH:914F5848297276F1D8C78263F5BE935D:295B4DBA4EF3CDAC9D498BAF8DAB131F
        public IWithEventDataStartTimeFilter DefineQuery()
        {
            this.responsePropertySelector.Clear();
            this.filterString = "";
            this.filterForTenant = false;
            return this;
        }

        ///GENMHASH:8E798D06F036643A781434270F4F347E:6ED95D1C0D7030224A0A5556D72F0018
        public ActivityLogsImpl EndsBefore(DateTime endTime)
        {
            this.queryEndTime = endTime;
            return this;
        }

        ///GENMHASH:6E40675090A7C5A5E2DC401C96A422D5:D9CC57125A6433E06763A35AA50F44DF
        public IEnumerable<Models.IEventData> Execute()
        {
            if (this.filterForTenant)
            {
                return ListEventDataForTenant(GetOdataFilterString() + this.filterString + " and eventChannels eq 'Admin, Operation'");
            }
            return ListEventData(GetOdataFilterString() + this.filterString);
        }

        ///GENMHASH:28267C95BE469468FC3C62D4CF4CCA7C:F7D4D3D83965F2CAF36159C081016C40
        public async Task<IPagedCollection<IEventData>> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (this.filterForTenant)
            {
                return await ListEventDataForTenantAsync(GetOdataFilterString() + this.filterString + " and eventChannels eq 'Admin, Operation'");
            }
            return await ListEventDataAsync(GetOdataFilterString() + this.filterString, cancellationToken);
        }

        ///GENMHASH:F9AA0F78087650E68B1DEE08F26A8EC9:51829AEAB69FA856409258ADAF5B2B08
        public ActivityLogsImpl FilterAtTenantLevel()
        {
            this.filterForTenant = true;
            return this;
        }

        ///GENMHASH:6C04BF10CFC9018CA61EC48D69CCFFC4:D91695419640E79A341E8B6E40B9C518
        public ActivityLogsImpl FilterByCorrelationId(string correlationId)
        {
            this.filterString = string.Format(" and correlationId eq '{0}'", correlationId);
            return this;
        }

        ///GENMHASH:F53D539E431A5CEE4CC1B076D4C77610:BFADD6FEAFCB5CD377ED3E9C10E4C678
        public ActivityLogsImpl FilterByResource(string resourceId)
        {
            this.filterString = String.Format(" and resourceUri eq '{0}'", resourceId);
            return this;
        }

        ///GENMHASH:CF28D7A5A1EBEBDAA73B8839CA5F9631:30133FA4E893BDEF196AC52E4D00AD6F
        public ActivityLogsImpl FilterByResourceGroup(string resourceGroupName)
        {
            this.filterString = string.Format(" and resourceGroupName eq '{0}'", resourceGroupName);
            return this;
        }

        ///GENMHASH:4E25211860404EE8E2BAF86972E02D5D:151A4F9B8C46D2B66AE4C6FF9A546B84
        public ActivityLogsImpl FilterByResourceProvider(string resourceProviderName)
        {
            this.filterString = string.Format(" and resourceProvider eq '{0}'", resourceProviderName);
            return this;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:E24F3ED3849126FC0026B1F5D9B9CE70
        public IActivityLogsOperations Inner
        {
            get
            {
                return this.myManager.Inner.ActivityLogs;
            }
        }

        ///GENMHASH:BECC31966AF171B5D462326D3806A2C9:2DF33786C02E42C345D1AB03B3DE2FD6
        public IReadOnlyList<Models.ILocalizableString> ListEventCategories()
        {
            return Extensions.Synchronize(() => ListEventCategoriesAsync());
        }

        ///GENMHASH:FDF86E3C0954DF96F806851F8D0E9022:63C88E9F65C9F2F07A5D1B56DC85A9E3
        public async Task<IReadOnlyList<Models.ILocalizableString>> ListEventCategoriesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await this.Manager().Inner.EventCategories.ListAsync(cancellationToken))
                    .Select(i => new LocalizableStringImpl(i))
                    .ToList();
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:363E4D62FCA795A36F9CB60513C86AFA
        public MonitorManager Manager()
        {
            return this.myManager;
        }

        ///GENMHASH:466C9D6BF16AFC7E5643C50D8BF6E937:38A64203651F9C55FF10205837F6BF41
        public ActivityLogsImpl StartingFrom(DateTime startTime)
        {
            this.queryStartTime = startTime;
            return this;
        }

        ///GENMHASH:5377F347172D86792C2D0F8ADCF6A22B:68C9E86F48D7C68955A6BCE451CAB7A5
        public ActivityLogsImpl WithAllPropertiesInResponse()
        {
            this.responsePropertySelector.Clear();
            return this;
        }

        ///GENMHASH:32EF35107E348211C3A6304CFDDF64B8:16484880324A3F804530C40A3A4891BC
        public ActivityLogsImpl WithResponseProperties(params EventDataPropertyName[] responseProperties)
        {
            this.responsePropertySelector.Clear();

            foreach (var EventDataPropertyName in responseProperties)
            {
                this.responsePropertySelector.Add(EventDataPropertyName.Value);
            }
            return this;
        }
    }
}