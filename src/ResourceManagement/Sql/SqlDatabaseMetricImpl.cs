// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Response containing the SQL database metrics.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZU1ldHJpY0ltcGw=
    internal partial class SqlDatabaseMetricImpl  :
        Wrapper<Models.Metric>,
        ISqlDatabaseMetric
    {
        private List<ISqlDatabaseMetricValue> sqlDatabaseMetricValues;

        ///GENMHASH:2DFE05B7A49BBD23F65FDFBB0BF2C427:594D1010C484E7E384FED20C1B90C922
        public string TimeGrain()
        {
            return this.Inner.TimeGrain;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:AE6A688E48A33F4836A5CFB695421894
        public Models.UnitType Unit()
        {
            return this.Inner.Unit;
        }

        ///GENMHASH:AAEBDC30B078CCB1B834E96A827ED51E:C0C35E00AF4E17F141675A2C05C7067B
        public SqlDatabaseMetricImpl(Metric innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:04777A24D701F6EEEE9D34EBA4230528
        public string Name()
        {
            return this.Inner.Name.Value;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:42AE1A0453935D9BF88147F2F9C3EC20
        public DateTime? StartTime()
        {
            return this.Inner.StartTime;
        }

        ///GENMHASH:3C1909F3137E91E93C57B90768BECD1A:561DFB636B157F511DFC1C40D1BDE39E
        public DateTime? EndTime()
        {
            return this.Inner.EndTime;
        }

        ///GENMHASH:AA67B4810CC7FB0A9425076713471212:20E3836EE79C64C3DD9D1D42104F1FAA
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricValue> MetricValues()
        {
            if (this.sqlDatabaseMetricValues == null)
            {
                this.sqlDatabaseMetricValues = new List<ISqlDatabaseMetricValue>();
                if (this.Inner.MetricValues != null)
                {
                    foreach (var metricValue in this.Inner.MetricValues)
                    {
                        sqlDatabaseMetricValues.Add(new SqlDatabaseMetricValueImpl(metricValue));
                    }
                }
            }
            return this.sqlDatabaseMetricValues.AsReadOnly();
        }
    }
}