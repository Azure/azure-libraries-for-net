// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.KeyVault.Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The request for setting a secret.
    /// </summary>
    public class UpdateSecretRequest
    {
        public string VaultBaseUrl { get; set; }
        public string SecretName { get; set; }
        public string SecretVersion { get; set; }
        public string ContentType { get; set; }
        public SecretAttributes SecretAttributes { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }
}
