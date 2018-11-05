// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition
{
    using Microsoft.Azure.KeyVault.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IBlank,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithValue,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of a secret definition allowing to specify the secret attributes.
    /// </summary>
    public interface IWithAttributes
    {
        /// <summary>
        /// Specifies the secret attributes.
        /// </summary>
        /// <param name="attributes">The object attributes managed by Key Vault service.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate WithAttributes(Attributes attributes);
    }

    /// <summary>
    /// The stage of a secret definition allowing to specify the tags.
    /// </summary>
    public interface IWithTags
    {
        /// <summary>
        /// Specifies the tags on the secret.
        /// </summary>
        /// <param name="tags">The key value pair of the tags.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate WithTags(IDictionary<string, string> tags);
    }

    /// <summary>
    /// The stage of a secret definition allowing to specify the secret content type.
    /// </summary>
    public interface IWithContentType
    {
        /// <summary>
        /// Specifies the secret content type.
        /// </summary>
        /// <param name="contentType">The content type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate WithContentType(string contentType);
    }

    /// <summary>
    /// The first stage of a secret definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithValue
    {
    }

    /// <summary>
    /// The stage of the secret definition which contains all the minimum required inputs for
    /// the secret to be created but also allows for any optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.KeyVault.Fluent.ISecret>,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithContentType,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithAttributes,
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithTags
    {
    }

    /// <summary>
    /// The stage of a secret definition allowing to specify the secret value.
    /// </summary>
    public interface IWithValue
    {
        /// <summary>
        /// Specifies the secret value.
        /// </summary>
        /// <param name="value">The string value of the secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Secret.Definition.IWithCreate WithValue(string value);
    }
}