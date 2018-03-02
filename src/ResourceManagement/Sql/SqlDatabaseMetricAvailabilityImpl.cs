// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Response containing the SQL database metric availability.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZU1ldHJpY0F2YWlsYWJpbGl0eUltcGw=
    internal partial class SqlDatabaseMetricAvailabilityImpl  :
        Wrapper<Models.MetricAvailability>,
        ISqlDatabaseMetricAvailability
    {

        ///GENMHASH:CB47DF12EC83BDE4688FAE5A72C984E6:C0C35E00AF4E17F141675A2C05C7067B
        public SqlDatabaseMetricAvailabilityImpl(MetricAvailability innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:2DFE05B7A49BBD23F65FDFBB0BF2C427:594D1010C484E7E384FED20C1B90C922
        public string TimeGrain()
        {
            return this.Inner.TimeGrain;
        }

        ///GENMHASH:6AB1A03F56255350FC94B191E1F74D91:568B462C9B5796E377CCC99094B1D667
        public string Retention()
        {
            return this.Inner.Retention;
        }
    }
}