// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobServicesImpl 
    {
        /// <summary>
        /// Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The observable for the request.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> Microsoft.Azure.Management.Storage.Fluent.IBlobServices.GetServicePropertiesAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken)
        {
            return await this.GetServicePropertiesAsync(resourceGroupName, accountName, cancellationToken);
        }

    }
}