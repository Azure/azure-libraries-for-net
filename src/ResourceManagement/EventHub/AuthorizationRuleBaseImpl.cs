// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Base implementation for authorization rule.
    /// (Internal use only).
    /// </summary>
    /// <typeparam name="RuleT">Rule fluent model.</typeparam>
    /// <typeparam name="RuleImpl">Implementation of rule fluent model.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkF1dGhvcml6YXRpb25SdWxlQmFzZUltcGw=
    internal abstract partial class AuthorizationRuleBaseImpl<RuleT,RuleImpl, UpdateEntryPoint>  :
        NestedResourceImpl<RuleT, AuthorizationRuleInner, RuleImpl, UpdateEntryPoint>,
        IAuthorizationRule<RuleT>
        where RuleT : class, IHasId
        where RuleImpl : AuthorizationRuleBaseImpl<RuleT, RuleImpl, UpdateEntryPoint>
        where UpdateEntryPoint : class
    {
        ///GENMHASH:6F0F4875025EFAD1501AE24B692D87A3:C5C9A7A1846EEA08D381D40B63B43DC6
        protected AuthorizationRuleBaseImpl(string name, AuthorizationRuleInner inner, IEventHubManager manager) : base(name, inner, manager)
        {
        }

        ///GENMHASH:AB1BA95F78B711F10D574A0046DE17B7:D03B292D619886851FBEC2556FBA2D32
        public IReadOnlyList<AccessRights> Rights
        {
            get
            {
                if (this.Inner.Rights == null)
                {
                    return new List<AccessRights>();
                }
                else
                {
                    return new List<AccessRights>(this.Inner.Rights);
                }
            }
        }

        ///GENMHASH:B5F20FEE4712239FEC489FA348B7432B:8231BB581A68B1C17FCEAAEEBC857049
        public RuleImpl WithListeningEnabled()
        {
            if (this.Inner.Rights == null)
            {
                this.Inner.Rights = new List<AccessRights>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Listen))
            {
                this.Inner.Rights.Add(AccessRights.Listen);
            }
            return (RuleImpl) this;
        }

        ///GENMHASH:C5DDA67F1816E477A8EAA6ECEFBBB25C:A23796BF710470D2B0F0EF3CB21F9D0B
        public RuleImpl WithSendingEnabled()
        {
            if (this.Inner.Rights == null)
            {
                this.Inner.Rights = new List<AccessRights>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Send))
            {
                this.Inner.Rights.Add(AccessRights.Send);
            }
            return (RuleImpl) this;
        }

        ///GENMHASH:D56754248D4EE259AEA7A819BD939780:448F969B7719EB9B90B397331F814EA9
        public RuleImpl WithManagementEnabled()
        {
            WithListeningEnabled();
            WithSendingEnabled();
            if (this.Inner.Rights == null)
            {
                this.Inner.Rights = new List<AccessRights>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Manage))
            {
                this.Inner.Rights.Add(AccessRights.Manage);
            }
            return (RuleImpl) this;
        }


        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<AccessKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:2751D8683222AD34691166D915065302:9B86FC2DF5BE701D70A2B1F445F91E61
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var keysInner = await this.GetKeysInnerAsync(cancellationToken);
            return new EventHubAuthorizationKeyImpl(keysInner);
        }

        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:EACB47A475A2EC02AC952C3B5FCFCC6E
        public IEventHubAuthorizationKey GetKeys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        ///GENMHASH:2A78999F239DA090C8DF19A6D1F08331:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<AccessKeysInner> RegenerateKeysInnerAsync(KeyType keyType, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:70CEBE8DE86892D83B09E339BC4B95FC:B8B9A834DA829DB408BC06F1BD0874E5
        public async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey> RegenerateKeyAsync(KeyType keyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            var keysInner = await this.RegenerateKeysInnerAsync(keyType, cancellationToken);
            return new EventHubAuthorizationKeyImpl(keysInner);
        }

        ///GENMHASH:089CB9C164DC80CDB29D51C8C539E9EA:80AB9608DE4559B7659A43E48078D878
        public IEventHubAuthorizationKey RegenerateKey(KeyType keyType)
        {
            return Extensions.Synchronize(() => RegenerateKeyAsync(keyType));
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:27E486AB74A10242FF421C0798DDC450
        protected abstract override Task<AuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:27E486AB74A10242FF421C0798DDC450
        public abstract override Task<RuleT> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}