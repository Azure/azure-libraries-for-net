// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition
{
    /// <summary>
    /// The stage allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The first stage of the definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IRouteFilter>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The entirety of the aroute filter definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.RouteFilter.Definition.IWithCreate
    {

    }
}