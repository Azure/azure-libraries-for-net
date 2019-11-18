// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A private link resource.
    /// </summary>
    public partial class PrivateLinkResourceImpl :
        Wrapper<Models.PrivateLinkResourceInner>,
        IPrivateLinkResource
    {
        internal PrivateLinkResourceImpl(Models.PrivateLinkResourceInner innerObject)
            : base(innerObject)
        {
        }

        public string GroupId()
        {
            return Inner.GroupId;
        }

        public string Id()
        {
            return Inner.Id;
        }

        public string Name()
        {
            return Inner.Name;
        }

        public IList<string> RequiredMembers()
        {
            return Inner.RequiredMembers;
        }

        public string Type()
        {
            return Inner.Type;
        }
    }
}