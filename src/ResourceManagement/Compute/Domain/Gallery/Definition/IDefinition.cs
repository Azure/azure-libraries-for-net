// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition
{
    /// <summary>
    /// The stage of the gallery definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The first stage of a gallery definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The entirety of the gallery definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the gallery definition allowing to specify description.
    /// </summary>
    public interface IWithDescription  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies description for the gallery.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithCreate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IGallery>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition.IWithDescription
    {

    }
}