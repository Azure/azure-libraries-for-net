// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.EventHub.Fluent.Models
{
    /// <summary>
    /// Defines values for AccessRights.
    /// </summary>
    public class AccessRights : ExpandableStringEnum<AccessRights>
    {
        public static readonly AccessRights Manage = Parse("Manage");
        public static readonly AccessRights Send = Parse("Send");
        public static readonly AccessRights Listen = Parse("Listen");
    }
}
