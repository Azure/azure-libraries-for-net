// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update
{
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
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
    /// The stage of the blobserviceproperties update allowing to specify Cors.
    /// </summary>
    public interface IWithCors 
    {

        /// <summary>
        /// Specifies a single CORS rule.
        /// </summary>
        /// <param name="corsRule">A single CORS rule.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithCORSRule(CorsRule corsRule);

        /// <summary>
        /// Specifies all of the CORS rules.
        /// </summary>
        /// <param name="corsRules">Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithCORSRules(IList<CorsRule> corsRules);
    }

    /// <summary>
    /// The template for a BlobServiceProperties update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties>,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IWithCors,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IWithDefaultServiceVersion,
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IWithDeleteRetentionPolicy
    {

    }

    /// <summary>
    /// The stage of the blobserviceproperties update allowing to specify DeleteRetentionPolicy.
    /// </summary>
    public interface IWithDeleteRetentionPolicy 
    {

        /// <summary>
        /// Specifies deleteRetentionPolicy.
        /// </summary>
        /// <param name="deleteRetentionPolicy">The blob service properties for soft delete.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy);

        /// <summary>
        /// Specifies that the delete retention policy is disabled.
        /// </summary>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithDeleteRetentionPolicyDisabled();

        /// <summary>
        /// Specifies that the delete retention policy is enabled for soft delete.
        /// </summary>
        /// <param name="numDaysEnabled">Number of days after soft delete that the blob service properties will actually be deleted.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithDeleteRetentionPolicyEnabled(int numDaysEnabled);
    }

    /// <summary>
    /// The stage of the blobserviceproperties update allowing to specify DefaultServiceVersion.
    /// </summary>
    public interface IWithDefaultServiceVersion 
    {

        /// <summary>
        /// Specifies defaultServiceVersion.
        /// </summary>
        /// <param name="defaultServiceVersion">DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update.IUpdate WithDefaultServiceVersion(string defaultServiceVersion);
    }
}