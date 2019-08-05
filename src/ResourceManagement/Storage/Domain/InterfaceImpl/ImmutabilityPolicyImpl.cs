// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ImmutabilityPolicyImpl 
    {
        /// <summary>
        /// Gets the etag value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.Etag
        {
            get
            {
                return this.Etag();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the immutabilityPeriodSinceCreationInDays value.
        /// </summary>
        int Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
        {
            get
            {
                return this.ImmutabilityPeriodSinceCreationInDays();
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the state value.
        /// </summary>
        ImmutabilityPolicyState Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies resourceGroupName, accountName, containerName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <return>The next definition stage.</return>
        ImmutabilityPolicy.Definition.IWithIfMatch ImmutabilityPolicy.Definition.IWithContainer.WithExistingContainer(string resourceGroupName, string accountName, string containerName)
        {
            return this.WithExistingContainer(resourceGroupName, accountName, containerName);
        }

        /// <summary>
        /// Specifies ifMatch.
        /// </summary>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <return>The next definition stage.</return>
        ImmutabilityPolicy.Definition.IWithImmutabilityPeriodSinceCreationInDays ImmutabilityPolicy.Definition.IWithIfMatch.WithIfMatch(string ifMatch)
        {
            return this.WithIfMatch(ifMatch);
        }

        /// <summary>
        /// Specifies ifMatch.
        /// </summary>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <return>The next update stage.</return>
        ImmutabilityPolicy.Update.IUpdate ImmutabilityPolicy.Update.IWithIfMatch.WithIfMatch(string ifMatch)
        {
            return this.WithIfMatch(ifMatch);
        }

        /// <summary>
        /// Specifies immutabilityPeriodSinceCreationInDays.
        /// </summary>
        /// <param name="immutabilityPeriodSinceCreationInDays">The immutability period for the blobs in the container since the policy creation, in days.</param>
        /// <return>The next definition stage.</return>
        ImmutabilityPolicy.Definition.IWithCreate ImmutabilityPolicy.Definition.IWithImmutabilityPeriodSinceCreationInDays.WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays)
        {
            return this.WithImmutabilityPeriodSinceCreationInDays(immutabilityPeriodSinceCreationInDays);
        }

        /// <summary>
        /// Specifies immutabilityPeriodSinceCreationInDays.
        /// </summary>
        /// <param name="immutabilityPeriodSinceCreationInDays">The immutability period for the blobs in the container since the policy creation, in days.</param>
        /// <return>The next update stage.</return>
        ImmutabilityPolicy.Update.IUpdate ImmutabilityPolicy.Update.IWithImmutabilityPeriodSinceCreationInDays.WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays)
        {
            return this.WithImmutabilityPeriodSinceCreationInDays(immutabilityPeriodSinceCreationInDays);
        }
    }
}