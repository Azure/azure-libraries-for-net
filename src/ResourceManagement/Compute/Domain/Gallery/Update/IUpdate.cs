// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Gallery.Update
{
    /// <summary>
    /// The template for a Gallery update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IGallery>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.Gallery.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Update.IWithDescription
    {

    }

    /// <summary>
    /// The stage of the gallery update allowing to specify description.
    /// </summary>
    public interface IWithDescription  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies description for the gallery.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Compute.Fluent.Gallery.Update.IUpdate WithDescription(string description);
    }
}