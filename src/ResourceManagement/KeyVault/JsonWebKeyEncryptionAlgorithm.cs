// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    //
    // Summary:
    //     Supported JsonWebKey algorithms
    public class JsonWebKeyEncryptionAlgorithm : ExpandableStringEnum<JsonWebKeyEncryptionAlgorithm>
    {
        public static readonly JsonWebKeyEncryptionAlgorithm RSAOAEP = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyEncryptionAlgorithm.RSAOAEP);
        public static readonly JsonWebKeyEncryptionAlgorithm RSA15 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyEncryptionAlgorithm.RSA15);
        public static readonly JsonWebKeyEncryptionAlgorithm RSAOAEP256 = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyEncryptionAlgorithm.RSAOAEP256);
    }
}
