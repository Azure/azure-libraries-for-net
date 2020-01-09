// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// Entry point for private link service visibility management API in Azure.
    /// </summary>
    public interface IPrivateLinkServiceVisibility
    {
        /// <summary>
        /// Gets private link service visibility.
        /// </summary>
        bool Visible { get; }
    }
}
