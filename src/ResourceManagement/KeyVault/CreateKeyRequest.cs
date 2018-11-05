// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.KeyVault.Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The request for setting a secret.
    /// </summary>
    public class CreateKeyRequest
    {
        public string VaultBaseUrl { get; set; }
        public string KeyName { get; set; }
        public JsonWebKeyType KeyType { get; set; }
        public int KeySize { get; set; }
        public List<JsonWebKeyOperation> KeyOperations { get; set; }
        public KeyAttributes KeyAttributes { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }
}
