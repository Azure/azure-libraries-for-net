// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal class AutoApprovedPrivateLinkServiceImpl :
        Wrapper<AutoApprovedPrivateLinkService>,
        IAutoApprovedPrivateLinkService
    {
        internal AutoApprovedPrivateLinkServiceImpl(AutoApprovedPrivateLinkService inner) :
            base(inner)
        {
        }

        public string PrivateLinkService
        {
            get
            {
                return Inner.PrivateLinkService;
            }
        }
    }
}
