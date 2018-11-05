// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    //
    // Summary:
    //     Supported JsonWebKey types
    public class JsonWebKeyOperation : ExpandableStringEnum<JsonWebKeyOperation>
    {
        public static readonly JsonWebKeyOperation Encrypt = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Encrypt);
        public static readonly JsonWebKeyOperation Decrypt = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Decrypt);
        public static readonly JsonWebKeyOperation Sign = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Sign);
        public static readonly JsonWebKeyOperation Verify = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Verify);
        public static readonly JsonWebKeyOperation Wrap = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Wrap);
        public static readonly JsonWebKeyOperation Unwrap = Parse(Microsoft.Azure.KeyVault.WebKey.JsonWebKeyOperation.Unwrap);
    }
}
