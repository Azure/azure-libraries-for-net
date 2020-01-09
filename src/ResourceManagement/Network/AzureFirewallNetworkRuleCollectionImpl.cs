// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class AzureFirewallNetworkRuleCollectionImpl :
        Wrapper<AzureFirewallNetworkRuleCollectionInner>,
        IAzureFirewallNetworkRuleCollection
    {
        internal AzureFirewallNetworkRuleCollectionImpl(AzureFirewallNetworkRuleCollectionInner inner)
            : base(inner)
        {
        }

        int? IAzureFirewallNetworkRuleCollection.Priority
        {
            get
            {
                return Inner.Priority;
            }
        }

        AzureFirewallRCAction IAzureFirewallNetworkRuleCollection.Action
        {
            get
            {
                return Inner.Action;
            }
        }

        IReadOnlyList<AzureFirewallNetworkRule> IAzureFirewallNetworkRuleCollection.Rules
        {
            get
            {
                List<AzureFirewallNetworkRule> rules = new List<AzureFirewallNetworkRule>();
                if (Inner.Rules != null)
                {
                    rules = new List<AzureFirewallNetworkRule>(Inner.Rules);
                }
                return rules.AsReadOnly();
            }
        }

        ProvisioningState IAzureFirewallNetworkRuleCollection.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        string IAzureFirewallNetworkRuleCollection.Name
        {
            get
            {
                return Inner.Name;
            }
        }

        string IAzureFirewallNetworkRuleCollection.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        string IAzureFirewallNetworkRuleCollection.Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
