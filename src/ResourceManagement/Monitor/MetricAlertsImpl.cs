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
    /// Implementation for  MetricAlerts.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljQWxlcnRzSW1wbA==
    internal partial class MetricAlertsImpl :
        TopLevelModifiableResources<IMetricAlert, MetricAlertImpl, MetricAlertResourceInner, IMetricAlertsOperations, MonitorManager>,
        IMetricAlerts
    {

        ///GENMHASH:CA4E0F7776F86D474617A98C0820B853:F85A80CDC97F925E518A32D7F21AC49E
        internal MetricAlertsImpl(MonitorManager monitorManager)
            : base(monitorManager.Inner.MetricAlerts, monitorManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:D3B649BE65613C91605382B3DAA6B9B1
        protected override MetricAlertImpl WrapModel(string name)
        {
            var inner = new MetricAlertResourceInner();
            inner.Enabled = true;
            inner.AutoMitigate = true;
            return new MetricAlertImpl(name, inner, this.Manager);
        }

        ///GENMHASH:59B19F19ABCCDD3C1BABE0FF100AE147:5FA12F364CD1704EED3894CEB79E2AD2
        protected override IMetricAlert WrapModel(MetricAlertResourceInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new MetricAlertImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public MetricAlertImpl Define(string name)
        {
            return WrapModel(name);
        }

        // catch up methods
        protected override async Task<IPage<MetricAlertResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return new MetricAlertResourceInnerPage(await Inner.ListBySubscriptionAsync(cancellationToken));
        }

        protected override async Task<IPage<MetricAlertResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<MetricAlertResourceInner>>(null);
        }

        protected override async Task<IPage<MetricAlertResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return new MetricAlertResourceInnerPage(await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken));
        }

        protected override async Task<IPage<MetricAlertResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<MetricAlertResourceInner>>(null);
        }

        protected override async Task<MetricAlertResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }
    }
}