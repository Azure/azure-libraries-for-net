// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Response containing the SQL database metric definitions.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZU1ldHJpY0RlZmluaXRpb25JbXBs
    internal partial class SqlDatabaseMetricDefinitionImpl  :
        Wrapper<Models.MetricDefinition>,
        ISqlDatabaseMetricDefinition
    {
        private List<ISqlDatabaseMetricAvailability> sqlDatabaseMetricAvailabilities;
        ///GENMHASH:5CDCE3A8B827FE30E0D0EA58A812A905:C0C35E00AF4E17F141675A2C05C7067B
        public SqlDatabaseMetricDefinitionImpl(MetricDefinition innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:109D11A77FA743E7E386E405BD1BAAAF:6CB035BEF3A0E1CC43A51A7924D850CE
        public PrimaryAggregationType PrimaryAggregationType()
        {
            return this.Inner.PrimaryAggregationType;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:AE6A688E48A33F4836A5CFB695421894
        public UnitDefinitionType Unit()
        {
            return this.Inner.Unit;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:04777A24D701F6EEEE9D34EBA4230528
        public string Name()
        {
            return this.Inner.Name.Value;
        }

        ///GENMHASH:D5DE14BA4719E901018C8885AF9DC60D:325076F36B410AB8D5B0AAF51D213AAA
        public string ResourceUri()
        {
            return this.Inner.ResourceUri;
        }

        ///GENMHASH:532A125F6308BA5B895A3303D68F428F:24C8A9A6597283812934AD14A398C185
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricAvailability> MetricAvailabilities()
        {
            if (sqlDatabaseMetricAvailabilities == null)
            {
                sqlDatabaseMetricAvailabilities = new List<ISqlDatabaseMetricAvailability>();
                if (this.Inner.MetricAvailabilities != null)
                {
                    foreach (var metricAvailability in this.Inner.MetricAvailabilities)
                    {
                        sqlDatabaseMetricAvailabilities.Add(new SqlDatabaseMetricAvailabilityImpl(metricAvailability));
                    }
                }
            }

            return sqlDatabaseMetricAvailabilities.AsReadOnly();
        }
    }
}