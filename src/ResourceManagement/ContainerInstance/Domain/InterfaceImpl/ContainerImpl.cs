// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;

    internal partial class ContainerImpl 
    {
        /// <summary>
        /// Specifies the container's port is available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="port">TCP port to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalPort(int port)
        {
            return this.WithInternalPort(port) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container's ports are available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="ports">Array of TCP ports to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalPorts(params int[] ports)
        {
            return this.WithInternalPorts(ports) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container's TCP port available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="port">TCP port to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithExternalTcpPort(int port)
        {
            return this.WithExternalTcpPort(port) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container's UDP ports available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="ports">Array of UDP ports to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithExternalUdpPorts(params int[] ports)
        {
            return this.WithExternalUdpPorts(ports) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container's UDP port available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="port">UDP port to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithExternalUdpPort(int port)
        {
            return this.WithExternalUdpPort(port) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container's TCP ports available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="ports">Array of TCP ports to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithExternalTcpPorts(params int[] ports)
        {
            return this.WithExternalTcpPorts(ports) as ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies that not ports will be opened internally or externally for this container instance.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithoutPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithoutPorts()
        {
            return this.WithoutPorts() as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the starting command lines.
        /// </summary>
        /// <param name="commandLines">The starting command lines the container will execute after it gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithStartingCommandLine<ContainerGroup.Definition.IWithNextContainerInstance>.WithStartingCommandLines(params string[] commandLines)
        {
            return this.WithStartingCommandLines(commandLines) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the starting command line.
        /// </summary>
        /// <param name="commandLine">The starting command line the container will execute after it gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithStartingCommandLine<ContainerGroup.Definition.IWithNextContainerInstance>.WithStartingCommandLine(string commandLine)
        {
            return this.WithStartingCommandLine(commandLine) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeName">The volume name as defined in the volumes of the container group.</param>
        /// <param name="mountPath">The local path the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithVolumeMountSetting<ContainerGroup.Definition.IWithNextContainerInstance>.WithVolumeMountSetting(string volumeName, string mountPath)
        {
            return this.WithVolumeMountSetting(volumeName, mountPath) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeMountSetting">The name and value pair representing volume names as defined in the volumes of the container group and the local paths the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithVolumeMountSetting<ContainerGroup.Definition.IWithNextContainerInstance>.WithVolumeMountSetting(IDictionary<string,string> volumeMountSetting)
        {
            return this.WithVolumeMountSetting(volumeMountSetting) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeName">The volume name as defined in the volumes of the container group.</param>
        /// <param name="mountPath">The local path the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithVolumeMountSetting<ContainerGroup.Definition.IWithNextContainerInstance>.WithReadOnlyVolumeMountSetting(string volumeName, string mountPath)
        {
            return this.WithReadOnlyVolumeMountSetting(volumeName, mountPath) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeMountSetting">The name and value pair representing volume names as defined in the volumes of the container group and the local paths the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithVolumeMountSetting<ContainerGroup.Definition.IWithNextContainerInstance>.WithReadOnlyVolumeMountSetting(IDictionary<string,string> volumeMountSetting)
        {
            return this.WithReadOnlyVolumeMountSetting(volumeMountSetting) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the number of CPU cores assigned to this container instance.
        /// </summary>
        /// <param name="cpuCoreCount">The number of CPU cores.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithCpuCoreCount<ContainerGroup.Definition.IWithNextContainerInstance>.WithCpuCoreCount(double cpuCoreCount)
        {
            return this.WithCpuCoreCount(cpuCoreCount) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerGroup.Definition.IWithNextContainerInstance Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerGroup.Definition.IWithNextContainerInstance>.Attach()
        {
            return this.Attach() as ContainerGroup.Definition.IWithNextContainerInstance;
        }

        /// <summary>
        /// Specifies the memory size in GB assigned to this container instance.
        /// </summary>
        /// <param name="memorySize">The memory size in GB.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithMemorySize<ContainerGroup.Definition.IWithNextContainerInstance>.WithMemorySizeInGB(double memorySize)
        {
            return this.WithMemorySizeInGB(memorySize) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the environment variable.
        /// </summary>
        /// <param name="envName">The environment variable name.</param>
        /// <param name="envValue">The environment variable value.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariable(string envName, string envValue)
        {
            return this.WithEnvironmentVariable(envName, envValue) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the environment variables.
        /// </summary>
        /// <param name="environmentVariables">The environment variables in a name and value pair to be set after the container gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariables(IDictionary<string,string> environmentVariables)
        {
            return this.WithEnvironmentVariables(environmentVariables) as ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance>;
        }

        /// <summary>
        /// Specifies the container image to be used.
        /// </summary>
        /// <param name="imageName">The container image.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithOrWithoutPorts<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithImage<ContainerGroup.Definition.IWithNextContainerInstance>.WithImage(string imageName)
        {
            return this.WithImage(imageName) as ContainerGroup.Definition.IWithOrWithoutPorts<ContainerGroup.Definition.IWithNextContainerInstance>;
        }
    }
}