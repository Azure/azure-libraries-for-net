// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Type to hold MSI configuration.
    /// </summary>
    public class MSILoginInformation : IBeta
    {
        /// <summary>
        /// Get or Set the MSI extension port to retrieve access token from.
        /// </summary>
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
}
