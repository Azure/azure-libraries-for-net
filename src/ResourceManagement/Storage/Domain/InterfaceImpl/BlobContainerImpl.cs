// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobContainerImpl 
    {
        /// <summary>
        /// Gets the etag value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.Etag
        {
            get
            {
                return this.Etag();
            }
        }

        /// <summary>
        /// Gets the hasImmutabilityPolicy value.
        /// </summary>
        bool? Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.HasImmutabilityPolicy
        {
            get
            {
                return this.HasImmutabilityPolicy();
            }
        }

        /// <summary>
        /// Gets the hasLegalHold value.
        /// </summary>
        bool? Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.HasLegalHold
        {
            get
            {
                return this.HasLegalHold();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the immutabilityPolicy value.
        /// </summary>
        ImmutabilityPolicyProperties Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.ImmutabilityPolicy
        {
            get
            {
                return this.ImmutabilityPolicy();
            }
        }

        /// <summary>
        /// Gets the lastModifiedTime value.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets the leaseDuration value.
        /// </summary>
        LeaseDuration Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.LeaseDuration
        {
            get
            {
                return this.LeaseDuration();
            }
        }

        /// <summary>
        /// Gets the leaseState value.
        /// </summary>
        LeaseState Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.LeaseState
        {
            get
            {
                return this.LeaseState();
            }
        }

        /// <summary>
        /// Gets the leaseStatus value.
        /// </summary>
        LeaseStatus Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.LeaseStatus
        {
            get
            {
                return this.LeaseStatus();
            }
        }

        /// <summary>
        /// Gets the legalHold value.
        /// </summary>
        LegalHoldProperties Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.LegalHold
        {
            get
            {
                return this.LegalHold();
            }
        }

        /// <summary>
        /// Gets the metadata value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.Metadata
        {
            get
            {
                return this.Metadata();
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the publicAccess value.
        /// </summary>
        PublicAccess? Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.PublicAccess
        {
            get
            {
                return this.PublicAccess();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobContainer.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        BlobContainer.Definition.IWithPublicAccess BlobContainer.Definition.IWithBlobService.WithExistingBlobService(string resourceGroupName, string accountName)
        {
            return this.WithExistingBlobService(resourceGroupName, accountName);
        }

        /// <summary>
        /// Specifies metadata.
        /// </summary>
        /// <param name="metadata">A name-value pair to associate with the container as metadata.</param>
        /// <return>The next update stage.</return>
        BlobContainer.Update.IUpdate BlobContainer.Update.IWithMetadata.WithMetadata(IDictionary<string,string> metadata)
        {
            return this.WithMetadata(metadata);
        }

        /// <summary>
        /// Specifies a singluar instance of metadata.
        /// </summary>
        /// <param name="name">A name to associate with the container as metadata.</param>
        /// <param name="value">A value to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        BlobContainer.Update.IUpdate BlobContainer.Update.IWithMetadata.WithMetadata(string name, string value)
        {
            return this.WithMetadata(name, value);
        }

        /// <summary>
        /// Specifies metadata.
        /// </summary>
        /// <param name="metadata">A name-value pair to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        BlobContainer.Definition.IWithCreate BlobContainer.Definition.IWithMetadata.WithMetadata(IDictionary<string,string> metadata)
        {
            return this.WithMetadata(metadata);
        }

        /// <summary>
        /// Specifies a singluar instance of metadata.
        /// </summary>
        /// <param name="name">A name to associate with the container as metadata.</param>
        /// <param name="value">A value to associate with the container as metadata.</param>
        /// <return>The next definition stage.</return>
        BlobContainer.Definition.IWithCreate BlobContainer.Definition.IWithMetadata.WithMetadata(string name, string value)
        {
            return this.WithMetadata(name, value);
        }

        /// <summary>
        /// Specifies publicAccess.
        /// </summary>
        /// <param name="publicAccess">Specifies whether data in the container may be accessed publicly and the level of access. Possible values include: 'Container', 'Blob', 'None'.</param>
        /// <return>The next update stage.</return>
        BlobContainer.Update.IUpdate BlobContainer.Update.IWithPublicAccess.WithPublicAccess(PublicAccess publicAccess)
        {
            return this.WithPublicAccess(publicAccess);
        }

        /// <summary>
        /// Specifies publicAccess.
        /// </summary>
        /// <param name="publicAccess">Specifies whether data in the container may be accessed publicly and the level of access. Possible values include: 'Container', 'Blob', 'None'.</param>
        /// <return>The next definition stage.</return>
        BlobContainer.Definition.IWithCreate BlobContainer.Definition.IWithPublicAccess.WithPublicAccess(PublicAccess publicAccess)
        {
            return this.WithPublicAccess(publicAccess);
        }
    }
}