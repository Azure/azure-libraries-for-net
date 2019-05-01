// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The stage of the immutabilitypolicy update allowing to specify IfMatch.
    /// </summary>
    public interface IWithIfMatch 
    {

        /// <summary>
        /// Specifies ifMatch.
        /// </summary>
        /// <param name="ifMatch">The entity state (ETag) version of the immutability policy to update. A value of "" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update.IUpdate WithIfMatch(string ifMatch);
    }

    /// <summary>
    /// The stage of the immutabilitypolicy update allowing to specify ImmutabilityPeriodSinceCreationInDays.
    /// </summary>
    public interface IWithImmutabilityPeriodSinceCreationInDays 
    {

        /// <summary>
        /// Specifies immutabilityPeriodSinceCreationInDays.
        /// </summary>
        /// <param name="immutabilityPeriodSinceCreationInDays">The immutability period for the blobs in the container since the policy creation, in days.</param>
        /// <return>The next update stage.</return>
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update.IUpdate WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays);
    }

    /// <summary>
    /// The template for a ImmutabilityPolicy update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy>,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update.IWithIfMatch,
        Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update.IWithImmutabilityPeriodSinceCreationInDays
    {

    }
}