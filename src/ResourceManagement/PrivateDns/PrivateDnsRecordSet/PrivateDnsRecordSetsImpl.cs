// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Represents a record set collection associated with a private DNS zone.
    /// </summary>
    internal class PrivateDnsRecordSetsImpl :
        ExternalChildResourcesNonCached<PrivateDnsRecordSetImpl, IPrivateDnsRecordSet, RecordSetInner, IPrivateDnsZone, PrivateDnsZoneImpl>
    {
        private const long defaultTtlInSeconds = 3600;

        /// <summary>
        /// Creates new PrivateDnsRecordSetsImpl.
        /// </summary>
        /// <param name="parent">The parent private DNS zone of the record set.</param>
        internal PrivateDnsRecordSetsImpl(PrivateDnsZoneImpl parent)
            : base(parent, "PrivateDnsRecordSet")
        {
        }

        internal PrivateDnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(AaaaRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineARecordSet(string name)
        {
            return SetDefaults(PrepareDefine(ARecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineCnameRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(CnameRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineMxRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(MxRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(PtrRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineSoaRecordSet()
        {
            return SetDefaults(PrepareDefine(SoaRecordSetImpl.NewRecordSet(Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(SrvRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            return SetDefaults(PrepareDefine(TxtRecordSetImpl.NewRecordSet(name, Parent)));
        }

        internal PrivateDnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            return PrepareUpdate(AaaaRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateARecordSet(string name)
        {
            return PrepareUpdate(ARecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateCnameRecordSet(string name)
        {
            return PrepareUpdate(CnameRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateMxRecordSet(string name)
        {
            return PrepareUpdate(MxRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            return PrepareUpdate(PtrRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateSoaRecordSet()
        {
            return PrepareUpdate(SoaRecordSetImpl.NewRecordSet(Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            return PrepareUpdate(SrvRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal PrivateDnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            return PrepareUpdate(TxtRecordSetImpl.NewRecordSet(name, Parent));
        }

        internal void WithoutAaaaRecordSet(string name, string eTagValue)
        {
            PrepareRemove(AaaaRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutARecordSet(string name, string eTagValue)
        {
            PrepareRemove(ARecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutCnameRecordSet(string name, string eTagValue)
        {
            PrepareRemove(CnameRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutMxRecordSet(string name, string eTagValue)
        {
            PrepareRemove(MxRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutPtrRecordSet(string name, string eTagValue)
        {
            PrepareRemove(PtrRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutSoaRecordSet( string eTagValue)
        {
            PrepareRemove(SoaRecordSetImpl.NewRecordSet(Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutSrvRecordSet(string name, string eTagValue)
        {
            PrepareRemove(SrvRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        internal void WithoutTxtRecordSet(string name, string eTagValue)
        {
            PrepareRemove(TxtRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        private PrivateDnsRecordSetImpl SetDefaults(PrivateDnsRecordSetImpl recordSet)
        {
            return recordSet.WithTimeToLiveInternal(defaultTtlInSeconds);
        }

        internal void ClearPendingOperations()
        {
            collection.Clear();
        }
    }
}
