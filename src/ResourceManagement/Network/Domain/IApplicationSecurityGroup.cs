// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Application security group.
    /// </summary>
    public interface IApplicationSecurityGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.ApplicationSecurityGroupInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IApplicationSecurityGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ApplicationSecurityGroup.Update.IUpdate>
    {

        /// <summary>
        /// Gets the provisioning state of the application security group resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the resource GUID property of the application security group resource.
        /// It uniquely identifies a resource, even if the user changes its name or
        /// migrate the resource across subscriptions or resource groups.
        /// </summary>
        string ResourceGuid { get; }
    }
}