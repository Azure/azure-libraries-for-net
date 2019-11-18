// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A private link resource.
    /// </summary>
    public interface IPrivateLinkResource  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.CosmosDB.Fluent.PrivateLinkResourceInner>
    {

        /// <summary>
        /// Gets the private link resource group id.
        /// </summary>
        /// <summary>
        /// Gets the groupId value.
        /// </summary>
        string GroupId { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the private link resource required member names.
        /// </summary>
        /// <summary>
        /// Gets the requiredMembers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }
    }
}