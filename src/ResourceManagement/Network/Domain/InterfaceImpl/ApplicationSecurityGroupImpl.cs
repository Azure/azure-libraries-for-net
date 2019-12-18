// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ApplicationSecurityGroupImpl
    {
        /// <summary>
        /// Gets the provisioning state of the application security group resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IApplicationSecurityGroup.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the resource GUID property of the application security group resource.
        /// It uniquely identifies a resource, even if the user changes its name or
        /// migrate the resource across subscriptions or resource groups.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationSecurityGroup.ResourceGuid
        {
            get
            {
                return this.ResourceGuid();
            }
        }
    }
}