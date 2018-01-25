// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for  com.microsoft.azure.management.network.ExpressRouteCircuitStats.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRXhwcmVzc1JvdXRlQ2lyY3VpdFN0YXRzSW1wbA==
    internal partial class ExpressRouteCircuitStatsImpl :
        Wrapper<ExpressRouteCircuitStatsInner>,
        IExpressRouteCircuitStats
    {
        ///GENMHASH:4B16EC2596F7A0EABFF36EFE6C116770:C0C35E00AF4E17F141675A2C05C7067B
        internal ExpressRouteCircuitStatsImpl(ExpressRouteCircuitStatsInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:E84DF3BA83A660A10D265835FA5AAAC7:B4A707C415C0FF5B80966AC53E85466D
        public long SecondaryBytesIn()
        {
            return Inner.SecondarybytesIn.HasValue ? Inner.SecondarybytesIn.Value : 0;
        }

        ///GENMHASH:1041B69E7BE8D4257B1AF0A216F225D5:F479133452345548E289D3D8F5216D5A
        public long PrimaryBytesOut()
        {
            return Inner.PrimarybytesOut.HasValue ? Inner.PrimarybytesOut.Value : 0;
        }

        ///GENMHASH:C223BAB339F83E8BA5B5DCE1CF0C6987:C7AAEEF9E36C6B3653F90F209B109876
        public long SecondaryBytesOut()
        {
            return Inner.SecondarybytesOut.HasValue ? Inner.SecondarybytesOut.Value : 0;
        }

        ///GENMHASH:00868B007C42DA256C8C0059810E0BCE:F17258A19EF1E0806B209F2080993686
        public long PrimaryBytesIn()
        {
            return Inner.PrimarybytesIn.HasValue ? Inner.PrimarybytesIn.Value : 0;
        }
    }
}