// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class AzureFirewallNatRuleCollectionImpl :
        Wrapper<AzureFirewallNatRuleCollectionInner>,
        IAzureFirewallNatRuleCollection
    {
        internal AzureFirewallNatRuleCollectionImpl(AzureFirewallNatRuleCollectionInner inner)
            : base(inner)
        {
        }

        int? IAzureFirewallNatRuleCollection.Priority
        {
            get
            {
                return Inner.Priority;
            }
        }

        AzureFirewallNatRCAction IAzureFirewallNatRuleCollection.Action
        {
            get
            {
                return Inner.Action;
            }
        }

        IReadOnlyList<AzureFirewallNatRule> IAzureFirewallNatRuleCollection.Rules
        {
            get
            {
                List<AzureFirewallNatRule> rules = new List<AzureFirewallNatRule>();
                if (Inner.Rules != null)
                {
                    rules.AddRange(Inner.Rules);
                }
                return rules.AsReadOnly();
            }
        }

        ProvisioningState IAzureFirewallNatRuleCollection.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        string IAzureFirewallNatRuleCollection.Name
        {
            get
            {
                return Inner.Name;
            }
        }

        string IAzureFirewallNatRuleCollection.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        string IAzureFirewallNatRuleCollection.Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
