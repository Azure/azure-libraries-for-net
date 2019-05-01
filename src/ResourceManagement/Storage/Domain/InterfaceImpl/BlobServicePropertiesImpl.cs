// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobServicePropertiesImpl 
    {
        /// <summary>
        /// Gets the cors value.
        /// </summary>
        CorsRules Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.Cors
        {
            get
            {
                return this.Cors();
            }
        }

        /// <summary>
        /// Gets the defaultServiceVersion value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.DefaultServiceVersion
        {
            get
            {
                return this.DefaultServiceVersion();
            }
        }

        /// <summary>
        /// Gets the deleteRetentionPolicy value.
        /// </summary>
        DeleteRetentionPolicy Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.DeleteRetentionPolicy
        {
            get
            {
                return this.DeleteRetentionPolicy();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies a single CORS rule.
        /// </summary>
        /// <param name="corsRule">A single CORS rule.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithCors.WithCORSRule(CorsRule corsRule)
        {
            return this.WithCORSRule(corsRule);
        }

        /// <summary>
        /// Specifies a single CORS rule.
        /// </summary>
        /// <param name="corsRule">A single CORS rule.</param>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithCors.WithCORSRule(CorsRule corsRule)
        {
            return this.WithCORSRule(corsRule);
        }

        /// <summary>
        /// Specifies all of the CORS rules.
        /// </summary>
        /// <param name="corsRules">Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithCors.WithCORSRules(IList<CorsRule> corsRules)
        {
            return this.WithCORSRules(corsRules);
        }

        /// <summary>
        /// Specifies all of the CORS rules.
        /// </summary>
        /// <param name="corsRules">Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.</param>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithCors.WithCORSRules(IList<CorsRule> corsRules)
        {
            return this.WithCORSRules(corsRules);
        }

        /// <summary>
        /// Specifies defaultServiceVersion.
        /// </summary>
        /// <param name="defaultServiceVersion">DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithDefaultServiceVersion.WithDefaultServiceVersion(string defaultServiceVersion)
        {
            return this.WithDefaultServiceVersion(defaultServiceVersion);
        }

        /// <summary>
        /// Specifies defaultServiceVersion.
        /// </summary>
        /// <param name="defaultServiceVersion">DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.</param>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithDefaultServiceVersion.WithDefaultServiceVersion(string defaultServiceVersion)
        {
            return this.WithDefaultServiceVersion(defaultServiceVersion);
        }

        /// <summary>
        /// Specifies deleteRetentionPolicy.
        /// </summary>
        /// <param name="deleteRetentionPolicy">The blob service properties for soft delete.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy)
        {
            return this.WithDeleteRetentionPolicy(deleteRetentionPolicy);
        }

        /// <summary>
        /// Specifies deleteRetentionPolicy.
        /// </summary>
        /// <param name="deleteRetentionPolicy">The blob service properties for soft delete.</param>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy)
        {
            return this.WithDeleteRetentionPolicy(deleteRetentionPolicy);
        }

        /// <summary>
        /// Specifies that the delete retention policy is disabled.
        /// </summary>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicyDisabled()
        {
            return this.WithDeleteRetentionPolicyDisabled();
        }

        /// <summary>
        /// Specifies that the delete retention policy is disabled.
        /// </summary>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicyDisabled()
        {
            return this.WithDeleteRetentionPolicyDisabled();
        }

        /// <summary>
        /// Specifies that the delete retention policy is enabled for soft delete.
        /// </summary>
        /// <param name="numDaysEnabled">Number of days after soft delete that the blob service properties will actually be deleted.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicyEnabled(int numDaysEnabled)
        {
            return this.WithDeleteRetentionPolicyEnabled(numDaysEnabled);
        }

        /// <summary>
        /// Specifies that the delete retention policy is enabled for soft delete.
        /// </summary>
        /// <param name="numDaysEnabled">Number of days after soft delete that the blob service properties will actually be deleted.</param>
        /// <return>The next update stage.</return>
        BlobServiceProperties.Update.IUpdate BlobServiceProperties.Update.IWithDeleteRetentionPolicy.WithDeleteRetentionPolicyEnabled(int numDaysEnabled)
        {
            return this.WithDeleteRetentionPolicyEnabled(numDaysEnabled);
        }

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        BlobServiceProperties.Definition.IWithCreate BlobServiceProperties.Definition.IWithStorageAccount.WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            return this.WithExistingStorageAccount(resourceGroupName, accountName);
        }
    }
}