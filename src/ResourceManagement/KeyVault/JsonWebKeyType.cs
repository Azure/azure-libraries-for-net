// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    //
    // Summary:
    //     Supported JsonWebKey types
    public class JsonWebKeyType : ExpandableStringEnum<JsonWebKeyType>
    {
        public static readonly JsonWebKeyType EllipticCurve = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.EllipticCurve);
        public static readonly JsonWebKeyType Rsa = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.Rsa);
        public static readonly JsonWebKeyType RsaHsm = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.RsaHsm);
        public static readonly JsonWebKeyType Octet = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyType.Octet);
    }
}
