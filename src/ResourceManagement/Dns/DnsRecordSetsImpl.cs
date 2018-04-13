// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;

    /// <summary>
    /// Represents an record set collection associated with a DNS zone.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRzSW1wbA==
    internal partial class DnsRecordSetsImpl :
        ExternalChildResourcesNonCached<DnsRecordSetImpl, IDnsRecordSet, RecordSetInner, IDnsZone, DnsZoneImpl>
    {
        private const long defaultTtlInSeconds = 3600;

        /// <summary>
        /// Creates new DnsRecordSetsImpl.
        /// </summary>
        /// <param name="parent">The parent DNS zone of the record set.</param>
        ///GENMHASH:679769A0C3AB0DC0D68CC67BCE854713:D191C7503BF1FFF7DC0169944F6D7D1D
        internal DnsRecordSetsImpl(DnsZoneImpl parent)
            : base(parent, "RecordSet")
        {
        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:EC4740AE1730815931674A743CFA405F
        internal DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(AaaaRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:26D2A37A37D05787C741D51B51540036
        internal DnsRecordSetImpl DefineARecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(ARecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:0E653C21FA610AD7BE55F29A75505790:FE5E8EB27FB4ABCF6536E14AAC77C56A
        internal DnsRecordSetImpl DefineCaaRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(CaaRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:D5078976D64C68B60845416B4A519771:63D1257FE4C4E0A90A6B61D62E75B243
        internal DnsRecordSetImpl DefineCNameRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(CNameRecordSetImpl.NewRecordSet(name, this.Parent)));
        }

        ///GENMHASH:7FD0DE0CD548F2703A15E4BAA97D6873:F89F3B1F2BD56AF43A4D34802A0631E2
        internal DnsRecordSetImpl DefineMXRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(MXRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:46C9C87DA2C900034A20B7DB46BD77F5:8BB7B2E82DEC8CA3D4E4D604C40FDD15
        internal DnsRecordSetImpl DefineNSRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(NSRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:2DFEFB602FB64D29979A84CF65A69C61
        internal DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(PtrRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:EEDBF02FD0C3468E6C240E4B90603434
        internal DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(SrvRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:97C26A4AE31E04D6392CA1F0ED41B303
        internal DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(TxtRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:FD0DE8482528744FFBB05D150412A8E3
        internal DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            return base.PrepareUpdate(AaaaRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:2EF7C751D386980613D0960A28E45B96
        internal DnsRecordSetImpl UpdateARecordSet(string name)
        {
            return base.PrepareUpdate(ARecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:4DD4D85C5B408CD0398C0BFCDACCFC59:E939DA7F66049CE24B893A2AF4A5AE45
        internal DnsRecordSetImpl UpdateCaaRecordSet(string name)
        {
            return base.PrepareUpdate(CaaRecordSetImpl.NewRecordSet(name, this.Parent));
        }

        ///GENMHASH:4F52CFFC8EB4D698DB3A4C3B1E187BD0:E3BD08E5FE933A570B0B4BECAAB8332D
        internal DnsRecordSetImpl UpdateCNameRecordSet(string name)
        {
            return this.PrepareUpdate(CNameRecordSetImpl.NewRecordSet(name, this.Parent));
        }

        ///GENMHASH:5CC95DD8B9468242DBEEF10F96E9EECF:1DBE6FD5118017062E44D7FD1F4DC7CC
        internal DnsRecordSetImpl UpdateMXRecordSet(string name)
        {
            return base.PrepareUpdate(MXRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:CC4422F1AB1A272DA6DBEBD9DD8767DF:C631BFEF9752170EDB60599311ACE154
        internal DnsRecordSetImpl UpdateNSRecordSet(string name)
        {
            return base.PrepareUpdate(NSRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:1B2A4B5E7066BFD0B85818CC859F0757
        internal DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            return base.PrepareUpdate(PtrRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:307087E2D68C3C7331CD91AE28C42489:C114B58978EA69D660C2EF5281A61567
        internal DnsRecordSetImpl UpdateSoaRecordSet()
        {
            return base.PrepareUpdate(SoaRecordSetImpl.NewRecordSet(Parent));
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:19CC40D60B6231A8B9D359AFC62E9389
        internal DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            return base.PrepareUpdate(SrvRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:1D57A12FB408D4A35683D2515C9C02C6
        internal DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            return base.PrepareUpdate(TxtRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:1F806E4CBC9AF647A64C1631E4524D83:4EE852CE78913BB7BC91F609C38B4650
        internal void WithCNameRecordSet(string name, string alias)
        {
            CNameRecordSetImpl recordSet = CNameRecordSetImpl.NewRecordSet(name, Parent);
            recordSet.Inner.CnameRecord.Cname = alias;
            this.SetDefaults(base.PrepareDefine(recordSet.WithTimeToLive(defaultTtlInSeconds)));
        }

        ///GENMHASH:762F03CE80F4A9BF3ADBEEC0D41DB5AF:3D390F3CC05AF82A3E866C7ED3823AC5
        internal void WithoutAaaaRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(AaaaRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:B52E7C54A2094CF7BC537D1CC67AD933:780F5F6769B115A637D6C4C0A4B5A95A
        internal void WithoutARecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(ARecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:E515F51C44205F030312A4B9FE9FFF71:F7C62765B0EF2651B439940EDD72D30A
        internal void WithoutCaaRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(CaaRecordSetImpl.NewRecordSet(name, this.Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:69DD1218436902CDC3B7BC8695982064:0C6A030D75273122C7F8AE8A8B9F2610
        internal void WithoutCNameRecordSet(string name, string eTagValue)
        {
            this.PrepareRemove(CNameRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:CAE11DD729AC8148C1BB19AC98C19A66:D19AA3E93E28C2680A74EF50A8D6D4BB
        internal void WithoutMXRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(MXRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:0A638BEAEF3AE7294B3373C1072B1E0A:E4015679DD5DAB294A7133C7CED1679D
        internal void WithoutNSRecordSet(string name, string eTagValue)
        {
            this.PrepareRemove(NSRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:C9A7146C9B1311BD2295FF461FD54E80:0BFB0327C156B42E021F2B7B7D954718
        internal void WithoutPtrRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(PtrRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:EC620CE3EF72DD020734D0F57C7057F2:FE30C4C19C12B6680207B4A1C6F7E5E3
        internal void WithoutSrvRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(SrvRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:2AAD8D85A395EE1384B1E0A6010A750B:9F2576B17FCE81461B0CABD653D22294
        internal void WithoutTxtRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(TxtRecordSetImpl.NewRecordSet(name, this.Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:EDB813BC169498B6DE770C4D9858547C:D7878BB646FC3265F12A85E42D5F6FB5
        private DnsRecordSetImpl SetDefaults(DnsRecordSetImpl recordSet)
        {
            return recordSet.WithTimeToLive(defaultTtlInSeconds);
        }

        internal void ClearPendingOperations()
        {
            this.collection.Clear();
        }
    }
}
