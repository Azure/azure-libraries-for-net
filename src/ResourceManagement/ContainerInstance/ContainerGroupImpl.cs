// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System.Linq;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update;

    /// <summary>
    /// Implementation for ContainerGroup and its create interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcmluc3RhbmNlLmltcGxlbWVudGF0aW9uLkNvbnRhaW5lckdyb3VwSW1wbA==
    internal partial class ContainerGroupImpl  :
        GroupableResource<
            IContainerGroup,
            ContainerGroupInner,
            ContainerGroupImpl,
            IContainerInstanceManager,
            IWithGroup,
            IWithOsType,
            IWithCreate,
            IUpdate>,
        IContainerGroup,
        IDefinition,
        IUpdate
    {
        private IStorageManager storageManager;
        private string creatableStorageAccountKey;
        private Dictionary<string, string> newFileShares;
        private Dictionary<string, Models.Container> containers;
        private Dictionary<string, Models.Volume> volumes;
        private IList<string> imageRegistryServers;
        private int[] externalTcpPorts;
        private int[] externalUdpPorts;
        private ContainerGroupMsiHandler containerGroupMsiHandler;

        ///GENMHASH:C4B69D63304D818F517794AA4D07AAC6:C2773B13EB9D03F0091114E1241E51EB
        internal ContainerGroupImpl(string name, ContainerGroupInner innerObject, IContainerInstanceManager manager, IStorageManager storageManager, IGraphRbacManager rbacManager)
            : base(name, innerObject, manager)
        {
            this.storageManager = storageManager;
            if (innerObject != null)
            {
                this.InitializeChildrenFromInner();
            }
            this.containerGroupMsiHandler = new ContainerGroupMsiHandler(rbacManager, this);
        }

        public DnsConfiguration DnsConfig()
        {
            return this.Inner.DnsConfig;
        }

        public bool IsIPAddressPrivate()
        {
            return this.Inner.IpAddress != null && this.Inner.IpAddress.Type != null && this.Inner.IpAddress.Type.Equals(ContainerGroupIpAddressType.Private.ToString());
        }

        public bool IsIPAddressPublic()
        {
            return this.Inner.IpAddress != null && this.Inner.IpAddress.Type != null && this.Inner.IpAddress.Type.Equals(ContainerGroupIpAddressType.Public.ToString());
        }

        public bool IsManagedServiceIdentityEnabled()
        {
            ResourceIdentityType? type = this.ManagedServiceIdentityType();
            return type != null && type != ResourceIdentityType.None;
        }
        public LogAnalytics LogAnalytics() {
            return this.Inner.Diagnostics.LogAnalytics;
        }

        public ResourceIdentityType? ManagedServiceIdentityType()
        {
            if (this.Inner.Identity != null)
            {
                return this.Inner.Identity.Type;
            }
            return null;
        }

        public string NetworkProfileId() {
            return this.Inner.NetworkProfile.Id;
        }

        public string SystemAssignedManagedServiceIdentityPrincipalId()
        {
            if (this.Inner.Identity != null)
            {
                return this.Inner.Identity.PrincipalId;
            }
            return null;
        }

        public string SystemAssignedManagedServiceIdentityTenantId()
        {
            if (this.Inner.Identity != null)
            {
                return this.Inner.Identity.TenantId;
            }
            return null;
        }

        public IReadOnlyCollection<string> UserAssignedManagedServiceIdentityIds()
        {
            if (this.Inner.Identity != null && this.Inner.Identity.UserAssignedIdentities != null)
            {
                return new ReadOnlyCollection<string>(new List<string>(this.Inner.Identity.UserAssignedIdentities.Keys));
            }
            return new ReadOnlyCollection<String>(new List<String>());
        }

        ///GENMHASH:9C262E34A24F538EA2B9CCF05B5DDC31:B1054C7ABC568976F407B3F83CBEF497
        public int[] ExternalTcpPorts()
        {
            return this.externalTcpPorts;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:99ECDF2C7D842BA7D2742AC2953EDA92
        public string State()
        {
            return this.Inner.InstanceView != null ? this.Inner.InstanceView.State : null;
        }

        ///GENMHASH:59B08BD03F2496BDEFB0CB87748CB717:75DE4FE44AED6C1A4FA25A3E81685E01
        public IReadOnlyCollection<string> ImageRegistryServers()
        {
            return new ReadOnlyCollection<string>(imageRegistryServers);
        }

        ///GENMHASH:48C59AE949E12C01A6C61142D3D2B6C5:213253B61921C0106B8B07DBB056405B
        public IReadOnlyCollection<Models.Port> ExternalPorts()
        {
            return new ReadOnlyCollection<Port>(this.Inner.IpAddress != null && this.Inner.IpAddress.Ports != null ?
                this.Inner.IpAddress.Ports : new List<Port>());
        }

        ///GENMHASH:AB09C46CE8F9CA6FA0F625131031E74D:1631EAB8864F459FF3F0235822E771D5
        public IReadOnlyDictionary<string, Models.Volume> Volumes()
        {
            return new ReadOnlyDictionary<string, Models.Volume>(this.volumes);
        }

        ///GENMHASH:568B36CDA0227A7F3A32B87E92E09B4D:C12E94C76D9C55968CE90919BD8CF60E
        public IReadOnlyDictionary<string, Models.Container> Containers()
        {
            return new ReadOnlyDictionary<string, Models.Container>(this.containers);
        }

        ///GENMHASH:EB9638E8F65D17F5F594E27D773A247D:9A9A38EC01C4A2143FD55250B964F335
        public string IPAddress()
        {
            return this.Inner.IpAddress != null ? this.Inner.IpAddress.Ip : null;
        }

        ///GENMHASH:B7B94C51823E8E9590CFB5D3B4497C02:0FB59B85F29ED94C51DB36094BBDE1A8
        public int[] ExternalUdpPorts()
        {
            return this.externalUdpPorts;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:023E92B4527E4CFAE96195535BADEFE2
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        public Fluent.OSTypeName OSType()
        {
            return Fluent.OSTypeName.Parse(this.Inner.OsType);
        }

        ///GENMHASH:72D8F838766D2FA789A06DBB8ACE4C8C:6688B3D6EDBA6430DBE60C201714B737
        public ContainerGroupRestartPolicy RestartPolicy()
        {
            return ContainerGroupRestartPolicy.Parse(this.Inner.RestartPolicy);
        }

        public void Restart()
        {
            Extensions.Synchronize(() => this.RestartAsync());
        }

        public async Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.ContainerGroups.RestartAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        public void Stop()
        {
            Extensions.Synchronize(() => this.StopAsync());
        }

        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.ContainerGroups.StopAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:43FFE67ED1E08092A08C7E35A3244CB2:E6719DA498FFBEA871EB1D1A559ABB37
        public IReadOnlyCollection<Models.EventModel> Events()
        {
            return new ReadOnlyCollection<Models.EventModel>(this.Inner.InstanceView != null && this.Inner.InstanceView.Events != null ?
                this.Inner.InstanceView.Events : new List<Models.EventModel>());
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:40DC8096FB53D9EA447C99B67637E40C
        protected void InitializeChildrenFromInner()
        {
            this.newFileShares = null;
            this.creatableStorageAccountKey = null;

            this.containers = new Dictionary<string, Container>();
            this.volumes = new Dictionary<string, Volume>();
            this.imageRegistryServers = new List<string>();

            // Getting the container instances
            if (this.Inner.Containers != null && this.Inner.Containers.Count > 0)
            {
                foreach (var ContainerInstance in this.Inner.Containers)
                {
                    this.containers.Add(ContainerInstance.Name, ContainerInstance);
                }
            }

            // Getting the volumes
            if (this.Inner.Volumes != null && this.Inner.Volumes.Count > 0)
            {
                foreach (var volume in this.Inner.Volumes)
                {
                    this.volumes.Add(volume.Name, volume);
                }
            }

            // Getting the private image registry servers
            if (this.Inner.ImageRegistryCredentials != null && this.Inner.ImageRegistryCredentials.Count > 0)
            {
                foreach (var imageRegistry in this.Inner.ImageRegistryCredentials)
                {
                    this.imageRegistryServers.Add(imageRegistry.Server);
                }
            }

            // Splitting ports between TCP and UDP ports
            if (this.Inner.IpAddress != null && this.Inner.IpAddress.Ports != null && this.Inner.IpAddress.Ports.Count > 0)
            {
                this.externalTcpPorts = this.Inner.IpAddress.Ports.Where(p => ContainerGroupNetworkProtocol.TCP.Equals(p.Protocol)).Select(p => p.PortProperty).ToArray();
                this.externalUdpPorts = this.Inner.IpAddress.Ports.Where(p => ContainerGroupNetworkProtocol.UDP.Equals(p.Protocol)).Select(p => p.PortProperty).ToArray();
            }
            else
            {
                this.externalTcpPorts = new int[0];
                this.externalUdpPorts = new int[0];
            }
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:30511FD503549EDC455B6D09D542DB93
        public async override Task<IContainerGroup> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.RefreshAsync(cancellationToken);
            this.InitializeChildrenFromInner();

            return this;
        }

        public async override Task<IContainerGroup> CreateResourceAsync(CancellationToken cancellationToken)
        {
            this.containerGroupMsiHandler.ProcessCreatedExternalIdentities();
            this.containerGroupMsiHandler.HandleExternalIdentities();
            ContainerGroupImpl self = this;
            if (IsInCreateMode)
            {
                if (this.creatableStorageAccountKey != null && this.newFileShares != null && this.newFileShares.Count > 0)
                {
                    // Creates the new Azure file shares
                    var storageAccount = this.CreatedResource(this.creatableStorageAccountKey) as IStorageAccount;
                    if (this.Inner.Volumes == null)
                    {
                        this.Inner.Volumes = new List<Volume>();
                    }
                    var storageAccountKey = (await storageAccount.GetKeysAsync())[0].Value;
                    var sas = $"DefaultEndpointsProtocol=https;AccountName={storageAccount.Name};AccountKey={storageAccountKey};EndpointSuffix=core.Windows.Net";
                    var cloudFileClient = CloudStorageAccount.Parse(sas).CreateCloudFileClient();
                    foreach (var fileShare in this.newFileShares)
                    {
                        CloudFileShare cloudFileShare = cloudFileClient.GetShareReference(fileShare.Value);
                        await cloudFileShare.CreateIfNotExistsAsync();
                        this.Inner.Volumes.Add(new Volume
                        {
                            Name = fileShare.Key,
                            AzureFile = new AzureFileVolume
                            {
                                ShareName = fileShare.Value,
                                ReadOnlyProperty = false,
                                StorageAccountName = storageAccount.Name,
                                StorageAccountKey = storageAccountKey
                            }
                        });
                    }
                }

                var inner = await this.Manager.Inner.ContainerGroups.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
                SetInner(inner);
                this.InitializeChildrenFromInner();

                return this;
            }
            else
            {
                var resourceInner = new ResourceInner();
                resourceInner.Location = this.RegionName;
                resourceInner.Tags = this.Inner.Tags;
                var updatedInner = await this.Manager.Inner.ContainerGroups.UpdateAsync(this.ResourceGroupName, this.Name, resourceInner, cancellationToken: cancellationToken);
                // TODO: this will go away after service fixes the update bug
                updatedInner = await this.GetInnerAsync(cancellationToken);
                SetInner(updatedInner);
                this.InitializeChildrenFromInner();

                return this;
            }
        }

        protected override Task<ContainerGroupInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return this.Manager.Inner.ContainerGroups.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }


        ///GENMHASH:002B9FED6878745A10FBEF2FDB77458A:4C268D270623A9FCE0E849411F7DACB8
        public ContainerGroupImpl WithLinux()
        {
            this.Inner.OsType = Fluent.OSTypeName.Linux.ToString();

            return this;
        }

        ///GENMHASH:21843F6A42DA7655078B0AAA573930DC:1BB4AF60868C4D62F669F7DFFC20EE87
        public ContainerGroupImpl WithWindows()
        {
            this.Inner.OsType = Fluent.OSTypeName.Windows.ToString();

            return this;
        }

        ///GENMHASH:81CB563AFF6AD26FDBD5ADDFA8E9807A:29FFF0E66BE4B91F688014D063FC58D9
        public ContainerGroupImpl WithPrivateImageRegistry(string server, string username, string password)
        {
            if (this.Inner.ImageRegistryCredentials == null)
            {
                this.Inner.ImageRegistryCredentials = new List<ImageRegistryCredential>();
            }
            this.Inner.ImageRegistryCredentials.Add(new ImageRegistryCredential
            {
                Server = server,
                Username = username,
                Password = password
            });

            return this;
        }

        ///GENMHASH:2CB4C248C39610BBCDFA3C7C13950F51:345DD81D2BBDE0DAE630775246270473
        public ContainerGroupImpl WithPublicImageRegistryOnly()
        {
            this.Inner.ImageRegistryCredentials = null;

            return this;
        }

        ///GENMHASH:F0C4F6A7F84296DE6B5B22E9CD83088B:3AA393F2B1A370FDC3C77E87951AD500
        public ContainerGroupImpl WithoutVolume()
        {
            this.Inner.Volumes = null;

            return this;
        }

        ///GENMHASH:948C3D8A111E9F3CE85191C15BCEEBFF:E4410CA2195639D89F98489D4A24F153
        public ContainerGroupImpl WithEmptyDirectoryVolume(string volumeName)
        {
            if (this.Inner.Volumes == null)
            {
                this.Inner.Volumes = new List<Volume>();
            }
            this.Inner.Volumes.Add(new Volume()
            {
                Name = volumeName,
                EmptyDir = new Object()
            });

            return this;
        }

        ///GENMHASH:DFC2593B74D1E01275625E2EE80CC9AD:D22668247339DCCC31D9166C946C6AA8
        public ContainerGroupImpl WithNewAzureFileShareVolume(string volumeName, string shareName)
        {
            if (this.newFileShares == null || this.creatableStorageAccountKey == null)
            {
                Storage.Fluent.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
                                .StorageAccounts
                                .Define(SdkContext.RandomResourceName("fs", 24))
                                .WithRegion(this.RegionName);
                Storage.Fluent.StorageAccount.Definition.IWithCreate creatable;
                if (this.newGroup != null)
                {
                    creatable = definitionWithGroup.WithNewResourceGroup(this.newGroup);
                }
                else
                {
                    creatable = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
                }
                this.creatableStorageAccountKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);

                this.newFileShares = new Dictionary<string, string>();
            }

            this.newFileShares.Add(volumeName, shareName);

            return this;
        }

        ///GENMHASH:C518B06C0BBC9766A09F6FD2432A9CD4:FDC33FB248B626868B54320954852A00
        public VolumeImpl DefineVolume(string name)
        {
            return new VolumeImpl(this, name);
        }

        ///GENMHASH:7094AF382C96EC7FD1063D04C15909E0:176B8A1880E543242F8EA2343BF2B436
        public ContainerImpl DefineContainerInstance(string name)
        {
            return new ContainerImpl(this, name);
        }

        ///GENMHASH:A56B900EF7111F72F47E8873EAB80EC5:D0617CA076D9D9042A7EB6FB9E67995F
        public ContainerGroupImpl WithContainerInstance(string imageName)
        {
            return this.DefineContainerInstance(this.Name)
                .WithImage(imageName)
                .WithoutPorts()
                .WithCpuCoreCount(1)
                .WithMemorySizeInGB(1.5)
                .Attach();
        }

        ///GENMHASH:95D94B5131D92BA7AF72C28CE506404B:B731C6B2B19E78D26B13FB71FBD36ECF
        public ContainerGroupImpl WithContainerInstance(string imageName, int port)
        {
            return this.DefineContainerInstance(this.Name)
                .WithImage(imageName)
                .WithExternalTcpPort(port)
                .WithCpuCoreCount(1)
                .WithMemorySizeInGB(1.5)
                .Attach();
        }

        ///GENMHASH:1C73260E17F72F996B485F399B1A7E02:93461D0A597F2906607068C9C6F891F6
        public ContainerGroupImpl WithRestartPolicy(ContainerGroupRestartPolicy restartPolicy)
        {
            this.Inner.RestartPolicy = restartPolicy.ToString();

            return this;
        }



        ///GENMHASH:5539452FF37A2039D171B77EAB519674:F662BD68539B03381406F317464C0B00
        public string GetLogContent(string containerName)
        {
            return Extensions.Synchronize(() => this.GetLogContentAsync(containerName));
        }

        ///GENMHASH:E56134B3DD31D67F07D4B5EDC1D24FD7:137080B7ED8C37E287C17CC77224DECA
        public string GetLogContent(string containerName, int tailLineCount)
        {
            return Extensions.Synchronize(() => this.GetLogContentAsync(containerName, tailLineCount));
        }

        ///GENMHASH:68FA359B278647E097B20441389A58FC:3119C16FFA0F521767097C339920EE47
        public async Task<string> GetLogContentAsync(string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var log = await this.Manager.Inner.Container.ListLogsAsync(this.ResourceGroupName, this.Name, containerName, cancellationToken: cancellationToken);

            return (log != null) ? log.Content : "";
        }

        ///GENMHASH:FF17FE4F8B9A7B52DB8052C65778E9B1:62A00FD4D8AED790BA6A5B89296698FF
        public async Task<string> GetLogContentAsync(string containerName, int tailLineCount, CancellationToken cancellationToken = default(CancellationToken))
        {
            var log = await this.Manager.Inner.Container.ListLogsAsync(this.ResourceGroupName, this.Name, containerName, tailLineCount, cancellationToken);

            return (log != null) ? log.Content : "";
        }

        ///GENMHASH:8642FC9B9C8DC7375DEE3CC5736F8853:D8E9D98F2E55B91C74B8A9CCC0D57DFB
        public ContainerGroupImpl WithDnsPrefix(string dnsPrefix)
        {
            if (this.Inner.IpAddress == null)
            {
                this.Inner.IpAddress = new IpAddress();
            }
            this.Inner.IpAddress.DnsNameLabel = dnsPrefix;
            this.Inner.IpAddress.Type = ContainerGroupIpAddressType.Public.ToString();

            return this;
        }

        ///GENMHASH:59348A25FD515049ECD26A6290F76B85:E61328CEA9774DAE97931A8E3F5BA1FA
        public string DnsPrefix()
        {
            return (this.Inner.IpAddress != null) ? this.Inner.IpAddress.DnsNameLabel : null;
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:6EE2F2474752814D061D517DDCF91010
        public string Fqdn()
        {
            return (this.Inner.IpAddress != null) ? this.Inner.IpAddress.Fqdn : null;
        }

        ///GENMHASH:F4416221E7E4EB6A087BCA399AE5E9F6:A0E77E1086B086D8F0F97954516DA583
        public IContainerExecResponse ExecuteCommand(string containerName, string command, int row, int column)
        {
            return Extensions.Synchronize(() => this.ExecuteCommandAsync(containerName, command, row, column));
        }

        ///GENMHASH:5D1452C0A2F0D2A020CBCC369E41D1F2:67CC4D00B6C73394256E4765E8876BE5
        public async Task<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse> ExecuteCommandAsync(string containerName, string command, int row, int column, CancellationToken cancellationToken = default(CancellationToken))
        {
            var containerExecRequestTerminalSize = new ContainerExecRequestTerminalSize() { Rows = row, Cols = column };
            var containerExecRequestInner = new Models.ContainerExecRequestInner() { Command = command, TerminalSize = containerExecRequestTerminalSize };
            var containerExecResponseInner = await this.Manager.Inner.Container
                .ExecuteCommandAsync(this.ResourceGroupName, this.Name, containerName, containerExecRequestInner, cancellationToken);
            return new ContainerExecResponseImpl(containerExecResponseInner);
        }

        public IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedManagedServiceIdentity()
        {
            this.containerGroupMsiHandler.WithLocalManagedServiceIdentity();
            return this;
        }

        public IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            this.containerGroupMsiHandler.WithAccessTo(resourceId, role);
            return this;
        }

        public IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            this.containerGroupMsiHandler.WithAccessTo(resourceId, roleDefinitionId);
            return this;
        }

        public IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            this.containerGroupMsiHandler.WithAccessToCurrentResourceGroup(role);
            return this;
        }

        public IWithSystemAssignedIdentityBasedAccessOrCreate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            this.containerGroupMsiHandler.WithAccessToCurrentResourceGroup(roleDefinitionId);
            return this;
        }

        public IWithCreate WithDnsConfiguration(IList<string> dnsServerNames, string dnsSearchDomains, string dnsOptions)
        {
            DnsConfiguration dnsConfiguration = new DnsConfiguration();
            dnsConfiguration.NameServers = dnsServerNames;
            dnsConfiguration.SearchDomains = dnsSearchDomains;
            dnsConfiguration.Options = dnsOptions;
            this.Inner.DnsConfig = dnsConfiguration;
            return this;
        }

        public IWithCreate WithDnsServerNames(IList<string> dnsServerNames)
        {
            DnsConfiguration dnsConfiguration = new DnsConfiguration();
            dnsConfiguration.NameServers = dnsServerNames;
            this.Inner.DnsConfig = dnsConfiguration;
            return this;
        }

        public IWithCreate WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            this.containerGroupMsiHandler.WithExistingExternalManagedServiceIdentity(identity);
            return this;
        }

        public IWithCreate WithNewUserAssignedManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity)
        {
            this.containerGroupMsiHandler.WithNewExternalManagedServiceIdentity(creatableIdentity);
            return this;
        }

        public IDnsConfigFork WithNetworkProfileId(string subscriptionId, string resourceGroupName, string networkProfileName)
        {
            String networkProfileId = "/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/networkProfiles/" + networkProfileName;
            ContainerGroupNetworkProfile containerGroupNetworkProfile = new ContainerGroupNetworkProfile();
            containerGroupNetworkProfile.Id = networkProfileId;
            this.Inner.NetworkProfile = containerGroupNetworkProfile;
            if (this.Inner.IpAddress != null)
            {
                this.Inner.IpAddress.Type = ContainerGroupIpAddressType.Private.ToString();
            }
            return this;
        }

        public IWithCreate WithLogAnalytics(string workspaceId, string workspaceKey)
        {
            LogAnalytics logAnalytics = new LogAnalytics();
            logAnalytics.WorkspaceId = workspaceId;
            logAnalytics.WorkspaceKey = workspaceKey;
            this.Inner.Diagnostics = new ContainerGroupDiagnostics();
            this.Inner.Diagnostics.LogAnalytics = logAnalytics;
            return this;
        }

        public IWithCreate WithLogAnalytics(string workspaceId, string workspaceKey, LogAnalyticsLogType logType, IDictionary<string, string> metadata)
        {
            LogAnalytics logAnalytics = new LogAnalytics();
            logAnalytics.WorkspaceId = workspaceId;
            logAnalytics.WorkspaceKey = workspaceKey;
            logAnalytics.LogType = logType;
            logAnalytics.Metadata = metadata;
            this.Inner.Diagnostics = new ContainerGroupDiagnostics();
            this.Inner.Diagnostics.LogAnalytics = logAnalytics;
            return this;
        }
    }
}