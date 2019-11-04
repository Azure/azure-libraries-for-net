// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Type to hold MSI configuration.
    /// </summary>
    public class MSILoginInformation : IBeta
    {
        /// <summary>
        /// Construction for MSI Login
        /// </summary>
        /// <param name="resourceType">MSI Resource Type</param>
        /// <param name="clientId">User Assigned Identity Client ID</param>
        /// <param name="resourceId">User Assigned Identity Resource ID</param>
        /// <param name="objectId">User Assigned Identity Object ID</param>
        public MSILoginInformation(MSIResourceType resourceType, string clientId = null, string resourceId = null, string objectId = null)
        {
            this.ResourceType = resourceType;
            this.UserAssignedIdentityClientId = clientId;
            this.UserAssignedIdentityResourceId = resourceId;
            this.UserAssignedIdentityObjectId = objectId;
        }

        /// <summary>
        /// Get or set the type of the resource for MSI authentication.
        /// </summary>
        public MSIResourceType ResourceType
        {
            get; private set;
        }

        /// <summary>
        /// Get or Set the MSI extension port to retrieve access token from.
        /// </summary>
        [Obsolete("Port is used for MSI VM extension based login, login using MSI VM extension is deprecated infavour of IMDS based login")]
        public int? Port
        {
            get; set;
        }

        /// <summary>
        /// Get or Set the Active Directory Client ID associated with the user assigned identity.
        /// </summary>
        public string UserAssignedIdentityClientId
        {
            get; set;
        }

        /// <summary>
        /// Get or Set user assigned identity resource ARM id.
        /// </summary>
        public string UserAssignedIdentityResourceId
        {
            get; set;
        }

        /// <summary>
        /// Get or Set the Active Directory Object ID associated with the user assigned identity.
        /// </summary>
        public string UserAssignedIdentityObjectId
        {
            get; set;
        }
    }

    /// <summary>
    /// List of supported resources for MSI authentication.
    /// </summary>
    public enum MSIResourceType
    {
        VirtualMachine = 0,
        AppService = 1
    }
}
