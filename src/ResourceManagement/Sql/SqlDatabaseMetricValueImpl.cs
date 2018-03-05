// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SqlDatabaseMetricValue.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZU1ldHJpY1ZhbHVlSW1wbA==
    internal partial class SqlDatabaseMetricValueImpl  :
        Wrapper<Models.MetricValue>,
        ISqlDatabaseMetricValue
    {
        ///GENMHASH:5BA999F4378FAE6FDDFE418C8C58C8FA:C0C35E00AF4E17F141675A2C05C7067B
        public SqlDatabaseMetricValueImpl(MetricValue innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:F388343A85878CDC4C2D91DE68982536:01EB34B1141A01EBBA64A91A322E8E07
        public double Average()
        {
            return this.Inner.Average.GetValueOrDefault();
        }

        ///GENMHASH:775D84187880B0017DB0A5805354E187:1D94B7DF9704D32D1E584B3A118594DE
        public double Total()
        {
            return this.Inner.Total.GetValueOrDefault();
        }

        ///GENMHASH:B84BFB9102C12A7625CB9CF2E3B5E7CF:BDFE6561FEC5EBDFF96600CDB5E62997
        public double Count()
        {
            return this.Inner.Count.GetValueOrDefault();
        }

        ///GENMHASH:5C32E7E71F449598B698B9299BA69D57:3F3ADF7F86DC5E00ED968023E2740499
        public double Maximum()
        {
            return this.Inner.Maximum.GetValueOrDefault();
        }

        ///GENMHASH:03FA5CE2AA51D611F698C900FC6E952B:8BF1BA74108B97CEE5E070A9F33B11EE
        public double Minimum()
        {
            return this.Inner.Minimum.GetValueOrDefault();
        }

        ///GENMHASH:45859958AA9C08487DCBDC7C1E9A55FD:8448E68448674491FD1723B68F87EB9D
        public DateTime? Timestamp()
        {
            return this.Inner.Timestamp;
        }
    }
}