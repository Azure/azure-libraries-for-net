// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents Connection Monitors collection associated with Network Watcher.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQ29ubmVjdGlvbk1vbml0b3JzSW1wbA==
    internal partial class ConnectionMonitorsImpl  :
        CreatableResources<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor,Microsoft.Azure.Management.Network.Fluent.ConnectionMonitorImpl,Models.ConnectionMonitorResultInner>,
        IConnectionMonitors
    {
        private IConnectionMonitorsOperations innerCollection;
        private NetworkWatcherImpl parent;

        /// <summary>
        /// Creates a new ConnectionMonitorsImpl.
        /// </summary>
        /// <param name="parent">The Network Watcher associated with Connection Monitors.</param>
        ///GENMHASH:5865540D916685B2F54AE4C598C4AF30:8DA68F36B326063647048D7F9A34FC05
        internal  ConnectionMonitorsImpl(IConnectionMonitorsOperations innerCollection, NetworkWatcherImpl parent)
        {
            this.parent = parent;
            this.innerCollection = innerCollection;
        }

        public IConnectionMonitorsOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:2A983980B1FCFB22A7F725D9E0344B2C
        protected override ConnectionMonitorImpl WrapModel(string name)
        {
            return new ConnectionMonitorImpl(name, parent, new ConnectionMonitorResultInner(), Inner);
        }

        ///GENMHASH:B4848DEA51714C68DA2A9E5CB432CD55:4FC3ABB359F0C409D6DDBC71717C2C4F
        protected override IConnectionMonitor WrapModel(ConnectionMonitorResultInner inner)
        {
            return (inner == null) ? null : new ConnectionMonitorImpl(inner.Name, parent, inner, Inner);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:2A983980B1FCFB22A7F725D9E0344B2C
        public ConnectionMonitorImpl Define(string name)
        {
            return new ConnectionMonitorImpl(name, parent, new ConnectionMonitorResultInner(), Inner);;
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }


        ///GENMHASH:4D33A73A344E127F784620E76B686786:B016E9F1E898A15E4995A241E8FB38A5
        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);
            await this.innerCollection.DeleteAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));

        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:E5B162BD6005B3BA236ADFAE6CA0A4CF
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:6B6D1D91AC2FCE3076EBD61D0DB099CF
        public IConnectionMonitor GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:2AE56F064529C0748B82B77D0D690DFC
        public async Task<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await innerCollection.GetAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
            return (WrapModel(inner));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:7C0CDAA3ED1A40FCFEC405E9D09BCB2B
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor> List()
        {
            Func<ConnectionMonitorResultInner, IConnectionMonitor> converter = inner =>
            {
                return ((ConnectionMonitorImpl)WrapModel(inner));
            };
            return Extensions.Synchronize(() => Inner.ListAsync(parent.ResourceGroupName, parent.Name))
                .Select(inner => converter(inner));
        }

        /// <return>An observable emits connection monitors in this collection.</return>
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:1BD69DE9A692366A5C81FE75F43DA924
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IConnectionMonitor>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerConnectionMonitors = await Inner.ListAsync(parent.ResourceGroupName, parent.Name, cancellationToken);
            var result = innerConnectionMonitors.Select((innerPacketCapture) => WrapModel(innerPacketCapture));
            return PagedCollection<IConnectionMonitor, ConnectionMonitorResultInner>.CreateFromEnumerable(result);
        }
    }
}