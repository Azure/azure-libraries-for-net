// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobContainersImpl 
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
        async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.ClearLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken)
        {
            return await this.ClearLegalHoldAsync(resourceGroupName, accountName, containerName, tags, cancellationToken);
        }

        /// <summary>
        /// Begins definition for a new Container resource.
        /// </summary>
        /// <param name="name">Resource name.</param>
        /// <return>The first stage of the new Container definition.</return>
        BlobContainer.Definition.IBlank Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.DefineContainer(string name)
        {
            return this.DefineContainer(name);
        }

        /// <summary>
        /// Begins definition for a new ImmutabilityPolicy resource.
        /// </summary>
        /// <param name="name">Resource name.</param>
        /// <return>The first stage of the new ImmutabilityPolicy definition.</return>
        ImmutabilityPolicy.Definition.IBlank Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.DefineImmutabilityPolicy(string name)
        {
            return this.DefineImmutabilityPolicy(name);
        }

        /// <summary>
        /// Deletes specified container under its account.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.DeleteAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(resourceGroupName, accountName, containerName, cancellationToken);
        }

        /// <summary>
        /// Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, only way is to delete the container after deleting all blobs inside the container.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.DeleteImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken)
        {
 
            await this.DeleteImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch, cancellationToken);
        }

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
        async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.ExtendImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, int immutabilityPeriodSinceCreationInDays, CancellationToken cancellationToken)
        {
            return await this.ExtendImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch, immutabilityPeriodSinceCreationInDays, cancellationToken);
        }

        /// <summary>
        /// Gets properties of a specified container.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.GetAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken)
        {
            return await this.GetAsync(resourceGroupName, accountName, containerName, cancellationToken);
        }

        /// <summary>
        /// Gets the existing immutability policy along with the corresponding ETag in response headers and body.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.GetImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken)
        {
            return await this.GetImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, cancellationToken);
        }

        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IListContainerItems>> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.ListAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken)
        {
            return await this.ListAsync(resourceGroupName, accountName, cancellationToken);
        }

        /// <summary>
        /// Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.LockImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken)
        {
            return await this.LockImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Sets legal hold tags. Setting the same tag results in an idempotent operation. SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="containerName">The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="tags">Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> Microsoft.Azure.Management.Storage.Fluent.IBlobContainers.SetLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken)
        {
            return await this.SetLegalHoldAsync(resourceGroupName, accountName, containerName, tags, cancellationToken);
        }
    }
}