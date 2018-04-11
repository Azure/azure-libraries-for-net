// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a permission.
    /// </summary>
    public interface IPermission :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.PermissionInner>
    {
        /// <summary>
        /// Gets allowed actions.
        /// </summary>
        IList<string> Actions { get; }

        /// <summary>
        /// Gets denied actions.
        /// </summary>
        IList<string> NotActions { get; }

        /// <summary>
        /// Gets allowed data actions.
        /// </summary>
        IList<string> DataActions { get; }

        /// <summary>
        /// Gets denied data actions.
        /// </summary>
        IList<string> NotDataActions { get; }
    }
}