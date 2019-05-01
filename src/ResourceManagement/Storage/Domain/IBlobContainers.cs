// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Type representing BlobContainers.
    /// </summary>
    public interface IBlobContainers  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Clears legal hold tags. Clearing the same or non-existent tag results in an idempotent operation. ClearLegalHold clears out only the specified tags in the request.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="tags">Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> ClearLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Begins definition for a new Container resource.
        /// </summary>
        /// <param name="name">Resource name.</param>
        /// <return>The first stage of the new Container definition.</return>
        BlobContainer.Definition.IBlank DefineContainer(string name);

        /// <summary>
        /// Begins definition for a new ImmutabilityPolicy resource.
        /// </summary>
        /// <param name="name">Resource name.</param>
        /// <return>The first stage of the new ImmutabilityPolicy definition.</return>
        ImmutabilityPolicy.Definition.IBlank DefineImmutabilityPolicy(string name);

        /// <summary>
        /// Deletes specified container under its account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task DeleteAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, only way is to delete the container after deleting all blobs inside the container.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task DeleteImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy. The only action allowed on a Locked policy will be this action. ETag in If-Match is required for this operation.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <param name="immutabilityPeriodSinceCreationInDays">The immutability period for the blobs in the container since the policy creation, in days.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> ExtendImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, int immutabilityPeriodSinceCreationInDays, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets properties of a specified container.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> GetAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the existing immutability policy along with the corresponding ETag in response headers and body.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> GetImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IListContainerItems>> ListAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> LockImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets legal hold tags. Setting the same tag results in an idempotent operation. SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="tags">Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> SetLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken));
    }
}