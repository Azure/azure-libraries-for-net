// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition
{
    using Microsoft.Azure.Management.Storage.Fluent;
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
    /// The first stage of a BlobServiceProperties definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithStorageAccount
    {

    }

    /// <summary>
    /// The stage of the blobserviceproperties definition allowing to specify DeleteRetentionPolicy.
    /// </summary>
    public interface IWithDeleteRetentionPolicy 
    {

        /// <summary>
        /// Specifies deleteRetentionPolicy.
        /// </summary>
        /// <param name="deleteRetentionPolicy">The blob service properties for soft delete.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy);

        /// <summary>
        /// Specifies that the delete retention policy is disabled.
        /// </summary>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithDeleteRetentionPolicyDisabled();

        /// <summary>
        /// Specifies that the delete retention policy is enabled for soft delete.
        /// </summary>
        /// <param name="numDaysEnabled">Number of days after soft delete that the blob service properties will actually be deleted.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithDeleteRetentionPolicyEnabled(int numDaysEnabled);
    }

    /// <summary>
    /// The entirety of the BlobServiceProperties definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties>,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCors,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithDefaultServiceVersion,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithDeleteRetentionPolicy
    {

    }

    /// <summary>
    /// The stage of the blobserviceproperties definition allowing to specify Cors.
    /// </summary>
    public interface IWithCors 
    {

        /// <summary>
        /// Specifies a single CORS rule.
        /// </summary>
        /// <param name="corsRule">A single CORS rule.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithCORSRule(CorsRule corsRule);

        /// <summary>
        /// Specifies all of the CORS rules.
        /// </summary>
        /// <param name="corsRules">Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithCORSRules(IList<CorsRule> corsRules);
    }

    /// <summary>
    /// The stage of the blobserviceproperties definition allowing to specify DefaultServiceVersion.
    /// </summary>
    public interface IWithDefaultServiceVersion 
    {

        /// <summary>
        /// Specifies defaultServiceVersion.
        /// </summary>
        /// <param name="defaultServiceVersion">DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithDefaultServiceVersion(string defaultServiceVersion);
    }

    /// <summary>
    /// The stage of the blobserviceproperties definition allowing to specify StorageAccount.
    /// </summary>
    public interface IWithStorageAccount 
    {

        /// <summary>
        /// Specifies resourceGroupName, accountName.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition.IWithCreate WithExistingStorageAccount(string resourceGroupName, string accountName);
    }
}