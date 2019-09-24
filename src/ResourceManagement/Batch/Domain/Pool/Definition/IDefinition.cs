// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.Pool.Definition
{
    using Microsoft.Azure.Management.Batch.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The first stage of a batch pool definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the pool definition.
    /// At this stage, any remaining optional settings can be specified, or the pool definition
    /// can be attached to the parent batch account definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
        /// <summary>
        /// Specifies the network configuration for the pool.
        /// </summary>
        /// <param name="networkConfiguration">The network configuration value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithNetworkConfiguration(NetworkConfiguration networkConfiguration);

        /// <summary>
        /// Specifies the file system configuration for the pool.
        /// </summary>
        /// <param name="mountConfiguration">The mount configuration value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithMountConfiguration(IList<MountConfiguration> mountConfiguration);

        /// <summary>
        /// Specifies the scale settings for the pool.
        /// </summary>
        /// <param name="scaleSettings">The scale settings value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithScaleSettings(ScaleSettings scaleSettings);

        /// <summary>
        /// Specifies the start task for the pool.
        /// </summary>
        /// <param name="startTask">The start task value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithStartTask(StartTask startTask);

        /// <summary>
        /// Specifies the metadata for the pool.
        /// </summary>
        /// <param name="metadata">The metadata value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithMetadata(IList<MetadataItem> metadata);

        /// <summary>
        /// Specifies the application packages for the pool.
        /// </summary>
        /// <param name="applicationPackages">The application packages value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithApplicationPackages(IList<ApplicationPackageReference> applicationPackages);

        /// <summary>
        /// Specifies the certificates for the pool.
        /// </summary>
        /// <param name="certificates">The certificates value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithCertificates(IList<CertificateReference> certificates);

        /// <summary>
        /// Specifies the size of virtual machine for the pool.
        /// </summary>
        /// <param name="vmSize">The size of virtual machine.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithVmSize(string vmSize);

        /// <summary>
        /// Specifies the deployment configuration for the pool.
        /// </summary>
        /// <param name="deploymentConfiguration">The deployment configuration value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithDeploymentConfiguration(DeploymentConfiguration deploymentConfiguration);

        /// <summary>
        /// Specifies the display name for the pool.
        /// </summary>
        /// <param name="displayName">The display name value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithDisplayName(string displayName);

        /// <summary>
        /// Specifies the interNodeCommunication value for the pool.
        /// </summary>
        /// <param name="interNodeCommunication">The state indicating whether the pool permits direct communication between nodes.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithInterNodeCommunication(InterNodeCommunicationState interNodeCommunication);

        /// <summary>
        /// Specifies the max tasks can run on the pool.
        /// </summary>
        /// <param name="maxTasksPerNode">The maximum number can run on the pool.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithMaxTasksPerNode(int? maxTasksPerNode);

        /// <summary>
        /// Specifies the task sceduling policy for the pool.
        /// </summary>
        /// <param name="taskSchedulingPolicy">The taskScedulingPolicy value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithTaskSchedulingPolicy(TaskSchedulingPolicy taskSchedulingPolicy);

        /// <summary>
        /// Specifies the user accounts for the pool.
        /// </summary>
        /// <param name="userAccounts">The userAccounts value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithUserAccount(IList<UserAccount> userAccounts);

        /// <summary>
        /// Specifies the application licenses for the pool.
        /// </summary>
        /// <param name="applicationLicenses">The applicationLicenses value.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithApplicationLicenses(IList<string> applicationLicenses);
    }

    /// <summary>
    /// The entirety of a Batch pool definition as a part of a Batch account definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }
}
