// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.WebKey;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The request for setting a secret.
    /// </summary>
    public class ImportKeyRequest
    {
        public string VaultBaseUrl { get; set; }
        public string KeyName { get; set; }
        public JsonWebKey Key { get; set; }
        public bool IsHsm { get; set; }
        public KeyAttributes KeyAttributes { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }
}
