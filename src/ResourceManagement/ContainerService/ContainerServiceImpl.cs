// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for ContainerService and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uQ29udGFpbmVyU2VydmljZUltcGw=
    internal partial class ContainerServiceImpl :
        GroupableResource<
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerService,
            Models.ContainerServiceInner,
            Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceImpl,
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager,
            ContainerService.Definition.IWithGroup,
            ContainerService.Definition.IWithOrchestrator,
            ContainerService.Definition.IWithCreate,
            ContainerService.Update.IUpdate>,
        IContainerService,
        IDefinition,
        IUpdate
    {
        private string networkId;
        private string subnetName;

        ///GENMHASH:E6D0551D4FCBCBFCB92123F27E001E43:1B6DFFB2F94EAF8297DB9CFDE661F1A6
        internal ContainerServiceImpl(string name, ContainerServiceInner innerObject, IContainerServiceManager manager) : base(name, innerObject, manager)
        {
            if (this.Inner.AgentPoolProfiles == null)
            {
                this.Inner.AgentPoolProfiles = new List<ContainerServiceAgentPoolProfile>();
            }

            if (this.Inner.MasterProfile != null && this.Inner.MasterProfile.VnetSubnetID != null)
            {
                this.networkId = ResourceUtils.ParentResourcePathFromResourceId(this.Inner.MasterProfile.VnetSubnetID);
                this.subnetName = ResourceUtils.NameFromResourceId(this.Inner.MasterProfile.VnetSubnetID);
            }
            else
            {
                this.networkId = null;
                this.subnetName = null;
            }
        }

        ///GENMHASH:A3928437B28327E4B79E35C826048649:B658C5321AF6202670FB51CF9D38C87B
        public int MasterNodeCount()
        {
            if (this.Inner.MasterProfile == null
                || this.Inner.MasterProfile.Count == null
                || !this.Inner.MasterProfile.Count.HasValue)
            {
                return 0;
            }

            return this.Inner.MasterProfile.Count.Value;
        }

        ///GENMHASH:48117D452AE9C0E09F09E657CC2A2720:C0043D92AB37920A26794953581E9F65
        public int MasterOSDiskSizeInGB()
        {
            if (this.Inner.MasterProfile == null
                || this.Inner.MasterProfile.OsDiskSizeGB == null
                || !this.Inner.MasterProfile.OsDiskSizeGB.HasValue)
            {
                return 0;
            }

            return this.Inner.MasterProfile.OsDiskSizeGB.Value;
        }

        ///GENMHASH:BC5DA28013FC488048456BB1488940CD:632689EFB76F9D83AE36321D76FDEF51
        public bool IsDiagnosticsEnabled()
        {
            if (this.Inner.DiagnosticsProfile == null
                || this.Inner.DiagnosticsProfile.VmDiagnostics == null)
            {
                throw new Exception("Diagnostic profile is missing!");
            }

            return this.Inner.DiagnosticsProfile.VmDiagnostics.Enabled;
        }

        ///GENMHASH:8730724FA8F2B13300CA29D7B7ECE13D:981AB6AA4AB466A4B166184D9DE03D70
        public string MasterDnsPrefix()
        {
            if (this.Inner.MasterProfile == null)
            {
                return null;
            }

            return this.Inner.MasterProfile.DnsPrefix;
        }

        ///GENMHASH:5721C956FFFB4F424DFAFA9F55C38027:8B5E3140B4A464FEEC0E65D880957299
        public string MasterSubnetName()
        {
            return subnetName;
        }

        ///GENMHASH:24C4B5842536160FA41D355F9B7D00FB:DD8CC27879A8C278408595B7F33E8EAF
        public string LinuxRootUsername()
        {
            if (this.Inner.LinuxProfile == null)
            {
                return null;
            }

            return this.Inner.LinuxProfile.AdminUsername;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:AC650DECC2C8D00599CB05B5C74C5BD9
        public string NetworkId()
        {
            return networkId;
        }

        ///GENMHASH:241438CD640E7B711BD934271A46E5C2:256764655BC8055C316CEC61AF8177D3
        public string ServicePrincipalClientId()
        {
            if (this.Inner.ServicePrincipalProfile == null)
            {
                return null;
            }

            return this.Inner.ServicePrincipalProfile.ClientId;
        }

        ///GENMHASH:757F66F135F222B4469B64707708EFAB:43CDEAE8E9316E871DDFDCB53D49F79C
        public string ServicePrincipalSecret()
        {
            if (this.Inner.ServicePrincipalProfile == null)
            {
                return null;
            }

            return this.Inner.ServicePrincipalProfile.Secret;
        }

        ///GENMHASH:6D557FE1D021BE5607F25800C54206AC:92A40AABED958DD7D8E0110C6E8CA32F
        public ContainerServiceOrchestratorTypes OrchestratorType()
        {
            if (this.Inner.OrchestratorProfile == null)
            {
                throw new Exception("Orchestrator profile is missing!");
            }

            return this.Inner.OrchestratorProfile.OrchestratorType;
        }

        ///GENMHASH:1C0F298C59000FB8575D2EB355D8B74B:1001666653F1B8AAB912580CFE34531C
        public string MasterFqdn()
        {
            if (this.Inner.MasterProfile == null)
            {
                return null;
            }

            return this.Inner.MasterProfile.Fqdn;
        }

        ///GENMHASH:4D74B3E4F89B919E9083354B48AF1701:D588C80E4321B8640ABFDC0BBB5100CC
        public string SshKey()
        {
            if (this.Inner.LinuxProfile == null
            || this.Inner.LinuxProfile.Ssh == null
            || this.Inner.LinuxProfile.Ssh.PublicKeys == null
            || this.Inner.LinuxProfile.Ssh.PublicKeys.Count == 0)
            {
                return null;
            }

            return this.Inner.LinuxProfile.Ssh.PublicKeys[0].KeyData;
        }

        ///GENMHASH:73ADFE18CF139D326FFC1685C2840F1E:6191B9BE10C5AB3BDFA7CAF4F4FCAA3C
        public ContainerServiceStorageProfileTypes MasterStorageProfile()
        {
            if (this.Inner.MasterProfile == null)
            {
                return null;
            }

            return this.Inner.MasterProfile.StorageProfile;
        }

        ///GENMHASH:49C218D29240434FDEA348294DA3B2E7:6F1FDC8F313247013F4C5F380E23A5F8
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceAgentPool> AgentPools()
        {
            var agentPoolMap = new Dictionary<string, IContainerServiceAgentPool>();
            if (this.Inner.AgentPoolProfiles != null && this.Inner.AgentPoolProfiles.Count > 0)
            {
                foreach (var agentPoolProfile in this.Inner.AgentPoolProfiles)
                {
                    agentPoolMap.Add(agentPoolProfile.Name, new ContainerServiceAgentPoolImpl(agentPoolProfile, this));
                }
            }

            return new ReadOnlyDictionary<string, IContainerServiceAgentPool>(agentPoolMap);
        }


        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:27F43A76F1F7FFC37D35C669F1BC99AD
        public override async Task<Microsoft.Azure.Management.ContainerService.Fluent.IContainerService> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!this.IsInCreateMode)
            {
                this.Inner.ServicePrincipalProfile = null;
            }
            var containerServiceInner = await this.Manager.Inner.ContainerServices.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
            this.SetInner(containerServiceInner);

            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:D9F528AA4CEE30F694136FDE4FD5754A
        protected override async Task<Models.ContainerServiceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ContainerServices.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:002B9FED6878745A10FBEF2FDB77458A:D5B202681E7C68C9E8C3C6F9EAD5F2E7
        public ContainerServiceImpl WithLinux()
        {
            if (this.Inner.LinuxProfile == null)
            {
                this.Inner.LinuxProfile = new ContainerServiceLinuxProfile();
            }

            return this;
        }

        ///GENMHASH:16F9F0849B5CE88334AA536BE689E6E4:52F150E15F371044D391D111BDF0D1C6
        private ContainerServiceImpl WithOrchestratorProfile(ContainerServiceOrchestratorTypes orchestratorType)
        {
            ContainerServiceOrchestratorProfile orchestratorProfile = new ContainerServiceOrchestratorProfile();
            orchestratorProfile.OrchestratorType = orchestratorType;
            this.Inner.OrchestratorProfile = orchestratorProfile;

            return this;
        }

        ///GENMHASH:5C41C090AC65B94D1A923D276B89B123:7AD1645115046FFDE15EA58C0E522AB3
        public ContainerServiceImpl WithKubernetesOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOrchestratorTypes.Kubernetes);

            return this;
        }

        ///GENMHASH:29F6680AA654C7C86E66FC6EFF098F3C:7AD00695C1BF9151F763804F463DC5C0
        public ContainerServiceImpl WithSwarmOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOrchestratorTypes.Swarm);

            return this;
        }

        ///GENMHASH:D06A15C503503CAC84A896D79BBE44E2:F711A03FCBF666D27AFE3BE7F3FB534F
        public ContainerServiceImpl WithDcosOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOrchestratorTypes.DCOS);

            return this;
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:B817381FDFC30DF9285E42C801B7649A
        public ContainerServiceImpl WithRootUsername(string rootUserName)
        {
            this.Inner.LinuxProfile.AdminUsername = rootUserName;

            return this;
        }

        ///GENMHASH:C07DCA54ADF001544477CA628BFB92CE:BCA751B3DDB20EBDA99C405AA41C684C
        public ContainerServiceImpl WithSshKey(string sshKeyData)
        {
            ContainerServiceSshConfiguration ssh = new ContainerServiceSshConfiguration();
            ssh.PublicKeys = new List<ContainerServiceSshPublicKey>();
            ContainerServiceSshPublicKey sshPublicKey = new ContainerServiceSshPublicKey();
            sshPublicKey.KeyData = sshKeyData;
            ssh.PublicKeys.Add(sshPublicKey);
            this.Inner.LinuxProfile.Ssh = ssh;

            return this;
        }

        ///GENMHASH:8AA9B71F2A03F253C400A2777E873454:E0368A12D3DC6849B2EF297539754B6A
        public ContainerServiceImpl WithServicePrincipal(string clientId, string secret)
        {
            ContainerServiceServicePrincipalProfile serviceProfile = new ContainerServiceServicePrincipalProfile();
            serviceProfile.ClientId = clientId;
            serviceProfile.Secret = secret;
            this.Inner.ServicePrincipalProfile = serviceProfile;

            return this;
        }

        ///GENMHASH:0908E8D1CF114E606A062BFCD2730794:8056B7C42FBFD68BB78CC48AE2AB3CDD
        public ContainerServiceImpl WithMasterOSDiskSizeInGB(int osDiskSizeInGB)
        {
            this.Inner.MasterProfile.OsDiskSizeGB = osDiskSizeInGB;

            return this;
        }

        ///GENMHASH:9047F7688B1B60794F60BC930616198C:32D9EC18C3C586336BFA6609CBDC3758
        public ContainerServiceImpl WithSubnet(string networkId, string subnetName)
        {
            this.networkId = networkId;
            this.subnetName = subnetName;
            this.Inner.MasterProfile.VnetSubnetID = networkId + "/subnets/" + subnetName;
            if (this.Inner.AgentPoolProfiles != null)
            {
                foreach (var agentPoolProfile in this.Inner.AgentPoolProfiles)
                {
                    var agentPoolSubnet = agentPoolProfile.VnetSubnetID;
                    if (agentPoolSubnet == null)
                    {
                        agentPoolProfile.VnetSubnetID = networkId + "/subnets/" + subnetName;
                    }
                    else
                    {
                        agentPoolProfile.VnetSubnetID = networkId + "/subnets/" + agentPoolSubnet;
                    }
                }
            }

            return this;
        }

        ///GENMHASH:85F5B72A7D9BBCCFBD3E533F108D12D6:B0A1BDCD289CD3F237C626D88E2F17FB
        public ContainerServiceImpl WithDiagnostics()
        {
            this.WithDiagnosticsProfile(true);

            return this;
        }

        ///GENMHASH:866899FE3F3EB7CCA4F030D6AD095566:C13AF6F33690645CA4767389BF9D3E70
        public ContainerServiceImpl WithoutDiagnostics()
        {
            this.WithDiagnosticsProfile(false);

            return this;
        }

        ///GENMHASH:6A72E02437FDFE34B555349311EFC1FF:7B2CC2D62CE6E55AD44277A0E6A65329
        public ContainerServiceAgentPoolImpl DefineAgentPool(string name)
        {
            ContainerServiceAgentPoolProfile innerPoolProfile = new ContainerServiceAgentPoolProfile();
            innerPoolProfile.Name = name;

            return new ContainerServiceAgentPoolImpl(innerPoolProfile, this);
        }

        ///GENMHASH:7008C1B356863441389F21D4127AEEC5:64E6234D6AA675082FFEDF9F02B9E851
        public ContainerServiceImpl WithMasterDnsPrefix(string dnsPrefix)
        {
            this.Inner.MasterProfile.DnsPrefix = dnsPrefix;

            return this;
        }

        ///GENMHASH:B629860592BCA4958E12BD85ED1476A1:098628D3A0B75FA79DF40EC0AFFFA051
        public ContainerServiceImpl WithAgentVirtualMachineCount(int agentCount)
        {
            foreach (var agent in this.Inner.AgentPoolProfiles)
            {
                agent.Count = agentCount;
            }

            return this;
        }

        ///GENMHASH:EE0AC1035D049C46E7AB57094F31E2DA:BB2F893B3D917609CB0B6DCE492A490C
        private ContainerServiceImpl WithDiagnosticsProfile(bool enabled)
        {
            if (this.Inner.DiagnosticsProfile == null)
            {
                this.Inner.DiagnosticsProfile = new ContainerServiceDiagnosticsProfile();
            }
            if (this.Inner.DiagnosticsProfile.VmDiagnostics == null)
            {
                this.Inner.DiagnosticsProfile.VmDiagnostics = new ContainerServiceVMDiagnostics();
            }
            this.Inner.DiagnosticsProfile.VmDiagnostics.Enabled = enabled;

            return this;
        }

        ///GENMHASH:FFA14E460A59533D2C337F3013267D59:EEA5825A22C4A5187DB93596817AA09E
        public ContainerServiceImpl WithMasterNodeCount(ContainerServiceMasterProfileCount profileCount)
        {
            ContainerServiceMasterProfile masterProfile = new ContainerServiceMasterProfile()
            {
                VmSize = ContainerServiceVMSizeTypes.StandardD2V2,
                Count = (int)profileCount
            };

            this.Inner.MasterProfile = masterProfile;

            return this;
        }

        ///GENMHASH:471813C8A7A79400855C3DE35D356C78:9EF17E64DA70F46F3B3EC162AB9FD2A5
        public ContainerServiceImpl WithMasterStorageProfile(ContainerServiceStorageProfileTypes storageProfile)
        {
            this.Inner.MasterProfile.StorageProfile = storageProfile;

            return this;
        }

        ///GENMHASH:07B654E40DC0819D64AEE0796D299D75:CEB6A3210E226335B25EDDBDD6A8CAFA
        public ContainerServiceImpl WithMasterVMSize(ContainerServiceVMSizeTypes vmSize)
        {
            this.Inner.MasterProfile.VmSize = vmSize;

            return this;
        }
    }
}