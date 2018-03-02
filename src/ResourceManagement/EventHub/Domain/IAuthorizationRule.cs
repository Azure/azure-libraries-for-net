// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// The base type representing authorization rule of event hub namespace and event hub.
    /// </summary>
    /// <typeparam name="RuleT">The specific authorization rule type.</typeparam>
    public interface IAuthorizationRule<RuleT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.INestedResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.EventHub.Fluent.Models.AuthorizationRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.EventHub.Fluent.IEventHubManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<RuleT>
    {
        /// <summary>
        /// Regenerates primary or secondary access keys.
        /// </summary>
        /// <param name="keyType">The key to regenerate.</param>
        /// <return>A representation of the deferred computation of this call, returning access keys (primary, secondary) and the connection strings.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> RegenerateKeyAsync(Management.EventHub.Fluent.Models.KeyType keyType, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>A representation of the deferred computation of this call, returning access keys (primary, secondary) and the connection strings.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets rights associated with the authorization rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Management.EventHub.Fluent.Models.AccessRights> Rights { get; }

        /// <return>The access keys (primary, secondary) and the connection strings.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey GetKeys();

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="keyType">The key to regenerate.</param>
        /// <return>The access keys (primary, secondary) and the connection strings.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey RegenerateKey(Management.EventHub.Fluent.Models.KeyType keyType);
    }
}