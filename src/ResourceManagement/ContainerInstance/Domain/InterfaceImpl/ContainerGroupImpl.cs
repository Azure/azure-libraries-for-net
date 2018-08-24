// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update;
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
            return this.WithPrivateImageRegistry(server, username, password);
        }

        /// <summary>
        /// Specifies the restart policy for all the container instances within the container group.
        /// </summary>
        /// <param name="restartPolicy">The restart policy for all the container instances within the container group.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithRestartPolicyBeta.WithRestartPolicy(ContainerGroupRestartPolicy restartPolicy)
        {
            return this.WithRestartPolicy(restartPolicy);
        }

        /// <summary>
        /// Skips the definition of volumes to be shared by the container instances.
        /// An IllegalArgumentException will be thrown if a container instance attempts to define a volume mounting.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithoutVolume()
        {
            return this.WithoutVolume();
        }

        /// <summary>
        /// Specifies a new Azure file share name to be created.
        /// </summary>
        /// <param name="volumeName">The name of the volume.</param>
        /// <param name="shareName">The Azure file share name to be created.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.WithNewAzureFileShareVolume(string volumeName, string shareName)
        {
            return this.WithNewAzureFileShareVolume(volumeName, shareName);
        }

        /// <summary>
        /// Specifies an empty directory volume that can be shared by the container instances in the container group.
        /// </summary>
        /// <param name="name">The name of the empty directory volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithFirstContainerInstance ContainerGroup.Definition.IWithPrivateImageRegistryOrVolumeBeta.WithEmptyDirectoryVolume(string name)
        {
            return this.WithEmptyDirectoryVolume(name);
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name);
        }

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IVolumeDefinitionBlank<ContainerGroup.Definition.IWithVolume> ContainerGroup.Definition.IWithVolume.DefineVolume(string name)
        {
            return this.DefineVolume(name);
        }

        /// <summary>
        /// <summary>
        /// Restarts all containers in a container group in place. If container image has updates, new image will be downloaded.
        /// </summary>
        void Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Restart()
        {
 
            this.Restart();
        }

        /// <summary>
        /// Restarts all containers in a container group in place asynchronously. If container image has updates, new image will be downloaded.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.RestartAsync(CancellationToken cancellationToken)
        {
 
            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Stops all containers in a container group. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        void Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Stops all containers in a container group asynchronously. Compute resources will be de-allocated and billing will stop.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
        }

        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with TCP port 80 opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName)
        {
            return this.WithContainerInstance(imageName);
        }

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with a custom TCP port opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <param name="port">The external port to be opened.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithFirstContainerInstance.WithContainerInstance(string imageName, int port)
        {
            return this.WithContainerInstance(imageName, port);
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the container instance.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithFirstContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name);
        }

        /// <summary>
        /// Specifies the DNS prefix to be used to create the FQDN for the container group.
        /// </summary>
        /// <param name="dnsPrefix">The DNS prefix to be used to create the FQDN for the container group.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithCreate ContainerGroup.Definition.IWithDnsPrefix.WithDnsPrefix(string dnsPrefix)
        {
            return this.WithDnsPrefix(dnsPrefix);
        }

        /// <summary>
        /// Only public container image repository will be used to create the container instances in the container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume ContainerGroup.Definition.IWithPublicImageRegistryOnly.WithPublicImageRegistryOnly()
        {
            return this.WithPublicImageRegistryOnly();
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
        /// Gets the container instances in this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.Container> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Containers
        {
            get
            {
                return this.Containers();
            }
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
                return this.Volumes();
            }
        }

        /// <summary>
        /// Gets the Docker image registry servers by which the container group is created from.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ImageRegistryServers
        {
            get
            {
                return this.ImageRegistryServers();
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
        /// Gets the container group events.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.EventModel> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Events
        {
            get
            {
                return this.Events();
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
        /// Starts the exec command for a specific container instance.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>The log lines from the end, up to the number specified.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExecuteCommand(string containerName, string command, int row, int column)
        {
            return this.ExecuteCommand(containerName, command, row, column);
        }

        /// <summary>
        /// Starts the exec command for a specific container instance within the container group.
        /// </summary>
        /// <param name="containerName">The container instance name.</param>
        /// <param name="command">The command to be executed.</param>
        /// <param name="row">The row size of the terminal.</param>
        /// <param name="column">The column size of the terminal.</param>
        /// <throws>IllegalArgumentException thrown if parameters fail the validation.</throws>
        /// <return>A representation of the future computation of this call.</return>
        async Task<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerExecResponse> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExecuteCommandAsync(string containerName, string command, int row, int column, CancellationToken cancellationToken)
        {
            return await this.ExecuteCommandAsync(containerName, command, row, column, cancellationToken);
        }

        /// <summary>
        /// Gets all the ports publicly exposed for this container group.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.Port> Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.ExternalPorts
        {
            get
            {
                return this.ExternalPorts();
            }
        }

        /// <summary>
        /// Gets the base level OS type required by the containers in the group.
        /// </summary>
        OSTypeName Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Gets the container group restart policy.
        /// </summary>
        Models.ContainerGroupRestartPolicy Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.RestartPolicy
        {
            get
            {
                return this.RestartPolicy();
            }
        }

        /// <summary>
        /// Gets the DNS prefix which was specified at creation time.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.DnsPrefix
        {
            get
            {
                return this.DnsPrefix();
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
        /// Gets the FQDN for the container group.
        /// </summary>
        string Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithNextContainerInstance.DefineContainerInstance(string name)
        {
            return this.DefineContainerInstance(name);
        }

        /// <summary>
        /// Specifies this is a Linux container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithLinux()
        {
            return this.WithLinux();
        }

        /// <summary>
        /// Specifies this is a Windows container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry ContainerGroup.Definition.IWithOsType.WithWindows()
        {
            return this.WithWindows();
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }
    }
}