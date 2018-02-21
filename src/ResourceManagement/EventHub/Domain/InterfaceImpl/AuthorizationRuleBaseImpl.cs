// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
/**
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    internal abstract partial class AuthorizationRuleBaseImpl<RuleT,RuleImpl> 
    {
        /// <summary>
        /// Regenerates primary or secondary access keys.
        /// </summary>
        /// <param name="keyType">The key to regenerate.</param>
        /// <return>A representation of the deferred computation of this call, returning access keys (primary, secondary) and the connection strings.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<RuleT>.RegenerateKeyAsync(Management.EventHub.Fluent.Models.KeyType keyType, CancellationToken cancellationToken)
        {
            return await this.RegenerateKeyAsync(keyType, cancellationToken) as Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey;
        }

        /// <summary>
        /// Gets rights associated with the authorization rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Management.EventHub.Fluent.Models.AccessRights> Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<RuleT>.Rights
        {
            get
            {
                return this.Rights() as System.Collections.Generic.IReadOnlyList<Management.EventHub.Fluent.Models.AccessRights>;
            }
        }

        /// <return>A representation of the deferred computation of this call, returning access keys (primary, secondary) and the connection strings.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<RuleT>.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeysAsync(cancellationToken) as Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey;
        }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="keyType">The key to regenerate.</param>
        /// <return>The access keys (primary, secondary) and the connection strings.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<RuleT>.RegenerateKey(Management.EventHub.Fluent.Models.KeyType keyType)
        {
            return this.RegenerateKey(keyType) as Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey;
        }

        /// <return>The access keys (primary, secondary) and the connection strings.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<RuleT>.GetKeys()
        {
            return this.GetKeys() as Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey;
        }
    }
}**/