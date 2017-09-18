// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a set of certificates which are all in the same Key Vault.
    /// </summary>
    public partial class VaultSecretGroup
    {
        /// <summary>
        /// Initializes a new instance of the VaultSecretGroup class.
        /// </summary>
        public VaultSecretGroup()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VaultSecretGroup class.
        /// </summary>
        /// <param name="sourceVault">The relative URL of the Key Vault
        /// containing all of the certificates in VaultCertificates.</param>
        /// <param name="vaultCertificates">The list of key vault references in
        /// SourceVault which contain certificates.</param>
        public VaultSecretGroup(Microsoft.Azure.Management.ResourceManager.Fluent.SubResource sourceVault = default(Microsoft.Azure.Management.ResourceManager.Fluent.SubResource), IList<VaultCertificate> vaultCertificates = default(IList<VaultCertificate>))
        {
            SourceVault = sourceVault;
            VaultCertificates = vaultCertificates;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the relative URL of the Key Vault containing all of
        /// the certificates in VaultCertificates.
        /// </summary>
        [JsonProperty(PropertyName = "sourceVault")]
        public Microsoft.Azure.Management.ResourceManager.Fluent.SubResource SourceVault { get; set; }

        /// <summary>
        /// Gets or sets the list of key vault references in SourceVault which
        /// contain certificates.
        /// </summary>
        [JsonProperty(PropertyName = "vaultCertificates")]
        public IList<VaultCertificate> VaultCertificates { get; set; }

    }
}
