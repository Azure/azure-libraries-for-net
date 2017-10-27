// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeering.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Represents Express Route Circuit Peerings collection associated with Network Watcher.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRXhwcmVzc1JvdXRlQ2lyY3VpdFBlZXJpbmdzSW1wbA==
    internal partial class ExpressRouteCircuitPeeringsImpl  :
        IndependentChildrenImpl<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering,Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuitPeeringImpl,Models.ExpressRouteCircuitPeeringInner,Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeeringsOperations,Microsoft.Azure.Management.Network.Fluent.INetworkManager,Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit>,
        IExpressRouteCircuitPeerings
    {
        private ExpressRouteCircuitImpl parent;
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IExpressRouteCircuit Parent()
        {
            //$ return parent;

            return null;
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:51D446831672E4ADA11ECA0ACA7B7567
        public async Task<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Inner.GetAsync(resourceGroup, parentName, name)
            //$ .Map(new Func1<ExpressRouteCircuitPeeringInner, ExpressRouteCircuitPeering>() {
            //$ @Override
            //$ public ExpressRouteCircuitPeering call(ExpressRouteCircuitPeeringInner inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:C9F03D33742DDC970FAC4D8DB1A57D4A
        public async Task<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return Inner.GetAsync(parent.ResourceGroupName(), parent.Name(), name)
            //$ .Map(new Func1<ExpressRouteCircuitPeeringInner, ExpressRouteCircuitPeering>() {
            //$ @Override
            //$ public ExpressRouteCircuitPeering call(ExpressRouteCircuitPeeringInner inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            //$ deleteByNameAsync(name).Await();

        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:720D92FD5E31F427626DBAEEEBF372F1
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> List()
        {
            //$ return (new PagedListConverter<ExpressRouteCircuitPeeringInner, ExpressRouteCircuitPeering>() {
            //$ @Override
            //$ public ExpressRouteCircuitPeering typeConvert(ExpressRouteCircuitPeeringInner inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ }).Convert(ReadableWrappersImpl.ConvertToPagedList(Inner.List(parent.ResourceGroupName(), parent.Name())));

            return null;
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:1B548782C32FC0F04862DDDB5537335F
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> ListByParent(string resourceGroupName, string parentName)
        {
            //$ return wrapList(this.Inner.List(resourceGroupName, parentName));

            return null;
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:AFCD61B362D6BFBAB04EC3872A0EDD43
        public async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(groupName, parentName, name).ToCompletable();

            return null;
        }

        ///GENMHASH:ECAE06A61F07DA1F3D1A8D023A8B2918:DDB2BB043185E9D0C3266308196FB6CC
        public ExpressRouteCircuitPeeringImpl DefineMicrosoftPeering()
        {
            //$ return new ExpressRouteCircuitPeeringImpl(parent, new ExpressRouteCircuitPeeringInner(), Inner, ExpressRouteCircuitPeeringType.MICROSOFT_PEERING);

            return null;
        }

        ///GENMHASH:21D478F33B98E8BA003B0CA8A77DC927:E43675D6B0AF2246CC7B27D4E8ADDC2C
        public ExpressRouteCircuitPeeringImpl DefineAzurePublicPeering()
        {
            //$ return new ExpressRouteCircuitPeeringImpl(parent, new ExpressRouteCircuitPeeringInner(), Inner, ExpressRouteCircuitPeeringType.AZURE_PUBLIC_PEERING);

            return null;
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:6B6D1D91AC2FCE3076EBD61D0DB099CF
        public IExpressRouteCircuitPeering GetByName(string name)
        {
            //$ return getByNameAsync(name).ToBlocking().Last();

            return null;
        }

        ///GENMHASH:921F345925153FFB7B665161B62A21A2:EF8777BA4B3D684F2BED0D68FF019106
        public ExpressRouteCircuitPeeringImpl DefineAzurePrivatePeering()
        {
            //$ return new ExpressRouteCircuitPeeringImpl(parent, new ExpressRouteCircuitPeeringInner(), Inner, ExpressRouteCircuitPeeringType.AZURE_PRIVATE_PEERING);

            return null;
        }

        /// <return>An observable emits packet captures in this collection.</return>
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:DBC1BFDB73D33E089DF6B74E82CCBAA9
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IExpressRouteCircuitPeering>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(Inner.ListAsync(parent.ResourceGroupName(), parent.Name()));

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:B587CE64B62DCF93404FA1B6C5D51EC7
        protected ExpressRouteCircuitPeeringImpl WrapModel(string name)
        {
            //$ return new ExpressRouteCircuitPeeringImpl(parent, new ExpressRouteCircuitPeeringInner(), Inner, new ExpressRouteCircuitPeeringType(name));

            return null;
        }

        ///GENMHASH:90E449BE53BE2022DD4BD866D5A6C29C:DD8B5257C314F4DDE0536EE2BF670307
        protected ExpressRouteCircuitPeeringImpl WrapModel(ExpressRouteCircuitPeeringInner inner)
        {
            //$ return (inner == null) ? null : new ExpressRouteCircuitPeeringImpl(parent, inner, Inner, inner.PeeringType());
            //$ }

            return null;
        }

        /// <summary>
        /// Creates a new ExpressRouteCircuitPeeringsImpl.
        /// </summary>
        /// <param name="parent">The Express Route Circuit associated with ExpressRouteCircuitPeering.</param>
        ///GENMHASH:AF86E70E6B4EC7F54D9A1FE126AFCEF1:A2C4AF47D7DA8DBEF35F6EEE6412C5FA
        internal  ExpressRouteCircuitPeeringsImpl(ExpressRouteCircuitImpl parent)
        {
            //$ super(parent.Manager().Inner.ExpressRouteCircuitPeerings(), parent.Manager());
            //$ this.parent = parent;
            //$ }

        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:E5B162BD6005B3BA236ADFAE6CA0A4CF
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(parent.ResourceGroupName(),
            //$ parent.Name(),
            //$ name).ToCompletable();

            return null;
        }
    }
}