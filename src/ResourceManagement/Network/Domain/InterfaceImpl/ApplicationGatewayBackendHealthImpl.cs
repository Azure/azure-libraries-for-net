// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayBackendHealthImpl
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGateway Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets the health information about each associated backend HTTP settings configuration, indexed by its name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth.HttpConfigurationHealths
        {
            get
            {
                return this.HttpConfigurationHealths();
            }
        }

        /// <summary>
        /// Gets the application gateway backend address pool that is health information pertains to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth.Backend
        {
            get
            {
                return this.Backend();
            }
        }
    }
}