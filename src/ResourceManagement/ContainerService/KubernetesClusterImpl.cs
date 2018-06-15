// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The implementation for KubernetesCluster and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uS3ViZXJuZXRlc0NsdXN0ZXJJbXBs
    internal partial class KubernetesClusterImpl  :
        GroupableResource<
            Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster,
            Models.ManagedClusterInner,
            Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterImpl,
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager,
            KubernetesCluster.Definition.IWithGroup,
            KubernetesCluster.Definition.IWithVersion,
            KubernetesCluster.Definition.IWithCreate,
            KubernetesCluster.Update.IUpdate>,
        IKubernetesCluster,
        IDefinition,
        IUpdate
    {
        private byte[] adminKubeConfigContent;
        private byte[] userKubeConfigContent;

        ///GENMHASH:DEDF5AE2F1ABB9DF6AD962840B38A58B:0F98D2133F32D8FB212E9B9A457FA932
        internal KubernetesClusterImpl(string name, ManagedClusterInner innerObject, IContainerServiceManager manager) : base(name, innerObject, manager)
        {
            //$ super(name, innerObject, manager);
            if (this.Inner.AgentPoolProfiles == null)
            {
                this.Inner.AgentPoolProfiles = new List<ContainerServiceAgentPoolProfile>();
            }

            this.adminKubeConfigContent = null;
            this.userKubeConfigContent = null;
        }

        ///GENMHASH:24C4B5842536160FA41D355F9B7D00FB:EA17E710E325D38A5D12B21C390850F7
        public string LinuxRootUsername()
        {
            if (this.Inner.LinuxProfile != null)
            {
                return this.Inner.LinuxProfile.AdminUsername;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:A1945CF277DF5AE74D653481F44D96CE
        public string Fqdn()
        {
            return this.Inner.Fqdn;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:85E13CAB57751CD4984182349A26B883
        public KubernetesVersion Version()
        {
            return KubernetesVersion.Parse(this.Inner.KubernetesVersion);
        }

        ///GENMHASH:241438CD640E7B711BD934271A46E5C2:C8A028803E4A0CD7460523EE2F3D33AB
        public string ServicePrincipalClientId()
        {
            if (this.Inner.ServicePrincipalProfile != null)
            {
                return this.Inner.ServicePrincipalProfile.ClientId;
            }
            else
            {
                return null;
            }
         }

        ///GENMHASH:757F66F135F222B4469B64707708EFAB:A23AF024A782515C5EB55331C73E9EC6
        public string ServicePrincipalSecret()
        {
            if (this.Inner.ServicePrincipalProfile != null)
            {
                return this.Inner.ServicePrincipalProfile.Secret;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:6B9110585F8C0802DD175E2A4CC42085:0AFA47BFFB09777DA247B843C7A8F6D9
        public byte[] AdminKubeConfigContent()
        {
            if (this.adminKubeConfigContent == null)
            {
                this.adminKubeConfigContent = Extensions.Synchronize(() => this.GetAdminKubeConfigContentAsync());
            }

            return this.adminKubeConfigContent;
        }

        ///GENMHASH:94A9F49AECE7874D497A7F5E8A5AB25C:FB91DAFFC2B4B802AB4DE52634A023D9
        public byte[] UserKubeConfigContent()
        {
            if (this.userKubeConfigContent == null)
            {
                this.userKubeConfigContent = Extensions.Synchronize(() => this.GetUserKubeConfigContentAsync());
            }

            return this.userKubeConfigContent;
        }

        private async Task<byte[]> GetAdminKubeConfigContentAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var profileInner = await this.Manager.Inner.ManagedClusters
                .GetAccessProfileAsync(this.ResourceGroupName, this.Name, KubernetesClusterAccessProfileRole.ADMIN.ToString(), cancellationToken: cancellationToken);
            if (profileInner == null)
            {
                return new byte[0];
            }
            else
            {
                return profileInner.KubeConfig;
            }
        }

        private async Task<byte[]> GetUserKubeConfigContentAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var profileInner = await this.Manager.Inner.ManagedClusters
                .GetAccessProfileAsync(this.ResourceGroupName, this.Name, KubernetesClusterAccessProfileRole.USER.ToString(), cancellationToken: cancellationToken);
            if (profileInner == null)
            {
                return new byte[0];
            }
            else
            {
                return profileInner.KubeConfig;
            }
        }

        ///GENMHASH:4D74B3E4F89B919E9083354B48AF1701:28EC225F90F55F3475ABB61EB5517F32
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

        ///GENMHASH:048D31D4D88B263A0EA3CF2218458D9B:D9B188AA53AD55835CC0103D71FA4805
        public KeyVaultSecretRef KeyVaultSecretReference()
        {
            if (this.Inner.ServicePrincipalProfile != null)
            {
                return this.Inner.ServicePrincipalProfile.KeyVaultSecretRef;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:59348A25FD515049ECD26A6290F76B85:99DA2F06545702040B219110889AFC52
        public string DnsPrefix()
        {
            return this.Inner.DnsPrefix;
        }

        ///GENMHASH:49C218D29240434FDEA348294DA3B2E7:7FF23C830B4C972862A832B3DCA72EC6
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusterAgentPool> AgentPools()
        {
            var agentPoolMap = new Dictionary<string, IKubernetesClusterAgentPool>();
            if (this.Inner.AgentPoolProfiles != null && this.Inner.AgentPoolProfiles.Count > 0)
            {
                foreach (var agentPoolProfile in this.Inner.AgentPoolProfiles)
                {
                    agentPoolMap.Add(agentPoolProfile.Name, new KubernetesClusterAgentPoolImpl(agentPoolProfile, this));
                }
            }

            return new ReadOnlyDictionary<string, IKubernetesClusterAgentPool>(agentPoolMap);
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:E92DCB891A6508AA2417BBC73DD661CA
        protected override async Task<Models.ManagedClusterInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var managedClueserInner = await this.Manager.Inner.ManagedClusters.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
            this.adminKubeConfigContent = await this.GetAdminKubeConfigContentAsync(cancellationToken);
            this.userKubeConfigContent = await this.GetUserKubeConfigContentAsync(cancellationToken);

            return managedClueserInner;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:25E405EF73C8D80ECBABEE2CA82ED9BB
        public override async Task<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!this.IsInCreateMode)
            {
                this.Inner.ServicePrincipalProfile = null;
            }

            var containerServiceInner = await this.Manager.Inner.ManagedClusters.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
            this.SetInner(containerServiceInner);
            this.adminKubeConfigContent = await this.GetAdminKubeConfigContentAsync(cancellationToken: cancellationToken);
            this.userKubeConfigContent = await this.GetUserKubeConfigContentAsync(cancellationToken: cancellationToken);

            return this;
        }

        ///GENMHASH:AA0E673C3A3D74BFB62C2BA269350BC6:7013F088123D73E5524D75A0D2D3F9DB
        public KubernetesClusterImpl WithVersion(KubernetesVersion kubernetesVersion)
        {
            this.Inner.KubernetesVersion = kubernetesVersion.ToString();

            return this;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:680AB4E250198E427BC1E5373E11C634
        public KubernetesClusterImpl WithVersion(string kubernetesVersion)
        {
            this.Inner.KubernetesVersion = kubernetesVersion;

            return this;
        }

        ///GENMHASH:6E6C7ADDA062559C24E2355B35D0238B:8ECEC33D2E495291645C6C111C44D076
        public KubernetesClusterImpl WithLatestVersion()
        {
            this.Inner.KubernetesVersion = "";

            return this;
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:8DAE3A3861F2953E54E87536C38425BB
        public KubernetesClusterImpl WithRootUsername(string rootUserName)
        {
            if (this.Inner.LinuxProfile == null)
            {
                this.Inner.LinuxProfile = new ContainerServiceLinuxProfile();
            }

            this.Inner.LinuxProfile.AdminUsername = rootUserName;

            return this;
        }

        ///GENMHASH:C07DCA54ADF001544477CA628BFB92CE:AD8727C11387554881FEF26A45C92D74
        public KubernetesClusterImpl WithSshKey(string sshKeyData)
        {
            ContainerServiceSshConfiguration ssh = new ContainerServiceSshConfiguration();
            ssh.PublicKeys = new List<ContainerServiceSshPublicKey>();
            ContainerServiceSshPublicKey sshPublicKey = new ContainerServiceSshPublicKey();
            sshPublicKey.KeyData = sshKeyData;
            ssh.PublicKeys.Add(sshPublicKey);
            this.Inner.LinuxProfile.Ssh = ssh;

            return this;
        }

        ///GENMHASH:3AD7800EEDA5002D343D541EF5BF6C59:87DD93F81EE748EBF7453FBA2AF71B16
        public KubernetesClusterImpl WithServicePrincipalClientId(string clientId)
        {
            this.Inner.ServicePrincipalProfile = new ContainerServiceServicePrincipalProfile() { ClientId = clientId };

            return this;
        }

        ///GENMHASH:F294A6CFAE712AE32ABA921B6F4AA43D:1950908079BD9401D00B541C605088A0
        public KubernetesClusterImpl WithServicePrincipalSecret(string secret)
        {
            this.Inner.ServicePrincipalProfile.Secret = secret;

            return this;
        }

        ///GENMHASH:F67AAA7822A5DCD4D5C72EF349C697BC:A854C60681F248A80A13DB65B15391E5
        public KubernetesClusterImpl WithKeyVaultReference(string vaultId)
        {
            this.Inner.ServicePrincipalProfile.Secret = null;
            this.Inner.ServicePrincipalProfile.KeyVaultSecretRef = new KeyVaultSecretRef() { VaultID = vaultId };

            return this;
        }

        ///GENMHASH:58C54A75D06ABFFA3A6E970ADB9F88A3:4895D1DEEC5C6A3BFC09C0CF5D301EA5
        public KubernetesClusterImpl WithKeyVaultSecret(string secretName, string secretVersion)
        {
            this.Inner.ServicePrincipalProfile.KeyVaultSecretRef.SecretName = secretName;
            this.Inner.ServicePrincipalProfile.KeyVaultSecretRef.Version = secretVersion;

            return this;
        }

        ///GENMHASH:8C3D6163D348B79C58B6C226EB37BA1B:719CEE0C578D3F2A28E53B9EFE90DBDE
        public KubernetesClusterImpl WithKeyVaultSecret(string secretName)
        {
            this.Inner.ServicePrincipalProfile.KeyVaultSecretRef.SecretName = secretName;

            return this;
        }

        ///GENMHASH:6A72E02437FDFE34B555349311EFC1FF:1242B313FA0B285B3216EBAAC61FA3DD
        public KubernetesClusterAgentPoolImpl DefineAgentPool(string name)
        {
            ContainerServiceAgentPoolProfile innerPoolProfile = new ContainerServiceAgentPoolProfile() { Name = name };

            return new KubernetesClusterAgentPoolImpl(innerPoolProfile, this);
        }

        ///GENMHASH:8642FC9B9C8DC7375DEE3CC5736F8853:F4225C430EBBA47D3B347EB5D5E555FA
        public KubernetesClusterImpl WithDnsPrefix(string dnsPrefix)
        {
            this.Inner.DnsPrefix = dnsPrefix;

            return this;
        }

        ///GENMHASH:B389D978FF5A3275B275BA4DE9FA4FB3:B7E8C8BCFE6B53ABB94D49F2C205309A
        public KubernetesClusterImpl WithAgentVirtualMachineCount(string agentPoolName, int agentCount)
        {
            if (this.Inner.AgentPoolProfiles != null && this.Inner.AgentPoolProfiles.Count > 0)
            {
                foreach (var agent in this.Inner.AgentPoolProfiles)
                {
                    if (agent.Name.Equals(agentPoolName))
                    {
                        agent.Count = agentCount;
                        break;
                    }
                }
            }

            return this;
        }

        ///GENMHASH:B629860592BCA4958E12BD85ED1476A1:9FF3FBA51C1ABED8D77125A4AD0F78DD
        public KubernetesClusterImpl WithAgentVirtualMachineCount(int agentCount)
        {
            if (this.Inner.AgentPoolProfiles != null && this.Inner.AgentPoolProfiles.Count > 0)
            {
                foreach (var agent in this.Inner.AgentPoolProfiles)
                {
                    agent.Count = agentCount;
                }
            }

            return this;
        }

    }
}