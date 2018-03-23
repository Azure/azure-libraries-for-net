// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIFileServer.Definition;


    /// <summary>
    /// Implementation for BatchAIFileServer and its create and update interfaces.
    /// </summary>
    public partial class BatchAIFileServerImpl :
        ResourceManager.Fluent.GroupableResource<
            IBatchAIFileServer,
            FileServerInner,
            BatchAIFileServerImpl,
            IBatchAIManager,
            IWithGroup,
            IWithDataDisks,
            IWithCreate,
            IWithCreate>,
        IBatchAIFileServer,
        IDefinition
    {
        private FileServerCreateParametersInner createParameters = new FileServerCreateParametersInner();
        internal BatchAIFileServerImpl(string name, FileServerInner innerObject, IBatchAIManager manager)
            : base(name, innerObject, manager)
        {
        }

        public BatchAIFileServerImpl WithVMSize(string vmSize)
        {
            createParameters.VmSize = vmSize;
            return this;
        }

        public BatchAIFileServerImpl WithSshPublicKey(string sshPublicKey)
        {
            EnsureUserAccountSettings().AdminUserSshPublicKey = sshPublicKey;
            return this;
        }

        public BatchAIFileServerImpl WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType)
        {
            DataDisks dataDisks = EnsureDataDisks();
            dataDisks.DiskSizeInGB = diskSizeInGB;
            dataDisks.DiskCount = diskCount;
            dataDisks.StorageAccountType = storageAccountType == null ? null : storageAccountType.Value;
            return this;
        }

        ///GENMHASH:724C7623D19A41D0DA37EDEDF5B45340:E0613BA7E2936CBE7482C98B6400EA39
        public IWithVMSize WithDataDisks(int diskSizeInGB, int diskCount, StorageAccountType storageAccountType, CachingType cachingType)
        {
            DataDisks dataDisks = EnsureDataDisks();
            dataDisks.DiskSizeInGB = diskSizeInGB;
            dataDisks.DiskCount = diskCount;
            dataDisks.StorageAccountType = storageAccountType == null ? null : storageAccountType.Value;
            dataDisks.CachingType = cachingType;
            return this;
        }


        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:8E1100FECC94D8D02A007E94A2829ADE
        public IWithCreate WithSubnet(string subnetId)
        {
            createParameters.Subnet = new ResourceId(subnetId);
            return this;
        }

        ///GENMHASH:9047F7688B1B60794F60BC930616198C:611CA1FC53B66F8126B3A71A8F7A964F
        public IWithCreate WithSubnet(string networkId, string subnetName)
        {
            createParameters.Subnet = new ResourceId(networkId + "/subnets/" + subnetName);
            return this;
        }

        public BatchAIFileServerImpl WithUserName(string userName)
        {
            EnsureUserAccountSettings().AdminUserName = userName;
            return this;
        }

        public BatchAIFileServerImpl WithPassword(string password)
        {
            EnsureUserAccountSettings().AdminUserPassword = password;
            return this;
        }

        private UserAccountSettings EnsureUserAccountSettings()
        {
            if (EnsureSshConfiguration().UserAccountSettings == null)
            {
                createParameters.SshConfiguration.UserAccountSettings = new UserAccountSettings();
            }
            return createParameters.SshConfiguration.UserAccountSettings;
        }

        protected override async Task<FileServerInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.FileServers.GetAsync(ResourceGroupName, Name, cancellationToken);
        }

        private SshConfiguration EnsureSshConfiguration()
        {
            if (createParameters.SshConfiguration == null)
            {
                createParameters.SshConfiguration = new SshConfiguration();
            }
            return createParameters.SshConfiguration;
        }

        private DataDisks EnsureDataDisks()
        {
            if (createParameters.DataDisks == null)
            {
                createParameters.DataDisks = new DataDisks();
            }
            return createParameters.DataDisks;
        }

        public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            createParameters.Location = this.RegionName;
            createParameters.Tags = this.Inner.Tags;
            await Manager.Inner.FileServers.CreateAsync(ResourceGroupName, Name, createParameters);
            return this;
        }

        public DateTime CreationTime()
        {
            return Inner.CreationTime.GetValueOrDefault();
        }

        public DateTime ProvisioningStateTransitionTime()
        {
            return Inner.ProvisioningStateTransitionTime.GetValueOrDefault();
        }

        public FileServerProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        public SshConfiguration SshConfiguration()
        {
            return Inner.SshConfiguration;
        }

        public MountSettings MountSettings()
        {
            return Inner.MountSettings;
        }

        public DataDisks DataDisks()
        {
            return Inner.DataDisks;
        }

        public string VMSize()
        {
            return Inner.VmSize;
        }

        public ResourceId Subnet()
        {
            return Inner.Subnet;
        }
    }
}