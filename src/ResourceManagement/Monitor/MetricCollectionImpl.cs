// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// The Azure  MetricCollection wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljQ29sbGVjdGlvbkltcGw=
    internal partial class MetricCollectionImpl :
        Wrapper<Microsoft.Azure.Management.Monitor.Fluent.Models.ResponseInner>,
        IMetricCollection
    {

        ///GENMHASH:9EC4482D6004AE3EE5DE8D1E51177060:C0C35E00AF4E17F141675A2C05C7067B
        internal MetricCollectionImpl(ResponseInner innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:E807784FEBE190636B32D76302B48B0E:AC89EACBA0C56F501A1CDB1BD8F2A0B1
        public double? Cost()
        {
            return this.Inner.Cost;
        }

        ///GENMHASH:7B4E91C7245DC969553F3F08B7869BCA:AE45972958C95CA7CB516F025E503393
        public TimeSpan? Interval()
        {
            return this.Inner.Interval;
        }

        ///GENMHASH:5E46449A7B51B1BC98D66C6A37EC1F02:E1410075F9D9439C3765FA62DD0E7F08
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.IMetric> Metrics()
        {
            return this.Inner.Value.Select(inner => new MetricImpl(inner)).ToList();
        }

        ///GENMHASH:E65A2E847594C17DA590ED0613F7AD5B:13D0AB0DC28C19EFC1EE9A3E7181739F
        public string Namespace()
        {
            return this.Inner.NamespaceProperty;
        }

        ///GENMHASH:1D4FD7BEC796362424CC11AD70971807:F899BEB46599964E6082D3FFF4D6C362
        public string ResourceRegion()
        {
            return this.Inner.Resourceregion;
        }

        ///GENMHASH:E1F654DDBF4921A658FEC599B70C85DD:7B911943C420EC0B6AA52AE6053B5ACE
        public string Timespan()
        {
            return this.Inner.Timespan;
        }
    }
}
