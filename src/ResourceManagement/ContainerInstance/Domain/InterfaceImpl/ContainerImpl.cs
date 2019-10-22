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
        /// Specifies the container's TCP port is available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="port">TCP port to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalTcpPort(int port)
        {
            return this.WithInternalTcpPort(port);
        }

        /// <summary>
        /// Specifies the container's UDP port is available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="port">UDP port to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalUdpPort(int port)
        {
            return this.WithInternalUdpPort(port);
        }

        /// <summary>
        /// Specifies the container's TCP ports are available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="ports">Array of TCP ports to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalTcpPorts(params int[] ports)
        {
            return this.WithInternalTcpPorts(ports);
        }

        /// <summary>
        /// Specifies the container's UDP ports are available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="ports">Array of UDP ports to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithInternalUdpPorts(params int[] ports)
        {
            return this.WithInternalUdpPorts(ports);
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
            return this.WithExternalTcpPort(port);
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
            return this.WithExternalUdpPorts(ports);
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
            return this.WithExternalUdpPort(port);
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
            return this.WithExternalTcpPorts(ports);
        }

        /// <summary>
        /// Specifies that not ports will be opened internally or externally for this container instance.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithoutPorts<ContainerGroup.Definition.IWithNextContainerInstance>.WithoutPorts()
        {
            return this.WithoutPorts();
        }

        /// <summary>
        /// Specifies the starting command line.
        /// </summary>
        /// <param name="executable">The executable which it will call after initializing the container.</param>
        /// <param name="parameters">The parameter list for the executable to be called.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithStartingCommandLineBeta<ContainerGroup.Definition.IWithNextContainerInstance>.WithStartingCommandLine(string executable, params string[] parameters)
        {
            return this.WithStartingCommandLine(executable, parameters);
        }

        /// <summary>
        /// Specifies the starting command line.
        /// </summary>
        /// <param name="executable">The executable or path to the executable that will be called after initializing the container.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithStartingCommandLine<ContainerGroup.Definition.IWithNextContainerInstance>.WithStartingCommandLine(string executable)
        {
            return this.WithStartingCommandLine(executable);
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
            return this.WithVolumeMountSetting(volumeName, mountPath);
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
            return this.WithVolumeMountSetting(volumeMountSetting);
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
            return this.WithReadOnlyVolumeMountSetting(volumeName, mountPath);
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
            return this.WithReadOnlyVolumeMountSetting(volumeMountSetting);
        }

        /// <summary>
        /// Specifies the number of CPU cores assigned to this container instance.
        /// </summary>
        /// <param name="cpuCoreCount">The number of CPU cores.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithCpuCoreCount<ContainerGroup.Definition.IWithNextContainerInstance>.WithCpuCoreCount(double cpuCoreCount)
        {
            return this.WithCpuCoreCount(cpuCoreCount);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ContainerGroup.Definition.IWithNextContainerInstance Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ContainerGroup.Definition.IWithNextContainerInstance>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the memory size in GB assigned to this container instance.
        /// </summary>
        /// <param name="memorySize">The memory size in GB.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithMemorySize<ContainerGroup.Definition.IWithNextContainerInstance>.WithMemorySizeInGB(double memorySize)
        {
            return this.WithMemorySizeInGB(memorySize);
        }

        /// <summary>
        /// Specifies the environment variable.
        /// </summary>
        /// <param name="envName">The environment variable name.</param>
        /// <param name="envValue">The environment variable value.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariable(string envName, string envValue)
        {
            return this.WithEnvironmentVariable(envName, envValue);
        }

        /// <summary>
        /// Specifies the environment variables.
        /// </summary>
        /// <param name="environmentVariables">The environment variables in a name and value pair to be set after the container gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariables(IDictionary<string,string> environmentVariables)
        {
            return this.WithEnvironmentVariables(environmentVariables);
        }

        /// <summary>
        /// Specifies a collection of name and secure value pairs for the environment variables.
        /// </summary>
        /// <param name="envName">The environment variable name.</param>
        /// <param name="securedValue">The environment variable secured value.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariableWithSecuredValue(string envName, string securedValue)
        {
            return this.WithEnvironmentVariableWithSecuredValue(envName, securedValue);
        }

        /// <summary>
        /// Specifies a collection of name and secure value pairs for the environment variables.
        /// </summary>
        /// <param name="environmentVariables">The environment variables in a name and value pair to be set after the container gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        IWithContainerInstanceAttach<ContainerGroup.Definition.IWithNextContainerInstance> IWithEnvironmentVariables<ContainerGroup.Definition.IWithNextContainerInstance>.WithEnvironmentVariablesWithSecuredValue(IDictionary<string, string> environmentVariables)
        {
            return this.WithEnvironmentVariablesWithSecuredValue(environmentVariables);
        }
        /// <summary>
        /// Specifies the container image to be used.
        /// </summary>
        /// <param name="imageName">The container image.</param>
        /// <return>The next stage of the definition.</return>
        ContainerGroup.Definition.IWithOrWithoutPorts<ContainerGroup.Definition.IWithNextContainerInstance> ContainerGroup.Definition.IWithImage<ContainerGroup.Definition.IWithNextContainerInstance>.WithImage(string imageName)
        {
            return this.WithImage(imageName);
        }
    }
}