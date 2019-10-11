// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Batch pool.
    /// </summary>
    public interface IPool :
        IExternalChildResource<IPool, IBatchAccount>,
        IHasInner<PoolInner>
    {
        /// <summary>
        /// Gets the display name for the pool.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the size of virtual machine for the pool.
        /// </summary>
        string VmSize { get; }

        /// <summary>
        /// Gets the network configuration for the pool.
        /// </summary>
        NetworkConfiguration NetworkConfiguration { get; }

        /// <summary>
        /// Gets the file system configuration for the pool.
        /// </summary>
        IList<MountConfiguration> MountConfiguration { get; }

        /// <summary>
        /// Gets the scale settings for the pool.
        /// </summary>
        ScaleSettings ScaleSettings { get; }

        /// <summary>
        /// Gets the start task for the pool.
        /// </summary>
        StartTask StartTask { get; }

        /// <summary>
        /// Gets the metadata for the pool.
        /// </summary>
        IList<MetadataItem> Metadata { get; }

        /// <summary>
        /// Gets the application packages for the pool.
        /// </summary>
        IList<ApplicationPackageReference> applicationPackages { get; }

        /// <summary>
        /// Gets the certificates for the pool.
        /// </summary>
        IList<CertificateReference> Certificates { get; }

        /// <summary>
        /// Gets the deployment configuration for the pool.
        /// </summary>
        DeploymentConfiguration DeploymentConfiguration { get; }

        /// <summary>
        /// Gets the state whether the pool permits direct communication between nodes.
        /// </summary>
        InterNodeCommunicationState InterNodeCommunication { get; }

        /// <summary>
        /// Gets the maximum number of tasks can run on the pool.
        /// </summary>
        int? MaxTasksPerNode { get; }

        /// <summary>
        /// Gets the task scheduling policy for the pool.
        /// </summary>
        TaskSchedulingPolicy TaskSchedulingPolicy { get; }

        /// <summary>
        /// Gets the user accounts for the pool.
        /// </summary>
        IList<UserAccount> UserAccounts { get; }

        /// <summary>
        /// Gets the application licenses for the pool.
        /// </summary>
        IList<string> ApplicationLicenses { get; }
    }
}
