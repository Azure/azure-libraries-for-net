// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  ActivityLogAlerts.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWN0aXZpdHlMb2dBbGVydHNJbXBs
    internal partial class ActivityLogAlertsImpl :
        TopLevelModifiableResources<IActivityLogAlert, ActivityLogAlertImpl, ActivityLogAlertResourceInner, IActivityLogAlertsOperations, MonitorManager>,
        IActivityLogAlerts
    {

        ///GENMHASH:F8D3B82AA31AB059BC1C918008DF3E2A:AFEB1F416BE811537ADFAB52035F7907
        internal ActivityLogAlertsImpl(MonitorManager monitorManager)
            : base(monitorManager.Inner.ActivityLogAlerts, monitorManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:648BBDBC0D111882A7B3E1D836899F04
        protected override ActivityLogAlertImpl WrapModel(string name)
        {
            return new ActivityLogAlertImpl(name, new ActivityLogAlertResourceInner(), this.Manager);
        }

        ///GENMHASH:9F8B6BDE6F07CCC4CC4A20EA49624620:880FB60A0EB367E0C3B1159A89BC7B21
        protected override IActivityLogAlert WrapModel(ActivityLogAlertResourceInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new ActivityLogAlertImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ActivityLogAlertImpl Define(string name)
        {
            return WrapModel(name);
        }

        // catch up methods
        protected override async Task<IPage<ActivityLogAlertResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return new ActivityLogAlertResourceInnerPage(await Inner.ListBySubscriptionIdAsync(cancellationToken));
        }

        protected override async Task<IPage<ActivityLogAlertResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ActivityLogAlertResourceInner>>(null);
        }

        protected override async Task<IPage<ActivityLogAlertResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return new ActivityLogAlertResourceInnerPage(await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken));
        }

        protected override async Task<IPage<ActivityLogAlertResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ActivityLogAlertResourceInner>>(null);
        }

        protected override async Task<ActivityLogAlertResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }
    }
}