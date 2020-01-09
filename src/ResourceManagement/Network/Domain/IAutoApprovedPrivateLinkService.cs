// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// Entry point for auto approved private link service management API in Azure.
    /// </summary>
    public interface IAutoApprovedPrivateLinkService
    {
        /// <summary>
        /// Gets the ID of the private link service resource.
        /// </summary>
        string PrivateLinkService { get; }
    }
}
