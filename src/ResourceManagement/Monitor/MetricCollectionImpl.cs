// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal class MetricCollectionImpl : Wrapper<ResponseInner>, IMetricCollection
    {
        public MetricCollectionImpl(ResponseInner innerObject)
            :base(innerObject)
        {
        }

        public Double? Cost
        {
            get
            {
                return this.Inner.Cost;
            }
        }

        public string Timespan
        {
            get
            {
                return this.Inner.Timespan;
            }
        }

        public System.TimeSpan? Interval
        {
            get
            {
                return this.Inner.Interval;
            }
        }

        public IReadOnlyList<Metric> Metrics
        {
            get
            {
                return this.Inner.Value.ToList();
            }
        }
    }
}
