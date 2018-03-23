// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for RegionCapabilities.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZWdpb25DYXBhYmlsaXRpZXNJbXBs
    internal partial class RegionCapabilitiesImpl  :
        Wrapper<Models.LocationCapabilitiesInner>,
        IRegionCapabilities
    {
        private Dictionary<string,Models.ServerVersionCapability> supportedCapabilitiesMap;
        /// <summary>
        /// Creates an instance of the region capabilities object.
        /// </summary>
        /// <param name="innerObject">The inner object.</param>
        ///GENMHASH:0DBAB2D0915F4FDAA0AFE98DF17E252F:F72565FAA4E1F04338873CBBB500B2D7
        public  RegionCapabilitiesImpl(LocationCapabilitiesInner innerObject)
            : base(innerObject)
        {
            this.supportedCapabilitiesMap = new Dictionary<string, ServerVersionCapability>();
            if (this.Inner.SupportedServerVersions != null)
            {
                foreach(var serverVersionCapability in this.Inner.SupportedServerVersions) {
                    supportedCapabilitiesMap[serverVersionCapability.Name] = serverVersionCapability;
                }
            }
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:D8BBB0F2104D53E6E6C8D3AD50580559
        public Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Name);
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public CapabilityStatus Status()
        {
            return this.Inner.Status.GetValueOrDefault();
        }

        ///GENMHASH:5227230190DE94913B16D39240105493:BA244ABFBAF86BD612D2145FC72AB7EC
        public IReadOnlyDictionary<string,Models.ServerVersionCapability> SupportedCapabilitiesByServerVersion()
        {
            return this.supportedCapabilitiesMap;
        }
    }
}