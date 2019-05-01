// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the blobcontainer update allowing to specify PublicAccess.
    /// </summary>
    public interface IWithPublicAccess 
    {

        /// <summary>
        /// Specifies publicAccess.
        /// </summary>
        /// <param name="publicAccess">Specifies whether data in the container may be accessed publicly and the level of access. Possible values include: 'Container', 'Blob', 'None'.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update.IUpdate WithPublicAccess(PublicAccess publicAccess);
    }

    /// <summary>
    /// The stage of the blobcontainer update allowing to specify Metadata.
    /// </summary>
    public interface IWithMetadata 
    {

        /// <summary>
        /// Specifies metadata.
        /// </summary>
        /// <param name="metadata">A name-value pair to associate with the container as metadata.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update.IUpdate WithMetadata(IDictionary<string,string> metadata);

        /// <summary>
        /// Specifies a singluar instance of metadata.
        /// </summary>
        /// <param name="name">A name to associate with the container as metadata.</param>
        /// <param name="value">A value to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update.IUpdate WithMetadata(string name, string value);
    }

    /// <summary>
    /// The template for a BlobContainer update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer>,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update.IWithPublicAccess,
        Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update.IWithMetadata
    {

    }
}