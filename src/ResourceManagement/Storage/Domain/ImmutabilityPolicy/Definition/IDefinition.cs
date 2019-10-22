// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The stage of the immutabilitypolicy definition allowing to specify ImmutabilityPeriodSinceCreationInDays.
    /// </summary>
    public interface IWithImmutabilityPeriodSinceCreationInDays 
    {

        /// <summary>
        /// Specifies immutabilityPeriodSinceCreationInDays.
        /// </summary>
        /// <param name="immutabilityPeriodSinceCreationInDays">The immutability period for the blobs in the container since the policy creation, in days.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithCreate WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays);
    }

    /// <summary>
    /// The entirety of the ImmutabilityPolicy definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithContainer,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithIfMatch,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithImmutabilityPeriodSinceCreationInDays,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The first stage of a ImmutabilityPolicy definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithContainer
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy>
    {

    }

    /// <summary>
    /// The stage of the immutabilitypolicy definition allowing to specify Container.
    /// </summary>
    public interface IWithContainer 
    {

        /// <summary>
        /// Specifies resourceGroupName, accountName, containerName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithIfMatch WithExistingContainer(string resourceGroupName, string accountName, string containerName);
    }

    /// <summary>
    /// The stage of the immutabilitypolicy definition allowing to specify IfMatch.
    /// </summary>
    public interface IWithIfMatch 
    {

        /// <summary>
        /// Specifies ifMatch.
        /// </summary>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition.IWithImmutabilityPeriodSinceCreationInDays WithIfMatch(string ifMatch);
    }
}