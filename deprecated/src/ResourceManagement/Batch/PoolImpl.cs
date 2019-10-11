// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccount pool and its parent interfaces.
    /// </summary>
    internal partial class PoolImpl :
        ExternalChildResource<
            IPool,
            PoolInner,
            IBatchAccount,
            BatchAccountImpl>,
        IPool,
        Pool.Definition.IDefinition<BatchAccount.Definition.IWithPool>,
        Pool.UpdateDefinition.IUpdateDefinition<BatchAccount.Update.IUpdate>,
        Pool.Update.IUpdate
    {
        internal PoolImpl(
            string name,
            BatchAccountImpl batchAccount,
            PoolInner inner)
            : base(name, batchAccount, inner)
        {
        }

        internal static PoolImpl NewPool(string name, BatchAccountImpl parent)
        {
            var inner = new PoolInner();
            inner.DisplayName = name;
            var poolImpl = new PoolImpl(name, parent, inner);

            return poolImpl;
        }

        public async override Task<IPool> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.Pool.CreateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                Inner,
                default(string),
                default(string),
                cancellationToken);

            return this;
        }

        public async override Task<IPool> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.Pool.UpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                Inner,
                default(string),
                cancellationToken);

            return this;
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.Pool.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                cancellationToken);
        }

        public override async Task<IPool> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.RefreshAsync(cancellationToken);
        }

        protected override async Task<PoolInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.Pool.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Inner.Name,
                cancellationToken);
        } 

        public BatchAccountImpl Attach()
        {
            return Parent.WithPool(this);
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        internal string VmSize()
        {
            return Inner.VmSize; 
        }

        internal NetworkConfiguration NetworkConfiguration()
        {
            return Inner.NetworkConfiguration;
        }

        internal IList<MountConfiguration> MountConfiguration()
        {
            return Inner.MountConfiguration;
        }

        internal ScaleSettings ScaleSettings()
        {
            return Inner.ScaleSettings;
        }

        internal StartTask StartTask()
        {
            return Inner.StartTask;
        }

        internal IList<MetadataItem> Metadata()
        {
            return Inner.Metadata;
        }

        internal IList<ApplicationPackageReference> applicationPackages()
        {
            return Inner.ApplicationPackages;
        }

        internal IList<CertificateReference> Certificates()
        {
            return Inner.Certificates;
        }

        internal DeploymentConfiguration DeploymentConfiguration()
        {
            return Inner.DeploymentConfiguration;
        }

        internal InterNodeCommunicationState InterNodeCommunication()
        {
            return Inner.InterNodeCommunication.GetValueOrDefault();
        }

        internal int? MaxTasksPerNode()
        {
            return Inner.MaxTasksPerNode;
        }

        internal TaskSchedulingPolicy TaskSchedulingPolicy()
        {
            return Inner.TaskSchedulingPolicy;
        }

        internal IList<UserAccount> UserAccounts()
        {
            return Inner.UserAccounts;
        }

        internal IList<string> ApplicationLicenses()
        {
            return Inner.ApplicationLicenses;
        }

        internal string DisplayName()
        {
            return Inner.DisplayName;
        }

        public PoolImpl WithNetworkConfiguration(NetworkConfiguration networkConfiguration)
        {
            Inner.NetworkConfiguration = networkConfiguration;
            return this;
        }

        public PoolImpl WithMountConfiguration(IList<MountConfiguration> mountConfiguration)
        {
            Inner.MountConfiguration = mountConfiguration;
            return this;
        }

        public PoolImpl WithScaleSettings(ScaleSettings scaleSettings)
        {
            Inner.ScaleSettings = scaleSettings;
            return this;
        }

        public PoolImpl WithStartTask(StartTask startTask)
        {
            Inner.StartTask = startTask;
            return this;
        }

        public PoolImpl WithMetadata(IList<MetadataItem> metadata)
        {
            Inner.Metadata = metadata;
            return this;
        }

        public PoolImpl WithApplicationPackages(IList<ApplicationPackageReference> applicationPackages)
        {
            Inner.ApplicationPackages = applicationPackages;
            return this;
        }

        public PoolImpl WithCertificates(IList<CertificateReference> certificates)
        {
            Inner.Certificates = certificates;
            return this;
        }

        public PoolImpl WithVmSize(string vmSize)
        {
            Inner.VmSize = vmSize;
            return this;
        }

        public PoolImpl WithDeploymentConfiguration(DeploymentConfiguration deploymentConfiguration)
        {
            Inner.DeploymentConfiguration = deploymentConfiguration;
            return this;
        }

        public PoolImpl WithDisplayName(string displayName)
        {
            Inner.DisplayName = displayName;
            return this;
        }

        public PoolImpl WithInterNodeCommunication(InterNodeCommunicationState interNodeCommunication)
        {
            Inner.InterNodeCommunication = interNodeCommunication;
            return this;
        }

        public PoolImpl WithMaxTasksPerNode(int? maxTasksPerNode)
        {
            Inner.MaxTasksPerNode = maxTasksPerNode;
            return this;
        }

        public PoolImpl WithTaskSchedulingPolicy(TaskSchedulingPolicy taskSchedulingPolicy)
        {
            Inner.TaskSchedulingPolicy = taskSchedulingPolicy;
            return this;
        }

        public PoolImpl WithUserAccount(IList<UserAccount> userAccounts)
        {
            Inner.UserAccounts = userAccounts;
            return this;
        }

        public PoolImpl WithApplicationLicenses(IList<string> applicationLicenses)
        {
            Inner.ApplicationLicenses = applicationLicenses;
            return this;
        }

        BatchAccount.Update.IUpdate ISettable<BatchAccount.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
