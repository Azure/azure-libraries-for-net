// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for Permission and its parent interfaces.
    /// </summary>
    public partial class PermissionImpl :
        Wrapper<Models.PermissionInner>,
        IPermission
    {
        public IList<string> Actions => Inner.Actions;

        public IList<string> NotActions => Inner.NotActions;

        public IList<string> DataActions => Inner.DataActions;

        public IList<string> NotDataActions => Inner.NotDataActions;

        public PermissionImpl(PermissionInner innerObject) : base(innerObject)
        {
        }
    }
}