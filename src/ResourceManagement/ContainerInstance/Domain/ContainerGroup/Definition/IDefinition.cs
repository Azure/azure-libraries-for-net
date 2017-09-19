// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// Grouping of volume definition stages.
    /// </summary>
    public interface IVolumeDefinitionStages 
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the container image.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImage<ParentT> 
    {
        /// <summary>
        /// Specifies the container image to be used.
        /// </summary>
        /// <param name="imageName">The container image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithOrWithoutPorts<ParentT> WithImage(string imageName);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Grouping of volume definition stages.
    /// </summary>
    public interface IContainerInstanceDefinitionStages 
    {
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify a private image registry.
    /// </summary>
    public interface IWithPrivateImageRegistry 
    {
        /// <summary>
        /// Specifies the private container image registry server login for the container group.
        /// </summary>
        /// <param name="server">Docker image registry server, without protocol such as "http" and "https".</param>
        /// <param name="username">The username for the private registry.</param>
        /// <param name="password">The password for the private registry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume WithPrivateImageRegistry(string server, string username, string password);
    }

    /// <summary>
    /// The final stage of the volume definition.
    /// At this stage, any remaining optional settings can be specified, or the subnet definition
    /// can be attached to the parent virtual network definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithVolumeAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify a public only or private image registry.
    /// </summary>
    public interface IWithPublicOrPrivateImageRegistry  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPublicImageRegistryOnly,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPrivateImageRegistry
    {
    }

    /// <summary>
    /// The entirety of the Azure Container Instance service container group definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IBlank,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithGroup,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithOsType,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolume,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithFirstContainerInstance,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithNextContainerInstance,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify volume mount setting.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithVolumeMountSetting<ParentT> 
    {
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
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithReadOnlyVolumeMountSetting(string volumeName, string mountPath);

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeMountSetting">The name and value pair representing volume names as defined in the volumes of the container group and the local paths the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithReadOnlyVolumeMountSetting(IDictionary<string,string> volumeMountSetting);

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
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithVolumeMountSetting(string volumeName, string mountPath);

        /// <summary>
        /// Specifies the container group's volume to be mounted by the container instance at a specified mount path.
        /// Mounting an Azure file share as a volume in a container is a two-step process. First, you provide
        /// the details of the share as part of defining the container group, then you specify how you wan
        /// the volume mounted within one or more of the containers in the group.
        /// </summary>
        /// <param name="volumeMountSetting">The name and value pair representing volume names as defined in the volumes of the container group and the local paths the volume will be mounted at.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IllegalArgumentException thrown if volumeName was not defined in the respective container group definition stage.</throws>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithVolumeMountSetting(IDictionary<string,string> volumeMountSetting);
    }

    /// <summary>
    /// The first stage of the container group definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify first required container instance.
    /// </summary>
    public interface IWithFirstContainerInstance 
    {
        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the container instance.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IContainerInstanceDefinitionBlank<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithNextContainerInstance> DefineContainerInstance(string name);

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with TCP port 80 opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCreate WithContainerInstance(string imageName);

        /// <summary>
        /// Defines one container instance for the specified image with one CPU count and 1.5 GB memory, with a custom TCP port opened externally.
        /// </summary>
        /// <param name="imageName">The name of the container image.</param>
        /// <param name="port">The external port to be opened.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCreate WithContainerInstance(string imageName, int port);
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify the OS type.
    /// </summary>
    public interface IWithOsType 
    {
        /// <summary>
        /// Specifies this is a Linux container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry WithLinux();

        /// <summary>
        /// Specifies this is a Windows container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPublicOrPrivateImageRegistry WithWindows();
    }

    /// <summary>
    /// The stage of the container group definition allowing to skip the private image registry.
    /// </summary>
    public interface IWithPublicImageRegistryOnly 
    {
        /// <summary>
        /// Only public container image repository will be used to create the container instances in the container group.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPrivateImageRegistryOrVolume WithPublicImageRegistryOnly();
    }

    /// <summary>
    /// The final stage of the container instance definition.
    /// At this stage, any remaining optional settings can be specified, or the subnet definition
    /// can be attached to the parent virtual network definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithContainerInstanceAttach<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCpuCoreCount<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithMemorySize<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStartingCommandLine<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithEnvironmentVariables<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolumeMountSetting<ParentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage of the volume definition allowing to specify a read only Azure File Share name.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAzureFileShare<ParentT> 
    {
        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStorageAccountName<ParentT> WithExistingReadWriteAzureFileShare(string shareName);

        /// <summary>
        /// Specifies an existing Azure file share name.
        /// </summary>
        /// <param name="shareName">An existing Azure file share name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStorageAccountName<ParentT> WithExistingReadOnlyAzureFileShare(string shareName);
    }

    /// <summary>
    /// Grouping of the container group's volume definition stages.
    /// </summary>
    public interface IVolumeDefinition<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IVolumeDefinitionBlank<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithAzureFileShare<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStorageAccountName<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStorageAccountKey<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolumeAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the volume definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IVolumeDefinitionBlank<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithAzureFileShare<ParentT>
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the number of CPU cores.
    /// The CPU cores can be specified as a fraction, i.e. 1.5 represents one and a half atomic CPU cores
    /// will be assigned to this container instance.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCpuCoreCount<ParentT> 
    {
        /// <summary>
        /// Specifies the number of CPU cores assigned to this container instance.
        /// </summary>
        /// <param name="cpuCoreCount">The number of CPU cores.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithCpuCoreCount(double cpuCoreCount);
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify a private image registry or a volume.
    /// </summary>
    public interface IWithPrivateImageRegistryOrVolume  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPrivateImageRegistry
    {
        /// <summary>
        /// Skips the definition of volumes to be shared by the container instances.
        /// An IllegalArgumentException will be thrown if a container instance attempts to define a volume mounting.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithFirstContainerInstance WithoutVolume();

        /// <summary>
        /// Specifies a new Azure file share name to be created.
        /// </summary>
        /// <param name="volumeName">The name of the volume.</param>
        /// <param name="shareName">The Azure file share name to be created.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithFirstContainerInstance WithNewAzureFileShareVolume(string volumeName, string shareName);

        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IVolumeDefinitionBlank<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolume> DefineVolume(string name);
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithOsType>
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify one or more container ports.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPortsOrContainerInstanceAttach<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPorts<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the starting command line.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStartingCommandLine<ParentT> 
    {
        /// <summary>
        /// Specifies the starting command line.
        /// </summary>
        /// <param name="commandLine">The starting command line the container will execute after it gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithStartingCommandLine(string commandLine);

        /// <summary>
        /// Specifies the starting command lines.
        /// </summary>
        /// <param name="commandLines">The starting command lines the container will execute after it gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithStartingCommandLines(params string[] commandLines);
    }

    /// <summary>
    /// The stage of the volume definition allowing to specify the storage account key to access to the Azure file.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageAccountKey<ParentT> 
    {
        /// <summary>
        /// Specifies the storage account key to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountKey">The storage account key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolumeAttach<ParentT> WithStorageAccountKey(string storageAccountKey);
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify a volume that can be mounted by a container instance.
    /// </summary>
    public interface IWithVolume  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithFirstContainerInstance
    {
        /// <summary>
        /// Begins the definition of a volume that can be shared by the container instances in the container group.
        /// The definition must be completed with a call to  VolumeDefinitionStages.WithVolumeAttach.attach().
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IVolumeDefinitionBlank<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithVolume> DefineVolume(string name);
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the container ports.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPorts<ParentT> 
    {
        /// <summary>
        /// Specifies the container's TCP port available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="port">TCP port to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithExternalTcpPort(int port);

        /// <summary>
        /// Specifies the container's ports are available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="ports">Array of TCP ports to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithInternalPorts(params int[] ports);

        /// <summary>
        /// Specifies the container's UDP ports available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="ports">Array of UDP ports to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithExternalUdpPorts(params int[] ports);

        /// <summary>
        /// Specifies the container's port is available to internal clients only (other container instances within the container group).
        /// Containers within a group can reach each other via localhost on the ports that they have exposed,
        /// even if those ports are not exposed externally on the group's IP address.
        /// </summary>
        /// <param name="port">TCP port to be exposed internally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithInternalPort(int port);

        /// <summary>
        /// Specifies the container's TCP ports available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="ports">Array of TCP ports to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithExternalTcpPorts(params int[] ports);

        /// <summary>
        /// Specifies the container's UDP port available to external clients.
        /// A public IP address will be create to allow external clients to reach the containers within the group.
        /// To enable external clients to reach a container within the group, you must expose the port on the
        /// IP address and from the container. Because containers within the group share a port namespace, port
        /// mapping is not supported.
        /// </summary>
        /// <param name="port">UDP port to be exposed externally.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT> WithExternalUdpPort(int port);
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify (or not) the container ports.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOrWithoutPorts<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPorts<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithoutPorts<ParentT>
    {
    }

    /// <summary>
    /// The stage of the volume definition allowing to specify the storage account name to access to the Azure file.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStorageAccountName<ParentT> 
    {
        /// <summary>
        /// Specifies the storage account name to access to the Azure file.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithStorageAccountKey<ParentT> WithStorageAccountName(string storageAccountName);
    }

    /// <summary>
    /// The stage of the container group definition allowing to specify a container instance.
    /// </summary>
    public interface IWithNextContainerInstance  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithCreate
    {
        /// <summary>
        /// Begins the definition of a container instance.
        /// </summary>
        /// <param name="name">The name of the volume.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IContainerInstanceDefinitionBlank<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithNextContainerInstance> DefineContainerInstance(string name);
    }

    /// <summary>
    /// The first stage of the container instance definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IContainerInstanceDefinitionBlank<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithImage<ParentT>
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing not to specify any container ports internal or external.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithoutPorts<ParentT> 
    {
        /// <summary>
        /// Specifies that not ports will be opened internally or externally for this container instance.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithoutPorts();
    }

    /// <summary>
    /// Grouping of the container group's volume definition stages.
    /// </summary>
    public interface IContainerInstanceDefinition<ParentT>  :
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IContainerInstanceDefinitionBlank<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithImage<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithOrWithoutPorts<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithPortsOrContainerInstanceAttach<ParentT>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the memory size in GB.
    /// The memory size can be specified as a fraction, i.e. 1.5 represents one and a half GB of memory.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithMemorySize<ParentT> 
    {
        /// <summary>
        /// Specifies the memory size in GB assigned to this container instance.
        /// </summary>
        /// <param name="memorySize">The memory size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithMemorySizeInGB(double memorySize);
    }

    /// <summary>
    /// The stage of the container instance definition allowing to specify the environment variables.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithEnvironmentVariables<ParentT> 
    {
        /// <summary>
        /// Specifies the environment variable.
        /// </summary>
        /// <param name="envName">The environment variable name.</param>
        /// <param name="envValue">The environment variable value.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithEnvironmentVariable(string envName, string envValue);

        /// <summary>
        /// Specifies the environment variables.
        /// </summary>
        /// <param name="environmentVariables">The environment variables in a name and value pair to be set after the container gets initialized.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition.IWithContainerInstanceAttach<ParentT> WithEnvironmentVariables(IDictionary<string,string> environmentVariables);
    }
}