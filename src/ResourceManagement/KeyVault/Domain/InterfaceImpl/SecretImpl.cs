// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class SecretImpl
    {
        /// <summary>
        /// Specifies the secret value.
        /// </summary>
        /// <param name="value">The string value of the secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithValue.WithValue(string value)
        {
            return this.WithValue(value) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the new version of the value to be added.
        /// </summary>
        /// <param name="value">The value for the new version.</param>
        /// <return>The next stage of the secret update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithValue.WithValue(string value)
        {
            return this.WithValue(value) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the secret attributes.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithAttributes.WithAttributes(Attributes attributes)
        {
            return this.WithAttributes(attributes) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the secret attributes.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithAttributes.WithAttributes(Attributes attributes)
        {
            return this.WithAttributes(attributes) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the secret content type.
        /// </summary>
        /// <param name="contentType">The content type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithContentType.WithContentType(string contentType)
        {
            return this.WithContentType(contentType) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the secret content type.
        /// </summary>
        /// <param name="contentType">The content type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithContentType.WithContentType(string contentType)
        {
            return this.WithContentType(contentType) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the version the secret show use.
        /// </summary>
        /// <param name="version">The version of the secret.</param>
        /// <return>The next stage of the secret update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithVersion.WithVersion(string version)
        {
            return this.WithVersion(version) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <return>A list of individual secret versions with the same secret name.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>> Microsoft.Azure.Management.KeyVault.Fluent.ISecret.ListVersionsAsync(CancellationToken cancellationToken)
        {
            return await this.ListVersionsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the secret management attributes.
        /// </summary>
        Microsoft.Azure.KeyVault.Models.SecretAttributes Microsoft.Azure.Management.KeyVault.Fluent.ISecret.Attributes
        {
            get
            {
                return this.Attributes() as Microsoft.Azure.KeyVault.Models.SecretAttributes;
            }
        }

        /// <summary>
        /// Gets application specific metadata in the form of key-value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.KeyVault.Fluent.ISecret.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string, string>;
            }
        }

        /// <summary>
        /// Gets the secret value.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.ISecret.Value
        {
            get
            {
                return this.Value();
            }
        }

        /// <summary>
        /// Gets the corresponding key backing the KV certificate if this is a
        /// secret backing a KV certificate.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.ISecret.Kid
        {
            get
            {
                return this.Kid();
            }
        }

        /// <summary>
        /// Gets type of the secret value such as a password.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.ISecret.ContentType
        {
            get
            {
                return this.ContentType();
            }
        }

        /// <summary>
        /// Gets true if the secret's lifetime is managed by key vault. If this is a key
        /// backing a certificate, then managed will be true.
        /// </summary>
        bool Microsoft.Azure.Management.KeyVault.Fluent.ISecret.Managed
        {
            get
            {
                return this.Managed();
            }
        }

        /// <return>A list of individual secret versions with the same secret name.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret> Microsoft.Azure.Management.KeyVault.Fluent.ISecret.ListVersions()
        {
            return this.ListVersions() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>;
        }

        /// <summary>
        /// Specifies the tags on the secret.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the tags on the secret.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags) as Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate;
        }
    }
}