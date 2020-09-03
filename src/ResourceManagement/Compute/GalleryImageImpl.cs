// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for GalleryImage and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyeUltYWdlSW1wbA==
    internal partial class GalleryImageImpl  :
        CreatableUpdatable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage,
            Models.GalleryImageInner,
            Microsoft.Azure.Management.Compute.Fluent.GalleryImageImpl, 
            IHasId,
            IUpdate>,
        IGalleryImage,
        IDefinition,
        IUpdate
    {
        private string galleryImageName;
        private string galleryName;
        private IComputeManager computeManager;
        private string resourceGroupName;

        ///GENMHASH:27AE3C88D6A0823E2356C59DA4236D18:666F587DB54BEB717C40C0642603C57C
        internal  GalleryImageImpl(string name, IComputeManager computeManager) : base(name, new GalleryImageInner())
        {
            this.computeManager = computeManager;
            // Set resource name
            this.galleryImageName = name;
        }

        ///GENMHASH:7085203F0E54D9143441675F515A5350:8187A0188F5A617E219748998105A41C
        internal  GalleryImageImpl(GalleryImageInner inner, IComputeManager computeManager) : base(inner.Name, inner)
        {
            this.computeManager = computeManager;
            // Set resource name
            this.galleryImageName = inner.Name;
            // resource ancestor names
            this.resourceGroupName = ResourceUtils.GetValueFromIdByName(inner.Id, "resourceGroups");
            this.galleryName = ResourceUtils.GetValueFromIdByName(inner.Id, "galleries");
            this.galleryImageName = ResourceUtils.GetValueFromIdByName(inner.Id, "images");
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:9A64142FBBAA15A12F245837F69E96FC:C0D602DEFC3F98CE1F6CCC5F0E7012C8
        public Disallowed Disallowed()
        {
            return this.Inner.Disallowed;
        }

        ///GENMHASH:E6D1DF89668E0AD4124D23BB98631AC0:253C5A8AA0CBC938019059050302255C
        public DateTime? EndOfLifeDate()
        {
            return this.Inner.EndOfLifeDate;
        }

        ///GENMHASH:638FC117F6C00F9473BA079A3C081D9C:9353C175CA560A336F913CAF055AF981
        public string Eula()
        {
            return this.Inner.Eula;
        }


        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:4D478BD54577C4E8EA7106DF1AB25435:694E5498526F78972B783CD90E235C66
        public GalleryImageIdentifier Identifier()
        {
            return this.Inner.Identifier;
        }


        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:3054A3D10ED7865B89395E7C007419C9
        public string Location()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IComputeManager Manager()
        {
            return this.computeManager;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name
        {
            get
            {
                if (base.Name == null)
                {
                    return this.Inner.Name;
                }
                else
                {
                    return base.Name;
                }
            }
        }

        string IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }


        ///GENMHASH:C8DCA7493B3D93CC58B7F779B4A3944C:A3BA84BA84AB2202398D3A6E65C5F76A
        public OperatingSystemStateTypes? OSState()
        {
            return this.Inner.OsState;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F71645491B82E137E4D1786750E7ADF0
        public OperatingSystemTypes? OSType()
        {
            return this.Inner.OsType;
        }

        ///GENMHASH:B36E92D071C2D2632B90A6792DC9FAAF:9DCD82DEC86B01C07765B045E56BAB5F
        public string PrivacyStatementUri()
        {
            return this.Inner.PrivacyStatementUri;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public ProvisioningState ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:7BF8931EF46F2FF0CF8FAD2663BC8F23:C3F84D08346618993E076B02237B84D9
        public ImagePurchasePlan PurchasePlan()
        {
            return this.Inner.PurchasePlan;
        }

        ///GENMHASH:6C30DC9FBD3D6CDF3BBB75B625DA990E:FC00F099BFC148181C0F3BD72E4B1BB4
        public RecommendedMachineConfiguration RecommendedVirtualMachineConfiguration()
        {
            return this.Inner.Recommended;
        }

        ///GENMHASH:45CB5EDC146E59116E681E4FA893DA9D:1847D4773368CE9C950D03D06E70E1A0
        public string ReleaseNoteUri()
        {
            return this.Inner.ReleaseNoteUri;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:3E9F81F446FDF2A19095DC13C7608416
        public IReadOnlyDictionary<string, string> Tags()
        {
            if (this.Inner.Tags == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return this.Inner.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:23EC4B61BB9F1DFE8F251827F8E66FF4
        protected override async Task<Models.GalleryImageInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.computeManager.Inner.GalleryImages;
            return await client.GetAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:3EE578C74AE5F7B41F5C490A1DC7D638
        public override async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.computeManager.Inner.GalleryImages;
            var inner = await client.CreateOrUpdateAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, this.Inner, cancellationToken);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:4A32A0416E219F53BE84CDA28E1A7FD1:1A75F5D887CCA16C68B3E18528A673E1
        public IGalleryImageVersion GetVersion(string versionName)
        {
            return this.computeManager.GalleryImageVersions.GetByGalleryImage(this.resourceGroupName, this.galleryName, this.galleryImageName, versionName);
        }

        ///GENMHASH:7F002133997D7216F18BB8D21CF034D2:BE28E3F7E873613CF430C710146DC5B3
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetVersionAsync(string versionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.computeManager.GalleryImageVersions.GetByGalleryImageAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, versionName, cancellationToken);
        }

        ///GENMHASH:37F76E5729DFBD562C6418F2290EBC6E:86927F304FB8C992B92BE20600A9354A
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> ListVersions()
        {
            return this.computeManager.GalleryImageVersions.ListByGalleryImage(this.resourceGroupName, this.galleryName, this.galleryImageName);
        }

        ///GENMHASH:D4A7A02E673639C444C53A8D52EFA5E3:6BDB02D858015991B4568658D3E9ADC2
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> ListVersionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.computeManager.GalleryImageVersions.ListByGalleryImageAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, cancellationToken);
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:46AD705474F82EB01989BDC537143CDA:E24CCAC647CB1E84A09989E367AC3866
        public IReadOnlyList<Models.DiskSkuTypes> UnsupportedDiskTypes()
        {
            if (this.Inner.Disallowed == null || this.Inner.Disallowed.DiskTypes == null)
            {
                return new List<Models.DiskSkuTypes>();
            }
            else
            {
                List<DiskSkuTypes> diskTypes = new List<DiskSkuTypes>();
                foreach(var diskTypeStr in this.Inner.Disallowed.DiskTypes)
                {
                    diskTypes.Add(DiskSkuTypes.FromStorageAccountType(DiskStorageAccountTypes.Parse(diskTypeStr)));
                }
                return diskTypes;
            }
        }

        ///GENMHASH:016764F09D1966D691B5DE3A7FD47AC9:5D67BF1D9DA1008F878F13C112FF5F35
        public GalleryImageImpl WithDescription(string description)
        {
            this.Inner.Description = description;
            return this;
        }

        ///GENMHASH:07B06D37077546C0B927329D67C53A81:79C20DF0A1E7505EA0686D15E34FECA3
        public GalleryImageImpl WithDisallowed(Disallowed disallowed)
        {
            this.Inner.Disallowed = disallowed;
            return this;
        }

        ///GENMHASH:6E6C9FDCE928A4707B0B6A71AD136F25:0D8FEF56B96316FB8667DA78C5C84F07
        public GalleryImageImpl WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            this.Inner.EndOfLifeDate = endOfLifeDate;
            return this;
        }

        ///GENMHASH:3E2F10CC43558B774476B4098C4B5AAB:5EAED4443132B650A90DAC7E22166BA5
        public GalleryImageImpl WithEula(string eula)
        {
            this.Inner.Eula = eula;
            return this;
        }

        ///GENMHASH:A665BD8151EF9002B07A6E1C8B87CDB8:6698608EA6DD6C61B2F2C8FA3AE030C8
        public GalleryImageImpl WithExistingGallery(string resourceGroupName, string galleryName)
        {
            this.resourceGroupName = resourceGroupName;
            this.galleryName = galleryName;
            return this;
        }

        ///GENMHASH:122D20BE545BE3A9BA66426AA6D8F239:63AE95F215B8467877CE9E7DFD592E08
        public GalleryImageImpl WithExistingGallery(IGallery gallery)
        {
            this.resourceGroupName = gallery.ResourceGroupName;
            this.galleryName = gallery.Name;
            return this;
        }

        ///GENMHASH:1EECE36B662887AA5C7C35565C99004E:00986057020BA21F25DC9703C93425B5
        public GalleryImageImpl WithGeneralizedLinux()
        {
            return this.WithLinux(OperatingSystemStateTypes.Generalized);
        }

        ///GENMHASH:71FAF9C45070E7CFF3E5C7BEDBD9DC0C:A57DB503FD70A521A97595B8FEF4B6AB
        public GalleryImageImpl WithGeneralizedWindows()
        {
            return this.WithWindows(OperatingSystemStateTypes.Generalized);
        }

        ///GENMHASH:4FF261989C984084E4F237BBB3F3166D:C1387D5805B738EDA65329EFF9CEDD95
        public GalleryImageImpl WithIdentifier(GalleryImageIdentifier identifier)
        {
            this.Inner.Identifier = identifier;
            return this;
        }

        ///GENMHASH:D2D95F5FA658E1ECA4DB864407B55C44:989E2C520E5575DC9C7E40E25FF2D269
        public GalleryImageImpl WithIdentifier(string publisher, string offer, string sku)
        {
            this.Inner.Identifier = new GalleryImageIdentifier()
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku
            };
            return this;
        }

        ///GENMHASH:3472074D1AB5FCC22AE56AFE70FDA2F8:E55B773D65A05FA8865303A9358A98E3
        public GalleryImageImpl WithLinux(OperatingSystemStateTypes osState)
        {
            this.Inner.OsType = OperatingSystemTypes.Linux;
            this.Inner.OsState = osState;
            return this;
        }

        ///GENMHASH:C8421133DBC453BD76FCC9BC29C80FA1:E4BC2D6403FDE9DB36572C1A7DC24543
        public GalleryImageImpl WithLocation(string location)
        {
            this.Inner.Location = location;
            return this;
        }

        ///GENMHASH:3E6A2E1842CF7045A3B0CF12AF9A85DA:8631322721E2C0858A3ABA04A72303A3
        public GalleryImageImpl WithLocation(Region location)
        {
            this.Inner.Location = location.ToString();
            return this;
        }

        ///GENMHASH:B193C7EB04D97343DA56B771815DD347:058990A9D00E548A58C7CAB261EFDC30
        public GalleryImageImpl WithOsState(OperatingSystemStateTypes osState)
        {
            this.Inner.OsState = osState;
            return this;
        }

        ///GENMHASH:327CBF262F4C69D4F67206A8BC678FD6:6E1EBADD62B789305803912915AD8226
        public GalleryImageImpl WithoutUnsupportedDiskType(DiskSkuTypes diskType)
        {
            if (this.Inner.Disallowed != null && this.Inner.Disallowed.DiskTypes != null)
            {
                int foundIndex = -1;
                int i = 0;
                string diskTypeToRemove = diskType.ToString();
                foreach(var diskTypeStr in this.Inner.Disallowed.DiskTypes)
                {
                    if (diskTypeStr.Equals(diskTypeToRemove, StringComparison.OrdinalIgnoreCase))
                    {
                        foundIndex = i;
                        break;
                    }
                    i++;
                }
                if (foundIndex != -1)
                {
                    this.Inner.Disallowed.DiskTypes.RemoveAt(foundIndex);
                }
            }
            return this;
        }

        ///GENMHASH:542B4A501337E966839DDFF5B784C5A4:956B22DE0183A9B1B40E11CB72457E23
        public GalleryImageImpl WithPrivacyStatementUri(string privacyStatementUri)
        {
            this.Inner.PrivacyStatementUri = privacyStatementUri;
            return this;
        }

        ///GENMHASH:77CF9954FB80D58565A3BDE78A132F2F:4738D18AB791EDFE3036C5D639ECDCBC
        public GalleryImageImpl WithPurchasePlan(string name, string publisher, string product)
        {
            return this.WithPurchasePlan(new ImagePurchasePlan()
            {
                Name = name,
                Publisher = publisher,
                Product = product
            });
        }

        ///GENMHASH:BD26D6DAB7F06580CA699479A1DBE779:2D7E0C7182D588C854835401FBDB12AD
        public GalleryImageImpl WithPurchasePlan(ImagePurchasePlan purchasePlan)
        {
            this.Inner.PurchasePlan = purchasePlan;
            return this;
        }

        ///GENMHASH:BB6C17CE4E2C9A3D847511D22875485F:EA7F351EB07905E692E2BECFD19BC27B
        public GalleryImageImpl WithRecommendedConfigurationForVirtualMachine(RecommendedMachineConfiguration recommendedConfig)
        {
            this.Inner.Recommended = recommendedConfig;
            return this;
        }

        ///GENMHASH:4B9730E760025024AE0695C6FF9355B8:D8AD9C6C8CC4609ADE980226D7CE3AEB
        public GalleryImageImpl WithRecommendedCPUsCountForVirtualMachine(int minCount, int maxCount)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            this.Inner.Recommended.VCPUs = new ResourceRange();
            this.Inner.Recommended.VCPUs.Min = minCount;
            this.Inner.Recommended.VCPUs.Max = maxCount;
            return this;
        }

        ///GENMHASH:DDA950D600673E301DECA66A7863B693:924C935C729B6146EC774C42879D933F
        public GalleryImageImpl WithRecommendedMaximumCPUsCountForVirtualMachine(int maxCount)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            if (this.Inner.Recommended.VCPUs == null)
            {
                this.Inner.Recommended.VCPUs = new ResourceRange();
            }
            this.Inner.Recommended.VCPUs.Max = maxCount;
            return this;
        }

        ///GENMHASH:2ED7D3217FD38DE3DA520C7017035348:EBCB4883E483A73B5F2C7252C4B36813
        public GalleryImageImpl WithRecommendedMaximumMemoryForVirtualMachine(int maxMB)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            if (this.Inner.Recommended.Memory == null)
            {
                this.Inner.Recommended.Memory = new ResourceRange();
            }
            this.Inner.Recommended.Memory.Max = maxMB;
            return this;
        }

        ///GENMHASH:2863D36B6A808F64907758A2B0A545C2:7EA77ABCEDE9DAC4A98451F7B01A8605
        public GalleryImageImpl WithRecommendedMemoryForVirtualMachine(int minMB, int maxMB)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            this.Inner.Recommended.Memory = new ResourceRange();
            this.Inner.Recommended.Memory.Min = minMB;
            this.Inner.Recommended.Memory.Max = maxMB;
            return this;
        }

        ///GENMHASH:F7ACEEC719739062CB2C5BA6C1B464CE:A244673762C643DCAAC847470E807C35
        public GalleryImageImpl WithRecommendedMinimumCPUsCountForVirtualMachine(int minCount)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            if (this.Inner.Recommended.VCPUs == null)
            {
                this.Inner.Recommended.VCPUs = new ResourceRange();
            }
            this.Inner.Recommended.VCPUs.Min = minCount;
            return this;
        }

        ///GENMHASH:D9EF1129EF6CFD5E1A9EC1C65BF718DA:F854E305471A3B494755B48029FEB01B
        public GalleryImageImpl WithRecommendedMinimumMemoryForVirtualMachine(int minMB)
        {
            if (this.Inner.Recommended == null)
            {
                this.Inner.Recommended = new RecommendedMachineConfiguration();
            }
            if (this.Inner.Recommended.Memory == null)
            {
                this.Inner.Recommended.Memory = new ResourceRange();
            }
            this.Inner.Recommended.Memory.Min = minMB;
            //$ return this;

            return this;
        }

        ///GENMHASH:8702D5B193A52AEA4A057F86D0EB6218:C967D26B6FD51C024F09767139ADC2EC
        public GalleryImageImpl WithReleaseNoteUri(string releaseNoteUri)
        {
            this.Inner.ReleaseNoteUri = releaseNoteUri;
            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:0A35F4FBFC584D98FAACCA25325781E8
        public GalleryImageImpl WithTags(IDictionary<string,string> tags)
        {
            this.Inner.Tags = tags;
            return this;
        }

        ///GENMHASH:BA0EA3BD50E3CD77EC22B73FFC802C41:744865003C628CE889C88FAC8E7D6E87
        public GalleryImageImpl WithUnsupportedDiskType(DiskSkuTypes diskType)
        {
            if (this.Inner.Disallowed == null)
            {
                this.Inner.Disallowed = new Disallowed();
            }
            if (this.Inner.Disallowed.DiskTypes == null)
            {
                this.Inner.Disallowed.DiskTypes = new List<string>();
            }
            bool found = false;
            string newDiskTypeStr = diskType.ToString();
            foreach(var diskTypeStr in this.Inner.Disallowed.DiskTypes)
            {
                if (diskTypeStr.Equals(newDiskTypeStr, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.Inner.Disallowed.DiskTypes.Add(diskType.ToString());
            }
            return this;
        }

        ///GENMHASH:847C05E525547573F21D410720E5BB39:0EA8BD8DFAC2B974572CF97EE781C58C
        public GalleryImageImpl WithUnsupportedDiskTypes(IList<Models.DiskSkuTypes> diskTypes)
        {
            if (this.Inner.Disallowed == null)
            {
                this.Inner.Disallowed = new Disallowed();
            }
            this.Inner.Disallowed.DiskTypes = new List<string>();
            foreach(var diskType in diskTypes)
            {
                this.Inner.Disallowed.DiskTypes.Add(diskType.ToString());
            }
            return this;
        }

        ///GENMHASH:255C87A909686D389A226B73B5FC61E0:9D9164D3A619DF1BDF4D73358606FD40
        public GalleryImageImpl WithWindows(OperatingSystemStateTypes osState)
        {
            this.Inner.OsType = OperatingSystemTypes.Windows;
            this.Inner.OsState = osState;
            return this;
        }
    }
}