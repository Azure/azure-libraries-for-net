// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for Container Service orchestrator types.
    /// </summary>
    public class ContainerServiceOrchestratorTypes :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.Models.ContainerServiceOrchestratorTypes>
    {
        public static readonly ContainerServiceOrchestratorTypes Kubernetes = Parse("Kubernetes");
        public static readonly ContainerServiceOrchestratorTypes Swarm = Parse("Swarm");
        public static readonly ContainerServiceOrchestratorTypes DCOS = Parse("DCOS");
        public static readonly ContainerServiceOrchestratorTypes DockerCE = Parse("DockerCE");
        public static readonly ContainerServiceOrchestratorTypes Custom = Parse("Custom");
    }
}
