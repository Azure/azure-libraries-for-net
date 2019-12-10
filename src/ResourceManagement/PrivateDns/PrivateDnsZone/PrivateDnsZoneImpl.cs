// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for PrivateDnsZone.
    /// </summary>
    internal partial class PrivateDnsZoneImpl :
        GroupableResource<IPrivateDnsZone,
            PrivateZoneInner,
            PrivateDnsZoneImpl,
            IPrivateDnsZoneManager,
            PrivateDnsZone.Definition.IWithCreate,
            PrivateDnsZone.Definition.IWithCreate,
            PrivateDnsZone.Definition.IWithCreate,
            PrivateDnsZone.Update.IUpdate>,
        IPrivateDnsZone,
        PrivateDnsZone.Definition.IDefinition,
        PrivateDnsZone.Update.IUpdate
    {
        private string privateDnsZoneETag;
        private PrivateDnsRecordSetsImpl recordSetsImpl;
        private VirtualNetworkLinksImpl virtualNetworkLinksImpl;

        internal PrivateDnsZoneImpl(string name, PrivateZoneInner innerModel, IPrivateDnsZoneManager privateDnsZoneManager)
            : base(name, innerModel, privateDnsZoneManager)
        {
            recordSetsImpl = new PrivateDnsRecordSetsImpl(this);
            virtualNetworkLinksImpl = new VirtualNetworkLinksImpl(this);
            InitRecordSets();
            VirtualNetworkLinks = virtualNetworkLinksImpl;
            virtualNetworkLinksImpl.ClearPendingOperations();
        }

        private void InitRecordSets()
        {
            AaaaRecordSets = new AaaaRecordSetsImpl(this);
            ARecordSets = new ARecordSetsImpl(this);
            CnameRecordSets = new CnameRecordSetsImpl(this);
            MxRecordSets = new MxRecordSetsImpl(this);
            PtrRecordSets = new PtrRecordSetsImpl(this);
            SoaRecordSets = new SoaRecordSetsImpl(this);
            SrvRecordSets = new SrvRecordSetsImpl(this);
            TxtRecordSets = new TxtRecordSetsImpl(this);
            recordSetsImpl.ClearPendingOperations();
        }

        /// <summary>
        /// Gets the etag associated with the private DNS zone.
        /// </summary>
        public string ETag
        {
            get
            {
                return Inner.Etag;
            }
        }

        /// <summary>
        /// Gets the maximum number of record sets that can be created in this
        /// Private DNS zone.
        /// </summary>
        public long MaxNumberOfRecordSets
        {
            get
            {
                return Inner.MaxNumberOfRecordSets.HasValue ? Inner.MaxNumberOfRecordSets.Value : 0;
            }
        }

        /// <summary>
        /// Gets the current number of record sets in this Private DNS zone.
        /// </summary>
        public long NumberOfRecordSets
        {
            get
            {
                return Inner.NumberOfRecordSets.HasValue ? Inner.NumberOfRecordSets.Value : 0;
            }
        }

        /// <summary>
        /// Gets the maximum number of virtual networks that can be linked to
        /// this Private DNS zone.
        /// </summary>
        public long MaxNumberOfVirtualNetworkLinks
        {
            get
            {
                return Inner.MaxNumberOfVirtualNetworkLinks.HasValue ? Inner.MaxNumberOfVirtualNetworkLinks.Value : 0;
            }
        }

        /// <summary>
        /// Gets the current number of virtual networks that are linked to this
        /// Private DNS zone.
        /// </summary>
        public long NumberOfVirtualNetworkLinks
        {
            get
            {
                return Inner.MaxNumberOfVirtualNetworkLinks.HasValue ? Inner.MaxNumberOfVirtualNetworkLinks.Value : 0;
            }
        }

        /// <summary>
        /// Gets the maximum number of virtual networks that can be linked to
        /// this Private DNS zone with registration enabled.
        /// </summary>
        public long MaxNumberOfVirtualNetworkLinksWithRegistration
        {
            get
            {
                return Inner.MaxNumberOfVirtualNetworkLinksWithRegistration.HasValue ? Inner.MaxNumberOfVirtualNetworkLinksWithRegistration.Value : 0;
            }
        }

        /// <summary>
        /// Gets the current number of virtual networks that are linked to this
        /// Private DNS zone with registration enabled.
        /// </summary>
        public long NumberOfVirtualNetworkLinksWithRegistration
        {
            get
            {
                return Inner.NumberOfVirtualNetworkLinksWithRegistration.HasValue ? Inner.NumberOfVirtualNetworkLinksWithRegistration.Value : 0;
            }
        }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// Possible values include: 'Creating', 'Updating', 'Deleting',
        /// 'Succeeded', 'Failed', 'Canceled'
        /// </summary>
        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing A (IPv4 address) records.
        /// </summary>
        public IARecordSets ARecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing AAAA (IPv6 address) records.
        /// </summary>
        public IAaaaRecordSets AaaaRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing CNAME (canonical name) records.
        /// </summary>
        public ICnameRecordSets CnameRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing MX (mail exchange) records.
        /// </summary>
        public IMxRecordSets MxRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing PTR (pointer) records.
        /// </summary>
        public IPtrRecordSets PtrRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing SOA (start of authority) records.
        /// </summary>
        public ISoaRecordSets SoaRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing SRV (service) records.
        /// </summary>
        public ISrvRecordSets SrvRecordSets { get; private set; }

        /// <summary>
        /// Gets entry point to manage record sets in this private zone containing TXT (text) records.
        /// </summary>
        public ITxtRecordSets TxtRecordSets { get; private set; }

        public IVirtualNetworkLinks VirtualNetworkLinks { get; private set; }

        public async override Task<IPrivateDnsZone> CreateResourceAsync(CancellationToken cancellationToken)
        {
            PrivateZoneInner innerResource;
            if(IsInCreateMode)
            {
                innerResource = await Manager.Inner.PrivateZones.CreateOrUpdateAsync(
                    ResourceGroupName,
                    Name,
                    Inner,
                    ifMatch: null,
                    ifNoneMatch: privateDnsZoneETag,
                    cancellationToken: cancellationToken);
            }
            else
            {
                innerResource = await Manager.Inner.PrivateZones.CreateOrUpdateAsync(
                    ResourceGroupName,
                    Name,
                    Inner,
                    ifMatch: privateDnsZoneETag,
                    ifNoneMatch: null,
                    cancellationToken: cancellationToken);
            }
            SetInner(innerResource);
            privateDnsZoneETag = null;
            await recordSetsImpl.CommitAndGetAllAsync(cancellationToken);
            await virtualNetworkLinksImpl.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        /// <summary>
        /// Lists all the record sets in this private zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        public IEnumerable<IPrivateDnsRecordSet> ListRecordSets(string recordSetNameSuffix = default(string), int? pageSize = default(int?))
        {
            return Extensions.Synchronize(() => ListRecordSetsAsync(recordSetNameSuffix, pageSize, pageSize == null, CancellationToken.None));
        }

        /// <summary>
        /// Asynchronously lists all the record sets in this private zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        public async Task<IPagedCollection<IPrivateDnsRecordSet>> ListRecordSetsAsync(string recordSetNameSuffix = default(string), int? pageSize = default(int?), bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPrivateDnsRecordSet, RecordSetInner>.LoadPage(
                async(cancellation) => await Manager.Inner.RecordSets.ListAsync(
                    ResourceGroupName,
                    Name,
                    top: pageSize,
                    recordsetnamesuffix: recordSetNameSuffix,
                    cancellationToken: cancellation),
                Manager.Inner.RecordSets.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken
                );
        }

        private PrivateDnsRecordSetImpl WrapModel(RecordSetInner inner)
        {
            var recordSet = new PrivateDnsRecordSetImpl(inner.Name, inner.Type, this, inner);
            switch(recordSet.RecordType())
            {
                case RecordType.A:
                    return new ARecordSetImpl(inner.Name, this, inner);
                case RecordType.AAAA:
                    return new AaaaRecordSetImpl(inner.Name, this, inner);
                case RecordType.CNAME:
                    return new CnameRecordSetImpl(inner.Name, this, inner);
                case RecordType.MX:
                    return new MxRecordSetImpl(inner.Name, this, inner);
                case RecordType.PTR:
                    return new PtrRecordSetImpl(inner.Name, this, inner);
                case RecordType.SOA:
                    return new SoaRecordSetImpl(inner.Name, this, inner);
                case RecordType.SRV:
                    return new SrvRecordSetImpl(inner.Name, this, inner);
                case RecordType.TXT:
                    return new TxtRecordSetImpl(inner.Name, this, inner);
                default:
                    return recordSet;
            }
        }

        protected override async Task<PrivateZoneInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.PrivateZones.GetAsync(
                ResourceGroupName,
                Name,
                cancellationToken);
        }

        internal PrivateDnsZoneImpl WithETagCheckInternal()
        {
            if(IsInCreateMode)
            {
                privateDnsZoneETag = "*";
                return this;
            }
            return WithETagCheckInternal(Inner.Etag);
        }

        internal PrivateDnsZoneImpl WithETagCheckInternal(string eTagValue)
        {
            privateDnsZoneETag = eTagValue;
            return this;
        }

        internal PrivateDnsRecordSetImpl DefineAaaaRecordSetInternal(string name)
        {
            return recordSetsImpl.DefineAaaaRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefineARecordSetInternal(string name)
        {
            return recordSetsImpl.DefineARecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefineCnameRecordSetInternal(string name)
        {
            return recordSetsImpl.DefineCnameRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefineMxRecordSetInternal(string name)
        {
            return recordSetsImpl.DefineMxRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefinePtrRecordSetInternal(string name)
        {
            return recordSetsImpl.DefinePtrRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefineSoaRecordSetInternal()
        {
            return recordSetsImpl.DefineSoaRecordSet();
        }

        internal PrivateDnsRecordSetImpl DefineSrvRecordSetInternal(string name)
        {
            return recordSetsImpl.DefineSrvRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl DefineTxtRecordSetInternal(string name)
        {
            return recordSetsImpl.DefineTxtRecordSet(name);
        }

        internal VirtualNetworkLinkImpl DefineVirtualNetworkLinkInternal(string name)
        {
            return virtualNetworkLinksImpl.DefineVirtualNetworkLink(name);
        }

        internal PrivateDnsRecordSetImpl UpdateAaaaRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateAaaaRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdateARecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateARecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdateCnameRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateCnameRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdateMxRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateMxRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdatePtrRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdatePtrRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdateSoaRecordSetInternal()
        {
            return recordSetsImpl.UpdateSoaRecordSet();
        }

        internal PrivateDnsRecordSetImpl UpdateSrvRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateSrvRecordSet(name);
        }

        internal PrivateDnsRecordSetImpl UpdateTxtRecordSetInternal(string name)
        {
            return recordSetsImpl.UpdateTxtRecordSet(name);
        }

        internal VirtualNetworkLinkImpl UpdateVirtualNetworkLinkInternal(string name)
        {
            return virtualNetworkLinksImpl.UpdateVirtualNetworkLink(name);
        }

        internal PrivateDnsZoneImpl WithoutAaaaRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutAaaaRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutARecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutARecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutCnameRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutCnameRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutMxRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutMxRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutPtrRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutPtrRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutSoaRecordSetInternal(string eTagValue)
        {
            recordSetsImpl.WithoutSoaRecordSet(eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutSrvRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutSrvRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutTxtRecordSetInternal(string name, string eTagValue)
        {
            recordSetsImpl.WithoutTxtRecordSet(name, eTagValue);
            return this;
        }

        internal PrivateDnsZoneImpl WithoutVirtualNetworkLinkInternal(string name, string eTagValue)
        {
            virtualNetworkLinksImpl.WithoutVirtualNetworkLink(name, eTagValue);
            return this;
        }

        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing private DNS zone.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PrivateDnsZone.Definition.IWithCreate PrivateDnsZone.Definition.IWithETagCheck.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies If-Match header to the current eTag value associated with the private DNS Zone.
        /// </summary>
        /// <return>The next stage of the update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithETagCheck.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies If-Match header to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithETagCheck.WithEtagCheck(string eTagValue)
        {
            return WithETagCheckInternal(eTagValue);
        }

        /// <summary>
        /// Specifies definition of an AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineAaaaRecordSet(string name)
        {
            return DefineAaaaRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IARecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineARecordSet(string name)
        {
            return DefineARecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone definition.</return>
        PrivateDnsRecordSet.UpdateDefinition.ICnameRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineCnameRecordSet(string name)
        {
            return DefineCnameRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IMxRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineMxRecordSet(string name)
        {
            return DefineMxRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefinePtrRecordSet(string name)
        {
            return DefinePtrRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ISoaRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineSoaRecordSet()
        {
            return DefineSoaRecordSetInternal();
        }

        /// <summary>
        /// Specifies definition of a SRV record set.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineSrvRecordSet(string name)
        {
            return DefineSrvRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a TXT record set.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithRecordSet.DefineTxtRecordSet(string name)
        {
            return DefineTxtRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.Update.IUpdateAaaaRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateAaaaRecordSet(string name)
        {
            return UpdateAaaaRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateARecordSet(string name)
        {
            return UpdateARecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The stage representing configuration for the CNAME record set.</return>
        PrivateDnsRecordSet.Update.IUpdateARecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateCnameRecordSet(string name)
        {
            return UpdateCnameRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.Update.IUpdateMxRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateMxRecordSet(string name)
        {
            return UpdateMxRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.Update.IUpdatePtrRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdatePtrRecordSet(string name)
        {
            return UpdatePtrRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.Update.IUpdateSoaRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateSoaRecordSet()
        {
            return UpdateSoaRecordSetInternal();
        }

        /// <summary>
        /// Specifies update of a SRV record set.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.Update.IUpdateSrvRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateSrvRecordSet(string name)
        {
            return UpdateSrvRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies update of a TXT record set.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.Update.IUpdateTxtRecordSet PrivateDnsZone.Update.IWithRecordSet.UpdateTxtRecordSet(string name)
        {
            return UpdateTxtRecordSetInternal(name);
        }

        /// <summary>
        /// Removes a AAAA record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutAaaaRecordSet(string name)
        {
            return WithoutAaaaRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a AAAA record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutAaaaRecordSet(string name, string eTagValue)
        {
            return WithoutAaaaRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a A record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutARecordSet(string name)
        {
            return WithoutARecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a A record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutARecordSet(string name, string eTagValue)
        {
            return WithoutARecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a CNAME record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutCnameRecordSet(string name)
        {
            return WithoutCnameRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a CNAME record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutCnameRecordSet(string name, string eTagValue)
        {
            return WithoutCnameRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a MX record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutMxRecordSet(string name)
        {
            return WithoutMxRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a MX record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutMxRecordSet(string name, string eTagValue)
        {
            return WithoutMxRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a PTR record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutPtrRecordSet(string name)
        {
            return WithoutPtrRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a PTR record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutPtrRecordSet(string name, string eTagValue)
        {
            return WithoutPtrRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a SOA record set in the private DNS zone.
        /// </summary>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutSoaRecordSet()
        {
            return WithoutSoaRecordSetInternal(null);
        }

        /// <summary>
        /// Removes a SOA record set in the private DNS zone.
        /// </summary>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutSoaRecordSet(string eTagValue)
        {
            return WithoutSoaRecordSetInternal(eTagValue);
        }

        /// <summary>
        /// Removes a SRV record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutSrvRecordSet(string name)
        {
            return WithoutSrvRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a SRV record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutSrvRecordSet(string name, string eTagValue)
        {
            return WithoutSrvRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Removes a TXT record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutTxtRecordSet(string name)
        {
            return WithoutTxtRecordSetInternal(name, null);
        }

        /// <summary>
        /// Removes a TXT record set in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithRecordSet.WithoutTxtRecordSet(string name, string eTagValue)
        {
            return WithoutTxtRecordSetInternal(name, eTagValue);
        }

        /// <summary>
        /// Specifies definition of an AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        PrivateDnsRecordSet.Definition.IAaaaRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineAaaaRecordSet(string name)
        {
            return DefineAaaaRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        PrivateDnsRecordSet.Definition.IARecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineARecordSet(string name)
        {
            return DefineARecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a CNAME record set.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone definition.</return>
        PrivateDnsRecordSet.Definition.ICnameRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineCnameRecordSet(string name)
        {
            return DefineCnameRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        PrivateDnsRecordSet.Definition.IMxRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineMxRecordSet(string name)
        {
            return DefineMxRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        PrivateDnsRecordSet.Definition.IPtrRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefinePtrRecordSet(string name)
        {
            return DefinePtrRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a SOA record set.
        /// </summary>
        /// <return>The stage representing configuration for the SOA record set.</return>
        PrivateDnsRecordSet.Definition.ISoaRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineSoaRecordSet()
        {
            return DefineSoaRecordSetInternal();
        }

        /// <summary>
        /// Specifies definition of a SRV record set.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        PrivateDnsRecordSet.Definition.ISrvRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineSrvRecordSet(string name)
        {
            return DefineSrvRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a TXT record set.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        PrivateDnsRecordSet.Definition.ITxtRecordSetBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithRecordSet.DefineTxtRecordSet(string name)
        {
            return DefineTxtRecordSetInternal(name);
        }

        /// <summary>
        /// Specifies definition of a virtual network link.
        /// </summary>
        /// <param name="name">The name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.Definition.IBlank<PrivateDnsZone.Definition.IWithCreate> PrivateDnsZone.Definition.IWithVirtualNetworkLink.DefineVirtualNetworkLink(string name)
        {
            return DefineVirtualNetworkLinkInternal(name);
        }

        /// <summary>
        /// Specifies definition of a virtual network link.
        /// </summary>
        /// <param name="name">The name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.UpdateDefinition.IBlank<PrivateDnsZone.Update.IUpdate> PrivateDnsZone.Update.IWithVirtualNetworkLink.DefineVirtualNetworkLink(string name)
        {
            return DefineVirtualNetworkLinkInternal(name);
        }

        /// <summary>
        /// Specifies update of a virtual network link.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <return>The stage representing configuration for the virtual network link.</return>
        VirtualNetworkLink.Update.IUpdate PrivateDnsZone.Update.IWithVirtualNetworkLink.UpdateVirtualNetworkLink(string name)
        {
            return UpdateVirtualNetworkLinkInternal(name);
        }

        /// <summary>
        /// Removes a virtual network link in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithVirtualNetworkLink.WithoutVirtualNetworkLink(string name)
        {
            return WithoutVirtualNetworkLinkInternal(name, null);
        }

        /// <summary>
        /// Removes a virtual network link in the private DNS zone.
        /// </summary>
        /// <param name="name">Name of the virtual network link.</param>
        /// <param name="eTagValue">The etag to use for concurrent protection.</param>
        /// <return>The next stage of private DNS zone update.</return>
        PrivateDnsZone.Update.IUpdate PrivateDnsZone.Update.IWithVirtualNetworkLink.WithoutVirtualNetworkLink(string name, string eTagValue)
        {
            return WithoutVirtualNetworkLinkInternal(name, eTagValue);
        }
    }
}
