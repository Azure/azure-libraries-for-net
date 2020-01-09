// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal class AzureFirewallApplicationRuleCollectionImpl :
        Wrapper<AzureFirewallApplicationRuleCollectionInner>,
        IAzureFirewallApplicationRuleCollection
    {
        internal AzureFirewallApplicationRuleCollectionImpl(AzureFirewallApplicationRuleCollectionInner inner)
            : base(inner)
        {
        }

        int? IAzureFirewallApplicationRuleCollection.Priority
        {
            get
            {
                return Inner.Priority;
            }
        }

        AzureFirewallRCAction IAzureFirewallApplicationRuleCollection.Action
        {
            get
            {
                return Inner.Action;
            }
        }

        IReadOnlyList<AzureFirewallApplicationRule> IAzureFirewallApplicationRuleCollection.Rules
        {
            get
            {
                List<AzureFirewallApplicationRule> rules = new List<AzureFirewallApplicationRule>();
                if (Inner.Rules != null)
                {
                    rules = new List<AzureFirewallApplicationRule>(Inner.Rules);
                }
                return rules.AsReadOnly();
            }
        }

        ProvisioningState IAzureFirewallApplicationRuleCollection.ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        string IAzureFirewallApplicationRuleCollection.Name
        {
            get
            {
                return Inner.Name;
            }
        }

        string IAzureFirewallApplicationRuleCollection.Etag
        {
            get
            {
                return Inner.Etag;
            }
        }

        string IAzureFirewallApplicationRuleCollection.Id
        {
            get
            {
                return Inner.Id;
            }
        }
    }
}
