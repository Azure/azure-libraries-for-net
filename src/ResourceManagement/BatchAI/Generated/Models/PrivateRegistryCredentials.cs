// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Credentials to access a container image in a private repository.
    /// </summary>
    public partial class PrivateRegistryCredentials
    {
        /// <summary>
        /// Initializes a new instance of the PrivateRegistryCredentials class.
        /// </summary>
        public PrivateRegistryCredentials()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateRegistryCredentials class.
        /// </summary>
        /// <param name="username">User name to login.</param>
        /// <param name="password">Password to login.</param>
        /// <param name="passwordSecretReference">Specifies the location of the
        /// password, which is a Key Vault Secret.</param>
        public PrivateRegistryCredentials(string username, string password = default(string), KeyVaultSecretReference passwordSecretReference = default(KeyVaultSecretReference))
        {
            Username = username;
            Password = password;
            PasswordSecretReference = passwordSecretReference;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets user name to login.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password to login.
        /// </summary>
        /// <remarks>
        /// One of password or passwordSecretReference must be specified.
        /// </remarks>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets specifies the location of the password, which is a Key
        /// Vault Secret.
        /// </summary>
        /// <remarks>
        /// Users can store their secrets in Azure KeyVault and pass it to the
        /// Batch AI Service to integrate with KeyVault. One of password or
        /// passwordSecretReference must be specified.
        /// </remarks>
        [JsonProperty(PropertyName = "passwordSecretReference")]
        public KeyVaultSecretReference PasswordSecretReference { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Username");
            }
            if (PasswordSecretReference != null)
            {
                PasswordSecretReference.Validate();
            }
        }
    }
}
