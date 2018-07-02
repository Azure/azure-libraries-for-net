// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using System.Net;

    /// <summary>
    /// Represents a Redis patch schedule collection associated with a Redis cache instance.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzUGF0Y2hTY2hlZHVsZXNJbXBs
    internal partial class RedisPatchSchedulesImpl :
        ExternalChildResourcesCached<RedisPatchScheduleImpl,
            IRedisPatchSchedule,
            RedisPatchScheduleInner,
            IRedisCache,
            RedisCacheImpl>
    {
        private string patchScheduleName = "default";

        ///GENMHASH:AD9917524F09AF9E9D44496728DD4F4E:42F30C4B3DBB6CE49D91EF728CBB7957
        internal  RedisPatchSchedulesImpl(RedisCacheImpl parent)
            : base (parent, "PatchSchedule")
        {
            if (parent.Id != null)
            {
                this.CacheCollection();
            }
        }

        ///GENMHASH:65D9C14D3DB321CE6E6AF5B1B86CF9BD:4E197CCA8EA0272BE0405F90C53F31D8
        internal IReadOnlyDictionary<string,Models.IRedisPatchSchedule> PatchSchedulesAsMap()
        {
            var result = new Dictionary<string, IRedisPatchSchedule>();
            foreach (var entry in this.Collection)
            {
                RedisPatchScheduleImpl schedule = entry.Value;
                result.Add(entry.Key, schedule);
            }

            return result;
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:7EDDB3D4663F077E51B9DEED8CBEA81F
        protected override IList<Microsoft.Azure.Management.Redis.Fluent.RedisPatchScheduleImpl> ListChildResources()
        {
            IPage<RedisPatchScheduleInner> retValue = null;

            try
            {
                retValue = Extensions.Synchronize(() => this.Parent.Manager.Inner.PatchSchedules.ListByRedisResourceAsync(this.Parent.ResourceGroupName, this.Parent.Name));
            }
            catch (CloudException ex) when (HttpStatusCode.NotFound == ex.Response.StatusCode)
            {
                // no exception should be thrown if the error code is "404 Not Found"
            }

            if(retValue == null)
            {
                return new List<RedisPatchScheduleImpl>();
            }

            return retValue
                    .AsContinuousCollection(link => Extensions.Synchronize(() => this.Parent.Manager.Inner.PatchSchedules.ListByRedisResourceNextAsync(link)))
                    .Select(inner => new RedisPatchScheduleImpl(inner.Name, this.Parent, inner))
                    .ToList();
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:0C5225E80E922751C67318B097BA8352
        protected override RedisPatchScheduleImpl NewChildResource(string name)
        {
            return new RedisPatchScheduleImpl(name, this.Parent, new RedisPatchScheduleInner());
        }

        ///GENMHASH:575ACD6B2F8DB77EB8418BE1DD965968:58A02B259CCAE12FC513BB9E49E7C583
        public void AddPatchSchedule(RedisPatchScheduleImpl patchSchedule)
        {
            this.AddChildResource(patchSchedule);
        }

        ///GENMHASH:8A7B2E82D212E78F5155D33477A1A8C1:EAC522B6D40FB7E3C1228792906D2E27
        public RedisPatchScheduleImpl DefineInlinePatchSchedule()
        {
            return this.PrepareDefine(this.patchScheduleName);
        }

        ///GENMHASH:29E3EBABEFC9DB4F1DCF2D8349652BAF:B5FC6B1C2EC9B5D2EA91BFADED314AE9
        public void DeleteInlinePatchSchedule()
        {
            this.PrepareRemove(this.patchScheduleName);
        }

        ///GENMHASH:CBF4AFABB2FAA2E1D1DA248452A775E7:59BEA683366219B31F1730D1BCB02E02
        public RedisPatchScheduleImpl GetPatchSchedule()
        {
            if(!this.Collection.ContainsKey(this.patchScheduleName))
            {
                return null;
            }
            return this.Collection[this.patchScheduleName];
        }

        ///GENMHASH:8D9FB32C1A68FED6543D49DBD2EF1458:E36476634597E3A1EF1F144166293628
        public void RemovePatchSchedule()
        {
            var psch = this.GetPatchSchedule();
            if (psch != null)
            {
                Extensions.Synchronize(() => psch.DeleteResourceAsync());
            }
        }

        ///GENMHASH:42D5879CEDFD6B722235D438670375E5:9C9E2F953CCDBC4573F56A9055417E77
        public RedisPatchScheduleImpl UpdateInlinePatchSchedule()
        {
            return this.PrepareUpdate(this.patchScheduleName);
        }

        // catchup methods
        public void Clear()
        {
            foreach (var child in this.Collection.Values)
            {
                child.Inner.ScheduleEntries.Clear();
            }
            this.Collection.Clear();
        }
    }
}