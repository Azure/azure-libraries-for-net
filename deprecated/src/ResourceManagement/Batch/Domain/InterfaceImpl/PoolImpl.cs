// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Microsoft.Azure.Management.Batch.Fluent.Models;
    using System.Collections.Generic;

    internal partial class PoolImpl
    {
        /// <summary>
        /// Gets the display name for the pool.
        /// </summary>
        string IPool.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets the size of virtual machine for the pool.
        /// </summary>
        string IPool.VmSize
        {
            get
            {
                return this.VmSize();
            }
        }

        /// <summary>
        /// Gets the network configuration for the pool.
        /// </summary>
        NetworkConfiguration IPool.NetworkConfiguration
        {
            get
            {
                return this.NetworkConfiguration();
            }
        }

        /// <summary>
        /// Gets the file system configuration for the pool.
        /// </summary>
        IList<MountConfiguration> IPool.MountConfiguration
        {
            get
            {
                return this.MountConfiguration();
            }
        }

        /// <summary>
        /// Gets the scale settings for the pool.
        /// </summary>
        ScaleSettings IPool.ScaleSettings
        {
            get
            {
                return this.ScaleSettings();
            }
        }

        /// <summary>
        /// Gets the start task for the pool.
        /// </summary>
        StartTask IPool.StartTask
        {
            get
            {
                return this.StartTask();
            }
        }

        /// <summary>
        /// Gets the metadata for the pool.
        /// </summary>
        IList<MetadataItem> IPool.Metadata
        {
            get
            {
                return this.Metadata();
            }
        }

        /// <summary>
        /// Gets the application packages for the pool.
        /// </summary>
        IList<ApplicationPackageReference> IPool.applicationPackages
        {
            get
            {
                return this.applicationPackages();
            }
        }

        /// <summary>
        /// Gets the certificates for the pool.
        /// </summary>
        IList<CertificateReference> IPool.Certificates
        {
            get
            {
                return this.Certificates();
            }
        }

        /// <summary>
        /// Gets the deployment configuration for the pool.
        /// </summary>
        DeploymentConfiguration IPool.DeploymentConfiguration
        {
            get
            {
                return this.DeploymentConfiguration();
            }
        }

        /// <summary>
        /// Gets the state whether the pool permits direct communication between nodes.
        /// </summary>
        InterNodeCommunicationState IPool.InterNodeCommunication
        {
            get
            {
                return this.InterNodeCommunication();
            }
        }

        /// <summary>
        /// Gets the maximum number of tasks can run on the pool.
        /// </summary>
        int? IPool.MaxTasksPerNode
        {
            get
            {
                return this.MaxTasksPerNode();
            }
        }

        /// <summary>
        /// Gets the task scheduling policy for the pool.
        /// </summary>
        TaskSchedulingPolicy IPool.TaskSchedulingPolicy
        {
            get
            {
                return this.TaskSchedulingPolicy();
            }
        }

        /// <summary>
        /// Gets the user accounts for the pool.
        /// </summary>
        IList<UserAccount> IPool.UserAccounts
        {
            get
            {
                return this.UserAccounts();
            }
        }

        /// <summary>
        /// Gets the application licenses for the pool.
        /// </summary>
        IList<string> IPool.ApplicationLicenses
        {
            get
            {
                return this.ApplicationLicenses();
            }
        }

        /// <summary>
        /// Specifies the network configuration for the pool.
        /// </summary>
        /// <param name="networkConfiguration">The network configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithNetworkConfiguration(NetworkConfiguration networkConfiguration)
        {
            return this.WithNetworkConfiguration(networkConfiguration);
        }

        /// <summary>
        /// Specifies the file system configuration for the pool.
        /// </summary>
        /// <param name="mountConfiguration">The mount configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithMountConfiguration(IList<MountConfiguration> mountConfiguration)
        {
            return this.WithMountConfiguration(mountConfiguration);
        }

        /// <summary>
        /// Specifies the scale settings for the pool.
        /// </summary>
        /// <param name="scaleSettings">The scale settings value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithScaleSettings(ScaleSettings scaleSettings)
        {
            return this.WithScaleSettings(scaleSettings);
        }

        /// <summary>
        /// Specifies the start task for the pool.
        /// </summary>
        /// <param name="startTask">The start task value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithStartTask(StartTask startTask)
        {
            return this.WithStartTask(startTask);
        }

        /// <summary>
        /// Specifies the metadata for the pool.
        /// </summary>
        /// <param name="metadata">The metadata value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithMetadata(IList<MetadataItem> metadata)
        {
            return this.WithMetadata(metadata);
        }

        /// <summary>
        /// Specifies the application packages for the pool.
        /// </summary>
        /// <param name="applicationPackages">The application packages value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithApplicationPackages(IList<ApplicationPackageReference> applicationPackages)
        {
            return this.WithApplicationPackages(applicationPackages);
        }

        /// <summary>
        /// Specifies the certificates for the pool.
        /// </summary>
        /// <param name="certificates">The certificates value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithCertificates(IList<CertificateReference> certificates)
        {
            return this.WithCertificates(certificates);
        }

        /// <summary>
        /// Specifies the size of virtual machine for the pool.
        /// </summary>
        /// <param name="vmSize">The size of virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithVmSize(string vmSize)
        {
            return this.WithVmSize(vmSize);
        }

        /// <summary>
        /// Specifies the deployment configuration for the pool.
        /// </summary>
        /// <param name="deploymentConfiguration">The deployment configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithDeploymentConfiguration(DeploymentConfiguration deploymentConfiguration)
        {
            return this.WithDeploymentConfiguration(deploymentConfiguration);
        }

        /// <summary>
        /// Specifies the display name for the pool.
        /// </summary>
        /// <param name="displayName">The display name value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName);
        }

        /// <summary>
        /// Specifies the interNodeCommunication value for the pool.
        /// </summary>
        /// <param name="interNodeCommunication">The state indicating whether the pool permits direct communication between nodes.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithInterNodeCommunication(InterNodeCommunicationState interNodeCommunication)
        {
            return this.WithInterNodeCommunication(interNodeCommunication);
        }

        /// <summary>
        /// Specifies the max tasks can run on the pool.
        /// </summary>
        /// <param name="maxTasksPerNode">The maximum number can run on the pool.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithMaxTasksPerNode(int? maxTasksPerNode)
        {
            return this.WithMaxTasksPerNode(maxTasksPerNode);
        }

        /// <summary>
        /// Specifies the task sceduling policy for the pool.
        /// </summary>
        /// <param name="taskSchedulingPolicy">The taskScedulingPolicy value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithTaskSchedulingPolicy(TaskSchedulingPolicy taskSchedulingPolicy)
        {
            return this.WithTaskSchedulingPolicy(taskSchedulingPolicy);
        }

        /// <summary>
        /// Specifies the user accounts for the pool.
        /// </summary>
        /// <param name="userAccounts">The userAccounts value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithUserAccount(IList<UserAccount> userAccounts)
        {
            return this.WithUserAccount(userAccounts);
        }

        /// <summary>
        /// Specifies the application licenses for the pool.
        /// </summary>
        /// <param name="applicationLicenses">The applicationLicenses value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool> Pool.Definition.IWithAttach<BatchAccount.Definition.IWithPool>.WithApplicationLicenses(IList<string> applicationLicenses)
        {
            return this.WithApplicationLicenses(applicationLicenses);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAccount.Definition.IWithPool ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<BatchAccount.Definition.IWithPool>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the network configuration for the pool.
        /// </summary>
        /// <param name="networkConfiguration">The network configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithNetworkConfiguration(NetworkConfiguration networkConfiguration)
        {
            return this.WithNetworkConfiguration(networkConfiguration);
        }

        /// <summary>
        /// Specifies the file system configuration for the pool.
        /// </summary>
        /// <param name="mountConfiguration">The mount configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithMountConfiguration(IList<MountConfiguration> mountConfiguration)
        {
            return this.WithMountConfiguration(mountConfiguration);
        }

        /// <summary>
        /// Specifies the scale settings for the pool.
        /// </summary>
        /// <param name="scaleSettings">The scale settings value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithScaleSettings(ScaleSettings scaleSettings)
        {
            return this.WithScaleSettings(scaleSettings);
        }

        /// <summary>
        /// Specifies the start task for the pool.
        /// </summary>
        /// <param name="startTask">The start task value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithStartTask(StartTask startTask)
        {
            return this.WithStartTask(startTask);
        }

        /// <summary>
        /// Specifies the metadata for the pool.
        /// </summary>
        /// <param name="metadata">The metadata value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithMetadata(IList<MetadataItem> metadata)
        {
            return this.WithMetadata(metadata);
        }

        /// <summary>
        /// Specifies the application packages for the pool.
        /// </summary>
        /// <param name="applicationPackages">The application packages value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithApplicationPackages(IList<ApplicationPackageReference> applicationPackages)
        {
            return this.WithApplicationPackages(applicationPackages);
        }

        /// <summary>
        /// Specifies the certificates for the pool.
        /// </summary>
        /// <param name="certificates">The certificates value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithCertificates(IList<CertificateReference> certificates)
        {
            return this.WithCertificates(certificates);
        }

        /// <summary>
        /// Specifies the size of virtual machine for the pool.
        /// </summary>
        /// <param name="vmSize">The size of virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithVmSize(string vmSize)
        {
            return this.WithVmSize(vmSize);
        }

        /// <summary>
        /// Specifies the deployment configuration for the pool.
        /// </summary>
        /// <param name="deploymentConfiguration">The deployment configuration value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithDeploymentConfiguration(DeploymentConfiguration deploymentConfiguration)
        {
            return this.WithDeploymentConfiguration(deploymentConfiguration);
        }

        /// <summary>
        /// Specifies the display name for the pool.
        /// </summary>
        /// <param name="displayName">The display name value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName);
        }

        /// <summary>
        /// Specifies the interNodeCommunication value for the pool.
        /// </summary>
        /// <param name="interNodeCommunication">The state indicating whether the pool permits direct communication between nodes.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithInterNodeCommunication(InterNodeCommunicationState interNodeCommunication)
        {
            return this.WithInterNodeCommunication(interNodeCommunication);
        }

        /// <summary>
        /// Specifies the max tasks can run on the pool.
        /// </summary>
        /// <param name="maxTasksPerNode">The maximum number can run on the pool.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithMaxTasksPerNode(int? maxTasksPerNode)
        {
            return this.WithMaxTasksPerNode(maxTasksPerNode);
        }

        /// <summary>
        /// Specifies the task sceduling policy for the pool.
        /// </summary>
        /// <param name="taskSchedulingPolicy">The taskScedulingPolicy value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithTaskSchedulingPolicy(TaskSchedulingPolicy taskSchedulingPolicy)
        {
            return this.WithTaskSchedulingPolicy(taskSchedulingPolicy);
        }

        /// <summary>
        /// Specifies the user accounts for the pool.
        /// </summary>
        /// <param name="userAccounts">The userAccounts value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithUserAccount(IList<UserAccount> userAccounts)
        {
            return this.WithUserAccount(userAccounts);
        }

        /// <summary>
        /// Specifies the application licenses for the pool.
        /// </summary>
        /// <param name="applicationLicenses">The applicationLicenses value.</param>
        /// <return>The next stage of the definition.</return>
        Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Pool.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithApplicationLicenses(IList<string> applicationLicenses)
        {
            return this.WithApplicationLicenses(applicationLicenses);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAccount.Update.IUpdate ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<BatchAccount.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the network configuration for the pool.
        /// </summary>
        /// <param name="networkConfiguration">The network configuration value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithNetworkConfiguration(NetworkConfiguration networkConfiguration)
        {
            return this.WithNetworkConfiguration(networkConfiguration);
        }

        /// <summary>
        /// Specifies the file system configuration for the pool.
        /// </summary>
        /// <param name="mountConfiguration">The mount configuration value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithMountConfiguration(IList<MountConfiguration> mountConfiguration)
        {
            return this.WithMountConfiguration(mountConfiguration);
        }

        /// <summary>
        /// Specifies the scale settings for the pool.
        /// </summary>
        /// <param name="scaleSettings">The scale settings value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithScaleSettings(ScaleSettings scaleSettings)
        {
            return this.WithScaleSettings(scaleSettings);
        }

        /// <summary>
        /// Specifies the start task for the pool.
        /// </summary>
        /// <param name="startTask">The start task value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithStartTask(StartTask startTask)
        {
            return this.WithStartTask(startTask);
        }

        /// <summary>
        /// Specifies the metadata for the pool.
        /// </summary>
        /// <param name="metadata">The metadata value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithMetadata(IList<MetadataItem> metadata)
        {
            return this.WithMetadata(metadata);
        }

        /// <summary>
        /// Specifies the application packages for the pool.
        /// </summary>
        /// <param name="applicationPackages">The application packages value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithApplicationPackages(IList<ApplicationPackageReference> applicationPackages)
        {
            return this.WithApplicationPackages(applicationPackages);
        }

        /// <summary>
        /// Specifies the certificates for the pool.
        /// </summary>
        /// <param name="certificates">The certificates value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithCertificates(IList<CertificateReference> certificates)
        {
            return this.WithCertificates(certificates);
        }

        /// <summary>
        /// Specifies the size of virtual machine for the pool.
        /// </summary>
        /// <param name="vmSize">The size of virtual machine.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithVmSize(string vmSize)
        {
            return this.WithVmSize(vmSize);
        }

        /// <summary>
        /// Specifies the deployment configuration for the pool.
        /// </summary>
        /// <param name="deploymentConfiguration">The deployment configuration value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithDeploymentConfiguration(DeploymentConfiguration deploymentConfiguration)
        {
            return this.WithDeploymentConfiguration(deploymentConfiguration);
        }

        /// <summary>
        /// Specifies the display name for the pool.
        /// </summary>
        /// <param name="displayName">The display name value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName);
        }

        /// <summary>
        /// Specifies the interNodeCommunication value for the pool.
        /// </summary>
        /// <param name="interNodeCommunication">The state indicating whether the pool permits direct communication between nodes.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithInterNodeCommunication(InterNodeCommunicationState interNodeCommunication)
        {
            return this.WithInterNodeCommunication(interNodeCommunication);
        }

        /// <summary>
        /// Specifies the max tasks can run on the pool.
        /// </summary>
        /// <param name="maxTasksPerNode">The maximum number can run on the pool.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithMaxTasksPerNode(int? maxTasksPerNode)
        {
            return this.WithMaxTasksPerNode(maxTasksPerNode);
        }

        /// <summary>
        /// Specifies the task sceduling policy for the pool.
        /// </summary>
        /// <param name="taskSchedulingPolicy">The taskScedulingPolicy value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithTaskSchedulingPolicy(TaskSchedulingPolicy taskSchedulingPolicy)
        {
            return this.WithTaskSchedulingPolicy(taskSchedulingPolicy);
        }

        /// <summary>
        /// Specifies the user accounts for the pool.
        /// </summary>
        /// <param name="userAccounts">The userAccounts value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithUserAccount(IList<UserAccount> userAccounts)
        {
            return this.WithUserAccount(userAccounts);
        }

        /// <summary>
        /// Specifies the application licenses for the pool.
        /// </summary>
        /// <param name="applicationLicenses">The applicationLicenses value.</param>
        /// <return>The next stage of the update.</return>
        Pool.Update.IUpdate Pool.Update.IWithAttach.WithApplicationLicenses(IList<string> applicationLicenses)
        {
            return this.WithApplicationLicenses(applicationLicenses);
        }
    }
}
