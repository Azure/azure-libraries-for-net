// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    //
    // Summary:
    //     Supported JsonWebKey algorithms
    public class JsonWebKeySignatureAlgorithm : ExpandableStringEnum<JsonWebKeySignatureAlgorithm>
    {
        public static readonly JsonWebKeySignatureAlgorithm RS256 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.RS256);
        public static readonly JsonWebKeySignatureAlgorithm RS384 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.RS384);
        public static readonly JsonWebKeySignatureAlgorithm RS512 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.RS512);
        public static readonly JsonWebKeySignatureAlgorithm RSNULL = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.RSNULL);
        public static readonly JsonWebKeySignatureAlgorithm PS256 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.PS256);
        public static readonly JsonWebKeySignatureAlgorithm PS384 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.PS384);
        public static readonly JsonWebKeySignatureAlgorithm PS512 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeySignatureAlgorithm.PS512);
    }
}
