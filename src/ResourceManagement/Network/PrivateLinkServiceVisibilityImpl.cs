// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal class PrivateLinkServiceVisibilityImpl :
        Wrapper<PrivateLinkServiceVisibilityInner>,
        IPrivateLinkServiceVisibility
    {
        internal PrivateLinkServiceVisibilityImpl(PrivateLinkServiceVisibilityInner inner) :
            base(inner)
        {
        }

        public bool Visible
        {
            get
            {
                return Inner.Visible.HasValue && Inner.Visible.Value == true;
            }
        }
    }
}
