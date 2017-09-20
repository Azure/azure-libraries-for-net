// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;

    internal partial class ContainerGroupImpl
    {
        /// <summary>
        /// Specifies the private container image registry server login for the container group.
        /// </summary>
        /// <param name="server">Docker image registry server, without protocol such as "http" and "https".</param>
        /// <param name="username">The username for the private registry.</param>
        /// <param name="password">The password for the private registry.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume ContainerGroup.Definition.IWithPrivateImageRegistry.WithPrivateImageRegistry(string server, string username, string password)
        {
            return this.WithPrivateImageRegistry(server, username, password) as ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume;
        }

        /// <summary>
        /// Specifies a new Azure file share name to be created.
        /// </summary>
        /// <param name="volumeName">The name of the volume.</param>
        /// <param name="shareName">The Azure file share name to be created.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithNewAzureFileShareVolume(string volumeName, string shareName)
        {
            return this.WithNewAzureFileShareVolume(volumeName, shareName) as ContainerGroup.Definition.IWithFirstContainerInstance;
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name) as ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume>;
        }

        /// <summary>
        /// Skips the definition of volumes to be shared by the container instances.
        /// An IllegalArgumentException will be thrown if a container instance attempts to define a volume mounting.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithoutVolume()
        {
            return this.WithoutVolume() as ContainerGroup.Definition.IWithFirstContainerInstance;
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name) as ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume>;
        }

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with TCP port 80 opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName)
        {
            return this.WithContainerInstance(imageName) as ContainerGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with a custom TCP port opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <param name="port">The external port to be opened.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName, int port)
        {
            return this.WithContainerInstance(imageName, port) as ContainerGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the container instance.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithFirstContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name) as ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Only public container image repository will be used to create the container instances in the container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume ContainerGroup.Definition.IWithPublicImageRegistryOnly.WithPublicImageRegistryOnly()
        {
            return this.WithPublicImageRegistryOnly() as ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume;
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContentAsync(string containerName, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(containerName, cancellationToken);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContentAsync(string containerName, int tailLineCount, CancellationToken cancellationToken)
        {
            return await this.GetLogContentAsync(containerName, tailLineCount, cancellationToken);
        }

        /// <summary>
        /// Gets the Docker image registry servers by which the container group is created from.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ImageRegistryServers
        {
            get
            {
                return this.ImageRegistryServers() as System.Collections.Generic.IReadOnlyCollection<string>;
            }
        }

        /// <summary>
        /// Gets the TCP ports publicly exposed for this container group.
        /// </summary>
        int[] Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalTcpPorts
        {
            get
            {
                return this.ExternalTcpPorts();
            }
        }

        /// <summary>
        /// Gets `always` Always restart.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.isAlwaysRestart
        {
            get
            {
                return this.IsAlwaysRestart();
            }
        }

        /// <summary>
        /// Gets the state of the container group; only valid in response.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets all the ports publicly exposed for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.Port> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalPorts
        {
            get
            {
                return this.ExternalPorts() as System.Collections.Generic.IReadOnlyCollection<Models.Port>;
            }
        }

        /// <summary>
        /// Gets the provisioningState of the container group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the UDP ports publicly exposed for this container group.
        /// </summary>
        int[] Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalUdpPorts
        {
            get
            {
                return this.ExternalUdpPorts();
            }
        }

        /// <summary>
        /// Gets the container instances in this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.Container> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Containers
        {
            get
            {
                return this.Containers() as System.Collections.Generic.IReadOnlyDictionary<string,Models.Container>;
            }
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>All available log lines.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContent(string containerName)
        {
            return this.GetLogContent(containerName);
        }

        /// <summary>
        /// Get the log content for the specified container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="tailLineCount">Only get the last log lines up to this.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.GetLogContent(string containerName, int tailLineCount)
        {
            return this.GetLogContent(containerName, tailLineCount);
        }

        /// <summary>
        /// Gets the IP address.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IPAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        /// <summary>
        /// Gets the volumes for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.Volume> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Volumes
        {
            get
            {
                return this.Volumes() as System.Collections.Generic.IReadOnlyDictionary<string,Models.Volume>;
            }
        }

        /// <summary>
        /// Gets true if IP address is public.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.IsIPAddressPublic
        {
            get
            {
                return this.IsIPAddressPublic();
            }
        }

        /// <summary>
        /// Gets the base level OS type required by the containers in the group.
        /// </summary>
        OSTypeName Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.OSType
        {
            get
            {
                return this.OSType() as OSTypeName;
            }
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithNextContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name) as ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies this is a Linux container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithLinux()
        {
            return this.WithLinux() as ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry;
        }

        /// <summary>
        /// Specifies this is a Windows container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithWindows()
        {
            return this.WithWindows() as ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup;
        }
    }
}