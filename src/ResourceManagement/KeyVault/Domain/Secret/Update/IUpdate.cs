// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update
{
    using System.Collections.Generic;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a secret update allowing to specify the tags.
    /// </summary>
    public interface IWithTags
    {
        /// <summary>
        /// Specifies the tags on the secret.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate WithTags(IDictionary<string, string> tags);
    }

    /// <summary>
    /// The stage of a secret update allowing to set the content type of the secret.
    /// </summary>
    public interface IWithContentType
    {
        /// <summary>
        /// Specifies the secret content type.
        /// </summary>
        /// <param name="contentType">The content type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate WithContentType(string contentType);
    }

    /// <summary>
    /// The stage of a secret update allowing to create a new version of the secret value.
    /// </summary>
    public interface IWithValue
    {
        /// <summary>
        /// Specifies the new version of the value to be added.
        /// </summary>
        /// <param name="value">The value for the new version.</param>
        /// <return>The next stage of the secret update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate WithValue(string value);
    }

    /// <summary>
    /// The stage of a secret update allowing to specify the secret attributes.
    /// </summary>
    public interface IWithAttributes
    {
        /// <summary>
        /// Specifies the secret attributes.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate WithAttributes(Attributes attributes);
    }

    /// <summary>
    /// The template for a secret update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithValue,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithVersion,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithAttributes,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithContentType,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IWithTags
    {
    }

    /// <summary>
    /// The stage of a secret update allowing to set the secret to a different version.
    /// </summary>
    public interface IWithVersion
    {
        /// <summary>
        /// Specifies the version the secret show use.
        /// </summary>
        /// <param name="version">The version of the secret.</param>
        /// <return>The next stage of the secret update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Update.IUpdate WithVersion(string version);
    }
}