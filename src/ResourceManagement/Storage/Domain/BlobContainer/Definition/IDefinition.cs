// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithMetadata,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer>
    {

    }

    /// <summary>
    /// The entirety of the BlobContainer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithBlobService,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithPublicAccess,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithMetadata,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The first stage of a BlobContainer definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithBlobService
    {

    }

    /// <summary>
    /// The stage of the blobcontainer definition allowing to specify Metadata.
    /// </summary>
    public interface IWithMetadata 
    {

        /// <summary>
        /// Specifies metadata.
        /// </summary>
        /// <param name="metadata">A name-value pair to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithCreate WithMetadata(IDictionary<string,string> metadata);

        /// <summary>
        /// Specifies a singluar instance of metadata.
        /// </summary>
        /// <param name="name">A name to associate with the container as metadata.</param>
        /// <param name="value">A value to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithCreate WithMetadata(string name, string value);
    }

    /// <summary>
    /// The stage of the blobcontainer definition allowing to specify BlobService.
    /// </summary>
    public interface IWithBlobService 
    {

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithPublicAccess WithExistingBlobService(string resourceGroupName, string accountName);
    }

    /// <summary>
    /// The stage of the blobcontainer definition allowing to specify PublicAccess.
    /// </summary>
    public interface IWithPublicAccess 
    {

        /// <summary>
        /// Specifies publicAccess.
        /// </summary>
        /// <param name="publicAccess">Specifies whether data in the container may be accessed publicly and the level of access. Possible values include: 'Container', 'Blob', 'None'.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition.IWithCreate WithPublicAccess(PublicAccess publicAccess);
    }
}