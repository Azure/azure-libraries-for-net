// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class DisasterRecoveryPairingAuthorizationRuleImpl 
    {
        /// <return>An observable that emits a single entity containing access keys (primary and secondary).</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey> Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeysAsync(cancellationToken);
        }

        /// <summary>
        /// Gets rights associated with the rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Management.EventHub.Fluent.Models.AccessRights> Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule.Rights
        {
            get
            {
                return this.Rights();
            }
        }

        /// <return>Entity containing access keys (primary and secondary).</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule.GetKeys()
        {
            return this.GetKeys();
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Management.EventHub.Fluent.EventHubManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.EventHubManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }
    }
}