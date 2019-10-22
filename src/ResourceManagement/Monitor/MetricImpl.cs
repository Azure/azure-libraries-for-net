// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Azure  Metric wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljSW1wbA==
    internal partial class MetricImpl :
        Wrapper<Models.MetricInner>,
        IMetric
    {
        private ILocalizableString metricName;

        ///GENMHASH:D5C6A215765AA9CB79343C504C3C3446:84C0C3C28D1475257EE342DAB8514869
        internal MetricImpl(MetricInner innerObject)
            : base(innerObject)
        {
            this.metricName = (Inner.Name == null) ? null : new LocalizableStringImpl(Inner.Name);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:829542CE32889D8307E18271D2D90F3C
        public ILocalizableString Name()
        {
            return this.metricName;
        }

        ///GENMHASH:FD5CC1CB1A2D5F80DBD14A9578C3F0E2:290F224302B9DDA3B670607D6F3BA688
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.TimeSeriesElement> Timeseries()
        {
            return this.Inner.Timeseries.ToList();
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:AE6A688E48A33F4836A5CFB695421894
        public Unit Unit()
        {
            return this.Inner.Unit;
        }
    }
}