// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A private link resource.
    /// </summary>
    internal partial class PrivateLinkResourceImpl :
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

        public IReadOnlyList<string> RequiredMembers()
        {
            return new List<string>(Inner.RequiredMembers).AsReadOnly();
        }

        public string Type()
        {
            return Inner.Type;
        }
    }
}