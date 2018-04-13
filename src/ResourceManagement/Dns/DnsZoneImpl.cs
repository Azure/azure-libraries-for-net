// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using ResourceManager.Fluent;
    using DnsZone.Update;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using DnsZone.Definition;
    using Models;
    using System.Linq;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for DnsZone.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNab25lSW1wbA==
    internal partial class DnsZoneImpl :
        GroupableResource<IDnsZone,
            ZoneInner,
            DnsZoneImpl,
            IDnsZoneManager,
            DnsZone.Definition.IWithCreate,
            DnsZone.Definition.IWithCreate,
            DnsZone.Definition.IWithCreate,
            DnsZone.Update.IUpdate>,
        IDnsZone,
        IDefinition,
        IUpdate
    {
        private IARecordSets aRecordSets;
        private IAaaaRecordSets aaaaRecordSets;
        private ICaaRecordSets caaRecordSets;
        private ICNameRecordSets cnameRecordSets;
        private IMXRecordSets mxRecordSets;
        private INSRecordSets nsRecordSets;
        private IPtrRecordSets ptrRecordSets;
        private ISrvRecordSets srvRecordSets;
        private ITxtRecordSets txtRecordSets;
        private string dnsZoneETag;
        private DnsRecordSetsImpl recordSetsImpl;

        ///GENMHASH:75C092938493254EC4132CCB45D76CAB:BAB5977A5FF45F43A2CD21012A939082
        internal DnsZoneImpl(string name, ZoneInner innerModel, IDnsZoneManager dnsZoneManager)
            : base(name, innerModel, dnsZoneManager)
        {
            recordSetsImpl = new DnsRecordSetsImpl(this);
            InitRecordSets();
            if (this.IsInCreateMode)
            {
                // Set the zone type to Public by default
                this.Inner.ZoneType = ZoneType.Public;
            }
        }

        ///GENMHASH:EE1082F2F97076B859060B336D52A16B:0308FBB3971E1B75C4F57CDDABFBE7B5
        private void InitRecordSets()
        {
            this.aRecordSets = new ARecordSetsImpl(this);
            this.aaaaRecordSets = new AaaaRecordSetsImpl(this);
            this.caaRecordSets = new CaaRecordSetsImpl(this);
            this.cnameRecordSets = new CNameRecordSetsImpl(this);
            this.mxRecordSets = new MXRecordSetsImpl(this);
            this.nsRecordSets = new NSRecordSetsImpl(this);
            this.ptrRecordSets = new PtrRecordSetsImpl(this);
            this.srvRecordSets = new SrvRecordSetsImpl(this);
            this.txtRecordSets = new TxtRecordSetsImpl(this);
            this.recordSetsImpl.ClearPendingOperations();
        }

        ///GENMHASH:DAB4AD5D3ECB1C104BA24998D652F125:EA171F8AA2319A7C4E704532D90B1A40
        private IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSetsIntern(string recordSetSuffix, int? pageSize)
        {
            return Extensions.Synchronize(() => Manager.Inner.RecordSets.ListByDnsZoneAsync(
                    ResourceGroupName,
                    Name,
                    top: pageSize,
                    recordsetnamesuffix: recordSetSuffix))
                .Select(inner =>
                {
                    var recordSet = new DnsRecordSetImpl(inner.Name, inner.Type, this, inner);
                    switch (recordSet.RecordType())
                    {
                        case RecordType.A:
                            return new ARecordSetImpl(inner.Name, this, inner);
                        case RecordType.AAAA:
                            return new AaaaRecordSetImpl(inner.Name, this, inner);
                        case RecordType.CAA:
                            return new CaaRecordSetImpl(inner.Name, this, inner);
                        case RecordType.CNAME:
                            return new CNameRecordSetImpl(inner.Name, this, inner);
                        case RecordType.MX:
                            return new MXRecordSetImpl(inner.Name, this, inner);
                        case RecordType.NS:
                            return new NSRecordSetImpl(inner.Name, this, inner);
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
                });
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:A2D475EBB6080BAD35B359545378FA61
        protected override async Task<ZoneInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Zones.GetAsync(
                ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:5954219C81F347FC86D24BBD07355380:8CFD324CF132033F543444B0B1ED6EC5
        public IAaaaRecordSets AaaaRecordSets()
        {
            return aaaaRecordSets;
        }

        ///GENMHASH:30908C2C584102AA407E97019816B480:27721B6B20D724D7EA8DFC88C40CA4FB
        public ZoneType AccessType()
        {
            if (this.Inner.ZoneType.HasValue)
            {
                return this.Inner.ZoneType.Value;
            }
            return ZoneType.Public;
        }

        ///GENMHASH:0EEABE3EECC944A59D1B1E0293BB0E07:27DC8959BB73F2F73F3A3012FEF5E5E3
        public IARecordSets ARecordSets()
        {
            return this.aRecordSets;
        }

        ///GENMHASH:57D3D488926D8724E7134C76E68E0399:A701022C616E42008633C76D5D93FF96
        public ICaaRecordSets CaaRecordSets()
        {
            return this.caaRecordSets;
        }

        ///GENMHASH:994C22D5D7B1BFECF8DE370CCFAAABCC:31CB15D3EB20E8486D2995C3637E584B
        public ICNameRecordSets CNameRecordSets()
        {
            return this.cnameRecordSets;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:A477712159701C72C6656EC139A9653C
        public async override Task<IDnsZone> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ZoneInner innerResource;
            if (IsInCreateMode)
            {
                innerResource = await Manager.Inner.Zones.CreateOrUpdateAsync(ResourceGroupName,
                    Name,
                    Inner,
                    ifMatch: null,
                    ifNoneMatch: this.dnsZoneETag,
                    cancellationToken: cancellationToken);
            }
            else
            {
                innerResource = await Manager.Inner.Zones.CreateOrUpdateAsync(ResourceGroupName,
                    Name,
                    Inner,
                    ifMatch: this.dnsZoneETag,
                    ifNoneMatch: null,
                    cancellationToken: cancellationToken);
            }
            SetInner(innerResource);
            this.dnsZoneETag = null;
            await recordSetsImpl.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:E214246C27C930AF56E1C36A541B6A7C
        public DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            return recordSetsImpl.DefineAaaaRecordSet(name);
        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:6C229B05276C28F28D29D98BCEFCE731
        public DnsRecordSetImpl DefineARecordSet(string name)
        {
            return recordSetsImpl.DefineARecordSet(name);
        }

        ///GENMHASH:0E653C21FA610AD7BE55F29A75505790:434D943441365809C42DAB2AD1D79BF6
        public DnsRecordSetImpl DefineCaaRecordSet(string name)
        {
            return recordSetsImpl.DefineCaaRecordSet(name);
        }

        ///GENMHASH:D5078976D64C68B60845416B4A519771:444527C77E73DC85CBC565951B7BE4D2
        public DnsRecordSetImpl DefineCNameRecordSet(string name)
        {
            return recordSetsImpl.DefineCNameRecordSet(name);
        }

        ///GENMHASH:7FD0DE0CD548F2703A15E4BAA97D6873:E99E8FB8BBD8463CB4478BD78959AB7F
        public DnsRecordSetImpl DefineMXRecordSet(string name)
        {
            return recordSetsImpl.DefineMXRecordSet(name);
        }

        ///GENMHASH:46C9C87DA2C900034A20B7DB46BD77F5:BB970D46BD3AF33A680442CAC58E7941
        public DnsRecordSetImpl DefineNSRecordSet(string name)
        {
            return recordSetsImpl.DefineNSRecordSet(name);
        }

        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:BB1221E0B6A091732CD0CDABB6D59B30
        public DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            return recordSetsImpl.DefinePtrRecordSet(name);
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:49BD30D95E736FFBF71D8B2D9D607E6B
        public DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            return recordSetsImpl.DefineSrvRecordSet(name);
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:3538A2F9D81A129EB1EDD9D2E236CB28
        public DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            return recordSetsImpl.DefineTxtRecordSet(name);
        }

        ///GENMHASH:4913BE5E272184975DDDF5335B476BBD:88ACBC17B6D51A9C055E4CC9834ED144
        public string ETag()
        {
            return this.Inner.Etag;
        }

        ///GENMHASH:3F0A6CC3DBBB3330F47E8737215D7ECE:17D906D49BFF77D8768FB115CC63703F
        public ISoaRecordSet GetSoaRecordSet()
        {
            RecordSetInner inner = Extensions.Synchronize(() => Manager.Inner.RecordSets.GetAsync(ResourceGroupName, Name, "@", RecordType.SOA));
            if (inner == null)
            {
                return null;
            }
            return new SoaRecordSetImpl(inner.Name, this, inner);
        }

        ///GENMHASH:AD6BE020D87A1FB1A7984887D3A945F6:9BB7605D73C9042DD071BBDE7C3B1BA3
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets()
        {
            return this.ListRecordSetsIntern(null, null);
        }

        ///GENMHASH:C7F16AA02D02CBF87CCC8862D08C1466:B09101AB23BBB35855F7C2A6A1D83C2A
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix)
        {
            return this.ListRecordSetsIntern(recordSetNameSuffix, null);
        }

        ///GENMHASH:3CBC468A730B7550412EEA9CB7234833:62AA8C34C5A8D473B0E450D3BDBA0F1E
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(int pageSize)
        {
            return this.ListRecordSetsIntern(null, pageSize);
        }

        ///GENMHASH:D8DD6F1A4E44E62105E4B9AA26CD9AD3:9D05C7F6EF3046ACCC3A3FC33174E0F9
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix, int pageSize)
        {
            return this.ListRecordSetsIntern(recordSetNameSuffix, pageSize);
        }

        ///GENMHASH:92C4BF577DB6715BC383624BAE7694E5:2B66DF1459C7E2E4C3B53DA60A7C27D7
        public long MaxNumberOfRecordSets()
        {
            return Inner.MaxNumberOfRecordSets.HasValue ? Inner.MaxNumberOfRecordSets.Value : 0;
        }

        ///GENMHASH:9346CB4D0F5C719EB9C7E3A3AE77D732:CF958FACD1F19347590706D6D905C707
        public IMXRecordSets MXRecordSets()
        {
            return this.mxRecordSets;
        }

        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:6BCC46117A9CF98B1FAA69B533CB3FC6
        public IReadOnlyList<string> NameServers()
        {
            if (Inner.NameServers == null)
            {
                return new List<string>();
            }
            return Inner.NameServers?.ToList();
        }

        ///GENMHASH:87C6576F7C5A41E12DA61251590634AA:6B2F5F529555C811DA244F0261C7F42C
        public INSRecordSets NSRecordSets()
        {
            return this.nsRecordSets;
        }

        ///GENMHASH:6367F8A407349BBB833D3790CE7781BE:0EADAFD1BDAB624768D805D29684A18A
        public long NumberOfRecordSets()
        {
            return Inner.NumberOfRecordSets.HasValue ? Inner.NumberOfRecordSets.Value : 0;
        }

        ///GENMHASH:82DDFD7EF42553D6690E5976569BC3A5:6F7BEBF118C7CAC28AEBD6B33F9EE35C
        public IPtrRecordSets PtrRecordSets()
        {
            return this.ptrRecordSets;
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:4218AF175C7B7D1CC68B5132CCD1DBB6
        public override async Task<IDnsZone> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ZoneInner inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            InitRecordSets();
            return this;
        }

        ///GENMHASH:B1C8DA2EAF2EFC4F4883789EACB97ADD:26C20804645352591062A08FD1BF06E2
        public IReadOnlyList<string> RegistrationVirtualNetworkIds()
        {
            if (this.Inner.RegistrationVirtualNetworks == null ||
                !this.Inner.RegistrationVirtualNetworks.Any())
            {
                return new List<string>();
            }

            return this.Inner.RegistrationVirtualNetworks
                .Select(rvn => rvn.Id)
                .ToList();
        }

        ///GENMHASH:EEACEA7689CED34CFC7039B17EAF09A4:B295C1D99F3B1F1795DD3EF1790A9983
        public IReadOnlyList<string> ResolutionVirtualNetworkIds()
        {
            if (this.Inner.ResolutionVirtualNetworks == null ||
                !this.Inner.ResolutionVirtualNetworks.Any())
            {
                return new List<string>();
            }

            return this.Inner.ResolutionVirtualNetworks
                .Select(rvn => rvn.Id)
                .ToList();
        }

        ///GENMHASH:F5E15CDECC035B82BF39162780BA9198:A252C32524D1D7E7B960E559973C4ED1
        public ISrvRecordSets SrvRecordSets()
        {
            return this.srvRecordSets;
        }

        ///GENMHASH:94C8130FABA73F5B8D40A0A1D4A5487B:B6F715104E7D3FFD403D53AB2D808CEA
        public ITxtRecordSets TxtRecordSets()
        {
            return this.txtRecordSets;
        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:882238400F73365E4E77FE91D84E9A2A
        public DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            return recordSetsImpl.UpdateAaaaRecordSet(name);
        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:74EE7F6E32AEC8468857AEFE42102157
        public DnsRecordSetImpl UpdateARecordSet(string name)
        {
            return recordSetsImpl.UpdateARecordSet(name);
        }

        ///GENMHASH:4DD4D85C5B408CD0398C0BFCDACCFC59:70DF09D2DA62505CEB5693EBF06B1A6A
        public DnsRecordSetImpl UpdateCaaRecordSet(string name)
        {
            return recordSetsImpl.UpdateCaaRecordSet(name);
        }

        ///GENMHASH:4F52CFFC8EB4D698DB3A4C3B1E187BD0:DD495C2B3433CCF1AE44BD065A83D4D1
        public DnsRecordSetImpl UpdateCNameRecordSet(string name)
        {
            return recordSetsImpl.UpdateCNameRecordSet(name);
        }

        ///GENMHASH:5CC95DD8B9468242DBEEF10F96E9EECF:403E71531E4FCC1F75E236845FCB5CF7
        public DnsRecordSetImpl UpdateMXRecordSet(string name)
        {
            return recordSetsImpl.UpdateMXRecordSet(name);
        }

        ///GENMHASH:CC4422F1AB1A272DA6DBEBD9DD8767DF:691112C89B7DC90A51D7891EEB64B9BB
        public DnsRecordSetImpl UpdateNSRecordSet(string name)
        {
            return recordSetsImpl.UpdateNSRecordSet(name);
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:F4A8120AB0D0D815E862D2EC8C695198
        public DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            return recordSetsImpl.UpdatePtrRecordSet(name);
        }

        ///GENMHASH:4412D5DEE797756911CD87C84F382A35:C88AB21DBBC024A3808484DD59B5C859
        public DnsRecordSetImpl UpdateSoaRecord()
        {
            return recordSetsImpl.UpdateSoaRecordSet();
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:7E7F67AB2A01777A833BEBE956EC369F
        public DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            return recordSetsImpl.UpdateSrvRecordSet(name);
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:668F2022AE8BCCCBCC0F38D5B1CFE316
        public DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            return recordSetsImpl.UpdateTxtRecordSet(name);
        }

        ///GENMHASH:1F806E4CBC9AF647A64C1631E4524D83:2CA42D7AD957BAD1C328C098A1AAEDCA
        public DnsZoneImpl WithCNameRecordSet(string name, string alias)
        {
            recordSetsImpl.WithCNameRecordSet(name, alias);
            return this;
        }

        ///GENMHASH:791593DE94E8D431FBB634CF0578A424:B9A84F7258ADA4688FCB65555E502356
        public DnsZoneImpl WithETagCheck()
        {
            if (IsInCreateMode)
            {
                this.dnsZoneETag = "*";
                return this;
            }
            return this.WithETagCheck(this.Inner.Etag);
        }

        ///GENMHASH:CAE9667D3C5220302471B1AF817CBA6A:4215D16B5B94BA109439FA15BFA72800
        public DnsZoneImpl WithETagCheck(string eTagValue)
        {
            this.dnsZoneETag = eTagValue;
            return this;
        }

        ///GENMHASH:E10C7FF5C36891D769128853352DD627:0B53BA2D3C3CA2B05AF0BEA9392F8C20
        public DnsZoneImpl WithoutAaaaRecordSet(string name)
        {
            return this.WithoutAaaaRecordSet(name, null);
        }

        ///GENMHASH:762F03CE80F4A9BF3ADBEEC0D41DB5AF:B2B714F347964883CADB06AD219088B7
        public DnsZoneImpl WithoutAaaaRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutAaaaRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:5121804C5EF1A7CB4B5C344EFB2BD758:D541888961AD74A86A658F00E4B05473
        public DnsZoneImpl WithoutARecordSet(string name)
        {
            return this.WithoutARecordSet(name, null);
        }

        ///GENMHASH:B52E7C54A2094CF7BC537D1CC67AD933:0DC8E6AD5AC994B91EFCD01CFC1096E3
        public DnsZoneImpl WithoutARecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutARecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:F4C7F9EA94A9693843E357C30B270500:5DBA625780CF1008200ACB582C26A988
        public DnsZoneImpl WithoutCaaRecordSet(string name)
        {
            return this.WithoutCaaRecordSet(name, null);
        }

        ///GENMHASH:E515F51C44205F030312A4B9FE9FFF71:CF737C5D3AF62EEDAA79CE3B56DD5250
        public DnsZoneImpl WithoutCaaRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutCaaRecordSet(name, eTag);

            return this;
        }

        ///GENMHASH:3CAFB4506578B44622E2A442A3CD8788:BAB752D3A1C75B0A4AACB01ABC60D250
        public DnsZoneImpl WithoutCNameRecordSet(string name)
        {
            return this.WithoutCNameRecordSet(name, null);
        }

        ///GENMHASH:69DD1218436902CDC3B7BC8695982064:836BD22B4D13522C26F35B8FDF823D87
        public DnsZoneImpl WithoutCNameRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutCNameRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:9AE527899D61D17A703966B76C70745E:2504EABC711E0C4024D6109846A65F7C
        public DnsZoneImpl WithoutMXRecordSet(string name)
        {
            return this.WithoutMXRecordSet(name, null);
        }

        ///GENMHASH:CAE11DD729AC8148C1BB19AC98C19A66:989CC2CE9CDA76E4756C96A70A1ECF2C
        public DnsZoneImpl WithoutMXRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutMXRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:A84F222A2C667953801DCF98F7DE030D:923487771CD86EE9B0CD6AB037014FE9
        public DnsZoneImpl WithoutNSRecordSet(string name)
        {
            return this.WithoutNSRecordSet(name, null);
        }

        ///GENMHASH:0A638BEAEF3AE7294B3373C1072B1E0A:8FB5B37D474A4ACD60C999F5C8898F1B
        public DnsZoneImpl WithoutNSRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutNSRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:1F53B3ABC8D3DD332F7B6932E224AA8C:5DE8F63E4D78168B2EC742B4E14FF460
        public DnsZoneImpl WithoutPtrRecordSet(string name)
        {
            return this.WithoutPtrRecordSet(name, null);
        }

        ///GENMHASH:C9A7146C9B1311BD2295FF461FD54E80:A9766E5FC43F95FC12091D22B2ECF495
        public DnsZoneImpl WithoutPtrRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutPtrRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:6A236BC9874C63721A7695A7FE9A4C18:62D250C4665A5EB885FF4EB68C6CDECE
        public DnsZoneImpl WithoutSrvRecordSet(string name)
        {
            recordSetsImpl.WithoutSrvRecordSet(name, null);
            return this;
        }

        ///GENMHASH:EC620CE3EF72DD020734D0F57C7057F2:629B1008510A5115AD391F91F775410C
        public DnsZoneImpl WithoutSrvRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutSrvRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:ECF2482EF49EC3D1CB1FA4A823939109:7E0994466D2DD0EFB8D1887B0196BE7A
        public DnsZoneImpl WithoutTxtRecordSet(string name)
        {
            return this.WithoutTxtRecordSet(name, null);
        }

        ///GENMHASH:2AAD8D85A395EE1384B1E0A6010A750B:46CCFCDE095AC0816D134C771C73D473
        public DnsZoneImpl WithoutTxtRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutTxtRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:AE4D8C9C499A1036D2B7A79371F6560F:AF1A57A8080D05967F6BB2860B2FE5FE
        public DnsZoneImpl WithPrivateAccess()
        {
            this.Inner.ZoneType = ZoneType.Private;
            this.Inner.RegistrationVirtualNetworks = null;
            this.Inner.ResolutionVirtualNetworks = null;
            return this;
        }

        ///GENMHASH:C81844C7F94289287F82A537F345EAFD:88502A96BBAE35FC2F2AE7D19F471533
        public DnsZoneImpl WithPrivateAccess(IList<string> registrationVirtualNetworkIds, IList<string> resolutionVirtualNetworkIds)
        {
            this.WithPrivateAccess();
            if (registrationVirtualNetworkIds != null && registrationVirtualNetworkIds.Any())
            {
                this.Inner.RegistrationVirtualNetworks = registrationVirtualNetworkIds
                                                            .Select(rvn => new SubResource(rvn))
                                                            .ToList();
            }
            if (resolutionVirtualNetworkIds != null && resolutionVirtualNetworkIds.Any())
            {
                this.Inner.ResolutionVirtualNetworks = resolutionVirtualNetworkIds
                                                            .Select(rvn => new SubResource(rvn))
                                                            .ToList();
            }

            return this;
        }

        ///GENMHASH:259340A97B801649BA035E4332D04080:6339DE7C0467AD981021C57E6675912F
        public DnsZoneImpl WithPublicAccess()
        {
            this.Inner.ZoneType = ZoneType.Public;
            this.Inner.RegistrationVirtualNetworks = null;
            this.Inner.ResolutionVirtualNetworks = null;
            return this;
        }
    }
}
